using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solinia
{
    public class ActorFactory
    {
        public static Actor Create()
        {
            var actor = new Actor();
            actor.Name = Guid.NewGuid().ToString();
            return actor;
        }
    }
}
