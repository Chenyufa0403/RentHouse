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
        public ActionResult Index()
        {
            IPermissionService permissionsService = new PermissionService();
            var list = permissionsService.GetList();
            return View();
        }
    }
}