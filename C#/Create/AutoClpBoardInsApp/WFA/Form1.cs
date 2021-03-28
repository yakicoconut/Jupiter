using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Threading;
using System.Text.RegularExpressions;

/*
 * C#|クリップボードの変更を監視する | 貧脚レーサーのサボり日記
 * 	https://anis774.net/codevault/clipboardwatcher.html
 * ぶびびんぶろぐ: WndProc（ウインドウプロシージャ）
 * 	http://bubibinba.blogspot.com/2012/06/wndproc.html
 * 【WindowsAPIメモ】メッセージ一覧 | フィロの村note
 *  http://note.phyllo.net/?eid=1106271
 * 動作原理とクリップボードチェイン - コピペテキスト修飾除去のヘルプ
 * 	https://www.inasoft.org/webhelp/delattr/HLP000010.html
 * API 関数解説
 * 	http://tokovalue.jp/function/SetClipboardViewer.htm
 *   
 */
namespace WFA
{
  /// <summary>
  /// メインフォーム
  /// </summary>
  public partial class Form1 : Form
  {
    #region コンストラクタ
    public Form1()
    {
      InitializeComponent();

      #region 【論理雛形】
      WFAComLogic WFACL = new WFAComLogic();
      // アプリ名設定
      Text = WFACL.GetAppName();
      #endregion

      // コンフィグ取得メソッド使用
      GetConfig();
    }
    #endregion

    #region コンフィグ取得メソッド
    public void GetConfig()
    {
      string hoge01 = _comLogic.GetConfigValue("Key01", "DefaultValue");
    }
    #endregion


    #region 宣言

    // 共通ロジッククラスインスタンス
    MCSComLogic _comLogic = new MCSComLogic();

    // クリップボードウォッチャ
    ClipBoardWatcher cbw;
    // 監視対象フラグ
    bool isMntrFlg;

    // 前回取得値
    string lastStr;

    #endregion


    #region フォームロードイベント
    private void Form1_Load(object sender, EventArgs e)
    {
      // 監視対象フラグ初期化
      isMntrFlg = true;
      // クリップボード監視クラスインスタンス
      cbw = new ClipBoardWatcher();

      // 監視処理
      cbw.DrawClipBoard += (sender2, e2) =>
      {
        // ねずみ返し_クリップボードに文字列がない場合
        if (!Clipboard.ContainsText())
        {
          return;
        }
        // ねずみ返し_監視対象外の場合
        if (!isMntrFlg)
        {
          return;
        }

        //// 対象テキストボックスへ書き込み
        //tbReadOnly.Text = Clipboard.GetText();
        //// 対象テキストボックス初期化
        //tbReadOnly.Text = string.Empty;
      };
    }
    #endregion

    #region OnOffボタン押下イベント
    private void btOnOff_Click(object sender, EventArgs e)
    {
      // 監視対象フラグ更新
      isMntrFlg = !isMntrFlg;

      // フラグが監視対象外の場合「OFF」
      lbOnOff.Text = isMntrFlg ? "ON" : "OFF";
    }
    #endregion

    #region テキストボックス値変更イベント
    private void tbReadOnly_TextChanged(object sender, EventArgs e)
    {
      //// コピー文字列
      //string tgtStr = tbReadOnly.Text;
      //// 挿入位置文字列
      //string insPosStr = tbInsPos.Text;
      //// 挿入文字列
      //string insStr = tbInsStr.Text;
      //// モードチェックボックス
      //bool isRepMode = cbIsRepMode.Checked;
      //bool isStrFｍtMode = cbIsStrFｍtMode.Checked;

      //string cngTxt = string.Empty;

      //// クリップボードに値を送る前にフラグを監視対象外に設定
      //isMntrFlg = false;

      //// ねずみ返し_対象文字列が空の場合
      //if (tgtStr == string.Empty)
      //{
      //  // 監視対象に戻す
      //  isMntrFlg = true;
      //  return;
      //}

      //// ねずみ返し_前回取得値と同じ場合
      //if (lastStr == tgtStr)
      //{
      //  // エクセル対策、セル値をコピーすると
      //  // 二回以上、クリップボードにアクセスするため
      //  isMntrFlg = true;
      //  return;
      //}

      //// 前回取得値に今回の値を設定
      //lastStr = tgtStr;

      //// 置き換えモード
      //if (isRepMode)
      //{
      //  // 文字列置き換えメソッド使用
      //  cngTxt = ReplaceTxt(tgtStr, insPosStr, insStr);
      //}
      //else if (isStrFｍtMode) // 書式指定挿入モード
      //{
      //  // 文字列書式指定挿入メソッド使用
      //  cngTxt = InsFmtTxt(tgtStr, insStr);
      //}
      //else
      //{
      //  // 文字数指定挿入メソッド使用
      //  cngTxt = InsPoTxt(tgtStr, insPosStr, insStr);
      //}

      //// ねずみ返し_挿入結果が空の場合
      //if (cngTxt == string.Empty)
      //{
      //  isMntrFlg = true;
      //  return;
      //}

      //// クリップボードへ送る
      //Clipboard.SetText(cngTxt);
      //// 採取モードの場合
      //if (cbColl.Checked)
      //{
      //  // 採取テキストボックスに追加
      //  tbColl.AppendText(cngTxt);
      //}
      //isMntrFlg = true;
    }
    #endregion


