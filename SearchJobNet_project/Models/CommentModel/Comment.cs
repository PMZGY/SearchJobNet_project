using System;
using System.Collections.Generic;
using CM = SearchJobNet_project.Models.CommentModel;

namespace SearchJobNet_project.Models.CommentModel
{
    public class Comment
    {
        // 新增評論
        public Boolean insertComment(CM.CommentModel iComment)
        {
            // do SQL insertComment
            return true;
        }

        // 修改評論
        public Boolean modifyComment(CM.CommentModel mComment)
        {
            // do SQL modifyComment
            return true;
        }

        // 刪除評論
        public Boolean delComment(CM.CommentModel comment)
        {
            // do SQL delComment
            return true;
        }

        // 檢舉評論
        public Boolean reportComment(CM.CommentModel comment)
        {
            // do SQL reportComment
            return true;
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