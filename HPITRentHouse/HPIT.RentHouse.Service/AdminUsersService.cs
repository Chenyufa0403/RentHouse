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
        public AjaxResult Add(AdminUsersDTO admin)
        {
            var db = new RentHouseEntity();
            var bs = new BaseService<T_AdminUsers>(db);
            T_AdminUsers users = new T_AdminUsers()
            {
                Id = admin.Id,
                Name = admin.Name,
                PhoneNum = admin.PhoneNum,
                PasswordHash = admin.PasswordHash,
                PasswordSalt = admin.PasswordSalt,
                Email = admin.Email,
                LoginErrorTimes = admin.LoginErrorTimes,
                LastLoginErrorDateTime = DateTime.Now,
                CityId = Convert.ToInt32(admin.CityId),
                CreateDateTime = DateTime.Now
            };
            long id = bs.Add(users);
            if (id > 0)
            {
                return new AjaxResult(ResultState.Success, "管理员添加成功");
            }
            else
            {
                return new AjaxResult(ResultState.Error, "管理员添加失败");
            }
        }
        public AdminUsersDTO Edit(long id)
        {
            var db = new RentHouseEntity();
            BaseService<T_AdminUsers> bs = new BaseService<T_AdminUsers>(db);
            T_AdminUsers model = bs.Get(a => a.Id == id);//少了个等于号，一个等于号是赋值，两个等于号是变量比较
            AdminUsersDTO dto = new AdminUsersDTO();
            if (model != null)
            {
                dto.Name = model.Name;
                dto.CityId = model.CityId.ToString();
                dto.Email = model.Email;
                dto.LoginErrorTimes = model.LoginErrorTimes;
                dto.PasswordHash = model.PasswordHash;
                dto.PasswordSalt = model.PasswordSalt;
                dto.PhoneNum = model.PhoneNum;
                dto.LastLoginErrorDateTime = Convert.ToInt32(model.LastLoginErrorDateTime);
            }
            return dto;
        }
    }
}
