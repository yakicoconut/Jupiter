using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICalcPlugin
{
  /// <summary>
  /// 計算プラグインインターフェイス
  /// </summary>
  public interface ICalcClass
  {
    /// <summary>　
    /// 計算記号
    /// </summary>
    string Symbol { get; set; }

    /// <summary>
    /// 計算メソッド
    /// </summary>
    /// <param name="luftElem">左辺</param>
    /// <param name="rightElem">右辺</param>
    /// <returns>計算結果</returns>
    int Calc(int leftElem, int rightElem);
  }
}
