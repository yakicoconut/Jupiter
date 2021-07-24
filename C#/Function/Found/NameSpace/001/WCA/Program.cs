using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WCA
{
  // 同プロジェクトのクラスは別の.csファイルでも呼び出し可能
  class Program
  {
    static void Main(string[] args)
    {
      // 同名前空間クラスのメソッド呼び出し
      Class1 cl1 = new Class1();
      cl1.ClMeth01();

      //// 【エラー】同プロジェクト、別名前空間クラスのメソッド呼び出し
      //Class2 cl2 = new Class2();
      //cl2.ClMeth02();

      // 同プロジェクト、別名前空間クラスのメソッド呼び出し
      // 完全修飾なら使用可能
      WCA_Test.Class2 cl2 = new WCA_Test.Class2();
      cl2.ClMeth02();

      // 【要設定】同ソリューション別プロジェクトクラス呼び出し
      // ※プロジェクト参照必須
      // ソリューションエクスプローラ-.csproject右クリック-[参照の追加]-[Projects]展開-[Solution]選択-対象名前空間
      WCL.WCLClassMain wclM = new WCL.WCLClassMain();
      wclM.MainMeth();
      // プロジェクト参照追加後は同プロジェクト、別名前空間クラスも呼び出し可能
      WCLNS01.TestClass01.Meth01();
    }

    static public void Meth01()
    {
      Console.WriteLine("Test01");
      Console.ReadKey();
    }
  }
}
