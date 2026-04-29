# Copilot instructions for InventarioISP20

## Build, test, and lint commands

This repository currently contains a single WinForms project (`Desktop/Desktop.csproj`) referenced by `InventarioISP20.slnx`.

```powershell
# Restore dependencies
dotnet restore .\InventarioISP20.slnx

# Build
dotnet build .\InventarioISP20.slnx -c Debug

# Run desktop app
dotnet run --project .\Desktop\Desktop.csproj
```

There is no test project in this repository yet (no `*Test*`/`*Tests*` `.csproj`), so there is no project-specific full-suite or single-test command currently.

There is also no repository-specific lint command/configuration checked in (no `.editorconfig`, ruleset, or analyzer config in source files).

## High-level architecture

- Single .NET 8 Windows Forms application (`net8.0-windows`) in the `Desktop` project.
- Startup flow is `Program.Main()` -> `ApplicationConfiguration.Initialize()` -> `Application.Run(new MenuPrincipalView())`.
- UI is form-centric: forms live under `Desktop/Views` and act as the current presentation layer.
- Each form is split into partial files:
  - `*.Designer.cs`: control tree, layout, and event wiring
  - `*.cs`: behavior/event handlers
  - `*.resx`: form resources
- Main menu UI uses `FontAwesome.Sharp` controls (`IconButton`, `IconMenuItem`) for icon-based actions.

## Key conventions in this codebase

- Keep form logic in the code-behind partial (`*.cs`) and keep generated control/layout code in `*.Designer.cs`; avoid manual edits to designer-managed sections.
- Event handlers are wired in designer code (for example, `Click += ...`) and implemented in the matching view code-behind file.
- Current naming uses Spanish domain/UI labels (`Articulos`, `Categorias`, `Prestamos`, `Ubicaciones`, `Salir del sistema`); follow that vocabulary for new UI-facing elements.
- Namespace usage is mostly `Desktop`; one form currently uses `Desktop.Views` (`UbicacionesView`). Match the surrounding file’s namespace when editing existing forms unless doing an intentional namespace normalization refactor.

## Mandatory instructions
- Siempre hablar en español.