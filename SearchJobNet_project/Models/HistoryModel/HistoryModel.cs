using System.Collections.Generic;

namespace SearchJobNet_project.Models.HistoryModel
{
    public class HistoryModel
    {
        ///<summary> 使用者PK </summary>
        public string User_ID { get; set; }

        ///<summary> 職缺Pk </summary>
        public string Job_ID { get; set; }

        ///<summary> 瀏覽時間 </summary>
        public string Time { get; set; }
        //建立假資料,總共有兩筆資料
        public HistoryModel()
        {
            // 建立list
            List<HistoryModel> hm = new List<HistoryModel>();

            // 塞入第一筆假資料
            HistoryModel hms = new HistoryModel();
            hms.User_ID = "zhongzhong";
            hms.Job_ID = "0";
            hms.Time = "2018/12/04";
            
            hm.Add(hms);
            
            // 塞入第二筆假資料
            hms=new HistoryModel();
            hms.User_ID = "zhongzhong2";
            hms.Job_ID = "1";
            hms.Time = "2018/12/04";

            hm.Add(hms);
        }
    }
}