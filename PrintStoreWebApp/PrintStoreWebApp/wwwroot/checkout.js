'use strict'
// Cart Container
let cartContainer = document.querySelector(".checkout-items");
let totalContainer = document.querySelector(".checkout-totals");

//get totals and sales tax rate
let checkoutSubtotal = localStorage.getItem('subtotal');
let checkoutTax = localStorage.getItem('tax');
let checkoutShipping = localStorage.getItem('shipping');
let checkoutTotal = localStorage.getItem('total');
const TAX = localStorage.getItem('salesTaxRate');
CreateTotals(checkoutSubtotal, checkoutTax, checkoutShipping, checkoutTotal);

// Get cart information and display
let printCart = localStorage.getItem('printsInCart');
printCart = printCart ? JSON.parse(printCart) : [];
let storeID = printCart[0].storeId;

printCart.forEach(checkOutItem => {
    let checkoutItemStorename = checkOutItem.storeName;
    let checkoutItemPrintname = checkOutItem.printTitle;

    fetch(`api/print/${checkoutItemStorename}/${checkoutItemPrintname}`)
    .then(response => response.json())
    .then(data => {
      console.log(data); 
      // if the quantity is less than zero, alert that item is unavailiable
      if(data[0].printQty <= 0)
      {
        alert(`${checkOutItem.printTitle} is out of stock. Removed 
                 from your checkout`);
                 RecalculateTotals(data[0].printPrice);
      }  
      else{
        console.log(data[0].printQty)
        CreateCheckoutItem(checkOutItem);

        //Create final cart for local storage
        var finalCart = localStorage.getItem('finalCart');
        finalCart = finalCart ? JSON.parse(finalCart) : [];
        finalCart.push(data[0]);
        // Save back to localStorage
        localStorage.setItem('finalCart', JSON.stringify(finalCart));
        
        // decrease inventory
        let printData = {
            storeId: checkOutItem.storeId,
            printId: checkOutItem.printID,
            purchaseQty: 1
        }
        console.log(printData);
        fetch('api/inventory/decreaseInventory', {
            method: 'POST',
            headers: {
                'Accept' : 'application/json',
                'Content-type': 'application/json'
            },
            body:JSON.stringify(printData)
        }).then(response => {
            if(!response.ok){
                throw new Error(`Network response was not ok (${response.status})`);
            }else{
                return response.json()
            }
        }).then((jsonReponse) => {
            console.log(jsonReponse);
        }).catch(function(err){
            console.log('Failed to fetch page: ', err);
        })

      }
    })
    .catch(function(err) {  
      console.log('Failed to fetch page: ', err);  
    });
    
});

// Recalculation totals
function RecalculateTotals(removePrice){
    checkoutSubtotal -= removePrice;
    checkoutTax = checkoutSubtotal * TAX;

    const SHIPPING_1 = 11.99;
    const SHIPPING_2 = 5.99;
    const SHIPPING_3 = 0;

    let checkoutShipping = 0;

    if (checkoutSubtotal > 75) {
        checkoutShipping = SHIPPING_3;
    }
    else if (checkoutSubtotal > 40) {
        checkoutShipping = SHIPPING_2;
    }
    else {
        checkoutShipping = SHIPPING_1;
    }

    checkoutTotal = checkoutSubtotal + checkoutTax + checkoutShipping;

    // Update local storage
    localStorage.setItem('subtotal', checkoutSubtotal);
    localStorage.setItem('tax', checkoutTax);
    localStorage.setItem('shipping', checkoutShipping);
    localStorage.setItem('total', checkoutTotal);
    // Create new totals to display
    CreateTotals(checkoutSubtotal, checkoutTax, checkoutShipping, checkoutTotal);

}


//Function to create checkout items
function CreateCheckoutItem(data){
    //create paragraph parent element
    let pElement = document.createElement('p');
    let itemName = data.printTitle;
    let itemPrice = data.printPrice;
    pElement.innerHTML = `<p><a href="#">${itemName}</a> <span class="price">&#36;${itemPrice}</span></p> `;
    cartContainer.appendChild(pElement);
}

