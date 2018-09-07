using System.Diagnostics;

namespace Solinia
{
    public class SpawnGroup : ISpawnGroup
    {
        private bool _loaded;

        // Events
        public event LoadedEventHandler<LoadedEventArgs<ISpawnGroup>> LoadedEvent;

        public long Id { get; set; }

        public string Name { get; set; }
        public float x { get; set; } = 0;
        public float y { get; set; } = 0;
        public float z { get; set; } = 0;

        public bool Loaded
        {
            get => _loaded;
            protected set
            {
                _loaded = value;
                OnSpawnGroupLoaded(new LoadedEventArgs<ISpawnGroup>(this));
            }
        }

        public SpawnGroup()
        {

        }

        public void Load()
        {
            Loaded = true;
        }

        private void OnSpawnGroupLoaded(LoadedEventArgs<ISpawnGroup> e)
        {
            LoadedEvent?.Invoke(this, e);
            Trace.TraceInformation("Spawngroup loaded: " + Id);
        }
    }
}