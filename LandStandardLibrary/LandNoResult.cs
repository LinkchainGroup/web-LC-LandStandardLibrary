namespace LandStandardLibrary
{
    /// <summary>
    /// 地號標準化結果Model
    /// </summary>
    public class LandNoResult
    {
        /// <summary>
        /// 地號
        /// </summary>
        public string LandNo { get; set; } = "";
        /// <summary>
        /// 是否為自定義地號
        /// </summary>
        public bool IsCustom { get; set; } = false;
        /// <summary>
        /// 是否成功標準化
        /// </summary>
        public bool IsNormalized { get; set; } = false;
        /// <summary>
        /// 錯誤訊息
        /// </summary>
        public string ErrorMsg { get; set; } = "";
        /// <summary>
        /// 參照用的ID
        /// </summary>
        public int ID { get; set; } = 0;

        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="landNo">要處理的地號字串</param>
        public LandNoResult(string landNo)
        {
            LandNo = landNo;
        }

        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="landNo">要處理的地號字串</param>
        /// <param name="id">識別碼</param>
        public LandNoResult(string landNo, int id)
        {
            LandNo = landNo;
            ID = id;
        }
    }
}
