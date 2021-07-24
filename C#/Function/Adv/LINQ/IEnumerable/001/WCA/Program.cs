using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

#region ヘッダ
/*
 * IEnumerable
 *   IEnumerableインターフェイスはGetEnumeratorメソッドを保証する
 *   →GetEnumeratorはIEnumeratorインターフェースを実装しているクラスのインスタンスを返すメソッド
 *   →IEnumeratorは「コレクションの現在の要素を取得したり、次の要素に進めたり、最初の要素にもどったりする」機能を保証する
 *   ⇒IEnumerableを実装するクラスはコレクションの要素を参照したり次に移したりするIEnumeratorを実装したクラスを返す
 *     ⇒yield(イテレータ)
 *       「yield return」で要素が返されるたびに、コレクションの次の要素をforeachで処理できるような形で返すことができるもの
 * サイト
 *   [C#] IEnumeratorインターフェイスを実装しforeachに対応したクラスを作成する
 *    https://www.ipentec.com/document/document.aspx?page=csharp-inplement-IEnumerator-IEnumerable
 */ 
#endregion
namespace WCA
{
  class Program
  {
    static void Main(string[] args)
    {

    }
  }

  #region コレクションクラス
  public class MyCollection : IEnumerable
  {
    //// IEnumerableインターフェイス実装メソッド
    //public IEnumerator GetEnumerator()
    //{
    //  for (int i = 0; i < hoge.Length; i++)
    //  {
    //    yield return hoge[i];
    //  }
    //}

    // IEnumerableインターフェイス実装メソッド
    public IEnumerator GetEnumerator()
    {
      MyEnumerator myEnume = new MyEnumerator();

      for (int i = 0; i < hoge.Length; i++)
      {
        myEnume.SetCurrent(hoge[i]);
      }

      return (IEnumerator)myEnume;

    }

    int[] hoge;
    public MyCollection()
    {
      hoge = new int[] { 0, 1, 2, 3 };
    }
  }
  #endregion


  public class MyEnumerator : IEnumerator
  {
    private object _Current;
    public object Current
    {
      get
      {
        return _Current;
      }
    }

    public void SetCurrent(object var)
    {
      _Current = var;
    }

    public bool MoveNext()
    {
      return true;
    }

    public void Reset()
    {

    }
  }
}
