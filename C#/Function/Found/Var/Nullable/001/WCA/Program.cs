#define TR04
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#region ヘッダ
/*
 * ・Nullを許容しない型は宣言時に型の後に「?」を着けることNull許容型となる
 * ・Null許容型はSystem.Nullable<T>構造体のインスタンス
 *   プロパティ
 *     ・bool HasValue
 *       値の有無を返す
 *     ・Type Value
 *       格納されている値を返す
 * ・bool?型の変数は直接bool型としては使用できない
 *   方法: bool? から bool に安全にキャストする (C# プログラミング ガイド) | Microsoft Docs
 *   	https://docs.microsoft.com/ja-jp/dotnet/csharp/programming-guide/nullable-types/how-to-safely-cast-from-bool-to-bool
 *   →int?等の型の場合は直接値を使用できる
 *   ⇒安全(値がnullでもエラーにならないよう)なif文
 *     「if(変数.HasValue && 変数.Value)」
 *     →HasValueメソッドを先に評価するので値がnullの時点で次の条件は評価しないためエラーにならない
 */
#endregion
namespace WCA
{
  class Program
  {
    static void Main(string[] args)
    {
      #region TR01_bool型
#if TR01
      // bool型
      Pattern01();
#endif
      #endregion

      #region TR02_int型
#if TR02
      // int型
      Pattern02();
#endif
      #endregion

      #region TR03_他クラス
#if TR03
      // 他クラス
      Pattern03();
#endif
      #endregion

      #region TR04_IF
#if TR04
      // IF
      Pattern04();
#endif
      #endregion

      Console.ReadKey();
    }

    #region パターン01_bool型
    /// <summary>
    /// bool型
    /// </summary>
    static void Pattern01()
    {
      // 宣言
      bool? var01 = true;
      bool? var02 = null;

      // 値をいきなり使う(.valueを使用せずに)
      // ★boolの場合値をいきなり使うことはできない(ビルドエラー)
      //if (var01)
      //{
      //  Console.WriteLine("TRUE");
      //}
      //else
      //{
      //  Console.WriteLine("FALSE");
      //}

      // →

      // bool?型をbool型として使用するには以下の方法が推奨されている
      if (var01.HasValue)
      {
        if ((bool)var01)
        {
          Console.WriteLine("TRUE");
        }
        else
        {
          Console.WriteLine("FALSE");
        }
      }

      // 単純な値の使用
      Console.WriteLine(var01.ToString());

      // 値があるか
      Console.WriteLine(var01.HasValue.ToString());

      // 明示的な値の取り出し
      try
      {
        Console.WriteLine(var01.Value.ToString());
      }
      catch (Exception e)
      {
        Console.WriteLine("値がnullの変数から.Valueで値を取り出そうとするとエラー");
      }


      Console.WriteLine("-----------------------------");

      // 単純な値の使用1
      // nullのため表示されない
      Console.WriteLine(var02.ToString());
      Console.WriteLine(var02.HasValue.ToString());

      // 値がない(nullの)場合、明示的な値の取り出しはできない(エラーとなる)
      try
      {
        Console.WriteLine(var02.Value.ToString());
      }
      catch (Exception e)
      {
        Console.WriteLine("値がnullの変数から.Valueで値を取り出そうとするとエラー");
      }

      // 値をいきなり使う(.valueを使用せずに)
      // ★boolの場合値をいきなり使うことはできない(ビルドエラー)
      //if (var02)
      //{
      //  Console.WriteLine("TRUE");
      //}
      //else
      //{
      //  Console.WriteLine("FALSE");
      //}

      // →

      // bool?型をbool型として使用するには以下の方法が推奨されている
      if (!var02.HasValue)
      {
        var02 = true;
      }
      if ((bool)var02)
      {
        Console.WriteLine("TRUE");
      }
      else
      {
        Console.WriteLine("FALSE");
      }
    }
    #endregion

    #region パターン02_int型
    /// <summary>
    /// int型
    /// </summary>
    static void Pattern02()
    {
      // 宣言
      int? var01 = 1;
      int? var02 = null;

      // 値をいきなり使う(.valueを使用せずに)
      if (var01 > 0)
      {
        Console.WriteLine("1以上");
      }
      else
      {
        Console.WriteLine("0以下");
      }

      // 単純な値の使用
      Console.WriteLine(var01.ToString());

      // 値があるか
      Console.WriteLine(var01.HasValue.ToString());

      // 明示的な値の取り出し
      try
      {
        Console.WriteLine(var01.Value.ToString());
      }
      catch (Exception e)
      {
        Console.WriteLine("値がnullの変数から.Valueで値を取り出そうとするとエラー");
      }


      Console.WriteLine("-----------------------------");


      // 値をいきなり使う(.valueを使用せずに)
      if (var02 > 0)
      {
        Console.WriteLine("1以上");
      }
      else if (var02 == 0)
      {
        Console.WriteLine("ちょうど0");
      }
      else if (var02 == null)
      {
        Console.WriteLine("値無し");
      }

      // 単純な値の使用1
      // nullのため表示されない
      Console.WriteLine(var02.ToString());
      Console.WriteLine(var02.HasValue.ToString());

      // 明示的な値の取り出しはできない(エラーとなる)
      try
      {
        Console.WriteLine(var02.Value.ToString());
      }
      catch (Exception e)
      {
        Console.WriteLine("値がnullの変数から.Valueで値を取り出そうとするとエラー");
      }
    }
    #endregion

    #region パターン03_他クラス
    /// <summary>
    /// 他クラス
    /// </summary>
    static void Pattern03()
    {
      NullableData nd = new NullableData();

      Console.WriteLine(nd.var01.ToString());
      Console.WriteLine(nd.var01.HasValue.ToString());
      try
      {
        Console.WriteLine(nd.var01.Value.ToString());
      }
      catch (Exception e)
      {
        Console.WriteLine("値がnullの変数から.Valueで値を取り出そうとするとエラー");
      }
    }
    #endregion

    #region パターン04_IF
    /// <summary>
    /// IF
    /// </summary>
    static void Pattern04()
    {
      // 宣言
      bool? var01 = null;

      // if文の条件で値取り出し(Value)メソッドが先に来るパターン
      try
      {
        if (var01.Value && var01.HasValue)
        {
          Console.WriteLine("Valueが先のif文");
        }
      }
      catch
      {
        Console.WriteLine("Valueが先のif文はエラー");
      }

      // if文の条件で値有無(HasValue)メソッドが先に来るパターン
      if (var01.HasValue && var01.Value)
      {
        // 値がないのでHasValueメソッドだけ評価されるため
        // 後のValueメソッドには到達しない、そのためエラーとならない
        Console.WriteLine("HasValueが先のif文");
      }
      else if (!var01.HasValue)
      {
        Console.WriteLine("null");
      }
    }
    #endregion
  }


  #region 対象他クラス
  class NullableData
  {
    /// <summary>
    /// 
    /// </summary>
    public int? var01;

    /// <summary>
    /// 
    /// </summary>
    public int? var02;
  }
  #endregion
}
