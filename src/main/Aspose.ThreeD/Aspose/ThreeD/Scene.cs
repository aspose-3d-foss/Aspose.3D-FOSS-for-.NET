using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Aspose.ThreeD.Utilities;
using Aspose.ThreeD.Formats;

namespace Aspose.ThreeD
{
    /// <summary>
    /// A scene is a top-level object that contains the nodes, geometries, materials, textures, animation, poses, sub-scenes and etc.
    /// Scene can have sub-scenes, acts as multiple-document support in files like collada/blender/fbx
    /// Node hierarchy can be accessed through  is used to keep a reference of unattached objects during serialization(like meta data or custom objects) so it can be used as a library.
    /// </summary>
    public class Scene : SceneObject
    {
        private readonly List<Scene> _subScenes;
        private readonly List<A3DObject> _library;
        private readonly List<AnimationClip> _animationClips;
        private readonly HashSet<Pose> _poses;
        private readonly Node _rootNode;
        private AssetInfo? _assetInfo;
        private AnimationClip? _currentAnimationClip;

        /// <summary>
        /// Initializes a new instance of the Scene class.
        /// </summary>
        public Scene() : base()
        {
            _subScenes = new List<Scene>();
            _library = new List<A3DObject>();
            _animationClips = new List<AnimationClip>();
            _poses = new HashSet<Pose>();
            _rootNode = new Node("RootNode");
            _assetInfo = new AssetInfo();
        }

        /// <summary>
        /// Initializes a new instance of the Scene class with an entity attached to a new node.
        /// </summary>
        public Scene(Entity entity) : this()
        {
            var node = _rootNode.CreateChildNode("RootEntity", entity);
        }

        /// <summary>
        /// Initializes a new instance of the Scene class as a sub-scene.
        /// </summary>
        public Scene(Scene parentScene, string name) : base(name)
        {
            _subScenes = new List<Scene>();
            _library = new List<A3DObject>();
            _animationClips = new List<AnimationClip>();
            _poses = new HashSet<Pose>();
            _rootNode = new Node("RootNode");
            _assetInfo = new AssetInfo();
            parentScene._subScenes.Add(this);
        }

        /// <summary>
        /// Gets all sub-scenes
        /// </summary>
        public IList<Scene> SubScenes => _subScenes;

        /// <summary>
        /// Objects that not directly used in scene hierarchy can be defined in Library.
        /// This is useful when you're using sub-scenes and put reusable components under sub-scenes.
        /// </summary>
        public IList<A3DObject> Library => _library;

        /// <summary>
        /// Gets all AnimationClip defined in the scene.
        /// </summary>
        public IList<AnimationClip> AnimationClips => _animationClips;

        /// <summary>
        /// Gets or sets the active AnimationClip
        /// </summary>
        public AnimationClip? CurrentAnimationClip
        {
            get => _currentAnimationClip;
            set => _currentAnimationClip = value;
        }

        /// <summary>
        /// Gets or sets the top-level asset information
        /// </summary>
        public AssetInfo? AssetInfo
        {
            get => _assetInfo;
            set => _assetInfo = value;
        }

        /// <summary>
        /// Gets all Pose used in this scene.
        /// </summary>
        public ICollection<Pose> Poses => _poses;

        /// <summary>
        /// Gets the root node of the scene.
        /// </summary>
        public Node RootNode => _rootNode;

        /// <summary>
        /// Gets a named AnimationClip
        /// </summary>
        public AnimationClip? GetAnimationClip(string name)
        {
            foreach (var clip in _animationClips)
            {
                if (clip.Name == name)
                    return clip;
            }
            return null;
        }

        /// <summary>
        /// Clears the scene content and restores the default settings.
        /// </summary>
        public void Clear()
        {
            _subScenes.Clear();
            _library.Clear();
            _animationClips.Clear();
            _poses.Clear();
        }

        /// <summary>
        /// A shorthand function to create and register the 
        /// The first AnimationClip will be assigned to the
        /// </summary>
        public AnimationClip CreateAnimationClip(string name)
        {
            var clip = new AnimationClip(name);
            _animationClips.Add(clip);
            if (_currentAnimationClip == null)
                _currentAnimationClip = clip;
            return clip;
        }

        /// <summary>
        /// Opens the scene from given stream using specified file format.
        /// </summary>
        public void Open(Stream stream, FileFormat format, CancellationToken cancellationToken)
        {
            throw new NotImplementedException("Opening from stream with FileFormat is not yet implemented");
        }

