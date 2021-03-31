//fetch store names and then display to dropdown menu
fetch("api/store/getStores")
    .then(response => response.json())
    .then(data => {
        console.log(data)
        window.localStorage.setItem('storeNames', data);        
    })
    .catch(function(err) {  
        console.log('Failed to fetch page: ', err);  
    });