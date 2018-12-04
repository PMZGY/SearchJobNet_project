
using System.Collections.Generic;

namespace SearchJobNet_project.Models.CommentModel
{
    public class CommentModel
    {
        ///<summary> 評論PK </summary>
        public string Comment_ID { get; set; }

        ///<summary> 職缺 </summary>
        public string Job_ID { get; set; }

        ///<summary> 發表者 </summary>
        public string User_ID { get; set; }

        ///<summary> 內容 </summary>
        public string Content { get; set; }

        ///<summary> 發表時間 </summary>
        public string Time { get; set; }

        ///<summary> 檢舉數 </summary>
        public int Report_no { get; set; }

        ///<summary> 是否存在 </summary>
        public bool Is_Alive { get; set; }

        // 建立假資料,總共有兩筆資料
        public CommentModel()
        {
            // 建立list
            List<CommentModel> cm = new List<CommentModel>();
            
            // 塞入第一筆假資料
            CommentModel cms = new CommentModel();
            cms.Comment_ID   = "A01";
            cms.Job_ID       = "0";
            cms.User_ID      = "Anna";
            cms.Content      = "It is good !";
            cms.Time         = "2018/12/04";
            cms.Report_no    = 0;
            cms.Is_Alive     = true;
            cm.Add(cms);

            // 塞入第二筆假資料
            cms = new CommentModel();
            cms.Comment_ID   = "A02";
            cms.Job_ID       = "1";
            cms.User_ID      = "Ally";
            cms.Content      = "It is excellent !";
            cms.Time         = "2018/12/03";
            cms.Report_no    = 0;
            cms.Is_Alive     = true;
            cm.Add(cms);

        }


      
    }
            
}