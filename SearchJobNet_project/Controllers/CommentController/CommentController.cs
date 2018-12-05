using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CM = SearchJobNet_project.Models.CommentModel;

namespace SearchJobNet_project.Controllers.CommentController
{
    public class CommentController
    {
        // 建立建構子
        public CommentController() { }

        //#region 評論功能 [新增/修改/刪除/檢舉/瀏覽]

<<<<<<< HEAD
        // 傳入行為字串與內容,判斷做什麼行為( I:新增 / M:修改 / D:刪除 / R:檢舉 ) 
        // 回傳msg(boolean),告知成功失敗與否
        public Boolean doComment(string actionComment)
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
                    // 呼叫 expert comment - insetComment function
                    return msg;

                // 修改評論
                case "M":
                    // 呼叫 expert comment - modifyComment function
                    return msg;

                // 刪除評論
                case "D":
                    // 呼叫 expert comment - delComment function
                    return msg;

                // 檢舉評論
                case "R":
                    // 呼叫 expert comment - reportComment function
                    return msg;               
=======
        //// 傳入行為字串與內容,判斷做什麼行為( I:新增 / M:修改 / D:刪除 / R:檢舉 / B:瀏覽 ) 
        //// 回傳msg(boolean),告知成功失敗與否
        //public Boolean doComment(string actionComment , string comment)
        //{
        //    // 回傳訊息 msg
        //    Boolean msg = false;
        //    // 建立CommentModel
        //    CM.CommentModel cm = new CM.CommentModel();

        //    // 行為字串 actionComment
        //    switch (actionComment)
        //    {
        //        // 新增評論
        //        case "I":             
        //            cm.Context = comment;
        //            CM.Comment insertObject = new CM.Comment();
        //            msg = insertObject.insertComment(cm);
        //            return msg;

        //        // 修改評論
        //        case "M":
        //            cm.Context = comment;
        //            CM.Comment modifyObject = new CM.Comment();
        //            msg = modifyObject.modifyComment(cm);
        //            return msg;

        //        // 刪除評論
        //        case "D":
        //            cm.Context = comment;
        //            CM.Comment delObject = new CM.Comment();
        //            msg = delObject.delComment(cm);
        //            return msg;

        //        // 檢舉評論
        //        case "R":
        //            cm.Context = comment;
        //            CM.Comment reportObject = new CM.Comment();
        //            msg = reportObject.reportComment(cm);
        //            return msg;

        //        // 瀏覽評論
        //        case "B":
        //            cm.Context = comment;
        //            CM.Comment browseObject = new CM.Comment();
        //            msg = browseObject.browseComment(cm);
        //            return msg;
>>>>>>> 47462c40ff339a8f607c8f2a11a4422b9ac1f462

        //        // 例外狀況
        //        default:
        //            return false;
        //    }
        //}

<<<<<<< HEAD
        // 傳入 評論PK,執行 瀏覽評論 功能
        // 回傳 整筆資料或部分資料(list的CommentModel型態)
        public List<CM.CommentModel> browseComment(string commentID)
        {
            CM.Comment comment = new CM.Comment();
            List<CM.CommentModel> cmModel = new List<CM.CommentModel>();
            cmModel = comment.browseComment(commentID);
            return cmModel;

        }
        #endregion
=======
        //#endregion
>>>>>>> 47462c40ff339a8f607c8f2a11a4422b9ac1f462

    }
}