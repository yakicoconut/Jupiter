using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA
{
  /// <summary>
  /// プログレスバー用フォームクラス
  /// </summary>
  public partial class FrmPrgBar : Form
  {
    #region デフォルトコンストラクタ
    /// <summary>
    /// デフォルトコンストラクタ
    /// </summary>
    public FrmPrgBar()
    {
      InitializeComponent();

      // 初期設定メソッド使用
      InitSet();
    }
    #endregion

    #region 初期設定メソッド
    private void InitSet()
    {
      // プログレスバー更新コールバックデリゲートインスタンス生成
      dlgUpdPrgBar = new UpdPrgBarCallback(UpdPrgBar);
    }
    #endregion


    #region 宣言

    // プログレスバー更新用デリゲート
    delegate void UpdPrgBarCallback(int val, int max);
    UpdPrgBarCallback dlgUpdPrgBar;

    #endregion
    

    #region フォームロードイベント
    private void FrmPrgBar_Load(object sender, EventArgs e)
    {
      // プログレスバー値初期化
      progressBar1.Value = 0;
    }
    #endregion

    #region プログレスバー更新メソッド
    private void UpdPrgBar(int val, int max)
    {
      // 最大値
      progressBar1.Maximum = max;

      // 更新
      progressBar1.Value = val;

      // ねずみ返し_最大値以上の場合
      if (val >= max)
      {
        // フォームクローズ
        Close();
      }
    }
    #endregion


    #region プログレスバー更新操作メソッド
    /// <summary>
    /// プログレスバー更新メソッド
    /// </summary>
    /// <param name="val">プログレスバー更新値</param>
    public void UpdPrgBarOprt(int val, int max)
    {
      // プログレスバー更新メソッド起動
      progressBar1.Invoke(dlgUpdPrgBar, val, max);
    }
    #endregion
  }
}
