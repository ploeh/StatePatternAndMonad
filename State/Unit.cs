namespace Ploeh.Samples.StatePattern
{
    public sealed class Unit
    {
        public readonly static Unit Instance = new();

        private Unit()
        {
        }
    }
}