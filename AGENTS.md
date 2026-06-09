# Aspose.3D FOSS Implementation - AI Agent Guide

## Project Overview

This is a FOSS (Free and Open Source) implementation of Aspose.3D for .NET 26.1.0.

## Implementation Strategy

### API Classification

**Category 1: Not Implemented (Throw Exception)**
- License-related APIs (License class, SetLicense, licensing modes)
- Trial-related APIs (TrialException, trial limitations)
- Metered APIs (Metered class, SetMeteredKey)

**Category 2: Stub Implementations**
- Rendering (Scene.Render, ImageRenderOptions)
- Advanced mesh operations (boolean operations, mesh simplification)
- Proprietary formats (A3DW, PDF, USD, JT, 3MF)
- Complex animations

**Category 3: Full Implementation**
- Core scene graph (Scene, Node, Entity)
- Basic geometry (Mesh, Box, Cylinder, Sphere)
- Common file formats (OBJ, STL, FBX, glTF, Collada, PLY)
- Transform hierarchy
- Materials and textures

## Implementation Status

### Fully Implemented
- Collada format reader (ColladaReader - complete)
- Group entity class (Group)
- Core scene graph (Scene, Node, Entity, SceneObject, A3DObject)
- Basic transforms (Transform, GlobalTransform)
- All Utilities namespace classes:
  - Vectors (FVector2, FVector3, FVector4, Vector2, Vector3, Vector4)
  - Matrices (FMatrix4, Matrix4)
  - Quaternions and rotations (Quaternion, RotationOrder, ComposeOrder)
  - Bounding boxes (BoundingBox, BoundingBox2D, BoundingBoxExtent)
  - Rectangles (Rect, RelativeRectangle)
  - Transform builders (TransformBuilder)
  - Vertex data (Vertex, VertexField, VertexDeclaration, VertexFieldDataType, VertexFieldSemantic)
  - Math utilities (MathUtils)
  - IO utilities (IOExtension, FileSystem)
  - Attributes (SemanticAttribute)
  - Exceptions (ParseException)
- Node hierarchy management (CreateChildNode, AddChildNode, Merge, etc.)
- Properties system (Property, PropertyCollection, PropertyFlags)
- Materials (Material base class in Shading namespace)
- File format detection and format definitions (FileFormat, FileFormatType, FileContentType)
- Format options (LoadOptions, SaveOptions base classes, OBJ/STL/GLTF/FBX specific options)
- Asset information (AssetInfo)
- Custom objects (CustomObject)
- Exceptions (ImportException, ExportException, TrialException)
- License and Metered classes (throw NotImplementedException as per FOSS policy)
- Camera entity stub
- Geometry base class with vertex elements
- Vertex elements (VertexElement, VertexElementUV, VertexElementVector, VertexElementVertexColor, VertexElementMaterial)
- Enums (VertexElementType, MappingMode, ReferenceMode, TextureMapping)
- Mesh class with polygon and vertex data support
- Primitive geometry classes (Box, Sphere, Cylinder)
- OBJ format reader and writer (ObjReader, ObjWriter)
- STL format reader and writer (StlReader, StlWriter)
- glTF format reader and writer (GltfReader, GltfWriter)
- FBX binary format reader/writer (FbxReader, FbxWriter - complete)
- Scene.Open() method for OBJ/STL/gltF/FBX/Collada/PLY format loading
- Scene.Save() method for OBJ/STL/gltF/PLY format saving
- Vertex element parsing (normals, UVs, colors)

### Stub Implementations
| API | Status | Notes |
|-----|--------|-------|
| Scene.Render() | Stub (throws exception) | Rendering not implemented in FOSS version |
| Scene.Save() for FBX | Stub (throws exception) | FBX export (FbxWriter) |
| Geometry.GetDeformers() | Stub (throws exception) | Not yet implemented |
| Watermark encoding/decoding | Stub (throws exception) | Watermark functionality not implemented in FOSS version |

### Recent Fixes (Binary FBX Importer)
Fixed binary FBX importer to correctly parse FBX files:

