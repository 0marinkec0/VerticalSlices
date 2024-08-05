# Newsletter solution with Vertical Slices Arhitecture

This is .NET Web API solution with Vertical Slices Architecture design which includes authentication features using .NET Identity Framework.

Solution is by architecture design divided into:

- **Application Layer:**
  -  **Common:** folder uses **Interfaces**, **DTO**'s and **Behaviours**(Validation and Logging) classes
  -  **Features** implements MediatR pattern with CQRS (it is divided into Commands and Queries)
      - All features are using following flow: **Validator -> Command -> CommandHandler -> Endpoint**
    
- **Entities:**
  - Using code first approach entities are used to create tables in SQL database and they contain business logic
    regarding each and every entity
    
- **Infrastructure Layer:**
  - **Database** used for migrations and contains ApplicationDbContext class
  - **Repositories** contains all implementation of abstractions in application layer
    
- **Shared folder:**
  - Contains Result class pattern with Error class implementation which are used trough layers



Setup before running:

To start and use the project, few things need to be changed and updated.

Add first migration to the project by opening package manager console and running.
 
    add-migration "{NameOfFirstMigration}" -OutputDir Infrastructure\Migrations -StartupProject Newsletter.Api -args         "{DatabaseConnectionString}"
           
First migration is needed so database container can pick it up and run migrations are created in "Infrastructure/Migrations" folder.

NOTE: .appsettings.json are using my own setting and variables, feel free to change them by your needs.
      DatabaseConnectionString needs to be changed by your own!
