namespace Ploeh.Samples.StatePattern
{
    public abstract class State
    {
        public virtual State Handle(Context context)
        {
            return this;
        }

        // Generalised methods
        public abstract StatePair<State, Out1> Handle1(In1 in1);

        public abstract StatePair<State, Out2> Handle2(In2 in2);
    }
}