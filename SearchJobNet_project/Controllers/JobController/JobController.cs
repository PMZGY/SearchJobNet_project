using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SJM = SearchJobNet_project.Models.SearchJobModel;
<<<<<<< HEAD
=======
using SJ = SearchJobNet_project.Models.SearchJob;
>>>>>>> 558dfd82b539c9aaab03cfb1490c8af1354bef49
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
            SearchJob sm = new SearchJob();
            List<SJM.SearchJobModel> sjModel = new List<SJM.SearchJobModel>();
            sjModel = sm.jobList(searchModel);
            //return sjModel;
            return View("JobListView");
        }

        //到職缺細項頁面
        // 傳入 職缺PK,執行 [查看職缺細項] 功能
        // 回傳 整筆資料或部分資料(list的JobModel型態)
        public ActionResult toJobDetailView(int JobID)
        {
            SearchJob sm = new SearchJob();
            List<JM.JobModel> jmModel = new List<JM.JobModel>();
            jmModel = sm.jobDetail(JobID);
            //return jmModel;
            return View("JobDetailView");
        }

        //到我的最愛頁面
        public ActionResult toMyFavoriteView()
        {
            return View("MyFavoriteView");
        }

<<<<<<< HEAD
        // 傳入 搜尋職缺model,執行 [搜尋職缺] 功能
        // 回傳 職缺清單
        public List<SJM.SearchJobModel> jobList(SJM.SearchJobModel searchModel)
        {
            //SJ.SearchJob sm = new SJ.SearchJob();
            List<SJM.SearchJobModel> sjModel = new List<SJM.SearchJobModel>();
            //sjModel = sm.jobList(searchModel);
            return sjModel;
            //toJSON
        }
        

        // 傳入 職缺PK,執行 [職缺細項] 功能
        // 回傳 整筆資料或部分資料(list的JobModel型態)
        public List<JM.JobModel> jobDetail(int JobID)
        {
            JM.JobModel searchJob = new JM.JobModel();
            List<JM.JobModel> jmModel = new List<JM.JobModel>();
            //jmModel = searchJob.jobDetail(JobID);
            return jmModel;
        }
=======
        
>>>>>>> 558dfd82b539c9aaab03cfb1490c8af1354bef49
    }
}