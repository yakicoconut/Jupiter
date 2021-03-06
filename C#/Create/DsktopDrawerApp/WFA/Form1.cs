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
using System.Drawing.Imaging;

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
      // 起動時ウィンドウサイズ
      launchSize = _comLogic.GetConfigValue("LaunchSize", "Max");
    }
    #endregion


    #region 宣言

    // 共通ロジッククラスインスタンス
    MCSComLogic _comLogic = new MCSComLogic();

    // 起動時ウィンドウサイズ
    string launchSize;

    #endregion


    #region フォームロードイベント
    private void Form1_Load(object sender, EventArgs e)
    {
      // フォーム透明化
      // 透明色は無難なものを使用(ColorクラスのTransparentやWhiteは予期しない動きになる)
      SetStyle(ControlStyles.SupportsTransparentBackColor, true);
      this.BackColor = Color.Green;
      // 透明を指定する
      this.TransparencyKey = Color.Green;

      // タスクバーにアイコンを表示しない
      this.ShowInTaskbar = false;

      // タスクバーを覆って表示
      this.WindowState = FormWindowState.Normal;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      // タスクバー表示
      this.Bounds = new Rectangle(0, 0, SystemInformation.PrimaryMonitorSize.Width, SystemInformation.WorkingArea.Height);

      // イベントハンドラフォーム設定メソッド使用
      SettingChildForm();

      // 起動時ウィンドウサイズが最小化設定の場合
      if (launchSize == "Min")
      {
        // 退避用ビットマップ生成
        Bitmap evacuationBmp = new Bitmap(this.Width, this.Height);

        // 描画済線退避
        evacuationBmp.Save(@"DsktopDrawerEvacuation.png", ImageFormat.Png);

        // 最小化
        this.WindowState = FormWindowState.Minimized;
      }
    }
    #endregion

    #region 常駐アイコンダブルクリックイベント
    private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      // ねずみ返し_既に通常状態の場合
      if (this.WindowState == FormWindowState.Normal)
      {
        return;
      }

      // フォーム表示
      this.Show();

      // 最小化から復帰
      this.WindowState = FormWindowState.Normal;

      // 退避した画像の復元
      this.BackgroundImage = Image.FromFile(@"DsktopDrawerEvacuation.png");
    }
    #endregion


    #region イベントハンドラフォーム設定メソッド
    public void SettingChildForm()
    {
      // イベントハンドラフォームインスタンス生成
      Form2 f2 = new Form2(this);

      // タスクバーに表示させない
      f2.ShowInTaskbar = false;
      // コントロールボックスを表示しない
      f2.ControlBox = false;
      // 枠線なし
      f2.FormBorderStyle = FormBorderStyle.None;
      // Form2のサイズはForm1のクライアント領域のサイズ
      f2.Size = this.ClientSize;
      // Form2の初期位置はLocationで指定
      f2.StartPosition = FormStartPosition.Manual;
      // Form2の位置をForm1のクライアント領域にセット
      f2.Location = this.PointToScreen(this.ClientRectangle.Location);

      // イベントハンドラフォームをオーナーにする
      this.AddOwnedForm(f2);

      // 透明化
      f2.Opacity = 0.05;

      /* 連動イベント */
      // Closeに追従
      this.FormClosing += delegate { f2.Close(); };
      // Moveに追従
      this.Move += delegate { f2.Location = this.PointToScreen(this.ClientRectangle.Location); };
      // リサイズに追従
      this.Resize += delegate { f2.Size = this.Size; };

      // 表示
      f2.Show();
    }
    #endregion


    #region 雛形メソッド
    public void template()
    {

    }
    #endregion
  }
}