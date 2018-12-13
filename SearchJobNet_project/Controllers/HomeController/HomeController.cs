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
            string[] worktype = new string[]{};
            string[] cityname = new string[]{};
            string[] cjobname = new string[]{};
            worktype[0] = "全職";
            worktype[1] = "兼職";
            cityname[0] = "新北市";
            cityname[1] = "台北市";
            cjobname[0] = "電子/軟體/半導體";
            cjobname[1] = "批發/零售";
            cjobname[2] = "金融投顧及保險";
            cjobname[3] = "大眾傳播";
            ViewBag.WorkType = worktype; 
            ViewBag.CityName = worktype;
            ViewBag.Cjob_Name1 = worktype;
            return View("HomePageView");
        }

    }
}