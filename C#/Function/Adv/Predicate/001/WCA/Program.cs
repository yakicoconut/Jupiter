using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Drawing;

#region ヘッダ
/*
 * プレディケート
 * 
 * 準備
 *   System.Drawingを参照設定に追加
 * サイト
 *   Predicate<T> 代理人 (System) | Microsoft Docs
 *   	https://docs.microsoft.com/ja-jp/dotnet/api/system.predicate-1?view=net-5.0
 * 
 */
#endregion
namespace WCA
{
  class WCA
  {
    static void Main(string[] args)
    {
      // メソッドパターン
      ExecMeth();

      // ラムダ式パターン
      ExecLamda();

      Console.ReadKey();
    }


    #region メソッドパターン

    /// <summary>
    /// メソッドパターン実行メソッド
    /// </summary>
    public static void ExecMeth()
    {
      // 対象数値配列
      int[] nums = { 1, 2, 3, 4, 5 };

      // プレディケイトデリゲートに数値条件メソッドを代入
      // 返り値はbool型
      Predicate<int> predicate = FindNum;
      //// エラーパターン
      //Predicate<int> predicate = FindNum2;
      //Predicate<int> predicate = FindNum3;

      // 配列から条件にあった要素の最初のものを返す
      int foundFirst = Array.Find(nums, predicate);

      // 表示
      Console.WriteLine("Found:{0}", foundFirst.ToString());
    }

    // 数値条件メソッド
    private static bool FindNum(int num)
    {
      bool ret = false;

      if (num < 5)
      {
        return true;
      }

      return ret;
    }

    // エラーメソッド
    private static void FindNum2(int num)
    {
      // 返り値があっていないためエラー
    }

    // エラーメソッド
    private static bool FindNum3()
    {
      // 引数があっていないためエラー
      return true;
    }

    #endregion


    #region ラムダ式パターン

    static void ExecLamda()
    {
      // 対象数値配列
      int[] array = new int[] { 1, 5, 3, 8 };
      // プレディケイトデリゲート変数宣言
      Predicate<int> prediInt;
      // デリゲート変数にラムダ式代入
      prediInt = x => x < 5;

      // 条件付合計メソッド使用
      int sum = Sum(array, prediInt);

      // 表示
      Console.WriteLine(sum.ToString());
    }

    /// <summary>
    /// 条件付合計メソッド
    /// </summary>
    /// <param name="a">対象数値配列</param>
    /// <param name="pred">合計条件</param>
    /// <returns></returns>
    static int Sum(int[] a, Predicate<int> pred)
    {
      int sum = 0;

      foreach (int x in a)
      {
        // プレディケイトデリゲート変数に対象数値を渡し
        // 条件に合致するものだけ合計する
        if (pred(x))
        {
          sum += x;
        }
      }

      return sum;
    }

    #endregion
  }
}
