using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ploeh.Samples.StatePattern
{
    public class Examples
    {
        [Fact]
        public void AToB()
        {
            var in1 = In1.Alpha;
            var ctx = new Context(new ConcreteStateA());
            var actual = ctx.Request1(in1);
            Assert.Equal(Out1.Gamma, actual);
            Assert.Equal(new ConcreteStateB(), ctx.State);
        }
    }
}
