namespace Ploeh.Samples.StatePattern
{
    public abstract class State
    {
        public virtual void Handle(Context context)
        {
        }

        // Generalised methods
        public abstract Out1 Handle1(Context context, In1 in1);

        public abstract Out2 Handle2(Context context, In2 in2);
    }
}