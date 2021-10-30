using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// 大小文字区別フラグ
    /// </summary>
    public bool IsCaseSens { get; set; }

    /// <summary>
    /// 改行モード判断フラグ
    /// </summary>
    public bool IsNewLine { get; set; }

    /// <summary>
    /// タブモード判断フラグ
    /// </summary>
    public bool IsTab { get; set; }

    /// <summary>
    /// エクセルモード判断フラグ
    /// </summary>
    public bool IsExcelMode { get; set; }
    
    /// <summary>
    /// 置換後文字列
    /// </summary>
    public string ReplacedStr { get; set; }

    /// <summary>
    /// 一括置換モード判断フラグ
    /// </summary>
    public bool IsMultRep { get; set; }

    /// <summary>
    /// 対象フォルダパス
    /// </summary>
    public string TgtDirPath { get; set; }

    /// <summary>
    /// ファイルフィルタ文字列
    /// </summary>
    public string FileFilter { get; set; }

    /// <summary>
    /// 文字コード
    /// </summary>
    public Encoding Enc { get; set; }

    /// <summary>
    /// 出力先フォルダパス文字列
    /// </summary>
    public string DestDirPath { get; set; }

    /// <summary>
    /// メインフォームサイズ
    /// </summary>
    public Size MainFormSize { get; set; }

    /// <summary>
    /// メインフォーム位置
    /// </summary>
    public Point MainFormLoca { get; set; }

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
