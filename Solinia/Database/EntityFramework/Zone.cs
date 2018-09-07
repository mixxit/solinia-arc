using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solinia.Database.EntityFramework
{
    [Table("Zone")]
    public partial class Zone : ISavable
    {
        public long Id { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }

        public long WorldId { get; set; }
    }
}
