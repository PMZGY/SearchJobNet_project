
namespace SearchJobNet_project.Models.CommentModel
{
    public class CommentModel
    {
        ///<summary> 評論者姓名 </summary>
        public string CommentName { get; set; }

        ///<summary> 內容 </summary>
        public string Context { get; set; }

        // 建立假資料
        public CommentModel()
        {
            // 塞入假資料
            this.CommentName = "ponpon";
            this.Context     = "I like this job!!";
        }
      
    }
            
}