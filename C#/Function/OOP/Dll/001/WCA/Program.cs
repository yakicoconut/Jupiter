using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WCA3;

#region ヘッダ
/*
 * dll
 *   ・C#クラスライブラリとして作成されたプロジェクトは
 *     ビルドされるとプロジェクトの名称でdllファイルとして作成される
 *   ・dllファイルは別プロジェクトの参照設定として追加でき、
 *     名前空間内のクラスにアクセスすることが可能
 */ 
#endregion
namespace WCA
{
  class Program
  {
    static void Main(string[] args)
    {
      // 同名前空間
      TestClass01 testClass01 = new TestClass01();
      testClass01.member01 = "abc";

      // 別名前空間
      WCA2.TestClass02 testClass02 = new WCA2.TestClass02();
      testClass02.member02 = "def";

      // dll参照
      // 静的メンバ
      TestClass03.member03 = "ghi";
      // インスタンス生成
      TestClass03 testClass03 = new TestClass03();
      testClass03.member04 = "jkl";

      // 表示
      Console.WriteLine(testClass01.member01);
      Console.WriteLine(testClass02.member02);
      Console.WriteLine(TestClass03.member03);
      Console.WriteLine(testClass03.member04);


      Console.ReadKey();
    }
  }

  public class TestClass01
  {
    public string member01;
  }
}


namespace WCA2
{
  public class TestClass02
  {
    public string member02;
  }
}