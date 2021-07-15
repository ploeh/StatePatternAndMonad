using System.Collections.Generic;

namespace Ploeh.Samples.StatePattern
{
    public class ConcreteStateB : State
    {
        public override Out1 Handle1(Context context, In1 in1)
        {
            if (in1 != In1.Alpha)
                return Out1.Delta;

            context.State = new ConcreteStateA();
            return Out1.Gamma;
        }

        public override Out2 Handle2(Context context, In2 in2)
        {
            throw new System.NotImplementedException();
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