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
        public RolesController(IRolesService rolesService)
        {
            _rolesService = rolesService;
        }
        public ActionResult Index()
        {
            return View();
        }

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
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add_Role(RolesDTO roles)
        {
            var add = _rolesService.Add(roles);
            return Json(add);
        }
        public ActionResult Edit(long id)
        {
            RolesDTO dto = _rolesService.Edit(id);
            return View(dto);
        }
        [HttpPost]
        public ActionResult Edit_Per(RolesDTO roles)
        {
            var ad = _rolesService.Edit(roles);
            return Json(ad);
        }
    }
}