# Chinese Auction Management System

This repository contains a full-stack project for managing a Chinese auction, with a backend API built in ASP.NET Core and a frontend in React.

---

## Project Overview

The system supports two types of users: Management and Customers.

### Management

- Login using predefined credentials (no registration).
- Manage donors: view, add, update, delete, and filter.
- Manage gifts: view, add, update, delete, with categories and ticket prices.
- View purchases, sort by gift price or popularity.
- Conduct draws per gift, generate winners and income reports.

### Customers

- Register and login with validation.
- Browse and filter gifts.
- Add gifts to a shopping cart.
- Save draft purchases.
- Confirm purchases.
- View winners after the draw.

---

## Technologies

- Backend: ASP.NET Core Web API with Entity Framework Core (Code First).
- Frontend: React.
- Database: MS SQL Server.
- Security: JWT authentication with role-based authorization.

---

## Getting Started

### Backend (API)

1. Navigate to the API directory:

    ```bash
    cd Server
    ```

2. Build and run the API:

    ```bash
    dotnet build
    dotnet run
    ```

### Frontend (React)

1. Navigate to the Client directory:

    ```bash
    cd Client
    ```

2. Install dependencies and start the React app:

    ```bash
    npm install
    npm start
    ```

---

### Security

- JWT authentication.
- Role-based authorization ([Authorize(Roles = "manager")]) for management actions.
- Middleware for authentication, error handling, and logging.

---

### Author

Yehudit Dolgin
