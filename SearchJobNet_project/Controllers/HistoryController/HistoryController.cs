using System.Collections.Generic;
using System.Web.Mvc;
using HM = SearchJobNet_project.Models.HistoryModel;
using CM = SearchJobNet_project.Models.CommentModel;


namespace SearchJobNet_project.Controllers.HistoryController
{
    public class HistoryController : Controller
    {
        // 建立建構子
        public HistoryController() { }

        //轉至歷史紀錄頁面
        public ActionResult Index()
        {
            return View("HistoryView");
        }

        #region 歷史紀錄功能 [生成瀏覽紀錄/瀏覽瀏覽紀錄/瀏覽評論紀錄]

        // 傳入 歷史model, 執行[生成瀏覽職缺紀錄] 功能
        // 回傳 成功新增資料與否
        [HttpPost]
        public ActionResult insertHistory(int jobID)
        {
            string msg = "";
            HM.History hm = new HM.History();
            if (Session["suserID"] == null || string.IsNullOrWhiteSpace(Session["suserID"].ToString()))
            {
                System.Diagnostics.Debug.Print("還沒登入");
            }
            else
            {
                msg = hm.insertHistory(Session["suserID"].ToString(), jobID);
            }
            return Content(msg);
        }
        [HttpPost]
        // 傳入 使用者PK 執行 [瀏覽瀏覽職缺紀錄] 功能
        // 回傳 整筆資料或部分資料(json的HistoryModel型態)
        public ActionResult browseHistoryjob()
        {

            HM.History hm = new HM.History();
            List<HM.HistoryModel> hmModel = new List<HM.HistoryModel>();

            hmModel = hm.browseHistoryjob(Session["suserID"].ToString());




            return Json(hmModel);

        }


        // 傳入 使用者PK 執行 [瀏覽歷史評論紀錄] 功能
        // 回傳 整筆資料或部分資料(json的HistoryModel型態)
        public ActionResult browseHistoryComment()
        {
            System.Diagnostics.Debug.Print(Session["suserID"].ToString() + " this is");
            CM.Comment comment = new CM.Comment();
            List<CM.CommentModel> hcommentModel = new List<CM.CommentModel>();
            hcommentModel = comment.browseHistoryComment(Session["suserID"].ToString());


            return Json(hcommentModel);
        }


        #endregion
    }
}