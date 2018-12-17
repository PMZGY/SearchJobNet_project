using System;
using System.Data.SqlClient;
using System.Data;

namespace SearchJobNet_project.Tools
{
    // 有四項功能 [新增,刪除,修改,瀏覽]功能 , [新增,刪除,修改]功能 為同一支
    public class DBConnection
    {
        // [新增] 資料至DB
        // 若DB程序錯誤 ,則回傳"DB wrong!!+錯誤點" ,反之,回傳"success"
        public string ActionDB(string SQLComment)
        {
            try
            {
                //處理狀態
                string state = "";

                // 設定連線資料[DB_IP / 資料庫名字 / 使用者帳號 / 密碼](這行是固定的，不用改)
                string ConStr = "data source=140.115.87.142,1433; initial catalog=JobDB; User ID = searchjob; Password = searchjob";

                // 建立連線
                SqlConnection conn = new SqlConnection(ConStr);

                //開始連線
                conn.Open();

                // 編輯 動作[新增,刪除,修改] 指令        
                string action_query = SQLComment;

                // new 一個 SqlCommand
                SqlCommand cmd = new SqlCommand(action_query, conn);

                // 執行處理db,並回傳影響筆數

                int count = cmd.ExecuteNonQuery();
                if (count > 0) state = "success";

                //關閉連線
                conn.Close();

                // 回傳 執行完畢
                return state;

            }
            catch (Exception e)
            {
                return "DB wrong!!"+e;
            }
        }

        // [瀏覽] DB資料
        public DataTable ReadDB(string SQLComment)
        {
            
            // 設定連線資料[DB_IP / 資料庫名字 / 使用者帳號 / 密碼](這行是固定的，不用改)
            string ConStr = "Data Source=140.115.87.142,1433; Initial Catalog=JobDB; User ID = searchjob; Password = searchjob";

            // 建立連線
            SqlConnection conn = new SqlConnection(ConStr);

            //開始連線
            conn.Open();

            // 編輯 query 指令                      
            string sql_query_string = SQLComment;

            // new 一個 SqlCommand
            SqlCommand cmd = new SqlCommand(sql_query_string, conn);

            //new 一個 SqlDataAdapter 接資料
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            //new 一個 DataSet 存資料(一個DataSet裡可以有很多table)
            DataSet ds = new DataSet();

            //把 da  接到的table 存到 ds 裡，並命名為"GETTABLE"
            da.Fill(ds, "GETTABLE");

            // 把table的欄位回傳至expert
            return ds.Tables["GETTABLE"];
                          
        }
       
    }
}