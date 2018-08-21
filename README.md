# Metro2036
Metro2036 Project ASP.NET Core 2.1

----------------------------------------------------------------------------------------------------
Requirenments:

OK - ASP.Net Core 2.1 Solution

* 8 web pages (views)
OK - 4 entity models -  Point, Route, Station, Train, TravelLog
* 4 controllers  (with at least one action for each)
* 3 Razor pages

* Use sections and partial views.
* Use display and editor templates.

OK - Use Entity Framework Core to access your database

OK - Use MVC Areas - Admin, User Areas
	to separate different parts of your application (e.g. area for administration)

* Adapt the default ASP.NET Core site template or get another free theme
	Use responsive design based on Twitter Bootstrap / Google Material design
	
* Use the standard ASP.NET Identity System for managing users and roles
	Your registered users should have at least one of these roles: user and administrator
	
* Write unit tests for your logic, controllers, actions, helpers, etc.
	You should have at least 10 test cases

* Implement error handling and data validation to avoid crashes when invalid data is entered
	Both 
		client-side and 
		server-side, even at the 
		database(s)

* Handle correctly the special HTML characters and tags like <br /> and <script> (escape special characters)

* Use Dependency Injection
	The built-in one in ASP.NET Core is perfectly fine

* Optionally, use AutoМapping

* Prevent from security vulnerabilities like SQL Injection, XSS, CSRF, parameter tampering, etc.

Bonuses
* Host the application in a cloud environment, e.g. in AppHarbor or Azure
---------------------------------------------------------------------------------------------------------

ToDo:

Home Page - Add some content
Abount Page - Add some content
Contact - Add contacts
FeedBack Form ?


Admin Area:
(As Drop Down)
User Maangement
	Index - UserID, User Name, EMail, Actions(Edit, Delete) | Add New Userg
Role Maangement

User Management - CRUD, Roles management


Points Routes Stations Trains - in DropDown Menu - Management
	- With View and Bind Model 

Identity Area :
	 Scaffold required pages

User Area:
	Home Paage 


--------------------------------------------------------------------------------------------------------
Assessment Criteria
•	Functionality – 0…20
•	Implementing controllers correctly (controllers should do only their work) – 0...5
•	Implementing views correctly (using display and editor templates) – 0…5
•	Unit tests (unit test for some of the controllers using mocking) – 0…10
•	Security (prevent SQL injection, XSS, CSRF, parameter tampering, etc.) – 0…5
•	Data validation (validation in the models and input models) – 0…10
•	Using auto mapper and inversion of control – 0…5
•	Using areas with multiple layouts – 0…10
•	Code quality (well-structured code, following the MVC pattern, following SOLID principles, etc.) – 0…10
•	Bonus (bonus points are given for exceptional project) – 0…25
--------------------------------------------------------------------------------------------------------