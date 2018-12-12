using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SJM = SearchJobNet_project.Models.SearchJobModel;
using Tools = SearchJobNet_project.Tools;

namespace SearchJobNet_project.Models.SearchJobModel
{
    public class SearchJob
    {
        
        //建立假資料
        // 取出假資料
        public List<SJM.SearchJobModel> getJobKind()
        {
            // 建立list
            List<SJM.SearchJobModel> jobKind = new List<SJM.SearchJobModel>();
            // 塞入 假資料
            
            string[] CityNameTest = { "新北市", "台北市" };
            string[] Wk_TypeTest = { "全職", "兼職" };
            jobKind.Add(new SearchJobModel
            {
                CityName = CityNameTest,
                Wk_Type  = Wk_TypeTest

            });
            return jobKind;
        }

        // 搜尋職缺清單
        public string jobList(SJM.SearchJobModel sjm)
        {
            // SQL指令 撈出職缺清單
            return "清單";
        }

        // 搜尋職缺細項
        public string jobDetail(SJM.SearchJobModel sJob)
        {
            // SQL指令 撈出職缺清單
            return "清單";
        }
        
    }
}