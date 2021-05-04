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

namespace WFA
{
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

      // パス取得グループボックスドロップ可設定(デザイナでは設定不可?)
      gbGetPath.AllowDrop = true;
    }
    #endregion

    #region コンフィグ取得メソッド
    public void GetConfig()
    {
      // コンパクトモードから復帰したときに使用するデフォルトの通常サイズ
      normalHeight = int.Parse(_comLogic.GetConfigValue("DefaultNormalHeight", "250"));
      normalWidth = int.Parse(_comLogic.GetConfigValue("DefaultNormalWidth", "480"));
      
      // デフォルト不透明度
      defaultOpacity = double.Parse(_comLogic.GetConfigValue("DefaultOpacity", "0.8"));
      // 不透明度増加値
      opacityUp = double.Parse(_comLogic.GetConfigValue("OpacityUp", "0.2"));
      // 不透明度減少値
      opacityDown = double.Parse(_comLogic.GetConfigValue("OpacityDown", "0.2"));

      copyTarget001 = _comLogic.GetConfigValue("CopyTarget001", string.Empty);

      // パス取得書式
      GET_PATH_STR_FORMAT = _comLogic.GetConfigValue("GetPathStrFormat", "{0}");

      // MultiRenameApp位置
      multiRenameAppPath = _comLogic.GetConfigValue("MultiRenameAppPath", @"..\multiRenameAppPath");
    }
    #endregion


    #region 宣言

    // 共通ロジッククラスインスタンス
    MCSComLogic _comLogic = new MCSComLogic();

    // コンパクトモードではないサイズ
    int normalHeight;
    int normalWidth;

    // デフォルト不透明度
    double defaultOpacity;
    // 不透明度増加値
    double opacityUp;
    // 不透明度減少値
    double opacityDown;

    // コピー対象変数
    string copyTarget001;

    // パス取得書式
    string GET_PATH_STR_FORMAT;

    // モードリスト
    List<string> listMode;

    // MultiRenameApp位置
    string multiRenameAppPath;

    #endregion

    #region フォームロードイベント
    private void Form1_Load(object sender, EventArgs e)
    {
      // フォーム不透明度調整
      this.Opacity = 0.8;
      // フォーム最前面化
      this.TopMost = true;
      // タスクバーにアイコンを表示しない
      this.ShowInTaskbar = false;
      
      // アプリモード配列初期化
      listMode = new List<string>();
      listMode.Add("GetPath");
      listMode.Add("MultiRenameApp");

      // モードコンボボックスに設定
      cbSelectMode.DataSource = listMode;
    }
    #endregion

    #region フォームダブルクリックイベント
    private void Form1_DoubleClick(object sender, EventArgs e)
    {
      // サイズがコンパクトモードの場合
      if (this.Size.Width == 250 && this.Size.Height == 150)
      {
        // サイズをもとに戻す
        this.Size = new Size(normalWidth, normalHeight);
      }
      else
      {
        // 現在のサイズを退避
        normalHeight = this.Size.Height;
        normalWidth = this.Size.Width;

        // サイズをコンパクトモードにする
        this.Size = new Size(250, 150);
      }
    }
    #endregion

    #region フォームサイズ変更イベント
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
    private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      // フォーム表示
      this.Show();

      // 最小化から復帰
      this.WindowState = FormWindowState.Normal;
    }
    #endregion


    #region パス取得グループボックスドロップエンターイベント
    private void gbGetPath_DragEnter(object sender, DragEventArgs e)
    {
      // ねずみ返し_マウスがファイルを持っていない場合、イベント・ハンドラを抜ける
      if (!e.Data.GetDataPresent(DataFormats.FileDrop))
      {
        return;
      }

      // ドラッグ中のファイルの取得
      string[] drags = (string[])e.Data.GetData(DataFormats.FileDrop);

      // ねずみ返し_フォルダかファイルを条件とする
      foreach (string d in drags)
      {
        // フォルダでもファイルでもない場合
        if (!Directory.Exists(d) && !File.Exists(d))
        {
          return;
        }
      }

      // マウスの表示を「+」に変更する
      e.Effect = DragDropEffects.Copy;
    }
    #endregion

    #region パス取得グループボックスドラッグドロップイベント
    private void gbGetPath_DragDrop(object sender, DragEventArgs e)
    {
      string setPath = string.Empty;
      bool compFlg = true;

      // コピー完了ラベル初期化
      lbCopyComp.Text = string.Empty;

      // ドラッグ&ドロップされたファイルの一つ目を取得
      string dropItem = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];

      // フォルダモードの場合
      if (cbIsDirPathMode.Checked)
      {
        // フォルダパス取得メソッド使用
        setPath =  GetDirPath(dropItem);
      }
      else
      {
        // ファイルパス取得メソッド使用
        setPath = GetFilePath(dropItem);
      }

      // モード分岐
      switch (cbSelectMode.SelectedItem.ToString())
      {
        case "MultiRenameApp":
          // MultiRenameApp送信メソッド使用
          compFlg = SendMultiRenameApp(setPath);
          break;

        default:
          // クリップボード送信メソッド使用
          compFlg = SendToClipBoard(setPath);
          break;
      }

      // 完了フラグによってラベル更新
      lbCopyComp.Text = compFlg ? "完了" : "失敗";

      // アプリモード初期化
      cbSelectMode.SelectedIndex = 0;
    }
    #endregion


    #region コピーボタン押下イベント共通
    private void btCopy_Click(object sender, EventArgs e)
    {
      // コピー完了ラベル初期化
      lbCopyComp.Text = string.Empty;

      try
      {
        // コピーコンボボックスの選択内容をクリップボードにセット
        Clipboard.SetText(cbCopyTgt.Text);
      }
      catch (Exception)
      {
        // コピー完了ラベル更新
        lbCopyComp.Text = "コピー失敗";
        return;
      }

      // コピー完了ラベル更新
      lbCopyComp.Text = "コピー完了";
    }
    #endregion

    #region 値保存ボタン押下イベント
    private void btSaveVal_Click(object sender, EventArgs e)
    {
      // ねずみ返し_テキストに値がない場合
      if (cbCopyTgt.Text == string.Empty)
      {
        return;
      }

      // コピー対象値出力メソッド使用
      OutputCopyValue(cbCopyTgt.Text);
    }
    #endregion

    #region 開くボタン押下イベント
    private void btOpenExplorer_Click(object sender, EventArgs e)
    {
      Process.Start(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
    }
    #endregion


    #region コンテキスト不透明度押下イベント
    private void ToolStripMenuItem不透明度_Click(object sender, EventArgs e)
    {
      // デフォルトに戻す
      this.Opacity = defaultOpacity;
    }
    #endregion

    #region コンテキスト不透明度_上げ押下イベント
    private void ToolStripMenuItem不透明度_上げ_Click(object sender, EventArgs e)
    {
      // 不透明度を上げる
      this.Opacity += opacityUp;
    }
    #endregion

    #region コンテキスト不透明度_下げ押下イベント
    private void ToolStripMenuItem不透明度_下げ_Click(object sender, EventArgs e)
    {
      // 不透明度を下げる
      this.Opacity -= opacityDown;
    }
    #endregion

    #region コンテキスト最前面押下イベント
    private void ToolStripMenuItem最前面_Click(object sender, EventArgs e)
    {
      // フォームの最前面フラグを変更
      this.TopMost = !this.TopMost;
    }
    #endregion


    #region コピー対象値出力メソッド
    /// <summary>
    /// コピー対象値出力メソッド
    /// </summary>
    /// <param name="logText">ログ出力文字列</param>
    private void OutputCopyValue(string logText)
    {
      try
      {
        // フォルダを使用する場合
        string dirPath = "SaveValue";
        if (!Directory.Exists(dirPath))
        {
          Directory.CreateDirectory(dirPath);
        }

        // コピー対象値を出力
        DateTime now = DateTime.Now;
        string fileName = now.ToString("yyyyMMddHHmmss") + "SaveValue.log";
        File.AppendAllText(Path.Combine(dirPath, fileName), logText + Environment.NewLine, Encoding.UTF8);
      }
      catch (Exception e)
      {

      }
    }
    #endregion


    #region フォルダパス取得メソッド
    private string GetDirPath(string targetPath)
    {
      string returnPath = targetPath;

      // ファイルの場合
      if (File.Exists(returnPath))
      {
        // フォルダまでを抜き出す
        returnPath = Path.GetDirectoryName(returnPath);
      }

      return string.Format(GET_PATH_STR_FORMAT, returnPath);
    }
    #endregion

    #region ファイルパス取得メソッド
    private string GetFilePath(string targetPath)
    {
      string returnPath = targetPath;

      return string.Format(GET_PATH_STR_FORMAT, returnPath);
    }
    #endregion


    #region クリップボード送信メソッド
    private bool SendToClipBoard(string sendVal)
    {
      try
      {
        // クリップボードにセット
        Clipboard.SetText(sendVal);
      }
      catch (Exception)
      {
        return false;
      }

      return true;
    }
    #endregion

    #region MultiRenameApp送信メソッド
    private bool SendMultiRenameApp(string sendVal)
    {
      try
      {
        // アプリ開始
        Process.Start(multiRenameAppPath, sendVal);
      }
      catch (Exception)
      {
        return false;
      }

      return true;
    }
    #endregion


    #region 雛形メソッド
    private void template()
    {

    }
    #endregion
  }
}
