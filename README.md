Overview
A simple backend service built with .NET 8 and Entity Framework that allows users to manage their tasks. Users can register, log in, and perform CRUD operations (Create, Read, Update, Delete) on their tasks. Each user’s tasks are secured through JWT authentication.

Setup Instructions
Clone the repository:

bash
Copy code
git clone <repository-link>  
cd task-management-backend  
Configure the database:

Open appsettings.json and update the connection string:
json
Copy code
"ConnectionStrings": {  
  "DefaultConnection": "YourDatabaseConnectionString"  
}  
Apply migrations to create the database:

bash
Copy code
dotnet ef database update  
Run the project:

bash
Copy code
dotnet run  
The API will be available at http://localhost:5000.

API Endpoints
User Endpoints:
POST /users/register – Register a new user.
POST /users/login – Log in and receive a JWT.
Task Endpoints (JWT required):
POST /tasks – Create a new task.
GET /tasks – Get a list of tasks (with optional filters).
GET /tasks/{id} – Get details of a specific task.
PUT /tasks/{id} – Update a task.
DELETE /tasks/{id} – Delete a task.
Features
JWT Authentication: Ensures only logged-in users can manage their tasks.
Task Filtering & Sorting: Filter tasks by status, due date, and priority.
Pagination: Get tasks in manageable pages.
Secure Passwords: Passwords are hashed before storin
