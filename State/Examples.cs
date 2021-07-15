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
        public void Request1AToB()
        {
            var in1 = In1.Alpha;
            var ctx = new Context(new ConcreteStateA());
            var actual = ctx.Request1(in1);
            Assert.Equal(Out1.Gamma, actual);
            Assert.Equal(new ConcreteStateB(), ctx.State);
        }

        [Fact]
        public void Request1AToA()
        {
            var in1 = In1.Beta;
            var ctx = new Context(new ConcreteStateA());
            var actual = ctx.Request1(in1);
            Assert.Equal(Out1.Delta, actual);
            Assert.Equal(new ConcreteStateA(), ctx.State);
        }

        [Fact]
        public void Request2AToB()
        {
            var in2 = In2.Epsilon;
            var ctx = new Context(new ConcreteStateA());
            var actual = ctx.Request2(in2);
            Assert.Equal(Out2.Eta, actual);
            Assert.Equal(new ConcreteStateB(), ctx.State);
        }

        [Fact]
        public void Request2AToA()
        {
            var in2 = In2.Zeta;
            var ctx = new Context(new ConcreteStateA());
            var actual = ctx.Request2(in2);
            Assert.Equal(Out2.Eta, actual);
            Assert.Equal(new ConcreteStateA(), ctx.State);
        }

        [Fact]
        public void Request1BAlpha()
        {
            var in1 = In1.Alpha;
            var ctx = new Context(new ConcreteStateB());
            var actual = ctx.Request1(in1);
            Assert.Equal(Out1.Gamma, actual);
            Assert.Equal(new ConcreteStateA(), ctx.State);
        }

        [Fact]
        public void Request1BBeta()
        {
            var in1 = In1.Beta;
            var ctx = new Context(new ConcreteStateB());
            var actual = ctx.Request1(in1);
            Assert.Equal(Out1.Gamma, actual);
            Assert.Equal(new ConcreteStateA(), ctx.State);
        }

        [Fact]
        public void Request2BEpsilon()
        {
            var in2 = In2.Epsilon;
            var ctx = new Context(new ConcreteStateB());
            var actual = ctx.Request2(in2);
            Assert.Equal(Out2.Theta, actual);
            Assert.Equal(new ConcreteStateB(), ctx.State);
        }

        [Fact]
        public void Request2BZeta()
        {
            var in2 = In2.Zeta;
            var ctx = new Context(new ConcreteStateB());
            var actual = ctx.Request2(in2);
            Assert.Equal(Out2.Theta, actual);
            Assert.Equal(new ConcreteStateB(), ctx.State);
        }

        [Fact]
        public void MultiUseExample1()
        {
            var in1 = In1.Alpha;
            var ctx = new Context(new ConcreteStateA());

            var outA = ctx.Request1(in1);
            var outB = ctx.Request1(in1);

            Assert.Equal(Out1.Gamma, outA);
            Assert.Equal(Out1.Gamma, outB);
            Assert.Equal(new ConcreteStateA(), ctx.State);
        }

        [Fact]
        public void MultiUseExample2()
        {
            var in2 = In2.Epsilon;
            var in1 = In1.Beta;
            var ctx = new Context(new ConcreteStateA());

            var outA = ctx.Request2(in2);
            var outB = ctx.Request1(in1);

            Assert.Equal(Out2.Eta, outA);
            Assert.Equal(Out1.Gamma, outB);
            Assert.Equal(new ConcreteStateA(), ctx.State);
        }
    }
}
