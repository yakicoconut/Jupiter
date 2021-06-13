using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace WFA
{
  /// <summary>
  /// コントロールフォーム
  /// </summary>
  public partial class FrmPtCtrl : Form
  {
    #region コンストラクタ
    public FrmPtCtrl(Form1 _fm1, DataStore _repData)
    {
      InitializeComponent();

      // 親フォーム設定
      fm1 = _fm1;

      // データ連携クラス引継ぎ
      dataStore = _repData;
    }
    #endregion


    #region 宣言

    // 親フォーム
    public Form1 fm1 { get; set; }

    // データ連携クラス
    DataStore dataStore;

    #endregion


    #region フォームロードイベント
    private void Form2_Load(object sender, EventArgs e)
    {
      this.Text = "コントロール";
      // 親コントロールのサイズと位置からサイズ・出現位置設定
      int parentX = fm1.Location.X;
      int parentY = fm1.Location.Y;
      int parentH = fm1.Height;
      int parentW = fm1.Width;
      // // 横幅は85(二行分)固定
      //this.Size = new Size(parentW, 85);
      this.Location = new Point(parentX * 2, parentY * 3);

      // タスクバーにアイコンを表示しない
      this.ShowInTaskbar = false;

      // コントロール値初期化メソッド使用
      this.InitCtrlValue();
    }
    #endregion

    #region コントロール値初期化メソッド
    public void InitCtrlValue()
    {
      // チェックボックス
      cbIgnoreCase.Checked = dataStore.IsIgnoreCase;
      cbNewLine.Checked = dataStore.IsNewLine;
      cbTab.Checked = dataStore.IsTab;

      // 文字コードコンボボックス設定
      cbChcp.DataSource = new string[] { "UTF8", "UTF7", "BigEndianUnicode", "Unicode", "Default", "ASCII", "UTF32" };
    }
    #endregion


    #region 大小文字判別チェックボックス値変更イベント
    private void cbIgnoreCase_CheckedChanged(object sender, EventArgs e)
    {
      // 親フォームプロパティ更新
      dataStore.IsIgnoreCase = cbIgnoreCase.Checked;
    }
    #endregion

    #region 改行モード判断チェックボックス値変更イベント
    private void cbNewLine_CheckedChanged(object sender, EventArgs e)
    {
      // 親フォームプロパティ更新
      dataStore.IsNewLine = cbNewLine.Checked;
    }
    #endregion

    #region タブモード判断チェックボックス値変更イベント
    private void cbTab_CheckedChanged(object sender, EventArgs e)
    {
      // 親フォームプロパティ更新
      dataStore.IsTab = cbTab.Checked;
    }
    #endregion


    #region 置換ボタン押下イベント
    private void btReplace_Click(object sender, EventArgs e)
    {
      // 対象フォルダパス取得
      string tgtDirPath = tbTgtDirPath.Text;

      // 値がない場合、
      if(string.IsNullOrEmpty(tgtDirPath))
      {
        // メインフォーム置換実行メソッド使用
        fm1.ExecRep();
        return;
      }

      // 対象フォルダが存在場合
      if (Directory.Exists(tgtDirPath))
      {
        // 
        fm1.ExecRep(tgtDirPath, tbFileFltr.Text, cbChcp.Text);
      }
    }
    #endregion

    #region パターンボタン押下イベント
    private void btPattern_Click(object sender, EventArgs e)
    {
      // パターン管理フォーム起動メソッド実行
      fm1.ShowPtMngFrm();
    }
    #endregion


    #region コンテキスト_不透明度押下イベント
    private void toolStripMenuItemOpacity_Click(object sender, EventArgs e)
    {
      //デフォルトに戻す
      this.Opacity = 0.8;
    }
    #endregion

    #region コンテキスト_上げ押下イベント
    private void toolStripMenuItemOpacityGain_Click(object sender, EventArgs e)
    {
      //不透明度を上げる
      this.Opacity += 0.2;
    }
    #endregion

    #region コンテキスト_下げ押下イベント
    private void toolStripMenuItemOpacityDec_Click(object sender, EventArgs e)
    {
      //不透明度を下げる
      this.Opacity -= 0.2;
    }
    #endregion


    #region フォームクロージングイベント
    private void Form2_FormClosing(object sender, FormClosingEventArgs e)
    {
      // クローズキャンセル
      if (e.CloseReason == CloseReason.UserClosing)
        e.Cancel = true;
    }
    #endregion
  }
}