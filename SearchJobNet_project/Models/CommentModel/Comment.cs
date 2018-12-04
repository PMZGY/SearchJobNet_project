using System;
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
        public Boolean browseComment(CM.CommentModel comment)
        {
            // do SQL browseComment
            return true;
        }

    }
}