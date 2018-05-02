using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace WFA
{
  public partial class FrmOption : Form
  {
    #region コンストラクタ
    public FrmOption()
    {
      InitializeComponent();
    }
    #endregion


    #region 宣言

    // 親フォーム
    public Form1 form1 { get; set; }

    #endregion


    #region フォームロードイベント
    private void Form2_Load(object sender, EventArgs e)
    {
      // タイトル設定
      this.Text = "Option";

      // タスクバーにアイコンを表示しない
      this.ShowInTaskbar = false;
    }
    #endregion


    #region 拡大/縮小チェックボックスチェックチェンジイベント
    private void cbIsModeZoom_CheckedChanged(object sender, EventArgs e)
    {
      // チェック済の場合
      if (cbIsModeZoom.Checked)
      {
        // ページ送りチェックをはずす
        cbIsModePageEject.Checked = false;
      }
    }
    #endregion

    #region ページ送りチェックボックスチェックチェンジイベント
    private void cbIsModePageEject_CheckedChanged(object sender, EventArgs e)
    {
      // チェック済の場合
      if (cbIsModePageEject.Checked)
      {
        // 拡大/縮小チェックをはずす
        cbIsModeZoom.Checked = false;
      }
    }
    #endregion


    #region 上ボタン押下イベント
    private void btUp_Click(object sender, EventArgs e)
    {
      // 上操作メソッド
      form1.UpOperation();
    }
    #endregion

    #region 下ボタン押下イベント
    private void btDown_Click(object sender, EventArgs e)
    {
      // 下操作メソッド
      form1.DownOperation();
    }
    #endregion

    #region 右ボタン押下イベント
    private void btRight_Click(object sender, EventArgs e)
    {
      // 右操作メソッド
      form1.RightOperation();
    }
    #endregion

    #region 左ボタン押下イベント
    private void btLeft_Click(object sender, EventArgs e)
    {
      // 左操作メソッド
      form1.LeftOperation();
    }
    #endregion


    #region 設定コントロール値変更共通イベント
    private void Common_tb_ValueChanged(object sender, EventArgs e)
    {
      // イベント発生コントロール取得
      Control ctrl = (Control)sender;
      string ctrlName = ctrl.Name;

      // コントロール名称で分岐
      switch (ctrlName)
      {
        case "nudZoomInRatio":
          // コントロールの内容をプロパティに設定
          form1.zoomInRatio = double.Parse(ctrl.Text);
          break;
        case "nudZoomOutRatio":
          form1.zoomOutRatio = double.Parse(ctrl.Text);
          break;
        case "nudUpDist":
          form1.upMoveDistance = int.Parse(ctrl.Text);
          break;
        case "nudDownDist":
          form1.downMoveDistance = int.Parse(ctrl.Text);
          break;
        case "nudRightDist":
          form1.rightMoveDistance = int.Parse(ctrl.Text);
          break;
        case "nudLeftDist":
          form1.leftMoveDistance = int.Parse(ctrl.Text);
          break;

        default:
          break;
      }
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

    #region コンテキスト_ファイルリスト押下イベント
    private void ToolStripMenuItemFileList_Click(object sender, EventArgs e)
    {
      // ファイルリストフォーム初期化メソッド使用
      form1.InitFileListForm();
    }
    #endregion

    #region コンテキスト_開く
    private void toolStripMenuItemOpenDir_Click(object sender, EventArgs e)
    {
      // アセンブリフォルダ開く
      Process.Start(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
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