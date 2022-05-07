@echo off
cd App.DAL.EF\Migrations 
DEL /F/Q/S *.* > NUL
cd..
RMDIR /Q/S Migrations 
cd ..
dotnet ef database drop --project App.DAL.EF --startup-project WebApp
dotnet ef migrations add --project App.DAL.EF --startup-project WebApp InitialCreation
dotnet ef database update --project App.DAL.EF --startup-project WebApp