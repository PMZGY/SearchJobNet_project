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
            SJM.SearchJob sjm = new SJM.SearchJob();
            List<SJM.SearchJobModel> sjModel = new List<SJM.SearchJobModel>();
            sjModel = sjm.jobList(searchModel);
            //return sjModel;
            List<SJM.SearchJobModel> list = new List<SJM.SearchJobModel>() {
                new SJM.SearchJobModel() {Comp_ID=1,CompName="台積電",Job_ID=250,CityName="新北市",Occu_Desc="前端工程師",Wk_Type="全職",Cjob_ID=1,Cjob_Name1="程式設計師"},
                new SJM.SearchJobModel() {Comp_ID=2,CompName="鴻海",Job_ID=300,CityName="台北市",Occu_Desc="後端工程師",Wk_Type="兼職",Cjob_ID=1,Cjob_Name1="程式設計師"}
            };

            return View("JobListView", this.Json(list));
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