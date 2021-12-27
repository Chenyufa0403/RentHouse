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
        public ActionResult Index()
        {
            return View();
        }

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
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add_AdminUser(AdminUsersDTO admin)
        {
            var add = _adminUsersService.Add(admin);
            return Json(add);
        }
        public ActionResult Edit(long id)
        {
            var model = _adminUsersService.Edit(id);
            return View(model);
        }
    }
}