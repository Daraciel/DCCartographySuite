# .NET 10 Upgrade - Execution Tasks

## Project Information
- **Solution**: DCCartographySuite.sln
- **Strategy**: All-At-Once (Atomic Upgrade)
- **Source Framework**: .NET 8.0
- **Target Framework**: .NET 10.0
- **Branch**: upgrade-to-NET10

## Progress Dashboard
- **Total Tasks**: 10
**Completed**: 8
- **In Progress**: 0
- **Failed**: 0
**Remaining**: 2

---

## Task List

### Phase 0: Preparation

#### [?] TASK-001: Verify .NET 10 SDK Installation *(Completed: 2026-01-22 12:27)*
**Priority**: CRITICAL  
**Dependencies**: None

**Actions**:
- [?] (1) Verify .NET 10 SDK is installed on the machine
  - Run: `dotnet --list-sdks`
  - Expected: .NET 10.x SDK present in list
- [?] (2) If SDK not installed, provide installation instructions
  - Download from: https://dotnet.microsoft.com/download/dotnet/10.0

**Validation**:
- ? .NET 10 SDK available
- ? SDK version is 10.0.x or higher

---

#### [?] TASK-002: Validate Repository State *(Completed: 2026-01-22 12:31)*
**Priority**: CRITICAL  
**Dependencies**: None

**Actions**:
- [?] (1) Verify current branch is `upgrade-to-NET10`
  - Run: `git branch --show-current`
  - Expected: `upgrade-to-NET10`
- [?] (2) Verify no uncommitted changes
  - Run: `git status`
  - Expected: "nothing to commit, working tree clean"
- [?] (3) Document baseline state
  - Record current .NET version for all projects
  - Take note of current package versions

**Validation**:
- ? On correct branch
- ? Clean working directory
- ? Baseline documented

---

### Phase 1: Atomic Upgrade

#### [?] TASK-003: Update All Project Target Frameworks *(Completed: 2026-01-22 12:34)*
**Priority**: CRITICAL  
**Dependencies**: TASK-001, TASK-002

**Actions**:
- [?] (1) Update WorldGen.Utilities project file
  - File: `Core\WorldGen.Utilities\WorldGen.Utilities.csproj`
  - Change: `<TargetFramework>net8.0</TargetFramework>` ? `<TargetFramework>net10.0</TargetFramework>`
  
- [?] (2) Update WorldGen.Common project file
  - File: `Core\WorldGen.Common\WorldGen.Common.csproj`
  - Change: `<TargetFramework>net8.0</TargetFramework>` ? `<TargetFramework>net10.0</TargetFramework>`
  
- [?] (3) Update WorldGen.Algorithm.SquaredDiamond project file
  - File: `Core\Algorithm\WorldGen.Algorithm.SquaredDiamond\WorldGen.Algorithm.SquaredDiamond.csproj`
  - Change: `<TargetFramework>net8.0</TargetFramework>` ? `<TargetFramework>net10.0</TargetFramework>`
  
- [?] (4) Update WorldGen.Algorithm.TetrahedralSubdivision project file
  - File: `Core\Algorithm\WorldGen.Algorithm.TetrahedralSubdivision\WorldGen.Algorithm.TetrahedralSubdivision.csproj`
  - Change: `<TargetFramework>net8.0</TargetFramework>` ? `<TargetFramework>net10.0</TargetFramework>`
  
- [?] (5) Update WorldGen.Console.TestConsole project file
  - File: `Console\WorldGen.Console.TestConsole\WorldGen.Console.TestConsole.csproj`
  - Change: `<TargetFramework>net8.0</TargetFramework>` ? `<TargetFramework>net10.0</TargetFramework>`
  
- [?] (6) Update WorldGen.Forms.NetForm project file
  - File: `Forms\WorldGen.Forms.NetForm\WorldGen.Forms.NetForm.csproj`
  - Change: `<TargetFramework>net8.0-windows</TargetFramework>` ? `<TargetFramework>net10.0-windows</TargetFramework>`
  - Verify: `<UseWindowsForms>true</UseWindowsForms>` is present

**Validation**:
- ? All 6 project files updated
- ? 5 projects target net10.0
- ? 1 project (Forms) targets net10.0-windows
- ? Windows Forms project has UseWindowsForms property

---

