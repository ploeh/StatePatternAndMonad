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
            var s = new ConcreteStateA();
            var actual = s.Handle1(in1);
            Assert.Equal(Out1.Gamma, actual.Value);
            Assert.Equal(new ConcreteStateB(), actual.State);
        }

        [Fact]
        public void Request1AToA()
        {
            var in1 = In1.Beta;
            var s = new ConcreteStateA();
            var actual = s.Handle1(in1);
            Assert.Equal(Out1.Delta, actual.Value);
            Assert.Equal(new ConcreteStateA(), actual.State);
        }

        [Fact]
        public void Request2AToB()
        {
            var in2 = In2.Epsilon;
            var s = new ConcreteStateA();
            var actual = s.Handle2(in2);
            Assert.Equal(Out2.Eta, actual.Value);
            Assert.Equal(new ConcreteStateB(), actual.State);
        }

        [Fact]
        public void Request2AToA()
        {
            var in2 = In2.Zeta;
            var s = new ConcreteStateA();
            var actual = s.Handle2(in2).SelectState(s => new Context(s));
            Assert.Equal(Out2.Eta, actual.Value);
            Assert.Equal(new ConcreteStateA(), actual.State.State);
        }

        [Fact]
        public void Request1BAlpha()
        {
            var in1 = In1.Alpha;
            var s = new ConcreteStateB();
            var actual = s.Handle1(in1).SelectState(s => new Context(s));
            Assert.Equal(Out1.Gamma, actual.Value);
            Assert.Equal(new ConcreteStateA(), actual.State.State);
        }

        [Fact]
        public void Request1BBeta()
        {
            var in1 = In1.Beta;
            var s = new ConcreteStateB();
            var actual = s.Handle1(in1).SelectState(s => new Context(s));
            Assert.Equal(Out1.Gamma, actual.Value);
            Assert.Equal(new ConcreteStateA(), actual.State.State);
        }

        [Fact]
        public void Request2BEpsilon()
        {
            var in2 = In2.Epsilon;
            var s = new ConcreteStateB();
            var actual = s.Handle2(in2).SelectState(s => new Context(s));
            Assert.Equal(Out2.Theta, actual.Value);
            Assert.Equal(new ConcreteStateB(), actual.State.State);
        }

        [Fact]
        public void Request2BZeta()
        {
            var in2 = In2.Zeta;
            var s = new ConcreteStateB();
            var actual = s.Handle2(in2).SelectState(s => new Context(s));
            Assert.Equal(Out2.Theta, actual.Value);
            Assert.Equal(new ConcreteStateB(), actual.State.State);
        }

        [Fact]
        public void MultiUseExample1()
        {
            var in1 = In1.Alpha;
            var csa = new ConcreteStateA();

            var s =
                from a in in1.Request1S()
                from b in in1.Request1S()
                select (a, b);
            var t = s.Run(csa);

            Assert.Equal(Out1.Gamma, t.Value.a);
            Assert.Equal(Out1.Gamma, t.Value.b);
            Assert.Equal(new ConcreteStateA(), t.State);
        }

        [Fact]
        public void MultiUseExample2()
        {
            var in2 = In2.Epsilon;
            var in1 = In1.Beta;
            var csa = new ConcreteStateA();

            var s =
                from a in in2.Request2S()
                from b in in1.Request1S()
                select (a, b);
            var t = s.Run(csa);

            Assert.Equal(Out2.Eta, t.Value.a);
            Assert.Equal(Out1.Gamma, t.Value.b);
            Assert.Equal(new ConcreteStateA(), t.State);
        }
    }
}
