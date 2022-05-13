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

        public State State { get; }

        public Context Request()
        {
            State.Handle(this);
            return this;
        }

        // Generalised methods
        public StatePair<Context, Out1> Request1(In1 in1)
        {
            return in1.Request1S().Run(State).SelectState(s => new Context(s));
        }

        public StatePair<Context, Out2> Request2(In2 in2)
        {
            return in2.Request2S().Run(State).SelectState(s => new Context(s));
        }
    }
}
