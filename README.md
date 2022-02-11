# Developer-App-Exercise
Developer Application  Assessment

# Database Setup
The easiest way to setup the database here is to simply use the DB_Setup.sql script as a startup script for the SQL Server Database project. To do this you will need to make sure you are connected to an instance of SQL Server and that the Solution's properties are set to "Multiple startup projects" with both project selected. 

1. Confirm multiple startup projects via the "Properties" window of the solution itself: 
  ![confirm multi project setup](https://i.imgur.com/hp6cg0k.png)
2. Go to the "Debug" tab of the *StudentDB* project's properties and check "Startup script" and then navigate to the location of *DB_Setup.sql* located in that project folder (1). This is a good time to test your connection string and copy it (if it works)(2).  
  ![StudentDB Properties Window](https://i.imgur.com/KYBXA87.png)
3. Rebuild the solution. It should create the database and tables when you start debugging (setup appsettings.json before debugging). 

*Alternatively* you can simply navigate to your SQL server in the SQL Server Object Explorer, right-click on it and select "New Query" and then copy/paste the query from *DB_Setup.sql* to setup the database and tables. If you go this route, you don't have to have multiple startup projects, you can ignore the StudentDB project and just debug the StudentInfo project directly, **after you setup the connection string**. 

1. ![Step 1](https://i.imgur.com/wmH6T3g.png)
2. ![Step 2](https://i.imgur.com/ubwJiXp.png)
3. ![Step 3](https://i.imgur.com/OTFIJ1X.png)

Regardless of the method you choose, when you're done you should have the StudentDB Database along with its tables and stored procedures: 

![Tables Setup](https://i.imgur.com/Tcdoy6V.png)

# Connection String Setup
The web app won't have access to your newly-created database unless you ensure it has the proper connection string. 
1. Find your connection string. You can use the "Debug" tab of the _StudentDB_ project to test your connection and output a working connection string: 

  ![Connection String](https://i.imgur.com/NchmHIu.png)
2. Navigate to *appsettings.json* in the _StudentInfo_ project: 

  ![App Settings](https://i.imgur.com/REu0fmF.png)

3. Paste your connection string into one of the settings. The "DedfaultDB" settings has been left blank so you can use that one. Then make sure the "DefaultConnection" setting has a value that matches the setting name for your connection string (e.g. it should say "DefaultDB" if that's where you pasted your connection string). 

  ![Individual Settings](https://i.imgur.com/NHVnQOh.png)
  
Now the web app should have access to your database server. 

# Data Integrity
Some of the sample data provided doesn't look quite correct; there are malformed mobile phone numbers and partial street addresses. As a developer it is not appropriate for me to manipulate the data so I chose schema that would allow it to exists as-is. Validation can be done in the application and/or via auditing the database itself but I chose to keep the data exactly as it was provided since I was not instructed to do either of those things. 

# Browser Compatibility
This application does make use of several newer ES6+ features like modules, classes and nullish coalescing. It should behave normally in any version of Chrome, Firefox, Safari or Edge produced since Fall of 2019. It will not work properly in any version of Internet Explorer. 
