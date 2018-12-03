using System;
using CM = SearchJobNet_project.Models.CommentModel;

namespace SearchJobNet_project.Controllers.CommentController
{
    public class CommentController
    {
        // 建立建構子
        public CommentController() { }
         
        // 傳入行為字串與內容,判斷做什麼行為( I:新增 / M:修改 / D:刪除 / C:檢查 ) 
        // 回傳msg(boolean),告知成功失敗與否
        public Boolean doComment(string actionComment , string comment)
        {
            // 回傳訊息 msg
            Boolean msg = false;

            // 行為字串 actionComment
            switch (actionComment)
            {
                // 新增評論
                case "I":
                    CM.Comment insertObject = new CM.Comment();
                    msg = insertObject.insertComment(comment);
                    return msg;

                // 修改評論
                case "M":
                    CM.Comment modifyObject = new CM.Comment();
                    msg = modifyObject.modifyComment(comment);
                    return msg;
                
                // 刪除評論 (用pk刪除評論)
                case "D":
                    CM.Comment delObject = new CM.Comment();
                    msg = delObject.delComment(comment);
                    return msg;
                
                // 檢舉評論 (用pk刪除評論)
                case "C":
                    CM.Comment reportObject = new CM.Comment();
                    msg = reportObject.reportComment(comment);
                    return msg;
                
                // 例外狀況
                default:
                    return false;
            }
        }
  
    }
}