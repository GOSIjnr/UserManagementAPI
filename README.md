### User Management API

The **User Management API** is a RESTful API built with ASP.NET Core, designed to manage user data. It provides endpoints for creating, reading, updating, and deleting user records. The API is structured with a clean separation of concerns, utilizing middleware for cross-cutting concerns and a service layer for business logic.

#### Features:
- **CRUD Operations**: Manage user records with endpoints for Create, Read, Update, and Delete.
- **Middleware**:
  - **AuthenticationMiddleware**: Validates JWT tokens for secure access.
  - **ErrorHandlingMiddleware**: Handles exceptions and returns standardized error responses.
  - **LoggingMiddleware**: Logs incoming requests and outgoing responses.
- **Swagger Integration**: Automatically generated API documentation and testing interface.
- **Dependency Injection**: Services like `UserService` are injected for modular and testable code.

#### Endpoints:
1. **GET /api/users**  
   Retrieve a list of all users.

2. **GET /api/users/{id}**  
   Retrieve a specific user by ID.

3. **POST /api/users**  
   Create a new user. Requires a JSON payload with user details.

4. **PUT /api/users/{id}**  
   Update an existing user by ID. Requires a JSON payload with updated user details.

5. **DELETE /api/users/{id}**  
   Delete a user by ID.

#### Technologies Used:
- **ASP.NET Core 9.0**
- **Swashbuckle** for Swagger documentation
- **System.IdentityModel.Tokens.Jwt** for token handling

#### Example User Model:
```json
{
  "id": 1,
  "firstName": "John",
  "lastName": "Doe",
  "email": "john.doe@example.com",
  "department": "HR"
}
```

#### How to Run:
1. Clone the repository.
2. Build the solution using Visual Studio or the .NET CLI.
3. Run the application. The API will be available at `http://localhost:5090` or `https://localhost:7153`.
4. Access the Swagger UI at `/swagger` for testing and documentation.

#### Future Enhancements:
- Add database integration for persistent storage.
- Implement advanced token validation in `AuthenticationMiddleware`.
- Add unit and integration tests.
