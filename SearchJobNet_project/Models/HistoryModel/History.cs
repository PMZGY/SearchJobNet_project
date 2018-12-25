using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CM = SearchJobNet_project.Models.CommentModel;
using HM = SearchJobNet_project.Models.HistoryModel;
using SJM = SearchJobNet_project.Models.SearchJobModel;
using Newtonsoft.Json;
namespace SearchJobNet_project.Models.HistoryModel
{
    public class History
    {
        public string insertHistory(string userID,int jobID)
        {
            #region [做DB連線 以及 執行DB處理]

            // 建立DB連線
            Tools.DBConnection bsc = new Tools.DBConnection();
           
            // 放入瀏覽歷史的資料
            string doDB = bsc.ActionDB(
                            string.Format(
                            @"INSERT INTO [History] (USER_ID,JOB_ID,TIME)
                              VALUES('{0}', {1} , CURRENT_TIMESTAMP);"    
                              , userID, jobID)
                            );


            // 如果 doDB為"success" ,代表DB連線成功 ,反之失敗
            if (doDB == "success")
            {
                return "insert history success";
            }
            else
            {
                return "insert history fail";
            }
            #endregion



        }
        public List<HM.HistoryModel> browseHistoryjob(string userID)
        {


            #region [做DB連線 以及 執行DB處理]

            // 建立DB連線
            Tools.DBConnection bhj = new Tools.DBConnection();
            List<HM.HistoryModel> bHistoryModel = new List<HM.HistoryModel>();
            HM.HistoryModel hmlist = new HM.HistoryModel();
            // 取出 特定的歷史job
            if (userID !="")
            {
                #region[ 取出特定歷史 job的資料 ]
                
                DataTable dt = bhj.ReadDB(
                                string.Format(
                                @"SELECT Job.COMP_ID,Company.COMPNAME,Job.JOB_ID,Job.CITYNAME,Job.OCCU_DESC,Job.WK_TYPE,Job.CJOB_ID,JobType.CJOB_NAME1,History.TIME
                                  FROM [Job],[History],[Company],[JobType]
                                  WHERE Job.JOB_ID=History.JOB_ID
                                  AND Job.COMP_ID=Company.COMP_ID
                                  AND Job.CJOB_ID = JobType.CJOB_ID
                                  AND History.USER_ID = '{0}'", userID
                                  )
                                );

                // 將DataTable的資料轉換為model
                string[] columnNames = dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    bHistoryModel.Add(new HM.HistoryModel() { });
                   
                     bHistoryModel[i] = new HM.HistoryModel()
                    {
                        Time = dt.Rows[i][8].ToString(),
                    };
                    bHistoryModel[i].searchjobModel = new SJM.SearchJobModel()
                    {

                        Comp_ID = Convert.ToInt16(dt.Rows[i][columnNames[0]]),
                        CompName = dt.Rows[i][1].ToString(),
                        Job_ID = Convert.ToInt16(dt.Rows[i][2]),
                        CityName = dt.Rows[i][3].ToString(),
                        Occu_Desc = dt.Rows[i][4].ToString(),
                        Wk_Type = dt.Rows[i][5].ToString(),
                        Cjob_ID = Convert.ToInt16(dt.Rows[i][6]),
                        Cjob_Name1 = dt.Rows[i][7].ToString()


                     };
                  
                }
                
                #endregion
               

            }
            return bHistoryModel;
            #endregion


           
            
        }
       
    }
}