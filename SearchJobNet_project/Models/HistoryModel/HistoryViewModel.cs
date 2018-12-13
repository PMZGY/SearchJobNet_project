using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CM = SearchJobNet_project.Models.CommentModel;
using SJM = SearchJobNet_project.Models.SearchJobModel;
namespace SearchJobNet_project.Models.HistoryViewModel
{
    public class HistoryViewModel
    {
        public HistoryModel.HistoryModel History { get; set; }
        public CM.CommentModel Comment { get; set; }
        public SJM.SearchJobModel SearchJob { get; set; }
    }
}