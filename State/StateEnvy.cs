using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Samples.StatePattern
{
    public static class StateEnvy
    {
        // Functor
        public static IState<TState, T1> Select<TState, T, T1>(
            this IState<TState, T> source,
            Func<T, T1> selector)
        {
            return source.SelectMany(x => Return<TState, T1>(selector(x)));
        }

        // Monad
        public static IState<TState, T1> SelectMany<TState, T, T1>(
            this IState<TState, T> source,
            Func<T, IState<TState, T1>> selector)
        {
            return new SelectManyState<TState, T, T1>(source, selector);
        }

        private class SelectManyState<TState, T, T1> : IState<TState, T1>
        {
            private readonly IState<TState, T> source;
            private readonly Func<T, IState<TState, T1>> selector;

            public SelectManyState(IState<TState, T> source, Func<T, IState<TState, T1>> selector)
            {
                this.source = source;
                this.selector = selector;
            }

            public StatePair<TState, T1> Run(TState state)
            {
                var pair = source.Run(state);
                var projection = selector(pair.Value);
                return projection.Run(pair.State);
            }
        }

        public static IState<TState, T> Return<TState, T>(T x)
        {
            return new ReturnState<TState, T>(x);
        }

        private class ReturnState<TState, T> : IState<TState, T>
        {
            private readonly T x;

            public ReturnState(T x)
            {
                this.x = x;
            }

            public StatePair<TState, T> Run(TState state)
            {
                return new StatePair<TState, T>(x, state);
            }
        }

        public static IState<TState, T1> SelectMany<TState, T, U, T1>(
            this IState<TState, T> source,
            Func<T, IState<TState, U>> k,
            Func<T, U, T1> s)
        {
            return source.SelectMany(x => k(x).Select(y => s(x, y)));
        }

        // MonadState
        public static IState<TState, TState> Get<TState>()
        {
            return new GetState<TState>();
        }

        private class GetState<TState> : IState<TState, TState>
        {
            public StatePair<TState, TState> Run(TState state)
            {
                return new StatePair<TState, TState>(state, state);
            }
        }

        public static IState<TState, Unit> Put<TState>(TState state)
        {
            return new PutState<TState>(state);
        }

        private class PutState<TState> : IState<TState, Unit>
        {
            private readonly TState state;

            public PutState(TState state)
            {
                this.state = state;
            }

            public StatePair<TState, Unit> Run(TState _)
            {
                return new StatePair<TState, Unit>(Unit.Instance, state);
            }
        }

        // Invariant functor

        public static IState<TState1, T> SelectState<TState, TState1, T>(
            this IState<TState, T> state,
            Func<TState, TState1> forward,
            Func<TState1, TState> back)
        {
            return
                from s1 in Get<TState1>()
                let s = back(s1)
                let p = state.Run(s)
                from _ in Put(forward(p.State))
                select p.Value;
        }

        public static IState<State, Out1> Request1(this In1 in1)
        {
            return
                from s in Get<State>()
                let p = s.Handle1(in1)
                from _ in Put(p.State)
                select p.Value;
        }

        public static IState<State, Out2> Request2(this In2 in2)
        {
            return
                from s in Get<State>()
                let p = s.Handle2(in2)
                from _ in Put(p.State)
                select p.Value;
        }
    }
}
