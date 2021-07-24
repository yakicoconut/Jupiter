using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// 名前空間指定
using WCLNS02;

namespace WCL
{
  // 同ファイル内での名前空間動作
  public class WCLClassMain
  {
    public void MainMeth()
    {
      // 完全修飾指定
      WCLNS01.TestClass01.Meth01();

      // usingディレクティブ使用
      TestClass02.Meth02();
    }
  }
}

namespace WCLNS01
{
  public class TestClass01
  {
    static public void Meth01()
    {

    }
  }
}

namespace WCLNS02
{
  public class TestClass02
  {
    static public void Meth02()
    {

    }
  }
}