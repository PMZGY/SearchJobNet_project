using System;

namespace SearchJobNet_project.Models.CommentModel
{
    public class Comment
    {
        // 新增評論
        public Boolean insertComment(string comment)
        {
            CommentModel cm = new CommentModel();
            cm.Context = comment;
            return true;
        }

        // 修改評論
        public Boolean modifyComment(string comment)
        {
            CommentModel cm = new CommentModel();
            cm.Context = comment;
            return true;
        }

        // 刪除評論
        public Boolean delComment(string comment)
        {
            CommentModel cm = new CommentModel();
            cm.Context = "";
            return true;
        }

        // 檢舉評論
        public Boolean reportComment(string comment)
        {
            CommentModel cm = new CommentModel();
            cm.Context = "";
            return true;
        }
    }
}