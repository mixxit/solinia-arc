using Solinia.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solinia
{
    public interface IZone : ISavable, ILoadable
    {
        string Name { get; set; }
        long WorldId { get; set; }
        List<ISpawnGroup> SpawnGroups { get; set; }
        ISpawnGroup CreateSpawnGroup(string name, int x, int y, int z);
    }
}
