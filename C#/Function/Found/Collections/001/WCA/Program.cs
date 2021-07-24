using System;
using System.Collections.Generic;
using System.Collections;

#region ヘッダ
/*
 * コレクション
 *   ・ハッシュテーブル
 *   ・キュー
 *   ・スタック
 *   ・ディクショナリ
 */ 
#endregion
namespace WCA
{
  class Program
  {
    #region メインメソッド
    static void Main(string[] args)
    {
      TestHashTable();
      TestQueue();
      TestStack();
      TestDictionary();

      Console.ReadKey();
    } 
    #endregion


    #region ハッシュテーブル
    static void TestHashTable()
    {
      // ハッシュテーブルインスタンス生成
      Hashtable ht = new Hashtable();

      // 値追加
      ht["あ"] = "浅草線";
      ht["A"] = "三田線";
      ht.Add("イ", "新宿線");
      ht.Add("1", "大江戸線");

      // キーによるデータの取得
      Console.WriteLine(ht["あ"]);
      Console.WriteLine(ht["A"]);
      Console.WriteLine(ht["ZZZ"]);
      Console.WriteLine(ht["イ"]);
      Console.WriteLine(ht["1"]);

      Console.WriteLine("---------------");

      // 一括出力
      foreach (string item in ht.Keys)
      {
        Console.WriteLine("{0}\t{1}", item, ht[item]);
      }

      Console.WriteLine("================");
    }
    #endregion

    #region キュー
    static void TestQueue()
    {
      // キューインスタンス生成
      Queue myQueue = new Queue();

      // 値追加
      myQueue.Enqueue("最初のお客さん");
      myQueue.Enqueue("次のお客さん");
      myQueue.Enqueue("三番目のお客さん");

      // 一括出力
      while (myQueue.Count > 0)
      {
        Console.WriteLine(myQueue.Dequeue());
      }

      Console.WriteLine("================");
    }
    #endregion

    #region スタック
    static void TestStack()
    {
      // スタックインスタンス生成
      Stack myStack = new Stack();

      // 値追加
      myStack.Push("12か月前に買った本");
      myStack.Push("6か月前に買った本");
      myStack.Push("2か月前に買った本");
      myStack.Push("2週間前に買った本");
      myStack.Push("昨日買った本");

      // 一括出力
      while (myStack.Count > 0)
      {
        Console.WriteLine(myStack.Pop());
      }

      Console.WriteLine("================");
    }
    #endregion

    #region ディクショナリ
    static void TestDictionary()
    {
      // ディクショナリインスタンス生成
      Dictionary<string, int> data = new Dictionary<string, int>();

      // 値追加
      data.Add("index.html", 100);
      data.Add("product.html", 34);
      data.Add("news.html", 58);
      data.Add("contact.html", 27);
      data.Add("download.html", 48);

      // キーによるデータの取得
      Console.WriteLine(data["news.html"]);
      
      // 一括出力
      foreach (string item in data.Keys)
      {
        Console.WriteLine("{0}\t{1}", item, data[item]);
      }
      Console.WriteLine("================");
    }
    #endregion
  }
}
