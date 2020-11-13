# University-Secretariat

A simple Windows Form application, written in C# in collaboration with [billz96](https://github.com/billz96), that emulates some basic functions of a University's Secretariat. 
Such as:

* Add/Remove/Update student entries
* Add/Remove/Update student score entries
* Add/Remove/Update course entries
* Search Student/Course/Score entries
* Student Login/Register
* Teacher Login/Register
* Edit Account Information
* View students/courses/score list
* View average scores per student, failed and passed courses

# How to use: #
You gotta host an sql database through an SQL server (in this case locally) and your database gotta have the name "secrbdb.sql" (an exact dump of our database can be found inside the folder "Database"). You can configure the settings of your SQL Server (such as password etc.) by changing the according stuff at line 13 of the "database.cs" file.
