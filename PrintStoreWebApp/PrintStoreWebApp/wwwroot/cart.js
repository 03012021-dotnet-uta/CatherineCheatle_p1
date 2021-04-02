const signUp = document.getElementById('signup-btn');
const signOut = document.getElementById('signout-btn');
const person = localStorage.getItem('person');
signOut.addEventListener('click', (e) => {
    localStorage.removeItem('person');
  })
if(person == null)
{
    signUp.style.display = 'block';
    signOut.style.display = 'none';
}
else{
    signUp.style.display = 'none';
    signOut.style.display = 'block';
}

// Get Cart Div
let cart = document.querySelector(".cart"); 
let cartTotal = document.querySelector(".cart-total");

// Get items that are stored in local storage, if any
// Otherwise, convert the localStorage string to an array
// Get the existing print data from local storage
var printCart = localStorage.getItem('printsInCart');
printCart = printCart ? JSON.parse(printCart) : [];

if(printCart.length <= 0)
{
    cart.innerHTML = "<p>Your cart is empty. Why not take a look around?</p>";
    cartTotal.style.display = 'none';
}
else{
    //Query the database for more details about the items in cart
    let cartCounter = 0;
    printCart.forEach(printItem => {
        CreateCartItem(printItem, cartCounter);
        cartCounter++;
    });
    CalculateTotals();
}

function CreateCartItem(data, cartItemNum)
{
    // create div class cart-item
    let printID = data.printID;
    let cartItem = document.createElement('div');
    cartItem.className = 'cart-item';
    cartItem.id = cartItemNum;

    // create div class buttons (child of cart-item)
    let cartDelButton = document.createElement('div');
    cartDelButton.className = "buttons";
    cartDelButton.innerHTML = `<button class="del-btn" type="button" name="button">
                                    <img src="icons/delete.svg" alt="" onclick="delClick(${cartItemNum})"/>
                                </button>`;
    // create div class cart-item-image
    let cartItemImage = document.createElement('div');
    cartItemImage.className = "cart-item-image";
    let cartImage = document.createElement('img');
    cartImage.src = data.printImage;
    cartItemImage.appendChild(cartImage);

    // create div class cart-item-description
    let cartItemDescription = document.createElement('div');
    cartItemDescription.className = "cart-item-description";
    // art title child
    let cartArtTitle = document.createElement('h3');
    cartArtTitle.textContent = data.printTitle;
    cartItemDescription.appendChild(cartArtTitle);
    // artist name child
    let cartArtist = document.createElement('h5');

    //check if names are null
    let artistfirst = data.artistFName;
    let artistlast = data.artistLName;

    if(artistfirst == null)
    {
        artistfirst = "";
    }
    if(artistlast == null)
    {
        artistlast = "";
    }
    
    const artistFullName = artistfirst + " " + artistlast;
    cartArtist.textContent = artistFullName;
    cartItemDescription.appendChild(cartArtist);
    // descrip child
    let cartDescrip = document.createElement('p');
    cartDescrip.textContent = data.printDecription;
    cartItemDescription.appendChild(cartDescrip);
    
    // create div class cart-item-quantity
    //check quanity to set max of input
    let maxQty = 30;
    if(data.printQty < maxQty)
    {
        maxQty = data.printQty;
    }

    let cartItemQuantity = document.createElement('div');
    cartItemQuantity.className = "cart-item-quantity";
    let quantityBox = document.createElement('input');
    quantityBox.type = 'number';
    quantityBox.value = '1';
    quantityBox.min = '1';
    quantityBox.max = maxQty;
    quantityBox.addEventListener("input", QtyBox, false);
    let qtyBoxWarning = document.createElement('span');
    qtyBoxWarning.className = 'qtyWarning';
    cartItemQuantity.appendChild(quantityBox);
    cartItemQuantity.appendChild(qtyBoxWarning);

    // create div class cart-item-total-price
    let cartItemTotalPrice = document.createElement('div');
    cartItemTotalPrice.className = "cart-item-total-price";
    cartItemTotalPrice.textContent = data.printPrice;

    //add all children to cart item div
    cartItem.appendChild(cartDelButton);
    cartItem.appendChild(cartItemImage);
    cartItem.appendChild(cartItemDescription);
    cartItem.appendChild(cartItemQuantity);
    cartItem.appendChild(cartItemTotalPrice);

    // add cart item to cart
    cart.appendChild(cartItem);
}

