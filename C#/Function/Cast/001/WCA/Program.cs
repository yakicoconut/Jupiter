#define ERROR
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * キャスト
 *   アップキャスト
 *     基底クラスの変数型に派生クラスのインスタンスを代入することは
 *     常に可能(明示的なキャストが必要ない)
 *   ダウンキャスト
 *     派生クラスの変数型に基底クラスのインスタンスを代入するには
 *     明示的なキャストが必要
 *   ・アップキャストされたインスタンスが格納されている変数は
 *     型が一緒でも中身のインスタンスが別のクラスという可能性があるため
 *     文法的なダウンキャストができていて(コンパイルが通って)も実行時に実際に
 *     変数代入が行われたときにエラーとなるパターンがある
 *   
 *     クラス定義
 *       基底クラス →継承→ 派生クラス1
 *                  →継承→ 派生クラス2
 *   
 *     インスタンス代入
 *       基底クラス型  変数①  = 派生クラス1インスタンス        ⇒ ○:アップキャスト
 *       基底クラス型  変数②  = 派生クラス2インスタンス        ⇒ ○:アップキャスト
 *       派生クラス1型 変数③  = (キャスト:派生クラス1型)変数① ⇒ ○:ダウンキャスト(明示的な変換必須)
 *       派生クラス2型 変数④  = (キャスト:派生クラス2型)変数② ⇒ ○:ダウンキャスト(明示的な変換必須)
 *       
 *       派生クラス2型 変数⑤  = (キャスト:派生クラス2型)変数① ⇒ △:コンパイルは通るが実行時エラー
 *                                                                    あくまで派生クラス型の変数に基底クラス型を
 *                                                                    代入しようとするため明示的なキャストをすれば
 *                                                                    コンパイルは通る(文法的にはエラーにならない)
 */
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
    class Base { }
    class Derived1 : Base { }
    class Derived2 : Base { }


    static void Main(string[] args)
    {      
      // 通常のインスタンス生成
      Derived1 dynamicD1 = new Derived1();
      Derived2 dynamicD2 = new Derived2();
      Base dynamicB = new Base();
      

      // 単純なアップキャスト
      // 「Base」クラス型の変数に
      // 「Derived1」クラスのインスタンスを入れる
      Base staticB1 = new Derived1();
      // 「Derived1」クラス型の変数に
      // 「Base」クラス型の「Derived1」クラスインスタンスを入れるが
      // ダウンキャストとなるため明示的なキャストが必須
      Derived1 staticD1 = (Derived1)staticB1;


      // 単純なアップキャスト
      Base staticB2 = new Derived1();
      // 「Derived2」クラス型の変数に
      // 「Base」クラス型の「Derived1」クラスインスタンスを入れる
      // →「Base」クラス型の変数のためキャストは可能だが
      //   インスタンスとして入っているのは「Derived1」クラスのため実行時にエラーとなる
      Derived2 staticD2 = (Derived2)staticB2;

      // 派生クラスに基底クラスのインスタンスは入れられない
      Derived1 staticD1Error = (Derived1)new Base();


      #region パターン_エラー
#if ERROR



#endif
      #endregion


      Console.ReadKey();
    }
  }
}
