# 🛠️ Product Management API

A clean, modular, and extensible ASP.NET Core Web API for managing products using modern development practices including:

- Clean Architecture
- CQRS with MediatR
- FluentValidation
- AutoMapper
- Entity Framework Core (In-Memory)
- Dummy in-memory Authentication
- Audit Fields (CreatedAt, ModifiedAt)

---

## 📁 Project Structure

```
ProductManagement/
├── Application/               # Application logic (CQRS, DTOs, validators)
├── Domain/                   # Domain entities
├── Infrastructure/          # Data access, persistence logic
├── WebAPI/ (or ProductManagement/)  # API layer (Controllers, Program.cs)
└── README.md
```

---

## ⚙️ Technologies Used

- [.NET 8](https://dotnet.microsoft.com/en-us/)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)
- [MediatR](https://github.com/jbogard/MediatR)
- [FluentValidation](https://docs.fluentvalidation.net/)
- [AutoMapper](https://automapper.org/)
- [Swagger / Swashbuckle](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)

---

## 🚀 Getting Started

### 🔧 Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

---

### 🧪 Run the Application

```bash
# Run the app
dotnet run --project ProductManagement
```

Navigate to:

```
https://localhost:{port}/swagger
```

to access the Swagger UI.

---

### 🧱 Run Migrations (Optional for real DBs)

If you switch to a real database (e.g., SQL Server), use:

```bash
# Add migration
dotnet ef migrations add InitialCreate --project Infrastructure --startup-project ProductManagement --context ApplicationDbContext

# Update database
dotnet ef database update --project Infrastructure --startup-project ProductManagement --context ApplicationDbContext
```

---

## 🔐 Authentication

The project uses a **dummy in-memory authentication scheme**. You can simulate authorization by sending a fake `Authorization` header:

```
Authorization: Bearer dummy-token
```

All authenticated routes assume the user is authorized.

---

## ✅ Features Implemented

### Products API

- **Create Product**
- **Update Product**
- **Delete Product**
- **Get Product by ID**
- **Get All Products (with pagination & filtering)**

### Validations

- Uses `FluentValidation` for command-level validations.
- Automatic model validation middleware is configured.

### CQRS

- Each use case is handled using separate `Command` / `Query` handlers via `MediatR`.

---

## 📦 Sample Request

### POST `/api/products`

```json
{
  "name": "Example Product",
  "price": 120.5,
  "quantity": 10
}
```



## ✨ Extending the App

You can easily extend this by:

- Adding new entities under `Domain`
- Creating commands/queries in `Application`
- Registering new validators
- Adding new `DbSet<TEntity>` in `ApplicationDbContext`

---

## 📌 Notes

- The app uses an in-memory database for simplicity — perfect for demos or quick tests.
- You can switch to SQL Server or another provider by updating `Program.cs` and `DbContext`.

---

## 🧑‍💻 Author

**Mohaned El Hadidi** 

---

## 📄 License

This project is licensed under the MIT License.