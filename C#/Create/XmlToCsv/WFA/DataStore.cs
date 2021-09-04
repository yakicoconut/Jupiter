using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA
{
  public class DataStore
  {
    #region プロパティ

    /// <summary>
    /// CSV変換後リスト
    /// </summary>
    public List<string> ConvdCsvList { get; set; }
    /// <summary>
    /// 階層順要素リスト
    /// </summary>
    public List<string> DepthElemList { get; set; }

    /// <summary>
    /// フルパスカラムディクショナリ
    /// </summary>
    public Dictionary<int, string> FullPathColDic { get; set; }
    /// <summary>
    /// 属性カラムディクショナリ
    /// </summary>
    public Dictionary<int, string> AttrColDic { get; set; }
    /// <summary>
    /// 値カラムディクショナリ
    /// </summary>
    public Dictionary<int, string> ValColDic { get; set; }

    /// <summary>
    /// 累計パスリスト
    /// </summary>
    public List<string> CmlPathList { get; set; }

    /// <summary>
    /// 最大属性数
    /// </summary>
    public int AttrMaxDepthNum { get; set; }

    /// <summary>
    /// 現在階層数
    /// </summary>
    public int CrDepthNum { get; set; }

    /// <summary>
    /// 前回階層数
    /// </summary>
    public int PreDepthNum { get; set; }

    #endregion


    #region コンストラクタ
    public DataStore()
    {
      // プロパティ初期化
      ConvdCsvList = new List<string>();
      DepthElemList = new List<string>();
      FullPathColDic = new Dictionary<int, string>();
      AttrColDic = new Dictionary<int, string>();
      ValColDic = new Dictionary<int, string>();
      CmlPathList = new List<string>();
      AttrMaxDepthNum = 0;
      CrDepthNum = 0;
      PreDepthNum = 0;
    }
    #endregion
  }
}
