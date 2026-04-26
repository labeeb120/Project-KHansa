# Institute Management System (VB.NET)

This is a simple accounting system for an institute, built using VB.NET and MS Access.

## Features
- Dynamic MS Access database connection.
- Automatic database schema generation.
- Student fee management.
- Institute expense tracking.
- Monthly and annual financial reports.
- Role-based login system.

## Requirements
- .NET 8.0 SDK or later.
- Windows OS (for running the UI).
- Microsoft Access Database Engine (for OLEDB connection).

## Setup
1. Clone the repository.
2. Open `InstituteSystem.sln` using **Visual Studio 2022**.
3. Ensure you have the **.NET desktop development** workload installed in Visual Studio.
4. Press **F5** or click **Start** to run the application.
4. On the login screen, select a path to an existing or new `.accdb` file.
5. Log in with:
   - **Username:** `admin`
   - **Password:** `admin123`

## Structure
- `DatabaseManager.vb`: Handles all data operations and schema initialization.
- `FrmLogin.vb`: Entry point for user authentication and DB path selection.
- `FrmMain.vb`: Dashboard for navigation.
- `FrmPayments.vb`: Interface for student fees.
- `FrmExpenses.vb`: Interface for institute expenses.
- `FrmReports.vb`: Financial reporting module.
