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

        // 傳入 評論model,執行 [新增評論] 功能
        // 回傳 成功新增資料與否
        [HttpPost]
        public ActionResult insertComment(CM.CommentModel commentModel)
        {
            string msg = "";
            CM.Comment cm = new CM.Comment();
            msg = cm.insertComment(commentModel);
            return Content(msg);
        }

        // 傳入 評論model,執行 [修改評論] 功能
        // 回傳 成功修改資料與否
        [HttpPost]
        public ActionResult modifyComment(CM.CommentModel commentModel)
        {
            string msg = "";
            CM.Comment cm = new CM.Comment();
            msg = cm.modifyComment(commentModel);
            return Content(msg);
        }

        // 傳入 評論PK,執行 [刪除評論] 功能
        // 回傳 成功修改資料與否
        [HttpPost]
        public ActionResult deleteComment(int commentID ,string time)
        {
            string msg = "";
            CM.Comment cm = new CM.Comment();
            msg = cm.delComment(commentID ,time);
            return Content(msg);
        }

        // 傳入 評論model,執行 [檢舉評論] 功能
        // 回傳 成功修改資料與否
        [HttpPost]
        public ActionResult reportComment(CM.CommentModel commentModel)
        {
            string msg = "";
            CM.Comment cm = new CM.Comment();
            msg = cm.reportComment(commentModel);
            return Content(msg);
        }

        // 傳入 USERPK,執行 [瀏覽會員評論 / 職缺評論] 功能
        // 回傳 整筆資料或部分資料(list的CommentModel型態)
        [HttpPost]
        public ActionResult browseMemberComment(object ID, int phase)
        {
            CM.Comment comment = new CM.Comment();
            List<CM.CommentModel> cmMemberModel = new List<CM.CommentModel>();
            cmMemberModel = comment.browseMemberOrJobComment(ID, phase);

            // message for debugged 12/16
            string json = JsonConvert.SerializeObject(cmMemberModel);
            System.Diagnostics.Debug.Print(json + "wwwwww");

            // try to use json to det data 12/16
            return Json(cmMemberModel);
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