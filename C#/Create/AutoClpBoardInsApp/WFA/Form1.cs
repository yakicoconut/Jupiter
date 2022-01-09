using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

#region 概要
/*
 * 備考
 *   ・エクセルでセルコピーした場合、
 *     クリップボードクリア?とセルコピーで
 *     2回以上クリップボード送信処理が行われる
 *     ⇒クリップボードデータ内のフォーマットから
 *       エクセル判定して前回内容と同じであれば
 *       スルーする処理とする
 * サイト
 *   C#からClipboardを操作する - KrdLab's blog
 *   	https://krdlab.hatenablog.com/entry/20070311/1173603960
 *   クリップボードの内容の変化を知る方法 | 鳩でもわかるC#
 *   	https://lets-csharp.com/how-to-clipboard-listener/
 *   ビューアチェイン
 *   	http://wisdom.sakura.ne.jp/system/winapi/win32/win92.html
 *   C#でClipboard監視(Windows API) - Qiita
 *   	https://qiita.com/kob58im/items/2697ea4c12c72ecd86c8
 *   クリップボードを監視してテキストボックスに追加していく感じの。
 *   	https://gist.github.com/unarist/6342758
 *   不二家: Windows message 一覧
 *   	http://fujyojp.blogspot.com/2009/07/windows-message.html
 *   C# Clipboardクラスでクリップボードを監視するとComExceptionが発生する - OITA: Oika's Information Technological Activities
 *   	https://oita.oika.me/2014/05/23/clipboard-comexception/
 *   のぶろぐ クリップボード使用時のCOMException
 *   	http://shen7113.blog.fc2.com/blog-entry-28.html
 *   クリップボードからデータを取得する クリップボードへデータを設定する [C#] | JOHOBASE
 *   	https://johobase.com/clipboard-get-set-csharp/
 *   C# でウィンドウメッセージをキャプチャするメッセージフィルターを利用する方法 - C# を用いた開発 - C# 入門
 *   	https://csharp.keicode.com/basic/message-filter.php
 *   動作原理とクリップボードチェイン - コピペテキスト修飾除去のヘルプ
 *   	https://www.inasoft.org/webhelp/delattr/HLP000010.html
 *   WM_CLIPBOARDUPDATE message (Winuser.h) - Win32 apps | Microsoft Docs
 *   	https://docs.microsoft.com/ja-jp/windows/win32/dataxchg/wm-clipboardupdate
 *   C#|クリップボードの変更を監視する | 貧脚レーサーのサボり日記
 *   	https://anis774.net/codevault/clipboardwatcher.html
 *   ぶびびんぶろぐ: WndProc（ウインドウプロシージャ）
 *   	http://bubibinba.blogspot.com/2012/06/wndproc.html
 *   【WindowsAPIメモ】メッセージ一覧 | フィロの村note
 *    http://note.phyllo.net/?eid=1106271
 *   API 関数解説
 *   	http://tokovalue.jp/function/SetClipboardViewer.htm
 */
#endregion
namespace WFA
{
  /// <summary>
  /// メインフォーム
  /// </summary>
  public partial class Form1 : Form
  {
    #region dllインポート

    // クリップボードリスナー登録関数
    [DllImport("user32.dll", SetLastError = true)]
    private extern static void AddClipboardFormatListener(IntPtr hwnd);
    // クリップボードリスナー解除関数
    [DllImport("user32.dll", SetLastError = true)]
    private extern static void RemoveClipboardFormatListener(IntPtr hwnd);

    #endregion


    #region コンストラクタ
    /// <summary>
    /// コンストラクタ
    /// </summary>
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
    /// <summary>
    /// コンフィグ取得メソッド
    /// </summary>
    public void GetConfig()
    {
      // 起動時オンフラグ取得
      if(bool.TryParse(_comLogic.GetConfigValue("IsInitOn", "False"), out isOn))
      {
        isOn = false;
      }
    }
    #endregion


    #region 宣言

    #region 定数

    /// <summary>
    /// エクセルセルフォーマット判定文字列 
    /// </summary>
    const string EXXEL_CELL_FMT = "EnhancedMetafile,MetaFilePict,System.Drawing.Bitmap,Bitmap,Biff12,Biff8,Biff5,SymbolicLink,DataInterchangeFormat,XML Spreadsheet,HTML Format,System.String,UnicodeText,Text,Csv,Hyperlink,Rich Text Format,Embed Source,Object Descriptor,Link Source,Link Source Descriptor,Link,Format129";

    /// <summary>
    /// クリップボードSetTextメソッドからの登録判定文字列 
    /// </summary>
    const string SET_TXT_FMT = "System.String,UnicodeText,Text";

