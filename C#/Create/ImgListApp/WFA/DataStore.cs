using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA
{
  /// <summary>
  /// データ格納クラス
  /// </summary>
  class DataStore
  {
    #region コンストラクタ
    public DataStore()
    {

    }
    #endregion


    #region プロパティ

    /// <summary>
    /// 画像パスディクショナリ
    /// </summary>
    public Dictionary<int, string> DicImgPath { get; set; }

    /// <summary>
    /// 対象拡張子
    /// </summary>
    public string[] TgtExt { get; set; }

    /// <summary>
    /// サムネイル幅
    /// </summary>
    public int ThumbW { get; set; }

    /// <summary>
    /// サムネイル高さ
    /// </summary>
    public int ThumbH { get; set; }

    /// <summary>
    /// 起動アプリパス
    /// </summary>
    public string LaunchAppPath { get; set; }

    /// <summary>
    /// 入力ファイル
    /// </summary>
    public string DropItem { get; set; }

    /// <summary>
    /// 画像リストソース
    /// </summary>
    public Image[] SrcImgList { get; set; }

    /// <summary>
    /// 画像ビューデータソース
    /// </summary>
    public ListViewItem[] SrcListViewItem { get; set; }

    #endregion
  }
}
