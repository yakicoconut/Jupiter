using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WFA
{
  /// <summary>
  /// データ連携クラス
  /// </summary>
  public class DataStore
  {
    #region プロパティ

    /// <summary>
    /// チェックボックスリスト
    /// </summary>
    public List<CheckBox> ListChkBox { get; set; }
    /// <summary>
    /// 検索対象テキストボックスリスト
    /// </summary>
    public List<TextBox> ListTbSearch { get; set; }
    /// <summary>
    /// 置換文字列テキストボックスリスト
    /// </summary>
    public List<TextBox> ListTbReplace { get; set; }

    /// <summary>
    /// 対象文字列
    /// </summary>
    public string TgtStr { get; set; }

    /// <summary>
    /// 大小文字判別
    /// </summary>
    public bool IsIgnoreCase { get; set; }

    /// <summary>
    /// 改行モード判断
    /// </summary>
    public bool IsNewLine { get; set; }

    /// <summary>
    /// 置換後文字列
    /// </summary>
    public string ReplacedStr { get; set; }

    #endregion

    #region コンストラクタ
    public DataStore()
    {
      // コントロールリストインスタンス生成
      ListChkBox = new List<CheckBox>();
      ListTbSearch = new List<TextBox>();
      ListTbReplace = new List<TextBox>();
    }
    #endregion
  }
}
