using HPIT.RentHouse.DTO;
using HPIT.RentHouse.lService;
using HPIT.RentHouse.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPIT.RentHouse.Service
{
    public class PermissionService : IPermissionService
    {
        public List<PermissionDTO> GetList()
        {
            var db = new RentHouseEntity();
            BaseService<T_Permissions> bs = new BaseService<T_Permissions>(db);
            var list = bs.GetList(e => true).Select(e => new PermissionDTO
            {
                Description = e.Description,
                Id = e.Id,
                Name = e.Name
            }).ToList();
            return list;
        }
    }
}
