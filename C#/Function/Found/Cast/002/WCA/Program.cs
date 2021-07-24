//#define ERROR
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#region ヘッダ
/*
 * as・is
 *   ・アップキャストした変数では派生クラスのメンバに
 *     アクセスすることが出来ないためダウンキャストする必要があるが
 *     間違った派生クラス型に対してキャストを行うとコンパイル上は問題ないが
 *     処理実行時にエラーとなってしまう
 *   ・as演算子とis演算子でインスタンスとキャスト対象インスタンスの関係性を
 *     調べることが出来、上記のエラーを防ぐことが可能
 *   is
 *     ・該当インスタンスが該当型に対してキャスト可能かどうかを返す
 *     ・あくまでキャスト可能かどうかを判断するため厳密に同じ型かどうかは判断できない
 *   as
 *     ・キャスト可能な場合はキャストを実行しキャストできない場合はnullを返す
 *       通常のキャストとの違いはエラーを返すかどうか
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


    // クラス定義
    class Base
    {
      public string var01 = "abc";
    }

    class Derived1 : Base
    {
      public string var02 = "def";
    }

    class Derived2 : Base
    {
      public string var03 = "ghi";
    }

    #region メインメソッド
    static void Main(string[] args)
    {
      Derived1 dynamicD1;
      Derived2 dynamicD2;
      Base dynamicB1;
      Base dynamicB2;

      // 通常アップキャスト
      dynamicB1 = new Derived1();
      dynamicB2 = new Derived2();
      // 通常ダウンキャスト
      dynamicD1 = (Derived1)dynamicB1;
      dynamicD2 = (Derived2)dynamicB2;


      #region パターン_エラー
#if ERROR

      // テレコしたダウンキャスト
      dynamicD1 = (Derived1)dynamicB2;
      dynamicD2 = (Derived2)dynamicB1;

#endif
      #endregion


      /* is */
      Derived1 varD1 = new Derived1();
      // 通常インスタンスは当然trueとなる
      Console.WriteLine(varD1 is Derived1);
      // アップキャストされた変数は元の型には戻せる
      Console.WriteLine(dynamicB1 is Derived1);
      // アップキャストされた変数は別の型には戻せない
      Console.WriteLine(dynamicB2 is Derived1);
      // キャスト可能か判断
      if (dynamicB1 is Derived1)
      {
        // ダウンキャスト前は基底クラスのメンバしか使用できない
        Console.WriteLine(dynamicB1.var01);

        // 可能な場合はダウンキャスト
        dynamicD1 = (Derived1)dynamicB1;

        // ダウンキャスト後は元のクラスのメンバも使用できる
        Console.WriteLine(dynamicD1.var02);
      }

      // キャスト可能かどうかを判断するため
      // 厳密に同じ型かどうかは判断できない
      Console.WriteLine(dynamicB1 is Derived1);
      Console.WriteLine(dynamicB1 is Base);
      // 厳密に判断したい場合は以下のようにする
      Console.WriteLine(dynamicB1.GetType() == typeof(Derived1));
      Console.WriteLine(dynamicB1.GetType() == typeof(Base));


      /* as */
      // キャストできないためnullを格納する
      Derived1 varD2 = dynamicB2 as Derived1;
      Console.WriteLine(varD2 == null);
      // キャストできる
      varD1 = dynamicB1 as Derived1;
      Console.WriteLine(varD1.var02);
      // isで書き換えると以下となる
      Derived1 varD1_1 = dynamicB1 is Derived1 ? (Derived1)dynamicB1 : null;


      Console.ReadKey();
    }
    #endregion
  }
}
