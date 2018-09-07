using Solinia.Database;

namespace Solinia
{
    public interface ISpawnGroup : ISavable, ILoadable
    {
        string Name { get; set; }
    }
}