// Get Cart Div
const cart = document.querySelector(".cart"); 
const cartTotal = document.getElementById("cart-total");

// Get items that are stored in local storage, if any
// Otherwise, convert the localStorage string to an array
// Get the existing print data from local storage
var printCart = localStorage.getItem('printsInCart');
printCart = printCart ? JSON.parse(printCart) : [];

console.log(printCart.length);
console.log(printCart);

if(printCart.length <= 0)
{
    cart.innerHTML = "<p>Your cart is empty. Why not take a look around?</p>";
}
else{
    //Query the database for more details about the items in cart
    let cartCounter = 0;
    printCart.forEach(printItem => {
        CreateCartItem(printItem, cartCounter);
        cartCounter++;
    });
    cartTotal.style.display = 'block';
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
    cartItemQuantity.innerHTML = `<button class="minus-btn" type="button" name="button">
                                    <img src="icons/minus.svg" alt="" />
                                </button>
                                <input type="number" name="name" value="1" min="1" max=${maxQty}>
                                <button class="plus-btn" type="button" name="button">
                                    <img src="icons/plus.svg" alt="" />
                                </button>`;
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
        cart.innerHTML = "<p>Your cart is empty. Why not take a look around?</p>";
        cartTotal.style.display = 'none';

    }
    else{
        printCart = printCart.slice(0, cartItemNum).concat(printCart.slice(cartItemNum + 1, printCart.length));
        // Save back to localStorage
        localStorage.setItem('printsInCart', JSON.stringify(printCart));
    }
       

}
