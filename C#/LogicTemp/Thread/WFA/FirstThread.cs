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

    // 一時停止イベント
    AutoResetEvent autoResetEvent = new AutoResetEvent(false);

    // フォーム1変数
    Form1 fm;

    #endregion


    #region プロパティ

    /// <summary>
    /// 一時停止フラグ
    /// true:停止、false:実行
    /// </summary>
    public bool PauseFlag { get; set; }

    /// <summary>
    /// 処理終了フラグ
    /// true:終了、false:継続
    /// </summary>
    public bool EndFlag { get; set; }

    #endregion


    #region 主要スレッド処理メソッド

    // 排他ロック用変数
    private readonly object _lockObj = new object();

    // ラベル更新メソッド用のデリゲート宣言
    delegate void LabelUpdateCallback(string str);

    /// <summary>
    /// 主要スレッドメソッド
    /// </summary>
    /// <param name="obj"></param>
    public void PrimeThread(Object obj)
    {
      /*
       * Unity C# スレッドの休止と再開 - Qiita
       *	https://qiita.com/satotin/items/4281afe26ae86d1eeec8
       */
      // 処理サンプル
      for (int i = 0; i < 10; i++)
      {
        // フラグが一時停止の場合
        if (PauseFlag == true)
        {
          MessageBox.Show("一時停止");
          // スレッドを無期限で待機
          autoResetEvent.WaitOne();
        }

        // 処理終了フラグが終了の場合
        if (EndFlag == true)
        {
          MessageBox.Show("途中終了");

          // 処理終了フラグ初期化
          EndFlag = false;
          // 処理終了
          return;
        }

        // スレッド処理振り分けメソッド使用
        fm.AssignThreadProcess(i.ToString());

        // 待機
        Thread.Sleep(1000);
      }

      //終了していて一時停止でないようにフラグを設定
      EndFlag = true;

      MessageBox.Show("完了");
    }

    #endregion

    #region 一時停止メソッド
    public void PauseThread(Thread threadA)
    {
      // ねずみ返し
      if (threadA == null)
      {
        return;
      }

      // 一時停止フラグが実行の場合
      if (!PauseFlag)
      {
        // 一時停止フラグを停止にする
        PauseFlag = true;

        return;
      }

      // 対象スレッドがブロック(一時停止)ステータスの場合
      if (threadA.ThreadState == System.Threading.ThreadState.WaitSleepJoin)
      {
        // 一時停止フラグを戻す
        PauseFlag = false;

        // 待機していた別処理スレッドを再開
        autoResetEvent.Set();
      }
    }
    #endregion

    #region 処理停止メソッド
    public void EndThread(Thread threadA)
    {
      // ねずみ返し
      if (threadA == null)
      {
        return;
      }

      // 対象スレッドがブロック(一時停止)ステータスの場合
      if (threadA.ThreadState == System.Threading.ThreadState.WaitSleepJoin)
      {
        // 待機していた別処理スレッドを再開
        autoResetEvent.Set();

        // 一時停止フラグを停止にする
        PauseFlag = false;
      }

      // 処理停止フラグを立てる
      EndFlag = true;
    }
    #endregion


    #region 雛形メソッド
    public void template()
    {

    }
    #endregion
  }
}
