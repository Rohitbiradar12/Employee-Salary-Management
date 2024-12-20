## Employee-Salary Management System
The Employee-Salary Management System is a distributed application designed to manage employees and their associated salary details. The system consists of two microservices:

Employee Service: Handles employee data and operations.
Salary Service: Manages salary-related data and operations.
These services communicate with each other using REST APIs.

## Features

# Employee Service
Create, Read, Update, and Delete (CRUD) operations for employees.
Filter employees by city and age.
Sort employees by various parameters (e.g., name, age).
Automatically notify the Salary Service when a new employee is added.

# Salary Service
Maintain salary records for employees.
Calculate gross salary based on basic, allowances, and deductions.
Expose APIs for CRUD operations on salary data.

# System Highlights
Microservices architecture with separate services for employees and salaries.
Inter-service communication using HttpClient.
Database integration using Entity Framework Core with SQL Server.
Dependency Injection and Scoped/Transient services.
Swagger for API documentation and testing.

# Technologies Used
Backend Framework: .NET 6 with ASP.NET Core
Database: SQL Server# Employee-Salary Management System

## Getting Started

Follow these steps to set up and run the Employee-Salary Management System.

### Prerequisites
Make sure you have the following installed:
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- SQL Server (or any compatible database)
- Git

---

### Clone the Repository
Clone the repository and navigate to the project directory:
```bash
git clone https://github.com/Rohitbiradar12/Employee-Salary-Management.git
cd employee-salary-management-system

dotnet ef migrations add InitialMigration --project EmployeeService
dotnet ef migrations add InitialMigration --project SalaryService
dotnet ef database update --project EmployeeService
dotnet ef database update --project SalaryService
