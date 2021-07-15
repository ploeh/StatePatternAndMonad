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

        public void Request()
        {
            State.Handle(this);
        }

        // Generalised methods
        public Out1 Request1(In1 in1)
        {
            return State.Handle1(this, in1).Value;
        }

        public Out2 Request2(In2 in2)
        {
            return State.Handle2(this, in2).Value;
        }
    }
}
