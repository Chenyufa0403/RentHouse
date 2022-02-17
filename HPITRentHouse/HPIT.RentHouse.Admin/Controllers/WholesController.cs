﻿using HPIT.RentHouse.Admin.Models;
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
    public class WholesController : Controller
    {
        // GET: House
        private IWholesService _housesService;
        public WholesController(IWholesService housesService)
        {
            _housesService = housesService;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetList(int start, int length, string name)
        {
            int count = 0;
            var list = _housesService.GetPageList(start, length, name, ref count);
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
        public ActionResult Add_Houses(WholesAddDTO houses)
        {
            var result = _housesService.Add(houses);
            return Json(result);
        }
        public ActionResult Edit(long id)
        {
            WholesAddDTO dto = _housesService.Edit(id);
            return View(dto);
        }
        [HttpPost]
        public ActionResult Edit_Per(WholesAddDTO houses)
        {
            var result = _housesService.Edit(houses);
            return Json(result);
        }
        [HttpPost]
        public ActionResult Delete(long id)
        {
            var result = _housesService.Delete(id);
            return Json(result);
        }
        [HttpPost]
        public ActionResult DeleteBatch(List<long> ids)
        {
            var result = _housesService.DeleteBatch(ids);
            return Json(result);
        }
    }
}