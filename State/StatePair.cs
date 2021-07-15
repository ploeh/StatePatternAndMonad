using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Samples.StatePattern
{
    public sealed class StatePair<TState, T>
    {
        public StatePair(T value, TState state)
        {
            Value = value;
            State = state;
        }

        public T Value { get; }
        public TState State { get; }

        public override bool Equals(object obj)
        {
            return obj is StatePair<TState, T> pair &&
                   EqualityComparer<T>.Default.Equals(Value, pair.Value) &&
                   EqualityComparer<TState>.Default.Equals(State, pair.State);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, State);
        }
    }
}
