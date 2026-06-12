using Aspose.ThreeD.Entities;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    public class BooleanOperator : Entity, IMeshConvertible
    {
        private BooleanOperation _operator;
        private BooleanOperand _first;
        private BooleanOperand _second;

        public BooleanOperator() : base("BooleanOperator")
        {
        }

        public BooleanOperator(BooleanOperation operation, A3DObject first, A3DObject second) : base("BooleanOperator")
        {
            _operator = operation;
            _first = BooleanOperand.Of((Entity)first);
            _second = BooleanOperand.Of((Entity)second);
        }

        public BooleanOperation Operator
        {
            get => _operator;
            set => _operator = value;
        }

        public BooleanOperand First
        {
            get => _first;
            set => _first = value;
        }

        public BooleanOperand Second
        {
            get => _second;
            set => _second = value;
        }

        public Mesh ToMesh()
        {
            return null!;
        }
    }
}
