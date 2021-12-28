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
    public class AdminUsersController : Controller
    {
        // GET: AdminUsers
        private IAdminUsersService _adminUsersService;
        public AdminUsersController(IAdminUsersService adminUsersService)
        {
            _adminUsersService = adminUsersService;
        }
        /// <summary>
        /// 查询管理员
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 查询管理员列表
        /// </summary>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public ActionResult GetList(int start, int length, string name)
        {
            int count = 0;
            var list = _adminUsersService.GetPageList(start, length, name, ref count);
            PageModel pageModel = new PageModel();
            pageModel.data = list;
            pageModel.recordsTotal = count;
            pageModel.recordsFiltered = count;
            return Json(pageModel);
        }
        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            return View();
        }
        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add_AdminUser(AdminUsersDTO admin)
        {
            var result = _adminUsersService.Add(admin);
            return Json(result);
        }
        /// <summary>
        /// 查询修改管理员id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(long id)
        {
            AdminUsersDTO dto = _adminUsersService.Edit(id);
            ViewBag.CityList = _adminUsersService.CityList();
            return View(dto);
        }
        /// <summary>
        /// 修改管理员
        /// </summary>
        /// <param name="adminUsers"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit_Per(AdminUsersDTO adminUsers)
        {
            var result = _adminUsersService.Edit(adminUsers);
            return Json(result);
        }
        /// <summary>
        /// 删除管理员
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(long id)
        {
            var result = _adminUsersService.Delete(id);
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
            var result = _adminUsersService.DeleteBatch(ids);
            return Json(result);
        }
    }
}