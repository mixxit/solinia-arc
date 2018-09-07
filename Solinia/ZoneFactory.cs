using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solinia
{
    public class ZoneFactory
    {
        public static Zone Create(long worldId)
        {
            var zone = new Zone();
            zone.Name = Guid.NewGuid().ToString();
            zone.WorldId = worldId;
            return zone;
        }
    }
}
