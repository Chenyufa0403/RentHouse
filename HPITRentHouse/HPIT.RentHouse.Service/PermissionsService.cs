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
    public class PermissionsService : IPermissionsService
    {
        /// <summary>
        /// 查询权限
        /// </summary>
        /// <returns></returns>
        public List<PermissionsDTO> GetList()
        {
            var db = new RentHouseEntity();
            BaseService<T_Permissions> bs = new BaseService<T_Permissions>(db);
            var list = bs.GetList(e => true).Select(e => new PermissionsDTO
            {
                Description = e.Description,
                Id = e.Id,
                Name = e.Name
            }).ToList();
            return list;
        }
        /// <summary>
        /// 查询权限列表
        /// </summary>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="name"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<PermissionsDTO> GetPageList(int start, int length, string name, ref int count)
        {
            var db = new RentHouseEntity();
            var bs = new BaseService<T_Permissions>(db);
            var query = PredicateExtensions.True<T_Permissions>();
            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.And(e => e.Name.Contains(name));
            }
            var list = bs.GetPagedList(start, length, ref count, query, a => a.Id);
            var result = list.Select(a => new PermissionsDTO
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description
            }).ToList();
            return result;
        }
        /// <summary>
        /// 添加权限节点
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        public AjaxResult Add(PermissionsDTO permission)
        {
            var db = new RentHouseEntity();
            var bs = new BaseService<T_Permissions>(db);
            T_Permissions permissions = new T_Permissions();
            permissions.Name = permission.Name;
            permissions.Description = permission.Description;
            permissions.CreateDateTime = DateTime.Now;
            long id = bs.Add(permissions);
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
        /// 查询修改权限id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PermissionsDTO Edit(long id)
        {
            var db = new RentHouseEntity();
            BaseService<T_Permissions> bs = new BaseService<T_Permissions>(db);
            T_Permissions model = bs.Get(a => a.Id == id);//少了个等于号，一个等于号是赋值，两个等于号是变量比较
            PermissionsDTO dto = new PermissionsDTO();
            if (model != null)
            {
                dto.Name = model.Name;
                dto.Description = model.Description;
            }
            return dto;
        }
        /// <summary>
        /// 修改权限
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        public AjaxResult Edit(PermissionsDTO permission)
        {
            var db = new RentHouseEntity();
            BaseService<T_Permissions> bs = new BaseService<T_Permissions>(db);
            var model = bs.Get(a => a.Id == permission.Id);
            model.Name = permission.Name;
            model.Description = permission.Description;
            bool res = bs.Update(model);
            if (res)
            {
                return new AjaxResult(ResultState.Success, "权限修改成功");
            }
            else
            {
                return new AjaxResult(ResultState.Error, "权限修改失败");
            }
        }
        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AjaxResult Delete(long id)
        {
            var db = new RentHouseEntity();
            BaseService<T_Permissions> bs = new BaseService<T_Permissions>(db);
            var model = bs.Get(p => p.Id == id);
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
                BaseService<T_Permissions> bs = new BaseService<T_Permissions>(db);
                foreach (var id in ids)
                {
                    var model = bs.Get(p => p.Id == id);
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
