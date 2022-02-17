using HPIT.RentHouse.Admin.Models;
using HPIT.RentHouse.lService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HPIT.RentHouse.Admin.Controllers
{
    [Authorize]
    public class HousesController : Controller
    {
        // GET: Houses
        private readonly IHousesService _housesService;
        public HousesController(IHousesService housesService)
        {
            _housesService = housesService;
        }
        /// <summary>
        /// 加载房源列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(int typeId)
        {
            ViewBag.typeId = typeId;
            return View();
        }

        /// <summary>
        /// 获取房源分页数据
        /// </summary>
        /// <param name="communityName"></param>
        /// <param name="typeId"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetHouseList(string communityName, int typeId, int start, int length)
        {
            int count = 0;
            var list = _housesService.GetHouseList(communityName, typeId, start, length, ref count);
            PageModel pageModel = new PageModel();
            pageModel.data = list;
            pageModel.recordsTotal = count;
            pageModel.recordsFiltered = count;
            return Json(pageModel);
        }
    }
}