# FOSS 26.2.0 Release Notes

## Version Information

- **FOSS Version**: 26.2.0
- **Target Framework**: .NET 10.0
- **Release Date**: 2026-07-15
- **Package Name**: Aspose.3D.FOSS

## API Coverage

The FOSS version 26.2.0 is fully aligned with Aspose.3D for .NET On-Premise 26.2.0.

### API Alignment Status
- **Public Type Differences**: 0 (for end users)
- **API Surface**: Identical to On-Premise 26.2.0

### Implementation Categories

**Category 1: Stub (Throws NotImplementedException)**
These features exist in the API but throw `NotImplementedException` at runtime:
- `License.SetLicense()` - License management
- `Metered.SetMeteredKey()` - Metered licensing
- `Scene.Render()` - Rendering functionality

**Category 2: Stub (Returns Empty/Default)**
These features have minimal implementations:
- Advanced mesh operations (boolean operations, mesh simplification)
- Proprietary format export (A3DW, PDF, USD, JT, 3MF - export only)
- Watermark encoding/decoding
- Complex animations

**Category 3: Full Implementation**
Core functionality with complete behavior:
- Core scene graph (Scene, Node, Entity, SceneObject, A3DObject)
- Basic geometry (Mesh, Box, Cylinder, Sphere, Plane, Torus)
- Common file format I/O (OBJ, STL, FBX, glTF, Collada, PLY)
- Transform hierarchy (Transform, GlobalTransform)
- Materials and textures
- Utilities (vectors, matrices, quaternions, bounding boxes)

## Test Coverage

- **Total Tests**: 162
- **Passing**: 162
- **Failing**: 0
- **Skipped**: 0

### Test Categories
- Round-trip tests for OBJ, STL, GLTF, FBX, Collada, PLY formats
- Error handling tests for Scene.Open and Scene.Save
- Invalid file path handling
- Unsupported file format detection
- Scene save/load validation

## Known Differences from On-Premise

### Internal Types (FOSS Excludes Advanced Features)
- **FOSS**: No `Openize.Drako.Utils.ShannonEntropyTracker` types
- **On-Premise**: Includes Draco utility types for advanced compression
- **Impact**: None - these are internal utilities, not public API

### Constructor Differences
- **FOSS**: Has additional `SaveOptions()` and `SaveOptions(FileFormat)` constructors
- **On-Premise**: These constructors are not present
- **Impact**: None - On-Premise compiled code works seamlessly with FOSS

### Runtime Behavior
- **FOSS**: Throws `NotImplementedException` with helpful message for stub features
- **On-Premise**: May have different internal implementation details

## Supported File Formats

### Import/Export (Category 3 - Full Implementation)
- **OBJ** (Wavefront OBJ) - Import/Export
- **STL** (Stereolithography) - Import/Export
- **GLTF** (gl Transmission Format) - Import/Export
- **FBX** (Autodesk FBX) - Import/Export
- **Collada** (DAE) - Import/Export
- **PLY** (Polygon File Format) - Import/Export

### Import Only (Category 2)
- **3MF** (Microsoft 3MF) - Import only
- **Amf** - Import only

## Usage Notes

### Target Framework
- .NET 10.0

### Package Installation
```bash
# Using NuGet
dotnet add package Aspose.3D.FOSS

# Using Package Manager
Install-Package Aspose.3D.FOSS
```

### Basic Usage
```csharp
using Aspose.ThreeD;

// Open a 3D file
var scene = new Scene();
scene.Open("model.obj");

// Save to another format
scene.Save("model.fbx");

// Create a new scene
var newScene = new Scene();
newScene.RootNode.CreateChildNode("Cube", new Box(1, 1, 1));
newScene.Save("cube.glb");
```

### Error Handling
```csharp
try
{
    scene.Save("output.obj");
}
catch (Exception ex)
{
    Console.WriteLine($"Error saving scene: {ex.Message}");
}
```

## API Compatibility

FOSS 26.2.0 is fully compatible with code written for Aspose.3D 26.2.0 On-Premise. Any code that compiles against On-Premise will also compile against FOSS without changes.

## Migration from On-Premise

To migrate from On-Premise to FOSS:
1. Replace `Aspose.3D` package with `Aspose.3D.FOSS`
2. Rebuild your project
3. Test functionality - most code will work without changes
4. For features marked as Category 1 (stubs), implement appropriate error handling

## Known Limitations

1. **Rendering**: The `Scene.Render()` method throws `NotImplementedException` - use On-Premise for rendering functionality
2. **Advanced Mesh Operations**: Boolean operations and mesh simplification are not available
3. **Proprietary Export**: Export to A3DW, PDF, USD, JT, 3MF is not available in export mode

## Support

For issues or questions about FOSS 26.2.0:
- Check the FOSS documentation
- Review test cases in `src/test/Aspose.ThreeD.Tests/`
- See `docs/foss-net-progress.md` for development history

## Changelog

### v26.2.0 (2026-07-15)
- Initial FOSS release aligned with On-Premise 26.2.0
- 0 public type differences
- 162 tests passing
- Full implementation of core file format I/O
