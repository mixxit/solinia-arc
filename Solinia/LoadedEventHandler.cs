using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solinia
{
    public delegate void LoadedEventHandler<T>(object sender, T e) where T : EventArgs;
}
