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
    public List<string> Xml2CsvList { get; set; }
    /// <summary>
    /// CSV変換後階層順要素情報リスト
    /// </summary>
    public List<string> ElemInfo2CsvList { get; set; }

    /// <summary>
    /// フルパスカラムディクショナリ
    /// </summary>
    public Dictionary<int, string> FullPathColDic { get; set; }
    /// <summary>
    /// 要素名称カラムディクショナリ
    /// </summary>
    public Dictionary<int, string> ElemNmColDic { get; set; }
    /// <summary>
    /// 属性カラムディクショナリ
    /// </summary>
    public Dictionary<int, string> AttrColDic { get; set; }
    /// <summary>
    /// 値カラムディクショナリ
    /// </summary>
    public Dictionary<int, string> ValColDic { get; set; }

    /// <summary>
    /// 階層順要素情報階層カラムディクショナリ
    /// </summary>
    public Dictionary<int, string> DpElemInfoElemColDic { get; set; }

    /// <summary>
    /// 階層順要素情報空要素フラグカラムディクショナリ
    /// </summary>
    public Dictionary<int, string> DpElemInfoEmptyFlgColDic { get; set; }

    /// <summary>
    /// 累計パスリスト
    /// </summary>
    public List<string> CmlPathList { get; set; }

    /// <summary>
    /// 最大要素階層数
    public int ElemMaxDepthNum { get; set; }

    /// <summary>
    /// 最大属性数
    /// </summary>
    public int AttrMaxDepthNum { get; set; }

    /// <summary>
    /// 合計行数
    /// </summary>
    public int TotalRowNum { get; set; }

    /// <summary>
    /// 前回階層数
    /// </summary>
    public int PreDepthNum { get; set; }

    #endregion


    #region コンストラクタ
    public DataStore()
    {
      // プロパティ初期化
      Xml2CsvList = new List<string>();
      ElemInfo2CsvList = new List<string>();

      FullPathColDic = new Dictionary<int, string>();
      ElemNmColDic = new Dictionary<int, string>();
      AttrColDic = new Dictionary<int, string>();
      ValColDic = new Dictionary<int, string>();

      DpElemInfoElemColDic = new Dictionary<int, string>();
      DpElemInfoEmptyFlgColDic = new Dictionary<int, string>();

      CmlPathList = new List<string>();

      AttrMaxDepthNum = 0;
      TotalRowNum = 0;
      PreDepthNum = 0;
    }
    #endregion
  }
}
