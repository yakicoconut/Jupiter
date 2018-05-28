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

    // 計算モードフラグ
    string calcMode = string.Empty;
    // 計算元データ
    string calcSource = string.Empty;
    // 一桁目フラグ
    bool isDigit = false;

    #endregion


    #region フォームロードイベント
    private void Form1_Load(object sender, EventArgs e)
    {
      // テキストボックス設定
      // 右寄せ
      tbEntry.TextAlign = HorizontalAlignment.Right;
      // 初期値
      tbEntry.Text = "0";
      // 入力不可
      tbEntry.Enabled = false;
    }
    #endregion

    #region ←ボタン押下イベント
    private void btLeft_Click(object sender, EventArgs e)
    {
      // テキストボックスの内容取得
      string entry = tbEntry.Text;

      // テキストボックスの内容が二桁以上の場合
      if (entry.Length >= 2)
      {
        // 末尾一文字削除
        entry = entry.Remove(entry.Length - 1, 1);
      }
      else
      {
        // 一桁の場合は「0」にする
        entry = "0";
      }

      // テキストボックス更新
      tbEntry.Text = entry;
    }
    #endregion

    #region CEボタン押下イベント
    private void btCancelEntry_Click(object sender, EventArgs e)
    {

    }
    #endregion

    #region Cボタン押下イベント
    private void btCancel_Click(object sender, EventArgs e)
    {
      // テキストボックスの内容を初期化
      tbEntry.Text = "0";

      // フラグ初期化
      calcSource = string.Empty;
      isDigit = false;
    }
    #endregion

    #region /ボタン押下イベント
    private void btDivision_Click(object sender, EventArgs e)
    {
      calcMode = "Division";
      isDigit = true;
    }
    #endregion

    #region *ボタン押下イベント
    private void btTimes_Click(object sender, EventArgs e)
    {
      calcMode = "Minus";
      isDigit = true;
    }
    #endregion

    #region -ボタン押下イベント
    private void btMinus_Click(object sender, EventArgs e)
    {
      calcMode = "Minus";
      isDigit = true;
    }
    #endregion

    #region +ボタン押下イベント
    private void btPlus_Click(object sender, EventArgs e)
    {
      calcMode = "Plus";
      isDigit = true;
    }
    #endregion

    #region =ボタン押下イベント
    private void btEqual_Click(object sender, EventArgs e)
    {
      // 計算処理メソッド使用
      CalcProcess();
    }
    #endregion

    
    #region 共通数値ボタン押下イベント
    private void com_NumberButton_Click(object sender, EventArgs e)
    {
      // 何かしらの計算モードかつ一桁目フラグが可の場合
      if (calcMode != string.Empty && isDigit)
      {
        // テキストボックスの内容を退避
        calcSource = tbEntry.Text;

        // テキストボックス内容クリア
        tbEntry.ResetText();

        // 最初の一回だけ
        isDigit = false;
      }

      // 押下ボタン名取得
      Control ctrl = (Control)sender;
      string ctrlName = ctrl.Name;
      ctrlName = ctrlName.Substring(2, ctrlName.Length - 2);


      #region 押下ボタン名で分岐
      string entry = string.Empty;
      switch (ctrlName)
      {
        case "One":
          entry = "1";
          break;

        case "Two":
          entry = "2";
          break;

        case "Three":
          entry = "3";
          break;

        case "Four":
          entry = "4";
          break;

        case "Five":
          entry = "5";
          break;

        case "Six":
          entry = "6";
          break;

        case "Seven":
          entry = "7";
          break;

        case "Eight":
          entry = "8";
          break;

        case "Nine":
          entry = "9";
          break;

        case "Zero":
          entry = "0";
          break;

        default:
          break;
      }
      #endregion


      // テキストボックスの内容が「0」のみの場合
      if (tbEntry.Text == "0")
      {
        // テキストボックス内容クリア
        tbEntry.ResetText();
      }

      // テキストボックスに追加
      tbEntry.AppendText(entry);
    }
    #endregion


    #region 計算処理メソッド
    public void CalcProcess()
    {
      // 計算モードで分岐
      int answer = 0;
      switch (calcMode)
      {
        case "Division":
          answer = int.Parse(calcSource) / int.Parse(tbEntry.Text);
          break;

        case "Times":
          answer = int.Parse(calcSource) * int.Parse(tbEntry.Text);
          break;

        case "Minus":
          answer = int.Parse(calcSource) - int.Parse(tbEntry.Text);
          break;

        case "Plus":
          answer = int.Parse(calcSource) + int.Parse(tbEntry.Text);
          break;

        default:
          break;
      }

      // 
      calcSource = answer.ToString();
      // テキストボックス内容クリア
      tbEntry.ResetText();
      // 答えを表示
      tbEntry.Text = calcSource;
    }
    #endregion


    #region 雛形メソッド
    public void template()
    {

    }
    #endregion
  }
}
