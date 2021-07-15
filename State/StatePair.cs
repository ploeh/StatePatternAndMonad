using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Samples.StatePattern
{
    public sealed class StatePair<T>
    {
        public StatePair(T value, State state)
        {
            Value = value;
            State = state;
        }

        public T Value { get; }
        public State State { get; }

        public override bool Equals(object obj)
        {
            return obj is StatePair<T> result &&
                   EqualityComparer<T>.Default.Equals(Value, result.Value) &&
                   EqualityComparer<State>.Default.Equals(State, result.State);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, State);
        }
    }
}
