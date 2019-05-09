#define PATTERN001
#define PATTERN002
#define PATTERN003
#define PATTERN004
#define PATTERN005
//#define ERROR
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * ジェネリック
 *   リスト
 *     配列型では宣言した型のみ、ArrayList型はobject型のみでしか
 *   メソッド
 *     メソッド内で使用する型を可変型として定義する
 *     可変型はメソッド呼び出し時に指定することが可能
 *   可変型配列相当メソッド
 *     配列の型を可変にするパターン
 *     直接可変型で配列を定義することはできずメソッドを用いる
 *     引数として追加する要素を指定することため複数の値を指定できる
 *     
 *     任意の型T(Type)はメソッドとクラスの呼び出し時に指定されるため
 *     Tを指定していないメソッド、クラス内では使用できない
 *   クラス
 *     インスタンス生成時に指定された型となる
 * 
 *   型制約クラス
 *     ★未検証
 *     
 *     第2回　ジェネリック（4/4） - ＠IT
 *      http://www.atmarkit.co.jp/fdotnet/csharp20/csharp20_02/csharp20_02_04.html
 *     型パラメータTにはIDisposableインターフェイスを実装した型しか指定できない
 *     new制約でTに指定した型に引数のないコンストラクタが存在することを保証する
 *     →IDisposableクラスの制約があることで必ず指定した型(クラス)にDisposeメソッドが存在することになる
 *     →さらにnew制約で指定型に引数のないコンストラクタが必ず存在するのでインスタンスをクラス内に生成することができる
 *     ⇒上記から生成したインスタンスには必ずDisposeメソッドが実装されているので呼び出すことが可能
 * 
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


    #region メインメソッド
    static void Main(string[] args)
    {
      #region パターン001_配列
#if PATTERN001

      // 型指定ジェネリック配列メソッド使用
      DesignateTypeList();

#endif
      #endregion


      #region パターン002_可変型メソッド
#if PATTERN002

      // 型可変ジェネリックメソッド使用
      VariableTypeMethod<int, bool>("a", 1, true);
      VariableTypeMethod<string, string>("a", "1", "z");

#endif
      #endregion


      #region パターン003_可変型配列相当メソッド
#if PATTERN003

      // 型可変ジェネリックメソッド使用
      VariableTypeListEquivalentMethod<string>("a", "1");
      VariableTypeListEquivalentMethod<int>(1, 2);

#endif
      #endregion


      #region パターン004_可変型クラス
#if PATTERN004

      // 型可変ジェネリッククラスのインスタンスを文字列型指定で生成
      VariableTypeClass<string> VTC = new VariableTypeClass<string>();
      // 呼び出し元指定型を返すメソッド使用
      var re = VTC.ReturnCallerDesignateType("abc");
      // 表示
      Console.WriteLine(re);

      // 型可変ジェネリッククラスのインスタンスを数値型指定で生成
      VariableTypeClass<int> VTC2 = new VariableTypeClass<int>();
      // 呼び出し元指定型を返すメソッド使用
      var re2 = VTC2.ReturnCallerDesignateType(1);
      // 表示
      Console.WriteLine(re2);

#endif
      #endregion


      #region パターン005
#if PATTERN005
      {
        /* 未 */
        // IDisposable継承制約の付いたジェネリッククラスのインスタンスを
        // IDisposableを継承したクラス型で生成する
        RestrictClass<InheritIDisposableClass> RC = new RestrictClass<InheritIDisposableClass>();

        // 【エラー】IDisposableを継承していないクラス型を指定することはできない
        //RestrictClass<NotInheritIDisposableClass> RC_ = new RestrictClass<NotInheritIDisposableClass>();
        //RestrictClass<string> RC_ = new RestrictClass<string>();


        /*
         * ジェネリッククラスを使用する場合、
         * 渡すことのできる型を絞り込む事設定を行うことで利便性をあげる
         * →下記のクラスの場合、以下の二つが制約となりそれ以外の型は渡すことが出来ない
         *   ・IDisposableクラスを継承していること
         *   ・引数なしコンストラクタを実装していること
         *   ⇒上記はクラス名に「 where T : IDisposable, new()」が設定されていることで保障される
         *     これにより呼び出し側から渡す型には必ずDisposeメソッドを実装していることが保障される
         *     ※コンストラクタに関してはクラス内で確実にインスタンスを生成できるため
         */
        // IDisposable継承、引数なしコンストラクタ制約の付いたジェネリッククラスのインスタンスを
        // IDisposableを継承したクラス型で生成する
        RestrictClassNew<InheritIDisposableClass> RC2 = new RestrictClassNew<InheritIDisposableClass>();
        // Disposeメソッドを実装したメソッドを呼び出し
        RC2.Close();
      }
#endif
      #endregion


      Console.ReadKey();
    }
    #endregion


    #region 型指定ジェネリック配列メソッド
    /// <summary>
    /// 型指定配列メソッド
    /// </summary>
    static void DesignateTypeList()
    {
      // ジェネリックリストを文字列型で宣言
      List<string> strList = new List<string>();

      // 値追加
      strList.Add("abc");
      strList.Add("def");
      strList.Add("ghi");

      // 値変更
      strList[1] = "jkl";

      // 表示
      foreach (string x in strList)
      {
        Console.WriteLine(x);
      }
    }
    #endregion


    #region 可変型ジェネリックメソッド
    /// <summary>
    /// 可変型メソッド
    /// </summary>
    static void VariableTypeMethod<T, T2>(string var1, T var2, T2 var3)
    {
      // T型が文字列かどうか
      string var4 = var2 as string;

      // T2型が文字列かどうか
      string var5 = var3 as string;

      // 表示
      Console.WriteLine(typeof(T) + ":" + var1 + var4 + var5);
    }
    #endregion


    #region 可変型ジェネリック配列相当メソッド

    /// <summary>
    /// 可変型配列相当メソッド
    /// </summary>
    static void VariableTypeListEquivalentMethod<T>(T var1, T var2)
    {
      // メソッド呼び出し時に指定された型を使用する
      List<T> strList = new List<T>();

      // 値追加
      strList.Add(var1);
      strList.Add(var2);

      // 表示
      Console.WriteLine(typeof(T));
      foreach (T x in strList)
      {
        Console.WriteLine(x.ToString());
      }
    }

    #region パターン_エラー
