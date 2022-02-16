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
    public class ShortsController : Controller
    {
        // GET: Shorts
        private IShortsService _shortsService;
        public ShortsController(IShortsService shortsService)
        {
            _shortsService = shortsService;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetList(int start, int length, string name)
        {
            int count = 0;
            var list = _shortsService.GetPageList(start, length, name, ref count);
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
        public ActionResult Add_Houses(ShortsAddDTO shorts)
        {
            var result = _shortsService.Add(shorts);
            return Json(result);
        }
        public ActionResult Edit(long id)
        {
            ShortsAddDTO dto = _shortsService.Edit(id);
            return View(dto);
        }
        [HttpPost]
        public ActionResult Edit_Per(ShortsAddDTO shorts)
        {
            var result = _shortsService.Edit(shorts);
            return Json(result);
        }
        [HttpPost]
        public ActionResult Delete(long id)
        {
            var result = _shortsService.Delete(id);
            return Json(result);
        }
        [HttpPost]
        public ActionResult DeleteBatch(List<long> ids)
        {
            var result = _shortsService.DeleteBatch(ids);
            return Json(result);
        }
    }
}