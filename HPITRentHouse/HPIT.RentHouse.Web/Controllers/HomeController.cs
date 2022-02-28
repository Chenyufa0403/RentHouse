using HPIT.RentHouse.lService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HPIT.RentHouse.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAdminUsersService _adminUsersService;
        private readonly IHousesService _housesService;
        public HomeController(IAdminUsersService adminUsersService, IHousesService housesService)
        {
            _adminUsersService = adminUsersService;
            _housesService = housesService;
        }
        public ActionResult Index(int cityId = 0)
        {
            var list = _adminUsersService.CityList();
            ViewBag.CityListName = list;
            if (cityId > 0)
            {
                ViewBag.DefaultCity = list.Where(e => e.Id == cityId).FirstOrDefault().Name;
            }
            else
            {
                ViewBag.DefaultCity = list.FirstOrDefault().Name;
            }
            return View();
        }
    }
}