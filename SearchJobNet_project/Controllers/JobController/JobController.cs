using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SJM = SearchJobNet_project.Models.SearchJobModel;
using JM = SearchJobNet_project.Models.JobModel;

namespace SearchJobNet_project.Controllers.JobController
{
    public class JobController : Controller
    {
        // 到JobList頁面
        // 傳入 搜尋職缺model,執行 [查看職缺清單] 功能
        // 回傳 職缺清單
        public ActionResult Index(SJM.SearchJobModel searchModel)
        {
            //SJM.SearchJob sjm = new SJM.SearchJob();
            //List<SJM.SearchJobModel> sjModel = new List<SJM.SearchJobModel>();
            //sjModel = sjm.jobList(searchModel);
            ViewBag.SearchJobCol = searchModel;
            return View("JobListView");
        }
        public ActionResult SendJobListData(SJM.SearchJobModel searchModel)
        {
            SJM.SearchJob sjm = new SJM.SearchJob();
            List<SJM.SearchJobModel> sjModel = new List<SJM.SearchJobModel>();
            sjModel = sjm.jobList(searchModel);

            return Json(this.Json(sjModel),JsonRequestBehavior.AllowGet);
        }

        //到職缺細項頁面
        // 傳入 職缺PK,執行 [查看職缺細項] 功能
        // 回傳 整筆資料或部分資料(list的JobModel型態)
        public ActionResult toJobDetailView(int JobID)
        {
            SJM.SearchJob sjm = new SJM.SearchJob();
            List<JM.JobModel> jmModel = new List<JM.JobModel>();
            jmModel = sjm.jobDetail(JobID);
            //return jmModel;
            return View("JobDetailView", jmModel);
        }

        //到我的最愛頁面
        public ActionResult toMyFavoriteView()
        {
            return View("MyFavoriteView");
        }


    }
}