using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SJ = SearchJobNet_project.Models.SearchJob;

namespace SearchJobNet_project.Controllers.HomeController
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {   
            // 搜尋職缺欄位內容種類
            SJ.SearchJob searchJob = new SJ.SearchJob();
            searchJob.getJobKind();
            return View("HomePageView");
        }

    }
}