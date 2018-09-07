using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solinia.Database.EntityFramework
{
    [Table("SpawnGroup")]
    public partial class SpawnGroup : ISavable
    {
        public long Id { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }
        [Required]
        public float x { get; set; }
        [Required]
        public float y { get; set; }
        [Required]
        public float z { get; set; }
    }
}
