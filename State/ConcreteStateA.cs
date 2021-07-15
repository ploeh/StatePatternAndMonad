namespace Ploeh.Samples.StatePattern
{
    public class ConcreteStateA : State
    {
        public override Out1 Handle1(Context context, In1 in1)
        {
            if (in1 != In1.Alpha)
                return Out1.Delta;

            context.State = new ConcreteStateB();
            return Out1.Gamma;
        }

        public override Out2 Handle2(Context context, In2 in2)
        {
            if (in2 == In2.Epsilon)
                context.State = new ConcreteStateB();

            return Out2.Eta;
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