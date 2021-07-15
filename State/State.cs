namespace Ploeh.Samples.StatePattern
{
    public abstract class State
    {
        public virtual State Handle(Context context)
        {
            return this;
        }

        // Generalised methods
        public abstract StatePair<Out1> Handle1(Context context, In1 in1);

        public abstract StatePair<Out2> Handle2(Context context, In2 in2);
    }
}