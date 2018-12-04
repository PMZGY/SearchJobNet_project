using System;
using System.Web.Mvc;
using MM = SearchJobNet_project.Models.MemberModel;

namespace SearchJobNet_project.Controllers.MemberController
{
    public class MemberController : Controller
    {
        // 建立建構子
        public MemberController(){ }

        #region 會員功能(註冊/登入/忘記密碼)
        /// <summary> 判斷要做 會員功能 哪一項 </summary>
        /// <param actionPara = "R"> 註冊     </param>
        /// <param actionPara = "L"> 登入     </param>
        /// <param actionPara = "F"> 忘記密碼 </param>
        /// <returns></returns>

        public Boolean doMemberController(string actionPara)
        {
            // 回傳訊息成功與否
            Boolean msg = false;

            // 判斷要做哪一個功能
            switch (actionPara)
            {
                case "R":
                    MM.MemberModel
                    return false;
                
            }

            return msg;
        }
        #endregion
    }
}