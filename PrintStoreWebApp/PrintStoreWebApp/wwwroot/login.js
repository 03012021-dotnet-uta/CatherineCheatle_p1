// get login form and login response
const loginForm = document.getElementById("login-form");
const loginReponse = document.getElementById("form-response");

console.log(loginReponse.innerHTML);

//add event listner for form submit
loginForm.addEventListener('submit', (event)=> {
    event.preventDefault();
    console.log("Submit button pressed");
    //create string[] to send to API
    const loginData = {
        CustomerEmail: loginForm.email.value.trim(),
        CustomerPassword: loginForm.password.value.trim()
    }
    console.log(loginData);
    console.log("Customer email: " + loginData.CustomerEmail);

    fetch('api/customer', {
        method: 'POST',
        headers: {
          'Accept': 'application/json',
          'Content-Type':'application/json'
        },
        body:JSON.stringify(loginData)
        })
        .then(response => {
          if (!response.ok) {
            throw new Error(`Network response was not ok (${response.status})`);
          }
          else       // When the page is loaded convert it to text
            return response.json();
        })
        .then((jsonResponse) => {
            loginReponse.textContent = jsonResponse.customerEmail + ' login successful';
          console.log(jsonResponse);
        }
        )
        .catch(function(err) {  
            console.log('Failed to fetch page: ', err);  
        });
})
