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

                    Value =i.ToString()
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
            string SQLComment = (sjm.CompName == null) ? "" : "AND C.COMPNAME =" + sjm.CompName;
            string SQLComment1 = (sjm.Cjob_Name1 == "不拘") ? "" : "AND JT.CJOB_NAME1 = " + sjm.Cjob_Name1;
            string SQLComment2 = (sjm.CityName == "不拘") ? "" : " AND J.CITYNAME = " + sjm.CityName;
            string SQLComment3 = (sjm.Wk_Type == "不拘") ? "" : "AND J.WK_TYPE =" + sjm.Wk_Type;
            DataTable dt = bsc.ReadDB(
                            string.Format(
                            @"SELECT J.COMP_ID,C.COMPNAME,J.CITYNAME,J.JOB_ID,J.OCCU_DESC,J.WK_TYPE,J.CJOB_ID,JT.CJOB_NAME1
                                  FROM [Job] AS J , [JobType] AS JT ,[Company] AS C
                                  WHERE 1=1
                                  AND J.CJOB_ID = JT.CJOB_ID
                                  AND C.COMP_ID = J.COMP_ID
                                  {0} {1} {2} {3}"
                                  , SQLComment1, SQLComment2, SQLComment3, SQLComment)
                                );
            // 將DataTable的資料轉換為model
            List<SJM.SearchJobModel> joblist = new List<SJM.SearchJobModel>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                joblist.Add(new SJM.SearchJobModel()
                {
                    Comp_ID = Convert.ToInt16(dt.Rows[i][0]),
                    CompName = dt.Rows[i][1].ToString(),
                    CityName = dt.Rows[i][2].ToString(),
                    Job_ID = Convert.ToInt16(dt.Rows[i][3]),
                    Occu_Desc = dt.Rows[i][4].ToString(),
                    Wk_Type = dt.Rows[i][5].ToString(),
                    Cjob_ID = Convert.ToInt16(dt.Rows[i][6]),
                    Cjob_Name1 = dt.Rows[i][7].ToString()
                });
            }

            #endregion
            return joblist;
            
        }


        // 搜尋職缺細項
        public List<JM.JobModel> jobDetail(int jobID)
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
                                  AND J.JOB_ID = {0}
                                  AND J.COMP_ID = C.COMP_ID
                                  AND J.CJOB_ID = JT.CJOB_ID"
                                  , jobID)
                                );
            List<JM.JobModel> jmModel = new List<JM.JobModel>();
            // 將DataTable的資料轉換為model 將職缺細項列出
            jmModel.Add(new JM.JobModel
            {
                Job_ID = Convert.ToInt16(dt.Rows[0][0]),
                Occu_Desc = dt.Rows[0][1].ToString(),
                Wk_Type = dt.Rows[0][2].ToString(),
                Cjob_ID = Convert.ToInt16(dt.Rows[0][3]),
                Cjob_Name1 = dt.Rows[0][4].ToString(),
                AvailReqNum = Convert.ToInt16(dt.Rows[0][5]),
                Stop_Date = dt.Rows[0][6].ToString(),
                Job_Detail = dt.Rows[0][7].ToString(),
                CityName = dt.Rows[0][8].ToString(),
                Experience = dt.Rows[0][9].ToString(),
                WkTime = dt.Rows[0][10].ToString(),
                SalaryCd = dt.Rows[0][11].ToString(),
                EdGrDesc = dt.Rows[0][12].ToString(),
                Url_Query = dt.Rows[0][13].ToString(),
                Comp_ID = Convert.ToInt16(dt.Rows[0][14]),
                CompName = dt.Rows[0][15].ToString(),
                TranDate = dt.Rows[0][16].ToString()
                        
            });
                

                #endregion
            
            return jmModel;
        }
        
    }
}