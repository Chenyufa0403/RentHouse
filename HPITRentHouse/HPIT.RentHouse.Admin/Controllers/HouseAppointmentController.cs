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
    [Authorize]
    public class HouseAppointmentController : Controller
    {
        private readonly IHouseAppointmentService _houseAppointmentService;

        public HouseAppointmentController(IHouseAppointmentService houseAppointmentService)
        {
            _houseAppointmentService = houseAppointmentService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetList(int start, int length)
        {
            //1、接口层写分页空方法
            //2、service实现接口方法
            //3、控制器调用
            int count = 0;
            var list = _houseAppointmentService.GetPageList(start, length, ref count);
            PageModel pageModel = new PageModel();
            pageModel.data = list;
            pageModel.recordsTotal = count;
            pageModel.recordsFiltered = count;
            return Json(pageModel);
        }

        /// <summary>
        /// 业务员接单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Follow(long id)
        {
            MyFormsPrincipal<LoginAdminDTO> user = User as MyFormsPrincipal<LoginAdminDTO>;
            var result = _houseAppointmentService.Follow(id, user.UserData.Id);
            return Json(result);
        }
    }
}