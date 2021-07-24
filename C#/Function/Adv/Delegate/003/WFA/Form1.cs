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

#region ヘッダ
/*
 * デリゲート
 *   ボタン押下イベント内でデリゲートに格納したインスタンスによって
 *   どのメソッドを実行するか分岐する
 *   →共通の計算メソッドに対して押下されたボタンに合う
 *     メソッドを格納したデリゲートを渡す
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

    // デリゲート宣言
    delegate int DlgtCalc(int x, int y);

    #endregion

    #region プロパティ

    // 左辺プロパティ
    private string _leftNum;
    public string leftNum
    {
      set
      {
        if (value.Length >= 1)
        {
          _leftNum = value;
        }
        else
        {
          MessageBox.Show("左辺の計算値に値がありません");
          throw new ArgumentOutOfRangeException("左辺の計算値に値がありません");
        }
      }
      get { return _leftNum; }
    }

    // 右辺プロパティ
    private string _rightNum;
    public string rightNum
    {
      set
      {
        if (value.Length >= 1)
        {
          _rightNum = value;
        }
        else
        {
          MessageBox.Show("右辺の計算値に値がありません");
          throw new ArgumentOutOfRangeException("右辺の計算値に値がありません");
        }
      }
      get { return _rightNum; }
    }

    #endregion


    #region +ボタン押下イベント
    private void btPlus_Click(object sender, EventArgs e)
    {
      // 足し算メソッドのインスタンス
      DlgtCalc calcDlgt = CalcSum;

      try
      {
        // プロパティに値をセット
        leftNum = tbLeftElem.Text;
        rightNum = tbRightElem.Text;
      }
      catch
      {
        return;
      }

      // 計算メソッド使用
      Calc(calcDlgt, int.Parse(leftNum), int.Parse(rightNum));
    }
    #endregion

    #region -ボタン押下イベント
    private void btMinus_Click(object sender, EventArgs e)
    {
      DlgtCalc calcDlgt = CalcSub;

      try
      {
        leftNum = tbLeftElem.Text;
        rightNum = tbRightElem.Text;
      }
      catch
      {
        return;
      }

      // 計算メソッド使用
      Calc(calcDlgt, int.Parse(leftNum), int.Parse(rightNum));
    }
    #endregion

    #region ×ボタン押下イベント
    private void btTimes_Click(object sender, EventArgs e)
    {
      DlgtCalc calcDlgt = CalcMulti;

      try
      {
        leftNum = tbLeftElem.Text;
        rightNum = tbRightElem.Text;
      }
      catch
      {
        return;
      }

      // 計算メソッド使用
      Calc(calcDlgt, int.Parse(leftNum), int.Parse(rightNum));
    }
    #endregion

    #region ÷ボタン押下イベント
    private void btDivided_Click(object sender, EventArgs e)
    {
      DlgtCalc calcDlgt = Calcdivide;

      try
      {
        leftNum = tbLeftElem.Text;
        rightNum = tbRightElem.Text;
      }
      catch
      {
        return;
      }

      // 計算メソッド使用
      Calc(calcDlgt, int.Parse(leftNum), int.Parse(rightNum));
    }
    #endregion


    #region 計算メソッド
    private void Calc(DlgtCalc calcDlgt, int x, int y)
    {
      // デリゲートに引数を入れて計算しテキストボックスに表示
      tbAnswer.Text = calcDlgt(x, y).ToString();
    }
    #endregion

    #region 足し算メソッド
    private int CalcSum(int x, int y)
    {
      return x + y;
    }
    #endregion

    #region  引き算メソッド
    private int CalcSub(int x, int y)
    {
      return x - y;
    }
    #endregion

    #region  掛け算メソッド
    private int CalcMulti(int x, int y)
    {
      return x * y;
    }
    #endregion

    #region 割り算メソッド
    private int Calcdivide(int x, int y)
    {
      return x / y;
    }
    #endregion
  }
}
