# Demo-BI
This Demo is an assignement given to me as part of my jobinterview. it is mean to show some demonmstration of skills in data management. and be used as a talking point in further interviews. 

Time Spend on this so far, this includes coffee and tea breaks and luches :  
* Session 1 : 30 minutes to read and understand the assingment. 2023-05-18  
* Session 2 : 6 Hours Building the application part 1 & 2. 2023-05-20.  
* Session 3 : 1 hour  Building the application part 3. 2023-05-20.  

the technoligy chosen for this the following: 
* For the backend, a Azure functions app, C# .net 6.0
* support Class libaries, C# .net 6.0
* Local sql server. 

## Approach

Since I dont have much experience with performance optimization I have decided to try a few methods out and se what works best. 

* Sequencial on full text. This is implimented in the `DefaultBIService`
* Parallel on full text. Not Implimented
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


# Research 
List of usefull googles i did during this assingment.   

* Storage of large text data in databases : https://stackoverflow.com/questions/140550/what-is-the-best-way-to-store-a-large-amount-of-text-in-a-sql-server-table  
* Maximal lenght of a string : https://stackoverflow.com/questions/140468/what-is-the-maximum-possible-length-of-a-net-string  
* Dictionary https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=net-6.0
* Postman console log https://learning.postman.com/docs/sending-requests/troubleshooting-api-requests/
* EF Core with MVC https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/migrations?view=aspnetcore-7.0
* Markdown https://www.markdownguide.org/basic-syntax/
* SQL sequential guid https://stackoverflow.com/questions/47483679/entity-framework-uses-newsequentialid-for-guid-key