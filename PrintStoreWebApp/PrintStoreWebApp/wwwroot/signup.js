//Query Selector for form
const registerForm = document.getElementById("signin-form");

//Add event listener to form
registerForm.addEventListener('submit', (e) => {
    e.preventDefault();

    //grab the data and create an object to send as part of the body of the fetch()
    console.log(registerForm.isDefaultNamespace.value);

    //Form values to form object
    const userData = {
        fname : registerForm.fName.value,
        lname : registerForm.lName.value,
        username : registerForm.email.value,
        password : registerForm.password.value
    }

    //fetch to attribute route in customer controller
});
//