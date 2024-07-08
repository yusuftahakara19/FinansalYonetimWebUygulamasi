# Financial Management Web Application

Financial Management Web Application is a comprehensive tool for managing personal finances, including account management, expense tracking, and money transfers. The application is built using N-tier architecture, ensuring a clear separation of concerns and maintainability.

## Technologies Used
- **Backend:** ASP.NET Core 7, Entity Framework Core
- **Frontend:** HTML, CSS, Vanilla JavaScript
- **Database:** Microsoft SQL Server
- **Others:** jQuery, jQuery Validation

## Video Demo

For a detailed walkthrough of the application, watch the [YouTube demo](https://www.youtube.com/watch?v=hzc20A8L_vA&t=1s).

## Installation

To install and run the application locally, follow these steps:

1. Clone the repository:
    ```bash
    git clone https://github.com/yourusername/financial-management-web-app.git
    ```
2. Navigate to the project directory:
    ```bash
    cd financial-management-web-app
    ```
3. Install the required packages:
    ```bash
    dotnet restore
    ```
4. Update the database connection string in `appsettings.json` to match your SQL Server configuration.

5. Apply the database migrations:
    ```bash
    dotnet ef database update
    ```
6. Run the application:
    ```bash
    dotnet run
    ```

## Usage

After starting the application, you can use the following features:

- **Account Management:** Create, edit, and delete accounts.
- **Expense Tracking:** Record, edit, and delete transactions.
- **Money Transfers:** Transfer money between accounts.
- **Exchange Rates:** View and update currency exchange rates.

