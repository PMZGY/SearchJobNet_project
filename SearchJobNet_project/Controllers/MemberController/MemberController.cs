using System.Web.Mvc;
using MM = SearchJobNet_project.Models.MemberModel;

namespace SearchJobNet_project.Controllers.MemberController
{
    public class MemberController : Controller
    {
        // 建立建構子
        public MemberController(){ }

        #region 會員功能(註冊/登入/忘記密碼)

        // 傳入 會員model,執行 [新增會員] 功能
        // 回傳 成功新增資料與否
        [HttpPost]
        public ActionResult registerMember(MM.MemberModel memberModel)
        {
            string msg = "";
            MM.Member mb = new MM.Member();
            msg = mb.registerMember(memberModel);
            return Content(msg);
        }

        // 傳入 會員model,執行 [登入會員] 功能
        // 回傳 會員model,判斷Session
        [HttpPost]
        public ActionResult loginMember(MM.MemberModel memberModel)
        {
            MM.MemberModel mbdata = new MM.MemberModel();
            MM.Member mb = new MM.Member();
            mbdata = mb.loginMember(memberModel);

            //儲存seesion userID ,如果沒登入則會存null
            Session["suserID"] = mbdata.User_ID;
            Session["suserName"] = mbdata.UserName;

            return Json(mbdata);            
        }

        #region[暫時先沒有忘記密碼功能]

        // 傳入 會員帳號,執行 [忘記密碼] 功能
        // 回傳 會員密碼
        public string forgetMember(int step ,string memberID ,string answer)
        {
            // step == 0 , 進行 傳入memberID 回傳問題 階段. (此時answer = "")
            // step == 1 , 進行 驗證答案是否正確 回傳密碼或驗證錯誤 階段

            // 產生member 物件
            MM.Member mb = new MM.Member();

            if (step == 0)
            {
                // 回傳 忘記密碼的問題
                string question = "";
                question = mb.forgetMember(0,memberID,"");
                return question;
            }
            else if (step == 1)
            {
                // 驗證 問題的答案 正確與否
                string result = "";
                result = mb.forgetMember(1,memberID,answer);
                return result;
            }
            else
            {
                return "input wrong parameter";
            }
        }
        #endregion

        #endregion
    }
}