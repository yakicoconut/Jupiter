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

      // タブインデックス設定
      int incTabIndex = 1;
      //btCngSize.TabIndex = incTabIndex++;
    }
    #endregion


    #region Startボタン押下イベント
    private void btStart_Click(object sender, EventArgs e)
    {
      // Starメソッドメソッド使用
      parentForm.Start(tbTgtPath.Text);
    }
    #endregion

    #region GetTimeボタン押下メソッド
    private void btGetTime_Click(object sender, EventArgs e)
    {
      // 位置確定範囲秒取得
      int posRange = (int)nudPosRange.Value;
      // 再生位置巻き戻し秒取得
      int cmtBack = (int)nudCmtBack.Value;
      // 改行チェック取得
      bool isNewLine = cbIsNewLine.Checked;

      // 現在再生位置取得メソッド使用
      string strPos = parentForm.GetPlayPos(posRange, cmtBack, isNewLine);
      // 値がない場合は更新しない
      lbPlayPos.Text = string.Empty == strPos ? lbPlayPos.Text : strPos;
    }
    #endregion

    #region Goボタン押下イベント
    private void btGo_Click(object sender, EventArgs e)
    {
      // 巻き戻し秒取得
      int goPosSec = (int)nudGoPos.Value;

      // Goメソッド使用
      parentForm.Go(goPosSec);
    } 
    #endregion

    #region Modeボタン押下イベント
    private void btMode_Click(object sender, EventArgs e)
    {
      // プレイヤーモード変更メソッド使用
      parentForm.CngMode();
    }
    #endregion


    #region 再生速度NumUpDown値変更イベント
    private void nudPlaySpd_ValueChanged(object sender, EventArgs e)
    {
      // 再生速度変更メソッド使用
      parentForm.CngPlaySpd((double)nudPlaySpd.Value);
    } 
    #endregion


    #region 日時秒数変換メソッド
    private int CngDateTimeToSec(DateTime dt)
    {
      // 秒変換
      return dt.Hour * 360 + dt.Minute * 60 + dt.Second;
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