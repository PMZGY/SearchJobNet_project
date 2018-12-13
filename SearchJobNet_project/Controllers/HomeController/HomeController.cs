using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SJM = SearchJobNet_project.Models.SearchJobModel;

namespace SearchJobNet_project.Controllers.HomeController
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {   
            // 搜尋職缺欄位內容種類
            SJM.SearchJob sjm = new SJM.SearchJob();
            List<SelectListItem> worktype = new List<SelectListItem>();
            List<SelectListItem> cityname = new List<SelectListItem>();
            List<SelectListItem> cjobname = new List<SelectListItem>();
            worktype.Add(new SelectListItem()
            {
                Text = "全職",
                Value = "0"
            });
            worktype.Add(new SelectListItem()
            {
                Text = "兼職",
                Value = "1"
            });
            cityname.Add(new SelectListItem()
            {
                Text = "新北市",
                Value = "0"
            });
            cityname.Add(new SelectListItem()
            {
                Text = "台北市",
                Value = "1"
            });
            cjobname.Add(new SelectListItem()
            {
                Text = "電子/軟體/半導體",
                Value = "0"
            });
            cjobname.Add(new SelectListItem()
            {
                Text = "批發/零售",
                Value = "1"
            });
            ViewBag.WorkType = worktype; 
            ViewBag.CityName = cityname;
            ViewBag.Cjob_Name1 = cjobname;
            return View("HomePageView");
        }

    }
}