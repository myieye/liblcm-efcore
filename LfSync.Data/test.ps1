dotnet ef database drop -f
rm Migrations -r -force
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet run --project=..\transform\