using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APII.Entities
{
    public abstract class EntityBase
    {
        [NotMapped]
        public virtual int Id { get; set; }
    }
}
