
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

        // 取出假資料,總共有兩筆資料
        public List<CommentModel> getAllComment()
        {
            // 建立list
            List<CommentModel> result = new List<CommentModel>();

            // 塞入 假資料
            result.Add(new CommentModel
            {
                Comment_ID = "A01",
                Job_ID     = "0",
                User_ID    = "Anna",
                Content    = "It is good !",
                Time       = "2018/12/04",
                Report_no  = 0,
                Is_Alive   = true

            });

            result.Add(new CommentModel
            {
                Comment_ID = "A02",
                Job_ID     = "1",
                User_ID    = "Ally",
                Content    = "It is excellent !",
                Time       = "2018/12/03",
                Report_no  = 0,
                Is_Alive   = true

            });

            // 回傳 假資料
            return result;
        }
      
    }
            
}