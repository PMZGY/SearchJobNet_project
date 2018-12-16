using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SearchJobNet_project.Models.JobModel;
using SJM = SearchJobNet_project.Models.SearchJobModel;
using JM = SearchJobNet_project.Models.JobModel;
using Tools = SearchJobNet_project.Tools;
using System.Web.Mvc;

namespace SearchJobNet_project.Models.SearchJobModel
{
    public class SearchJob
    {

        public List<SelectListItem> getWorkType()
        {

            #region [做DB連線 以及 執行DB處理]

            // 建立DB連線
            Tools.DBConnection bsc = new Tools.DBConnection();


            #endregion
            // 取出職缺性質種類
            #region[ 取出職缺性質種類 ]

            DataTable dt = bsc.ReadDB(
                            string.Format(
                            @"SELECT WK_TYPE
                                  FROM [Job]
                                  GROUP BY WK_TYPE"
                              )
                            );

            // 將DataTable的資料轉換為list
            List<SelectListItem> worktype = new List<SelectListItem>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                worktype.Add(new SelectListItem()
                {
                    Text = dt.Rows[i][0].ToString(),

                    Value = i.ToString()
                });
            }



            #endregion



            return worktype;
        }

        public List<SelectListItem> getCityName()
        {

            #region [做DB連線 以及 執行DB處理]

            // 建立DB連線
            Tools.DBConnection bsc = new Tools.DBConnection();
            #endregion
            // 取出地點種類
            #region[ 取出地點種類 ]

            DataTable dt = bsc.ReadDB(
                            string.Format(
                            @"SELECT CITYNAME
                                  FROM [Job]
                                  GROUP BY CITYNAME"
                              )
                            );
            // 將DataTable的資料轉換為list
            List<SelectListItem> cityname = new List<SelectListItem>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cityname.Add(new SelectListItem()
                {
                    Text = dt.Rows[i][0].ToString(),
                    Value = i.ToString()
                });
            }
            #endregion
            return cityname;

        }

        public List<SelectListItem> getCjob_Name1()
        {

            #region [做DB連線 以及 執行DB處理]

            // 建立DB連線
            Tools.DBConnection bsc = new Tools.DBConnection();
            #endregion
            // 取出職務大類別種類
            #region[ 取出職務大類別種類 ]

            DataTable dt = bsc.ReadDB(
                            string.Format(
                            @"SELECT CJOB_NAME1
                                  FROM [JobType]
                                  GROUP BY CJOB_NAME1"
                              )
                            );

            // 將DataTable的資料轉換為list
            List<SelectListItem> cjobname = new List<SelectListItem>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cjobname.Add(new SelectListItem()
                {
                    Text = dt.Rows[i][0].ToString(),
                    Value = i.ToString()
                });
            }


            #endregion


            return cjobname;
        }

        // 搜尋職缺清單
        public List<SJM.SearchJobModel> jobList(SJM.SearchJobModel sjm)
        {
            #region [做DB連線 以及 執行DB處理]

            // 建立DB連線
            Tools.DBConnection bsc = new Tools.DBConnection();
            #endregion
            // 取出職缺清單
            #region[ 取出職缺清單 ]
            string SQLComment = (sjm.CompName == null) ? "" : "AND C.COMPNAME LIKE '%" + sjm.CompName + "%' ";
            string SQLComment1 = (sjm.Cjob_Name1 == "不拘") ? "" : "AND JT.CJOB_NAME1 = '" + sjm.Cjob_Name1 + "'";
            string SQLComment2 = (sjm.CityName == "不拘") ? "" : " AND J.CITYNAME = '" + sjm.CityName + "'";
            string SQLComment3 = (sjm.Wk_Type == "不拘") ? "" : "AND J.WK_TYPE = '" + sjm.Wk_Type + "'";
            DataTable dt = bsc.ReadDB(
                            string.Format(
                            @"SELECT J.COMP_ID,C.COMPNAME,J.CITYNAME,J.JOB_ID,J.OCCU_DESC,J.WK_TYPE,J.CJOB_ID,JT.CJOB_NAME1
                                  FROM [Job] AS J , [JobType] AS JT ,[Company] AS C
                                  WHERE 1=1
                                  AND J.CJOB_ID = JT.CJOB_ID
                                  AND C.COMP_ID = J.COMP_ID
                                  {0} {1} {2} {3}"
                                  , SQLComment, SQLComment1, SQLComment2, SQLComment3)
                                );
            // 將DataTable的資料轉換為model
            List<SJM.SearchJobModel> joblist = new List<SJM.SearchJobModel>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                joblist.Add(new SJM.SearchJobModel()
                {
                    Comp_ID = dt.Rows[i][0].ToString(),
                    CompName = dt.Rows[i][1].ToString(),
                    CityName = dt.Rows[i][2].ToString(),
                    Job_ID = dt.Rows[i][3].ToString(),
                    Occu_Desc = dt.Rows[i][4].ToString(),
                    Wk_Type = dt.Rows[i][5].ToString(),
                    Cjob_ID = dt.Rows[i][6].ToString(),
                    Cjob_Name1 = dt.Rows[i][7].ToString()
                });
            }

            #endregion
            return joblist;

        }


        // 搜尋職缺細項
        public JM.JobModel jobDetail(string jobID)
        {

            // SQL指令 撈出職缺細項

            #region [做DB連線 以及 執行DB處理]

            // 建立DB連線
            Tools.DBConnection bsc = new Tools.DBConnection();
            #endregion
            // 取出職缺細項

            #region[ 取出職缺細項 ]

            DataTable dt = bsc.ReadDB(
                                string.Format(
                                @"SELECT *
                                  FROM [Job] AS J , [Company] AS C , [JobType] AS JT 
                                  WHERE 1=1
                                  AND J.JOB_ID = '{0}'
                                  AND J.COMP_ID = C.COMP_ID
                                  AND J.CJOB_ID = JT.CJOB_ID"
                                  , jobID)
                                );
            JM.JobModel jmModel = new JM.JobModel();
            // 將DataTable的資料轉換為model 將職缺細項列出

            jmModel.Job_ID = dt.Rows[0][0].ToString();
            jmModel.Occu_Desc = dt.Rows[0][1].ToString();
            jmModel.Wk_Type = dt.Rows[0][2].ToString();
            jmModel.Cjob_ID = dt.Rows[0][3].ToString();
            jmModel.Cjob_Name1 = dt.Rows[0][4].ToString();
            jmModel.AvailReqNum = Convert.ToInt16(dt.Rows[0][5]);
            jmModel.Stop_Date = dt.Rows[0][6].ToString();
            jmModel.Job_Detail = dt.Rows[0][7].ToString();
            jmModel.CityName = dt.Rows[0][8].ToString();
            jmModel.Experience = dt.Rows[0][9].ToString();
            jmModel.WkTime = dt.Rows[0][10].ToString();
            jmModel.SalaryCd = dt.Rows[0][11].ToString();
            jmModel.EdGrDesc = dt.Rows[0][12].ToString();
            jmModel.Url_Query = dt.Rows[0][13].ToString();
            jmModel.Comp_ID = dt.Rows[0][14].ToString();
            jmModel.CompName = dt.Rows[0][15].ToString();
            jmModel.TranDate = dt.Rows[0][16].ToString();



            #endregion

            return jmModel;
        }


        // 搜尋我的最愛
        public List<SJM.SearchJobModel> myFavorite(string user_ID)
        {
            #region [做DB連線 以及 執行DB處理]

            // 建立DB連線
            Tools.DBConnection bsc = new Tools.DBConnection();
            #endregion
            // 取出我的最愛
            #region[ 取出我的最愛 ]
            DataTable dt = bsc.ReadDB(
                            string.Format(
                            @"SELECT JOB_ID
                                  FROM [MyFavorite] 
                                  WHERE 1=1
                                  AND USER_ID = '{0}'"
                                  , user_ID)
                                );
            string[] job_ID = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                job_ID[i] = dt.Rows[i][0].ToString();
            }

            DataTable dt1 = bsc.ReadDB(
                            string.Format(
                            @"SELECT J.COMP_ID,C.COMPNAME,J.CITYNAME,J.JOB_ID,J.OCCU_DESC,J.WK_TYPE,J.CJOB_ID,JT.CJOB_NAME1
                                  FROM [Job] AS J , [JobType] AS JT ,[Company] AS C
                                  WHERE 1=1
                                  AND J.CJOB_ID = JT.CJOB_ID
                                  AND C.COMP_ID = J.COMP_ID
                                  AND JOB_ID IN ({0})"
                                  , job_ID)
                                );

            // 將DataTable的資料轉換為model
            List<SJM.SearchJobModel> joblist = new List<SJM.SearchJobModel>();
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                joblist.Add(new SJM.SearchJobModel()
                {
                    Comp_ID = dt1.Rows[i][0].ToString(),
                    CompName = dt1.Rows[i][1].ToString(),
                    CityName = dt1.Rows[i][2].ToString(),
                    Job_ID = dt1.Rows[i][3].ToString(),
                    Occu_Desc = dt1.Rows[i][4].ToString(),
                    Wk_Type = dt1.Rows[i][5].ToString(),
                    Cjob_ID = dt1.Rows[i][6].ToString(),
                    Cjob_Name1 = dt1.Rows[i][7].ToString()
                });
            }

            #endregion
            return joblist;

        }

        // 新增我的最愛 [ 評論model的attr. 皆為填入項目 ]
        public string insertMyFavorite(string user_ID, string job_ID)
        {
            #region [做DB連線 以及 執行DB處理]

            // 建立DB連線
            Tools.DBConnection bsc = new Tools.DBConnection();

            // 放入 我的最愛的資料
            string doDB = bsc.ActionDB(
                            string.Format(
                            @"INSERT INTO [MyFavorite] (USER_ID,JOB_ID)
                              VALUES('{0}','{1}');"
                              , user_ID, job_ID)
                            );

            // 如果 doDB為"success" ,代表DB連線成功 ,反之失敗
            if (doDB != "success")
            {
                return "DB處理錯誤";
            }

            #endregion

            #region[檢查DB內容]

            // 查看是否新增成功
            DataTable dt = bsc.ReadDB(
                             string.Format(
                             @"SELECT JOB_ID
                                  FROM [MyFavorite] 
                                  WHERE 1=1
                                  AND USER_ID = '{0}'
                                  AND JOB_ID = '{1}'"
                                   , user_ID, job_ID)
                                 );

            // 判斷 DB 是否有插入一模一樣的資料筆
            if (dt.Rows.Count == 0)
            {
                return "insert error!";
            }
            else
            {
                return "insert success!";
            }

            #endregion

        }

    }
}

