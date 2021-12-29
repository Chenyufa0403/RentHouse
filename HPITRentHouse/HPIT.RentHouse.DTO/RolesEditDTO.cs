using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPIT.RentHouse.DTO
{
    public class RolesEditDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<long> PermissionsIds { get; set; }

    }
}
