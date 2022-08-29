***************************************************************
TASK:

In this case, you will implement the Asset API, where you can manage CRUD operations, and the User API, where you can keep user information.

For User API, design a method that statistically returns 10 users' information from the endpoint. The user's id, first name, last name, e-mail, date of birth, and phone information should exist in the fields returned from this endpoint.

On the other hand, design your Asset API where you can manage all the assets in the hospital. Asset service will have only an Asset entity whose main fields are Id, Category, MacAddress, and Status. Id information must be unique PK for all assets. MacAddress information should be in a unique and appropriate format for all assets. It must contain 12 hexadecimal digits. One way to represent them is to form six pairs of the characters separated with a colon(:) and all chars must be capitalized. For example, 01:23:45:67:89:AB is a valid MAC address. Status information should be Caution when an asset is created for the first time. Other status information where the asset can be updated should be: Usable, Down, Passive. You can use the CreatedDate, UpdatedDate, CreatedByUserId, and UpdatedByUserId fields to keep track of the time and user of your entity's command operations. You can design your entity with the soft delete approach to protect data. It is expected that there will be a total of 5 endpoints:
1.	get all assets (with pagination)
2.	get asset by id
3.	create asset
4.	update asset
5.	delete asset 
In API 1 and 2, it is expected to return CreatedByUser and UpdatedByUser with other user information (defined in user API). The response of the user API should be cached and easily changeable between Redis and memory. You can expire by giving a timeout for cache invalidation. Timeout information should be taken from the config file and can be changed when necessary.

Important notes:
•	Rest standards, such as naming, and HTTP response codes, should be followed.
•	Necessary validations should be provided, such as MAC address format.
•	API documentation should be required, such as Swagger.
•	PostgreSQL should be used as a database, and Redis should be used as a cache.
•	Unit tests should be written. In-Memory database can be used in tests.
•	Clean code and clean architecture best practices should be followed. 
•	All projects should be in a single solution.
•	All external services (database, redis, etc.) and APIs should be in a single docker-compose file. "docker-compose up" command should be enough to run all services.
•	Push all the work to a GitHub repository and send the link to us.

You can summarize the guidance needed to get your project up in the README file.

Resource: https://en.wikipedia.org/wiki/MAC_address 
***************************************************************

REPORT

. Couldn't manage to run Docker container properly. Compose file includes 3 expected images but I was keep getting System.Net.Sockets.SocketException (10061): Connection refused error.

To run assetapi locally:

Prequsities
1.Postgres 
2.Redis server
3.EF tools -> Update-database 

Steps
1.Register a user
2.Pass JWT token to authorized services.