dotnet ef database drop -f
#dotnet ef migrations remove
#dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet run --project=..\transform\