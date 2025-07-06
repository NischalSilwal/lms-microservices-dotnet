# 🚀 Microservices Architecture Project

[![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)](https://dotnet.microsoft.com/)
[![Ocelot](https://img.shields.io/badge/Ocelot-API%20Gateway-blue?style=for-the-badge)](https://github.com/ThreeMammals/Ocelot)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)](https://www.microsoft.com/en-us/sql-server)
[![Microservices](https://img.shields.io/badge/Architecture-Microservices-green?style=for-the-badge)](https://microservices.io/)

> **A beginner-friendly microservices project demonstrating modern distributed architecture patterns with Ocelot API Gateway and lightweight APIs.**

---

## 📋 Table of Contents

- [🎯 Project Overview](#-project-overview)
- [🏗️ Architecture](#️-architecture)
- [✨ Features](#-features)
- [🛠️ Technology Stack](#️-technology-stack)
- [📁 Project Structure](#-project-structure)
- [🚀 Getting Started](#-getting-started)
- [⚙️ Configuration](#️-configuration)
- [📖 Learning Guide](#-learning-guide)
- [🤝 Contributing](#-contributing)

---

## 🎯 Project Overview

This project demonstrates a **microservices architecture** implementation using modern .NET technologies. It's designed as an educational resource for developers who want to understand and implement their first microservices project.

### 🎯 Why This Project?

- **Learn by Example**: Real-world implementation of microservices patterns
- **Beginner-Friendly**: Clear separation of concerns and well-documented code
- **Production-Ready**: Uses industry-standard tools and practices
- **Scalable Design**: Easy to extend with additional services

---

## 🏗️ Architecture

```
┌─────────────────┐    ┌─────────────────┐    ┌─────────────────┐
│   Client Apps   │    │   Mobile Apps   │    │   Web Portal    │
└─────────┬───────┘    └────────┬───────┘     └─────────┬───────┘
          │                     │                       │
          └─────────────────────┼───────────────────────┘
                                │
                       ┌────────│────────┐
                       │  Ocelot Gateway │
                       │   (Port 5000)   │
                       └─────────┬───────┘
                                 │
          ┌──────────────────────┼────────────────┐────────────────────┐
          │                      │                │                    │
┌─────────┴───────┐ ┌────────────│────┐ ┌─────────┴───────┐  ┌─────────┴──────────┐ 
│ Authentication  │ │ Student Service │ │  Book Service   │  │  DashboardService  │
│   Service       │ │   (Port 5112)   │ │  (Port 5115)    │  │  (Port 5117)       │
│  (Port 5113)    │ │                 │ │                 │  │                    │
└─────────────────┘ └─────────────────┘ └─────────────────┘  └─────────────────── ┘
```

### 🔧 Key Components

- **🛡️ Ocelot API Gateway**: Single entry point for all client requests
- **🔐 Authentication Service**: Handles user authentication and authorization
- **👥 Student Management Service**: Manages student data and operations
- **📚 Book Management Service**: Handles book inventory and operations
- **🗄️ Database per Service**: Each service has its own database

---

## ✨ Features

### 🚀 Core Features
- ✅ **Microservices Architecture** - Loosely coupled, independently deployable services
- ✅ **API Gateway** - Centralized routing and cross-cutting concerns
- ✅ **Service Independence** - Each service can be developed, deployed, and scaled independently
- ✅ **Database per Service** - Data isolation and service autonomy
- ✅ **Lightweight APIs** - Fast and efficient service communication

### 🛠️ Technical Features
- ✅ **Automated Migrations** - Database setup with shell scripts
- ✅ **JSON Configuration** - Simple Ocelot routing configuration
- ✅ **Development Environment** - Ready-to-use development setup
- ✅ **Scalable Design** - Easy to add new services and features

---

## 🛠️ Technology Stack

| Category | Technology | Purpose |
|----------|------------|---------|
| **Framework** | .NET 6/7/8 | Core application framework |
| **API Gateway** | Ocelot | Request routing and API composition |
| **Database** | SQL Server | Data persistence |
| **ORM** | Entity Framework Core | Data access layer |
| **Authentication** | JWT/Identity | Security and user management |
| **Configuration** | appsettings.json | Environment-specific settings |

---

## 📁 Project Structure

```
📦 MicroservicesLibrarySystem/
├── 🚪 ApiGateway-microservices/
│ └── 🛡️ ApiGateway-microservices/
│ ├── 📄 ApiGateway-microservices.csproj
│ ├── 📄 Program.cs
│ ├── 📄 ocelot.json
│ └── 📄 appsettings.json
│
├── 📚 BookService/
│ └── BookService/
│ ├── 📄 BookService.csproj
│ ├── 📄 Program.cs
│ ├── 📄 Book.cs
│ ├── 📄 BookModule.cs
│ ├── 📄 ApplicationDbContext.cs
│ └── 📁 Controllers/
│
├── 📊 DashboardService/
│ └── DashboardService/
│ ├── 📄 DashboardService.csproj
│ ├── 📄 Program.cs
│ ├── 📄 DashboardModule.cs
│ └── 📁 Controllers/
│
├── 👨‍🎓 StudentService/
│ └── StudentService/
│ ├── 📄 StudentService.csproj
│ ├── 📄 Program.cs
│ ├── 📄 Student.cs
│ ├── 📄 StudentModule.cs
│ ├── 📄 ApplicationDbContext.cs
│ └── 📁 Controllers/
│
└── 🔐 UserService/
└── UserService/
├── 📄 UserService.csproj
├── 📄 Program.cs
├── 📄 User.cs
├── 📄 UserModule.cs
├── 📁 context/
└── 📁 Controllers/
```

---

## 🚀 Getting Started

### 📋 Prerequisites

Before running this project, ensure you have:

- ✅ **.NET 6 SDK** or later installed
- ✅ **SQL Server** (LocalDB or full version)
- ✅ **Visual Studio** or **VS Code**
- ✅ **Git** for version control

### 🔧 Installation & Setup

#### 1️⃣ Clone the Repository
```bash
git clone https://github.com/yourusername/microservices-project.git
cd microservices-project
```

#### 2️⃣ Configure Database Connection
Before running the project, update the database connection strings in each service:

**📝 Update Connection Strings:**
```json
// In each appsettings.Development.json file
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=YOUR_DATABASE_NAME;Trusted_Connection=true;TrustServerCertificate=true;"
  }
}
```

**🔧 Files to Update:**
- `AuthenticationService/appsettings.Development.json`
- `StudentService/appsettings.Development.json`
- `BookService/appsettings.Development.json`

#### 3️⃣ Run the Setup Script
```bash
# Make the script executable (Linux/Mac)
chmod +x scripts/setup.sh

# Run the setup script
./scripts/setup.sh
```

> **💡 Note**: The setup script will automatically:
> - Restore NuGet packages for all projects
> - Run database migrations for each service
> - Build all projects

#### 4️⃣ Manual Migration (Alternative)
If you prefer to run migrations manually:

```bash
# Navigate to each service directory and run:
cd AuthenticationService
dotnet ef migrations add "InitialCreate"
dotnet ef database update

cd ../StudentService
dotnet ef migrations add "InitialCreate"
dotnet ef database update

cd ../BookService
dotnet ef migrations add "InitialCreate"
dotnet ef database update
```

---

## ⚙️ Configuration

### 🛡️ Ocelot API Gateway Configuration

The Ocelot gateway uses a simple JSON configuration format:

```json
{
  "Routes": [
    {
      "DownstreamPathTemplate": "/api/auth/{everything}",
      "DownstreamScheme": "https",
      "DownstreamHostAndPorts": [
        {
          "Host": "localhost",
          "Port": 5003
        }
      ],
      "UpstreamPathTemplate": "/auth/{everything}",
      "UpstreamHttpMethod": [ "GET", "POST", "PUT", "DELETE" ]
    },
    {
      "DownstreamPathTemplate": "/api/students/{everything}",
      "DownstreamScheme": "https",
      "DownstreamHostAndPorts": [
        {
          "Host": "localhost",
          "Port": 5001
        }
      ],
      "UpstreamPathTemplate": "/students/{everything}",
      "UpstreamHttpMethod": [ "GET", "POST", "PUT", "DELETE" ]
    }
  ]
}
```

### 📊 Service Port Configuration

| Service     | Port  | Base Path            |
|-------------|-------|----------------------|
| Users       | 5113  | `/api/users/`        |
| Students    | 5112  | `/api/students/`     |
| Books       | 5115  | `/api/books/`        |
| Dashboard   | 5117  | `/api/dashboard/`    |
| API Gateway | 5000  | `/api/{service}/...` |


---

## 🏃‍♂️ Running the Project

### 🚀 Start All Services

**Option 1: Using Visual Studio**
1. Set multiple startup projects
2. Select all service projects
3. Press F5 to run

**Option 2: Using Command Line**
```bash
# Terminal 1 - API Gateway
cd ApiGateway
dotnet run

# Terminal 2 - Authentication Service
cd AuthenticationService
dotnet run

# Terminal 3 - Student Service
cd StudentService
dotnet run

# Terminal 4 - Book Service
cd BookService
dotnet run
```

### 🔍 Testing the Services

Once all services are running, you can test them:

- **API Gateway**: `https://localhost:5000`
- **Swagger UI**: Each service exposes Swagger documentation
- **Health Checks**: `/health` endpoint on each service

---

## 📖 Learning Guide

### 🎓 For Beginners: Building Your First Microservice

This project is designed to be your stepping stone into microservices architecture. Here's how to approach it:

#### 1️⃣ **Understanding the Architecture**
- Start by examining the project structure
- Understand how each service has its own responsibility
- See how services communicate through HTTP APIs

#### 2️⃣ **Key Concepts to Learn**
- **Service Independence**: Each service can be developed and deployed separately
- **API Gateway Pattern**: Single entry point for all client requests
- **Database per Service**: Data isolation and service autonomy
- **Configuration Management**: Environment-specific settings

#### 3️⃣ **Adding Your Own Service**
To add a new service (e.g., Library Management):

1. Create a new .NET Web API project
2. Add Entity Framework and your models
3. Create controllers and business logic
4. Update the Ocelot configuration
5. Add database migrations
6. Test your service

#### 4️⃣ **Best Practices Demonstrated**
- ✅ Clear separation of concerns
- ✅ RESTful API design
- ✅ Configuration management
- ✅ Database migrations
- ✅ Error handling
- ✅ Swagger documentation

### 🎯 Next Steps

After understanding this project, consider exploring:
- **Docker containerization**
- **Service discovery**
- **Circuit breaker patterns**
- **Distributed caching**
- **Message queues**
- **Monitoring and logging**

---

## 🧪 Testing

### 🔧 Running Tests
```bash
# Run all tests
dotnet test

# Run tests for a specific service
dotnet test StudentService.Tests
```

### 📊 API Testing
Use tools like:
- **Postman** - For manual API testing
- **Swagger UI** - Built-in API documentation and testing
- **curl** - Command-line testing

Example API calls:
```bash
# Get all students through API Gateway
curl -X GET https://localhost:5000/students

# Create a new student
curl -X POST https://localhost:5000/students \
  -H "Content-Type: application/json" \
  -d '{"name": "John Doe", "email": "john@example.com"}'
```

---

## 🤝 Contributing

We welcome contributions! Here's how you can help:

### 🐛 Reporting Issues
- Use GitHub Issues to report bugs
- Provide detailed reproduction steps
- Include environment information

### 💡 Feature Requests
- Suggest new features through GitHub Issues
- Explain the use case and benefit

### 🔧 Pull Requests
1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add tests if applicable
5. Submit a pull request

---

## 📚 Additional Resources

### 📖 Documentation
- [Ocelot Documentation](https://ocelot.readthedocs.io/)
- [.NET Microservices Guide](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)

### 🎓 Learning Materials
- [Microservices.io](https://microservices.io/)
- [Microsoft Microservices Architecture](https://docs.microsoft.com/en-us/azure/architecture/microservices/)

---

## 📄 Contact Me: 

[![LinkedIn](https://img.shields.io/badge/LinkedIn-Connect-blue?logo=linkedin&style=for-the-badge)](https://www.linkedin.com/in/nischal-silwal-1ba8b2324/)
[![Gmail](https://img.shields.io/badge/Gmail-nischalsilwalhtd@gmail.com-red?logo=gmail&style=for-the-badge)](mailto:nischalsilwalhtd@gmail.com)


---

## 🙏 Acknowledgments

- Thanks to the Ocelot team for the excellent API Gateway
- Microsoft for the comprehensive .NET ecosystem
- The open-source community for continuous inspiration

---

<div align="center">

### 🌟 If this project helped you learn microservices, please give it a star! ⭐

**Happy Coding!** 🚀

</div>

