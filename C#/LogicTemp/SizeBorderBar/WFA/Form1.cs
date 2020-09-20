using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using Microsoft.VisualBasic;
using System.Diagnostics;


#region ヘッダ
/*
* 概要
*   サイズ変更不可コントロールのサイズ変更を
*   パネルで実装する
* 詳細
*   四辺にバー状のパネルを配置し、
*   マウスクリック、移動イベントでサイズ変更を行う
* 特記
*   コントロールの背景色プロパティにある
*   Transparent(透過色)は親コントロールの
*   色に依存する
*   →そのため、直下となるコントロールに対して
*     パネルの追加を行う(デザイナからではなく、
*     コードでの対応)
* サイト
*   フォームの端をドラッグしてサイズ変更する機能を提供するクラス（C#用） - amongの雑記
*   	https://among-ev.hatenadiary.org/entry/20110320/1300593343
*   PictureBox上のLabelの背景が透明にならない問題の解決法 - .NET Tips (VB.NET,C#...)
*   	https://dobon.net/vb/dotnet/control/labelonpicturebox.html
*/ 
#endregion
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

    // サイズ変更境界線パネル
    private Panel borderPanelTop;
    private Panel borderPanelLeft;
    private Panel borderPanelRight;
    private Panel borderPanelBottom;
    private Panel borderPanelRightBottom;

    // マウスのクリック位置を記憶
    private Point ctrlMousePoint;

    #endregion


    #region フォームロードイベント
    private void Form1_Load(object sender, EventArgs e)
    {
      // 境界線パネル設定メソッド使用
      SetBorderPanel();
    }
    #endregion

    #region 境界線パネル設定メソッド
    private void SetBorderPanel()
    {
      borderPanelTop = new Panel();
      // 透過色用に直下コントロールを親とする
      textBox1.Controls.Add(borderPanelTop);
      // 透過色背景色
      borderPanelTop.BackColor = Color.Transparent;
      // カーソル矢印
      borderPanelTop.Cursor = Cursors.SizeNS;
      // ドッキング
      borderPanelTop.Dock = DockStyle.Top;
      borderPanelTop.Size = new Size(350, 5);
      // イベント
      borderPanelTop.MouseDown += new MouseEventHandler(borderPanel_Comm_MouseDown);
      borderPanelTop.MouseMove += new MouseEventHandler(borderPanelTop_MouseMove);

      borderPanelLeft = new Panel();
      textBox1.Controls.Add(borderPanelLeft);
      borderPanelLeft.BackColor = Color.Transparent;
      borderPanelLeft.Cursor = Cursors.SizeWE;
      borderPanelLeft.Dock = DockStyle.Left;
      borderPanelLeft.Size = new Size(5, 200);
      borderPanelLeft.MouseDown += new MouseEventHandler(borderPanel_Comm_MouseDown);
      borderPanelLeft.MouseMove += new MouseEventHandler(borderPanelLeft_MouseMove);

      borderPanelRight = new Panel();
      textBox1.Controls.Add(borderPanelRight);
      borderPanelRight.BackColor = Color.Black;
      borderPanelRight.Cursor = Cursors.SizeWE;
      // ドッキングでは隅の境界コントロールにかぶるため、アンカーで対応
      borderPanelRight.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Right;
      // ロケーションも手動設定
      borderPanelRight.Location = new Point(textBox1.Size.Width - 9, 0);
      // 隅コントロール分サイズを開ける
      borderPanelRight.Size = new Size(5, textBox1.Size.Height - 9);
      borderPanelRight.MouseDown += new MouseEventHandler(borderPanel_Comm_MouseDown);
      borderPanelRight.MouseMove += new MouseEventHandler(borderPanelRight_MouseMove);

      borderPanelBottom = new Panel();
      textBox1.Controls.Add(borderPanelBottom);
      borderPanelBottom.BackColor = Color.Black;
      borderPanelBottom.Cursor = Cursors.SizeNS;
      borderPanelBottom.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left) | AnchorStyles.Right;
      borderPanelBottom.Location = new Point(0, textBox1.Size.Height - 9);
      borderPanelBottom.Size = new Size(textBox1.Size.Width - 9, 5);
      borderPanelBottom.MouseDown += new MouseEventHandler(borderPanel_Comm_MouseDown);
      borderPanelBottom.MouseMove += new MouseEventHandler(borderPanelBottom_MouseMove);

      // 隅の境界コントロール
      borderPanelRightBottom = new Panel();
      textBox1.Controls.Add(borderPanelRightBottom);
      borderPanelRightBottom.BackColor = Color.Red;
      borderPanelRightBottom.Cursor = Cursors.SizeNWSE;
      borderPanelRightBottom.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      borderPanelRightBottom.Location = new Point(textBox1.Size.Width - 9, textBox1.Size.Height - 10);
      borderPanelRightBottom.Size = new Size(5, 6);
      borderPanelRightBottom.MouseDown += new MouseEventHandler(borderPanel_Comm_MouseDown);
      borderPanelRightBottom.MouseMove += new MouseEventHandler(borderPanelRightBottom_MouseMove);
    }
    #endregion


    #region サイズ変更境界線パネル共通マウスダウンイベント
    private void borderPanel_Comm_MouseDown(object sender, MouseEventArgs e)
    {
      // 左クリックの場合
      if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
      {
        // 開始位置取得
        ctrlMousePoint = new Point(e.X, e.Y);
      }
    }
    #endregion


    #region サイズ変更境界線パネル上部マウスムーブイベント
    private void borderPanelTop_MouseMove(object sender, MouseEventArgs e)
    {
      // 左クリックの場合
      if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
      {
        // フォームのサイズを動かした分調整する
        Top += e.Y - ctrlMousePoint.Y;
        Height -= e.Y - ctrlMousePoint.Y;
      }
    }
    #endregion

    #region サイズ変更境界線パネル左部マウスムーブイベント
    private void borderPanelLeft_MouseMove(object sender, MouseEventArgs e)
    {
      // 左クリックの場合
      if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
      {
        // フォームのサイズを動かした分調整する
        Left += e.X - ctrlMousePoint.X;
        Width -= e.X - ctrlMousePoint.X;
      }
    }
    #endregion

    #region サイズ変更境界線パネル右部マウスムーブイベント
    private void borderPanelRight_MouseMove(object sender, MouseEventArgs e)
    {
      // 左クリックの場合
      if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
      {
        // フォームのサイズを動かした分調整する
        Width += e.X - ctrlMousePoint.X;
      }
    }
    #endregion

    #region サイズ変更境界線パネル下部マウスムーブイベント
    private void borderPanelBottom_MouseMove(object sender, MouseEventArgs e)
    {
      // 左クリックの場合
      if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
      {
        // フォームのサイズを動かした分調整する
        Height += e.Y - ctrlMousePoint.Y;
      }
    }
    #endregion

    #region サイズ変更境界線パネル右下部マウスムーブイベント
    private void borderPanelRightBottom_MouseMove(object sender, MouseEventArgs e)
    {
      // 左クリックの場合
      if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
      {
        // フォームのサイズを動かした分調整する
        Height += e.Y - ctrlMousePoint.Y;
        Width += e.X - ctrlMousePoint.X;
      }
    }
    #endregion


    #region 雛形メソッド
    private void template()
    {

    }
    #endregion
  }
}
