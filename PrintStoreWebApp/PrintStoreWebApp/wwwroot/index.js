//fetch store names and then display to dropdown menu
fetch("api/store/getStores")
    .then(response => response.json())
    .then(data => {
        window.localStorage.setItem('storeNames', data);        
    })
    .catch(function(err) {  
        console.log('Failed to fetch page: ', err);  
});

const signUp = document.getElementById('signup-btn');
const signOut = document.getElementById('signout-btn');
const login = document.getElementById('login-btn');
const person = localStorage.getItem('person');
signOut.addEventListener('click', (e) => {
    localStorage.removeItem('person');
  })
if(person == null)
{
    signUp.style.display = 'block';
    login.style.display = 'block';
    signOut.style.display = 'none';
}
else{
    signUp.style.display = 'none';
    login.style.display = 'none';
    signOut.style.display = 'block';
}
