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
                                  FROM [Job] AS J
                                  GROUP BY WK_TYPE"
                              )
                            );

            // 將DataTable的資料轉換為list
            List<SelectListItem> worktype = new List<SelectListItem>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                worktype.Add(new SelectListItem()
                {
                    Text = dt.Rows[i].ToString(),
                    Value = Convert.ToString(i)
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
                                  FROM [Job] AS J
                                  GROUP BY CITYNAME"
                              )
                            );
            // 將DataTable的資料轉換為list
            List<SelectListItem> cityname = new List<SelectListItem>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cityname.Add(new SelectListItem()
                {
                    Text = dt.Rows[i].ToString(),
                    Value = Convert.ToString(i)
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
                                  FROM [Job] AS J
                                  GROUP BY CJOB_NAME1"
                              )
                            );

            // 將DataTable的資料轉換為list
            List<SelectListItem> cjobname = new List<SelectListItem>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cjobname.Add(new SelectListItem()
                {
                    Text = dt.Rows[i].ToString(),
                    Value = Convert.ToString(i)
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
            // 取出職務大類別種類
            #region[ 取出職缺清單 ]

            DataTable dt = bsc.ReadDB(
                            string.Format(
                            @"SELECT *
                                  FROM [Job] AS J , [JobType] AS JT 
                                  WHERE 1=1
                                  AND J.CJOB_NAME1 = {0}"
                                  , sjm.CityName , sjm.Cjob_Name1)
                                );

            // 將DataTable的資料轉換為list
            List<SelectListItem> cjobname = new List<SelectListItem>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cjobname.Add(new SelectListItem()
                {
                    Text = dt.Rows[i].ToString(),
                    Value = Convert.ToString(i)
                });
            }


            #endregion


            return cjobname;



            //List<SJM.SearchJobModel> sjmModel = new List<SJM.SearchJobModel>();
            // SQL指令 撈出職缺清單
            List<SJM.SearchJobModel> sjmModel = new List<SJM.SearchJobModel>()
            {
                new SearchJobModel(){Comp_ID=1,CompName="台積電",Job_ID=250,CityName="新北市",Occu_Desc="前端工程師",Wk_Type="全職",Cjob_ID=1,Cjob_Name1="程式設計師"},
                new SearchJobModel(){Comp_ID=2,CompName="鴻海",Job_ID=300,CityName="台北市",Occu_Desc="後端工程師",Wk_Type="兼職",Cjob_ID=1,Cjob_Name1="程式設計師"}
            };
            return sjmModel;
           

        }


        // 搜尋職缺細項
        public List<JM.JobModel> jobDetail(int jobID)
        {
            List<JM.JobModel> jmModel = new List<JM.JobModel>();
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
                                  FROM [Job] AS J , [Company] AS C , [JobType] AS JT , [Comment] AS C
                                  WHERE 1=1
                                  AND J.JOB_ID = {0}
                                  AND J.COMP_ID = C.COMP_ID
                                  AND J.CJOB_ID = JT.CJOB_ID"
                                  , jobID)
                                );

                // 將DataTable的資料轉換為model 將職缺細項列出 評論要迴圈
                    jmModel.Add(new JM.JobModel
                    {
                        //JOB_ID = Convert.ToInt16(dt.Rows[0][0].ToString()),
                        //Occu_Desc = Convert.ToInt16(dt.Rows[0][1]),
                        //Wk_Type = Convert.ToInt16(dt.Rows[0][2]),
                        //Cjob_ID = dt.Rows[0][3].ToString(),
                        //AvailReqNum = dt.Rows[0][4].ToString(),
                        //Stop_Date = Convert.ToInt16(dt.Rows[0][5]),
                        //Job_Detail = dt.Rows[0][6].ToString()
                        //CityName = dt.Rows[0][6].ToString()
                        //Experience = dt.Rows[0][6].ToString()
                        //WkTime = dt.Rows[0][6].ToString()
                        //SalaryCd = dt.Rows[0][6].ToString()
                        //EdGrDesc = dt.Rows[0][6].ToString()
                        //Url_Query = dt.Rows[0][6].ToString()
                        //Comp_ID = dt.Rows[0][6].ToString()
                        //TranDate = dt.Rows[0][6].ToString()
                        //Cjob_Name1 = dt.Rows[0][6].ToString()
                        //CompName = dt.Rows[0][6].ToString()
                    });
                

                #endregion
            
            return jmModel;
        }
        
    }
}