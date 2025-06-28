# ASP.NET MVC Admin Dashboard

A modular and extensible ASP.NET MVC web application with authentication, token-based session handling, and full CRUD operations for Employees and Departments. Built using a 3-Tier Architecture and the Unit of Work pattern.

---

## 🚀 Features

- 🔐 ASP.NET Identity (Login / Register)
- 🍪 Token stored in Cookies for session handling
- 📂 Department Controller with:
  - Index
  - Create
  - Edit
  - Details
  - Delete
- 👤 Employee Controller with:
  - Index
  - Create
  - Edit
  - Details
  - Delete
- 🛠️ Unit of Work + Repository Pattern
- 🧱 Three-Tier Architecture:
  - **Presentation Layer** (UI)
  - **Business Logic Layer** (BLL)
  - **Data Access Layer** (DAL)
- 🎨 Responsive UI using Bootstrap

---

## 📁 Project Structure

```plaintext
│
├── Dashboard.Web            → UI / MVC project (Views, Controllers)
├── Dashboard.BLL            → Business Logic Layer (Services, Interfaces)
├── Dashboard.DAL            → Data Access Layer (Repositories, UnitOfWork)
├── Dashboard.Entities       → Models / Domain Entities
├── Dashboard.Data           → DbContext, EF Core Configurations
└── Dashboard.Core           → Interfaces, Utilities, Shared Code
