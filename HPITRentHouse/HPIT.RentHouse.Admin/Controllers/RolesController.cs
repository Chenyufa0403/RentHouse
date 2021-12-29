using HPIT.RentHouse.Admin.Models;
using HPIT.RentHouse.DTO;
using HPIT.RentHouse.lService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HPIT.RentHouse.Admin.Controllers
{
    public class RolesController : Controller
    {
        private IRolesService _rolesService;
        private IPermissionsService _permissionsService;
        public RolesController(IRolesService rolesService, IPermissionsService permissionsService)
        {
            _permissionsService = permissionsService;
            _rolesService = rolesService;
        }
        /// <summary>
        /// 查询角色
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 查询角色列表
        /// </summary>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public ActionResult GetList(int start, int length, string name)
        {
            //int start = 0;
            //int length = 12;
            //string name = "";
            int count = 0;
            var list = _rolesService.GetPageList(start, length, name, ref count);
            PageModel pageModel = new PageModel();
            pageModel.data = list;
            pageModel.recordsTotal = count;
            pageModel.recordsFiltered = count;
            return Json(pageModel);
        }
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            var per = _permissionsService.GetList();
            ViewBag.perList = per;
            return View();
        }
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add_Role(RolesEditDTO roles)
        {
            var result = _rolesService.Add(roles);
            return Json(result);
        }
        /// <summary>
        /// 查询修改角色id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(long id)
        {
            var per = _permissionsService.GetList();
            ViewBag.perList = per;
            RolesDTO dto = _rolesService.Edit(id);
            return View(dto);
        }
        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit_Per(RolesEditDTO roles)
        {
            var result = _rolesService.Edit(roles);
            return Json(result);
        }
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(long id)
        {
            var result = _rolesService.Delete(id);
            return Json(result);
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteBatch(List<long> ids)
        {
            var result = _rolesService.DeleteBatch(ids);
            return Json(result);
        }
    }
}