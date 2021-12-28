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
        /// <summary>
        /// 查询管理员
        /// </summary>
        /// <returns></returns>
        public List<AdminUsersDTO> GetList()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 查询管理员列表
        /// </summary>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="name"></param>
        /// <param name="count"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 查询修改管理员id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
                dto.LastLoginErrorDateTime = DateTime.Now;
            }
            return dto;
        }
        /// <summary>
        /// 修改管理员
        /// </summary>
        /// <param name="adminUsers"></param>
        /// <returns></returns>
        public AjaxResult Edit(AdminUsersDTO adminUsers)
        {
            var db = new RentHouseEntity();
            BaseService<T_AdminUsers> bs = new BaseService<T_AdminUsers>(db);
            var model = bs.Get(a => a.Id == adminUsers.Id);

            model.Name = adminUsers.Name;
            model.LoginErrorTimes = adminUsers.LoginErrorTimes;
            model.PasswordHash = adminUsers.PasswordHash;
            model.PasswordSalt = adminUsers.PasswordSalt;
            model.PhoneNum = adminUsers.PhoneNum;
            model.CityId = Convert.ToInt32(adminUsers.CityId);
            model.Email = adminUsers.Email;
            bool res = bs.Update(model);
            if (res)
            {
                return new AjaxResult(ResultState.Success, "管理员修改成功");
            }
            else
            {
                return new AjaxResult(ResultState.Error, "管理员修改失败");
            }

        }
        /// <summary>
        /// 获取城市表字段
        /// </summary>
        /// <returns></returns>
        public List<CitiesDTO> CityList()
        {
            var db = new RentHouseEntity();
            var bs = new BaseService<T_Cities>(db);
            var list = bs.GetList(e => true).Select(e => new CitiesDTO
            {
                Id = e.Id,
                Name = e.Name
            }).ToList();
            return list;
        }
        /// <summary>
        /// 删除管理员
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AjaxResult Delete(long id)
        {
            var db = new RentHouseEntity();
            BaseService<T_AdminUsers> bs = new BaseService<T_AdminUsers>(db);
            var model = bs.Get(a => a.Id == id);
            if (bs.Delete(model))
            {
                return new AjaxResult(ResultState.Success, "权限删除成功");
            }
            else
            {
                return new AjaxResult(ResultState.Error, "权限删除失败");
            }
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public AjaxResult DeleteBatch(List<long> ids)
        {
            try
            {
                var db = new RentHouseEntity();
                BaseService<T_AdminUsers> bs = new BaseService<T_AdminUsers>(db);
                foreach (var id in ids)
                {
                    var model = bs.Get(a => a.Id == id);
                    bs.Delete(model);
                }
                return new AjaxResult(ResultState.Success, "权限删除成功");
            }
            catch (Exception)
            {
                return new AjaxResult(ResultState.Error, "权限删除失败");
            }
        }
    }
}
