using Newtonsoft.Json;
using System;
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
                        (cm[i].Content_Text == mComment.Content_Text) &&
                        (cm[i].Time         == mComment.Time)
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

        // 檢舉評論
        public string reportComment(string formData)
        {
            // 將formData 解json 序列化
            CommentModel cm = JsonConvert.DeserializeObject<CommentModel>(formData);

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
                                 , cm.SessionID)
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
                                          , cm.Comment_ID)
                                        );

            // 判斷檢舉次數 是否到達五次
            int reportsnum = Convert.ToInt16(reporttimes.Rows[0][0]);
            reportsnum = reportsnum + 1;
            string SQLComment = (reportsnum == 5) ? ", Is_Alive  = \"false\"" : "";

            // 修改 commentID的資料(次數+1)
            String doDBConnect = bsc.ActionDB(
                                     string.Format(
                                            @"UPDATE [Comment]
                                              SET REPORT_NO = {0},
                                                  '{1}'
                                              WHERE 1=1
                                              AND COMMENT_ID = {2};"
                                              , reportsnum ,SQLComment ,cm.Comment_ID)
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
                                              , cm.Comment_ID, cm.SessionID)
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
            List<CommentModel> cms = this.browseComment(cm.Comment_ID);

            // 查看檢舉評論那筆 ,是否執行成功

            for (int i = 0; i < cms.Count; i++)
            {
                if ( (cms[i].Comment_ID == cm.Comment_ID) &&
                     (cms[i].Report_no  == reportsnum)
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
                
            // for ignore bug 12/16
                //jobID = Convert.ToInt32(ID);
            }

            // 判斷是 會員功能呼叫 或是 職缺功能呼叫
            //to get data
            string SQLComment = (phase == 0) ? string.Format("AND C.USER_ID = '{0}'", memberID) : string.Format("AND C.JOB_ID = {0}",1);
            //string SQLComment = (phase == 0) ? string.Format("AND C.USER_ID = '{0}'", memberID) : string.Format("AND C.JOB_ID = {0}", jobID);

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