    #region 書式指定モードチェックイベント
    private void cbIsStrFｍtMode_CheckedChanged(object sender, EventArgs e)
    {
      //bool isRepMode = cbIsRepMode.Checked;
      //bool isStrFｍtMode = cbIsStrFｍtMode.Checked;

      //// 両モードがオンになった場合
      //if (isRepMode & isStrFｍtMode)
      //{
      //  // 別モードは排他
      //  cbIsRepMode.Checked = false;
      //}

      //// 置き換えモードの場合ラベル更新
      //lbInsPos.Text = isStrFｍtMode ? "不使用;" : "挿入位置:";
      //tbInsPos.Enabled = isStrFｍtMode ? false : true;
      //lbInsStr.Text = isStrFｍtMode ? "書式  ;" : "挿入文字:";
    }
    #endregion

    #region 置き換えモードチェック押下イベント
    private void cbIsRepMode_CheckedChanged(object sender, EventArgs e)
    {
      //bool isRepMode = cbIsRepMode.Checked;
      //bool isStrFｍtMode = cbIsStrFｍtMode.Checked;

      //// 両モードがオンになった場合
      //if (isRepMode & isStrFｍtMode)
      //{
      //  // 別モードは排他
      //  cbIsStrFｍtMode.Checked = false;
      //}

      //// 置き換えモードの場合ラベル更新
      //lbInsPos.Text = isRepMode ? "置換前;" : "挿入位置:";
      //lbInsStr.Text = isRepMode ? "置換後;" : "挿入文字:";
    }
    #endregion


    #region 採取テキストボックスキーダウンイベント
    private void tbColl_KeyDown(object sender, KeyEventArgs e)
    {
      // Ctrl+A
      if (e.Control && e.KeyCode == Keys.A)
        tbColl.SelectAll();
    }
    #endregion

    #region 採取チェックボックスチェックイベント
    private void cbColl_CheckedChanged(object sender, EventArgs e)
    {
      //// チェックした場合
      //if (cbColl.Checked)
      //{
      //  // 採取テキストボックスクリア
      //  tbColl.ResetText();
      //}
    }
    #endregion


    #region 文字列置き換えメソッド
    private string ReplaceTxt(string tgtStr, string regStr, string newStr)
    {
      string retStr = string.Empty;

      // 正規表現置き換え
      retStr = Regex.Replace(tgtStr, regStr, newStr, RegexOptions.Multiline);

      return retStr;
    }
    #endregion

    #region 文字列書式指定挿入メソッド
    private string InsFmtTxt(string tgtStr, string insStr)
    {
      string retStr = string.Empty;

      // 文字列指定で挿入
      retStr = string.Format(insStr, tgtStr);
      return retStr;
    }
    #endregion

    #region 文字数指定挿入メソッド
    private string InsPoTxt(string tgtStr, string insPosStr, string insStr)
    {
      // 返却用変数
      string retStr = string.Empty;
      // 対象文字列文字数
      int tgtStrLen = tgtStr.Length;

      // ねずみ返し_数値でない場合
      int insPosNum;
      if (!int.TryParse(insPosStr, out insPosNum))
      {
        return "";
      }
      // ねずみ返し_絶対値が文字数を超す場合
      if (Math.Abs(insPosNum) > tgtStrLen)
      {
        return "";
      }

      // マイナス値の場合
      if (insPosNum < 0)
      {
        // 末尾から指定
        insPosNum += tgtStrLen;
      }

      // マイナスかつ0の場合
      if (insPosStr.Substring(0, 1) == "-" && insPosNum == 0)
      {
        // 末尾指定
        insPosNum = tgtStrLen;
      }

      // 文字数指定で挿入
      retStr = tgtStr.Insert(insPosNum, insStr);
      return retStr;
    }
    #endregion


