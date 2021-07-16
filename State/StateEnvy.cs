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
            return new SelectState<TState, T, T1>(source, selector);
        }

        private class SelectState<TState, T, T1> : IState<TState, T1>
        {
            private IState<TState, T> source;
            private Func<T, T1> selector;

            public SelectState(IState<TState, T> source, Func<T, T1> selector)
            {
                this.source = source;
                this.selector = selector;
            }

            public StatePair<TState, T1> Run(TState state)
            {
                var pair = source.Run(state);
                var projection = selector(pair.Value);
                return new StatePair<TState, T1>(projection, pair.State);
            }
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
            private IState<TState, T> source;
            private Func<T, IState<TState, T1>> selector;

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

        public static IState<TState, T1> SelectMany<TState, T, U, T1>(
            this IState<TState, T> source,
            Func<T, IState<TState, U>> k,
            Func<T, U, T1> s)
        {
            return source.SelectMany(x => k(x).Select(y => s(x, y)));
        }

        public static IState<Context, Out1> Request1(this In1 in1)
        {
            return new DelegateState<Context, Out1>(ctx => ctx.Request1(in1));
        }

        public static IState<Context, Out2> Request2(this In2 in2)
        {
            return new DelegateState<Context, Out2>(ctx => ctx.Request2(in2));
        }

        private class DelegateState<TState, T> : IState<TState, T>
        {
            private Func<TState, StatePair<TState, T>> imp;

            public DelegateState(Func<TState, StatePair<TState, T>> imp)
            {
                this.imp = imp;
            }

            public StatePair<TState, T> Run(TState state)
            {
                return imp(state);
            }
        }
    }
}
