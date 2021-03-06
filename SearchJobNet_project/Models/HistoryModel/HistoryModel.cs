﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CM = SearchJobNet_project.Models.CommentModel;
using SJM = SearchJobNet_project.Models.SearchJobModel;
namespace SearchJobNet_project.Models.HistoryModel
{
	public class HistoryModel
	{              
        ///<summary> 發表者 </summary>
        [Required]
        [Display(Name = "發表者")]
        public string User_ID { get; set; }

        ///<summary> 職缺 </summary>
        [Required]
        [Display(Name = "職缺")]
        public int Job_ID { get; set; }


        ///<summary> 瀏覽時間 </summary>
        [Display(Name = "發表時間")]
        public string Time { get; set; }

        ///<summary> 評論model </summary>
        public CM.CommentModel commentModel { get; set; }

        ///<summary> search job model </summary>
        public SJM.SearchJobModel searchjobModel { get; set; }
    }
}