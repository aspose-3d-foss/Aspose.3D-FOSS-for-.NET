using System;
using System.Collections.Generic;
using Aspose.ThreeD.Entities;
using Aspose.ThreeD.Utilities;
using Xunit;

namespace Aspose.ThreeD.Tests
{
    public class ArrayListAdapterTests
    {
        [Fact]
        public void ArrayListAdapterInVertexElementTemplate_ShouldWork()
        {
            // Verify ArrayListAdapter works correctly through VertexElementTemplate
            var element = new TestVertexElementTemplate();
            
            Assert.NotNull(element.Data);
            Assert.Equal(0, element.Data.Count);
            
            element.Data.Add(1.5);
            element.Data.Add(2.5);
            Assert.Equal(2, element.Data.Count);
            
            Assert.Equal(1.5, element.Data[0]);
            Assert.Equal(2.5, element.Data[1]);
            
            element.Data.Clear();
            Assert.Empty(element.Data);
        }

        private class TestVertexElementTemplate : VertexElementTemplate<double>
        {
            public TestVertexElementTemplate() : base()
            {
            }
        }
    }
}
