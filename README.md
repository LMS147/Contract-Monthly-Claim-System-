# Contract Monthly Claim System

A comprehensive web application for managing and processing monthly claims for contracts. Built with ASP.NET Core, this system provides user authentication, claim management, reporting capabilities, and Excel export functionality.

## 📋 Table of Contents

- [Features](#features)
- [Technology Stack](#technology-stack)
- [Prerequisites](#prerequisites)
- [Installation & Setup](#installation--setup)
- [Project Structure](#project-structure)
- [Configuration](#configuration)
- [Usage](#usage)
- [Database](#database)
- [Authentication & Authorization](#authentication--authorization)
- [API & Services](#api--services)
- [License](#license)

## ✨ Features

- **User Authentication & Authorization** - Secure login system with Identity Framework
- **Claim Management** - Create, view, edit, and process monthly claims
- **Report Generation** - Generate comprehensive reports on claims and contracts
- **Excel Export** - Export claim data to Excel format using EPPlus and ClosedXML
- **PDF Generation** - Generate PDF documents using iText7
- **Role-Based Access Control** - Different access levels for managers and users
- **Database Seeding** - Automatic initialization with default users and roles

## 🛠️ Technology Stack

- **Framework**: ASP.NET Core 8.0
- **Language**: C# with nullable reference types enabled
- **Database**: SQL Server (LocalDB for development)
- **ORM**: Entity Framework Core 8.0.28
- **Authentication**: ASP.NET Core Identity with JWT Bearer support
- **Excel Processing**: EPPlus 6.2.11, ClosedXML 0.105.0
- **PDF Generation**: iText7 9.4.0
- **Testing**: FakeItEasy 8.3.0
- **Web Framework**: ASP.NET Core MVC

## 📋 Prerequisites

Before you begin, ensure you have the following installed:

- **.NET 8.0 SDK** or later
- **SQL Server** (or LocalDB included with Visual Studio)
- **Visual Studio 2022** (Community, Professional, or Enterprise) or **Visual Studio Code** with C# extension

## 🚀 Installation & Setup

### 1. Clone the Repository

```bash
git clone https://github.com/LMS147/Contract-Monthly-Claim-System-.git
cd Contract-Monthly-Claim-System-
```

### 2. Restore Dependencies

```bash
dotnet restore
```

### 3. Update the Database Connection String

Edit `appsettings.json` to configure your database connection:

```json
{
    "ConnectionStrings": {
        "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ContractMonthlyClaimSystem;Trusted_Connection=true;MultipleActiveResultSets=true"
    }
}
```

For production, update with your actual SQL Server connection details.

### 4. Apply Migrations & Seed Database

```bash
dotnet ef database update
```

The application will automatically seed the database with default users and roles on first run.

### 5. Build & Run

```bash
dotnet run
```

Or open the solution in Visual Studio:
```bash
start ContractMonthlyClaimSystem.sln
```

The application will be available at `https://localhost:5001` or `http://localhost:5000`.

## 📁 Project Structure

```
Contract-Monthly-Claim-System/
├── Controllers/           # MVC Controllers for handling requests
├── Models/               # Data models and ViewModels
├── Views/                # Razor templates for UI
├── Migrations/           # Database migration files
├── Properties/           # Project properties and launch settings
├── wwwroot/             # Static files (CSS, JS, images)
├── Program.cs           # Application entry point and DI configuration
├── appsettings.json     # Configuration settings
├── appsettings.Development.json # Development-specific settings
└── ContractMonthlyClaimSystem.csproj # Project file with dependencies
```

## ⚙️ Configuration

### Application Settings

Edit `appsettings.json` to configure:

- **Database Connection**: Update the connection string for your environment
- **Logging**: Adjust log levels as needed
- **HTTPS**: Configure HTTPS settings

### EPPlus License

The application uses a non-commercial license for EPPlus:
```csharp
ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
```

For commercial use, update the license context accordingly.

## 🔐 Authentication & Authorization

### Security Features

- **Password Requirements**:
  - Minimum 6 characters
  - Must contain at least one uppercase letter
  - Must contain at least one lowercase letter
  - Must contain at least one digit
  - Unique characters required

- **Account Lockout**:
  - 5 failed login attempts trigger a 5-minute lockout
  - Lockout enabled for new users

- **Session Management**:
  - 60-minute session timeout
  - Sliding expiration enabled
  - Secure, HttpOnly cookies

- **Authorization**:
  - Login required: `/Account/Login`
  - Access denied page: `/Manager/AccessDenied`

## 💼 API & Services

### IClaimService

Manages claim-related operations:
- Register implementation: `ClaimService`
- Handles claim creation, retrieval, and processing

### IReportService

Generates reports and analytics:
- Register implementation: `EnhancedReportService`
- Supports multiple export formats (Excel, PDF)

Services are registered as scoped dependencies in the DI container.

## 🗄️ Database

### Connection String

The application uses SQL Server LocalDB by default:

```
Server=(localdb)\mssqllocaldb;Database=ContractMonthlyClaimSystem;Trusted_Connection=true;MultipleActiveResultSets=true
```

### Entity Framework Core

- **Version**: 8.0.28
- **Design**: Code-first migrations
- **Tools**: Entity Framework Core CLI and Tools installed
- **Auto Seeding**: Database is automatically seeded on application startup

## 📝 Usage

### Accessing the Application

1. Navigate to `https://localhost:5001`
2. Log in with default credentials (configured during seeding)
3. Access different features based on your role

### Creating a Claim

1. Go to the Claims section
2. Click "New Claim"
3. Fill in the required information
4. Save and submit

### Generating Reports

1. Navigate to Reports section
2. Select your report criteria
3. Choose export format (Excel/PDF)
4. Download the generated file

### Exporting Data

Use the export functionality to save claim data in Excel format with full formatting and multiple sheets.

## 🧪 Development

### Building the Project

```bash
dotnet build
```

### Running Tests

```bash
dotnet test
```

### Creating a Migration

```bash
dotnet ef migrations add MigrationName
```

### Updating the Database

```bash
dotnet ef database update
```

## 📄 License

This project is licensed under the MIT License - see the [LICENSE.txt](LICENSE.txt) file for details.

## 🤝 Contributing

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📧 Support

For issues, questions, or suggestions, please open an issue on the [GitHub repository](https://github.com/LMS147/Contract-Monthly-Claim-System-/issues).

---

**Last Updated**: July 2026
