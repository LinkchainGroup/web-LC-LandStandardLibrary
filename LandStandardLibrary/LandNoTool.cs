using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LandStandardLibrary
{
    public interface ILandNoTool
    {
        List<LandNoResult> Build();
        LandNoTool Normalize();

        LandNoTool Trim();
        LandNoTool FullToHalf();
        LandNoTool PadZero();
    }

    /// <summary>
    /// 地號處理工具
    /// </summary>
    public class LandNoTool : ILandNoTool
    {
        private List<LandNoResult> LandNoList = new List<LandNoResult>();
        public LandNoTool(string landno)
        {
            LandNoList.Add(new LandNoResult(landno));
        }
        public LandNoTool(string landno, int id)
        {
            LandNoList.Add(new LandNoResult(landno, id));
        }
        public LandNoTool(List<string> landnos)
        {
            LandNoList = landnos.Select(a => new LandNoResult(a)).ToList();
        }

        public LandNoTool(List<KeyValuePair<int, string>> landnos)
        {
            LandNoList = landnos.Select(a => new LandNoResult(a.Value, a.Key)).ToList();
        }

        /// <summary>
        /// 使用者只需呼叫此方法即可包含其他所有的轉換
        /// </summary>
        /// <returns></returns>
        public LandNoTool Normalize()
        {
            Trim();
            FullToHalf();
            Verify();
            PadZero();
            return this;
        }

        /// <summary>
        /// 去除空白
        /// </summary>
        /// <returns></returns>
        public LandNoTool Trim()
        {
            LandNoList.ForEach(a =>
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < a.LandNo.Length; i++)
                {
                    if (!char.IsWhiteSpace(a.LandNo[i]))
                    {
                        sb.Append(a.LandNo[i]);
                    }
                }
                a.LandNo = sb.ToString();
            });
            return this;
        }

        /// <summary>
        /// 數字全形轉半形
        /// </summary>
        /// <returns></returns>
        public LandNoTool FullToHalf()
        {
            LandNoList.ForEach(a =>
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < a.LandNo.Length; i++)
                {
                    switch (a.LandNo[i])
                    {
                        case '１':
                            sb.Append('1');
                            break;
                        case '２':
                            sb.Append('2');
                            break;
                        case '３':
                            sb.Append('3');
                            break;
                        case '４':
                            sb.Append('4');
                            break;
                        case '５':
                            sb.Append('5');
                            break;
                        case '６':
                            sb.Append('6');
                            break;
                        case '７':
                            sb.Append('7');
                            break;
                        case '８':
                            sb.Append('8');
                            break;
                        case '９':
                            sb.Append('9');
                            break;
                        case '０':
                            sb.Append('0');
                            break;
                        default:
                            sb.Append(a.LandNo[i]);
                            break;
                    }
                }
                a.LandNo = sb.ToString();
            });
            return this;
        }

        /// <summary>
        /// 驗證地號正確性
        /// </summary>
        /// <returns></returns>
        public LandNoTool Verify()
        {
            var legalNumber = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            LandNoList.ForEach(a =>
            {
                if (a.LandNo == string.Empty)
                {
                    a.IsNormalized = true;
                    a.ErrorMsg = "";
                }
                else if (a.LandNo.First() == '(' && a.LandNo.Last() == ')')
                {
                    a.IsCustom = true;
                    a.IsNormalized = false;
                    a.ErrorMsg = "";
                }
                else
                {
                    var splitArr = a.LandNo.Split('-');
                    if (splitArr.Length > 2)
                    {
                        a.IsNormalized = false;
                        a.ErrorMsg = "非標準地號";
                    }
                    else if (splitArr.Sum(arr => arr.Length) > 8)
                    {
                        a.IsNormalized = false;
                        a.ErrorMsg = "非標準地號";
                    }
                    else if (splitArr.Any(c => c.Length > 4))
                    {
                        a.IsNormalized = false;
                        a.ErrorMsg = "非標準地號";
                    }
                    else if (splitArr.SelectMany(c => c).Any(b => !legalNumber.Contains(b)))
                    {
                        a.IsNormalized = false;
                        a.ErrorMsg = "非標準地號";
                    }
                    else
                    {
                        a.IsNormalized = true;
                        a.ErrorMsg = "";
                    }
                }
            });
            return this;
        }

        /// <summary>
        /// 補零
        /// </summary>
        /// <param name="landNo"></param>
        /// <returns></returns>
        public LandNoTool PadZero()
        {
            LandNoList.ForEach(a =>
            {
                if (a.IsNormalized)
                {
                    if (a.LandNo != string.Empty)
                    {
                        var splitArr = a.LandNo.Split('-').ToList();
                        if (splitArr.Count() == 1) { splitArr.Add(""); }

                        for (var i = 0; i < splitArr.Count(); i++)
                        {
                            splitArr[i] = splitArr[i].PadLeft(4, '0');
                        }

                        a.LandNo = string.Join("-", splitArr);
                    }
                    else
                    {
                        a.LandNo = string.Empty;
                    }
                }
            });

            return this;
        }

        /// <summary>
        /// 取得標準化地號列表
        /// </summary>
        /// <returns></returns>
        public List<LandNoResult> Build()
        {
            return LandNoList;
        }
    }

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

        public LandNoResult(string landNo)
        {
            LandNo = landNo;
        }

        public LandNoResult(string landNo, int id)
        {
            LandNo = landNo;
            ID = id;
        }
    }
}
