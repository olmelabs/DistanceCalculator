# Distance Calculator
Calculates distance between two points specified by coordinates. 
Demonstrates .NET Core Web Api, Swagger, Api Versioning, Dependency Injection. Uses strategy pattern to encapsulate calculation algorithm. Allows easy api extensions by means of versioning. Switching to another calculation strategy is also easy, as it is a matter of one-line change in start-up (change implementation in IOC)
To run project, download or clone repository. Open cmd or powershell and execute:
```
dotnet restore
dotnet build CompanyName.DistanceCalculator.sln --no-restore 
dotnet run --project CompanyName.DistanceCalculator/CompanyName.DistanceCalculator.csproj 
```
If everything is ok, you will see api swagger on http://localhost:5000/swagger
