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
    public class SharingsController : Controller
    {
        // GET: Sharing
        private ISharingsService _sharingService;
        public SharingsController(ISharingsService sharingService)
        {
            _sharingService = sharingService;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetList(int start, int length, string name)
        {
            int count = 0;
            var list = _sharingService.GetPageList(start, length, name, ref count);
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
        public ActionResult Add_Houses(SharingsAddDTO sharing)
        {
            var result = _sharingService.Add(sharing);
            return Json(result);
        }
        public ActionResult Edit(long id)
        {
            WholesAddDTO dto = _sharingService.Edit(id);
            return View(dto);
        }
        [HttpPost]
        public ActionResult Edit_Per(SharingsAddDTO sharing)
        {
            var result = _sharingService.Edit(sharing);
            return Json(result);
        }
        [HttpPost]
        public ActionResult Delete(long id)
        {
            var result = _sharingService.Delete(id);
            return Json(result);
        }
        [HttpPost]
        public ActionResult DeleteBatch(List<long> ids)
        {
            var result = _sharingService.DeleteBatch(ids);
            return Json(result);
        }
    }
}