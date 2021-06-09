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
using System.Text.RegularExpressions;
using System.Drawing;

namespace WFA
{
  /// <summary>
  /// 置換実行処理クラス
  /// </summary>
  public class ExecRepThread
  {
    #region コンストラクタ
    public ExecRepThread(Form1 fm, DataStore _dataStore)
    {
      // 呼び出し元フォームの設定
      fm1 = fm;

      // プログレスバーフォーム
      fmPrgBar = new FrmPrgBar();
      // 事前にロードし、非表示としておく
      fmPrgBar.Show();
      fmPrgBar.Visible = false;

      // データ連携クラス引継ぎ
      dataStore = _dataStore;
    }
    #endregion


    #region 宣言

    // メインフォーム
    Form1 fm1;
    // プログレスバーフォーム
    FrmPrgBar fmPrgBar;

    // データ連携クラス
    DataStore dataStore;

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

    //// 排他ロック用変数
    //private readonly object _lockObj = new object();

    //// ラベル更新メソッド用のデリゲート宣言
    //delegate void LabelUpdateCallback(string str);

    ///// <summary>
    ///// 主要スレッドメソッド
    ///// </summary>
    ///// <param name="obj"></param>
    //public void PrimeThread(Object obj)
    //{
    //  /*
    //   * Unity C# スレッドの休止と再開 - Qiita
    //   *	https://qiita.com/satotin/items/4281afe26ae86d1eeec8
    //   */
    //  // 処理サンプル
    //  for (int i = 0; i < 10; i++)
    //  {
    //    // フラグが一時停止の場合
    //    if (PauseFlag == true)
    //    {
    //      MessageBox.Show("一時停止");
    //      // スレッドを無期限で待機
    //      autoResetEvent.WaitOne();
    //    }

    //    // 処理終了フラグが終了の場合
    //    if (EndFlag == true)
    //    {
    //      MessageBox.Show("途中終了");

    //      // 処理終了フラグ初期化
    //      EndFlag = false;
    //      // 処理終了
    //      return;
    //    }

    //    // スレッド処理振り分けメソッド使用
    //    fm.AssignThreadProcess(i.ToString());

    //    // 待機
    //    Thread.Sleep(1000);
    //  }

    //  //終了していて一時停止でないようにフラグを設定
    //  EndFlag = true;

    //  MessageBox.Show("完了");
    //}

    #endregion

    #region 主要スレッド処理メソッド
    /// <summary>
    /// 主要スレッドメソッド
    /// </summary>
    /// <param name="obj"></param>
    public void MainProcessThread()
    {
      string resultStr = dataStore.TgtStr;

      int i = 0;
      foreach (CheckBox x in dataStore.ListChkBox)
      {
        // ねずみ返し_チェックが付いていない場合
        if (!x.Checked)
        {
          i++;
          // プログレスバー更新メソッドメソッド使用
          fmPrgBar.UpdPrgBarOprt(i, 20);
          continue;
        }
        // ねずみ返し_検索対象が空の場合
        if (dataStore.ListTbSearch[i].Text == string.Empty)
        {
          i++;
          fmPrgBar.UpdPrgBarOprt(i, 20);
          continue;
        }

        // Regexオプション
        RegexOptions regOption;
        regOption = RegexOptions.None;
        // 大小文字判別
        if (dataStore.IsIgnoreCase)
        {
          // 大小文字判別しない
          regOption = RegexOptions.IgnoreCase;
        }

        /* 置換え */
        // 複数行モード(「^」と「$」の有効化)
        resultStr = Regex.Replace(resultStr, dataStore.ListTbSearch[i].Text, dataStore.ListTbReplace[i].Text, RegexOptions.Multiline);
        // 改行モード判断
        if (dataStore.IsNewLine)
        {
          // 「\n」を改行とする
          resultStr = Regex.Replace(resultStr, @"\\n", Environment.NewLine);
        }

        i++;
        fmPrgBar.UpdPrgBarOprt(i, 20);
      }

      // 置換後文字列設定
      dataStore.ReplacedStr = resultStr;
    }
    #endregion


    #region スタートメソッド
    /// <summary>
    /// スタートメソッド
    /// </summary>
    public Thread Start()
    {
      // メイン処理メソッドスレッドインスタンス生成
      Thread threadA = new Thread(new ThreadStart(MainProcessThread));
      // バックグラウンドフラグ
      threadA.IsBackground = true;

      // プログレスバーフォーム開始位置
      fmPrgBar.StartPosition = FormStartPosition.CenterParent;
      // サイズ設定
      fmPrgBar.Size = new Size(fm1.Size.Width * 3 / 4, 50);

      // スレッドスタート
      threadA.Start();
      // プログレスバーフォーム表示
      fmPrgBar.ShowDialog(fm1);

      return threadA;
    }
    #endregion
  }
}
