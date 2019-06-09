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

    // クリップボード
    ClipBoardWatcher cbw;
    // 監視対象外フラグ
    bool notMonitorFlg;

    #endregion


    #region フォームロードイベント
    private void Form1_Load(object sender, EventArgs e)
    {
      // オンオフボタン表示初期化
      btOnOff.Text = "オン";

      // 監視対象外フラグ初期化
      notMonitorFlg = false;
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
        if (notMonitorFlg)
        {
          return;
        }

        // 対象テキストボックスへ書き込み
        tbReadOnly.Text = Clipboard.GetText();
        // 対象テキストボックス初期化
        tbReadOnly.Text = string.Empty;
      };
    }
    #endregion

    #region ボタン1押下イベント
    private void button1_Click(object sender, EventArgs e)
    {
      string buttonTxt = string.Empty;

      // 監視対象外フラグ更新
      notMonitorFlg = !notMonitorFlg;

      // フラグが監視対象外の場合「オフ」
      buttonTxt = notMonitorFlg ? "オフ" : "オン";
      btOnOff.Text = buttonTxt;
    }
    #endregion

    #region テキストボックス値変更イベント
    private void tbReadOnly_TextChanged(object sender, EventArgs e)
    {
      // 値取得
      string targetStr = tbReadOnly.Text;
      int targetLength = targetStr.Length;
      string insStr = tbInsStr.Text;
      string insPosStr = tbInsPos.Text;
      bool isStrFｍtMode = cbIsStrFｍtMode.Checked;

      string cngTxt = string.Empty;

      // クリップボードに値を送る前にフラグを監視対象外に設定
      notMonitorFlg = true;

      // ねずみ返し_対象文字列が空の場合
      if (targetStr == string.Empty)
      {
        // 監視対象に戻す
        notMonitorFlg = false;
        return;
      }

      // 書式指定挿入モード
      if (isStrFｍtMode)
      {
        // 文字列書式指定挿入メソッド使用
        cngTxt = InsFormatTxt(insStr, targetStr);
      }
      else
      {
        // 文字数指定挿入メソッド使用
        cngTxt = InsPositionTxt(targetStr, insPosStr, insStr);
      }

      // ねずみ返し_挿入結果が空の場合
      if (cngTxt == string.Empty)
      {
        notMonitorFlg = false;
        return;
      }

      // クリップボードへ送る
      Clipboard.SetText(cngTxt);
      notMonitorFlg = false;
    }
    #endregion


    #region 文字列書式指定挿入メソッド
    private string InsFormatTxt(string targetStr, string insStr)
    {
      string returnStr = string.Empty;

      // 文字列指定で挿入
      returnStr = string.Format(insStr, targetStr);

      return returnStr;
    }
    #endregion

    #region 文字数指定挿入メソッド
    private string InsPositionTxt(string targetStr, string insPosStr, string insStr)
    {
      string returnStr = string.Empty;
      int targetStrLen = targetStr.Length;
      int insPosNum;

      // ねずみ返し_数値でない場合
      if (!int.TryParse(insPosStr, out insPosNum))
      {
        return "";
      }
      // ねずみ返し_絶対値が文字数を超す場合
      if (Math.Abs(insPosNum) > targetStrLen)
      {
        return "";
      }

      // マイナス値の場合
      if (insPosNum < 0)
      {
        // 末尾から指定
        insPosNum = targetStrLen + insPosNum;
      }

      // マイナスかつ0の場合
      if (insPosStr.Substring(0, 1) == "-" && insPosNum == 0)
      {
        // 末尾指定
        insPosNum = targetStrLen;
      }

      // 文字数指定で挿入
      returnStr = targetStr.Insert(insPosNum, insStr);

      return returnStr;
    }
    #endregion


    #region 雛形メソッド
    public void template()
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
