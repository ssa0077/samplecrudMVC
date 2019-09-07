# mojsampletest

Patient Database to Add, Update, Delete and Read Patient information
Assumptions 

1.	I am a doctor and I am maintaining a list of my Patients. 
2.	I will only be able to see the patients that I have added

Usage 
1.	Home page shows a gridview with patients and I can search for patients using the search text box. I can search on any visible patient demographics and the grid will filter the results based on my search string. 
2.	Every patient Added there will be a unique patient Id created (ie. National Id No. (NHS no. etc)
3.	I will be able to add new patient using the ‘Add new’ button on the ‘My Patients’ page. 
4.	I can also edit, delete and view details of a patient using the action buttons on each row. 

Tech Stack Used
1.	VS 2017 community edition
2.	ASP.NET MVC 
3.	Bootstrap
4.	Jquery 1.7.1
5.	Datatables jquery plugin 
6.	.NET framework 4.5.1
7.	C# Programming language
8.	Entity Framework 6
9.	MS SQL Server 2012

Design Approach 
1.	A clean architecture which is not dependent on persistent frameworks. 
2.	User defined dependency injection using a ‘Unit of Work’ approach. 
3.	Using a Code-First approach with Entity Framework. Database gets created on first-run of the application. 
4.	At the moment the application consists of only 1 table. However it is open to addition of more tables and logic. 
5.	Very basic application in terms of functionality with a loosely coupled architecture for better maintainability in the long run. 
6.	Test project has been created with a simple list to test CRUD operations. 
