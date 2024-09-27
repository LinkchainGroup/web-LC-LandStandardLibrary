using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LandStandardLibrary
{
    public interface ILandNoTool
    {
        /// <summary>
        /// 取得標準化地號列表
        /// </summary>
        /// <returns></returns>
        List<LandNoResult> Build();
        /// <summary>
        /// 正規化
        /// 使用者只需呼叫此方法即可包含其他所有的轉換
        /// </summary>
        /// <returns></returns>
        LandNoTool Normalize();
        /// <summary>
        /// 去除空白
        /// </summary>
        /// <returns></returns>
        LandNoTool Trim();
        /// <summary>
        /// 數字和連結號，全形轉半形
        /// </summary>
        /// <returns></returns>
        LandNoTool FullToHalf();
        /// <summary>
        /// 驗證地號正確性
        /// </summary>
        /// <returns></returns>
        LandNoTool Verify();
        /// <summary>
        /// 補Dash
        /// </summary>
        /// <returns></returns>
        LandNoTool PadDash();
        /// <summary>
        /// 補零
        /// </summary>
        /// <param name="landNo"></param>
        /// <returns></returns>
        LandNoTool PadZero();
    }

    /// <summary>
    /// 地號處理工具
    /// </summary>
    public class LandNoTool : ILandNoTool
    {
        #region 屬性
        private static char[] legalNumber = new char[] { 
            '0', '1', '2', '3', '4', 
            '5', '6', '7', '8', '9' 
        };
        private List<LandNoResult> LandNoList = new List<LandNoResult>();
        #endregion 屬性

        #region 建構式
        /// <summary>
        /// 建構式(處理單一地號)
        /// </summary>
        /// <param name="landno">要處理的地號字串</param>
        public LandNoTool(string landno)
        {
            LandNoList.Add(new LandNoResult(landno));
        }
        /// <summary>
        /// 建構式(處理單一地號)
        /// </summary>
        /// <param name="landno">要處理的地號字串</param>
        /// <param name="id">識別碼</param>
        public LandNoTool(string landno, int id)
        {
            LandNoList.Add(new LandNoResult(landno, id));
        }
        /// <summary>
        /// 建構式(處理多個地號)
        /// </summary>
        /// <param name="landnos">要處理的地號字串清單</param>
        public LandNoTool(List<string> landnos)
        {
            LandNoList = landnos.Select(a => new LandNoResult(a)).ToList();
        }
        /// <summary>
        /// 建構式(處理多個地號)
        /// </summary>
        /// <param name="landnos">要處理的地號字串與識別碼清單</param>
        public LandNoTool(List<KeyValuePair<int, string>> landnos)
        {
            LandNoList = landnos.Select(a => new LandNoResult(a.Value, a.Key)).ToList();
        }
        #endregion 建構式

        /// <inheritdoc />
        public LandNoTool Normalize()
        {
            Trim();
            FullToHalf();
            Verify();
            PadDash();
            PadZero();
            return this;
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
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
                        case '－':
                        case '—':
                            sb.Append('-');
                            break;
                        case '（':
                            sb.Append('(');
                            break;
                        case '）':
                            sb.Append(')');
                            break;
                        case '　':
                            sb.Append(' ');
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

        /// <inheritdoc />
        public LandNoTool Verify()
        {
            LandNoList.ForEach(a =>
            {
                if (a.LandNo == string.Empty)
                {
                    a.IsNormalized = false;
                    a.ErrorMsg = "地號不可為空";
                }
                else if (a.LandNo.First() == '(' && a.LandNo.Last() == ')')
                {
                    a.IsCustom = true;
                    a.IsNormalized = false;
                    a.ErrorMsg = "";
                }
                else
                {
                    if (a.LandNo.All(char.IsDigit) && a.LandNo.Length == 8)
                    {
                        a.IsNormalized = true;
                        a.ErrorMsg = "";
                    }
                    else
                    {
                        var splitArr = a.LandNo.Split('-');
                        if (!splitArr.Any(x => !string.IsNullOrEmpty(x)))
                        {
                            a.IsNormalized = false;
                            a.ErrorMsg = "地號不可為空";
                        }
                        else if (splitArr.Length > 2)
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
                }
            });
            return this;
        }

        /// <inheritdoc />
        public LandNoTool PadDash()
        {
            LandNoList
                .Where(a => a.IsNormalized
                            && a.LandNo.All(char.IsDigit)
                            && a.LandNo.Length == 8)
                .ToList()
                .ForEach(x =>
                {
                    x.LandNo = x.LandNo.Insert(4, "-");
                });
            return this;
        }

        /// <inheritdoc />
        public LandNoTool PadZero()
        {
            LandNoList.ForEach(a =>
            {
                if (a.IsNormalized)
                {
                    if (a.LandNo != string.Empty)
                    {
                        var splitArr = a.LandNo.Split('-').ToList();
                        if (splitArr.Count() == 1 && splitArr[0].Length <= 4) 
                        { 
                            splitArr.Add(""); 
                        }

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

        /// <inheritdoc />
        public List<LandNoResult> Build()
        {
            return LandNoList;
        }
    }
}
