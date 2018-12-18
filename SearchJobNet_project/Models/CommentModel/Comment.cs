using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using CM = SearchJobNet_project.Models.CommentModel;

namespace SearchJobNet_project.Models.CommentModel
{
    public class Comment
    {
        // 新增評論
        public string insertComment(CM.CommentModel iComment)
        {
            #region [做DB連線 以及 執行DB處理]
            
            // 建立DB連線
            Tools.DBConnection bsc = new Tools.DBConnection();

            // 放入 commentID的資料
            string doDB = bsc.ActionDB(
                            string.Format(
                            @"INSERT INTO [Comment] (JOB_ID,USER_ID,CONTENT_TEXT,TIME)
                              VALUES({0},'{1}','{2}','{3}');"
                              ,iComment.Job_ID ,iComment.User_ID,iComment.Content_Text ,iComment.Time)
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
                    if ((cm[i].Job_ID       == iComment.Job_ID) &&
                        (cm[i].User_ID      == iComment.User_ID) &&
                        (cm[i].Content_Text == iComment.Content_Text) &&
                        (cm[i].Time         == iComment.Time)                        
                      )
                    {
                        return "insert success!";
                    }
                }
                return "insert error!";
            }

            #endregion

        }

        // 修改評論 
        public string modifyComment(int comment_ID, string content_text)
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
                              AND COMMENT_ID = {1};"
                              , content_text, comment_ID)
                            );

            // 如果 doDB為"success" ,代表DB連線成功 ,反之失敗
            if (doDB != "success")
            {
                return "DB處理錯誤";
            }

            #endregion

            #region[檢查DB內容]

            // 查看是否修改成功
            List<CommentModel> cm = this.browseComment(comment_ID);

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
                    if ((cm[i].Comment_ID   == comment_ID) &&
                        (cm[i].Content_Text == content_text)
                      )
                    {
                        return "modify success!";
                    }
                }
                return "modify error!";
            }

            #endregion

        }

        // 刪除評論
        public string delComment(int comment_ID)
        {
            #region [做DB連線 以及 執行DB處理]

            // 建立DB連線
            Tools.DBConnection bsc = new Tools.DBConnection();

            // 刪除 commentID的資料
            String doDB = bsc.ActionDB(
                            string.Format(
                            @"DELETE FROM [Comment]
                              WHERE 1=1
                              AND COMMENTID = {0};"
                            , comment_ID)
                           );

            // 如果 doDB為"success" ,代表DB連線成功 ,反之失敗
            if (doDB != "success")
            {
                return "DB處理錯誤";
            }

            #endregion

            #region[檢查DB內容]

            // 查看是否修改成功
            List<CommentModel> cm = this.browseComment(comment_ID);

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
                    if (cm[i].Comment_ID == comment_ID)
                    {
                        return "delete error!";
                    }
                }
                return "delete success!";
            }

            #endregion
        }

        // 檢舉評論
        public string reportComment(int comment_ID)
        {
            // 建立DB連線
            Tools.DBConnection bsc = new Tools.DBConnection();

            #region[判斷sessionID者是否曾經檢舉過此筆]

            // 判斷sessionID者是否曾經檢舉過此筆
            DataTable dt = bsc.ReadDB(
                               string.Format(
                               @"SELECT *
                                 FROM [Report] AS R
                                 WHERE 1=1
                                 AND R.USER_ID = '{0}'"
                                 , Session["suserID"])
                                );

            // 若已檢舉過 ,直接回傳"Can't report again!"
            if (dt.Rows.Count > 0)
            {
                return "Can't report again!";
            }

            #endregion

            #region[此筆評論增加report numbers ,判斷是否還存活 ,新增report table資料]

                #region[評論增加report numbers ,判斷是否還存活]

                // 判斷此筆資料的 檢舉次數
                DataTable reporttimes = bsc.ReadDB(
                                            string.Format(
                                            @"SELECT C.REPORT_NO
                                              FROM [Comment] AS C
                                              WHERE 1=1
                                              AND C.COMMENT_ID = {0}"
                                              , comment_ID)
                                            );

                // 取得檢舉次數 ,並增加一次
                int reportsnum = Convert.ToInt16(reporttimes.Rows[0][0]);
                reportsnum = reportsnum + 1;

                // 若檢舉次數 = 5 ,不存活SQL指令
                string SQLComment = (reportsnum == 5) ? ", Is_Alive  = \"false\"" : "";

                // 修改 commentID的資料(次數+1)
                String doDBConnect = bsc.ActionDB(
                                         string.Format(
                                                @"UPDATE [Comment]
                                                  SET REPORT_NO = {0},
                                                      '{1}'
                                                  WHERE 1=1
                                                  AND COMMENT_ID = {2};"
                                                  , reportsnum ,SQLComment , comment_ID)
                                                );

                // 如果 doDB為"success" ,代表DB連線成功 ,反之失敗
                if (doDBConnect != "success")
                {
                    return "修改 commentID的資料 錯誤";
                }

                #endregion

                #region[新增report table資料]

                // 新增 report table 資料
                String  modifyreport = bsc.ActionDB(
                                         string.Format(
                                                @"INSERT INTO[Report](COMMENT_ID,USER_ID)
                                                VALUES({0},'{1}'); "
                                                  , comment_ID, Session["suserID"])
                                        );

                // 如果 modifyreport == "success" ,代表DB連線成功 ,反之失敗
                if (modifyreport != "success")
                {
                    return "新增 report table 資料 錯誤";
                }

                #endregion

            #endregion

            #region[檢查DB內容]

            // 查看是否修改成功
            List<CommentModel> cms = this.browseComment(comment_ID);

            // 查看檢舉評論那筆 ,是否執行成功

            for (int i = 0; i < cms.Count; i++)
            {
                if ( (cms[i].Comment_ID == comment_ID) &&
                     (cms[i].Report_no  == reportsnum)
                   )
                {
                    return "report success!";
                }
            }
            return "delete success!";

            #endregion
        }

        // 瀏覽評論
        public List<CM.CommentModel> browseComment(int comment_ID)
        {
            List<CM.CommentModel> bCommentModel = new List<CM.CommentModel>();

            #region [做DB連線 以及 執行DB處理]

            // 建立DB連線
            Tools.DBConnection bsc = new Tools.DBConnection();

            #region[ 取出特定 commentID的資料 ]

            DataTable dt = bsc.ReadDB(
                            string.Format(
                            @"SELECT *
                                FROM [Comment] AS C
                                WHERE 1=1
                                AND C.COMMENT_ID = {0}"
                                , comment_ID)
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

        // 瀏覽 [歷史評論]
        public List<CM.CommentModel> browseHistoryComment(string user_ID)
        {
            List<CM.CommentModel> bCommentModel = new List<CM.CommentModel>();

            // 建立DB連線
            Tools.DBConnection bsc = new Tools.DBConnection();

            #region[ 取出 USER_ID的評論 ]

            DataTable dt = bsc.ReadDB(
                            string.Format(
                            @"SELECT J.COMPNAME ,J.OCCU_DESC ,C.TIME ,C.IS_ALIVE
                              FROM [Comment] AS C , [Job] AS J
                              WHERE 1=1
                              AND C.JOB_ID = J.JOB_ID
                              AND C.USER_ID = '{0}'"
                              , user_ID)
                            );

            // 將DataTable的資料轉換為model
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bCommentModel.Add(new CM.CommentModel
                {
                    CompName  = dt.Rows[i][0].ToString(),
                    Occu_Desc = dt.Rows[i][1].ToString(),
                    Time      = dt.Rows[i][2].ToString(),
                    Is_Alive  = dt.Rows[i][3].ToString()
                });
            }

            #endregion

            return bCommentModel;

        }

    }
}