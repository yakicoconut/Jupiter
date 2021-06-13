using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WFA
{
  public partial class FrmPtCtrl : Form
  {
    #region コンストラクタ
    public FrmPtCtrl(Form1 fm1, DataStore _dataStore)
    {
      InitializeComponent();

      // 親フォーム設定
      form1 = fm1;

      // データ連携クラス引継ぎ
      dataStore = _dataStore;
    }
    #endregion


    #region 宣言

    // 親フォーム
    public Form1 form1 { get; set; }

    // データ連携クラス
    DataStore dataStore;

    #endregion


    #region フォームロードイベント
    private void Form2_Load(object sender, EventArgs e)
    {
      this.Text = "コントロール";
      // 親コントロールのサイズと位置からサイズ・出現位置設定
      int parentX = form1.Location.X;
      int parentY = form1.Location.Y;
      int parentH = form1.Height;
      int parentW = form1.Width;
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


    #region 置換ボタン押下イベント
    private void btReplace_Click(object sender, EventArgs e)
    {
      // 置換実行メソッド
      form1.ExecRep();
    }
    #endregion

    #region パターンボタン押下イベント
    private void btPattern_Click(object sender, EventArgs e)
    {
      // パターン管理フォーム起動メソッド実行
      form1.ShowPtMngFrm();
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