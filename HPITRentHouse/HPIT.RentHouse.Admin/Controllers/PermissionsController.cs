using HPIT.RentHouse.Admin.Models;
using HPIT.RentHouse.DTO;
using HPIT.RentHouse.lService;
using HPIT.RentHouse.Service;
using HPIT.RentHouse.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HPIT.RentHouse.Admin.Controllers
{
    public class PermissionsController : Controller
    {
        private IPermissionsService _permissionsService;
        public PermissionsController(IPermissionsService permissionsService)
        {
            _permissionsService = permissionsService;
        }
        //public ActionResult Index()
        //{
        //    IPermissionService permissionsService = new PermissionService();
        //    return View();
        //}
        /// <summary>
        /// 查询权限
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //IPermissionService permissionsService = new PermissionService();
            var list = _permissionsService.GetList();
            return View();
        }
        /// <summary>
        /// 查询权限列表
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
            var list = _permissionsService.GetPageList(start, length, name, ref count);
            PageModel pageModel = new PageModel();
            pageModel.data = list;
            pageModel.recordsTotal = count;
            pageModel.recordsFiltered = count;
            return Json(pageModel);
        }
        /// <summary>
        /// 添加权限
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            return View();
        }
        /// <summary>
        /// 添加权限节点
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add_Per(PermissionsDTO permission)
        {
            var result = _permissionsService.Add(permission);
            return Json(result);
        }
        /// <summary>
        /// 查询修改权限id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(long id)
        {
            PermissionsDTO dto = _permissionsService.Edit(id);
            return View(dto);
        }
        /// <summary>
        /// 修改权限
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit_Per(PermissionsDTO dto)
        {
            var result = _permissionsService.Edit(dto);
            return Json(result);
        }
        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(long id)
        {
            var result = _permissionsService.Delete(id);
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
            var result = _permissionsService.DeleteBatch(ids);
            return Json(result);
        }
    }
}