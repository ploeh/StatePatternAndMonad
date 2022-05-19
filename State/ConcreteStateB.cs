using System.Collections.Generic;

namespace Ploeh.Samples.StatePattern
{
    public class ConcreteStateB : State
    {
        public override StatePair<State, Out1> Handle1(In1 in1)
        {
            return new StatePair<State, Out1>(Out1.Gamma, new ConcreteStateA());
        }

        public override StatePair<State, Out2> Handle2(In2 in2)
        {
            return new StatePair<State, Out2>(Out2.Theta, this);
        }

        public override bool Equals(object obj)
        {
            return obj is ConcreteStateB;
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}