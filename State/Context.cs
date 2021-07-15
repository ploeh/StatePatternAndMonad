using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Samples.StatePattern
{
    public class Context
    {
        public Context(State state)
        {
            State = state;
        }

        public State State { get; internal set; }

        public Context Request()
        {
            State.Handle(this);
            return this;
        }

        // Generalised methods
        public StatePair<Context, Out1> Request1(In1 in1)
        {
            var pair = State.Handle1(this, in1);
            State = pair.State;
            return new StatePair<Context, Out1>(pair.Value, this);
        }

        public StatePair<Context, Out2> Request2(In2 in2)
        {
            var pair = State.Handle2(this, in2);
            State = pair.State;
            return new StatePair<Context, Out2>(pair.Value, this);
        }
    }
}
