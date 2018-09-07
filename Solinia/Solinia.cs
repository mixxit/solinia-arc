using Solinia.Database;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solinia
{
    public sealed class Solinia
    {
        private static readonly Lazy<Solinia> lazy =
        new Lazy<Solinia>(() => new Solinia());
        private IWorld world;
        private IRepository<World, Database.EntityFramework.World> worldRepository = new EFRepository<World, Database.EntityFramework.World>();
        public static Solinia Instance { get { return lazy.Value; } }

        private Solinia()
        {
            
        }

        public void LoadWorld(long worldId)
        {
            if (worldRepository.First() == null)
            {
                var newWorld = WorldFactory.Create();
                world = worldRepository.Set(newWorld);
                Trace.TraceInformation("New world detected, generating");
            }
            else
                world = worldRepository.Get(worldId);

            world.Load();
        }

        public Solinia GetInstance()
        {
            return Solinia.Instance;
        }

        public IWorld GetWorld()
        {
            return GetInstance().world;
        }
    }
}
