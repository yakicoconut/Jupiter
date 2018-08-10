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
  /// <summary>
  /// 操作フォーム
  /// </summary>
  public partial class FrmOption : Form
  {
    #region コンストラクタ
    /// <summary>
    /// コンストラクタ
    /// </summary>
    public FrmOption()
    {
      InitializeComponent();
    }
    #endregion


    #region 宣言

    #endregion

    #region プロパティ

    /// <summary>
    /// 親フォーム
    /// </summary>
    public Form1 parentForm { get; set; }

    #endregion


    #region フォームロードイベント
    private void Form2_Load(object sender, EventArgs e)
    {
      // タイトル設定
      this.Text = "Option";

      // タスクバーにアイコンを表示しない
      this.ShowInTaskbar = false;

      // タブインデックス設定
      int incTabIndex = 1;
      btUp.TabIndex = incTabIndex++;
      btDown.TabIndex = incTabIndex++;
      btLeft.TabIndex = incTabIndex++;
      btRight.TabIndex = incTabIndex++;
      tbFileName.TabIndex = incTabIndex++;
      nudZoomInRatio.TabIndex = incTabIndex++;
      nudZoomOutRatio.TabIndex = incTabIndex++;
      nudUpDist.TabIndex = incTabIndex++;
      nudDownDist.TabIndex = incTabIndex++;
      nudLeftDist.TabIndex = incTabIndex++;
      nudRightDist.TabIndex = incTabIndex++;
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


    #region 共通キー押下イベント
    private void FrmOption_ComKeyDown(object sender, KeyEventArgs e)
    {
      // デフォルトのボタン押下効果を無効化
      // これを記述しないと本イベントが二回発生してしまう
      if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.Control || e.Shift || e.Alt)
        e.Handled = true;

      // 親フォームのキー押下イベント使用
      parentForm.ComKeyDown(e);
    }
    #endregion


    #region 上ボタン押下イベント
    private void btUp_Click(object sender, EventArgs e)
    {
      // 上操作メソッド
      parentForm.UpOperation();
    }
    #endregion

    #region 下ボタン押下イベント
    private void btDown_Click(object sender, EventArgs e)
    {
      // 下操作メソッド
      parentForm.DownOperation();
    }
    #endregion

    #region 右ボタン押下イベント
    private void btRight_Click(object sender, EventArgs e)
    {
      // 右操作メソッド
      parentForm.RightOperation();
    }
    #endregion

    #region 左ボタン押下イベント
    private void btLeft_Click(object sender, EventArgs e)
    {
      // 左操作メソッド
      parentForm.LeftOperation();
    }
    #endregion

    #region Viewボタン押下イベント
    private void btView_Click(object sender, EventArgs e)
    {
      // ビュウアプリ起動メソッド
      parentForm.LaunchView();
    }
    #endregion


    #region 設定コントロール値変更共通イベント
    private void Common_tb_ValueChanged(object sender, EventArgs e)
    {
      // イベント発生コントロール取得
      Control ctrl = (Control)sender;
      string ctrlName = ctrl.Name;

      // ヌメリックアップダウンコントロール用変数
      NumericUpDown nudCtrl;

      // コントロール名称で分岐
      switch (ctrlName)
      {
        case "nudZoomInRatio":
          // 数値上下ボタンの場合、変更後の値はValueプロパティで取得する
          nudCtrl = (NumericUpDown)ctrl;
          // コントロールの内容をプロパティに設定
          parentForm.zoomInRatio = (double)nudCtrl.Value;
          break;
        case "nudZoomOutRatio":
          // 数値上下ボタンの場合、変更後の値はValueプロパティで取得する
          nudCtrl = (NumericUpDown)ctrl;
          parentForm.zoomOutRatio = (double)nudCtrl.Value;
          break;
        case "nudUpDist":
          parentForm.upMoveDistance = int.Parse(ctrl.Text);
          break;
        case "nudDownDist":
          parentForm.downMoveDistance = int.Parse(ctrl.Text);
          break;
        case "nudRightDist":
          parentForm.rightMoveDistance = int.Parse(ctrl.Text);
          break;
        case "nudLeftDist":
          parentForm.leftMoveDistance = int.Parse(ctrl.Text);
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

    #region コンテキスト_透明押下イベント
    private void toolStripMenuItemOpacityTransparent_Click(object sender, EventArgs e)
    {
      // 不透明度を0%にするとフォームが非表示扱いとなってしまうため
      this.Opacity = 0.01;
    }
    #endregion

    #region コンテキスト_ファイルリスト押下イベント
    private void ToolStripMenuItemFileList_Click(object sender, EventArgs e)
    {
      // ファイルリストフォーム初期化メソッド使用
      parentForm.InitFileListForm();
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

  #region ボタンイベントオーバーライドクラス
  /// <summary>
  /// ボタンイベントオーバーライドクラス
  /// </summary>
  public class ButtonEx : Button
  {
    /// <summary>
    /// キー入力イベント
    /// </summary>
    /// <param name="keyData"></param>
    /// <returns></returns>
    protected override bool IsInputKey(Keys keyData)
    {
      /*
       * ボタン上で矢印キーを押下された場合、元の処理(フォーカス移動)を無効化する
       * .Designer.csファイルのボタンコントロールの宣言を本クラス(ButtonEx)で行う
       */

      // 矢印キーが押されたときは、trueを返す
      Keys kcode = keyData & Keys.KeyCode;
      if (kcode == Keys.Up || kcode == Keys.Down || kcode == Keys.Left || kcode == Keys.Right)
      {
        return true;
      }

      return base.IsInputKey(keyData);
    }
  }
  #endregion
}