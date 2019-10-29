# <img src="https://ruc.dk/sites/default/files/2017-05/ruc_logo_download_en.png" width=500px>


## RAWDATA Assignment 4 – Web Service and Data Layer

This assignment is in two parts.

The first part is about creating a domain model and as data service. The data service is the layer that communicates with the database and provide an interface to the rest of the  system. The data service also takes care of the transformation between the database model and the domain model.

In the second part, a restful webservice is added in a layer on top of the data layer from the first part. 

[Assignment description part 1](https://github.com/shus0001/Assignment4-raw4/blob/master/RAWDATA%202018%20-%20Assignment%204%20part%20I.pdf)


This assignment was developed by group **raw4** of course RAWDATA (Master's in Computer Science, Roskilde University):
- [Özge Yaşayan](https://github.com/ozgey99)
- [Shushma Devi Gurung](https://github.com/shus0001)
- [Ivan Spajić](https://github.com/ivanspajic)
- [Manish Shrestha](https://github.com/shrestaz)

----

## Current status:
![#008000](https://placehold.it/15/008000/000000?text=+) Part 1: Complete. 18 out of 18 tests pass.

![#FFA500](https://placehold.it/15/FFA500/000000?text=+) Part 2: Yet to start.


## Results:

1. Terminal:

<img src="Resources/Terminal-testing.png" width=500px>

2. Visual Studio test explorer:

<img src="Resources/Test-Explorer.png" width=300px>

----

## Steps to reproduce:

> **Prerequisites: You must have [Git](https://git-scm.com/downloads) and [.Net Core 3.0 SDK](https://dotnet.microsoft.com/download) installed. Use OS and IDE of your choice. Additionally, you must have [PostgreSQL](https://www.postgresql.org/download/) installed with the database set up.**

0. Open a terminal and clone the project: `git clone https://github.com/shus0001/Assignment4-raw4.git`

2. Navigate into the project: `cd Assignment4-raw4`

----

**If you have the database setup already, skip to step 3.**

> _These steps assumes you are using Windows, "postgres" is the user as setup by default when installing PostgreSQL and you have set the "Environment Variables" correctly._

1. From the same terminal, create a database:
```
psql -U postgres -c "create database northwind"
``` 

2. Using the provided `.sql` file, seed the database:
```
psql -U postgres -d northwind -f .\Resources\northwind_postgres.sql
```

Now, the database has been created and seeded. Use the software of your choice to connect and visualise the database, or use the included pgAdmin. For more information on the data, [read here.](https://github.com/shus0001/Assignment4-raw4/blob/master/RAWDATA%202018%20-%20Assignment%204%20part%20I.pdf)

----

3. **Important:** Update with the password of your postgres user in `.\Data Layer\Database Context\NorthwindContext.cs`: Line 11 on the variable `string connectionString`.
> _You can also update the name of the database and the user if you had your database set up differently._

----

### Running the tests

#### Terminal:
4. run `dotnet test`

#### Visual Studio:
5. Open Project or Solution > navigate to the cloned folder and open solution named `Northwind.sln`.

6. Run the test by opening Test menu > Run All Tests.

_Part 2 of the assignment has not yet started. Come back for a restful webservice built on top of this data layer._ 👷‍♀️👷‍♂️


Happy Coding! 👨‍💻 👩‍💻
