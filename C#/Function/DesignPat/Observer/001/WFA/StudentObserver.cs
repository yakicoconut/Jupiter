using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WFA
{
  /// <summary>
  /// Studentとして監視するクラス
  /// </summary>
  class StudentObserver : IObserver
  {
    #region メンバ

    Form1 fm2;

    #endregion


    #region コンストラクタ
    public StudentObserver(Form1 fm1)
    {
      fm2 = fm1;
    }
    #endregion


    #region Subject通知メソッド
    /// <summary>
    /// Subject通知メソッド
    /// </summary>
    /// <param name="notifySubject"></param>
    public void Notify(NotifyStruct notifySubject)
    {
      fm2.textBox1.AppendText("*** Student ***\r\n");
      fm2.textBox1.AppendText("送信元 = " + notifySubject.from.ToString() + "\r\n");
      fm2.textBox1.AppendText("受信先 = " + notifySubject.to.ToString() + "\r\n");
      fm2.textBox1.AppendText("内容 = " + notifySubject.subject + "\r\n");
    }
    #endregion
  }
}
