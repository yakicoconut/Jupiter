#define PATTERN01
#define PATTERN02
//#define PATTERN03
#define PATTERN04
//#define PATTERN05
#define PATTERN06
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#region ヘッダ
/*
 * staticメソッド内でstaticでないメンバを参照できない理由 - プログラミングとかブログ
 *  http://shirakamisauto.hatenablog.com/entry/2015/06/15/181428
 *    ・static(静的)修飾子を使用して宣言されたメンバはアプリの実行時にメモリが確保される
 *      そのためインスタンス化して始めてメモリ展開される動的なメンバを含んでいる場合、
 *      staticメンバの使用時に動的メンバがインスタンス化(メモリ展開)されていない可能性があるためエラーとなる
 * 
 * 連載! とことん C#: 第 2 回 静的 (static) なクラスとその意義 言語: C#
 *	https://code.msdn.microsoft.com/windowsdesktop/2-static-8c0cc826
 *	  ・動的メンバはインスタンス化によってメモリを確保できる分の実体を生成することができる
 *	    静的メンバはインスタンス化できないため唯一一つの実体しかもてない(データの整合性が取りやすい)
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

    #endregion

    static void Main(string[] args)
    {
      #region パターン01_静的メソッド
      /*
       * 単純に静的クラスの静的メソッドを呼び出す
       */
#if PATTERN01
      // 静的クラスの静的メソッド使用
      TestClass01.Test01();
#endif
      #endregion


      #region パターン02_動的メソッド
      /*
       * 動的クラスでも静的メソッドであれば
       * インスタンス化せずに呼び出すことが可能
       */
#if PATTERN02
      // 動的クラスの静的メソッド使用
      TestClass02.Test02();
#endif
      #endregion


      #region パターン03_動的メソッドエラー
#if PATTERN03
      /*
       * エラーパターン
       * 動的クラスの動的メソッドをインスタンス化しないで
       * 使用しようとする
       */

      // 動的クラスの動的メソッド使用
      TestClass02.Test03();
#endif
      #endregion


      #region パターン04_動的メソッド
      /*
       * 動的クラスの動的メソッドを使用するにはインスタンス化が必須
       */
#if PATTERN04
      // 動的クラスインスタンス化
      TestClass02 tearClass02 = new TestClass02();

      // 動的クラスの動的メソッド使用
      tearClass02.Test03();
#endif
      #endregion


      #region パターン05_動的メソッドエラー
#if PATTERN05
      /*
       * コンパイルエラーパターン
       * 静的メソッド内で動的変数を使用しようとする
       */
#endif
      #endregion


      #region パターン06_静的メソッド内動的変数
      /*
       * 静的メソッド内で動的変数のを含むクラスのインスタンス化が
       * されていれば動的変数のメモリが確保されているため問題なく呼び出せる
       */
#if PATTERN06
      // 動的クラスの動的メソッド使用
      TestClass02.Test05();
#endif
      #endregion


      Console.ReadKey();
    }
  }


  #region 静的クラス
  /// <summary>
  /// 静的クラス
  /// </summary>
  static class TestClass01
  {
    #region 静的メソッド
    /// <summary>
    /// 静的メソッド
    /// </summary>
    public static void Test01()
    {
      Console.WriteLine("TEST001");
    }
    #endregion
  }
  #endregion


  #region 動的クラス
  /// <summary>
  /// 動的クラス
  /// </summary>
  class TestClass02
  {
    #region 静的メソッド
    /// <summary>
    /// 静的メソッド
    /// </summary>
    public static void Test02()
    {
      Console.WriteLine("TEST002");
    }
    #endregion

    #region 動的メソッド
    /// <summary>
    /// 動的メソッド
    /// </summary>
    public void Test03()
    {
      Console.WriteLine("TEST003");
    }
    #endregion

    #region パターン05_静的メソッド内動的変数エラー
#if PATTERN05
    string str01;

    /// <summary>
    /// 静的メソッド
    /// </summary>
    public static void Test04()
    {
      str01 = "TEST004";
      Console.WriteLine(str01);
    }
#endif
    #endregion

    #region パターン06_静的メソッド内動的変数
#if PATTERN06
    string str02;

    /// <summary>
    /// 静的メソッド内動的変数
    /// </summary>
    public static void Test05()
    {
      // 本クラスのインスタンス生成
      // これにより動的変数str02のメモリが確保される
      TestClass02 testClass02 = new TestClass02();

      // インスタンスが生成され、動的変数のメモリが確保されているためエラーにならない
      testClass02.str02 = "TEST005";
      Console.WriteLine(testClass02.str02);
    }
#endif
    #endregion
  }
  #endregion
}
