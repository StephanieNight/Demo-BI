# Demo-BI
This Demo is an assignement given to me as part of my jobinterview. it is mean to show some demonmstration of skills in data management. and be used as a talking point in further interviews. 

Time Spend on this so far, this includes coffee and tea breaks and luches :  
* Session 1 : 30 minutes. To read and understand the assingment. 2023-05-18  
* Session 2 : 6 Hours. Building the application part 1 & 2. 2023-05-20.  
* Session 3 : 1 hour.  Building the application part 3. 2023-05-20.  
* Session 4 : 30 minutes. Improvements. 2023-05-20.  
* Session 5 : X Hours. Implimented the different approches and tested them. 2023-05-21

the technoligy chosen for this the following: 
* For the backend, a Azure functions app, C# .net 6.0
* support Class libaries, C# .net 6.0
* Local sql server. 

## Approach

Since I dont have much experience with performance optimization I have decided to try a few methods out and se what works best. 

* Sequencial on full text. This is implimented in the `DefaultBIService`
* Parallel on full text. `ParallelBIService`
* Parallel paragraphs and sequeltial word count. Not Implimented
* Hashed cache for unique words with watchlist update. Not Implimented

# Database. 
Assumes a local instans with the default setup and windows authentication.  
with the following connection string working :
`Server=.;Database=BI_Dev;Trusted_Connection=True`

If you need to use an other database change the hardcoded connection string in `ServiceCollectionExtensions` and `BIDatabaseFactory`


## CLI setup 
if you dont have ef as part of your CLI tools use this command

`dotnet tool install --global dotnet-ef`

navigate to the dataaccess projet in from the console with this command 

`cd .\Services\DataAccess\`

from here you can create migrations 

`dotnet ef migrations add [MigrationName]`

and Update the database 

`dotnet ef database update`


# Postman collection 
Located under the folder `.\tools\BI-Demo.postman_collection.json`

in this collection i saved a few requests i used for implimenting this assingment, these are stored under the folder "OneShots"

in the Tests folder you find a API test used to make sure the paragraph endpoind returned the correct respons always.


# Testing 
so far testing has not been much of a priority as i have not come up with a good unit test. however i did make and extend one API test with postman that is saved in the postman collection


# Research 
List of usefull googles i did during this assingment.   

* Storage of large text data in databases : https://stackoverflow.com/questions/140550/what-is-the-best-way-to-store-a-large-amount-of-text-in-a-sql-server-table  
* Maximal lenght of a string : https://stackoverflow.com/questions/140468/what-is-the-maximum-possible-length-of-a-net-string  
* Dictionary https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=net-6.0
* Postman console log https://learning.postman.com/docs/sending-requests/troubleshooting-api-requests/
* EF Core with MVC https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/migrations?view=aspnetcore-7.0
* Markdown https://www.markdownguide.org/basic-syntax/
* SQL sequential guid https://stackoverflow.com/questions/47483679/entity-framework-uses-newsequentialid-for-guid-key
* Parallel For loop https://www.dotnetperls.com/parallel-for
* Stopwatch https://www.dotnetperls.com/stopwatch
* Concurent Dictionary https://learn.microsoft.com/en-us/dotnet/api/system.collections.concurrent.concurrentdictionary-2.addorupdate?redirectedfrom=MSDN&view=net-7.0#overloads
