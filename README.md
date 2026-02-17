# Market API

A RESTful Web API built with **.NET 8** and **Entity Framework Core** to manage market products and categories. This project demonstrates full CRUD operations and relational data handling using a SQL Server database.

## 🚀 Tech Stack
* **Framework:** .NET 8 Web API
* **Language:** C#
* **Database:** SQL Server
* **ORM:** Entity Framework Core
* **Documentation:** Swagger / OpenAPI

## ✨ Features
* **Products Management:** Create, Read, Update, and Delete products.
* **Categories Management:** Organize products into categories.
* **Relational Data:** Implements a one-to-many relationship (One Category -> Many Products).
* **DTO Pattern:** Uses Data Transfer Objects to shape API responses and prevent cycles.

## 📂 Project Structure
* `Controllers/`: Contains the API endpoints (`MarketController`, `CategoryController`).
* `Data/`: Database context and configuration.
* `Models/`: Entity definitions (`Product.cs`, `Category.cs`).
* `DTOs/`: Data Transfer Objects for clean API responses (`CategoryDTO`, `ProductDTO`).
* `postman/`: Contains the exported Postman collection for testing.