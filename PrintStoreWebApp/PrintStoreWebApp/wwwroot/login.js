// get login form and login response
const loginForm = document.getElementById("login-form");
const loginReponse = document.getElementById("form-response");

console.log(loginReponse.innerHTML);

//add event listner for form submit
loginForm.addEventListener('submit', (event)=> {
    event.preventDefault();

    const CustomerEmail = loginForm.email.value.trim();
    const CustomerPassword = loginForm.password.value.trim();

    fetch(`api/customer/login/${CustomerEmail}/${CustomerPassword}`)
        .then(response => {
          if (!response.ok) {
            throw new Error(`Network response was not ok (${response.status})`);
          }
          else       // When the page is loaded convert it to text
            return response.json();
        })
        .then((jsonResponse) => {
          loginReponse.textContent = `Welcome, ${jsonResponse.customerFName} ${jsonResponse.customerLName}. Login Successful.`;
          console.log(jsonResponse);
          return jsonResponse;
        }
        )
        .then(res => {
          localStorage.setItem('person', JSON.stringify(res));
          //set 2 sec time delay before moving on to next page
          location = 'menu.html';          
        })
        .catch(function(err) {  
            console.log('Failed to fetch page: ', err);  
        });
})