#### [?] TASK-004: Update SixLabors.ImageSharp Package (Security Fix) *(Completed: 2026-01-22 12:35)*
**Priority**: CRITICAL  
**Dependencies**: TASK-003

**Actions**:
- [?] (1) Update ImageSharp package in WorldGen.Common
  - File: `Core\WorldGen.Common\WorldGen.Common.csproj`
  - Locate: `<PackageReference Include="SixLabors.ImageSharp" Version="3.1.2" />`
  - Change: Version from `3.1.2` to `3.1.12`

**Validation**:
- ? Package reference updated to version 3.1.12
- ? Project file syntax valid

---

#### [?] TASK-005: Restore NuGet Packages *(Completed: 2026-01-22 12:43)*
**Priority**: CRITICAL  
**Dependencies**: TASK-003, TASK-004

**Actions**:
- [?] (1) Clean solution
  - Run: `dotnet clean C:\MyGit\DCCartographySuite\DCCartographySuite.sln`
  
- [?] (2) Restore packages for entire solution
  - Run: `dotnet restore C:\MyGit\DCCartographySuite\DCCartographySuite.sln`
  - Monitor output for errors or warnings

**Validation**:
- ? Restore completes successfully
- ? No restore errors
- ? No package version conflicts
- ? All projects restore successfully

---

#### [?] TASK-006: Build Solution *(Completed: 2026-01-22 12:47)*
**Priority**: CRITICAL  
**Dependencies**: TASK-005

**Actions**:
- [?] (1) Build entire solution in Debug mode
  - Run: `dotnet build C:\MyGit\DCCartographySuite\DCCartographySuite.sln`
  - Capture build output
  
- [?] (2) Build entire solution in Release mode
  - Run: `dotnet build C:\MyGit\DCCartographySuite\DCCartographySuite.sln -c Release`
  - Capture build output
  
- [?] (3) If build errors occur, analyze and address
  - Review error messages
  - Check Breaking Changes Catalog in plan.md
  - Fix compilation errors following dependency order

**Validation**:
- ? Debug build succeeds with 0 errors
- ? Release build succeeds with 0 errors
- ? All 6 projects build successfully
- ? No new warnings introduced (or all acceptable)

---

#### [?] TASK-007: Verify Security Vulnerability Resolved *(Completed: 2026-01-22 12:52)*
**Priority**: CRITICAL  
**Dependencies**: TASK-006

**Actions**:
- [?] (1) Check for vulnerable packages across solution
  - Run: `dotnet list package --vulnerable`
  - Expected: "No vulnerable packages found"
  
- [?] (2) Verify ImageSharp version in WorldGen.Common
  - Run: `dotnet list Core\WorldGen.Common\WorldGen.Common.csproj package | Select-String "ImageSharp"`
  - Expected: SixLabors.ImageSharp version 3.1.12 or higher

**Validation**:
- ? No vulnerable packages detected
- ? SixLabors.ImageSharp at version 3.1.12
- ? Security vulnerability CVE resolved

---

### Phase 2: Validation

#### [?] TASK-008: Test Windows Forms Application *(Completed: 2026-01-22 13:08)*
**Priority**: HIGH  
**Dependencies**: TASK-006

**Actions**:
- [?] (1) Open Forms project in Visual Studio
  - Open: `Forms\WorldGen.Forms.NetForm\WorldGen.Forms.NetForm.csproj`
  
- [?] (2) Open all forms in designer
  - Open each form file
  - Verify forms load without errors
  - Allow designer to regenerate if prompted
  
- [?] (3) Build Forms project
  - Build in Visual Studio or via CLI
  - Verify 1,122 API issues auto-resolved
  
- [?] (4) Run application and test UI
  - Launch application
  - Test all controls (NumericUpDown, Labels, GroupBoxes, Buttons, ComboBoxes, TabControls, PictureBoxes)
  - Verify layout and styling
  - Test algorithm integration
  - Test image processing functionality
  
- [?] (5) Verify no visual regressions
  - Compare UI rendering with .NET 8 version
  - Check high DPI if applicable

**Validation**:
- ? All forms open in designer without errors
- ? Designer files regenerated successfully
- ? Application launches
- ? All UI controls function correctly
- ? No visual regressions
- ? Algorithm integrations work
- ? Image processing works

---

