﻿using System;
using System.Collections.Generic;
using System.Data;
using CM = SearchJobNet_project.Models.CommentModel;

namespace SearchJobNet_project.Models.CommentModel
{
    public class Comment
    {
        // 新增評論 [ 評論model的attr. 皆為填入項目 ]
        public string insertComment(CM.CommentModel iComment)
        {
            #region [做DB連線 以及 執行DB處理]
            
            // 建立DB連線
            Tools.DBConnection bsc = new Tools.DBConnection();

            // 放入 commentID的資料
            string doDB = bsc.ActionDB(
                            string.Format(
                            @"INSERT INTO [Comment] (COMMENT_ID,JOB_ID,USER_ID,CONTENT_TEXT,TIME,REPORT_NO,IS_ALIVE)
                              VALUES({0},{1},'{2}','{3}','{4}',{5},'{6}');"
                              ,iComment.Comment_ID ,iComment.Job_ID ,iComment.User_ID
                              ,iComment.Content_Text ,iComment.Time ,iComment.Report_no ,iComment.Is_Alive)
                            );

            // 如果 doDB為"success" ,代表DB連線成功 ,反之失敗
            if (doDB != "success")
            {
                return "DB處理錯誤";
            }
            
            #endregion

            #region[檢查DB內容]

            // 查看是否新增成功
            List<CommentModel> cm = this.browseComment(iComment.Comment_ID);

            // 如果list個數為0 ,則回傳插入失敗
            if (cm.Count == 0)
            {
                return "insert error!";
            }
            else
            {
                // 判斷 DB 是否有插入一模一樣的資料筆
                for (int i = 0; i < cm.Count; i++)
                {
                    if ((cm[i].Comment_ID   == iComment.Comment_ID) &&
                        (cm[i].Job_ID       == iComment.Job_ID) &&
                        (cm[i].User_ID      == iComment.User_ID) &&
                        (cm[i].Content_Text == iComment.Content_Text) &&
                        (cm[i].Time         == iComment.Time) &&
                        (cm[i].Report_no    == iComment.Report_no) &&
                        (cm[i].Is_Alive     == iComment.Is_Alive)
                      )
                    {
                        return "insert success!";
                    }
                }
                return "insert error!";
            }

            #endregion

        }

        // 修改評論 [ 評論model的attr. comment為修改項目 ,commentID和time為修改條件 ]
        public string modifyComment(CM.CommentModel mComment)
        {

            #region [做DB連線 以及 執行DB處理]

            // 建立DB連線
            Tools.DBConnection bsc = new Tools.DBConnection();

            // 修改 commentID的資料
            String doDB = bsc.ActionDB(
                            string.Format(
                            @"UPDATE [Comment]
                              SET CONTENT_TEXT = '{0}'
                              WHERE 1=1
                              AND COMMENT_ID = {1}
                              AND TIME = '{2}' ;"
                              , mComment.Content_Text, mComment.Comment_ID, mComment.Time)
                            );

            // 如果 doDB為"success" ,代表DB連線成功 ,反之失敗
            if (doDB != "success")
            {
                return "DB處理錯誤";
            }

            #endregion

            #region[檢查DB內容]

            // 查看是否修改成功
            List<CommentModel> cm = this.browseComment(mComment.Comment_ID);

            // 如果list個數為0 ,則回傳修改失敗
            if (cm.Count == 0)
            {
                return "modify error!";
            }
            else
            {
                // 判斷 DB 是否有修改一模一樣的資料筆
                for (int i = 0; i < cm.Count; i++)
                {
                    if ((cm[i].Comment_ID   == mComment.Comment_ID) &&
                        (cm[i].Job_ID       == mComment.Job_ID) &&
                        (cm[i].User_ID      == mComment.User_ID) &&
                        (cm[i].Content_Text == mComment.Content_Text) &&
                        (cm[i].Time         == mComment.Time) &&
                        (cm[i].Report_no    == mComment.Report_no) &&
                        (cm[i].Is_Alive     == mComment.Is_Alive)
                      )
                    {
                        return "modify success!";
                    }
                }
                return "modify error!";
            }

            #endregion

        }

