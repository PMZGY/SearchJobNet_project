using System.Collections.Generic;
using HM = SearchJobNet_project.Models.HistoryModel;

namespace SearchJobNet_project.Controllers.HistoryController
{
	public class HistoryController
	{
        // 建立建構子
        public HistoryController() { }

        #region 歷史紀錄功能 [生成瀏覽紀錄/瀏覽瀏覽紀錄/瀏覽評論紀錄]
        
        // 傳入 歷史model, 執行[生成瀏覽職缺紀錄] 功能
        // 回傳 成功新增資料與否
        public string insertHistory(HM.HistoryModel historyModel)
        {
            string msg = "";
            HM.History hm = new HM.History();
            msg = hm.insertHistory(historyModel);
            return msg;
        }
        // 傳入 使用者PK,職缺PK 執行 [瀏覽瀏覽職缺紀錄] 功能
        // 回傳 整筆資料或部分資料(list的HistoryModel型態)
        public List<HM.HistoryModel> browseHistoryjob(string jobID,string userID)
        {
            HM.History hm = new HM.History();
            List<HM.HistoryModel> hmModel = new List<HM.HistoryModel>();
            hmModel = hm.browseHistoryjob(jobID,userID);
            return hmModel;
        }

        
        // 傳入 使用者PK 執行 [瀏覽評論紀錄] 功能
        // 回傳 整筆資料或部分資料(list的HistoryModel型態)
        public List<HM.HistoryModel> browseHistorycomment(string userID)
        {
            HM.History hm = new HM.History();
            List<HM.HistoryModel> hmModel = new List<HM.HistoryModel>();
            hmModel = hm.browseHistorycomment(userID);
            return hmModel;
        }


        #endregion
    }
}