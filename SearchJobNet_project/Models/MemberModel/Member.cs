using MM = SearchJobNet_project.Models.MemberModel;

namespace SearchJobNet_project.Models.MemberModel
{
    public class Member
    {
        #region 會員功能(註冊/登入/忘記密碼)

        // 會員功能 註冊
        public string registerMember(MM.MemberModel rMember)
        {
            // 判斷 rMember的User_ID 是否在DB已重複
            // 重複 return "Account has been registered" ;

            // else 
            // SQL指令 塞入rMember
            return "insert data success";
        }

        // 會員功能 登入
        public string loginMember(MM.MemberModel lMember)
        {
            // SQL指令 撈出lMember的帳密
            // 比對密碼是不是一樣
            // 不一樣狀況 return "password is not correct!";

            // else
            return "login success";
        }

        // 會員功能 忘記密碼
        public string forgetMember(int step, string memberID, string answer)
        {
            // step == 0 , 進行 傳入memberID 回傳問題 階段. (此時answer = "")
            // step == 1 , 進行 驗證答案是否正確 回傳密碼或驗證錯誤 階段

            if (step == 0)
            {
                // SQL指令 撈出memberID的問題,並回傳問題
                return "Question";
            }
            else if (step == 1)
            {
                // 收到答案,比對答案是不是一樣
                // 不一樣狀況 return "the answer of question is wrong!";
                // else return 密碼
                return "password";
            }
            else
            {
                return "input wrong parameter";
            }

        }

        #endregion
    }
}