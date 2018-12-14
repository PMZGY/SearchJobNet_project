using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CM = SearchJobNet_project.Models.CommentModel;
using HM = SearchJobNet_project.Models.HistoryModel;
using SJM = SearchJobNet_project.Models.SearchJobModel;

namespace SearchJobNet_project.Models.HistoryModel
{
    public class History
    {
        public string insertHistory(HM.HistoryModel iHistory)
        {
            #region [做DB連線 以及 執行DB處理]

            // 建立DB連線
            Tools.DBConnection bsc = new Tools.DBConnection();

            // 放入 commentID的資料
            string doDB = bsc.ActionDB(
                            string.Format(
                            @"INSERT INTO [History] (USER_ID,JOB_ID,TIME)
                              VALUES({0},{1},{2});"
                              ,iHistory.User_ID, iHistory.Job_ID, iHistory.Time)
                            );  
                            

            // 如果 doDB為"success" ,代表DB連線成功 ,反之失敗
            if (doDB != "success")
            {
                return "DB處理錯誤";
            }
            else
            {
                return "DB處理成功";
            }
            #endregion

            
            
        }
        public List<HM.HistoryModel> browseHistoryjob(int userID)
        {
            List<HM.HistoryModel> bHistoryModel = new List<HM.HistoryModel>();
            HM.HistoryModel hmlist = new HM.HistoryModel();
            #region [做DB連線 以及 執行DB處理]

            // 建立DB連線
            Tools.DBConnection bhj = new Tools.DBConnection();

            // 取出 特定的評論 或是 全部的評論
            if (userID>0)
            {
                #region[ 取出特定歷史 job的資料 ]

                DataTable dt = bhj.ReadDB(
                                string.Format(
                                @"SELECT COMP_ID,COMPNAME,JOB_ID,CITYNAME,OCCU_DESC,WK_TYPE,CJOB_ID,CJOB_NAME1,TIME
                                  FROM [Job],[History] 
                                  WHERE Job.JOB_ID=History.JOB_ID
                                  AND History.USERID = {0}"
                                  , userID)
                                );

                // 將DataTable的資料轉換為model
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    bHistoryModel[i].searchjobModel.Add(new SJM.SearchJobModel
                    {
                        Comp_ID = Convert.ToInt16(dt.Rows[i][0]),
                        CompName = dt.Rows[i][1].ToString(),
                        Job_ID = Convert.ToInt16(dt.Rows[i][2]),
                        CityName = dt.Rows[i][3].ToString(),
                        Occu_Desc = dt.Rows[i][4].ToString(),
                        Wk_Type = dt.Rows[i][5].ToString(),
                        Cjob_ID = Convert.ToInt16(dt.Rows[i][6]),
                        Cjob_Name1 = dt.Rows[i][7].ToString(),

                    });
                    bHistoryModel.Add(new HM.HistoryModel
                    {
                        Time = dt.Rows[i][8].ToString(),
                    });
                    
                }

                #endregion
            }
            
            return bHistoryModel;

            #endregion

            
        }
       
    }
}