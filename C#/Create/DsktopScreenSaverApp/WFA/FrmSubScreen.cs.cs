using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WFA
{
  public partial class FrmSubScreen : Form
  {
    #region コンストラクタ
    public FrmSubScreen(Form1 fm1)
    {
      InitializeComponent();
    } 
    #endregion


    #region 宣言

    // 主スレッド処理クラス変数
    FirstThread firstThread;
    // スレッド生成
    Thread threadA;

    #endregion


    #region プロパティ

    // 親フォーム
    public Form1 form1 { get; set; }

    // サブスクリーン情報
    public int subScreenWidth { get; set; }
    public int subScreenHeight { get; set; }

    // 設定情報
    public string TargetDir { get; set; }
    public int ViewTime { get; set; }
    public int ViewTimeMultiple { get; set; }

    #endregion


    #region フォームロードイベント
    private void FrmSubScreen_Load(object sender, EventArgs e)
    {
      // 主スレッド処理クラスインスタンス生成
      firstThread = new FirstThread(this, AssignThreadProcess);
      // 対象フォルダプロパティ設定
      firstThread.TargetDir = TargetDir;
      // 表示時間(ミリ秒)プロパティ設定
      firstThread.ViewTime = ViewTime;
      // 表示時間倍数数プロパティ設定
      firstThread.ViewTimeMultiple = ViewTimeMultiple;

      // スレッドインスタンス生成
      threadA = new Thread(new ParameterizedThreadStart(firstThread.PrimeThread));
      // スレッドスタート
      threadA.Start();

      // マウス非表示
      Cursor.Hide();
      // サイズモードを伸縮モードに設定
      pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

      // フォーム設定メソッド使用
      FormSetting();
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
      this.Bounds = new Rectangle(SystemInformation.PrimaryMonitorSize.Width + 1, 0, subScreenWidth, subScreenHeight);

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
    private void FrmSubScreen_FormClosed(object sender, FormClosedEventArgs e)
    {
      // スレッド完了フラグを立てる
      firstThread.EndFlag = true;
    } 
    #endregion
  }
}
