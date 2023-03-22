# LibLCM EFCore

Created as a proof-of-concept for storing [LibLCM](https://github.com/sillsdev/liblcm) in a relational database.

It can now be used to migrate virtually an entire LibLCM project into Postgres using EF-Core.

### SIL.LCModel.EFCore.Generator

Generates most of the EF-Core model and model configuration using a C# [Source Generator](https://learn.microsoft.com/en-us/dotnet/csharp/roslyn-sdk/source-generators-overview).

### SIL.LCModel.EFCore

The basis of the EF-Core model including types that don't exist in the [MasterLCModel.xml](https://github.com/sillsdev/liblcm/blob/ffac9f07318e74ba64adaab5f79668304eb5dab7/src/SIL.LCModel/MasterLCModel.xml) file (used by the generator).

### SIL.LCModel.EFCore.Migration

Where the migration actually happens.
