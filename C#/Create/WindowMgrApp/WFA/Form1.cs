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
      // 除外プロセス名
      omitProcess = _comLogic.GetConfigValue("OmitProcess", "DefaultValue").Split(',');
    }
    #endregion


    #region 宣言

    // 共通ロジッククラスインスタンス
    MCSComLogic _comLogic = new MCSComLogic();

    // プロセスディクショナリ
    public Dictionary<string, Process> dicProcess;
    // プロセスディクショナリアクセスキー数値
    int dicAcsKeyNum = 0;

    // 除外ウィンドウ名
    string[] omitTitle;
    // 除外プロセス名
    string[] omitProcess;

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
      // 最前面設定
      this.TopMost = true;
      cbIsTopMost.Checked = true;

      // フォームのキー押下イベントを受け取る設定
      this.KeyPreview = true;

      // リストビューマルチセレクト禁止
      lvProcessList.MultiSelect = false;
      // リストビュードロップ許可
      lvProcessList.AllowDrop = true;

      // リストビュー初期化メソッド使用
      InitListView();
    }
    #endregion


    #region フォームキー押下イベント
    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
      // F5の場合
      if (e.KeyCode == Keys.F5)
      {
        // リストビュー初期化メソッド使用
        InitListView();
        return;
      }
    }
    #endregion

    #region リストビューキー押下イベント
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
      // 操作後、次の項目へ行くかどうかフラグ
      bool isNext = false;

      // 押下キー分岐
      switch (e.KeyCode)
      {
        // 上
        case Keys.Up:
          // リスト上下押下メソッド使用
          ListViewKeyDownUpDown(isNext, currentIndex, lastIndex, e);
          break;

        // 下
        case Keys.Down:
          // 次の項目へフラグを立てる
          isNext = true;
          // リスト上下押下メソッド使用
          ListViewKeyDownUpDown(isNext, currentIndex, lastIndex, e);
          break;

        default:
          break;
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

      // ねずみ返し_選択中アイテムにチェックがある場合
      if (windowTitle[0].Checked)
        return;

      #region コメント_VBウィンドウアクティブメソッド使用

      //// VBウィンドウアクティブメソッド使用
      //// ウィンドウタイトルでアクティブ化
      //ActiveWindowVB(windowTitle[0].Text);

      #endregion

      // プロセスディクショナリアクセスキー取得
      string dicAcsKeyStr = windowTitle[0].Text.Substring(windowTitle[0].Text.Length - 6, 6);

      // ディクショナリからウィンドウプロセス取得
      Process windowProc = dicProcess[dicAcsKeyStr];
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

    #region 最善面チェックボックス変更イベント
    private void cbIsTopMost_CheckedChanged(object sender, EventArgs e)
    {
      // 最前面設定
      this.TopMost = cbIsTopMost.Checked;
    } 
    #endregion


    #region ドラッグ&ドロップイベント
    private void lvProcessList_DragDrop(object sender, DragEventArgs e)
    {
      // ねずみ返し_ドラッグできるアイテムかどうか
      if (!e.Data.GetDataPresent(typeof(ListViewItem)))
      {
        return;
      }

      // 対象アイテム
      ListViewItem srcItem = (ListViewItem)e.Data.GetData(typeof(ListViewItem));

      // 対象アイテムの位置からアイテム自体を取得
      Point p = lvProcessList.PointToClient(new Point(e.X, e.Y));
      ListViewItem item = lvProcessList.GetItemAt(p.X, p.Y);

      // 行番号取得
      int destIndex = lvProcessList.Items.IndexOf(item);
      // チェック有無取得
      bool isChk = srcItem.Checked;

      // アイテムが存在しない場所の場合
      if (destIndex == -1)
      {
        // リストの最後に追加
        destIndex = lvProcessList.Items.Count;
      }
      // 移動先が自分自身より下の場合
      else if (destIndex > srcItem.Index)
      {
        // 自分自身より上の場合、選択した場所に挿入する。
        destIndex++;
      }

      // 挿入
      ListViewItem newItem = lvProcessList.Items.Insert(destIndex, srcItem.Text);
      // チェック引継ぎ
      newItem.Checked = isChk;
      newItem.Selected = true;

      // 元アイテム削除
      lvProcessList.Items.Remove(srcItem);
    }
    #endregion

    #region ドラッグエンターイベント
    private void lvProcessList_DragEnter(object sender, DragEventArgs e)
    {
      // ねずみ返し_ドラッグできるアイテムかどうか
      if (!e.Data.GetDataPresent(typeof(ListViewItem)))
      {
        return;
      }

      // 左クリックの場合
      if (e.KeyState == 0x1 || (e.KeyState & 0x8) > 0)
      {
        // 移動
        e.Effect = DragDropEffects.Move;
      }
    }
    #endregion

    #region ドラッグオーバーイベント
    private void lvProcessList_DragOver(object sender, DragEventArgs e)
    {
      // ねずみ返し_ドラッグできるアイテムかどうか
      if (!e.Data.GetDataPresent(typeof(ListViewItem)))
      {
        return;
      }

      // 対象アイテムの位置からアイテム自体を取得
      Point p = lvProcessList.PointToClient(new Point(e.X, e.Y));
      ListViewItem item = this.lvProcessList.GetItemAt(p.X, p.Y);

      // アイテムがある場合
      if (item != null)
      {
        // 選択
        item.Selected = true;
      }
    }
    #endregion

    #region 選択アイテムドラッグイベント
    private void lvProcessList_ItemDrag(object sender, ItemDragEventArgs e)
    {
      // ドラッグ&ドロップイベント開始
      lvProcessList.DoDragDrop((ListViewItem)e.Item, DragDropEffects.Copy | DragDropEffects.Move);
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
      dicProcess = new Dictionary<string, Process>();
      // プロセスディクショナリアクセスキー数値初期化
      dicAcsKeyNum = 0;

      // 全プロセスをループ処理
      int i = 0;
      foreach (Process x in Process.GetProcesses())
      {
        // ねずみ返し_タイトルがない場合
        if (x.MainWindowTitle == string.Empty)
          continue;

        // ウィンドウタイトル取得
        string windowTitle = Path.GetFileName(x.MainWindowTitle);
        // プロセス(アプリ)名取得
        string processName = x.ProcessName;

        // プロセスディクショナリアクセスキー数値インクリメント
        dicAcsKeyNum++;
        // プロセスディクショナリアクセスキー作成
        string dicAcsKeyStr = "DIC" + dicAcsKeyNum.ToString("000");

        // リストビューにプロセス名追加
        lvProcessList.Items.Add(windowTitle + " " + dicAcsKeyStr);

        // 除外ウィンドウ名か除外プロセス名の場合
        if (omitTitle.Contains(windowTitle) || omitProcess.Contains(processName))
          // チェックをつける
          lvProcessList.Items[i].Checked = true;

        // ディクショナリにも追加
        dicProcess.Add(dicAcsKeyStr, x);
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


    #region リスト上下押下メソッド
    private void ListViewKeyDownUpDown(bool isNext, int currentIndex, int lastIndex, KeyEventArgs e)
    {
      // ねずみ返し_全ての項目がチェックされている場合
      if (lvProcessList.CheckedItems.Count == lvProcessList.Items.Count)
        return;

      int destIndex;

      while (true)
      {
        if (isNext)
        {
          // 現在行の一つ下が範囲内なら一つ下の行設定、範囲外なら先頭行設定
          destIndex = currentIndex + 1 <= lastIndex ? currentIndex + 1 : 0;
        }
        else
        {
          // 現在行の一つ上が範囲内なら一つ上の行設定、範囲外なら最終行設定
          destIndex = currentIndex - 1 >= 0 ? currentIndex - 1 : lastIndex;
        }

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