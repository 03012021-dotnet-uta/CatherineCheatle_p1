// Get Select Store button, Store Drop Down Menu and card wrapper div
const dropDownBtn = document.getElementsByClassName("dropbtn");
const dropDownMenu = document.getElementById("myDropdown");
const cardWrapper = document.querySelector('.wrapper');

// Function for when Select Store Button is clicked
function myFunction() {
  // Get store name from local storage and split into an array
  var storeNames = window.localStorage.getItem('storeNames');
  var storeArr = storeNames.split(",").map(item => item.trim());

  // If drop down list is empty, then add stores to list
  if(dropDownMenu.childElementCount == 0)
  {
    storeArr.forEach(s => {
        var node = document.createElement('a');
        var linkText = document.createTextNode(s);
        node.appendChild(linkText);
        node.addEventListener('click', storeClick, false);
        dropDownMenu.appendChild(node);
    });
  }

  // If the Select Store Button is pressed again then close the drop down list
  dropDownMenu.classList.toggle("show");

  //check if any child elements were clicked
  function storeClick(event)
  {
    // Get the store element that triggered the click
    var x = event.target;
    const storename = x.textContent.trim();
    // Clear the browse page to then add the store's inventory
    cardWrapper.innerHTML = "";

    //add store name to local storage 
    localStorage.setItem('ChosenStore', storename);

    //fetch inventory and display to page
    fetch(`api/inventory/storeInventory/${storename}`)
      .then(response => response.json())
      .then(data => {
          console.log(data); 
          data.forEach(print => {
            CreateCard(print);
          });    
      })
      .catch(function(err) {  
          console.log('Failed to fetch page: ', err);  
      });
  }
}

//function to create card for displaying print item
function CreateCard(printinfo){
  //Create a card
  var cardNode = document.createElement('div');
  //add class to div
  cardNode.className = 'card';
  //Create img child for card
  var imgNode = document.createElement('img');
  //add img src
  imgNode.src = printinfo.printImage;
  //add alt to img
  imgNode.alt = printinfo.printName;
  //create div child
  var childDivNode = document.createElement('div');
  //set class of child div
  childDivNode.className = "info";
  //create child heading for child div
  var headingChildNode = document.createElement('h2');
  //add text to heading
  headingChildNode.textContent = printinfo.printName;
  //create child p for child div
  var pChildNode = document.createElement('p');
  //add text to p
  pChildNode.textContent = printinfo.printDescrip;
  //create link child for child div
  var aChildNode = document.createElement('a');
  //add class
  aChildNode.className = "btn";
  //add href
  aChildNode.href = "#";
  //add text
  aChildNode.textContent = "Add to Cart";
  aChildNode.addEventListener('click', AddToCart, false);
  //add children to info div
  childDivNode.appendChild(headingChildNode);
  childDivNode.appendChild(pChildNode);
  childDivNode.appendChild(aChildNode);
  //add card child to card
  cardNode.appendChild(imgNode);
  cardNode.appendChild(childDivNode);
  //add card child to wrapper
  cardWrapper.appendChild(cardNode);
}
  
// Close the dropdown menu if the user clicks outside of it
window.onclick = function(event) {
  if (!event.target.matches('.dropbtn')) {
    var dropdowns = document.getElementsByClassName("dropdown-content");
    var i;
    for (i = 0; i < dropdowns.length; i++) {
      var openDropdown = dropdowns[i];
      if (openDropdown.classList.contains('show')) {
        openDropdown.classList.remove('show');
      }
    }
  }
} 

// function to add print to cart
function AddToCart(event) {
  // Get print item element that triggered the click
  var x = event.target;
  // Get the paragraph sibiling to get the heading to grab print name
  var psib = x.previousSibling;
  var hsib = psib.previousSibling;

  //Create object to store the print name and store name of 
  const printname = hsib.textContent;
  const storename = window.localStorage.getItem('ChosenStore');

  var printItem = {
    storeName : storename,
    printName: printname
  };

  //Query the database to check if there is enough inventory to add item to cart
  fetch(`api/print/${storename}/${printname}`)
    .then(response => response.json())
    .then(data => {
      console.log(data); 
      // if the quantity is less than zero, alert that item is unavailiable
      if(data[0].printQty <= 0)
      {
        alert("Item out of stock! Couldn't add to cart.")
      }  
      else{
        // Else add item to cart  
        // Add print name to local storage to keep track of items in cart
        // Get the existing print data from local storage
        var printCart = localStorage.getItem('printsInCart');

        // If no existing data, create an array
        // Otherwise, convert the localStorage string to an array
        printCart = printCart ? JSON.parse(printCart) : [];

        // Add new data to localStorage Array
        printCart.push(data[0]);

        // Save back to localStorage
        localStorage.setItem('printsInCart', JSON.stringify(printCart));

        alert("Added to cart!")
      }
    })
    .catch(function(err) {  
      console.log('Failed to fetch page: ', err);  
    });
}




  //html for card
  /*
  <div class="card">
                <img src="img/pinkbluepastelart.jpg" alt="brown-hawk-owl">
                <div class="info">
                    <h2>Art Title</h2>
                    <p>Art print description</p>
                    <a href="#" class="btn">Add to Cart</a>
                </div>
  </div>*/