#if ERROR

    /// <summary>
    /// 不可パターン
    /// </summary>
    static void ErrorPattern1(var var1)
    {
      // メソッド呼び出し時に指定された型を使用する
      List<T> strList = new List<T>();

      // 値追加
      strList.Add(var1);

      // 表示
      Console.WriteLine(typeof(T));
      foreach (T x in strList)
      {
        Console.WriteLine(x.ToString());
      }
    }

#endif
    #endregion

    #endregion
  }


  #region 可変型ジェネリッククラス
  /// <summary>
  /// 可変型クラス
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class VariableTypeClass<T>
  {
    /// <summary>
    /// 呼び出し元指定型を返すメソッド
    /// </summary>
    /// <returns></returns>
    public T ReturnCallerDesignateType(T var2)
    {
      // T型はNull非許容型の可能性があるため
      // 初期化にdefault(T)を用いる
      T var1 = default(T);

      // 呼び出し元で指定された型が文字列なら
      if (var2.GetType() == typeof(string))
      {
        // 変数var1にvar2を代入
        var1 = var2;
      }

      // Tが文字列なら引数をそのまま返すが
      // 文字列以外なら指定型によってnullか0を返す
      return var1;
    }
  }
  #endregion


  #region 型制約ジェネリッククラス関連

  #region IDisposableインターフェイス継承クラス
  /// <summary>
  /// Disposeを実装するクラス
  /// </summary>
  public class InheritIDisposableClass : IDisposable
  {
    /*
     * IDisposableインターフェイスは
     * Disposeメソッドのみを提供する
     */

    // コンストラクタ
    public InheritIDisposableClass()
    {

    }

    // Disposeの実装
    public void Dispose()
    {
      Console.WriteLine("Disposed");
    }
  }
  #endregion

  #region 非IDisposableインターフェイス継承クラス
  /// <summary>
  /// Disposeを独自に実装するクラス
  /// </summary>
  public class NotInheritIDisposableClass
  {
    /*
     * IDisposableを継承せずに
     * Disposeメソッドを実装
     */

    // Disposeを独自に実装
    public void Dispose()
    {
      Console.WriteLine("NotDisposed");
    }
  }
  #endregion

  #region 型制約ジェネリッククラス
  /// <summary>
  /// 制約の付いたジェネリッククラス
  /// </summary>
  public class RestrictClass<T> where T : IDisposable
  {
    /*
     * 型パラメータTにはIDisposableを継承していない型は指定できない
     */

    // 渡されたオブジェクト型を呼び出し元指定の型に変換して返す
    public T ReturnT(T var1)
    {
      return (T)var1;
    }
  }

  #endregion

  #region 制約の付いたジェネリッククラス_new
  /// <summary>
  /// 制約の付いたジェネリッククラス_new
  /// </summary>
  public class RestrictClassNew<T> where T : IDisposable, new()
  {
    // 指定型のインスタンス生成
    public T CallerIns = new T();

    // インスタンスからDisposeメソッドを呼び出すメソッド
    public void Close()
    {
      // 必ずDisposeメソッドを実装している
      CallerIns.Dispose();
    }
  }
  #endregion

  #endregion
}