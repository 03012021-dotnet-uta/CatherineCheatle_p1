const registerForm = document.getElementById("signin-form");
const registerResponse = document.getElementById("form-response");

registerForm.addEventListener('submit', (e) => {
  e.preventDefault();//to prevent the form from submitting and resetting

  // grab the data and create an object to send as part of the body of my fetch()
  const userData = {
    CustomerFName: registerForm.fname.value.trim(),
    CustomerLName: registerForm.lname.value.trim(),
    CustomerEmail: registerForm.email.value.trim(),
    CustomerPassword: registerForm.password.value.trim(),
  }
  console.log(userData);

  fetch('api/customer/register', {
    method: 'POST',
    headers: {
      'Accept': 'application/json',
      'Content-Type':'application/json'
    },
    body:JSON.stringify(userData)
    })
    .then(response => {
      if (!response.ok) {
        registerResponse.textContent = `Sorry but is looks like this email is already taken. Try signing in or use a different email`;
        throw new Error(`Network response was not ok (${response.status})`);
      }
      else       // When the page is loaded convert it to text
        return response.json();
    })
    .then((jsonResponse) => {
      registerResponse.textContent = ` Welcome, ${jsonResponse.fname} ${jsonResponse.lname}`;
      return jsonResponse;
    })
    .then(res => {
      //save the personId to localStorage
      localStorage.setItem('person', res.customerId);// this is available to the whole browser
      //switch the screen
      location = 'index.html';
    })
    .catch(function(err) {  
        console.log('Failed to fetch page: ', err);  
    });
});