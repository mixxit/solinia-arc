using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solinia
{
    public class Actor : IActor
    {
        private bool _loaded;

        // Events
        public event LoadedEventHandler<LoadedEventArgs<IActor>> LoadedEvent;

        public long Id { get; set; }

        public string Name { get; set; }

        public Boolean IsPlayer { get; set; } = false;

        public int STR { get; set; } = 75;
        public int STA { get; set; } = 75;
        public int AGI { get; set; } = 75;
        public int DEX { get; set; } = 75;
        public int INT { get; set; } = 75;
        public int WIS { get; set; } = 75;
        public int CHA { get; set; } = 75;

        public bool Loaded
        {
            get => _loaded;
            protected set
            {
                _loaded = value;
                OnActorLoaded(new LoadedEventArgs<IActor>(this));
            }
        }

        public Actor()
        {

        }
        
        public void Load()
        {
            Loaded = true;
        }

        private void OnActorLoaded(LoadedEventArgs<IActor> e)
        {
            LoadedEvent?.Invoke(this, e);
            Trace.TraceInformation("Actor loaded: " + Id);
        }
    }
}
