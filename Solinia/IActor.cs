using Solinia.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solinia
{
    public interface IActor : ISavable, ILoadable
    {
        string Name { get; set; }
        Boolean IsPlayer { get; set; }
    }
}
