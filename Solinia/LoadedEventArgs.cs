using System;

namespace Solinia
{
    public class LoadedEventArgs<T> : EventArgs
    {
        T loaded;

        public LoadedEventArgs(T loaded)
        {
            this.loaded = loaded;
        }

        public T GetLoaded()
        {
            return this.loaded;
        }
    }
}