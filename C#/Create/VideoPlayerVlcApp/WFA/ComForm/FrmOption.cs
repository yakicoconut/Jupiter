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

    // ウィンドウをマウスで操作したかどうかフラグ
    bool windowMouseMoveFlg;

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

      // 親フォーム位置を設定
      nudCngLocationX.Value = parentForm.Location.X;
      nudCngLocationY.Value = parentForm.Location.Y;
      // 親フォームサイズを設定
      //nudCngSizeH.Value = parentForm.Height;
      //nudCngSizeW.Value = parentForm.Width;
      nudCngSizeH.Value = 576;
      nudCngSizeW.Value = 1024;

      // Vlc音量設定
      //nudVolume.Value = parentForm.VlcVol;
      nudVolume.Value = 60;

      // タブインデックス設定
      int incTabIndex = 1;
      //btCngSize.TabIndex = incTabIndex++;
    }
    #endregion


    #region 拡大/縮小チェックボックスチェックチェンジイベント
    private void cbIsModeZoom_CheckedChanged(object sender, EventArgs e)
    {
      //// チェック済の場合
      //if (cbIsModeZoom.Checked)
      //{
      //  // ページ送りチェックをはずす
      //  cbIsModePageEject.Checked = false;
      //}
    }
    #endregion

    #region ページ送りチェックボックスチェックチェンジイベント
    private void cbIsModePageEject_CheckedChanged(object sender, EventArgs e)
    {
      //// チェック済の場合
      //if (cbIsModePageEject.Checked)
      //{
      //  // 拡大/縮小チェックをはずす
      //  cbIsModeZoom.Checked = false;
      //}
    }
    #endregion


    #region 共通キー押下イベント
    private void FrmOption_ComKeyDown(object sender, KeyEventArgs e)
    {
      // デフォルトのボタン押下効果を無効化
      // これを記述しないと本イベントが二回発生してしまう
      if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.Control || e.Shift || e.Alt)
        e.Handled = true;

      //// 親フォームのキー押下イベント使用
      //parentForm.ComKeyDown(e);
    }
    #endregion


    #region フォームサイズ変更ボタン押下イベント
    private void btCngSize_Click(object sender, EventArgs e)
    {
      // 親フォームサイズ変更
      parentForm.CngVlcWindSize(int.Parse(nudCngSizeW.Text), int.Parse(nudCngSizeH.Text));
    }
    #endregion

    #region 下ボタン押下イベント
    private void btDown_Click(object sender, EventArgs e)
    {
      //// 下操作メソッド
      //parentForm.DownOperation();
    }
    #endregion

    #region 右ボタン押下イベント
    private void btRight_Click(object sender, EventArgs e)
    {
      //// 右操作メソッド
      //parentForm.RightOperation();
    }
    #endregion

    #region 左ボタン押下イベント
    private void btLeft_Click(object sender, EventArgs e)
    {
      //// 左操作メソッド
      //parentForm.LeftOperation();
    }
    #endregion

    #region Viewボタン押下イベント
    private void btView_Click(object sender, EventArgs e)
    {
      //// ビュウアプリ起動メソッド
      //parentForm.LaunchView();
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

      //// コントロール名称で分岐
      //switch (ctrlName)
      //{
      //  case "nudZoomInRatio":
      //    // 数値上下ボタンの場合、変更後の値はValueプロパティで取得する
      //    nudCtrl = (NumericUpDown)ctrl;
      //    // コントロールの内容をプロパティに設定
      //    parentForm.ZoomInRatio = (double)nudCtrl.Value;
      //    break;
      //  case "nudZoomOutRatio":
      //    // 数値上下ボタンの場合、変更後の値はValueプロパティで取得する
      //    nudCtrl = (NumericUpDown)ctrl;
      //    parentForm.ZoomOutRatio = (double)nudCtrl.Value;
      //    break;
      //  case "nudUpDist":
      //    parentForm.UpMoveDistance = int.Parse(ctrl.Text);
      //    break;
      //  case "nudDownDist":
      //    parentForm.DownMoveDistance = int.Parse(ctrl.Text);
      //    break;
      //  case "nudRightDist":
      //    parentForm.RightMoveDistance = int.Parse(ctrl.Text);
      //    break;
      //  case "nudLeftDist":
      //    parentForm.LeftMoveDistance = int.Parse(ctrl.Text);
      //    break;

      //  default:
      //    break;
      //}
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
      //// ファイルリストフォーム初期化メソッド使用
      //parentForm.InitFileListForm();
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
      // ユーザクロージングの場合
      if (e.CloseReason == CloseReason.UserClosing)
      {
        // 親フォームクローズ
        parentForm.Close();
      }
    }
    #endregion

    #region 指定時間適用ボタン押下イベント
    private void btGoTime_Click(object sender, EventArgs e)
    {
      // 指定時刻をミリ秒に変換
      /*
       *    1秒 = 1000ミリ秒
       *   60秒 = (1秒×60) = (1000ミリ秒×60) = 60000ミリ秒 = 60秒
       *  1時間 = (1分×60) = (60秒×60) = (60000ミリ秒×60) = 3600000ミリ秒 = 3600秒
       * 24時間 = (60分×24) = (3600秒×24) = (3600000ミリ秒×24) = 86400000ミリ秒 = 86400秒
       * 0.999ミリ秒 = 
       */
      int hour = dtpTime.Value.Hour;
      int minute = dtpTime.Value.Minute;
      int second = dtpTime.Value.Second;
      int mSecond = (int)(nudMilliSec.Value * 1000);
      // 変換
      long mSec = (hour * 3600000) + (minute * 60000) + (second * 1000) + mSecond;

      // 遅延再生設定値取得
      int delayedTime = (int)nudDelayedPlay.Value;

      // VlcTimeメソッド使用
      parentForm.VlcTime(mSec, delayedTime);
    } 
    #endregion

    #region ポーズスタートボタン押下イベント
    private void btPauseStart_Click(object sender, EventArgs e)
    {
      // Vlc停止/再生メソッド使用
      parentForm.VlcPauseStart();
    }
    #endregion

    #region ファイルパステキストキーアップイベント
    private void tbTgtPath_KeyUp(object sender, KeyEventArgs e)
    {
      // ねずみ返し_エンターキー押下でない場合
      if (e.KeyData != Keys.Enter)
      {
        return;
      }

      // Vlcメディア初期化メソッド使用
      parentForm.VlcMediaInit(tbTgtPath.Text);
    }
    #endregion

    #region VlcウィンドウX位置値変更イベント
    private void nudCngLocationX_ValueChanged(object sender, EventArgs e)
    {
      // ねずみ返し_ウィンドウをマウスで操作した結果、イベントが発生した場合
      if (windowMouseMoveFlg)
        return;

      // X座標変更
      parentForm.CngVlcWindLocation((int)nudCngLocationX.Value, (int)nudCngLocationY.Value);
    }
    #endregion

    #region VlcウィンドウY位置値変更イベント
    private void nudCngLocationY_ValueChanged(object sender, EventArgs e)
    {
      // Y座標変更
      parentForm.CngVlcWindLocation((int)nudCngLocationX.Value, (int)nudCngLocationY.Value);
    }
    #endregion

    #region Vlcウィンドウ横幅値変更イベント
    private void nudCngSizeW_ValueChanged(object sender, EventArgs e)
    {
      // 横幅変更
      parentForm.CngVlcWindSize((int)nudCngSizeW.Value, (int)nudCngSizeH.Value);
    }
    #endregion

    #region Vlcウィンドウ高さ値変更イベント
    private void nudCngSizeH_ValueChanged(object sender, EventArgs e)
    {
      // 高さ変更
      parentForm.CngVlcWindSize((int)nudCngSizeW.Value, (int)nudCngSizeH.Value);
    }
    #endregion

    #region 音量調整変更イベント
    private void nudVolume_ValueChanged(object sender, EventArgs e)
    {
      // Vlc音量調整メソッド使用
      parentForm.VlcVolume((int)nudVolume.Value);
    }
    #endregion


    #region コントロール外部操作メソッド

    #region 再生時間テキストボックス更新

    private void UpdTbDuration(string str)
    {
      // コントロール更新
      tbDuration.Text = str;
    }

    // コントロール更新メソッド用デリゲート宣言
    delegate void UpdDurationTextBoxCallback(string str);

    public void UpdDurationTextBoxOperation(string str)
    {
      // コントロール更新メソッドのデリゲートインスタンス生成
      UpdDurationTextBoxCallback dlgUpdDurationTextBox = new UpdDurationTextBoxCallback(UpdTbDuration);

      // コントロール更新メソッド起動
      tbDuration.Invoke(dlgUpdDurationTextBox, str);
    }

    #endregion

    #region 位置・サイズ設定コントロール更新

    private void UpdNudCngLocaSize(int x, int y, int width, int height)
    {
      nudCngLocationX.Value = x;
      nudCngLocationY.Value = y;
      nudCngSizeW.Value = width;
      nudCngSizeH.Value = height;
    }
    delegate void UpdNudCngLocaSizeCallback(int x, int y, int width, int height);
    public void UpdNudCngLocaSizeOperation(int x, int y, int width, int height)
    {
      // ウィンドウをマウスで操作したかどうかフラグを立てる
      windowMouseMoveFlg = true;

      // コントロール更新メソッド起動
      UpdNudCngLocaSizeCallback dlgUpdNudCngLocaSize = new UpdNudCngLocaSizeCallback(UpdNudCngLocaSize);
      tbDuration.Invoke(dlgUpdNudCngLocaSize, x, y, width, height);

      windowMouseMoveFlg = false;
    }

    #endregion

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