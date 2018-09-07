namespace Solinia.Database.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("World")]
    public partial class World : ISavable
    {
        public long Id { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }
    }
}
