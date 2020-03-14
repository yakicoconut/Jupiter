using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICalcPlugin;

namespace CalcMinus
{
  public class Minus : ICalcClass
  {
    #region ICalcClassメンバ

    #region プロパティ

    /// <summary>　
    /// 計算記号
    /// </summary>
    public string Symbol { get; set; }

    #endregion


    #region 計算メソッド
    /// <summary>
    /// 計算メソッド
    /// </summary>
    /// <param name="luftElem">左辺</param>
    /// <param name="rightElem">右辺</param>
    /// <returns>計算結果</returns>
    public int Calc(int leftElem, int rightElem)
    {
      // 計算記号プロパティ設定
      Symbol = "-";

      // 計算
      return leftElem - rightElem;
    }
    #endregion

    #endregion
  }
}
