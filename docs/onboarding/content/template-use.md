- [Template Installation And Use](#template-installation-and-use)
  - [From Nuget](#from-nuget)
  - [From Local Repository](#from-local-repository)
  - [Using The Template](#using-the-template)

---

# Template Installation And Use

## From Nuget

// TODO

## From Local Repository

1. Clone or download repository.
1. Install from local folder.
1. At root level `basic-ntier-template` run:

   ```powershell
   # basic-ntier-template\.
   dotnet new install .
   ```

   Or:

   ```powershell
   # basic-ntier-template\.
   dotnet new uninstall .
   ```

1. Use the template from anywhere:

```powershell
dotnet new basic-ntier-template -o "NetCoreContosoUniversityAppExample"
```

## Using The Template

```powershell
# Custom solution name (and path, if included in the string)
dotnet new basic-ntier-template -o "../../MyFolder/NetCoreContosoUniversityAppExample2"
```

```powershell
# Force file generation, and override existing files if any
dotnet new basic-ntier-template -o  "NetCoreContosoUniversityAppExample3" --force
```
