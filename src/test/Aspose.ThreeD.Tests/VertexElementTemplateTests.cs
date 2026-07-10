using Aspose.ThreeD.Entities;
using Aspose.ThreeD.Utilities;
using Xunit;

namespace Aspose.ThreeD.Tests
{
    public class VertexElementTemplateTests
    {
        [Fact]
        public void Data_ShouldBeWritable()
        {
            var element = new TestVertexElementTemplate();
            
            Assert.NotNull(element.Data);
            Assert.Empty(element.Data);
            
            element.Data.Add(1.5);
            element.Data.Add(2.5);
            Assert.Equal(2, element.Data.Count);
        }

        [Fact]
        public void CopyTo_ShouldCopyData()
        {
            var source = new TestVertexElementTemplate();
            source.Data.Add(1.5);
            source.Data.Add(2.5);
            
            var target = new TestVertexElementTemplate();
            source.CopyTo(target);
            
            Assert.Equal(2, target.Data.Count);
            Assert.Equal(1.5, target.Data[0]);
            Assert.Equal(2.5, target.Data[1]);
        }

        [Fact]
        public void SetData_ShouldSetData()
        {
            var element = new TestVertexElementTemplate();
            var data = new double[] { 1.0, 2.0, 3.0 };
            
            element.SetData(data);
            
            Assert.Equal(3, element.Data.Count);
            Assert.Equal(1.0, element.Data[0]);
            Assert.Equal(2.0, element.Data[1]);
            Assert.Equal(3.0, element.Data[2]);
        }

        [Fact]
        public void Clear_ShouldClearData()
        {
            var element = new TestVertexElementTemplate();
            element.Data.Add(1.0);
            element.Data.Add(2.0);
            
            element.Clear();
            
            Assert.Equal(0, element.Data.Count);
        }

        private class TestVertexElementTemplate : VertexElementTemplate<double>
        {
            public TestVertexElementTemplate() : base()
            {
            }
        }
    }
}
