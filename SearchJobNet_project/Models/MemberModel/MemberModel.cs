

namespace SearchJobNet_project.Models.MemberModel
{
    public class MemberModel
    {
        ///<summary> 會員帳號 </summary>
        public string memberAccount { get; set; }

        ///<summary> 會員密碼 </summary>
        public string memberPassword { get; set; }

        ///<summary> 會員名字 </summary>
        public string memberName { get; set; }

        // 塞入假資料
        public MemberModel()
        {
            this.memberAccount  = "A001";
            this.memberPassword = "6666";
            this.memberName     = "ponpon";
        }
    }
}