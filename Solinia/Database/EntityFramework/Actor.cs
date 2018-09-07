using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solinia.Database.EntityFramework
{
    [Table("Actor")]
    public partial class Actor : ISavable
    {
        public long Id { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }
        [Required]
        public Boolean IsPlayer { get; set; }
        [Required]
        public int STR { get; set; }
        [Required]
        public int STA { get; set; }
        [Required]
        public int AGI { get; set; }
        [Required]
        public int DEX { get; set; }
        [Required]
        public int INT { get; set; }
        [Required]
        public int WIS { get; set; }
        [Required]
        public int CHA { get; set; }

    }
}
