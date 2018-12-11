using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CM = SearchJobNet_project.Models.CommentModel;
using Tools = SearchJobNet_project.Tools;

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

            // 建立DB連線
            Tools.DBConnection bsc = new Tools.DBConnection();

            // 取出 特定的評論 或是 全部的評論
            if (commentID != "")
            {               
                // 取出特定 commentID的資料
                DataTable dt = bsc.ReadDB(
                string.Format(
                @"SELECT *
                  FROM [Comment] AS C
                  WHERE 1=1
                  C.commentID = {0}",commentID)
                );

                // 從DataTble 取出 資料欄位名稱
                string[] columnNames = dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();

                // 將DataTable的資料轉換為model
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    bCommentModel.Add(new CM.CommentModel
                    {
                        Comment_ID = Convert.ToInt16(dt.Rows[i][columnNames[0]].ToString()),
                        Job_ID = Convert.ToInt16(dt.Rows[i][1]),
                        User_ID = Convert.ToInt16(dt.Rows[i][2]),
                        Content_Text = dt.Rows[i][3].ToString(),
                        Time = dt.Rows[i][4].ToString(),
                        Report_no = Convert.ToInt16(dt.Rows[i][5]),
                        Is_Alive = dt.Rows[i][6].ToString()
                    });
                }
            }
            else
            {
                // 取出全部資料
                
                // 從DB取出SQL下的指令的資料
                DataTable dt = bsc.ReadDB(
                @"SELECT * 
                  FROM [Comment]"
                );

                // 從DataTable 取出 資料欄位名稱
                string[] columnNames = dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();

                // 將DataTable的資料轉換為model
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    bCommentModel.Add(new CM.CommentModel {
                        Comment_ID   = Convert.ToInt16(dt.Rows[i][columnNames[0]].ToString()),
                        Job_ID       = Convert.ToInt16(dt.Rows[i][1]),
                        User_ID      = Convert.ToInt16(dt.Rows[i][2]),
                        Content_Text = dt.Rows[i][3].ToString(),
                        Time         = dt.Rows[i][4].ToString(),
                        Report_no    = Convert.ToInt16(dt.Rows[i][5]),
                        Is_Alive     = dt.Rows[i][6].ToString()
                    } );
                }
                
            }
            return bCommentModel;
        }

    }
}