        /// <summary>
        /// Opens the scene from given stream using specified IO config.
        /// </summary>
        public void Open(Stream stream, LoadOptions options, CancellationToken cancellationToken)
        {
            throw new NotImplementedException("Opening from stream with LoadOptions is not yet implemented");
        }

        /// <summary>
        /// Opens the scene from given stream
        /// </summary>
        public void Open(Stream stream)
        {
            throw new NotImplementedException("Opening from stream is not yet implemented");
        }

        /// <summary>
        /// Opens the scene from given stream
        /// </summary>
        public void Open(Stream stream, CancellationToken cancellationToken)
        {
            Open(stream);
        }

        /// <summary>
        /// Opens the scene from given path using specified file format.
        /// </summary>
        public void Open(string fileName, FileFormat format, CancellationToken cancellationToken)
        {
            throw new NotImplementedException("Opening from file with FileFormat is not yet implemented");
        }

        /// <summary>
        /// Opens the scene from given path using specified file format.
        /// </summary>
        public void Open(string fileName, LoadOptions options)
        {
            Clear();

            if (options is Formats.ObjLoadOptions objOptions)
            {
                var loadedScene = Formats.ObjReader.Read(fileName, objOptions);
                foreach (var node in loadedScene.RootNode.ChildNodes)
                {
                    _rootNode.ChildNodes.Add(node);
                }
                foreach (var clip in loadedScene.AnimationClips)
                {
                    _animationClips.Add(clip);
                }
                foreach (var pose in loadedScene.Poses)
                {
                    _poses.Add(pose);
                }
            }
            else
            {
                throw new NotSupportedException($"File format not yet supported for loading");
            }
        }

        /// <summary>
        /// Opens the scene from given path using specified file format.
        /// </summary>
        public void Open(string fileName, LoadOptions options, CancellationToken cancellationToken)
        {
            throw new NotImplementedException("Opening from file with LoadOptions and cancellation token is not yet implemented");
        }

        /// <summary>
        /// Opens the scene from given path
        /// </summary>
        public void Open(string fileName)
        {
            var format = FileFormat.Detect(fileName);
            Open(fileName, format.CreateLoadOptions());
        }

        /// <summary>
        /// Opens the scene from given path using specified file format.
        /// </summary>
        public void Open(string fileName, FileFormat format)
        {
            Open(fileName, format.CreateLoadOptions());
        }

        /// <summary>
        /// Opens the scene from given path
        /// </summary>
        public void Open(string fileName, CancellationToken cancellationToken)
        {
            Open(fileName);
        }

        /// <summary>
        /// Opens the scene from given stream using specified file format.
        /// </summary>
        public static Scene FromStream(Stream stream, FileFormat format, CancellationToken cancellationToken)
        {
            var scene = new Scene();
            scene.Open(stream, format, cancellationToken);
            return scene;
        }

        /// <summary>
        /// Opens the scene from given stream using specified IO config.
        /// </summary>
        public static Scene FromStream(Stream stream, LoadOptions options, CancellationToken cancellationToken)
        {
            var scene = new Scene();
            scene.Open(stream, options, cancellationToken);
            return scene;
        }

        /// <summary>
        /// Opens the scene from given stream
        /// </summary>
        public static Scene FromStream(Stream stream, CancellationToken cancellationToken)
        {
            var scene = new Scene();
            scene.Open(stream, cancellationToken);
            return scene;
        }

        /// <summary>
        /// Opens the scene from given path using specified file format.
        /// </summary>
        public static Scene FromFile(string fileName, FileFormat format, CancellationToken cancellationToken)
        {
            var scene = new Scene();
            scene.Open(fileName, format, cancellationToken);
            return scene;
        }

        /// <summary>
        /// Opens the scene from given path using specified file format.
        /// </summary>
        public static Scene FromFile(string fileName, LoadOptions options, CancellationToken cancellationToken)
        {
            var scene = new Scene();
            scene.Open(fileName, options, cancellationToken);
            return scene;
        }

        /// <summary>
        /// Opens the scene from given path
        /// </summary>
        public static Scene FromFile(string fileName)
        {
            var scene = new Scene();
            scene.Open(fileName);
            return scene;
        }

        /// <summary>
        /// Opens the scene from given path
        /// </summary>
        public static Scene FromFile(string fileName, CancellationToken cancellationToken)
        {
            return FromFile(fileName);
        }

