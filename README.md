# 🛒 Market Management System API

### *High-Performance Inventory & Security Framework*

---

## 🏗️ System Architecture & Logic

This project represents a professional-grade transition from a basic CRUD application to a secure, enterprise-ready API. It is built with a focus on **Separation of Concerns** and **Data Integrity**.

* **Framework Core:** Powered by **.NET 8** for high-performance request handling.
* **ORM & Database:** Utilizes **Entity Framework Core** with **SQL Server** to manage complex relational data.
* **Relational Mapping:** Implements a strict **One-to-Many** relationship where Categories act as parent containers for Market products.
* **Data Transfer Pattern (DTO):** Employs the DTO pattern to eliminate circular references and protect internal database schemas from external exposure.

---

## 🔐 Advanced Security Implementation

The API features a multi-layered authentication and authorization pipeline, moving beyond simple identity checks into rule-based logic.

### **1. JWT Bearer Authentication**

* Implements a secure "handshake" protocol where users exchange credentials for a cryptographically signed **JSON Web Token**.
* All sensitive methods are intercepted by a middleware pipeline that validates token integrity and expiration.

### **2. Role-Based Access Control (RBAC)**

* Distinguishes between `Admin` and `User` roles to govern system permissions.
* **Seeding Logic:** Automatically prepopulates the database with a default **Super Admin** account during the migration process for immediate environment setup.

### **3. Policy-Based Authorization**

* Includes a specialized **`SeniorManagerOnly`** policy.
* This policy evaluates **Custom Claims** (like `JobLevel`) within the JWT, allowing for dynamic security rules that aren't tied to static roles.

---

## 📂 Project Structure Overview

* **`Controllers/`**: Manages the API surface area for `Market`, `Category`, and `Account` (Identity).
* **`Models/`**: Houses the core domain entities, including the newly integrated `User` and `Role` definitions.
* **`DTOs/`**: Dedicated objects for `Login`, `Register`, and `Market` data exchange to maintain clean API contracts.
* **`Data/`**: Contains the `ApplicationDbContext` and the automated **Admin Seeding** configurations.

---

## 🛠️ Technical Implementation Details

* **Namespace:** `webAPI`
* **Authentication Scheme:** `JwtBearerDefaults.AuthenticationScheme`
* **Validation:** Implements `[FromBody]` and `[ApiController]` attributes to ensure strict JSON payload validation.
* **Documentation:** Integrated with **Swagger/OpenAPI** for real-time endpoint testing and schema visualization.

---