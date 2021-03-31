//get button and dropdowndiv
const dropDownBtn = document.getElementsByClassName("dropbtn");
const dropDownMenu = document.getElementById("myDropdown");
  
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
        alert(storename);

        //fetch inventory
        fetch(`api/inventory/storeInventory/${storename}`)
          .then(response => response.json())
          .then(data => {
              console.log(data); 
              console.log(data[0].printArtistFName);     
          })
          .catch(function(err) {  
              console.log('Failed to fetch page: ', err);  
          });
    }
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


