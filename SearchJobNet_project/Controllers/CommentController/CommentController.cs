using System.Collections.Generic;
using System.Web.Mvc;
using CM = SearchJobNet_project.Models.CommentModel;
using Newtonsoft.Json;

namespace SearchJobNet_project.Controllers.CommentController
{
    public class CommentController : Controller
    {
        // 建立建構子
        public CommentController() { }

        #region 評論功能 [新增/修改/刪除/檢舉/瀏覽]

        // 傳入 評論model(只有 Content_Text ,jobID),執行 [新增評論] 功能
        // 回傳 成功新增資料與否
        [HttpPost]
        public ActionResult insertComment(CM.CommentModel commentModel)
        {
            string msg = "";
            CM.Comment cm = new CM.Comment();
            commentModel.SessionID = Session["suserID"].ToString();
            msg = cm.insertComment(commentModel);
            return Content(msg);
        }

        // 傳入 評論內容和commentID ,執行 [修改評論] 功能
        // 回傳 成功修改資料與否
        [HttpPost]
        public ActionResult modifyComment(int comment_ID ,string content_text)
        {
            string msg = "";
            CM.Comment cm = new CM.Comment();
            msg = cm.modifyComment(comment_ID ,content_text);
            return Content(msg);
        }

        // 傳入 commentID,執行 [刪除評論] 功能
        // 回傳 成功修改資料與否
        [HttpPost]
        public ActionResult deleteComment(int comment_ID)
        {
            string msg = "";
            CM.Comment cm = new CM.Comment();
            msg = cm.delComment(comment_ID);
            return Content(msg);
        }

       // 傳入 commentID, 執行[檢舉評論] 功能
       //回傳 成功修改資料與否(string 型態)
        [HttpPost]
        public ActionResult reportComment(int comment_ID)
        {
            string msg = "";
            CM.Comment cm = new CM.Comment();
            msg = cm.reportComment(comment_ID ,Session["suserID"].ToString());
            return Content(msg);
        }

        // 傳入 comment_ID ,執行 [瀏覽評論] 功能
        // 回傳 list的CommentModel型態
        [HttpPost]
        public ActionResult browseMemberComment(int job_ID)
        {
            CM.Comment comment = new CM.Comment();
            List<CM.CommentModel> cmMemberModel = new List<CM.CommentModel>();
            cmMemberModel = comment.browseJobComment(job_ID);

            //序列化
            string json = JsonConvert.SerializeObject(cmMemberModel);

            return Json(cmMemberModel);
        }

        // 傳入 USER_ID ,執行 [瀏覽歷史評論] 功能
        // 回傳 list的CommentModel型態
        [HttpPost]
        public ActionResult browseHistoryComment(string user_ID)
        {
            CM.Comment comment = new CM.Comment();
            List<CM.CommentModel> cmHistoryModel = new List<CM.CommentModel>();
            cmHistoryModel = comment.browseHistoryComment(user_ID);

            return Json(cmHistoryModel);
        }

        #region [先暫時不用]
        // 傳入 評論PK,執行 [瀏覽評論] 功能
        // 回傳 整筆資料或部分資料(list的CommentModel型態)
        //[HttpPost]
        //public ActionResult browseComment(int commentID)
        //{
        //    CM.Comment comment = new CM.Comment();
        //    List<CM.CommentModel> cmModel = new List<CM.CommentModel>();
        //    cmModel = comment.browseComment(commentID);
        //    return View(cmModel);
        //}
        #endregion

        #endregion

    }
}