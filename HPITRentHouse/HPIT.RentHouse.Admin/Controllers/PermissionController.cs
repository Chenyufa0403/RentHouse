using HPIT.RentHouse.Admin.Models;
using HPIT.RentHouse.lService;
using HPIT.RentHouse.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HPIT.RentHouse.Admin.Controllers
{
    public class PermissionController : Controller
    {
        private IPermissionService _permissionService;
        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }
        //public ActionResult Index()
        //{
        //    IPermissionService permissionsService = new PermissionService();
        //    return View();
        //}
        public ActionResult Index()
        {
            //IPermissionService permissionsService = new PermissionService();
            var list = _permissionService.GetList();
            return View();
        }

        public ActionResult GetList(int start, int length, string name)
        {
            //int start = 0;
            //int length = 12;
            //string name = "";
            int count = 0;
            var list = _permissionService.GetPageList(start, length, name, ref count);
            PageModel pageModel = new PageModel();
            pageModel.data = list;
            pageModel.recordsTotal = count;
            pageModel.recordsFiltered = count;
            return Json(pageModel);
        }





    }
}