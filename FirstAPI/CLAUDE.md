# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

This is a .NET 8 Web API project designed to run on AWS Lambda. It provides a REST API for managing books with CRUD operations.

## Common Commands

- **Run locally**: `dotnet run`
- **Build**: `dotnet build`
- **Publish for Lambda**: `dotnet publish -c Release`
- **Run EF migrations**: `dotnet ef migrations list` / `dotnet ef migrations add <name>` / `dotnet ef database update`

## Architecture

- **Framework**: ASP.NET Core 8 with AWS Lambda hosting (`Amazon.Lambda.AspNetCoreServer`)
- **Database**: Entity Framework Core with SQL Server
- **API Documentation**: Swagger/OpenAPI (available at `/swagger` in development)
- **Endpoints**: RESTful at `api/books`

## Key Files

- `Program.cs`: Application entry point, configures EF, Swagger, and Lambda hosting
- `Data/FirstAPIContext.cs`: EF DbContext for the Books table
- `Controllers/BooksController.cs`: REST controller with GET, POST, PUT, DELETE actions
- `Models/Book.cs`: Entity model with Id, Title, Author, YearPublished

## Database

Connection string is configured in `appsettings.json` under `ConnectionStrings:DefaultConnection`. Migrations are in the `Migrations/` folder.