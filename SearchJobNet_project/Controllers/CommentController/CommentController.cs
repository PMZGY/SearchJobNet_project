using System;
using System.Web.Mvc;
using CM = SearchJobNet_project.Models.CommentModel;

namespace SearchJobNet_project.Controllers.CommentController
{
    public class CommentController
    {
        // 建立建構子
        public CommentController() { }

        #region 評論功能 [新增/修改/刪除/檢舉/瀏覽]

        // 傳入行為字串與內容,判斷做什麼行為( I:新增 / M:修改 / D:刪除 / R:檢舉 / B:瀏覽 ) 
        // 回傳msg(boolean),告知成功失敗與否
        public Boolean doComment(string actionComment , string comment)
        {
            // 回傳訊息 msg
            Boolean msg = false;
            // 建立CommentModel
            CM.CommentModel cm = new CM.CommentModel();

            // 行為字串 actionComment
            switch (actionComment)
            {
                // 新增評論
                case "I":             
                    cm.Context = comment;
                    CM.Comment insertObject = new CM.Comment();
                    msg = insertObject.insertComment(cm);
                    return msg;

                // 修改評論
                case "M":
                    cm.Context = comment;
                    CM.Comment modifyObject = new CM.Comment();
                    msg = modifyObject.modifyComment(cm);
                    return msg;

                // 刪除評論
                case "D":
                    cm.Context = comment;
                    CM.Comment delObject = new CM.Comment();
                    msg = delObject.delComment(cm);
                    return msg;

                // 檢舉評論
                case "R":
                    cm.Context = comment;
                    CM.Comment reportObject = new CM.Comment();
                    msg = reportObject.reportComment(cm);
                    return msg;

                // 瀏覽評論
                case "B":
                    cm.Context = comment;
                    CM.Comment browseObject = new CM.Comment();
                    msg = browseObject.browseComment(cm);
                    return msg;

                // 例外狀況
                default:
                    return false;
            }
        }

        #endregion

    }
}