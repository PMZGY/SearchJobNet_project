using System.ComponentModel.DataAnnotations;

namespace SearchJobNet_project.Models.MemberModel
{
    public class MemberModel
    {
        ///<summary> 使用者PK </summary>
        [Required]
        [Display(Name = "使用者PK")]
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
        [Display(Name = "驗證問題")]
        public string Change_Que { get; set; }

        ///<summary> 驗證答案 </summary>
        [Display(Name = "驗證答案")]
        public string Change_Ans { get; set; }

        // 取出假資料,總共一筆
        public MemberModel getMemberData()
        {
            // 建立member model
            MemberModel result = new MemberModel();

            // 塞入假資料
            result.User_ID    = "A01";
            result.UserName   = "PONPON";
            result.PassWord   = "987945";
            result.Re_Time    = "20181208";
            result.Change_Que = "what is ur favorite color?";
            result.Change_Ans = "red";

            return result;
        }        
    }
}