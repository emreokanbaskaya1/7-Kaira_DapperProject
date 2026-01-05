# 🛍️ Kaira - Fashion E-Commerce Platform

![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?style=for-the-badge&logo=dotnet)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-MVC-512BD4?style=for-the-badge&logo=dotnet)
![Dapper](https://img.shields.io/badge/Dapper-ORM-00758F?style=for-the-badge)
![OpenAI](https://img.shields.io/badge/OpenAI-GPT--4-412991?style=for-the-badge&logo=openai)
![Bootstrap](https://img.shields.io/badge/Bootstrap-5.3-7952B3?style=for-the-badge&logo=bootstrap)

A modern, feature-rich fashion e-commerce platform built with ASP.NET Core MVC and Dapper ORM, featuring an AI-powered outfit suggestion assistant.

## ✨ Features

### 🎨 Frontend Features
- **Responsive Design**: Mobile-first approach with Bootstrap 5.3
- **Dynamic Product Catalog**: Browse products with pagination
- **Category Management**: Organized product categories
- **Video Integration**: Embedded promotional videos
- **Customer Testimonials**: Display customer reviews
- **AI Outfit Assistant**: Get personalized outfit suggestions powered by OpenAI GPT-4

### 🔧 Backend Features
- **Dapper ORM**: Lightweight and fast data access
- **Repository Pattern**: Clean architecture with separation of concerns
- **View Components**: Modular and reusable UI components
- **Admin Panel**: Complete CRUD operations for all entities
- **RESTful API**: Clean API endpoints for data management

### 🤖 AI Integration
- **OpenAI GPT-4o-mini**: Intelligent outfit recommendations
- **Season-Based Suggestions**: Spring, Summer, Autumn, Winter
- **Occasion-Specific**: Business, Casual, Sport, Special Events
- **Real-time Response**: Instant AI-powered suggestions

## 🏗️ Project Structure

```
Kaira_DapperProject/
├── KairaWebUI/
│   ├── Areas/
│   │   └── Admin/
│   │       ├── Controllers/
│   │       │   ├── CategoryController.cs
│   │       │   ├── ProductController.cs
│   │       │   ├── CollectionController.cs
│   │       │   ├── TestimonialController.cs
│   │       │   └── VideoController.cs
│   │       └── Views/
│   ├── Controllers/
│   │   └── HomeController.cs
│   ├── Context/
│   │   └── AppDbContext.cs
│   ├── DTOs/
│   │   ├── CategoryDtos/
│   │   ├── ProductDtos/
│   │   ├── CollectionDtos/
│   │   ├── TestimonialDtos/
│   │   └── VideoDtos/
│   ├── Repositories/
│   │   ├── CategoryRepositories/
│   │   ├── ProductRepositories/
│   │   ├── CollectionRepositories/
│   │   ├── TestimonialRepositories/
│   │   └── VideoRepositories/
│   ├── ViewComponents/
│   │   ├── BillboardViewComponent.cs
│   │   ├── ProductsViewComponent.cs
│   │   ├── VideoViewComponent.cs
│   │   └── TestimonialsViewComponent.cs
│   ├── Views/
│   │   ├── Home/
│   │   └── Shared/
│   ├── wwwroot/
│   └── Program.cs
```

## 🚀 Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [SQL Server](https://www.microsoft.com/sql-server) or LocalDB
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)
- [OpenAI API Key](https://platform.openai.com/api-keys)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/emreokanbaskaya1/7-Kaira_DapperProject.git
   cd 7-Kaira_DapperProject
   ```

2. **Update Connection String**
   
   Open `appsettings.json` and update the connection string:
   ```json
   {
     "ConnectionStrings": {
       "SqlConnection": "Your_Connection_String_Here"
     }
   }
   ```

3. **Add OpenAI API Key**
   
   Add your OpenAI API key to `appsettings.json`:
   ```json
   {
     "OpenAI": {
       "ApiKey": "your-openai-api-key-here"
     }
   }
   ```

4. **Create Database**
   
   Run the following SQL script to create the database:
   ```sql
   CREATE DATABASE KaireDapperDb;
   GO

   USE KaireDapperDb;
   GO

   CREATE TABLE Categories (
       CategoryId INT PRIMARY KEY IDENTITY(1,1),
       Name NVARCHAR(100) NOT NULL
   );

   CREATE TABLE Products (
       ProductId INT PRIMARY KEY IDENTITY(1,1),
       Name NVARCHAR(200) NOT NULL,
       Description NVARCHAR(MAX),
       Price DECIMAL(18,2) NOT NULL,
       ImageUrl NVARCHAR(500),
       CategoryId INT FOREIGN KEY REFERENCES Categories(CategoryId)
   );

   CREATE TABLE Collections (
       CollectionId INT PRIMARY KEY IDENTITY(1,1),
       Title NVARCHAR(200) NOT NULL,
       Description NVARCHAR(MAX),
       ImageUrl NVARCHAR(500)
   );

   CREATE TABLE Testimonials (
       TestimonialId INT PRIMARY KEY IDENTITY(1,1),
       CustomerName NVARCHAR(100) NOT NULL,
       Comment NVARCHAR(MAX) NOT NULL,
       Rating INT
   );

   CREATE TABLE Videos (
       VideoId INT PRIMARY KEY IDENTITY(1,1),
       Url NVARCHAR(500) NOT NULL,
       BackgroundImageUrl NVARCHAR(500)
   );
   ```

5. **Restore NuGet Packages**
   ```bash
   dotnet restore
   ```

6. **Run the Application**
   ```bash
   dotnet run --project KairaWebUI
   ```

7. **Access the Application**
   - Frontend: `https://localhost:5001`
   - Admin Panel: `https://localhost:5001/Admin/Product`

## 📦 Dependencies

### Core Dependencies
- **ASP.NET Core 9.0**: Web framework
- **Dapper**: Micro ORM
- **Microsoft.Data.SqlClient**: SQL Server data provider

### Frontend Dependencies
- **Bootstrap 5.3**: UI framework
- **Swiper.js**: Touch slider
- **AOS**: Animate on scroll library

### AI Integration
- **OpenAI SDK**: GPT-4 integration for outfit suggestions

## 🎯 Key Features Explained

### 1. AI Outfit Suggestion Assistant

The platform includes an innovative AI-powered outfit suggestion feature:

```csharp
[HttpPost]
public async Task<IActionResult> GetOutfitSuggestion(string season, string occasion)
{
    var apiKey = _configuration["OpenAI:ApiKey"];
    var client = new ChatClient("gpt-4o-mini", apiKey);
    
    var prompt = $@"Provide a short outfit suggestion for {season} season 
                    and {occasion} occasion in English...";
    
    var response = await client.CompleteChatAsync(prompt);
    return Json(new { success = true, suggestion = response.Value.Content[0].Text });
}
```

**How it works:**
1. User selects season (Spring, Summer, Autumn, Winter)
2. User selects occasion (Business, Casual, Sport, Special Event)
3. AI generates personalized outfit recommendations
4. Results displayed in a clean, formatted list

### 2. Repository Pattern

Clean separation of data access logic:

```csharp
public interface IProductRepository
{
    Task<List<ResultProductDto>> GetAllProductsAsync();
    Task<ResultProductDto> GetProductByIdAsync(int id);
    Task CreateProductAsync(CreateProductDto createProductDto);
    Task UpdateProductAsync(UpdateProductDto updateProductDto);
    Task DeleteProductAsync(int id);
}
```

### 3. View Components

Reusable UI components for better code organization:

- **BillboardViewComponent**: Hero slider
- **ProductsViewComponent**: Product grid with pagination
- **VideoViewComponent**: Promotional videos
- **TestimonialsViewComponent**: Customer reviews

## 🔐 Admin Panel

Access the admin panel to manage:
- ✅ Products (CRUD operations)
- ✅ Categories
- ✅ Collections
- ✅ Testimonials
- ✅ Videos

**Admin Routes:**
- `/Admin/Product`
- `/Admin/Category`
- `/Admin/Collection`
- `/Admin/Testimonial`
- `/Admin/Video`

## 🎨 UI/UX Features

- **Responsive Design**: Works seamlessly on all devices
- **Smooth Animations**: AOS library for scroll animations
- **Interactive Sliders**: Swiper.js for product carousels
- **Modern UI**: Bootstrap 5 with custom styling
- **SVG Icons**: Scalable vector icons for better performance

## 📊 Database Schema

```
Categories
├── CategoryId (PK)
└── Name

Products
├── ProductId (PK)
├── Name
├── Description
├── Price
├── ImageUrl
└── CategoryId (FK)

Collections
├── CollectionId (PK)
├── Title
├── Description
└── ImageUrl

Testimonials
├── TestimonialId (PK)
├── CustomerName
├── Comment
└── Rating

Videos
├── VideoId (PK)
├── Url
└── BackgroundImageUrl
```

## 🛠️ Technologies Used

### Backend
- ASP.NET Core 9.0 MVC
- Dapper ORM
- Repository Pattern
- Dependency Injection
- OpenAI API

### Frontend
- Razor Views
- Bootstrap 5.3
- JavaScript (ES6+)
- Swiper.js
- AOS Animation Library

### Database
- Microsoft SQL Server
- LocalDB (Development)

## 📝 API Endpoints

### Products
- `GET /Home/GetProducts` - Get all products
- `POST /Admin/Product/CreateProduct` - Create product
- `PUT /Admin/Product/UpdateProduct/{id}` - Update product
- `DELETE /Admin/Product/DeleteProduct/{id}` - Delete product

### AI Assistant
- `POST /Home/GetOutfitSuggestion` - Get AI outfit suggestion

## 👨‍💻 Author

**Emre Okan Başkaya**
- GitHub: [@emreokanbaskaya1](https://github.com/emreokanbaskaya1)

## 🙏 Acknowledgments

- [Bootstrap](https://getbootstrap.com/) - UI Framework
- [OpenAI](https://openai.com/) - AI Integration
- [Swiper](https://swiperjs.com/) - Slider Library
- [AOS](https://michalsnik.github.io/aos/) - Animation Library
- [Dapper](https://github.com/DapperLib/Dapper) - Micro ORM
