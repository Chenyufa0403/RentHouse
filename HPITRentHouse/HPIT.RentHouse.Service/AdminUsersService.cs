using HPIT.RentHouse.Common;
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
    public class AdminUsersService : IAdminUsersService
    {
        public List<AdminUsersDTO> GetList()
        {
            throw new NotImplementedException();
        }

        public List<AdminUsersDTO> GetPageList(int start, int length, string name, ref int count)
        {
            var db = new RentHouseEntity();
            var bs = new BaseService<T_AdminUsers>(db);
            var query = PredicateExtensions.True<T_AdminUsers>();
            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.And(e => e.Name.Contains(name));
            }
            var list = bs.GetPagedList(start, length, ref count, query, a => a.Id);
            var result = list.Select(a => new AdminUsersDTO
            {
                Id = a.Id,
                Name = a.Name,
                PhoneNum = a.PhoneNum,
                Email = a.Email,
                LoginErrorTimes = a.LoginErrorTimes,
                CityId = a.T_Cities.Name
            }).ToList();
            return result;
        }
    }
}
