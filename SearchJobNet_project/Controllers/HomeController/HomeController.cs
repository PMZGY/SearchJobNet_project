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
            ViewBag.WorkType = sjm.getWorkType(); 
            ViewBag.CityName = sjm.getCityName();
            ViewBag.Cjob_Name1 = sjm.getCjob_Name1();
            return View("HomePageView");
        }

    }
}