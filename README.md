# Aspose.3D for .NET - FOSS Implementation

A Free and Open Source implementation of Aspose.3D for .NET 26.1.0.

## About

This project provides an open-source alternative to the commercial Aspose.3D library, maintaining API compatibility for common 3D operations.

## Status

**This is a work-in-progress FOSS implementation.**

Currently implementing core functionality:
- Scene graph management
- Basic geometry primitives
- Common file format support (OBJ, STL, FBX, glTF)

## Limitations

Some advanced features are not available in this FOSS version:
- License/trial management APIs (throws NotImplementedException)
- Rendering functionality
- Advanced mesh operations
- Proprietary formats (A3DW, PDF, USD, JT)

For full functionality, consider using [Aspose.3D's commercial On-Premise API](https://products.aspose.com/3d/net/).

## Installation

```bash
dotnet add package Aspose.3D.FOSS
```

## Quick Start

```csharp
using Aspose.ThreeD;

// Create a new scene
var scene = new Scene();

// Save to OBJ format
scene.Save("output.obj");
```

## Documentation

See [AGENTS.md](AGENTS.md) for implementation status and development guidelines.

## License

MIT License

## Links

- [Commercial Aspose.3D](https://products.aspose.com/3d/net/)
- [Documentation](https://docs.aspose.com/3d/net/)
- [GitHub Issues](https://github.com/aspose-3d/Aspose.3D-for-.NET/issues)