    #region 雛形メソッド
    private void template()
    {

    }
    #endregion


    #region フォームクロージングイベント
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      // クリップボードクラスインスタンス終了
      cbw.Dispose();
    }
    #endregion
  }


  #region クリップボード監視クラス
  /// <summary>
  /// クリップボード監視クラス
  /// 使用後は必ずDispose()メソッドを呼び出して下さい。
  /// </summary>
  public class ClipBoardWatcher : IDisposable
  {
    #region 宣言

    /// <summary>
    /// 監視処理対象フォームクラス
    /// </summary>
    ClipBoardWatcherForm form;

    /// <summary>
    /// クリップボード変更感知イベント
    /// </summary>
    public event EventHandler DrawClipBoard;

    #endregion


    #region コンストラクタ
    /// <summary>
    /// 対象スレッドをクリップボードビューアチェインに登録する
    /// </summary>
    public ClipBoardWatcher()
    {
      // 監視処理対象フォームクラスインスタンス生成
      form = new ClipBoardWatcherForm();

      // 監視開始メソッド使用
      form.StartWatch(raiseDrawClipBoard);
    }
    #endregion


    #region イベント初期化登録?メソッド
    private void raiseDrawClipBoard()
    {
      if (DrawClipBoard != null)
      {
        // クリップボード変更感知イベントイベント登録
        DrawClipBoard(this, EventArgs.Empty);
      }
    }
    #endregion


    #region Disposeメソッド
    /// <summary>
    /// 対象スレッドをクリップボードビューアチェインから削除する
    /// </summary>
    public void Dispose()
    {
      form.Dispose();
    }
    #endregion


    #region 監視処理対象フォームクラス
    private class ClipBoardWatcherForm : Form
    {
      #region 宣言

      /// <summary>
      /// クリップボードチェイン追加ウィンドウハンドル指定
      /// </summary>
      /// <param name="hwnd"></param>
      /// <returns></returns>
      [DllImport("user32.dll")]
      private static extern IntPtr SetClipboardViewer(IntPtr hwnd);

      /// <summary>
      /// メッセージ送信
      /// </summary>
      /// <param name="hwnd"></param>
      /// <param name="wMsg"></param>
      /// <param name="wParam"></param>
      /// <param name="lParam"></param>
      /// <returns></returns>
      [DllImport("user32.dll")]
      private static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

      /// <summary>
      /// 指定ウィンドウハンドルクリップボードチェイン削除
      /// </summary>
      /// <param name="hwnd"></param>
      /// <param name="hWndNext"></param>
      /// <returns></returns>
      [DllImport("user32.dll")]
      private static extern bool ChangeClipboardChain(IntPtr hwnd, IntPtr hWndNext);

      const int WM_DRAWCLIPBOARD = 0x0308;
      const int WM_CHANGECBCHAIN = 0x030D;

      IntPtr nextHandle;

      // スレッド実行デリゲート
      ThreadStart proc;

      #endregion


      #region 監視開始メソッド
      /// <summary>
      /// 監視開始メソッド
      /// </summary>
      /// <param name="raiseDrawClipBoard">スレッド実行デリゲート</param>
      public void StartWatch(ThreadStart raiseDrawClipBoard)
      {
        // スレッド実行デリゲート設定
        this.proc = raiseDrawClipBoard;
        // コントロールのバインド先ウィンドウ ハンドル
        nextHandle = SetClipboardViewer(this.Handle);
      }
      #endregion

      #region ウインドウプロシージャメソッド
      protected override void WndProc(ref Message m)
      {
        // メッセージが
        if (m.Msg == WM_DRAWCLIPBOARD)
        {
          SendMessage(nextHandle, m.Msg, m.WParam, m.LParam);
          proc();
        }
        else if (m.Msg == WM_CHANGECBCHAIN)
        {
          if (m.WParam == nextHandle)
          {
            nextHandle = m.LParam;
          }
          else
          {
            SendMessage(nextHandle, m.Msg, m.WParam, m.LParam);
          }
        }
        base.WndProc(ref m);
      }
      #endregion

      #region Disposeメソッド
      protected override void Dispose(bool disposing)
      {
        // 対象ハンドル削除
        ChangeClipboardChain(this.Handle, nextHandle);
        base.Dispose(disposing);
      }
      #endregion
    }
    #endregion
  }
  #endregion
}
