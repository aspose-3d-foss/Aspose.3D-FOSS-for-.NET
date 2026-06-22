# Aspose.3D FOSS Implementation - AI Agent Guide

## Project Overview

This is a FOSS (Free and Open Source) implementation of Aspose.3D for .NET 26.2.0.

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
| Watermark encoding/decoding | Stub (throws exception) | Watermark functionality not implemented in FOSS version |

### Proprietary Format Stubs (Added 2026-06-10)
Added stub implementations for proprietary format classes:

1. **PdfFormat** - Adobe's PDF format with extract methods
2. **PlyFormat** - PLY point cloud format with encode/decode methods
3. **Microsoft3MFFormat** - Microsoft 3MF format with buildable/transform methods
4. **DracoFormat** - Google Draco compression format
5. **RvmFormat** - AVEVA RVM format for plant design data
6. **DracoSaveOptions** - Draco compression options with quantization bits
7. **DracoCompressionLevel** - Compression level enum (NoCompression, Fast, Standard, Optimal)
8. **PdfLoadOptions** - PDF loading options with password support
9. **PdfSaveOptions** - PDF export options with render modes and lighting schemes
10. **PdfRenderMode** - PDF render mode enum (Solid, Wireframe, Transparent, etc.)
11. **PdfLightingScheme** - PDF lighting scheme enum (Artwork, Day, Night, etc.)

All format stubs throw `NotImplementedException` at runtime as per FOSS policy.

### API Signature Updates (Added 2026-06-11)
Updated FOSS implementation to match On-Premise 26.2.0 API signatures:

**Changes Made:**
1. **A3DObject.Name**: Changed from read-only `{get;}` to read-write `{get; set;}` 
2. **DynamicProperty**: Made internal class (was public, removed from On-Premise API)
3. **SceneObject**: Changed inheritance from `INamedObject` to `A3DObject`
4. **BooleanOperand**: Changed from enum to class with static `Of()` factory methods
5. **BooleanOperator**: Changed from enum to class with constructors and properties
6. **AnimationChannel**: Removed constructors, added `KeyframeSequence`, `ComponentType` properties
7. **Light**: Changed inheritance from `Entity` to `Frustum`, removed `Direction`, `Target`, `GetBoundingBox()`, `GetEntityRendererKey()`
8. **Geometry**: Changed `ControlPoints` to return `IList<Vector4>`, changed `GetDeformers()` to return `ICollection<Deformer>`, made constructor `public`
9. **KeyFrame**: Updated constructor signature, changed `Time` from `float` to `double`, `Value` from `Vector4` to `float`
10. **KeyframeSequence**: Changed inheritance from `object` to `A3DObject`
11. **StepMode/WeightedMode**: Renamed enum values to PascalCase
12. **Deformer**: Changed constructor from `protected` to `public`

### Binary FBX Importer Fixes (Added 2026-06-10)
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
- All 63 tests pass (including 2 new binary FBX tests)
- Verified with FBX 7300 and 7500 binary files with normals and UVs

### API Changes Summary (2026-06-11)
The FOSS implementation now matches On-Premise 26.2.0 API surface for all public types that exist in both versions. Remaining missing types are mostly:
- **Rendering types** (~60 types) - EntityRenderer, IPipeline, IRenderQueue, etc.
- **Proprietary format options** (~15 types) - A3dwSaveOptions, UsdSaveOptions, etc.
- **CAD/profile types** (~20 types) - CircleShape, RectangleShape, Text, etc.

These are all features that remain stubs or unimplemented per FOSS policy.

### ArrayList<T> Interface Fix (Added 2026-06-12)

Fixed ArrayList<T> implementation to avoid IList ambiguity:

**Changes:**
1. **ArrayList<T>**: Simplified implementation to avoid `IList` interface conflicts
   - Changed `IArrayList<T>` to only extend `IList<T>` instead of `IList<T> + IList`
   - Added explicit `IEnumerable.GetEnumerator()` implementation
   - Removed explicit `IList` interface implementations

2. **VertexElement subclasses**: Removed `readonly` from internal data fields
   - Changed `private readonly ArrayList<T> field = new ArrayList<T>()` to `private ArrayList<T> field`
   - Initialize in constructor instead of field initializer

3. **Geometry/Mesh**: Fixed field initialization
   - Changed from `ArrayList<T> field = new ArrayList<T>()` with `List<T>` assignment
   - To `ArrayList<T> field` with `ArrayList<T>` assignment in constructor

4. **IIndexedVertexElement**: Created interface with only `Indices` property
   - No `SetIndices` method (as per On-Premise API)
   - Fixed `FbxReader.cs` to cast to `VertexElement` for `SetIndices` calls

**Test Results:**
- Build: 0 errors, 0 warnings
- Tests: 63/63 passing

### Not Implemented (Throws Exception)
| API | Reason |
|-----|--------|
| License.SetLicense() | License validation not applicable |
| Metered.SetMeteredKey() | Trial/metering not applicable || Scene.Render() | Stub (throws) | Rendering requires proprietary algorithms |

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

### ArrayList<T> Interface Fix (Added 2026-06-12)

Fixed ArrayList<T> implementation to avoid IList ambiguity:

**Changes:**
1. **ArrayList<T>**: Simplified implementation to avoid `IList` interface conflicts
   - Changed `IArrayList<T>` to only extend `IList<T>` instead of `IList<T> + IList`
   - Added explicit `IEnumerable.GetEnumerator()` implementation
   - Removed explicit `IList` interface implementations

2. **VertexElement subclasses**: Removed `readonly` from internal data fields
   - Changed `private readonly ArrayList<T> field = new ArrayList<T>()` to `private ArrayList<T> field`
   - Initialize in constructor instead of field initializer

3. **Geometry/Mesh**: Fixed field initialization
   - Changed from `ArrayList<T> field = new ArrayList<T>()` with `List<T>` assignment
   - To `ArrayList<T> field` with `ArrayList<T>` assignment in constructor

4. **IIndexedVertexElement**: Created interface with only `Indices` property
   - No `SetIndices` method (as per On-Premise API)
   - Fixed `FbxReader.cs` to cast to `VertexElement` for `SetIndices` calls

**Test Results:**
- Build: 0 errors, 0 warnings
- Tests: 63/63 passing

## Test Coverage

Tests have been implemented:
- SceneTests.cs - Tests for Scene class initialization and basic operations
- FileIOTests.cs - Tests for OBJ, STL, GLTF, FBX, PLY file I/O and primitive geometry
- FormatDetectionTests.cs - Tests for format detection

All 63 tests pass.

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


### Build and Test
```bash
cd src/main/Aspose.ThreeD
dotnet build
dotnet test
```

## Notes

- Always follow the skill foss-agent, if you don't know what it is, read it before doing anything.
- Tests must use test files from `testdata/` directory, absolute path is not allowed to use.
- Stub implementations should be minimal but compilable
- Document all deviations from Aspose.3D's behavior in this file
