using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public string Job_ID { get; set; }


        ///<summary> 瀏覽時間 </summary>
        [Display(Name = "發表時間")]
        public string Time { get; set; }


        // 取出假資料,總共有兩筆資料
        public List<HistoryModel> getAllHistory()
        {
            // 建立list
            List<HistoryModel> result = new List<HistoryModel>();

            // 塞入 假資料
            result.Add(new HistoryModel
            {
                
                Job_ID = "0",
                User_ID = "ZhongZhong1",
                Time = "2018/12/02"
                

            });

            result.Add(new HistoryModel
            {
                Job_ID = "1",
                User_ID = "ZhongZhong2",
                Time = "2018/12/04"

            });

            // 回傳 假資料
            return result;
        }

    }
}