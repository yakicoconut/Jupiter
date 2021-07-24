#define QUERY
//#define METHOD
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#region ヘッダ
/*
 * LINQ
 * 
 */ 
#endregion
namespace WCA
{
  class Program
  {
    static void Main(string[] args)
    {
      #region QUERY
#if QUERY
      QuerySyntax();
#endif     
      #endregion


      #region METHOD
#if METHOD
      MethodSyntax();
#endif
      #endregion


      Console.ReadKey();
    }

    #region クエリ構文メソッド
    /// <summary>
    /// クエリ構文メソッド
    /// </summary>
    static void QuerySyntax()
    {
      var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

      IEnumerable<int> highScoresQuery =
          from score in numbers
          where score > 6
          orderby score descending
          select score;

      foreach (var x in highScoresQuery)
      {
        Console.WriteLine(x);
      }
    }
    #endregion


    #region メソッド構文メソッド
    /// <summary>
    /// メソッド構文メソッド
    /// </summary>
    static void MethodSyntax()
    {
      /*
       * ラムダ式内にブレークポイントを張るには該当箇所にカーソルを配置する必要がある
       * 以下の場合、通常のブレークポイントの挿入では「;」までの文を対象としてしまうが
       * ラムダ式の内容「x > 5 || x % 2 == 0」に対するブレークポイントの挿入はカーソルを
       * 式内に配置し右クリックからブレークポイントの挿入を行う
       */

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
  }
}
