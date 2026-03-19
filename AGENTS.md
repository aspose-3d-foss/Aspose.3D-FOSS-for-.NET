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

### Stub Implementations
| API | Status | Notes |
|-----|--------|-------|
| Scene.Render() | Stub (throws exception) | Rendering not implemented in FOSS version |
| Scene.Open() for FBX | Partial (binary parsing complete, scene graph needs work) | FBX importer structure exists but needs complete scene graph parsing |
| Scene.Save() for FBX | Stub (throws exception) | FBX export (FbxWriter) |
| Geometry.GetDeformers() | Stub (throws exception) | Not yet implemented |
| Watermark encoding/decoding | Stub (throws exception) | Watermark functionality not implemented in FOSS version |

### Not Implemented (Throws Exception)
| API | Reason |
|-----|--------|
| License.SetLicense() | License validation not applicable |
| Metered.SetMeteredKey() | Trial/metering not applicable |
| Scene.Render() | Rendering requires proprietary algorithms |

## Test Coverage

Tests have been implemented:
- SceneTests.cs - Tests for Scene class initialization and basic operations
- FileIOTests.cs - Tests for OBJ and STL file I/O and primitive geometry
- FormatDetectionTests.cs - Tests for format detection

All 35 tests are passing.

## Test Data

Sample files are located in `testdata/input/`:
- `cube.obj` - Basic cube mesh
- `stl_ascii.stl`, `stl_binary.stl` - STL files for testing
- `cube.fbx` - FBX file for testing
- GLTF test files in `testdata/gltf/`

Expected outputs in `testdata/expected/`:
- Will be populated as tests are added

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

- Always verify API signatures with `dump-csharp` before implementing
- Tests must use test files from `testdata/` directory, absolute path is not allowed to use.
- Stub implementations should be minimal but compilable
- Document all deviations from Aspose.3D's behavior in this file
