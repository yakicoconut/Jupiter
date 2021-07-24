using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WFA
{
  class Class1
  {
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="fm">フォーム1</param>
    public Class1(Form1 fm)
    {
      // 渡されたフォーム1を変数に設定
      fm1 = fm;
    }

    // フォーム1変数
    public Form1 fm1;
  }
}
