namespace Ploeh.Samples.StatePattern
{
    public class Out2
    {
        public readonly static Out2   Eta = new();
        public readonly static Out2 Theta = new();

        private Out2() { }
    }
}