        // 刪除評論 [ 評論model的attr. commentID 和 time 為修改pk ]
        public string delComment(int commentID,string time)
        {
            #region [做DB連線 以及 執行DB處理]

            // 建立DB連線
            Tools.DBConnection bsc = new Tools.DBConnection();

            // 刪除 commentID的資料
            String doDB = bsc.ActionDB(
                            string.Format(
                            @"DELETE FROM [Comment]
                              WHERE 1=1
                              AND COMMENTID = {0}
                              AND TIME = '{1}';"
                            , commentID ,time)
                           );

            // 如果 doDB為"success" ,代表DB連線成功 ,反之失敗
            if (doDB != "success")
            {
                return "DB處理錯誤";
            }

            #endregion

            #region[檢查DB內容]

            // 查看是否修改成功
            List<CommentModel> cm = this.browseComment(commentID);

            // 如果list個數為0 ,則回傳刪除成功
            if (cm.Count == 0)
            {
                return "delete success!";
            }
            else
            {
                // 若不是評論者刪除的那筆(當事人可能有很多筆) ,則回傳 刪除成功
                for (int i = 0; i < cm.Count; i++)
                {
                    if ((cm[i].Comment_ID == commentID) &&(cm[i].Time == time))
                    {
                        return "delete error!";
                    }
                }
                return "delete success!";
            }

            #endregion
        }

        // 檢舉評論 [ 評論model的attr. commentID 和 time 為修改pk ]
        public string reportComment(CM.CommentModel rComment)
        {
            #region[查看與修改 評論檢舉次數]

            // 檢查 評論檢舉次數是否到達五次
            rComment.Report_no = rComment.Report_no + 1;

            if (rComment.Report_no == 5)
            {
                rComment.Is_Alive = "true";
            }
            else
            {
                rComment.Is_Alive = "false";
            }

            #endregion

            #region [做DB連線 以及 執行DB處理]

            // 建立DB連線
            Tools.DBConnection bsc = new Tools.DBConnection();

            // 判斷檢舉次數 是否到達五次
            string SQLComment = (rComment.Report_no == 5)?", Is_Alive  = \"false\"":"";
            
            // 修改 commentID的資料
            String doDB = bsc.ActionDB(
                            string.Format(
                            @"UPDATE [Comment]
                              SET REPORT_NO = {0}
                                  '{1}'
                              WHERE 1=1
                              AND COMMENT_ID = {2}
                              AND TIME = '{3}' ;"
                                , rComment.Report_no, SQLComment, rComment.Comment_ID, rComment.Time)
                            );

            // 如果 doDB為"success" ,代表DB連線成功 ,反之失敗
            if (doDB != "success")
            {
                return "DB處理錯誤";
            }

            #endregion

            #region[檢查DB內容]

            // 查看是否修改成功
            List<CommentModel> cm = this.browseComment(rComment.Comment_ID);

            // 查看檢舉評論那筆 ,是否執行成功

            for (int i = 0; i < cm.Count; i++)
            {
                if ((cm[i].Comment_ID == rComment.Comment_ID) && 
                    (cm[i].Time       == rComment.Time) &&
                    (cm[i].Report_no  == rComment.Report_no)&&
                    (cm[i].Is_Alive   == rComment.Is_Alive)
                   )
                {
                    return "report success!";
                }
            }
            return "delete success!";
            
            #endregion
        }

