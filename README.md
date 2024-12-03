# Task Management System Backend

##  Overview
A simple backend service for task management built with **.NET 8** and **Entity Framework**. This system allows users to register, log in, and manage their tasks (create, update, delete, and view). All tasks are associated with specific users and protected using **JWT authentication**.

---

##  Getting Started

### 1. Clone the repository:
```bash
git clone https://github.com/vzxtq/Task-Management.git
cd task-management-backend

2. Configure the database:
Open the appsettings.json file and update the connection string with your database details:
"ConnectionStrings": {
  "DefaultConnection": "YourDatabaseConnectionString"
}

3. Apply migrations and create the database:
dotnet ef database update

4. Run the application:
dotnet run
The API will be available at http://localhost:5120.

API Endpoints
 User Endpoints:
POST /users/register — Register a new user.
POST /users/login — Authenticate a user and receive a JWT.

Task Endpoints (JWT required):
POST /tasks — Create a new task.
GET /tasks — Retrieve a list of tasks with optional filtering and sorting.
GET /tasks/{id} — Retrieve task details by ID.
PUT /tasks/{id} — Update an existing task.
DELETE /tasks/{id} — Delete a task by ID.

Features
JWT Authentication: Secure all task-related operations to ensure only authenticated users can access their data.
Task Management: Users can manage tasks including setting status and priority.
Filtering & Sorting: Support for filtering tasks by status, due date, and priority, with sorting capabilities.

Technologies Used
.NET 8
Entity Framework Core
JWT Authentication
SQL Database
