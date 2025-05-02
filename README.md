# 🍔 GoodHamburguer API

A simple Web API built with ASP.NET Core 8 for managing sandwich orders, extras, and applying business rules based on item combinations.

## 🏗️ Architecture
The project follows the principles of **Clean Architecture**, separating responsibilities across the **Application, Domain, Infrastructure, and WebAPI** layers. It uses the **CQRS** pattern to separate read and write operations, implemented with **MediatR** for decoupling between command and query handlers.

## 🛠 Technologies Used
ASP.NET Core 8

C#
Entity Framework Core (InMemory)
Swagger / Swashbuckle

## 📋 Features

- ✅ List available sandwiches and extras  
- ✅ Create new orders  
- ✅ Apply automatic discounts based on selected items  
- ✅ Update existing orders  
- ✅ Delete orders  
- ✅ In-memory database (no setup required)  
- ✅ Swagger for testing endpoints  

## 📦 Requirements

- .NET 8 SDK  
- Visual Studio 2022+ or Visual Studio Code  
- No authentication or external database required  

## 🚀 Getting Started

1. Clone the repository:

   ```bash
   git clone https://github.com/your-username/good-hamburguer-api.git
   cd good-hamburguer-api

2. Run the project:
   ```bash
   dotnet run
   ```
   
3. Open your browser and navigate to:
   ```bash
   [dotnet run](https://localhost:{PORT}/swagger)
   ```