        // 瀏覽[會員= 0/職缺= 1]評論
        public List<CM.CommentModel> browseMemberOrJobComment(object ID,int phase)
        {
            List<CM.CommentModel> bCommentModel = new List<CM.CommentModel>();

            #region [做DB連線 以及 執行DB處理]

            // 建立DB連線
            Tools.DBConnection bsc = new Tools.DBConnection();

            #region[ 取出特定 commentID的資料 ]

            // 判斷 會員的ID(string) 或是 職缺的ID(int)
            string memberID = "";
            int jobID = 0;

            if (phase == 0)
            {
                // 是會員
                memberID = ID.ToString();
            }
            else
            {
                //是職缺
                jobID = Convert.ToInt32(jobID);
            }

            // 判斷是 會員功能呼叫 或是 職缺功能呼叫
            string SQLComment = (phase == 0) ? string.Format("AND C.USERID = '{0}'",memberID) : string.Format("AND C.JOB_ID = {0}",jobID);

            DataTable dt = bsc.ReadDB(
                            string.Format(
                            @"SELECT *
                             FROM [Comment] AS C
                             WHERE 1=1
                             {0}"
                             , SQLComment)
                            );

            // 將DataTable的資料轉換為model
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bCommentModel.Add(new CM.CommentModel
                {
                    Comment_ID   = Convert.ToInt16(dt.Rows[i][0].ToString()),
                    Job_ID       = Convert.ToInt16(dt.Rows[i][1]),
                    User_ID      = dt.Rows[i][2].ToString(),
                    Content_Text = dt.Rows[i][3].ToString(),
                    Time         = dt.Rows[i][4].ToString(),
                    Report_no    = Convert.ToInt16(dt.Rows[i][5]),
                    Is_Alive     = dt.Rows[i][6].ToString()
                });
            }

            #endregion
            
            return bCommentModel;

            #endregion
        }

        // 瀏覽評論
        public List<CM.CommentModel> browseComment(int commentID)
        {
            List<CM.CommentModel> bCommentModel = new List<CM.CommentModel>();

            #region [做DB連線 以及 執行DB處理]

            // 建立DB連線
            Tools.DBConnection bsc = new Tools.DBConnection();

            // 取出 特定的評論 或是 全部的評論
            if (commentID > 0)
            {
                #region[ 取出特定 commentID的資料 ]

                DataTable dt = bsc.ReadDB(
                                string.Format(
                                @"SELECT *
                                  FROM [Comment] AS C
                                  WHERE 1=1
                                  AND C.COMMENT_ID = {0}"
                                  , commentID)
                                );

                // 將DataTable的資料轉換為model
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    bCommentModel.Add(new CM.CommentModel
                    {
                        Comment_ID   = Convert.ToInt16(dt.Rows[i][0].ToString()),
                        Job_ID       = Convert.ToInt16(dt.Rows[i][1]),
                        User_ID      = dt.Rows[i][2].ToString(),
                        Content_Text = dt.Rows[i][3].ToString(),
                        Time         = dt.Rows[i][4].ToString(),
                        Report_no    = Convert.ToInt16(dt.Rows[i][5]),
                        Is_Alive     = dt.Rows[i][6].ToString()
                    });
                }

                #endregion
            }
            else
            {
                #region[ 取出全部資料 ]

                // 從DB取出SQL下的指令的資料
                DataTable dt = bsc.ReadDB(
                                @"SELECT * 
                                  FROM [Comment]"
                                );

                // 將DataTable的資料轉換為model
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    bCommentModel.Add(new CM.CommentModel
                    {
                        Comment_ID   = Convert.ToInt16(dt.Rows[i][0].ToString()),
                        Job_ID       = Convert.ToInt16(dt.Rows[i][1]),
                        User_ID      = dt.Rows[i][2].ToString(),
                        Content_Text = dt.Rows[i][3].ToString(),
                        Time         = dt.Rows[i][4].ToString(),
                        Report_no    = Convert.ToInt16(dt.Rows[i][5]),
                        Is_Alive     = dt.Rows[i][6].ToString()
                    });
                }

                #endregion
            }
            return bCommentModel;

            #endregion
        }

    }
}