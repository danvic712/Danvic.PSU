# Danvic.PSU
Danvic.PSU is my graduation project of dotnet core version, this is a ASP.NET Core 2.0 MVC project 

## Get Started
- First you need to restore nuget packages to add used packages in this project, also you can build solution to achieve this target.
- Second you need to set sql connection string according to your own configuration, the config info at the appsettings.json file, the config node is SQLConnection which under the ConnectionStrings node.
- Third and last you just need to set the PSU.Site as the startup project and then run it. 

## Using Things
- Project Framework: ASP.NET Core 2.0 MVC
- ORM: Entity Framework Core(using Code-First to create database)
- SQL Engine: MySQL Server 5.7
- Permission Validation: Policy-Based Authorization
- UI Template: AdminLte(a open source ui template based on Bootstrap 3.x, this repository address is https://github.com/almasaeed2010/AdminLTE)
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
  1. PSU.Domain: a class library which achieve interfaces of PSU.IService
  2. PSU.Repository: a class library which contains some functions where using linq to achieve some operate of PSU.Domain
- 04_Rule: business rules layer, contains two system component PSU.IService and PSU.Model
  1. PSU.IService: a class library which definition business rules
  2. PSU.Model: a class library which contains view model of site pages model
- Controller.PSU: controller of mvc
- PSU.Site: a mvc project template(without controller), using areas to distinguish different roles

## Page effect
![login page](https://images2018.cnblogs.com/blog/1310859/201807/1310859-20180722152527671-1937628083.png)
![administrator home page](https://images2018.cnblogs.com/blog/1310859/201807/1310859-20180722151554922-1069570383.png)
![student home page](https://images2018.cnblogs.com/blog/1310859/201807/1310859-20180722152608486-1544802079.png)

