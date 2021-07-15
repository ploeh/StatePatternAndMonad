namespace Ploeh.Samples.StatePattern
{
    public class ConcreteStateA : State
    {
        public override StatePair<State, Out1> Handle1(Context context, In1 in1)
        {
            if (in1 != In1.Alpha)
                return new StatePair<State, Out1>(Out1.Delta, this);

            return new StatePair<State, Out1>(Out1.Gamma, new ConcreteStateB());
        }

        public override StatePair<State, Out2> Handle2(Context context, In2 in2)
        {
            if (in2 == In2.Epsilon)
                return new StatePair<State, Out2>(Out2.Eta, new ConcreteStateB());

            return new StatePair<State, Out2>(Out2.Eta, this);
        }

        public override bool Equals(object obj)
        {
            return obj is ConcreteStateA;
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}