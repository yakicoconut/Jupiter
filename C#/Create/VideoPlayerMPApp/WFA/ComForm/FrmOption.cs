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
    public Form1 ParentForm { private get; set; }

    /// <summary>
    /// 再生位置移動秒デフォルト値
    /// </summary>
    public int DefGoPosSec { private get; set; }

    /// <summary>
    /// 取得再生位置確定範囲秒デフォルト値
    /// </summary>
    public int DefCmtPosRange { private get; set; }

    /// <summary>
    /// 再生位置取得後巻き戻し秒デフォルト値
    /// </summary>
    public int DefGetAftBackPos { private get; set; }

    #endregion


    #region フォームロードイベント
    private void Form2_Load(object sender, EventArgs e)
    {
      // タイトル設定
      this.Text = "Option";

      // タスクバーにアイコンを表示しない
      this.ShowInTaskbar = false;

      //// タブインデックス設定
      //int incTabIndex = 1;
      //btCngSize.TabIndex = incTabIndex++;

      // 再生位置移動秒デフォルト値設定
      nudGoPosSec.Value = DefGoPosSec;
      // 取得再生位置確定範囲秒デフォルト値設定
      nudCmtPosRange.Value = DefCmtPosRange;
      // 再生位置取得後巻き戻し秒デフォルト値設定
      nudGetAftBackPos.Value = DefGetAftBackPos;
    }
    #endregion


    #region ReadVideoボタン押下イベント
    private void btStart_Click(object sender, EventArgs e)
    {
      // 対象ファイルパス取得
      string tgtPath = ExclIniEndWQuot(tbTgtPath.Text);
      // ファイル読込メソッド呼出しメソッド使用
      CallReadVideo(tgtPath);
    }
    #endregion

    #region GetTimeボタン押下メソッド
    private void btGetTime_Click(object sender, EventArgs e)
    {
      // 位置確定範囲秒取得
      int posRange = (int)nudCmtPosRange.Value;
      // 再生位置巻き戻し秒取得
      int cmtBack = (int)nudGetAftBackPos.Value;
      // 改行チェック取得
      bool isNewLine = cbIsNewLine.Checked;

      // 現在再生位置取得メソッド使用
      string strPos = ParentForm.GetPlayPos(posRange, cmtBack, ref isNewLine);
      // 値がない場合は更新しない
      lbPlayPos.Text = string.Empty == strPos ? lbPlayPos.Text : strPos;
      // 改行フラグ反映
      cbIsNewLine.Checked = isNewLine;
    }
    #endregion

    #region Goボタン押下イベント
    private void btGo_Click(object sender, EventArgs e)
    {
      // 巻き戻し秒取得
      int goPosSec = (int)nudGoPosSec.Value;

      // Goメソッド使用
      ParentForm.Go(goPosSec);
    }
    #endregion

    #region Modeボタン押下イベント
    private void btMode_Click(object sender, EventArgs e)
    {
      // プレイヤーモード変更メソッド使用
      ParentForm.CngMode();
    }
    #endregion


    #region 再生速度NumUpDown値変更イベント
    private void nudPlaySpd_ValueChanged(object sender, EventArgs e)
    {
      // 再生速度変更メソッド使用
      ParentForm.CngPlaySpd((double)nudPlaySpd.Value);
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

      // 対象ファイルパス取得
      string tgtPath = ExclIniEndWQuot(tbTgtPath.Text);
      // ファイル読込メソッド呼出しメソッド使用
      CallReadVideo(tgtPath);
    }
    #endregion


    #region 先頭末尾Wクォート除去イベント
    private string ExclIniEndWQuot(string tgtStr)
    {
      // 返却用変数
      string refStr = tgtStr;
      // 末尾インデックス取得
      int lastInd = tgtStr.Length - 1;

      // 先頭と末尾が「"」の場合
      if (tgtStr[0] == '"' && tgtStr[lastInd] == '"')
      {
        // Wクォートを取る
        refStr = tgtStr.Substring(1, lastInd - 1);
      }

      return refStr;
    }
    #endregion

    #region 日時秒数変換メソッド
    private int CngDateTimeToSec(DateTime dt)
    {
      // 秒変換
      return dt.Hour * 360 + dt.Minute * 60 + dt.Second;
    }
    #endregion

    #region ファイル読込メソッド呼出しメソッド
    private void CallReadVideo(string tgtPath)
    {
      // ねずみ返し_ファイル存在確認
      if (!File.Exists(tgtPath))
      {
        MessageBox.Show(string.Format("対象ファイルパスが存在しません{0}{1}", Environment.NewLine, tgtPath));
        return;
      }

      // ReadVideoメソッド使用
      ParentForm.ReadVideo(tgtPath);
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
        ParentForm.Close();
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