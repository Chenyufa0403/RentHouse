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
    public class RolesService : IRolesService
    {
        /// <summary>
        /// 查询角色
        /// </summary>
        /// <returns></returns>
        public List<RolesDTO> GetList()
        {
            var db = new RentHouseEntity();
            BaseService<T_Roles> bs = new BaseService<T_Roles>(db);
            var list = bs.GetList(e => true).Select(e => new RolesDTO
            {
                Id = e.Id,
                Name = e.Name
            }).ToList();
            return list;
        }
        /// <summary>
        /// 查询角色列表
        /// </summary>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="name"></param>
        /// <param name="count"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public AjaxResult Add(RolesEditDTO roles)
        {
            var db = new RentHouseEntity();
            var bs = new BaseService<T_Roles>(db);
            var bsp = new BaseService<T_Permissions>(db);
            var role = new T_Roles();
            role.Name = roles.Name;
            role.CreateDateTime = DateTime.Now;
            if (roles.PermissionsIds != null && roles.PermissionsIds.Count > 0)
            {
                foreach (var ids in roles.PermissionsIds)
                {
                    T_Permissions permissions = bsp.Get(p => p.Id == ids);
                    role.T_Permissions.Add(permissions);
                }
            }
            long id = bs.Add(role);
            if (id > 0)
            {
                return new AjaxResult(ResultState.Success, "角色添加成功");
            }
            else
            {
                return new AjaxResult(ResultState.Error, "角色添加失败");
            }
        }
        /// <summary>
        /// 查询角色id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RolesEditDTO Edit(long id)
        {
            var db = new RentHouseEntity();
            BaseService<T_Roles> bs = new BaseService<T_Roles>(db);
            T_Roles model = bs.Get(a => a.Id == id);//少了个等于号，一个等于号是赋值，两个等于号是变量比较
            RolesEditDTO dto = new RolesEditDTO();
            if (model != null)
            {
                dto.Name = model.Name;
                dto.PermissionsIds = model.T_Permissions.Select(t => t.Id).ToList();
            }
            return dto;
        }
        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public AjaxResult Edit(RolesEditDTO roles)
        {
            var db = new RentHouseEntity();
            BaseService<T_Roles> bs = new BaseService<T_Roles>(db);
            var bsp = new BaseService<T_Permissions>(db);
            var model = bs.Get(a => a.Id == roles.Id);
            model.Name = roles.Name;
            model.T_Permissions.Clear();
            if (roles.PermissionsIds != null && roles.PermissionsIds.Count > 0)
            {
                foreach (var ids in roles.PermissionsIds)
                {
                    T_Permissions permissions = bsp.Get(p => p.Id == ids);
                    model.T_Permissions.Add(permissions);
                }
            }
            bool res = bs.Update(model);
            if (res)
            {
                return new AjaxResult(ResultState.Success, "角色修改成功");
            }
            else
            {
                return new AjaxResult(ResultState.Error, "角色修改失败");
            }
        }
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AjaxResult Delete(long id)
        {
            var db = new RentHouseEntity();
            BaseService<T_Roles> bs = new BaseService<T_Roles>(db);
            var model = bs.Get(r => r.Id == id);
            if (bs.Delete(model))
            {
                return new AjaxResult(ResultState.Success, "角色删除成功");
            }
            else
            {
                return new AjaxResult(ResultState.Error, "角色删除失败");
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
                BaseService<T_Roles> bs = new BaseService<T_Roles>(db);
                foreach (var id in ids)
                {
                    var model = bs.Get(r => r.Id == id);
                    bs.Delete(model);
                }
                return new AjaxResult(ResultState.Success, "角色删除成功");
            }
            catch (Exception)
            {
                return new AjaxResult(ResultState.Error, "角色删除失败");
            }
        }
    }
}
