using System;
using System.Collections.Generic;
using CM = SearchJobNet_project.Models.CommentModel;

namespace SearchJobNet_project.Models.CommentModel
{
    public class Comment
    {
        // 新增評論
        public string insertComment(CM.CommentModel iComment)
        {
            // do SQL insertComment
            return "insert data success";
        }

        // 修改評論
        public string modifyComment(CM.CommentModel mComment)
        {
            // do SQL modifyComment
            return "modify data success";
        }

        // 刪除評論
        public string delComment(string commentID)
        {
            // do SQL delComment
            return "delete data success";
        }

        // 檢舉評論
        public string reportComment(CM.CommentModel rComment)
        {
            // 檢查 評論檢舉次數是否到達五次
            rComment.Report_no = rComment.Report_no + 1;
            if (rComment.Report_no != 5)
            {
                return "report data success";
            }
            else
            {
                rComment.Is_Alive = false;
                return "report data success ,and it was deleted!";
            }
            // do SQL reportComment
        }

        // 瀏覽評論
        public List<CM.CommentModel> browseComment(string commentID)
        {
            List<CM.CommentModel> bCommentModel = new List<CM.CommentModel>();
            CM.CommentModel cmlist = new CM.CommentModel();
           
            // 取出 特定的評論 或是 全部的評論
            if (commentID != "")
            {
                // 用for 取出特定資料
                for (int i = 0; i < cmlist.getAllComment().Count; i++)
                {
                    if (cmlist.getAllComment()[i].Comment_ID == commentID)
                    {
                        bCommentModel.Add(cmlist.getAllComment()[i]);
                        break;
                    }
                }
            }
            else
            {
                // 取出全部資料
                for (int i = 0; i < cmlist.getAllComment().Count ; i++)
                {
                    bCommentModel.Add(cmlist.getAllComment()[i]);                    
                }
                
            }
            return bCommentModel;
        }

    }
}