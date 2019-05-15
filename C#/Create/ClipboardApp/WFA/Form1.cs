﻿using System;
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
      normalHeight = int.Parse(ConfigurationManager.AppSettings["DefaultNormalHeight"]);
      normalWidth = int.Parse(ConfigurationManager.AppSettings["DefaultNormalWidth"]);

      // デフォルト不透明度
      defaultOpacity = double.Parse(ConfigurationManager.AppSettings["DefaultOpacity"]);
      // 不透明度増加値
      opacityUp = double.Parse(ConfigurationManager.AppSettings["OpacityUp"]);
      // 不透明度減少値
      opacityDown = double.Parse(ConfigurationManager.AppSettings["OpacityDown"]);

      copyTarget001 = ConfigurationManager.AppSettings["CopyTarget001"];
      copyTarget002 = ConfigurationManager.AppSettings["CopyTarget002"];
      copyTarget003 = ConfigurationManager.AppSettings["CopyTarget003"];
      copyTarget004 = ConfigurationManager.AppSettings["CopyTarget004"];
      copyTarget005 = ConfigurationManager.AppSettings["CopyTarget005"];
      copyTarget006 = ConfigurationManager.AppSettings["CopyTarget006"];
      copyTarget007 = ConfigurationManager.AppSettings["CopyTarget007"];
      copyTarget008 = ConfigurationManager.AppSettings["CopyTarget008"];
      copyTarget009 = ConfigurationManager.AppSettings["CopyTarget009"];
      copyTarget010 = ConfigurationManager.AppSettings["CopyTarget010"];

      // パス取得書式
      GET_PATH_STR_FORMAT = ConfigurationManager.AppSettings["GetPathStrFormat"];
    }
    #endregion


    #region 宣言

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
    string copyTarget002;
    string copyTarget003;
    string copyTarget004;
    string copyTarget005;
    string copyTarget006;
    string copyTarget007;
    string copyTarget008;
    string copyTarget009;
    string copyTarget010;

    // パス取得書式
    string GET_PATH_STR_FORMAT;

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

      tbCopy001.Text = copyTarget001;
      tbCopy002.Text = copyTarget002;
      tbCopy003.Text = copyTarget003;
      tbCopy004.Text = copyTarget004;
      tbCopy005.Text = copyTarget005;
      tbCopy006.Text = copyTarget006;
      tbCopy007.Text = copyTarget007;
      tbCopy008.Text = copyTarget008;
      tbCopy009.Text = copyTarget009;
      tbCopy010.Text = copyTarget010;
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

      // クリップボードにセット
      Clipboard.SetText(setPath);
    }
    #endregion


    #region コピーボタン押下イベント共通
    private void btCopy_Click(object sender, EventArgs e)
    {
      // イベント発生コントロール取得
      Control ctrl = (Control)sender;
      // コントロールの番号を取得
      string ctrlNum = ctrl.Name.Substring(ctrl.Name.Length - 3, 3);
      // 対象のテキストボックス取得
      TextBox targetCtrl = (TextBox)this.Controls["tbCopy" + ctrlNum];

      // コピーボタンの内容をクリップボードにセット
      Clipboard.SetText(targetCtrl.Text);
    }
    #endregion

    #region 値保存ボタン押下イベント
    private void btSaveVal_Click(object sender, EventArgs e)
    {
      // テキストボックスを全て取得する
      for (int i = 1; i <= 10; i++)
      {
        // 対象のテキストボックス取得
        TextBox targetCtrl = (TextBox)this.Controls["tbCopy" + i.ToString("000")];
        // ねずみ返し_テキストに値がない場合
        if (targetCtrl.Text == string.Empty)
        {
          continue;
        }

        // コピー対象値出力メソッド使用
        OutputCopyValue(targetCtrl.Text);
      }
    }
    #endregion

    #region 開くボタン押下イベント
    private void btOpenExplorer_Click(object sender, EventArgs e)
    {
      Process.Start(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
    }
    #endregion


    #region コンテキスト不透明度押下イベント
    private void 不透明度ToolStripMenuItem_Click(object sender, EventArgs e)
    {
      // デフォルトに戻す
      this.Opacity = defaultOpacity;
    }
    #endregion

    #region コンテキスト不透明度_上げ押下イベント
    private void 上げToolStripMenuItem_Click(object sender, EventArgs e)
    {
      // 不透明度を上げる
      this.Opacity += opacityUp;
    }
    #endregion

    #region コンテキスト不透明度_下げ押下イベント
    private void 下げToolStripMenuItem_Click(object sender, EventArgs e)
    {
      // 不透明度を下げる
      this.Opacity -= opacityDown;
    }
    #endregion

    #region コンテキスト最前面押下イベント
    private void 最前面ToolStripMenuItem_Click(object sender, EventArgs e)
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


    #region 雛形メソッド
    private void template()
    {

    }
    #endregion
  }
}
