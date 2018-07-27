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

    // 線描画フラグ
    bool mouseDrug = false;

    // 描画開始座標
    int prevX;
    int prevY;

    #endregion


    #region フォームロードイベント
    private void Form1_Load(object sender, EventArgs e)
    {
      // タスクバーを覆って表示
      this.WindowState = FormWindowState.Normal;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      // タスクバー表示
      this.Bounds = new Rectangle(0, 0, SystemInformation.PrimaryMonitorSize.Width, SystemInformation.WorkingArea.Height);

      // デフォルト不透明度
      this.Opacity = 0.6;
      
      //// 背景透明設定
      //SetStyle(ControlStyles.SupportsTransparentBackColor, true);
      //this.BackColor = Color.Transparent;
    }
    #endregion

    #region フォームマウスダウンイベント
    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
      // 描画開始
      mouseDrug = true;
      prevX = e.Location.X;
      prevY = e.Location.Y;
    }
    #endregion

    #region フォームマウスアップイベント
    private void Form1_MouseUp(object sender, MouseEventArgs e)
    {
      // 描画終了
      mouseDrug = false;
    }
    #endregion

    #region フォームマウスムーブイベント
    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
      // ねずみ返し_描画フラグが立っていない場合
      if (!mouseDrug)
      {
        return;
      }

      // ペンオブジェクト生成
      using (Pen objPen = new Pen(Color.Black, 1))
      {
        // グラフィックスオブジェクト生成
        using (Graphics objGrp = this.CreateGraphics())
        {
          // 線描画
          objGrp.DrawLine(objPen, prevX, prevY, e.Location.X, e.Location.Y);
          // 描画(マウスドラッグ)後の座標を開始座標に設定
          prevX = e.Location.X;
          prevY = e.Location.Y;
        }
      }
    }
    #endregion


    #region コンテキスト_不透明度押下イベント
    private void toolStripMenuItemOpacity_Click(object sender, EventArgs e)
    {
      // デフォルトに戻す
      this.Opacity = 0.8;
    }
    #endregion

    #region コンテキスト_上げ押下イベント
    private void toolStripMenuItemOpacityGain_Click(object sender, EventArgs e)
    {
      // 不透明度が0.8以上なら
      if (this.Opacity >= 0.8)
      {
        // ※Graphicsで黒塗りつぶしをしていると
        //   不透明度を100%から下げたあとにとなぜか色が元に戻ってしまうため最大99%とする
        this.Opacity = 0.99;
        return;
      }

      // 不透明度を上げる
      this.Opacity += 0.2;
    }
    #endregion

    #region コンテキスト_下げ押下イベント
    private void toolStripMenuItemOpacityDec_Click(object sender, EventArgs e)
    {
      // 不透明度を下げる
      this.Opacity -= 0.2;

      // 不透明度が0.1以下なら
      if (this.Opacity <= 0.1)
      {
        // 不透明度を0%にするとフォームが非表示扱いとなってしまうため
        this.Opacity = 0.01;
      }
    }
    #endregion

    #region コンテキスト_透明押下イベント
    private void ToolStripMenuItemOpacityTransparent_Click(object sender, EventArgs e)
    {
      // 不透明度を0%にするとフォームが非表示扱いとなってしまうため
      this.Opacity = 0.01;
    }
    #endregion

    #region コンテキスト_タスクバー押下イベント
    private void ToolStripMenuItemTaskBar_Click(object sender, EventArgs e)
    {
      // タスクバー非表示の場合
      if (this.Bounds.Height == SystemInformation.WorkingArea.Height)
      {
        // タスクバー非表示
        this.Bounds = Screen.PrimaryScreen.Bounds;
      }
      else
      {
        // タスクバー表示
        this.Bounds = new Rectangle(0, 0, SystemInformation.PrimaryMonitorSize.Width, SystemInformation.WorkingArea.Height);
      }
    }
    #endregion

    #region コンテキスト_閉じる押下イベント
    private void toolStripMenuItemClose_Click(object sender, EventArgs e)
    {
      // フォーム閉じる
      this.Close();
    }
    #endregion


    #region 雛形メソッド
    public void template()
    {

    }
    #endregion
  }
}