function CreateTotals(s, t, ship, gt){
    let totalElement = document.createElement('p');
    totalElement.innerHTML = `<p>Subtotal <span class="price" id="checkout-total"><b>${s}</b></span></p>
                            <p>Tax <span class="price" id="checkout-total"><b>${t}</b></span></p>
                            <p>Shipping <span class="price" id="checkout-total"><b>${ship}</b></span></p>
                            <p>Total <span class="price" id="checkout-total"><b>${gt}</b></span></p>`;
    totalContainer.appendChild(totalElement);
}

// submit checkout, create order
const checkoutForm = document.querySelector(".checkout-form");

checkoutForm.addEventListener('submit', (e) => {
    e.preventDefault();
    let finalCart = localStorage.getItem('finalCart');
    finalCart = finalCart ? JSON.parse(finalCart) : [];

    // get form input values and other need info
    let userFName = checkoutForm.fname.value.trim();
    let userLName = checkoutForm.lname.value.trim();
    let userPhoneNum = checkoutForm.phone.value.trim();
    let userAdd = checkoutForm.adr.value.trim();
    let userCity = checkoutForm.city.value.trim();
    let userState = checkoutForm.state.value.trim();
    let userZip = checkoutForm.zip.value.trim();
    let orderDate = new Date();
    let orderDeliveryDate = new Date();
    orderDeliveryDate.setDate(orderDeliveryDate.getDate() + 7);
    orderDate = orderDate.toISOString();
    orderDeliveryDate = orderDeliveryDate.toISOString();
    let userSubtotal = (Number(localStorage.getItem('subtotal')) + Number(localStorage.getItem('shipping')));
    let userTax = localStorage.getItem('tax');
    let userTotalCost = localStorage.getItem('total');
    let userId = localStorage.getItem('person');
    let userStoreID = finalCart[0].storeId;

    // create raw order object
    const userData = {
        CustomerId: userId,
        StoreId: userStoreID, 
        OrderDate: orderDate,
        OrderDeliveryDate:orderDeliveryDate,
        OrderSubtotal: userSubtotal,
        OrderTax: userTax, 
        OrderTotalPrice: userTotalCost,
        CustomerFName: userFName,
        CustomerLName: userLName,
        CustomerStreet: userAdd, 
        CustomerCity: userCity, 
        CustomerState: userState, 
        CustomerZip: userZip,
        CustomerPhone: userPhoneNum,
        prints: finalCart
    }

    console.log(userData);

    fetch('api/order/placeorder', {
        method: 'POST',
        headers: {
          'Accept': 'application/json',
          'Content-Type':'application/json'
        },
        body:JSON.stringify(userData)
        })
        .then(response => {
          if (!response.ok) {
            throw new Error(`Network response was not ok (${response.status})`);
          }
          else       // When the page is loaded convert it to text
            return response.json();
        })
        .then((jsonResponse) => {
            console.log(jsonResponse);
            localStorage.setItem('ordernum', jsonResponse.ordersId);
            return jsonResponse;
        })
        .then(res => {
            localStorage.removeItem('printsInCart');
          location = 'index.html';
        })
        .catch(function(err) {  
            console.log('Failed to fetch page: ', err);  
        });
});


// // add to db
//                 fetch('api/order/addorderline', {
//                     method: 'POST',
//                     headers: {
//                       'Accept': 'application/json',
//                       'Content-Type':'application/json'
//                     },
//                     body:JSON.stringify(userData)
//                 })
//                 .then(response => {
//                     if (!response.ok) {
//                       throw new Error(`Network response was not ok (${response.status})`);
//                     }
//                     else       // When the page is loaded convert it to text
//                       return response.json();
//                 }).catch(function(err) {  
//                     console.log('Failed to fetch page: ', err);  
//                 });