using HPIT.RentHouse.DTO;
using HPIT.RentHouse.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HPIT.RentHouse.Web.Controllers
{
    public class HouseController : Controller
    {
        private readonly IHousesService _housesService;
        private readonly IAdminUsersService _adminUsersService;
        private readonly IRegionService _regionService;
        private readonly IHouseAppointmentService _houseAppointmentService;

        public HouseController(IHousesService houseService, IAdminUsersService adminUsersService,
                                IRegionService regionService, IHouseAppointmentService houseAppointmentService)
        {
            _housesService = houseService;
            _adminUsersService = adminUsersService;
            _regionService = regionService;
            _houseAppointmentService = houseAppointmentService;
        }

        /// <summary>
        /// 房源搜索
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Search(HouseSearchOptions options)
        {
            //默认城市
            var cityList = _adminUsersService.CityList();
            options.CityId = cityList.FirstOrDefault().Id;

            ViewBag.DefaultCity = cityList.FirstOrDefault().Name;
            ViewBag.RegionList = _regionService.GetRegionList(cityList.FirstOrDefault().Id);


            //月租条件处理
            if (!string.IsNullOrWhiteSpace(options.MonthRent))
            {
                var strMonthRent = options.MonthRent.Split('-');

                if (strMonthRent[0] != "*")
                {
                    options.StartMonthRent = Convert.ToInt32(strMonthRent[0]);
                }

                if (strMonthRent[1] != "*")
                {
                    options.EndMonthRent = Convert.ToInt32(strMonthRent[1]);
                }
            }


            var list = _housesService.Search(options);
            return View(list);
        }
        public ActionResult Detail(int id)
        {
            var model = _housesService.GetHouseDetail(id);
            return View(model);
        }
    }
}