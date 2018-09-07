using Solinia.Database;
using System.Collections.Generic;

namespace Solinia
{
    public interface IWorld : ISavable, ILoadable
    {
        string Name { get; set; }
        IZone CreateZone();
        IActor CreateActor();
        List<IZone> Zones { get; set; }
        List<IActor> Actors { get; set; }
    }
}