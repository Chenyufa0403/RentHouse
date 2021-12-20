using HPIT.RentHouse.Common;
using HPIT.RentHouse.DTO;
using HPIT.RentHouse.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPIT.RentHouse.lService;

namespace HPIT.RentHouse.Service
{
    public class RolesService:IRolesService
    {
        public List<RolesDTO> GetList()
        {
            throw new NotImplementedException();
        }

        public List<RolesDTO> GetPageList(int start, int length, string name, ref int count)
        {
            var db = new RentHouseEntity();
            var bs = new BaseService<T_Roles>(db);
            var query = PredicateExtensions.True<T_Roles>();
            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.And(e => e.Name.Contains(name));
            }
            var list = bs.GetPagedList(start, length, ref count, query, a => a.Id);
            var result = list.Select(a => new RolesDTO
            {
                Id = a.Id,
                Name = a.Name
            }).ToList();
            return result;
        }
    }
}
