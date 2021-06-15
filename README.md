# NameSearchApi
#### This project demonstrates use of .NET and Entity Framework Code First to implement a REST API. The main funtionality of NameSearchApi is to allow a user to add a person object to the provided database, and allows the user to enter a query of any name, and any person in the database with that name will be returned along with their information. There are also the other endpoints that are basic CRUD operations. <br>
---
## Build, Run, and Test instructions

### In Microsoft Visual Studio <br>
* Clone the project and open in Microsoft Visual Studio
* Pressing the "IIS Express" will build and run the solution, and a browser window should be opened to "https://localhost:44320/swagger/index.html"

### Endpoints
* The first REST endpoint is a GET request that returns all people in the database
  * Click on the request, click "Try it out", then "Execute"
* The second enpoint is a POST request where a new person can be added to the database
  * Click on the request then "Try it out"
  * The id parameter can be deleted since a new id is automatically generated
  * Replace the other parameters with any appropriate value then press "Execute"
* The third endpoint is a GET request that returns all of the people with a name that contains the name that was submitted
  *  Click on the request then "Try it out"
  *  Enter a name in the name field (First, last or full name) and click "Execute"
  *  A list of "person" objects will return or a 404 will return if no one has this name

### Testing
* Microsoft Visual Studio
 * While inside the project, click "Test" in the toolbar, then "Run All Tests"
* Visual Studio Code 
 *  Cd into "NameSearchTests" directory
 *  Enter "dotnet test" in the terminal



