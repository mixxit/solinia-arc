using Solinia.Database;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solinia
{
    public class World : IWorld
    {
        private bool _loaded;
        private IRepository<SpawnGroup, Database.EntityFramework.SpawnGroup> spawngroupRepository = new EFRepository<SpawnGroup, Database.EntityFramework.SpawnGroup>();
        private IRepository<Zone, Database.EntityFramework.Zone> zoneRepository = new EFRepository<Zone, Database.EntityFramework.Zone>();
        private IRepository<Actor, Database.EntityFramework.Actor> actorRepository = new EFRepository<Actor, Database.EntityFramework.Actor>();

        public List<IZone> Zones { get; set; } = new List<IZone>();
        public List<IActor> Actors { get; set; } = new List<IActor>();

        // Events
        public event LoadedEventHandler<LoadedEventArgs<IWorld>> LoadedEvent;

        public long Id { get; set; }

        public string Name { get; set; }

        public bool Loaded
        {
            get => _loaded;
            protected set
            {
                _loaded = value;
                OnWorldLoaded(new LoadedEventArgs<IWorld>(this));
            }
        }

        public World()
        {

        }

        public void Load()
        {
            LoadZones();
            LoadActors();
            Loaded = true;
        }

        private void LoadZones()
        {
            Zones.Clear();
            foreach (long id in zoneRepository.Ids)
            {
                var zone = zoneRepository.Get(id);
                if (zone.WorldId != this.Id)
                    continue;

                Zones.Add(zoneRepository.Get(id));
            }
            
            foreach (Zone zone in Zones)
                zone.Load();
        }

        private void LoadActors()
        {
            Actors.Clear();
            foreach (long id in actorRepository.Ids)
            {
                var actor = actorRepository.Get(id);
                Actors.Add(actorRepository.Get(id));
            }

            foreach (Actor actor in Actors)
                actor.Load();
        }

        private void OnWorldLoaded(LoadedEventArgs<IWorld> e)
        {
            LoadedEvent?.Invoke(this, e);
            Trace.TraceInformation("World loaded: " + Id);
        }

        public IZone CreateZone()
        {
            if (this.Id < 1)
                throw new Exception("World does not have an ID");

            var zone = ZoneFactory.Create(this.Id);
            var returnZone = zoneRepository.Set(zone);
            LoadZones();

            return Zones.FirstOrDefault(z => z.Id == returnZone.Id);
        }

        public IActor CreateActor()
        {
            var actor = ActorFactory.Create();
            var returnActor = actorRepository.Set(actor);
            LoadActors();

            return Actors.FirstOrDefault(z => z.Id == returnActor.Id);
        }

        ISpawnGroup IZone.CreateSpawnGroup(long zoneId, string name, int x, int y, int z)
        {
            if (this.Id < 1)
                throw new Exception("World does not have an ID");

            if (zoneId < 1)
                throw new Exception("Zone does not have an ID");

            var spawngroup = SpawnGroupFactory.Create(this.Id);
            var returnZone = spawngroupRepository.Set(spawngroup);
            LoadSpawnGroup();

            return SpawnGroups.FirstOrDefault(z => z.Id == returnZone.Id);
        }

        public void Tick()
        {
            Trace.TraceInformation("Tick");
        }
    }
}
