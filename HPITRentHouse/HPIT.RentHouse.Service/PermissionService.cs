﻿using HPIT.RentHouse.Common;
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
        public List<PermissionDTO> GetPageList(int start, int length, string name, ref int count)
        {
            var db = new RentHouseEntity();
            var bs = new BaseService<T_Permissions>(db);
            var query = PredicateExtensions.True<T_Permissions>();
            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.And(e => e.Name.Contains(name));
            }
            var list = bs.GetPagedList(start, length, ref count, query, a => a.Id);
            var result = list.Select(a => new PermissionDTO
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description
            }).ToList();
            return result;
        }
        public AjaxResult Add(PermissionDTO permission)
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
    }
}
