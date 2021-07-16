using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Samples.StatePattern
{
    public interface IState<TState, T>
    {
        StatePair<TState, T> Run(TState state);
    }
}
