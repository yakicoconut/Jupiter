using System;
using System.Windows.Forms;

namespace WFA
{
  /// <summary>
  /// プログレスバー用フォーム
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

      // 処理ラベル初期化
      lbPrg.Text = "0/";
    }
    #endregion


    #region 宣言

    // プログレスバー更新用デリゲート
    private delegate void UpdPrgBarCallback(int val);
    private UpdPrgBarCallback dlgUpdPrgBar;

    #endregion

    #region プロパティ

    /// <summary>
    /// プログレスバー最大値
    /// </summary>
    public int PrgBarMax { private get; set; }

    #endregion


    #region フォーム表示イベント
    private void FrmPrgBar_Shown(object sender, EventArgs e)
    {
      // プログレスバー最大値設定
      prgBar.Maximum = PrgBarMax;
      // プログレスバー値初期化
      prgBar.Value = 0;
    }
    #endregion


    #region プログレスバー更新メソッド
    private void UpdPrgBar(int val)
    {
      // 経過ラベル更新
      lbPrg.Text = string.Format("{0}/{1}", val, PrgBarMax);
      lbPrg.Update();

      // 更新
      prgBar.Value = val;

      // ねずみ返し_最大値以上の場合
      if (val >= prgBar.Maximum)
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
    public void UpdPrgBarOprt(int val)
    {
      // プログレスバー更新メソッド起動
      prgBar.Invoke(dlgUpdPrgBar, val);
    }
    #endregion
  }
}
