# Developer-App-Exercise
Developer Application  Assessment

# Database Setup
Setup is easiest with SQL Server Lite. Navigate to the "Properties" section of the database project and under "Debug" find your connection string (You can select "Edit" and configure this yourself if the default connection string is not correct). 

After establishing your connection string, go to *appsettings.json* and add your connection string to the list of connection strings (or replace an existing value). 

Make sure the name of your connection string is in the "DefaultConnection" property. 

Rebuild the solution and start the app in debug mode. It should successfully connect to your local database. If not, you can always use the DB_Setup.sql script to create the necessary tables and procedures on your own database and use a connection string that will work for that database server instead. 

# Data Integrity
Some of the sample data provided doesn't look quite correct; there are malformed mobile phone numbers and partial street addresses. As a developer it is not appropriate for me to manipulate the data so I chose schema that would allow it to exists as-is. Validation can be done in the application and/or via auditing the database itself but I chose to keep the data exactly as it was provided since I was not instructed to do either of those things. 

# Focus on JavaScript and Core Features 
We're not really leveraging .NET MVC/Razor much here. In an actual project I would definitely pre-load the data rather than make a separate HTTP request. In terms of performance, most users are unlikely to see a significant difference. I also avoid bundling for small apps like this and excessive library use. Bundling should either be automated or ignore (otherwise it's a waste of a developer's time) and libraries should only be used if they save significant time (not true of many libraries, including jQuery). 

# Browser Compatibility
This application does make use of several newer ES6+ features like modules, classes and nullish coalescing. It should behave normally in any version of Chrome, Firefox, Safari or Edge produced since Fall of 2019. It will not work properly in any version of Internet Explorer. 
