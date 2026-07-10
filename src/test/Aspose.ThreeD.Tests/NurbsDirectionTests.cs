using Aspose.ThreeD.Entities;
using Aspose.ThreeD.Utilities;
using Xunit;

namespace Aspose.ThreeD.Tests
{
    public class NurbsDirectionTests
    {
        [Fact]
        public void Constructor_ShouldInitializeDefaultValues()
        {
            var direction = new NurbsDirection();
            
            Assert.NotNull(direction);
            Assert.Equal(3, direction.Order);
            Assert.Equal(2, direction.Degree);
            Assert.Equal(10, direction.Divisions);
            Assert.Equal(NurbsType.Open, direction.Type);
            Assert.Equal(4, direction.Count);
        }

        [Fact]
        public void KnotVectors_ShouldBeWritable()
        {
            var direction = new NurbsDirection();
            var knotVectors = direction.KnotVectors;
            
            Assert.NotNull(knotVectors);
            Assert.Empty(knotVectors);
            
            knotVectors.Add(0.0);
            knotVectors.Add(1.0);
            Assert.Equal(2, knotVectors.Count);
        }

        [Fact]
        public void Multiplicity_ShouldBeWritable()
        {
            var direction = new NurbsDirection();
            var multiplicity = direction.Multiplicity;
            
            Assert.NotNull(multiplicity);
            Assert.Empty(multiplicity);
            
            multiplicity.Add(2);
            Assert.Single(multiplicity);
        }

        [Fact]
        public void Order_ShouldBeSettable()
        {
            var direction = new NurbsDirection();
            direction.Order = 4;
            
            Assert.Equal(4, direction.Order);
        }

        [Fact]
        public void Degree_ShouldBeSettable()
        {
            var direction = new NurbsDirection();
            direction.Degree = 2;
            
            Assert.Equal(2, direction.Degree);
        }

        [Fact]
        public void Divisions_ShouldBeSettable()
        {
            var direction = new NurbsDirection();
            direction.Divisions = 20;
            
            Assert.Equal(20, direction.Divisions);
        }

        [Fact]
        public void Type_ShouldBeSettable()
        {
            var direction = new NurbsDirection();
            direction.Type = NurbsType.Closed;
            
            Assert.Equal(NurbsType.Closed, direction.Type);
        }

        [Fact]
        public void Count_ShouldBeSettable()
        {
            var direction = new NurbsDirection();
            direction.Count = 8;
            
            Assert.Equal(8, direction.Count);
        }
    }
}
