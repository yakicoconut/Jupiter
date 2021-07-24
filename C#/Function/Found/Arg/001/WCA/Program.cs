#define PATTERN01
#define PATTERN02
#define PATTERN03
#define PATTERN04
//#define ERROR
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#region ヘッダ
/*
 * 引数001
 *   フィールド変数
 *     クラス内に宣言する変数は
 *     クラス内であれば呼び出しメソッド内外で値が引き継がれる
 *   値渡し
 *     修飾子をつけないメソッド引数は
 *     値のみをメソッドに渡すためメソッド内で使い捨てられる(呼び出し元の変数には影響しない)
 *   参照渡し
 *     引数に指定した変数のメモリアドレスをメソッドに渡す引数のこと
 *     メソッド内で使用する引数に値が入ると割り当てられているメモリアドレスに
 *     対して値を設定するためメソッドが終了しても値が元の変数に引き継がれる
 *     ref引数
 *       呼び出しメソッド内で設定された値を引き継ぐ
 *       渡すメモリアドレスを確定しければならないため
 *       変数の初期化が必須
 *     out引数
 *       引数を戻り値として使用することにref引数よりも特化した参照渡し
 *       変数の初期化は必要なく、メソッド内で値を入れないとエラーとなる
 *       →ref引数の初期化が必須な点と戻り値として使用しているのに値を入れなくても良い点
 *         を改善した
 *         ※但し、参照対象変数の宣言は必須(省略できるのはあくまで初期化のみ)
 *           ⇒C#7からは出力変数宣言として変数の宣言も必要なくなった
 *       ⇒C#7からタプル型で戻り値を複数指定可能となった
 *   参照型
 *     参照型パラメーターの引き渡し (C# プログラミング ガイド) | Microsoft Docs
 *     	https://docs.microsoft.com/ja-jp/dotnet/csharp/programming-guide/classes-and-structs/passing-reference-type-parameters
 *   VS2010で使用できない?もの
 *     参照渡し_in引数
 *       C#4.0の「オプション引数」機能で追加?
 *     デフォルト引数
 *       変数の初期化を引数として指定可能
 *       C#4.0の「オプション引数」機能で追加?
 *       C++等で実装されている機能
 *       Visual Studioインストール時の版によって使用できない?
 *         C# デフォルト引数について | プログラミングテクニック集キヤミー
 *         	http://cammy.co.jp/technical/2017/07/11/c-%E3%83%87%E3%83%95%E3%82%A9%E3%83%AB%E3%83%88%E5%BC%95%E6%95%B0%E3%81%AB%E3%81%A4%E3%81%84%E3%81%A6/
 */ 
#endregion
namespace WCA
{
  class Program
  {
    #region 宣言

    // フィールド変数
    static int fieldVar;

    #endregion


