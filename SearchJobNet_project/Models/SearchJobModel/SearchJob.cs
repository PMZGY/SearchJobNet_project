using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SearchJobNet_project.Models.JobModel;
using SJM = SearchJobNet_project.Models.SearchJobModel;
using JM = SearchJobNet_project.Models.JobModel;
using Tools = SearchJobNet_project.Tools;

namespace SearchJobNet_project.Models.SearchJobModel
{
    public class SearchJob
    {
        
        //建立假資料
        // 取出假資料
        public String[] getJobKind()
        {
            String[] jobKindd = new String[] { };
            
            // 建立list
            List<SJM.SearchJobModel> jobKind = new List<SJM.SearchJobModel>();
           // 塞入 假資料
            
            string[] CityNameTest = { "新北市", "台北市" };
            string[] Wk_TypeTest = { "全職", "兼職" };
            jobKind.Add(new SearchJobModel
            {
               // CityName = CityNameTest,
               // Wk_Type  = Wk_TypeTest
            });

            
            return jobKindd;
        }

        // 搜尋職缺清單
        public List<SJM.SearchJobModel> jobList(SJM.SearchJobModel sjm)
        {
            //List<SJM.SearchJobModel> sjmModel = new List<SJM.SearchJobModel>();
            // SQL指令 撈出職缺清單
            List<SJM.SearchJobModel> sjmModel = new List<SJM.SearchJobModel>()
            {
                new SearchJobModel(){Comp_ID=1,CompName="台積電",Job_ID=250,CityName="新北市",Occu_Desc="前端工程師",Wk_Type="全職",Cjob_ID=1,Cjob_Name1="程式設計師"},
                new SearchJobModel(){Comp_ID=2,CompName="鴻海",Job_ID=300,CityName="台北市",Occu_Desc="後端工程師",Wk_Type="兼職",Cjob_ID=1,Cjob_Name1="程式設計師"}
            };
            return sjmModel;
        }
        

        // 搜尋職缺細項
        public List<JM.JobModel> jobDetail(int jobID)
        {
            List<JM.JobModel> jmModel = new List<JM.JobModel>();
            // SQL指令 撈出職缺清單
            return jmModel;
        }
        
    }
}