namespace Ploeh.Samples.StatePattern
{
    public class In1
    {
        public readonly static In1 Alpha = new();
        public readonly static In1  Beta = new();

        private In1() {}
    }
}