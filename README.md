# Newsletter solution with Vertical Slices Arhitecture

This is .NET Web API solution with Vertical Slices Architecture design which includes authentication features using .NET Identity Framework.

Solution is by architecture design divided into:

- **Application Layer:**
  -  **Common** folder which uses **Interfaces**, **DTO**'s and **Behaviours**(Validation and Logging)
  -  **Features** which uses MediatR pattern with CQRS (it is divided into Commands and Queries)
    
- **Entities:**
  - Using code first approach entities are used to create tables in SQL database and they contain business logic
    regarding each and every entity
    
- **Infrastructure Layer:**
  - **Database** used for migrations and contains ApplicationDbContext class
  - **Repositories** contains all implementation of abstractions in application layer
    
- **Shared folder:**
  - Contains Result class pattern with Error class implementation which are used trough layers
