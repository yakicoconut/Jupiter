#define PATTERN01
#define PATTERN02
#define PATTERN03
#define PATTERN04
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

#region ヘッダ
/*
 * 値型、参照型
 *   値型と参照型 - C# によるプログラミング入門 | ++C++; // 未確認飛行 C
 *  	http://ufcpp.net/study/csharp/oo_reference.html
 *   ・クラス、配列等は参照型で変数にメモリアドレスを格納する
 *   ・構造体、数値等は値型で変数に値を格納する
 *   ・値型は引数として渡ったメソッド内で変更がされても
 *     呼び出し元では値が変わらないが
 *     参照型の場合は渡したメソッド内で値が変更されると呼び出し元の
 *     変数の値も変更される
 *   ・値型
 *     bool、enum、struct(構造体)、数値型
 *   ・参照型
 *     string、object、配列、クラス、インターフェイス、デリゲート
 *   stringって本当に参照型？
 *    http://bbs.wankuma.com/index.cgi?mode=al2&namber=3817&KLOG=4
 *      >string a = "1";
 *      >string b = a;
 *      >string c = b;
 *      >
 *      >a,b,c 自体には、"1への参照が入っています。なので「文字列変数」は参照型です。
 *      >
 *      >b = "2";
 *      >
 *      >b には"2"の参照が入ります。b に "2"の参照が入っただけなので、a,c の参照は当然変化しませんよね？
 *      >
 *      >つまり、「文字列の代入」という行為は、「文字列変数の値（中身）」を書き換えているのではなく、参照を再設定しているということです。
 *      >
 *      >string a = new string("1");
 *      >string b = a;
 *      >string b = new string("2");
 *      >
 *      >こんな感じの動きです。ここで a が "2" になるかと言ったら…なりませんよね。
 *   →string(文字列)は参照型だが特殊で、値設定毎にメモリアドレスを再設定しているため
 *     結果として値型と同じ動きになる
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
      #region パターン01_クラス
#if PATTERN01

      // 参照型検証クラスのインスタンス生成
      RefTest refTest = new RefTest();

      // 検証メンバに値設定
      refTest.obj = "A";
      Console.WriteLine("クラス前:{0}", refTest.obj);

      // 引数変更メソッド_クラス使用
      Change(refTest);
      Console.WriteLine("クラス後:{0}", refTest.obj);

#endif
      #endregion


      #region パターン02_配列
#if PATTERN02

      // 数値配列生成
      int[] arr = new int[3] { 1, 2, 3 };
      Console.WriteLine("配列前:{0}", arr[0]);

      // 引数変更メソッド_配列使用
      Change(arr);
      Console.WriteLine("配列後:{0}", arr[0]);

#endif
      #endregion


      #region パターン03_値型
#if PATTERN03

      // 数値
      int i = 1;
      Console.WriteLine("値型前:{0}", i.ToString());

      // 引数変更メソッド_値型使用
      Change(arr);
      Console.WriteLine("値型後:{0}", i.ToString());

#endif
      #endregion


      #region パターン04_文字列
#if PATTERN04

      // 文字列
      string str = "A";
      Console.WriteLine("文字列前:{0}", str.ToString());

      // 引数変更メソッド_文字列使用
      Change(str);
      Console.WriteLine("文字列後:{0}", str.ToString());

#endif
      #endregion


      Console.ReadKey();
    }


    #region 引数変更メソッド_クラス
    /// <summary>
    /// 引数変更メソッド_クラス
    /// </summary>
    /// <param name="var"></param>
    static void Change(RefTest var)
    {
      // 引数の値変更
      var.obj = "B";

      // 引数に新しいインスタンス設定
      var = new RefTest();
      // 新しいインスタンスに値を設定
      var.obj = "C";
      Console.WriteLine("クラス中:{0}", var.obj);
    }
    #endregion


    #region 引数変更メソッド_配列
    /// <summary>
    /// 引数変更メソッド_配列
    /// </summary>
    /// <param name="var"></param>
    static void Change(int[] var)
    {
      // 引数の値変更
      var[0] = 4;

      // 引数に新しいインスタンス設定
      var = new int[1] { 5 };
      Console.WriteLine("配列中:{0}", var[0]);
    }
    #endregion


    #region 引数変更メソッド_値型
    /// <summary>
    /// 引数変更メソッド_値型
    /// </summary>
    /// <param name="var"></param>
    static void Change(int var)
    {
      // 引数の値変更
      var = 2;
      Console.WriteLine("値型中:{0}", var.ToString());
    }
    #endregion


    #region 引数変更メソッド_文字列
    /// <summary>
    /// 引数変更メソッド_文字列
    /// </summary>
    /// <param name="var"></param>
    static void Change(string var)
    {
      // 引数の値変更
      var = "B";
      Console.WriteLine("文字列中:{0}", var);
    }
    #endregion
  }


  #region 参照型検証クラス
  /// <summary>
  /// 参照型検証クラス
  /// </summary>
  class RefTest
  {
    /// <summary>
    /// 検証メンバ
    /// </summary>
    public object obj;
  } 
  #endregion
}