    #endregion

    /// <summary>
    /// 共通ロジッククラスインスタンス 
    /// </summary>
    MCSComLogic _comLogic = new MCSComLogic();

    /// <summary>
    /// オンフラグ
    /// </summary>
    bool isOn;

    /// <summary>
    /// 前回コピー文字列
    /// </summary>
    string preTxt = string.Empty;
    /// <summary>
    /// 前回処理後文字列
    /// </summary>
    string preResTxt = string.Empty;

    /// <summary>
    /// デフォルト不透明度
    /// </summary>
    double defaultOpacity;
    /// <summary>
    /// 不透明度増加値
    /// </summary>
    double opacityUp;
    /// <summary>
    /// 不透明度減少値
    /// </summary>
    double opacityDown;

    #endregion


    #region フォームロードイベント
    /// <summary>
    /// フォームロードイベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Form1_Load(object sender, EventArgs e)
    {
      // フォーム不透明度調整
      this.Opacity = 0.8;
      // フォーム最前面化
      this.TopMost = true;
      // タスクバーにアイコンを表示しない
      this.ShowInTaskbar = false;

      // オンの場合
      if (isOn)
      {
        // クリップボードリスナー登録実行
        AddClipboardFormatListener(Handle);
        // オンオフラベル更新
        lbOnOff.Text = "ON";
      }
    }
    #endregion

    #region フォームサイズ変更イベント
    /// <summary>
    /// フォームサイズ変更イベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Form1_SizeChanged(object sender, EventArgs e)
    {
      // 最小化の場合
      if (this.WindowState == FormWindowState.Minimized)
      {
        // 完全に隠す
        this.Hide();
      }
    }
    #endregion

    #region 常駐アイコンダブルクリックイベント
    /// <summary>
    /// 常駐アイコンダブルクリックイベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      // フォーム表示
      this.Show();

      // 最小化から復帰
      this.WindowState = FormWindowState.Normal;
    }
    #endregion


    #region On/Offボタン押下イベント
    /// <summary>
    /// On/Offボタン押下イベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btOnOff_Click(object sender, EventArgs e)
    {
      // オンオフフラグ切り替え
      isOn = !isOn;

      // クリップボードリスナー登録/解除
      if (isOn)
      {
        AddClipboardFormatListener(Handle);
      }
      else
      {
        RemoveClipboardFormatListener(Handle);
      }

      // オンオフラベル更新
      lbOnOff.Text = isOn ? "ON" : "OFF";
    }
    #endregion


    #region 採取モードチェックボックス変更イベント
    /// <summary>
    /// 採取モードチェックボックス変更イベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Com_Cb_CheckedChanged(object sender, EventArgs e)
    {
      // 各チェックボックス値合計
      int sumModeChk = Convert.ToInt32(cbIsCollMode.Checked) + Convert.ToInt32(cbIsReSendMode.Checked);
      if (sumModeChk != 0)
      {
        return;
      }

      // 発火元コントロール分岐
      switch (sender)
      {
        // 採取チェックボックス
        case CheckBox ctrl when sender.Equals(cbIsCollMode):
          // どれか一つは必ずチェックする
          cbIsReSendMode.Checked = true;
          break;

        // 再登録チェックボックス
        case CheckBox ctrl when sender.Equals(cbIsReSendMode):
          cbIsCollMode.Checked = true;
          break;
      }
    }
    #endregion


