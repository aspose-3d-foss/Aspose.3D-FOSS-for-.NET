using Aspose.ThreeD.Entities;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// This class encapsulates the transformed mesh as Boolean operation's operand.
    /// </summary>
    public class BooleanOperand
    {
        private A3DObject _operand;

        internal BooleanOperand(A3DObject operand)
        {
            _operand = operand;
        }

        /// <summary>
        /// Gets the operand, it can be an instance of Node, Entity or Mesh.
        /// </summary>
        public A3DObject Operand => _operand;

        /// <summary>
        /// Gets the string representation.
        /// </summary>
        public override string ToString()
        {
            return $"BooleanOperand: {_operand?.GetType().Name ?? "null"}";
        }

        /// <summary>
        /// Construct a BooleanOperand instance from a node, a valid entity implemented Mesh is required.
        /// </summary>
        public static BooleanOperand Of(Node node)
        {
            return new BooleanOperand(node);
        }

        /// <summary>
        /// Construct a BooleanOperand instance from a bare Mesh instance.
        /// </summary>
        public static BooleanOperand Of(Entity mesh)
        {
            return new BooleanOperand(mesh);
        }

        /// <summary>
        /// Construct a BooleanOperand instance from a bare Mesh instance with transform.
        /// </summary>
        public static BooleanOperand Of(Entity mesh, Matrix4? transform)
        {
            return new BooleanOperand(mesh);
        }
    }
}
