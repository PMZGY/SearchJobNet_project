using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SearchJobNet_project.Models.CommentModel
{
    public class CommentModel
    {
        ///<summary> 評論PK </summary>
        [Required]
        [Display(Name = "評論PK")]
        public int Comment_ID { get; set; }

        ///<summary> 職缺 </summary>
        [Display(Name = "職缺")]
        public int Job_ID { get; set; }

        ///<summary> 發表者 </summary>
        [Display(Name = "發表者")]
        public int User_ID { get; set; }

        ///<summary> 內容 </summary>
        [Display(Name = "內容")]
        public string Content_Text { get; set; }

        ///<summary> 發表時間 </summary>
        [Display(Name = "發表時間")]
        public string Time { get; set; }

        ///<summary> 檢舉數 </summary>
        [Display(Name = "檢舉數")]
        public int Report_no { get; set; }

        ///<summary> 是否存在 </summary>
        [Display(Name = "是否存在")]
        public string Is_Alive { get; set; }

    }
            
}