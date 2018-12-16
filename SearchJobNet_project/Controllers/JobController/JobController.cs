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
            ViewBag.CityName = searchModel.CityName;
            ViewBag.Wk_Type = searchModel.Wk_Type;
            ViewBag.CompName = searchModel.CompName;
            ViewBag.Cjob_Name1 = searchModel.Cjob_Name1;

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

            //for test 12/16

        //public ActionResult toJobDetailView(string jobID)
        public ActionResult toJobDetailView()
        {
            SJM.SearchJob sjm = new SJM.SearchJob();
            JM.JobModel jmModel = new JM.JobModel();
            //jmModel = sjm.jobDetail(jobID);
            jmModel = sjm.jobDetail("111");
            
            return View("JobDetailView", jmModel);
        }

        //到我的最愛頁面
        public ActionResult toMyFavoriteView(string user_ID )
        {
            SJM.SearchJob sjm = new SJM.SearchJob();
            List<SJM.SearchJobModel> sjModel = new List<SJM.SearchJobModel>();
            sjModel = sjm.myFavorite(user_ID);

            return Json(this.Json(sjModel), JsonRequestBehavior.AllowGet);
            //return View("MyFavoriteView");
        }

        // 傳入 使用者ID與職缺ID,執行 [加到我的最愛] 功能
        // 回傳 成功新增資料與否
        [HttpPost]
        public ActionResult insertMyFavorite(string user_ID , string job_ID)
        {
            string msg = "";
            SJM.SearchJob sjm = new SJM.SearchJob();
            msg = sjm.insertMyFavorite(user_ID, job_ID);
            return Content(msg);
        }

    }
}