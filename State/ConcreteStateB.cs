using System.Collections.Generic;

namespace Ploeh.Samples.StatePattern
{
    public class ConcreteStateB : State
    {
        public override Out1 Handle1(Context context, In1 in1)
        {
            context.State = new ConcreteStateA();
            return Out1.Gamma;
        }

        public override Out2 Handle2(Context context, In2 in2)
        {
            return Out2.Theta;
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