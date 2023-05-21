# Demo-BI
This Demo is an assignement given to me as part of my jobinterview. it is a mean to show some demonstration of skills in data management and be used as a talking point in further interviews. 

Time Spend on this assingment, this includes coffee and tea breaks and lunches :  
* Session 1 : 30 minutes. To read and understand the assingment. 2023-05-18  
* Session 2 : 6 Hours. Building the application part 1 & 2. 2023-05-20.  
* Session 3 : 1 hour.  Building the application part 3. 2023-05-20.  
* Session 4 : 30 minutes. Improvements. 2023-05-20.  
* Session 5 : 3 Hours. Implimented the different approches and tested them. 2023-05-21

Bringing the total to 11 Hours spend. 

the chosen technology is the following: 
* For the backend, a Azure functions app, C# .net 6.0
* support Class libaries, C# .net 6.0
* Local sql server. 

## Approach

Since my experience with performance optimization is sparse, I have decided to try a few methods to se what works best. 

* Sequencial for each through on the full text, as a baseline. This is implemented in the `DefaultBIService` class.
* Parallel for on full text. This is implemented in the `ParallelBIService` class.
* Parallel for on the paragraphs and Sequential word count. This is implemented in the `ParagraphBIService` class. 
* Hashed cache for unique words, saved in a database. This is implemented in the `HashedBIService` class. 

To change what algorithm is used go to the `Startup` class in the backendAPI project and shift it out for one of the other 3 classes, this projects ships with the default enabled.

## Test of the approach
To test these approaches, i made a logging table. this table contains statics on each run like, what service was used, how much data was handled, and in how much time. This, in combination with the postman collection, has lead to the majorty of the testing.

It was found in the test that azure functions first run is rather slow in start up, so this will be ignored in the test results. 

The results is saved in the root of this project `Test Data Results.xlsx`

But here are the highligths: 

|                  | DefaultBIService | ParallelBIService | ParagraphBIService | HashedBIService |
| ---------------- | ------------|------------ |------------ | ----------- |
| Avarage run time (ms.)| 12.57894737 | 19.94736842 | 12.78947368 | 9.736842105 | 

Leaving the HashedBIService to be what looks to be the fastest by a small margin. 
This result is based on 5 runs of 4 data sets. 5000 Bytes, 50K Bytes, 100K Bytes, 1M Bytes
with the first run of 5000 bytes removed as it was tainted. the test runs are found in the postman.

# Database. 
The Database was writen as a Code first project, and assumes a local instance with the default setup and windows authentication and with the following connection string working:
`Server=.;Database=BI_Dev;Trusted_Connection=True`

If you need to use another database, change the hardcoded connection string in `ServiceCollectionExtensions` and `BIDatabaseFactory`

As i never got the configuration working.

## CLI setup for Entity Framework (EF)
If you dont have "EF" installed as part of your CLI tools use this command

`dotnet tool install --global dotnet-ef`

Navigate to the dataaccess projet in from the console with this command 

`cd .\Services\DataAccess\`

From here you can create migrations 

`dotnet ef migrations add [MigrationName]`

And update the database 

`dotnet ef database update`

And delete the database 

`dotnet ef database drop`

# Postman collection 
Located under the folder `.\tools\BI-Demo.postman_collection.json`

In this collection i saved a few requests i used for implementing this assingment, these are stored under the folder "OneShots"

In the Tests folder you find a API test used to make sure the paragraph endpoind returned the correct respons always.


# Unit-Testing 
So far testing has not been much of a priority, as i have not come up with a good unit test. however i did make and extend one API test with postman that is saved in the postman collection


# Research 
List of usefull googles i did during this assingment.   

* Storage of large text data in databases : https://stackoverflow.com/questions/140550/what-is-the-best-way-to-store-a-large-amount-of-text-in-a-sql-server-table  
* Maximal lenght of a string : https://stackoverflow.com/questions/140468/what-is-the-maximum-possible-length-of-a-net-string  
* Dictionary https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=net-6.0
* Postman console log https://learning.postman.com/docs/sending-requests/troubleshooting-api-requests/
* Postman automated test Docs https://learning.postman.com/docs/writing-scripts/test-with-monitors/
* EF Core with MVC https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/migrations?view=aspnetcore-7.0
* Markdown https://www.markdownguide.org/basic-syntax/
* SQL sequential guid https://stackoverflow.com/questions/47483679/entity-framework-uses-newsequentialid-for-guid-key
* Parallel For loop https://www.dotnetperls.com/parallel-for
* Stopwatch https://www.dotnetperls.com/stopwatch
* Concurent Dictionary https://learn.microsoft.com/en-us/dotnet/api/system.collections.concurrent.concurrentdictionary-2.addorupdate?redirectedfrom=MSDN&view=net-7.0#overloads
