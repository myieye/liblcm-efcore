dotnet ef database drop -f
dotnet ef database update --no-build
dotnet run --project=..\SIL.LCModel.EFCore.Migration\