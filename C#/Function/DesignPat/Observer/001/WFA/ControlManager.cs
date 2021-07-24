using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WFA
{
  /// <summary>
  /// Subjectの実体
  /// </summary>
  class ControlManager : ISubject
  {
    #region メンバ

    // オブザーバ操作格納配列
    private List<IObserver> observerList;
    // イベント通知用構造体
    private NotifyStruct notifySubject;

    #endregion


    #region コンストラクタ
    /// <summary>
    /// コンストラクタ
    /// </summary>
    public ControlManager()
    {
      // オブザーバ配列の初期化
      observerList = new List<IObserver>();
    }
    #endregion
    

    #region Observer登録メソッド
    /// <summary>
    /// Observer登録メソッド
    /// </summary>
    /// <param name="observer"></param>
    public void Attach(IObserver observer)
    {
      // リストに追加
      observerList.Add(observer);
    }
    #endregion
    
    #region Observer削除メソッド
    public void Detach(IObserver observer)
    {
      // リストから削除
      observerList.Remove(observer);
    }
    #endregion
    
    #region Observer送信メソッド
    /// <summary>
    /// Observer送信メソッド
    /// </summary>
    public void Notify()
    {
      // リストの内容をオブザーバへ送信する
      foreach (IObserver observer in observerList)
      {
        // オブザーバのSubject通知メソッドを使用する
        observer.Notify(notifySubject);
      }
    }
    #endregion

    #region 構造体格納メソッド
    /// <summary>
    /// イベント通知に利用する構造体に格納
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <param name="subject"></param>
    public void SetChanged(int from, int to, string subject)
    {
      //
      NotifyStruct notifySubject;

      //
      notifySubject.from = from;
      notifySubject.to = to;
      notifySubject.subject = subject;

      //
      this.SetChanged(notifySubject);
    }
    #endregion

    #region イベント通知用構造体格納メソッド
    /// <summary>
    /// イベント通知用構造体格納メソッド
    /// </summary>
    /// <param name="notifySubject"></param>
    public void SetChanged(NotifyStruct notifySubject)
    {
      // イベント通知用構造体に値を格納
      this.notifySubject.from = notifySubject.from;
      this.notifySubject.to = notifySubject.to;
      this.notifySubject.subject = notifySubject.subject;

      // Observer送信メソッド使用
      Notify();
    }
    #endregion
  }
}
