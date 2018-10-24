#define TEST003
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FastTxtDiff
{
  #region ★山内:テスト用フォーム
  /// <summary>
  /// ★山内:テスト用フォーム
  /// </summary>
  public partial class TestForm1 : Form
  {
    #region デフォルトコンストラクタ
    public TestForm1()
    {
      InitializeComponent();
    }
    #endregion


    #region ボタン1押下イベント
    private void button1_Click(object sender, EventArgs e)
    {
      #region テストデータ

      //      string textA = @"abc
      //defg
      //h
      //ij
      //";
      string textA = @"abc";
      string textB = @"acb";
      //string textA = @"綾金大学大学院";
      //string textB = @"大学院理工学研究科情報専攻";
      DiffOption option = new DiffOption();

      #endregion


      #region テスト001_SplitCharメソッド
#if TEST001

      // 文字コード数値変換静的メソッドテスト
      FastDiff.Test.TestSplitChar(textA, option);

#endif
      #endregion

      #region テスト002_SplitLineメソッド
#if TEST002

      // 行単位分離静的メソッドテスト
      FastDiff.Test.TestSplitLine(textA, option);

#endif
      #endregion

      #region テスト003_DiffCharメソッド
#if TEST003

      textBox1.AppendText("0123456789112345678921234567893123456789\r\n");
      textBox1.AppendText(textA.ToString() + "\r\n");
      textBox1.AppendText(textB.ToString() + "\r\n");
      textBox1.AppendText("-----------------------------\r\n");

      // 文字比較メソッドテスト
      DiffResult[] result = FastDiff.DiffChar(textA, textB);
      foreach (DiffResult x in result)
      {
        textBox1.AppendText(x.ToString() + "\r\n");
      }

#endif
      #endregion
    }
    #endregion
  }
  #endregion


  #region ★山内:メインプログラムクラス
  /// <summary>
  /// ★山内:メインプログラムクラス
  /// </summary>
  /// <!-- 注:フォームの前に記述するとデザイナーが使用できない -->
  static class Program
  {
    /// <summary>
    /// アプリケーションのメイン エントリ ポイントです。
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new TestForm1());
    }
  }
  #endregion
}
