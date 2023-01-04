using System.Collections.Generic;

namespace LandStandardLibrary
{
    public interface ILandNoTool
    {
        List<string> Build();
        LandNoTool Trim();
        LandNoTool FullToHalf();
        LandNoTool PadZero();        
    }

    /// <summary>
    /// 地號處理工具
    /// </summary>
    public class LandNoTool : ILandNoTool
    {
        private List<string> LandNoList = new List<string>();
        public LandNoTool(string landno)
        {
            LandNoList.Add(landno);
        }
        public LandNoTool(List<string> landnos)
        {
            LandNoList = landnos;
        }

        /// <summary>
        /// 去除空白
        /// </summary>
        /// <returns></returns>
        public LandNoTool Trim()
        {
            return this;
        }

        /// <summary>
        /// 數字全形轉半形
        /// </summary>
        /// <returns></returns>
        public LandNoTool FullToHalf()
        {
            return this;
        }

        /// <summary>
        /// 補零
        /// </summary>
        /// <param name="landNo"></param>
        /// <returns></returns>
        public LandNoTool PadZero ()
        {
            return this;
        }

        /// <summary>
        /// 取得標準化地號列表
        /// </summary>
        /// <returns></returns>
        public List<string> Build()
        {
            return LandNoList;
        }
    }
}