// Delete from cart
function delClick(cartItemNum)
{        
    console.log(cartItemNum);
    const cartItemDiv = document.getElementById(cartItemNum);
    cartItemDiv.style.display = 'none';

    // get cart from local storage
    var printCart = localStorage.getItem('printsInCart');
    printCart = printCart ? JSON.parse(printCart) : [];

    // delete item from cart
    if (printCart.length ==  0)
    {
        localStorage.removeItem('printsInCart');
    }
    else{
        printCart = printCart.slice(0, cartItemNum).concat(printCart.slice(cartItemNum + 1, printCart.length));
        // Save back to localStorage
        localStorage.setItem('printsInCart', JSON.stringify(printCart));
    }

    location.reload();

}

// Calculate the totals for the user's cart
function CalculateTotals() {

    console.log("Calculate");
    console.log(printCart);

    // calculate subtotal
    let cartSubtotal = 0;

    printCart.forEach(printItem => {
        cartSubtotal += printItem.printPrice;
    });
    let userSubtotal = document.getElementById("cart-subtotal");
    userSubtotal.textContent = cartSubtotal;

    // calculate tax
    const TAX = 0.07;
    let cartTax = cartSubtotal * TAX;
    let userTax = document.getElementById("cart-tax");
    userTax.textContent = cartTax;

    // calculate shipping
    const SHIPPING_1 = 11.99;
    const SHIPPING_2 = 5.99;
    const SHIPPING_3 = 0;
    let cartShipping = 0;
    if (cartSubtotal > 75) {
        cartShipping = SHIPPING_3;
    }
    else if (cartSubtotal > 40) {
        cartShipping = SHIPPING_2;
    }
    else {
        cartShipping = SHIPPING_1;
    }
    let userShipping = document.getElementById("cart-shipping");
    userShipping.textContent = cartShipping;

    // calculate total
    let cartTotal = cartSubtotal + cartTax + cartShipping;
    let userTotal = document.getElementById("cart-grand-total");
    userTotal.textContent = cartTotal;

    localStorage.setItem('salesTaxRate', TAX);
    localStorage.setItem('subtotal', cartSubtotal);
    localStorage.setItem('tax', cartTax);
    localStorage.setItem('shipping', cartShipping);
    localStorage.setItem('total', cartTotal);
}

// 
//check quantity box
function QtyBox(event){
    let boxChangeEvent = event.target;
    let input = boxChangeEvent.value;
    let minAmt = boxChangeEvent.min;
    let maxAmt = boxChangeEvent.max;
    let checkoutBtn = document.querySelector(".checkout-btn");
    let warning = boxChangeEvent.nextSibling;
    console.log(checkoutBtn);
    
    //check if input is valid, if not let the user know and disable checkout button
    if ((Number(input) > Number(maxAmt)) || (Number(input) < Number(minAmt)) || (input = ""))
    {
        boxChangeEvent.style.border = 'solid 1px red';
        warning.innerHTML = "<p style = 'color: red'>" + "Please enter valid number</p><br>" 
                                + `Choose a number between ${minAmt} and ${maxAmt}`;
        warning.style.color = 'red';
        warning.style.fontSize = 'medium';
        checkoutBtn.disabled = true;
    }
    else {
        warning.innerHTML="";
        boxChangeEvent.style.border = 'solid 1px black';
        checkoutBtn.disabled = false;
        
    }
}

function checkoutUser(){
    // check if user is signed in
    let user = localStorage.getItem('person');
    user = JSON.parse(user);
    console.log(user);
    if (user == null) {
        alert("You must sign in before checking out!");
    }
    else {
        console.log(user.customerFName);
        location = "checkout.html";
    }
    


}