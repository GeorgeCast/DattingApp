using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APII.Entities
{
    public class AppUser : EntityBase
    {
        public override int Id { get; set; }

        public string UserName { get; set; }
    }
}
