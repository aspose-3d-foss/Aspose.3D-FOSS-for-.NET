using System;
using System.Collections.Generic;
using System.IO;
using Aspose.ThreeD.Entities;

namespace Aspose.ThreeD.Formats.GLTF
{
    /// <summary>
    /// This class provides support for EXT_structural_metadata, only used in glTF.
    /// </summary>
    public class StructuralMetadata
    {
        public StructuralMetadata()
        {
        }

        /// <summary>
        /// The class definitions .
        /// </summary>
        public Dictionary<string, ClassType> Classes { get; } = new Dictionary<string, ClassType>();

        /// <summary>
        /// The enum type definitions
        /// </summary>
        public Dictionary<string, EnumType> Enums { get; } = new Dictionary<string, EnumType>();

        /// <summary>
        /// The property tables in this metadata.
        /// </summary>
        public List<PropertyTable> PropertyTables { get; } = new List<PropertyTable>();

        /// <summary>
        /// Create a meta class type
        /// </summary>
        public ClassType CreateClass(string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create an enum type
        /// </summary>
        public EnumType CreateEnum(string name)
        {
            throw new NotImplementedException();
        }

        public PropertyTable CreatePropertyTable(string name, ClassType clazz)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Attach current meta data to specified scene
        /// </summary>
        public void Attach(Scene scene)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get  associated with specified scene.
        /// </summary>
        public static StructuralMetadata From(Scene scene)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The class definitions .
        /// </summary>
        public class ClassType
        {
            public ClassType(string name, string displayName, string description, List<Property> properties)
            {
            }

            public string Name { get; }
            public string DisplayName { get; set; }
            public string Description { get; set; }
            public IList<Property> Properties { get; } = new List<Property>();

            public string ToString()
            {
                throw new NotImplementedException();
            }

            public Property AddProperty(string name, EnumType type, bool array, int? count)
            {
                throw new NotImplementedException();
            }

            public Property AddProperty(string name, string displayName, string description, EnumType type, bool array, int? count)
            {
                throw new NotImplementedException();
            }

            public Property AddProperty(string name, string displayName, string description, Type type, bool normalized, int? count)
            {
                throw new NotImplementedException();
            }

            public Property AddProperty(string name, Type type)
            {
                throw new NotImplementedException();
            }

            public void AddProperty(Property property)
            {
                throw new NotImplementedException();
            }
        }

        public class EnumType
        {
            public EnumType(string name, List<EnumValue> values)
            {
            }

            public IList<EnumValue> Values { get; } = new List<EnumValue>();
            public string Name { get; }

            public string ToString()
            {
                throw new NotImplementedException();
            }

            public EnumValue AddValue(string name, int value)
            {
                throw new NotImplementedException();
            }
        }

        public class Property
        {
            public Property(string name, string displayName, string description, Type type, bool normalized, int? count)
            {
            }

            public Property(string name, string displayName, string description, EnumType type, bool array, int? count)
            {
            }

            public Property(string name, Type type)
            {
            }

            public string Name { get; }
            public string DisplayName { get; set; }
            public string Description { get; set; }
            public Type Type { get; }
            public EnumType EnumType { get; set; }
            public bool Normalized { get; set; }
            public int? Count { get; set; }

            public string ToString()
            {
                throw new NotImplementedException();
            }
        }

        public class EnumValue
        {
            public EnumValue(string name, int value)
            {
            }

            public string Name { get; }
            public int Value { get; }

            public string ToString()
            {
                throw new NotImplementedException();
            }
        }

        public class PropertyTable
        {
            public PropertyTable(string name, ClassType mclass)
            {
            }

            public string Name { get; }
            public ClassType MetaClass { get; }
            public Dictionary<string, object> Values { get; } = new Dictionary<string, object>();

            public object GetValue(string name)
            {
                throw new NotImplementedException();
            }

            public void AddValue(Property prop, object value)
            {
                throw new NotImplementedException();
            }

            public void AddValue(string propName, object value)
            {
                throw new NotImplementedException();
            }

            public static PropertyTable From(VertexElementUserData userData)
            {
                throw new NotImplementedException();
            }

            public void Attach(VertexElementUserData userData)
            {
                throw new NotImplementedException();
            }
        }
    }
}