        /// <summary>
        /// Saves the scene to stream using specified file format.
        /// </summary>
        public void Save(Stream stream, FileFormat format)
        {
            throw new NotImplementedException("Saving to stream with FileFormat is not yet implemented");
        }

        /// <summary>
        /// Saves the scene to stream using specified file format.
        /// </summary>
        public void Save(Stream stream, FileFormat format, CancellationToken cancellationToken)
        {
            throw new NotImplementedException("Saving to stream with FileFormat and cancellation token is not yet implemented");
        }

        /// <summary>
        /// Saves the scene to stream using specified file format.
        /// </summary>
        public void Save(Stream stream, SaveOptions options)
        {
            throw new NotImplementedException("Saving to stream with SaveOptions is not yet implemented");
        }

        /// <summary>
        /// Saves the scene to stream using specified file format.
        /// </summary>
        public void Save(Stream stream, SaveOptions options, CancellationToken cancellationToken)
        {
            throw new NotImplementedException("Saving to stream with SaveOptions and cancellation token is not yet implemented");
        }

        /// <summary>
        /// Saves the scene to specified path using specified file format.
        /// </summary>
        public void Save(string fileName)
        {
            var format = FileFormat.Detect(fileName);
            var options = format.CreateSaveOptions();
            Save(fileName, options);
        }

        /// <summary>
        /// Saves the scene to specified path using specified file format.
        /// </summary>
        public void Save(string fileName, FileFormat format)
        {
            var options = format.CreateSaveOptions();
            Save(fileName, options);
        }

        /// <summary>
        /// Saves the scene to specified path using specified file format.
        /// </summary>
        public void Save(string fileName, FileFormat format, CancellationToken cancellationToken)
        {
            throw new NotImplementedException("Saving to file with FileFormat and cancellation token is not yet implemented");
        }

        /// <summary>
        /// Saves the scene to specified path using specified file format.
        /// </summary>
        public void Save(string fileName, SaveOptions options)
        {
            if (options is Formats.ObjSaveOptions objOptions)
            {
                Formats.ObjWriter.Write(fileName, this, objOptions);
            }
            else
            {
                throw new NotSupportedException($"File format not yet supported for saving");
            }
        }

        /// <summary>
        /// Saves the scene to specified path using specified file format.
        /// </summary>
        public void Save(string fileName, SaveOptions options, CancellationToken cancellationToken)
        {
            throw new NotImplementedException("Saving to file with SaveOptions and cancellation token is not yet implemented");
        }

        /// <summary>
        /// Render the scene into external file from given camera's perspective.
        /// The default output size is 1024x768 and output format is png
        /// </summary>
        public void Render(Entities.Camera camera, string fileName)
        {
            throw new NotImplementedException(
                "This feature is not available in the FOSS version. " +
                "Consider using Aspose.3D's commercial On-Premise API for full functionality.");
        }

        /// <summary>
        /// Render the scene into external file from given camera's perspective.
        /// </summary>
        public void Render(Entities.Camera camera, string fileName, Vector2 size, string format)
        {
            throw new NotImplementedException(
                "This feature is not available in the FOSS version. " +
                "Consider using Aspose.3D's commercial On-Premise API for full functionality.");
        }

        /// <summary>
        /// Render the scene into external file from given camera's perspective.
        /// </summary>
        public void Render(Entities.Camera camera, string fileName, Vector2 size, string format, ImageRenderOptions options)
        {
            throw new NotImplementedException(
                "This feature is not available in the FOSS version. " +
                "Consider using Aspose.3D's commercial On-Premise API for full functionality.");
        }

        /// <summary>
        /// Render the scene into bitmap from given camera's perspective.
        /// </summary>
        public void Render(Entities.Camera camera, TextureData bitmap)
        {
            throw new NotImplementedException(
                "This feature is not available in the FOSS version. " +
                "Consider using Aspose.3D's commercial On-Premise API for full functionality.");
        }

        /// <summary>
        /// Render the scene into bitmap from given camera's perspective.
        /// </summary>
        public void Render(Entities.Camera camera, TextureData bitmap, ImageRenderOptions options)
        {
            throw new NotImplementedException(
                "This feature is not available in the FOSS version. " +
                "Consider using Aspose.3D's commercial On-Premise API for full functionality.");
        }
    }
}
