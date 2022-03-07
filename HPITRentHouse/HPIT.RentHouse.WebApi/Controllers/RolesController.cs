using HPIT.RentHouse.Common;
using HPIT.RentHouse.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
    }
}
