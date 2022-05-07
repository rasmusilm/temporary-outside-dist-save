@echo off
set timestamp=%DATE:/=-%_%TIME::=-%
set timestamp=%timestamp: =%
dotnet ef migrations add --project App.DAL.EF --startup-project WebApp %timestamp%
dotnet ef database update --project App.DAL.EF --startup-project WebApp