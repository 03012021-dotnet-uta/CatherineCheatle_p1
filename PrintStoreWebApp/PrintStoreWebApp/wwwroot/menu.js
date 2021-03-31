//get button and dropdowndiv
const dropDownBtn = document.getElementsByClassName("dropbtn");
const dropDownMenu = document.getElementById("myDropdown");
const cardWrapper = document.querySelector('.wrapper');

function myFunction() {
    var storeNames = window.localStorage.getItem('storeNames');
    var storeArr = storeNames.split(",").map(item => item.trim());
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
    console.log(storeArr);
    dropDownMenu.classList.toggle("show");

    //check if any child elements were clicked
    function storeClick(event)
    {
        var x = event.target;
        const storename = x.textContent.trim();
        cardWrapper.innerHTML = "";

        //fetch inventory
        fetch(`api/inventory/storeInventory/${storename}`)
          .then(response => response.json())
          .then(data => {
              console.log(data); 
              console.log(data[0].printArtistFName); 
              data.forEach(print => {
                CreateCard(print);
              });    
          })
          .catch(function(err) {  
              console.log('Failed to fetch page: ', err);  
          });
    }
  }

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

  //test dynamically adding a card to wrapper

  /*
  <div class="card">
                <img src="img/pinkbluepastelart.jpg" alt="brown-hawk-owl">
                <div class="info">
                    <h2>Art Title</h2>
                    <p>Art print description</p>
                    <a href="#" class="btn">Add to Cart</a>
                </div>
  </div>*/


