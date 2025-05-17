
# 📘 Exam

Exam number one of **“Design and Programming of Mobile Platforms”**.  
This project is a backend API built with **.NET 8** and **SQL Server**.

---

## ⚙️ Installation and Configuration

### ✅ Requirements

```sh
- .NET 8 SDK or higher → https://dotnet.microsoft.com/en-us/download
- SQL Server → https://www.microsoft.com/en-us/sql-server/sql-server-downloads
- Visual Studio Code or Visual Studio
```

---

### 📁 Clone the Repository

```sh
git clone https://github.com/Kevin7819/Exam-Back.git
cd Exam-Back/api
```

---

## 🛠️ Database Configuration

### 1️⃣ Create `appsettings.Development.json`

Create a file named `appsettings.Development.json` inside the `api` folder with the following content:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
```

---

### 2️⃣ Create `appsettings.json` and configure SQL Server credentials

Inside the `api` folder, create a file named `appsettings.json` and add the following configuration:

```json
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

🔁 Replace `"YOURSERVER"` with the name of your actual SQL Server instance (e.g. `localhost\SQLEXPRESS`).

---

## 🚀 How to Run the API

### 1️⃣ Install dependencies

```sh
dotnet restore
```

---

### 2️⃣ Create the database

#### 📦 Initialize migrations

```sh
dotnet ef migrations add Init
```

#### 🧩 Apply the migrations to the database

```sh
dotnet ef database update
```

---

### 3️⃣ Run the API

```sh
dotnet run
```

---

## 📌 Important Notes

- 🔧 Replace `"YOURSERVER"` with your real SQL Server instance name
- ✅ Ensure the **SQL Server service** is running before executing database operations

---


# 👥 Contributors

- Gerald Andrey Calderón Castillo  
  GitHub: https://github.com/Gera10CC  
  ID: 703050481  

- Kevin Abel Venegas Bermúdez  
  GitHub: https://github.com/Kevin7819  
  ID: 703070997  

# 📂 Repository Links

- 🔙 Backend API in .NET  
  GitHub: git@github.com:Kevin7819/Exam-Back.git  
  Main Branch: Master  

- 📱 Android Mobile App  
  GitHub: git@github.com:Kevin7819/Exam-Front.git  
  Main Branch: Master  