using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WFA
{
  /// <summary>
  /// サブジェクトインターフェイス
  /// </summary>
  interface ISubject
  {
    /// <summary>
    /// Observer登録
    /// </summary>
    /// <param name="observer"></param>
    void Attach(IObserver observer);

    /// <summary>
    /// Observer削除
    /// </summary>
    /// <param name="observer"></param>
    void Detach(IObserver observer);

    /// <summary>
    /// Observer通知
    /// </summary>
    void Notify();
  }
}
