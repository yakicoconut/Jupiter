//#define BREAKPOINT
#define LINQ
//#define DELEGATE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#region ヘッダ
/* 
 * ラムダ
 * サイト
 *   LINQで書くとデバッグしづらいよね？そんなことないよ - かずきのBlog@hatena
 *    http://blog.okazuki.jp/entry/2017/07/23/165809
 *   [C# LINQ] Whereの使い方から注意点まで
 *    https://clickan.click/csharp-linq-where/
 *   LINQ：重複のないデータを取得する - Distinctメソッド［C#］ - Build Insider
 *    http://www.buildinsider.net/web/bookaspmvc5/050305
 */
#endregion
namespace WCA
{
  class Program
  {
    static void Main(string[] args)
    {
      #region BREAKPOINT
#if BREAKPOINT
      /* ラムダ式のブレークポイント */

      // ラムダ式の最もシンプルな使用方法はLINQ式
      int[] numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

      /*
       * ラムダ式内にブレークポイントを張るには該当箇所にカーソルを配置する必要がある
       * 以下の場合、通常のブレークポイントの挿入では「;」までの文を対象としてしまうが
       * ラムダ式の内容「x > 5 || x % 2 == 0」に対するブレークポイントの挿入はカーソルを
       * 式内に配置し右クリックからブレークポイントの挿入を行う
       */
      var extraction = numbers.Where(x => x > 5 &&
        x % 2 == 0);


      /*
       * デバッグ時、実際にブレイクされるのはLINQ式の結果(IEnumerable変数)を使用したとき
       * →以下のintをインクリメントする処理のブレークが先に行われ
       *   foreachに入ったときに上記のラムダ式がブレイクされる
       */
      int test01 = 0;
      test01 += 1;
      test01 += 1;
      test01 += 1;
      test01 += 1;

      /*
       * 以下でLINQ式の結果をループする
       * 1~5はWhereで一つずつ評価されはじかれる
       * 6から実際にextraction変数に格納されループ処理でyに渡る
       */
      foreach (var y in extraction)
      {
        Console.WriteLine(y);
      }
#endif
      #endregion


      #region if LINQ
#if LINQ
      {
        // LINQメソッド構文メソッド使用
        LinqMethodSyntax();
      }
#endif
      #endregion


      #region if DELEGATE
#if DELEGATE
      {
        // デリゲート通常使用メソッド使用
        ExecDelegate();

        // デリゲートラムダ式使用メソッド使用
        ExecLamda();
      }
#endif
      #endregion


      Console.ReadKey();
    }


    #region LINQのメソッド構文メソッド
    /// <summary>
    /// LINQメソッド構文メソッド
    /// </summary>
    static void LinqMethodSyntax()
    {
      // 数値配列作成
      var numbers = new[] { 1, 2, 2, 3, 3, 3, 4, 4, 4 };

      // 【LINQ】1.数値配列のWhereを使って偶数の値のみにフィルタリングする
      var values = numbers.Where(x => x % 2 == 0)
          // 【LINQ】2.重複したデータを除去
          .Distinct()
          // 【LINQ】3.渡って来た値を二乗する
          .Select(x => x * x);

      // 表示
      foreach (var value in values)
      {
        Console.WriteLine(value);
      }
    }
    #endregion


    #region デリゲート

    // 共通デリゲート宣言
    delegate int deleTestA(int arg_Dele1, int arg_Dele2);
    delegate void deleTestB(int arg_Dele);
    delegate void deleTestC();

    #region デリゲート通常使用メソッド

    /// <summary>
    /// デリゲート通常使用メソッド
    /// </summary>
    static void ExecDelegate()
    {
      //デリゲート対象メソッド01をデリゲートに代入
      deleTestA del01 = new deleTestA(test01);

      //デリーゲート使用
      del01(100, 101);
    }

    //デリゲート対象メソッド01
    static int test01(int arg1, int arg2)
    {
      Console.WriteLine("デリゲート通常使用:" + arg1.ToString());

      return 0;
    }

    #endregion

    #region デリゲートラムダ式使用メソッド

    /// <summary>
    /// デリゲートラムダ式使用メソッド
    /// </summary>
    static void ExecLamda()
    {
      //ラムダ式をデリゲートに代入
      //返り値ありで引数を複数取るラムダ式
      deleTestA del02 = (x, y) => x * 1;
      //デリーゲート使用
      int j = del02(200, 201);
      Console.WriteLine("デリゲートラムダ式使用1:" + j.ToString());


      //返り値ありで引数を複数取るラムダ式
      deleTestA del03 = (x, y) =>
      {
        x = x * 1;
        return x;
      };
      //デリーゲート使用
      int k = del03(300, 301);
      Console.WriteLine("デリゲートラムダ式使用2:" + k.ToString());


      //返り値なしで引数を一つ取るラムダ式
      deleTestB del04 = x => Console.WriteLine("デリゲートラムダ式使用3:" + x.ToString());
      //デリーゲート使用
      del04(400);


      //返り値なしで引数を一つ取るラムダ式
      deleTestB del05 = x =>
      {
        x = x * 1;
        Console.WriteLine("デリゲートラムダ式使用4:" + x.ToString());
      };
      //デリーゲート使用
      del05(500);


      //返り値なしで引数を取らないラムダ式
      deleTestC del06 = () => Console.WriteLine("デリゲートラムダ式使用5:引数なし");
      //デリーゲート使用
      del06();
    }

    #endregion

    #endregion
  }
}
