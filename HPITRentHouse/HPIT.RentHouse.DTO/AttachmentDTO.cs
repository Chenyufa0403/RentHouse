using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPIT.RentHouse.DTO
{
    [Serializable]
    public class AttachmentDTO
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string IconName { get; set; }
    }
}
