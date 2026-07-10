using System;
using Aspose.ThreeD.Entities;
using Aspose.ThreeD.Utilities;
using Xunit;

namespace Aspose.ThreeD.Tests
{
    public class NurbsCurveTests
    {
        [Fact]
        public void Constructor_ShouldInitializeDefaultValues()
        {
            var curve = new NurbsCurve();
            
            Assert.NotNull(curve);
            Assert.Equal(2, curve.Order);
            Assert.Equal(1, curve.Degree);
            Assert.False(curve.Rational);
            Assert.Equal(CurveDimension.ThreeDimensional, curve.Dimension);
            Assert.Equal(NurbsType.Open, curve.CurveType);
        }

        [Fact]
        public void ConstructorWithName_ShouldInitializeWithName()
        {
            var curve = new NurbsCurve("TestCurve");
            
            Assert.Equal("TestCurve", curve.Name);
        }

        [Fact]
        public void ControlPoints_ShouldBeWritable()
        {
            var curve = new NurbsCurve();
            var controlPoints = curve.ControlPoints;
            
            Assert.NotNull(controlPoints);
            Assert.Empty(controlPoints);
            
            controlPoints.Add(new Vector4(1, 2, 3, 1));
            Assert.Single(controlPoints);
        }

        [Fact]
        public void Multiplicity_ShouldBeWritable()
        {
            var curve = new NurbsCurve();
            var multiplicity = curve.Multiplicity;
            
            Assert.NotNull(multiplicity);
            Assert.Empty(multiplicity);
            
            multiplicity.Add(2);
            Assert.Single(multiplicity);
        }

        [Fact]
        public void KnotVectors_ShouldBeWritable()
        {
            var curve = new NurbsCurve();
            var knotVectors = curve.KnotVectors;
            
            Assert.NotNull(knotVectors);
            Assert.Empty(knotVectors);
            
            knotVectors.Add(0.0);
            knotVectors.Add(1.0);
            Assert.Equal(2, knotVectors.Count);
        }

        [Fact]
        public void Order_ShouldBeSettable()
        {
            var curve = new NurbsCurve();
            curve.Order = 4;
            
            Assert.Equal(4, curve.Order);
            Assert.Equal(3, curve.Degree);
        }

        [Fact]
        public void Degree_ShouldBeSettable()
        {
            var curve = new NurbsCurve();
            curve.Degree = 2;
            
            Assert.Equal(3, curve.Order);
            Assert.Equal(2, curve.Degree);
        }

        [Fact]
        public void Rational_ShouldBeSettable()
        {
            var curve = new NurbsCurve();
            curve.Rational = true;
            
            Assert.True(curve.Rational);
        }

        [Fact]
        public void Dimension_ShouldBeSettable()
        {
            var curve = new NurbsCurve();
            curve.Dimension = CurveDimension.TwoDimensional;
            
            Assert.Equal(CurveDimension.TwoDimensional, curve.Dimension);
        }

        [Fact]
        public void CurveType_ShouldBeSettable()
        {
            var curve = new NurbsCurve();
            curve.CurveType = NurbsType.Closed;
            
            Assert.Equal(NurbsType.Closed, curve.CurveType);
        }

        [Fact]
        public void Evaluate_ShouldThrowNotImplementedException()
        {
            var curve = new NurbsCurve();
            
            Assert.Throws<NotImplementedException>(() => curve.Evaluate(10));
        }

        [Fact]
        public void EvaluateAt_ShouldThrowNotImplementedException()
        {
            var curve = new NurbsCurve();
            
            Assert.Throws<NotImplementedException>(() => curve.EvaluateAt(0.5));
        }
    }
}