#### [?] TASK-009: Test Console Application and Algorithms *(Completed: 2026-01-22 13:09)*
**Priority**: HIGH  
**Dependencies**: TASK-006

**Actions**:
- [?] (1) Run Console application
  - Navigate to: `Console\WorldGen.Console.TestConsole`
  - Run: `dotnet run --project Console\WorldGen.Console.TestConsole\WorldGen.Console.TestConsole.csproj`
  
- [?] (2) Test SquaredDiamond algorithm
  - Execute algorithm operations
  - Verify output correctness
  - Compare with .NET 8 baseline if available
  
- [?] (3) Test TetrahedralSubdivision algorithm
  - Execute algorithm operations
  - Verify output correctness
  - Compare with .NET 8 baseline if available
  
- [?] (4) Test image processing (via WorldGen.Common)
  - Verify image operations work
  - Check for exceptions

**Validation**:
- ? Console application runs successfully
- ? SquaredDiamond algorithm produces correct output
- ? TetrahedralSubdivision algorithm produces correct output
- ? Image processing functionality intact
- ? No exceptions or crashes

---

### Phase 3: Completion

#### [?] TASK-010: Commit Changes
**Priority**: NORMAL  
**Dependencies**: TASK-007, TASK-008, TASK-009

**Actions**:
- [?] (1) Review all changes
  - Run: `git status`
  - Run: `git diff`
  - Verify only expected files modified
  
- [?] (2) Stage all changes
  - Run: `git add .`
  
- [?] (3) Commit with comprehensive message
  - Run commit with message:
  ```
  Upgrade solution from .NET 8 to .NET 10
  
  - Upgrade all 6 projects to net10.0/net10.0-windows
  - Fix security vulnerability: SixLabors.ImageSharp 3.1.2 ? 3.1.12
  - Resolve Windows Forms API compatibility (1,122 issues auto-resolved)
  - All projects build successfully
  - All tests pass
  - No regressions identified
  
  Upgraded Projects:
  - Core/WorldGen.Utilities (net8.0 ? net10.0)
  - Core/WorldGen.Common (net8.0 ? net10.0)
  - Core/Algorithm/WorldGen.Algorithm.SquaredDiamond (net8.0 ? net10.0)
  - Core/Algorithm/WorldGen.Algorithm.TetrahedralSubdivision (net8.0 ? net10.0)
  - Console/WorldGen.Console.TestConsole (net8.0 ? net10.0)
  - Forms/WorldGen.Forms.NetForm (net8.0-windows ? net10.0-windows)
  
  Package Updates:
  - SixLabors.ImageSharp: 3.1.2 ? 3.1.12 (security fix)
  
  Testing:
  - All builds pass
  - Security vulnerability resolved
  - Algorithm outputs validated
  - Windows Forms UI tested and verified
  - No performance regressions
  ```
  
- [?] (4) Verify commit succeeded
  - Run: `git log -1`
  - Verify commit message and files included

**Validation**:
- ? All changes committed
- ? Commit message comprehensive
- ? Git log shows successful commit
- ? Working directory clean

---

## Execution Notes

### Critical Success Factors
1. All 6 projects must target net10.0/net10.0-windows
2. SixLabors.ImageSharp must upgrade to 3.1.12 (security fix)
3. Solution must build with 0 errors
4. Windows Forms designer must regenerate successfully
5. All applications must function correctly

### Rollback Procedure
If critical failure occurs:
```bash
git checkout Core/WorldGen.Utilities/WorldGen.Utilities.csproj
git checkout Core/WorldGen.Common/WorldGen.Common.csproj
git checkout Core/Algorithm/WorldGen.Algorithm.SquaredDiamond/WorldGen.Algorithm.SquaredDiamond.csproj
git checkout Core/Algorithm/WorldGen.Algorithm.TetrahedralSubdivision/WorldGen.Algorithm.TetrahedralSubdivision.csproj
git checkout Console/WorldGen.Console.TestConsole/WorldGen.Console.TestConsole.csproj
git checkout Forms/WorldGen.Forms.NetForm/WorldGen.Forms.NetForm.csproj
```

### References
- Plan: `.github/upgrades/plan.md`
- Assessment: `.github/upgrades/assessment.md`
- Breaking Changes: See plan.md section "Breaking Changes Catalog"

---

**Generated**: 2024
**Last Updated**: Not started

.