using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Text;

namespace WFA
{
  /// <summary>
  /// コントロールフォーム
  /// </summary>
  public partial class FrmCtrl : Form
  {
    #region コンストラクタ
    public FrmCtrl(FrmMain _frmMain, DataStore _dataStore)
    {
      InitializeComponent();

      // 親フォーム設定
      frmMain = _frmMain;

      // データ連携クラス引継ぎ
      dataStore = _dataStore;
    }
    #endregion


    #region 宣言

    // 親フォーム
    private FrmMain frmMain;

    // データ連携クラス
    DataStore dataStore;

    #endregion


    #region フォームロードイベント
    private void FrmCtrl_Load(object sender, EventArgs e)
    {
      this.Text = "コントロール";
      // 親コントロールのサイズと位置からサイズ・出現位置設定
      int parentX = frmMain.Location.X;
      int parentY = frmMain.Location.Y;
      int parentH = frmMain.Height;
      int parentW = frmMain.Width;
      // // 横幅は85(二行分)固定
      //this.Size = new Size(parentW, 85);
      this.Location = new Point(parentX * 2, parentY * 3);

      // タスクバーにアイコンを表示しない
      this.ShowInTaskbar = false;

      // 文字コードコンボボックス設定
      cbChcp.DataSource = new string[] { "UTF8", "SJIS", "UTF7", "BigEndianUnicode", "Unicode", "Default", "ASCII", "UTF32" };
      // コントロール値初期化メソッド使用
      this.InitCtrlValue();
    }
    #endregion

    #region コントロール値初期化メソッド
    /// <summary>
    /// コントロール値初期化メソッド
    /// </summary>
    public void InitCtrlValue()
    {
      // チェックボックス
      cbIsCaseSens.Checked = dataStore.IsCaseSens;
      cbIsNewLine.Checked = dataStore.IsNewLine;
      cbIsTab.Checked = dataStore.IsTab;
      cbIsMultRep.Checked = dataStore.IsMultRep;
      // 一括置換
      tbTgtDirPath.Text = dataStore.TgtDirPath;
      tbFileFilter.Text = dataStore.FileFilter;
      cbChcp.Text = dataStore.Enc.ToString();
    }
    #endregion


    #region 共通_チェックボックス値変更イベント
    private void Com_ChekBox_CheckedChanged(object sender, EventArgs e)
    {
      switch (sender)
      {
        // 型がチェックボックスかつ対象コントロールと一致する場合
        case CheckBox ctrl when sender.Equals(cbIsCaseSens):
          // 親フォームプロパティ更新
          dataStore.IsCaseSens = cbIsCaseSens.Checked;
          break;

        case CheckBox ctrl when sender.Equals(cbIsNewLine):
          dataStore.IsNewLine = cbIsNewLine.Checked;
          break;

        case CheckBox ctrl when sender.Equals(cbIsTab):
          dataStore.IsTab = cbIsTab.Checked;
          break;

        case CheckBox ctrl when sender.Equals(cbIsMultRep):

          bool chk = cbIsMultRep.Checked;
          dataStore.IsMultRep = chk;

          // 一括置換用コントロール有無効
          tbTgtDirPath.Enabled = chk;
          tbFileFilter.Enabled = chk;
          cbChcp.Enabled = chk;
          tbDestDirPath.Enabled = chk;
          break;

        default:
          break;
      }
    }
    #endregion

    #region 文字コードコンボボックス選択変更イベント
    private void cbChcp_SelectedIndexChanged(object sender, EventArgs e)
    {
      // 文字列文字コード変換メソッド使用
      dataStore.Enc = frmMain.Str2Enc(cbChcp.Text);
    }
    #endregion


    #region 置換ボタン押下イベント
    private void btReplace_Click(object sender, EventArgs e)
    {
      // 一括置換がチェックされていない場合
      if (!dataStore.IsMultRep)
      {
        // メインフォーム置換実行メソッド使用
        frmMain.ExecRep();
        return;
      }

      // 対象フォルダパス取得
      string tgtDirPath = tbTgtDirPath.Text;

      // フォルダ指定されていない場合
      if (string.IsNullOrEmpty(tgtDirPath))
      {
        MessageBox.Show("一括置換フォルダが指定されていません");
        return;
      }
      // 対象フォルダが存在しない場合
      if (!Directory.Exists(tgtDirPath))
      {
        MessageBox.Show("対象フォルダが存在しません");
        return;
      }

      /* データ連携クラス設定 */
      // 対象フォルダパス
      dataStore.TgtDirPath = tgtDirPath;
      // ファイルフィルタ文字列(空の場合、「*.*」)
      dataStore.FileFilter = string.IsNullOrEmpty(tbFileFilter.Text) ? "*.*" : tbFileFilter.Text;
      // 出力フォルダパス(空の場合、カレントディレクトリ指定)
      dataStore.DestDirPath = string.IsNullOrEmpty(tbDestDirPath.Text) ? Directory.GetCurrentDirectory() : tbDestDirPath.Text;

      // 複数用置換実行メソッド使用
      frmMain.ExecDirRep();
    }
    #endregion

    #region パターンボタン押下イベント
    private void btPattern_Click(object sender, EventArgs e)
    {
      // 現状の一括置換値設定
      dataStore.TgtDirPath = tbTgtDirPath.Text;
      dataStore.FileFilter = tbFileFilter.Text;

      // パターン管理フォーム起動メソッド実行
      frmMain.ShowPtMngFrm();
    }
    #endregion

    #region 開くボタン押下イベント
    private void btOpen_Click(object sender, EventArgs e)
    {
      // Exe位置を開くメソッド使用
      OpenExePath();
    }
    #endregion


    #region コンテキスト_透明度押下イベント
    private void toolStripMenuItemTra_Click(object sender, EventArgs e)
    {
      // デフォルトに戻す
      this.Opacity = 0.8;
    }
    #endregion

    #region コンテキスト_透明度_上げる押下イベント
    private void toolStripMenuItemTraGain_Click(object sender, EventArgs e)
    {
      // より透明にする
      this.Opacity -= 0.2;
    }
    #endregion

    #region コンテキスト_透明度_下げる押下イベント
    private void toolStripMenuItemTraDec_Click(object sender, EventArgs e)
    {
      // より不透明にする
      this.Opacity += 0.2;
    }
    #endregion


    #region Exe位置を開くメソッド
    private void OpenExePath()
    {
      // 自身のフォルダを開く
      string myLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
      Process.Start(myLocation);
    }
    #endregion


    #region フォームクロージングイベント
    private void FrmCtrl_FormClosing(object sender, FormClosingEventArgs e)
    {
      // クローズキャンセル
      if (e.CloseReason == CloseReason.UserClosing)
        e.Cancel = true;
    }
    #endregion
  }
}