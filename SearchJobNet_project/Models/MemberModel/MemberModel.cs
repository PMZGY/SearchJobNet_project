using System.ComponentModel.DataAnnotations;

namespace SearchJobNet_project.Models.MemberModel
{
    public class MemberModel
    {
        ///<summary> 使用者ID </summary>
        [Required]
        [Display(Name = "使用者ID")]
        public string User_ID { get; set; }

        ///<summary> 使用者名稱 </summary>
        [Display(Name = "使用者名稱")]
        public string UserName { get; set; }

        ///<summary> 密碼 </summary>
        [Display(Name = "密碼")]
        public string PassWord { get; set; }

        ///<summary> 註冊日期 </summary>
        [Display(Name = "註冊日期")]
        public string Re_Time { get; set; }

        ///<summary> 驗證問題 </summary>
        //[Display(Name = "驗證問題")]
        //public string Change_Que { get; set; }

        ///<summary> 驗證答案 </summary>
        //[Display(Name = "驗證答案")]
        //public string Change_Ans { get; set; }
    }
}