**Issues Fixed:**
1. **Compression Method**: Changed from `GZipStream` (RFC1952) to `DeflateStream` (RFC1950/zlib) with proper header skipping
2. **Array Token Parsing**: Changed from `verticesElement.Compound.GetFirstElement("a")` to using `verticesElement.Tokens` directly for binary format

**Technical Details:**
- FBX binary format uses zlib compression (encoding=1) with `78 01` or `78 9c` header
- Array data in binary FBX is stored directly in element tokens, not in nested "a" elements
- Properly reads end_offset, prop_count, prop_length for all nested scopes
- Handles both 32-bit (version < 7500) and 64-bit (version >= 7500) FBX formats

**Test Results:**
- All 62 tests pass (including 2 new binary FBX tests)
- Verified with FBX 7300 and 7500 binary files with normals and UVs

### Not Implemented (Throws Exception)
| API | Reason |
|-----|--------|
| License.SetLicense() | License validation not applicable |
| Metered.SetMeteredKey() | Trial/metering not applicable |
| Scene.Render() | Rendering requires proprietary algorithms |

### Recent Changes (IOService Merge)
Merged two IOService classes into one internal `Aspose.ThreeD.Formats.IOService` class:

**Changes:**
1. Created internal `Aspose.ThreeD.Formats.IOService` class
2. Made `IOService` internal to hide implementation details
3. Added `FileFormat.Detect(Stream, string)` method to match On-Premise API
4. Updated `ColladaFormat` extension from ".dae" to "dae" for consistency
5. Updated all format extensions to include dot prefix (".obj", ".stl", etc.)

**Status:**
- Format detection (`FileFormat.Detect`) - fully implemented
- Importer/Exporter creation (`IOService.CreateImporter/Exporter`) - stubs (throws `NotImplementedException`)

## Test Coverage

Tests have been implemented:
- SceneTests.cs - Tests for Scene class initialization and basic operations
- FileIOTests.cs - Tests for OBJ, STL, GLTF, FBX, PLY file I/O and primitive geometry
- FormatDetectionTests.cs - Tests for format detection

All 62 tests pass (including 2 new binary FBX tests).

## Test Data

Sample files are located in `testdata/`:
### ASCII FBX Tests
- `testdata/fbx7400ascii/cube.fbx` - ASCII FBX with normals and UVs
- `testdata/fbx7400ascii/fuel_tank6.fbx` - Complex ASCII FBX

### Binary FBX Tests  
- `testdata/fbx7300binary/camera.fbx` - FBX 7300 binary
- `testdata/fbx7300binary/fuel_tank6.fbx` - FBX 7300 binary with normals and UVs
- `testdata/fbx7500binary/camera.fbx` - FBX 7500 binary (64-bit)
- `testdata/fbx7500binary/fuel_tank6.fbx` - FBX 7500 binary with normals and UVs

### Other Formats
- `testdata/input/cube.obj` - Basic cube mesh
- `testdata/stl/stl_ascii.stl`, `testdata/stl/stl_binary.stl` - STL files
- GLTF test files in `testdata/gltf/`

## Development Commands

### Analyze Aspose.3D API
```bash
.opencode/skills/foss-agent/scripts/dump-csharp --package Aspose.3D:26.1.0 --namespace Aspose.ThreeD
.opencode/skills/foss-agent/scripts/dump-csharp --package Aspose.3D:26.1.0 --class Aspose.ThreeD.Scene
```

### Build and Test
```bash
cd src/main/Aspose.ThreeD
dotnet build
dotnet test
```

## Notes

- Always follow the skill foss-agent, if you don't know what it is, read it before doing anything.
- It's absolute not allowed to add new public class/members that are not existed in the result of `dump-csharp`
- Always verify API signatures with `dump-csharp` before implementing
- Tests must use test files from `testdata/` directory, absolute path is not allowed to use.
- Stub implementations should be minimal but compilable
- Document all deviations from Aspose.3D's behavior in this file
