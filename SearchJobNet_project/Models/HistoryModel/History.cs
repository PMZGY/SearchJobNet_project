using  System;
using System.Collections.Generic;
using HM = SearchJobNet_project.Models.HistoryModel;

namespace SearchJobNet_project.Models.HistoryModel
{
    public class History
    {
        public string insertHistory(HM.HistoryModel iHistory)
        {
            // do SQL insertHistory
            return "insert data success";
        }
        public List<HM.HistoryModel> browseHistoryjob(string jobID, string userID)
        {
            List<HM.HistoryModel> bHistoryModel = new List<HM.HistoryModel>();
            HM.HistoryModel hmlist = new HM.HistoryModel();


            return bHistoryModel;
        }
        public List<HM.HistoryModel> browseHistorycomment(int userID)
        {
            List<HM.HistoryModel> bHistoryModelc = new List<HM.HistoryModel>();
            HM.HistoryModel hmlist = new HM.HistoryModel();


            return bHistoryModelc;
        }
    }
}