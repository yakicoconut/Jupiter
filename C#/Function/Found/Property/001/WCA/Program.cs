using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#region ヘッダ
/*
 * プロパティ
 *   ・クラス外部から見るとメンバー変数のように振る舞い、
 *     クラス内部から見るとメソッドのように振舞うもの
 *   ・自動実装プロパティ
 *     C#3.0から機能として加わったプロパティの記述のしかた
 *   ・入力値の制御、チェックの目的に良く利用される
 *   ・メンバーフィールドをそのまま公開するのは非推奨
 *     プロパティを介してカプセル化する
 *     →ノーチェックで利用する場合にはフィールドではなく
 *     「自動実装プロパティ」を使うべき
 */
#endregion
namespace WCA
{
  /// <summary>
  /// メインプログラム
  /// </summary>
  class Program
  {
    #region 宣言

    // 共通ロジッククラスインスタンス
    static MCSComLogic _comLogic = new MCSComLogic();

    // ループフラグ
    private static bool loopFlag = true;

    #endregion

    #region プロパティ

    #region 通常実装プロパティ

    // バッキングフィールド
    private static string _propTest01;
    // プロパティ
    public static string PropTest01
    {
      get
      {
        // バッキングフィールドを返す
        return _propTest01;
      }
      set
      {
        // セットされた値をバッキングフィールドに設定
        _propTest01 = value;
      }
    }

    #endregion

    // 自動実装プロパティ
    public static string PropTest02 { get; set; }

    #region プロパティテスト1

    // バッキングフィールド
    private static int _propTest03;
    public static int PropTest03
    {
      get
      {
        return _propTest03;
      }
      set
      {
        // セットされた値をバッキングフィールドに設定
        _propTest03 = value;

        // 値が10より上の場合
        if (_propTest03 >= 10)
        {
          // ループフラグを折る
          loopFlag = false;
        }
      }
    }

    #endregion

    #region プロパティテスト2

    // バッキングフィールド
    private static int _propTest04;
    public static int PropTest04
    {
      get
      {
        return _propTest04;
      }
      set
      {
        // セットされた値をバッキングフィールドに設定
        _propTest04 = value;

        // 値が10より下の場合
        if (_propTest04 < 10)
        {
          // メッセージ表示
          Console.WriteLine(string.Format("入力された値は{0}です\r\n10以上の数値を入力してください!!!\r\n", _propTest04.ToString()));

          // 固定値を設定
          _propTest04 = -1;
        }
      }
    }

    #endregion

    #endregion


    #region メインメソッド
    static void Main(string[] args)
    {
      // 入力メソッド1使用
      Input1();
    }
    #endregion


    #region 入力メソッド1
    /// <summary>
    /// 入力メソッド1
    /// </summary>
    static void Input1()
    {
      while (loopFlag)
      {
        Console.WriteLine("10以上の数値を入力してください");

        // 数値をプロパティに設定
        PropTest03 = int.Parse(Console.ReadLine());

        // 10以上だった場合はメッセージを表示して終了
        Console.WriteLine(string.Format("入力された値は{0}です", PropTest03.ToString()));
        Console.ReadLine();
      }
    }
    #endregion


    #region 入力メソッド2
    /// <summary>
    /// 入力メソッド2
    /// </summary>
    static void Input2()
    {
      Console.WriteLine("10以上の数値を入力してください");

      // 数値をプロパティに設定
      PropTest04 = int.Parse(Console.ReadLine());

      // ねずみ返し_値が固定値の場合
      if (PropTest04 == -1)
      {
        // 再帰的に本メソッドを呼び出し
        Input2();
        return;
      }

      // 10以上だった場合はメッセージを表示して終了
      Console.WriteLine(string.Format("入力された値は{0}です", PropTest04.ToString()));
      Console.ReadLine();
    }
    #endregion
  }
}
