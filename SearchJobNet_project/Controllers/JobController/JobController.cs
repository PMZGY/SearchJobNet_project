using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SearchJobNet_project.Controllers.JobController
{
    public class JobController : Controller
    {
        // 到JobList頁面
        public ActionResult Index()
        {
            return View("JobListView");
        }

        //到職缺細項頁面
        public ActionResult toJobDetailView()
        {
            return View("JobDetailView");
        }

        //到我的最愛頁面
        public ActionResult toMyFavoriteView()
        {
            return View("MyFavoriteView");
        }
    }
}