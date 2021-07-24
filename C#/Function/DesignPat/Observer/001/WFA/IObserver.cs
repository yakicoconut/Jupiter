using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WFA
{
  /// <summary>
  /// オブザーバインターフェイス
  /// </summary>
  interface IObserver
  {
    /// <summary>
    /// Subject通知メソッド
    /// </summary>
    /// <param name="notifySubject"></param>
    void Notify(NotifyStruct notifySubject);
  }
}