    static void Main(string[] args)
    {
      #region パターン01_フィールド
#if PATTERN01
      /*
       * メソッド内でフィールドに設定した値は
       * メソッド終了後も持続される
       */

      // メソッドに渡す前に値を入れる
      fieldVar = 1;
      Console.WriteLine(string.Format("フィールド前:{0}", fieldVar));

      // フィールド用メソッド使用
      FieldMeth();
      Console.WriteLine(string.Format("フィールド後:{0}", fieldVar));

#endif
      #endregion


      #region パターン02_値渡し
#if PATTERN02
      /*
       * デフォルト(修飾子をつけない)の引数は
       * 値渡しとなるため引数のスコープはメソッド内でのみ
       */

      // メソッドに渡す前に値を入れる
      int passByValArg = 1;
      Console.WriteLine(string.Format("値渡し前:{0}", passByValArg));

      // フィールド用メソッド使用
      RefByValMeth(passByValArg);
      Console.WriteLine(string.Format("値渡し後:{0}", passByValArg));

#endif
      #endregion


      #region パターン03_参照渡し
#if PATTERN03
      /*
       * ref引数
       *   メソッド内で設定した値がメソッド終了後も
       *   渡した変数に引き継がれる
       *   渡す変数は初期化必須
       */
      // 参照渡し_ref
      int refArg = 1;
      Console.WriteLine(string.Format("ref前:{0}", refArg));
      // 参照渡し_refメソッド使用
      RefMeth(ref refArg);
      Console.WriteLine(string.Format("ref後:{0}", refArg));


      /*
       * out引数
       *   メソッド内で設定した値がメソッド終了後も
       *   渡した変数に引き継がれる
       *   渡す変数は初期化が必要ない
       *   メソッド内で引数に値が入らないとエラーで知らせてくれる
       */
      // 参照渡し_out
      int outArg1 = 1;
      Console.WriteLine(string.Format("out1前:{0}", outArg1));
      // 参照渡し_outメソッド使用
      OutMeth(out outArg1);
      Console.WriteLine(string.Format("out1後:{0}", outArg1));

      int outArg2;
      Console.WriteLine(string.Format("out2前:{0}", "未割り当て"));
      OutMeth(out outArg2);
      Console.WriteLine(string.Format("out2後:{0}", outArg2));

#endif
      #endregion


      #region パターン04_参照型
#if PATTERN04
      /*
       * 参照型は常に参照私になる?
       * →未解決
       */

      // メソッドに渡す前に値を入れる
      string refType = "A";
      Console.WriteLine(string.Format("参照型前:{0}", refType));

      // フィールド用メソッド使用
      ValMeth(refType);
      Console.WriteLine(string.Format("参照型後:{0}", refType));

#endif
      #endregion


      #region エラーパターン
#if ERROR
      /*
       * ref引数で変数を初期化しない
       */
      int refArg2;
      RefMeth(ref refArg2);

#endif
      #endregion


      Console.ReadKey();
    }


    #region フィールド用メソッド
    /// <summary>
    /// フィールド用メソッド
    /// </summary>
    /// <param name="var"></param>
    private static void FieldMeth()
    {
      // フィールドに値を設定
      fieldVar = 2;
      Console.WriteLine(string.Format("フィールド中:{0}", fieldVar));
    }
    #endregion


    #region 値渡しメソッド
    /// <summary>
    /// 値渡しメソッド
    /// </summary>
    /// <param name="var"></param>
    private static void RefByValMeth(int var)
    {
      // 引数に値を設定する
      var = 2;
      Console.WriteLine(string.Format("値渡し中:{0}", var));
    }
    #endregion


    #region 参照渡し_refメソッド
    /// <summary>
    /// 参照渡し_refメソッド
    /// </summary>
    /// <param name="var"></param>
    private static void RefMeth(ref int var)
    {
      // 引数に値を設定する
      var = 2;
      Console.WriteLine(string.Format("ref中:{0}", var));
    }
    #endregion


    #region 参照渡し_outメソッド
    /// <summary>
    /// 参照渡し_outメソッド
    /// </summary>
    /// <param name="var"></param>
    private static void OutMeth(out int var)
    {
      // 引数に値を設定する
      var = 2;
      Console.WriteLine(string.Format("outx中:{0}", var));
    }
    #endregion


    #region 参照渡し_outエラーメソッド
#if ERROR
    /// <summary>
    /// 参照渡し_outエラーメソッド
    /// </summary>
    /// <param name="var"></param>
    private static void OutMethError(out int var)
    {
      // out引数に値を設定しないためエラーとなる
    }
#endif
    #endregion


    #region 参照型メソッド
#if PATTERN04
    /// <summary>
    /// 参照型メソッド
    /// </summary>
    /// <param name="var"></param>
    private static void ValMeth(string var)
    {
      // 引数に値を設定する
      var = "B";
      Console.WriteLine(string.Format("参照型中:{0}", var));
    }
#endif
    #endregion

  }
}
