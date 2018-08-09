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

/*
 * 画面上のすべてのウィンドウとそのタイトルを列挙する - .NET Tips (VB.NET,C#...)
 * 	https://dobon.net/vb/dotnet/process/enumwindows.html
 * 外部アプリケーションのウィンドウをアクティブにする - .NET Tips (VB.NET,C#...)
 * 	https://dobon.net/vb/dotnet/process/appactivate.html
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
      // 除外ウィンドウ名
      omitTitle = _comLogic.GetConfigValue("OmitTitle", "DefaultValue").Split(',');
    }
    #endregion


    #region 宣言

    // 共通ロジッククラスインスタンス
    MCSComLogic _comLogic = new MCSComLogic();

    // プロセスディクショナリ
    public Dictionary<int, Process> dicProcess;

    // 除外ウィンドウ名
    string[] omitTitle;

    #endregion

    #region DllImport

    // 外部プロセスのメイン・ウィンドウを起動するためのWin32 API
    [DllImport("user32.dll")]
    private static extern bool SetForegroundWindow(IntPtr hWnd);
    [DllImport("user32.dll")]
    private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
    [DllImport("user32.dll")]
    private static extern bool IsIconic(IntPtr hWnd);
    // ShowWindowAsync関数のパラメータに渡す定義値
    // 画面を元の大きさに戻す
    private const int SW_RESTORE = 9;

    #endregion


    #region フォームロードイベント
    private void Form1_Load(object sender, EventArgs e)
    {
      // リストビューマルチセレクト禁止
      lvProcessList.MultiSelect = false;

      // プロセスディクショナリ初期化
      dicProcess = new Dictionary<int, Process>();

      // リストビュー初期化メソッド使用
      InitListView();
    }
    #endregion

    #region キー押下イベント
    private void lvProcessList_KeyDown(object sender, KeyEventArgs e)
    {
      // ねずみ返し_リストビューの項目が選択されていない場合
      if (lvProcessList.SelectedItems.Count <= 0)
      {
        return;
      }

      // 現在行数取得
      int currentIndex = lvProcessList.SelectedItems[0].Index;
      // 最終行取得 
      int lastIndex = lvProcessList.Items.Count - 1;
      // 移動先行初期化
      int destIndex = 0;

      // ねずみ返し_全ての項目がチェックされている場合
      if (lvProcessList.CheckedItems.Count == lvProcessList.Items.Count)
        return;

      // 上押下かつ先頭行の場合
      if (e.KeyCode == Keys.Up)
      {
        // 上へループ
        while (true)
        {
          // 現在行の一つ上が範囲内なら一つ上の行設定、範囲外なら最終行設定
          destIndex = currentIndex - 1 >= 0 ? currentIndex - 1 : lastIndex;

          // 移動先がチェックされている場合
          if (lvProcessList.Items[destIndex].Checked)
          {
            // 現在行数変数を更新
            currentIndex = destIndex;
            continue;
          }

          break;
        }

        // 行選択メソッド使用
        SelectItemRow(currentIndex, destIndex, e);
      }
      // 下押下かつ最終行の場合
      else if (e.KeyCode == Keys.Down)
      {
        // 下へループ
        while (true)
        {
          // 現在行の一つ下が範囲内なら一つ下の行設定、範囲外なら先頭行設定
          destIndex = currentIndex + 1 <= lastIndex ? currentIndex + 1 : 0;

          // 移動先がチェックされている場合
          if (lvProcessList.Items[destIndex].Checked)
          {
            // 現在行数変数を更新
            currentIndex = destIndex;
            continue;
          }

          break;
        }

        // 行選択メソッド使用
        SelectItemRow(currentIndex, destIndex, e);
      }
    }
    #endregion

    #region リストビュー選択項目変更イベント
    private void lvProcessList_SelectedIndexChanged(object sender, EventArgs e)
    {
      // 選択中アイテム取得
      var windowTitle = lvProcessList.SelectedItems;

      // ねずみ返し_選択中アイテムがない場合
      if (windowTitle.Count <= 0)
        return;

      #region コメント_VBウィンドウアクティブメソッド使用

      //// VBウィンドウアクティブメソッド使用
      //// ウィンドウタイトルでアクティブ化
      //ActiveWindowVB(windowTitle[0].Text);

      #endregion

      // ディクショナリからウィンドウプロセス取得
      Process windowProc = dicProcess[windowTitle[0].Index];
      // User32ウィンドウアクティブメソッド使用
      ActiveWindowUser32(windowProc.MainWindowHandle);

      // 自身をアクティブ化
      this.Activate();
    }
    #endregion

    #region 更新ボタン押下イベント
    private void button1_Click(object sender, EventArgs e)
    {
      // リストビュー初期化メソッド使用
      InitListView();
    }
    #endregion


    #region リストビュー初期化メソッド
    /// <summary>
    /// リストビュー初期化メソッド
    /// </summary>
    public void InitListView()
    {
      // リストビュー初期化
      lvProcessList.Items.Clear();
      // プロセスディクショナリ初期化
      dicProcess = new Dictionary<int, Process>();

      // 全プロセスをループ処理
      int i = 0;
      foreach (Process x in Process.GetProcesses())
      {
        // ねずみ返し_タイトルがない場合
        if (x.MainWindowTitle == string.Empty)
          continue;

        // ウィンドウタイトル取得
        string windowTitle = Path.GetFileName(x.MainWindowTitle);

        // リストビューにプロセス名追加
        lvProcessList.Items.Add(windowTitle);

        // 除外ウィンドウ名の場合
        if (omitTitle.Contains(windowTitle))
          // チェックをつける
          lvProcessList.Items[i].Checked = true;

        // ディクショナリにも追加
        dicProcess.Add(i, x);
        i += 1;
      }
    }
    #endregion

    #region 行選択メソッド
    private void SelectItemRow(int currentIndex, int destIndex, KeyEventArgs e)
    {
      // 現在選択行の選択をはずす
      lvProcessList.Items[currentIndex].Selected = false;
      lvProcessList.Items[currentIndex].Focused = false;
      // 対象行を選択
      lvProcessList.Items[destIndex].Selected = true;
      lvProcessList.Items[destIndex].Focused = true;

      // 選択処理が二重で実行されるため
      // デフォルト(一つ上を選択する)キー押下イベント無効化
      // 参照型のため値変更後返す必要はない
      e.Handled = true;
    }
    #endregion


    #region VBウィンドウアクティブメソッド
    public void ActiveWindowVB(string windowTitle)
    {
      // VB.dll使用
      Interaction.AppActivate(windowTitle);
    }
    #endregion

    #region User32ウィンドウアクティブメソッド
    public void ActiveWindowUser32(IntPtr windowHandle)
    {
      //// 単純なアクティブ化
      //SetForegroundWindow(windowHandle);

      // ウィンドウが最小化されていれば元に戻す
      if (IsIconic(windowHandle))
      {
        ShowWindowAsync(windowHandle, SW_RESTORE);
      }

      // ウィンドウを最前面に表示する
      SetForegroundWindow(windowHandle);
    }
    #endregion


    #region 雛形メソッド
    public void template()
    {

    }
    #endregion
  }
}