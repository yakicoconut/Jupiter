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
* 
* サイト
* 
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

    // マウスのクリック位置を記憶
    private Point ctrlMousePoint;

    #endregion


    #region フォームマウスダウンイベント
    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
      // 左クリックの場合
      if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
      {
        // 開始位置取得
        ctrlMousePoint = new Point(e.X, e.Y);
      }
    }
    #endregion

    #region フォームマウスムーブイベント
    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
      // 左クリックの場合
      if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
      {
        // フォームの位置を動かした先にする
        this.Left += e.X - ctrlMousePoint.X;
        this.Top += e.Y - ctrlMousePoint.Y;
      }
    }
    #endregion


    #region 雛形メソッド
    public void template()
    {

    }
    #endregion
  }
}
