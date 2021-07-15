namespace Ploeh.Samples.StatePattern
{
    public class In2
    {
        public readonly static In2 Epsilon = new();
        public readonly static In2    Zeta = new();

        private In2() {}
    }
}