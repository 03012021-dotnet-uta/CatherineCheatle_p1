# Art Print Store Application
***
## Project Description
This is an ASPNET Core web application which allows a user to choose a store, which has their own inventory of prints, and add prints to their cart to later checkout and place an order. 
***
## Technologies Used
* HTML
* CSS
* Javascript
* .NET 5
* C#
* Entity Framework Core (EF)
* Microsoft SQL Server Database
***
## Features
* A user can sign up and login into an account
* A user can choose from three stores
* Each Store has its own inventory
* A user can add a print to their cart
* A user can delete items from their cart
* A user can go to checkout to view final list of items before placing and order
* A user can place an order
* Shipping fee is calculated based on subtotal
* A shipping delivery date is set in the SQL database
* Client-side validation
***
## Getting Started
1. $git clone https://github.com/03012021-dotnet-uta/CatherineCheatle_p1.git
2. Check nuget packages and ensure you have the following:
* Entity Framework Core v. 5.0.4
* Entity Framework Design v. 5.0.4
* Entity Framework SqlServer v. 5.0.4
* Entity Framework Tools v. 5.0.4
3. You can set up your own database, in which you will need to change startup and set up user secrets for your connection string. You will also need to 
do code-first approach with EF by cd into Repository and entering the following command: dotnet ef update database --startup-project ../PrintStoreWebApp/PrintStoreWebApp.csproj
4. Once your database is set up you can cd into PrintStoreWebApp to run the application using the command (dotnet run) and open the link to localhost
