using System.Collections.Generic;

namespace SearchJobNet_project.Models.JobModel
{
    public class JobModel
    {
        ///<summary> 公司PK </summary>
        public string Comp_ID { get; set; }

        ///<summary> 公司名稱 </summary>
        public string CompName { get; set; }

        ///<summary> 職缺Pk </summary>
        public string Job_ID { get; set; }

        ///<summary> 職缺名稱 </summary>
        public string Occu_Desc { get; set; }

        ///<summary> 職缺性質 </summary>
        public string Wk_Type { get; set; }

        ///<summary> 職缺大類別代碼 </summary>
        public string Cjob_ID { get; set; }

        ///<summary> 職缺大類別名稱 </summary>
        public string Cjob_Name1 { get; set; }

        ///<summary> 工作地點 </summary>
        public string CityName { get; set; }

        ///<summary> 工作經驗 </summary>
        public string Experience { get; set; }

        ///<summary> 工作時間 </summary>
        public string WkTime { get; set; }

        ///<summary> 工作內容 </summary>
        public string Job_Detail { get; set; }

        ///<summary> 核薪方式 </summary>
        public string SalaryCd { get; set; }

        ///<summary> 最低學歷要求 </summary>
        public string EdGrDesc { get; set; }

        ///<summary> 職缺資料URL </summary>
        public string Url_Query { get; set; }

        ///<summary> 職缺更新日期 </summary>
        public string TranDate { get; set; }

        ///<summary> 雇用人數 </summary>
        public string AvailReqNum { get; set; }

        ///<summary> 應徵截止日期 </summary>
        public string Stop_Date { get; set; }

        

        //建立假資料,總共有兩筆資料
        //public JobModel()
        //{
        //}
    }
}