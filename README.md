# Danvic.PSU
Danvic.PSU is my graduation project of dotnet core version, this is a ASP.NET Core 2.0 MVC project 

## Using Things
- Project Framework: ASP.NET Core 2.0 MVC
- ORM: Entity Framework Core(using Code-First to create database)
- SQL Engine: MySQL Server 5.7
- Permission Validation: Policy-Based Authorization
- UI Template: AdminLte(a opern source ui template based on Bootstrap 3.x, this repository address is https://github.com/almasaeed2010/AdminLTE)
- Tables Control: Jquery Datatables
- Data Visualization Control: ECharts
- Log: NLog

## Layer Introduction
- 01_Entity: database entity layer, contains a system component of PSU.Entity
  1. PSU.Entity: a class library which used to store the C# object entity corresponding to the table in the database
- 02_Infrastructure: basic structural layer, contains two system component PSU.EFCore and PSU.Utility
  1. PSU.EFCore: a class library which add EF Core to operate database 
  2. PSU.Utility: a class library which contains some useful code helper class like json convert helper, html convert helper etc.
- 03_Logic: business logic layer, contains two system component PSU.Domain and PSU.Repository
  1. PSU.Domain:
  2. PSU.Repository:
- 04_Rule: business rules layer, contains two system component PSU.IService and PSU.Model
  1. PSU.IService:
  2. PSU.Model:
- Controller.PSU: controller of mvc
- PSU.Site: a mvc project template(without controller)

