using System.Collections.Generic;

namespace Ploeh.Samples.StatePattern
{
    public class Out1
    {
        public readonly static Out1 Gamma = new();
        public readonly static Out1 Delta = new();

        private Out1() { }
    }
}