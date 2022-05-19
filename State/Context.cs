﻿using System;
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

        // Generalised methods
        public StatePair<Context, Out2> Request2(In2 in2)
        {
            return in2.Request2().Run(this);
        }
    }
}
