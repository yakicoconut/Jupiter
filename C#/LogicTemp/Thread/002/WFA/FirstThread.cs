using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.VisualBasic;

namespace WFA
{
  /// <summary>
  /// 主スレッド処理クラス
  /// </summary>
  class FirstThread
  {
    #region コンストラクタ
    public FirstThread(Form1 fm1)
    {
      // 呼び出し元フォームの設定
      fm = fm1;
    }
    #endregion


    #region 宣言

    // フォーム1変数
    Form1 fm;

    #endregion


    #region 主要スレッド処理メソッド
    /// <summary>
    /// 主要スレッドメソッド
    /// </summary>
    /// <param name="obj"></param>
    public void PrimeThread(Object obj)
    {
      //// 処理サンプル
      //for (int i = 0; i <= 5; i++)
      //{
      //  // ラベル更新操作メソッド使用
      //  fm.UpdLabelOprt(i.ToString());

      //  // 待機
      //  Thread.Sleep(1000);
      //}

      ////MessageBox.Show("完了");
    }
    #endregion
  }
}
