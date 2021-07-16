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

        public StatePair<TState1, T1> SelectBoth<TState1, T1>(
            Func<T, T1> selectValue,
            Func<TState, TState1> selectState)
        {
            return new StatePair<TState1, T1>(
                selectValue(Value),
                selectState(State));
        }

        public StatePair<TState1, T> SelectState<TState1>(
            Func<TState, TState1> selectState)
        {
            return SelectBoth(x => x, selectState);
        }

        public StatePair<TState, T1> SelectValue<T1>(Func<T, T1> selectValue)
        {
            return SelectBoth(selectValue, s => s);
        }

        public StatePair<TState, T1> Select<T1>(Func<T, T1> selectValue)
        {
            return SelectValue(selectValue);
        }

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
