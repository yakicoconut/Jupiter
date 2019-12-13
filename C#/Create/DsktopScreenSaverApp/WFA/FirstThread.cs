using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Windows.Forms;

namespace WFA
{
  /// <summary>
  /// 主スレッド処理クラス
  /// </summary>
  class FirstThread
  {
    #region コンストラクタ
    public FirstThread(Form fm1, AssignThreadProcessCallback assignThreadProcess)
    {
      // 呼び出し元フォームの設定
      fm = fm1;
      // デリゲート引継ぎ
      dlgAssignThreadProcess = assignThreadProcess;
    }
    #endregion


    #region 宣言

    // 一時停止イベント
    AutoResetEvent autoResetEvent = new AutoResetEvent(false);

    // フォーム変数
    Form fm;
    // ピクチャボックス更新メソッド用のデリゲート宣言
    public delegate void AssignThreadProcessCallback(string str);
    AssignThreadProcessCallback dlgAssignThreadProcess;
    
    // 画像ファイル拡張子
    List<string> ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG" };

    #endregion


    #region プロパティ

    /// <summary>
    /// 対象フォルダパス
    /// </summary>
    public string TargetDir { get; set; }

    /// <summary>
    /// 完了フラグ
    /// </summary>
    public bool EndFlag { get; set; }

    /// <summary>
    /// 表示時間(ミリ秒)
    /// </summary>
    public int ViewTime { get; set; }

    /// <summary>
    /// 表示時間倍数数
    /// </summary>
    public int ViewTimeMultiple { get; set; }

    #endregion


    #region 主要スレッド処理メソッド

    // 排他ロック用変数
    private readonly object _lockObj = new object();

    /// <summary>
    /// 主要スレッドメソッド
    /// </summary>
    /// <param name="obj"></param>
    public void PrimeThread(Object obj)
    {
      // デフォルトファイル設定
      string path = string.Empty;

      // 対象フォルダからファイル取得
      var files = Directory.GetFiles(TargetDir);

      // ファイルループ
      for (int i = 0; i <= files.Length; i++)
      {
        // ファイル最大値に達した場合
        if (i == (files.Length))
        {
          // 無限ループ
          i = 0;
        }

        // 対象ファイル拡張子が画像でない場合
        if (!ImageExtensions.Contains(Path.GetExtension(files[i]).ToUpperInvariant()))
        {
          continue;
        }

        // ファイル設定
        path = files[i];

        // スレッド処理振り分けメソッド使用
        dlgAssignThreadProcess(path);

        // 表示時間倍数待機
        for (int j = 1; j <= ViewTimeMultiple; j++)
        {
          // ねずみ返し_完了フラグ
          if (EndFlag)
          {
            return;
          }
          Thread.Sleep(ViewTime);
        }
      }
    }

    #endregion


    #region 雛形メソッド
    public void template()
    {

    }
    #endregion
  }
}
