dotnet ef database drop -f
dotnet ef migrations remove --no-build
dotnet ef migrations add InitialCreate --prefix-output
dotnet ef database update
dotnet run --project=..\SIL.LCModel.EFCore.Migration\