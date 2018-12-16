using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SearchJobNet_project.Models.JobModel
{
    public class JobModel
    {
        ///<summary> 公司PK </summary>
        [Required]
        [Display(Name = "公司編號")]
        public string Comp_ID { get; set; }

        ///<summary> 公司名稱 </summary>
        [Display(Name = "公司名稱")]
        public string CompName { get; set; }

        ///<summary> 職缺Pk </summary>
        [Required]
        [Display(Name = "職缺編號")]
        public string Job_ID { get; set; }

        ///<summary> 職缺名稱 </summary>
        [Display(Name = "職缺名稱")]
        public string Occu_Desc { get; set; }

        ///<summary> 職缺性質 </summary>
        [Display(Name = "職缺性質")]
        public string Wk_Type { get; set; }

        ///<summary> 職缺大類別代碼 </summary>
        [Required]
        [Display(Name = "職缺大類別編號")]
        public string Cjob_ID { get; set; }

        ///<summary> 職缺大類別名稱 </summary>
        [Display(Name = "職缺大類別名稱")]
        public string Cjob_Name1 { get; set; }

        ///<summary> 工作地點 </summary>
        [Display(Name = "工作地點")]
        public string CityName { get; set; }

        ///<summary> 工作經驗 </summary>
        [Display(Name = "工作經驗")]
        public string Experience { get; set; }

        ///<summary> 工作時間 </summary>
        [Display(Name = "工作時間")]
        public string WkTime { get; set; }

        ///<summary> 工作內容 </summary>
        [Display(Name = "工作內容")]
        public string Job_Detail { get; set; }

        ///<summary> 核薪方式 </summary>
        [Display(Name = "核薪方式")]
        public string SalaryCd { get; set; }

        ///<summary> 最低學歷要求 </summary>
        [Display(Name = "最低學歷要求")]
        public string EdGrDesc { get; set; }

        ///<summary> 職缺資料URL </summary>
        [Display(Name = "職缺資料URL")]
        public string Url_Query { get; set; }

        ///<summary> 職缺更新日期 </summary>
        [Display(Name = "職缺更新日期")]
        public string TranDate { get; set; }

        ///<summary> 雇用人數 </summary>
        [Display(Name = "雇用人數")]
        public int AvailReqNum { get; set; }

        ///<summary> 應徵截止日期 </summary>
        [Display(Name = "應徵截止日期")]
        public string Stop_Date { get; set; }

        
    }
}