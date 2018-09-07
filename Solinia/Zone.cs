using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solinia
{
    public class Zone : IZone
    {
        private bool _loaded;
        public List<ISpawnGroup> SpawnGroups { get; set; } = new List<ISpawnGroup>();

        // Events
        public event LoadedEventHandler<LoadedEventArgs<IZone>> LoadedEvent;

        public long Id { get; set; }

        public string Name { get; set; }

        public long WorldId { get; set; }

        public bool Loaded
        {
            get => _loaded;
            protected set
            {
                _loaded = value;
                OnZoneLoaded(new LoadedEventArgs<IZone>(this));
            }
        }

        public Zone()
        {
        }

        public void Load()
        {
            Loaded = true;
        }

        private void OnZoneLoaded(LoadedEventArgs<IZone> e)
        {
            LoadedEvent?.Invoke(this, e);
            Trace.TraceInformation("Zone loaded: " + Id);
        }
    }
}
