using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SearchJobNet_project.Models.SearchJobModel
{
    public class SearchJobModel
    {
        ///<summary> 公司PK </summary>
        [Required]
        [Display(Name = "公司編號")]
        public string Comp_ID { get; set; }

        ///<summary> 公司名稱 </summary>
        [Display(Name = "公司名稱")]
        public string CompName { get; set; }

        ///<summary> 工作地點 </summary>
        [Display(Name = "工作地點")]
        public string CityName { get; set; }

        ///<summary> 職缺Pk </summary>
        [Required]
        [Display(Name = "職缺編號")]
        public string Job_ID { get; set; }
       
        ///<summary> 職缺名稱 </summary>
        [Display(Name = "職缺名稱")]
        public string Occu_Desc { get; set; }

        ///<summary> 職缺性質_全職 </summary>
        public bool Wk_Type_All { get; set; }

        ///<summary> 職缺性質_兼職 </summary>
        public bool Wk_Type_Part { get; set; }

        ///<summary> 職缺大類別代碼 </summary>
        [Display(Name = "職缺大類別編號")]
        public string Cjob_ID { get; set; }

        ///<summary> 職缺大類別名稱 </summary>
        [Display(Name = "職缺大類別名稱")]
        public string Cjob_Name1 { get; set; }

        ///<summary> 工作經驗 </summary>
        ///public string Experience { get; set; }

        ///<summary> 工作時間 </summary>
        ///public string WkTime { get; set; }

        //建立假資料,總共有兩筆資料
        //public SearchJobModel()
        //{
        //}
    }
}