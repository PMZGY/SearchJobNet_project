using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

namespace SearchJobNet_project.Tools
{
    public class DBConnection
    {
        // 處理 新增資料至
        public void InsertDB()
        {
            // 設定連線資料[DB_IP / 資料庫名字 / 使用者帳號 / 密碼](這行是固定的，不用改)
            string ConStr = "data source=140.115.87.142,1433; initial catalog=JobDB; User ID = searchjob; Password = searchjob";

            // 建立連線
            SqlConnection conn = new SqlConnection(ConStr);

            //開始連線
            conn.Open();

            // 編輯 insert 指令              [table_name] (col1, col2)     (@變數)
            string insert_query = "INSERT INTO [Company] (COMPNAME) VALUES (@COMPNAME)";

            // new 一個 SqlCommand
            SqlCommand cmd = new SqlCommand(insert_query, conn);

            // 用cmd給值，cmd.Parameters.AddWithValue(變數 , 值) 
            cmd.Parameters.AddWithValue("@COMPNAME", "TEST_COMPNAME");

            //結束cmd
            cmd.ExecuteNonQuery();

            //關閉連線
            conn.Close();

        }

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

            //select * from [Company]

            // new 一個 SqlCommand
            SqlCommand cmd = new SqlCommand(sql_query_string, conn);

            //new 一個 SqlDataAdapter 接資料
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            //new 一個 DataSet 存資料(一個DataSet裡可以有很多table)
            DataSet ds = new DataSet();

            //把 da  接到的table 存到 ds 裡，並命名為"GETTABLE"
            da.Fill(ds, "GETTABLE");

            //                              DataSet /   Tabl  /  Row  /  Column
            //印出ds裡的值                        ds / Company / 第1行 / "COMPNAME"欄   

            // 把table的欄位回傳至expert
            return ds.Tables["GETTABLE"];
                
            // Console.WriteLine("Company name= " + ds.Tables["Company"].Rows[0]["COMPNAME"].ToString());
            
            
        }
       
    }
}