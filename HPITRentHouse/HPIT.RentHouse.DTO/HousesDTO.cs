using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPIT.RentHouse.DTO
{
    public class HousesDTO
    {
        public long Id { get; set; }
        public string RoomTypeId { get; set; }
        public string CommunityId { get; set; }
        public string Address { get; set; }
        public int MonthRent { get; set; }
        public string StatusId { get; set; }
        public string DecorateStatusId { get; set; }
        public decimal Area { get; set; }
    }
}
