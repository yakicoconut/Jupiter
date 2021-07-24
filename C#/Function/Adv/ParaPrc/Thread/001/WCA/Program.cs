#define PATTERN001
//#define ERROR
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

#region ヘッダ
/*
 * スレッド001
 *   ・並列処理を行う
 *   ・Threadクラスはインスタンスの生成時に実行するメソッドのデリゲートを渡す必要がある
 *   ・Threadクラスに渡すデリゲート
 *     ThreadStart
 *       .NET Framework1.1以降で使用可能
 *       デリゲートとして渡すメソッドに対して引数を渡すことが出来ない
 *     ParameterizedThreadStart
 *       .NET Framework2.0以降で使用可能
 *       デリゲートとして渡したメソッドに対して
 *       該当スレッドのStartメソッドからobject型の引数を渡すことが可能
 *   ・インスタンス生成時にデリゲートを使用せず直接メソッド名を記述することも可能
 *     その場合、対象メソッドの引数の有無からThreadStartかParameterizedThreadStartが
 *     自動で割り当てられる
 * サイト
 *   スレッドの開始時にパラメータを渡すには？［2.0のみ、C#、VB］ - ＠IT
 *   	http://www.atmarkit.co.jp/fdotnet/dotnettips/434paramthread/paramthread.html
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
      // パラメータ無しスレッド用デリゲート
      ThreadStart dlgtThreadTestA = ThreadTestA;
      // パラメータ有りスレッド用デリゲート
      ParameterizedThreadStart dlgtThreadTestB = ThreadTestB;


      #region パターン001_デリゲート使用
#if PATTERN001

      // デリゲートを使用して明示的にスレッド生成
      Thread threadA = new Thread(dlgtThreadTestA);
      Thread threadB = new Thread(dlgtThreadTestB);

#endif
      #endregion

      #region パターン002_デリゲート不使用
#if PATTERN002

      // デリゲートを使用せずにスレッド生成
      // 自動的にThreadStartかParameterizedThreadStartデリゲートが判断される
      Thread threadA = new Thread(ThreadTestA);
      Thread threadB = new Thread(ThreadTestB);

#endif
      #endregion

      #region パターン_エラー
#if ERROR

      // デリゲートとして渡す対象メソッドの引数が
      // ThreadStartかParameterizedThreadStartどちらの
      // デリゲートとも合わないためエラー
      Thread threadC = new Thread(ThreadTestC);

#endif
      #endregion


      // スレッドスタート
      threadA.Start();
      threadB.Start("B");

      // メインスレッドの書き込みが後になることを確認
      Thread.Sleep(1000);
      Console.Write("Main" + Environment.NewLine);


      Console.ReadKey();
    }


    #region テストAメソッド
    private static void ThreadTestA()
    {
      for (int i = 1; i <= 5; i++)
      {
        Console.Write("A" + Environment.NewLine);
        Thread.Sleep(2000);
      }
    }
    #endregion

    #region テストBメソッド
    private static void ThreadTestB(object o)
    {
      for (int i = 1; i <= 5; i++)
      {
        Console.Write(o.ToString() + Environment.NewLine);
        Thread.Sleep(2000);
      }
    }
    #endregion

    #region テストCメソッド
    private static void ThreadTestC(int i)
    {
      for (int j = 1; j <= 5; j++)
      {
        Console.Write(i.ToString() + Environment.NewLine);
        Thread.Sleep(2000);
      }
    }
    #endregion
  }
}