    #region Winメッセージキャッチイベント
    /// <summary>
    /// Winメッセージキャッチイベント
    /// </summary>
    /// <param name="m">メッセージ</param>
    protected override void WndProc(ref Message m)
    {
      // ねずみ返し_クリップボード更新通知でない場合
      if (m.Msg != 0x31D)
      {
        // 継承元メソッド呼び出し
        base.WndProc(ref m);
        return;
      }

      // finally実施目的try句
      try
      {
        // クリップボードテキスト取得
        string crTxt = Clipboard.GetText();

        // クリップボード内容判定メソッド使用
        bool ret = ChkClipData(crTxt);
        // ねずみ返し_判断結果が終了の場合
        if (!ret)
        {
          return;
        }

        // 文字列操作メソッド使用
        StrMan(crTxt);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString());
      }
      finally
      {
        // 事後作業
        m.Result = IntPtr.Zero;
      }
    }
    #endregion


    #region クリップボード内容判定メソッド
    /// <summary>
    /// クリップボード内容判定メソッド
    /// </summary>
    /// <param name="crTxt">対象クリップボードテキスト</param>
    /// <returns>成否</returns>
    private bool ChkClipData(string crTxt)
    {
      // ねずみ返し_文字列型が含まれない場合
      if (!Clipboard.ContainsText())
      {
        return false;
      }

      //クリップボードデータ取得
      IDataObject data = Clipboard.GetDataObject();

      // 関連付けられている全形式取得
      string[] fmtAry = data.GetFormats();
      string fmtStr = string.Join(",", fmtAry);

      // フォーマット分岐
      switch (fmtStr)
      {
        // エクセルの場合
        case EXXEL_CELL_FMT:
          // ねずみ返し_前回コピー文字列と同じ場合
          if (crTxt == preTxt)
          {
            return false;
          }
          break;

        // 再登録の場合
        case SET_TXT_FMT:
          // ねずみ返し_前回処理後文字列と同じ場合
          if (crTxt == preResTxt)
          {
            return false;
          }
          break;

        default:
          break;
      }

      return true;
    }
    #endregion

    #region 文字列操作メソッド
    /// <summary>
    /// 文字列操作メソッド
    /// </summary>
    /// <param name="crTxt">対象クリップボードテキスト</param>
    private void StrMan(string crTxt)
    {
      // 採取モードチェックボックス値
      bool isCollMode = cbIsCollMode.Checked;
      // クリップボード再登録モードチェックボックス値
      bool isReSendMode = cbIsReSendMode.Checked;
      // 改行するかチェックボックス値
      bool isNewLine = cbIsNewLine.Checked;
      // 正規表現検索文字列テキストボックス値取得
      string regStr = tbRegStr.Text;
      // 正規表現置換後文字列テキストボックス値取得
      string repStr = tbRepStr.Text;

      // 処理後文字列
      string resSr = crTxt;

      // 正規表現検索文字列が空でない場合
      if (regStr != string.Empty)
      {
        // 文字列置き換えメソッド使用
        resSr = ReplaceTxt(resSr, regStr, repStr);
      }

      // 改行する場合
      if (isNewLine)
      {
        // 改行文字列設定
        resSr += Environment.NewLine;
      }

      // 採取モードの場合
      if (isCollMode)
      {
        // 採取テキストボックスに追加
        tbColl.AppendText(resSr);
      }

      // クリップボード再登録モードの場合
      if (isReSendMode)
      {
        // 処理後文字列を前回処理後文字列変数に設定
        preResTxt = resSr;

        // クリップボードへ再登録
        Clipboard.SetText(resSr);
      }

      // 前回文字列に退避
      preTxt = crTxt;
    }
    #endregion

    #region 文字列置き換えメソッド
    /// <summary>
    /// 文字列置き換えメソッド
    /// </summary>
    /// <param name="tgtStr">対象文字列</param>
    /// <param name="regStr">検索文字列</param>
    /// <param name="newStr">置き換え文字列</param>
    /// <returns>置き換え結果文字列</returns>
    private string ReplaceTxt(string tgtStr, string regStr, string newStr)
    {
      string retStr = string.Empty;

      // 正規表現置き換え
      retStr = Regex.Replace(tgtStr, regStr, newStr, RegexOptions.Multiline);

      return retStr;
    }
    #endregion


    #region コンテキスト不透明度押下イベント
    /// <summary>
    /// コンテキスト不透明度押下イベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ToolStripMenuItem不透明度_Click(object sender, EventArgs e)
    {
      // デフォルトに戻す
      this.Opacity = defaultOpacity;
    }
    #endregion

    #region コンテキスト不透明度_上げ押下イベント
    /// <summary>
    /// コンテキスト不透明度_上げ押下イベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ToolStripMenuItem不透明度_上げ_Click(object sender, EventArgs e)
    {
      // 不透明度を上げる
      this.Opacity += opacityUp;
    }
    #endregion

    #region コンテキスト不透明度_下げ押下イベント
    /// <summary>
    /// コンテキスト不透明度_下げ押下イベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ToolStripMenuItem不透明度_下げ_Click(object sender, EventArgs e)
    {
      
      // 不透明度を下げる
      this.Opacity -= opacityDown;
    }
    #endregion

    #region コンテキスト最前面押下イベント
    /// <summary>
    /// コンテキスト最前面押下イベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ToolStripMenuItem最前面_Click(object sender, EventArgs e)
    {
      // フォームの最前面フラグを変更
      this.TopMost = !this.TopMost;
    }
    #endregion


    #region フォームクロージングイベント
    /// <summary>
    /// フォームクロージングイベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      // クリップボードリスナー解除
      RemoveClipboardFormatListener(Handle);
    }
    #endregion
  }
}
