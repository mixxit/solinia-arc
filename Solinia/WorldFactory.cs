using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solinia
{
    public class WorldFactory
    {
        public static World Create()
        {
            var world = new World();
            world.Name = Guid.NewGuid().ToString();
            return world;
        }
    }
}
