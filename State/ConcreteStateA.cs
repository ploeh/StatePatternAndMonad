namespace Ploeh.Samples.StatePattern
{
    public class ConcreteStateA : State
    {
        public override Out1 Handle1(Context context, In1 in1)
        {
            context.State = new ConcreteStateB();
            return null;
        }

        public override Out2 Handle2(Context context, In2 in2)
        {
            throw new System.NotImplementedException();
        }
    }
}