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
  public class ExecRepPrc
  {
    #region コンストラクタ
    public ExecRepPrc(Form1 _fm1, DataStore _dataStore)
    {
      // 呼び出し元フォームの設定
      fm1 = _fm1;

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


    #region 置換スレッド処理メソッド
    /// <summary>
    /// 置換スレッド処理メソッド
    /// </summary>
    private void ExecRepThread()
    {
      string resultStr = dataStore.TgtStr;

      // プログレスバー最大値設定
      fmPrgBar.PrgBarMax = 20;
      int i = 0;
      foreach (CheckBox x in dataStore.ListChkBox)
      {
        // ねずみ返し_チェックが付いていない場合
        if (!x.Checked)
        {
          i++;
          // プログレスバー更新メソッドメソッド使用
          fmPrgBar.UpdPrgBarOprt(i);
          continue;
        }
        // ねずみ返し_検索対象が空の場合
        if (dataStore.ListTbSearch[i].Text == string.Empty)
        {
          i++;
          fmPrgBar.UpdPrgBarOprt(i);
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
        // タブモード判断
        if (dataStore.IsTab)
        {
          // 「\t」をタブ文字とする
          resultStr = Regex.Replace(resultStr, @"\\t", "\t");
        }

        i++;
        fmPrgBar.UpdPrgBarOprt(i);
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
      // 置換スレッド処理メソッドインスタンス生成
      Thread threadA = new Thread(new ThreadStart(ExecRepThread));
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
