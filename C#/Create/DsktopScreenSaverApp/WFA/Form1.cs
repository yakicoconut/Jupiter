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
using System.Drawing.Imaging;
using System.Threading;

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
      targetDir = _comLogic.GetConfigValue("TargetDir", "");
      viewTime = int.Parse(_comLogic.GetConfigValue("ViewTime", "1000"));
      viewTimeMultiple = int.Parse(_comLogic.GetConfigValue("ViewTimeMultiple", "3"));
    }
    #endregion


    #region 宣言

    // 共通ロジッククラスインスタンス
    MCSComLogic _comLogic = new MCSComLogic();

    // 主スレッド処理クラス変数
    FirstThread firstThread;
    // スレッド生成
    Thread threadA;

    // サブスクリーンクラス
    FrmSubScreen fmSubScreen;

    // 対象フォルダパス
    string targetDir;
    // 表示時間(ミリ秒)
    int viewTime;
    // 表示時間倍数数
    int viewTimeMultiple;

    #endregion


    #region フォームロードイベント
    private void Form1_Load(object sender, EventArgs e)
    {
      // 主スレッド処理クラスインスタンス生成
      firstThread = new FirstThread(this, AssignThreadProcess);
      // 対象フォルダプロパティ設定
      firstThread.TargetDir = targetDir;
      // 表示時間(ミリ秒)プロパティ設定
      firstThread.ViewTime = viewTime;
      // 表示時間倍数数プロパティ設定
      firstThread.ViewTimeMultiple = viewTimeMultiple;

      // スレッドインスタンス生成
      threadA = new Thread(new ParameterizedThreadStart(firstThread.PrimeThread));
      // スレッドスタート
      threadA.Start();

      // マウス非表示
      Cursor.Hide();
      // サイズモードを伸縮モードに設定
      pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

      // メインフォーム設定メソッド使用
      FormSetting();

      // 全スクリーン情報取得
      Screen[] screenArray = Screen.AllScreens;
      // マルチディスプレイの場合
      if (screenArray.Length >= 2)
      {
        // サブスクリーンクラスインスタンス生成
        fmSubScreen = new FrmSubScreen(this);

        // サブスクリーン情報引継ぎ
        fmSubScreen.subScreenWidth = screenArray[1].Bounds.Width;
        fmSubScreen.subScreenHeight = screenArray[1].Bounds.Height;

        // 設定情報引継ぎ
        fmSubScreen.TargetDir = targetDir;
        fmSubScreen.ViewTime = viewTime;
        fmSubScreen.ViewTimeMultiple = viewTimeMultiple;

        // オプションフォームのプロパティに本クラスを設定
        fmSubScreen.form1 = this;
        // フォーム2呼び出し
        fmSubScreen.Show();
      }
    }
    #endregion


    #region フォーム設定メソッド
    private void FormSetting()
    {
      // タスクバーにアイコンを表示しない
      this.ShowInTaskbar = false;

      // タスクバーを覆って表示
      this.WindowState = FormWindowState.Normal;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Bounds = new Rectangle(0, 0, SystemInformation.PrimaryMonitorSize.Width, SystemInformation.PrimaryMonitorSize.Height);

      // 最前面化(タスクバー見切れ対応)
      this.TopMost = true;
    }
    #endregion


    #region ピクチャボックス更新メソッド
    public void PicBoxUpdate(string str)
    {
      // ピクチャボックス画像設定
      pictureBox1.ImageLocation = str;
    }
    #endregion

    #region コントロール操作メソッド

    // ピクチャボックス更新メソッド用のデリゲート宣言
    delegate void PicBoxUpdateCallback(string str);

    public void ControlOperation(string path)
    {
      // ピクチャボックス更新メソッドのデリゲートインスタンス生成
      PicBoxUpdateCallback dlgInsLabelUpd = new PicBoxUpdateCallback(PicBoxUpdate);

      // ピクチャボックスコントロールのメソッド起動
      pictureBox1.Invoke(dlgInsLabelUpd, path);
    }

    #endregion

    #region スレッド処理振り分けメソッド
    public void AssignThreadProcess(string path)
    {
      // コントロール操作メソッド使用
      ControlOperation(path);
    }
    #endregion


    #region フォームクローズイベント
    private void Form1_FormClosed(object sender, FormClosedEventArgs e)
    {
      // サブスクリーンクラスインスタンスが存在する場合
      if (fmSubScreen != null)
      {
        // サブフォーム閉じる
        fmSubScreen.Close();
      }

      // スレッド完了フラグを立てる
      firstThread.EndFlag = true;
    }
    #endregion


    #region 雛形メソッド
    public void template()
    {

    }
    #endregion
  }
}