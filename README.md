# Exam

Exam number one of “Design and programming of mobile platforms”.

## Installation and Configuration

### Requirements
```sh
- .NET 8 SDK (https://dotnet.microsoft.com/en-us/download) or higher
- SQL Server (https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- Visual Studio Code or Visual Studio
```
### Clone the repository

```sh
git clone https://github.com/Kevin7819/Exam-Back.git
cd Exam-Back/api
```

### Database Configuration

### 1️⃣ Create appsettings.Development.json

### Create an appsettings.Development.json file inside the api folder with the following content:

```sh
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
```
### 2️⃣ Create appsettings.json and configure SQL Server credentials

### Inside the api folder, create a file called appsettings.json and add your credentials:
```sh
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOURSERVER;Database=dbexam;Integrated Security=True;TrustServerCertificate=True;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}

```
## How to Run the API

### 1️⃣ Install dependencies

dotnet restore

### 2️⃣ Create the database

### To initialize migrations

```sh
dotnet ef migrations add Init
```

### To update the database

```sh
dotnet ef database update
```

### 3️⃣ Run the API

```sh
dotnet run
```

### Important Notes:
- Replace "YOURSERVER" with your actual SQL Server instance name
- The JWT key shown is a sample - for production use a more secure key
- Ensure SQL Server service is running before database operations
- For development purposes only