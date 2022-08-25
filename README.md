# AirLineWebApp-Assignment
●	Registration (10 Marks)
1.	Register with email, PAN No, password and confirm password field
2.	Each email should be an unique email (uniqueness should be verified using Ajax call on blur event of email field
3.	Email max length should be 50 characters
4.	Password min length and max length will be 8 and 10 characters respectively
5.	All fields are mandatory
6.	All registered used will have a role of Operator
7.	After successful registration, all users will receive a welcome email. Subject: “Your Registration is Successful” and Body as “Thanks for the registration. Please login using <url of login page of your application>
8.	User can’t login unless they are approved by the Admin
9.	The user table can have one hardcoded user with your Kellton email address and password as Kellton@2022 and role as Admin

●	Login (5 Marks)
1.	Login with email and password
2.	It should give an error if user enters invalid credentials

●	Approve New Users (10 Marks)
1.	This page can be only opened by the Admin user. This page will list all users from the user table who is pending for Approval.
2.	There will be 2 buttons against every row – Approve and Reject (Both should be implemented as HttpPut from Ajax). We should maintain the status of users from a single column
3.	Any registered user can only login after approval from Admin. If the user is Rejected then the rejected user will not appear again on this page and that user can also not login to the application

●	Manage Airlines (15 Marks)
1.	Create a screen to Add/Edit/List/Delete Airlines
2.	Before delete – there should be a confirmation message to user using JQuery. After confirmation, the record can be deleted
3.	Listing page should use partial view concept and display records by Airline name is ascending order
4.	Create and Edit Screen Should capture Airline Name (Max length – 50 character, check unique on onblur event using Ajax call), From City and To City (Both city field should not accept more than 30 characters), Fare (should accept only Integer number) and all fields will be mandatory
5.	Only an user with the Operator role can work on all Airlines related screen

●	Web Application Role Based Implementation (10 Marks)
1.	Airline menu option should work only for Operator
2.	Approve new users should work only for Admin

Common Rules
●	Welcome <logged in User Email> should appear on each page that opens after successful login (Use session to do this)
●	Use proper DB table name, column name, data type, Null/Not null, primary and foreign key relationship (wherever applicable)
●	Sonar report should be in passed state
●	Must write at least 5 unit test methods
●	Make use of Auto mapper while converting the API Model to View Model
●	Implement proper authentication/authorization at API layer using JWT. You should be able to demonstrate this using postman or Swagger to the evaluator during the evaluation of the assignment

#To complete the above assignment, you have to create 3 projects
 
#	 MVC Web Application
#  Web API
#  Class Library project for DB operations using Entity Framework code first approach
