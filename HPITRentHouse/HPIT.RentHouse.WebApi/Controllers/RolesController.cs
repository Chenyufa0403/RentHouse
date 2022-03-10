using HPIT.RentHouse.Common;
using HPIT.RentHouse.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HPIT.RentHouse.WebApi.Models;
using HPIT.RentHouse.DTO;

namespace HPIT.RentHouse.WebApi.Controllers
{
    public class RolesController : ApiController
    {
        /// <summary>
        /// 根据id获取角色信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public AjaxResult Get(int id)
        {
            RolesService rolesService = new RolesService();
            var role = rolesService.Edit(id);
            return new AjaxResult(ResultState.Success, "", role);
        }
        /// <summary>
        /// 获取角色列表信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public AjaxResult GetList()
        {
            RolesService rolesService = new RolesService();
            var list = rolesService.GetList();
            return new AjaxResult(ResultState.Success, "", list);
        }
        /// <summary>
        /// 获取角色分页列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public AjaxResult GetPageList(int start, int length, string name)
        {
            RolesService rolesService = new RolesService();
            int count = 0;
            var list = rolesService.GetPageList(start, length, name, ref count);
            PageModel pageModel = new PageModel();
            pageModel.data = list;
            pageModel.recordsTotal = count;
            pageModel.recordsFiltered = count;
            return new AjaxResult(ResultState.Success, "", pageModel);
        }
        /// <summary>
        /// 获取角色分页列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public AjaxResult GetPageList([FromUri] RoleParaModel model)
        {
            RolesService rolesService = new RolesService();
            int count = 0;
            var list = rolesService.GetPageList(model.start, model.length, model.name, ref count);
            PageModel pageModel = new PageModel();
            pageModel.data = list;
            pageModel.recordsTotal = count;
            pageModel.recordsFiltered = count;
            return new AjaxResult(ResultState.Success, "", pageModel);
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public AjaxResult DeleteRole(long id)
        {
            RolesService rolesService = new RolesService();
            var result = rolesService.Delete(id);
            return result;
        }
        [HttpPost]
        public AjaxResult DeleteBatch([FromBody]List<long> ids)
        {
            RolesService rolesService = new RolesService();
            var result = rolesService.DeleteBatch(ids);
            return result;
        }
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public AjaxResult AddRole([FromBody] RolesEditDTO dto)
        {
            RolesService rolesService = new RolesService();
            var result = rolesService.Add(dto);
            return result;
        }
    }
}
