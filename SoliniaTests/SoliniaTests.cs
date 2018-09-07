using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solinia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solinia.Tests
{
    [TestClass()]
    public class SoliniaTests
    {
        [TestMethod()]
        public void InstanceTest()
        {
            Assert.IsNotNull(Solinia.Instance);
        }

        [TestMethod()]
        public void GetWorldTest()
        {
            Solinia.Instance.LoadWorld(1);
            Assert.IsNotNull(Solinia.Instance.GetWorld());
        }

        [TestMethod()]
        public void GetWorldName()
        {
            Solinia.Instance.LoadWorld(1);
            Assert.AreEqual("4b86379f-a403-45e3-b891-7d22fd51e14f", Solinia.Instance.GetWorld().Name);
        }

        [TestMethod()]
        public void WorldLoadedEvent()
        {
            World world = WorldFactory.Create();
            world.LoadedEvent += new LoadedEventHandler<LoadedEventArgs<IWorld>>(DetectWorldEvent);
            world.Load();
            bool found = worldLoadedDetected;
            worldLoadedDetected = false;
            Assert.AreEqual(true, found);
        }

        private bool worldLoadedDetected = false;
        public void DetectWorldEvent(object sender, LoadedEventArgs<IWorld> e)
        {
            worldLoadedDetected = true;
        }

        [TestMethod()]
        public void GetZoneName()
        {
            Solinia.Instance.LoadWorld(1);
            if (Solinia.Instance.GetWorld().Zones.Count  < 1)
            {
                Solinia.Instance.GetWorld().CreateZone();
            }
            Assert.AreEqual("58d8e910-e66d-411a-848a-331e25622456", Solinia.Instance.GetWorld().Zones.First().Name);
        }

        [TestMethod()]
        public void CreateZone()
        {
            Solinia.Instance.LoadWorld(1);
            var zone = Solinia.Instance.GetWorld().CreateZone();
            Assert.AreEqual(zone.Name, Solinia.Instance.GetWorld().Zones.FirstOrDefault(z => z.Id == zone.Id).Name);
        }

        [TestMethod()]
        public void CreateSpawnGroup()
        {
            Solinia.Instance.LoadWorld(1);
            var zone = Solinia.Instance.GetWorld().CreateZone();
            var actor = Solinia.Instance.GetWorld().Actors.First();
            var name = Guid.NewGuid().ToString();
            var spawnGroup = zone.CreateSpawnGroup(name, 0,0,0);
            Assert.AreEqual(spawnGroup.Name, zone.SpawnGroups.First().Name);
        }

        [TestMethod()]
        public void CreateActor()
        {
            Solinia.Instance.LoadWorld(1);
            var actor = Solinia.Instance.GetWorld().CreateActor();
            Assert.AreEqual(actor.Name, Solinia.Instance.GetWorld().Actors.FirstOrDefault(a => a.Id == actor.Id).Name);
        }

        [TestMethod()]
        public void ZoneLoadedEvent()
        {
            Zone zone = ZoneFactory.Create(1);
            zone.LoadedEvent += new LoadedEventHandler<LoadedEventArgs<IZone>>(DetectZoneEvent);
            zone.Load();
            bool found = zoneLoadedDetected;
            zoneLoadedDetected = false;
            Assert.AreEqual(true, found);
        }

        private bool zoneLoadedDetected = false;
        public void DetectZoneEvent(object sender, LoadedEventArgs<IZone> e)
        {
            zoneLoadedDetected = true;
        }

        [TestMethod()]
        public void ActorLoadedEvent()
        {
            Actor actor = ActorFactory.Create();
            actor.LoadedEvent += new LoadedEventHandler<LoadedEventArgs<IActor>>(DetectActorEvent);
            actor.Load();
            bool found = actorLoadedDetected;
            actorLoadedDetected = false;
            Assert.AreEqual(true, found);
        }

        private bool actorLoadedDetected = false;
        public void DetectActorEvent(object sender, LoadedEventArgs<IActor> e)
        {
            actorLoadedDetected = true;
        }
    }
}