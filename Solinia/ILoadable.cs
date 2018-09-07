using System;

namespace Solinia
{
    public interface ILoadable
    {
        bool Loaded { get; }
        void Load();
    }
}