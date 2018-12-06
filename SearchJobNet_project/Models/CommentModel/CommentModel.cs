using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SearchJobNet_project.Models.CommentModel
{
    public class CommentModel
    {
        ///<summary> 評論PK </summary>
        [Required]
        [Display(Name = "評論PK")]
        public string Comment_ID { get; set; }

        ///<summary> 職缺 </summary>
        [Display(Name = "職缺")]
        public string Job_ID { get; set; }

        ///<summary> 發表者 </summary>
        [Display(Name = "發表者")]
        public string User_ID { get; set; }

        ///<summary> 內容 </summary>
        [Display(Name = "內容")]
        public string Content { get; set; }

        ///<summary> 發表時間 </summary>
        [Display(Name = "發表時間")]
        public string Time { get; set; }

        ///<summary> 檢舉數 </summary>
        [Display(Name = "檢舉數")]
        public int Report_no { get; set; }

        ///<summary> 是否存在 </summary>
        [Display(Name = "是否存在")]
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