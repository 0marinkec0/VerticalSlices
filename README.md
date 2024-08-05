# Newsletter solution with Vertical Slices Arhitecture

This is .NET Web API solution with Vertical Slices Architecture design which includes authentication features using .NET Identity Framework.


![image](https://github.com/user-attachments/assets/b1e038ea-f495-4b74-99db-8ba434ecf11e) ![image](https://github.com/user-attachments/assets/a5d64217-78a2-4bd0-a55a-ff277aea2f60)




Solution is by architecture design divided into:

- **Application Layer:**
  -  **Common:** folder uses **Interfaces**, **DTO**'s and **Behaviours**(Validation and Logging) classes
  -  **Features:** implements MediatR pattern with CQRS (it is divided into Commands and Queries)
      - All features are using following flow: **Validator -> Command -> CommandHandler -> Endpoint**
    
- **Entities:**
  - Using code first approach entities are used to create tables in SQL database and they contain business logic
    regarding each and every entity
    
- **Infrastructure Layer:**
  - **Database:** used for migrations and contains ApplicationDbContext class
  - **Repositories:** contains all implementation of abstractions in application layer
    
- **Shared folder:**
  - Contains Result class pattern with Error class implementation which are used trough layers



# Setup before running

To start and use the project, few things need to be changed and updated.

Add first migration to the project by opening package manager console and running.
 
    add-migration "{NameOfFirstMigration}" -OutputDir Infrastructure\Database\Migrations -StartupProject Newsletter.Api -args "{DatabaseConnectionString}"
           
First migration is needed so database container can pick it up and run migrations are created in "Infrastructure/Migrations" folder.

NOTE: .appsettings.json are using my own setting and variables, feel free to change them by your needs.
      DatabaseConnectionString needs to be changed by your own!



# Tehnologies and Patterns
- [ASP .NET API with .NET 7](https://learn.microsoft.com/en-us/aspnet/core/?view=aspnetcore-7.0)
- [Fluent Validation](https://docs.fluentvalidation.net/en/latest/)
- [MediatR with CQRS](https://github.com/jbogard/MediatR)
- [EntityFramework](https://learn.microsoft.com/en-us/ef/core/)
- [Identity ASP.NET core](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-8.0&tabs=visual-studio)
- [Vertical Slices Arhitecture](https://github.com/nadirbad/VerticalSliceArchitecture)
- SQL Server
