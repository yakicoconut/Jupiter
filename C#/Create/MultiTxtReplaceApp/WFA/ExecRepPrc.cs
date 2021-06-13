using System;
using System.Text;
using System.Threading;
using System.IO;
using System.Windows.Forms;
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
    public ExecRepPrc(DataStore _dataStore)
    {
      // データ連携クラス引継ぎ
      dataStore = _dataStore;
    }
    #endregion


    #region 宣言

    // プログレスバーフォーム
    FrmPrgBar fmPrgBar;
    // 複数置換用プログレスバーフォーム
    FrmPrgBar fmPrgBarMltRep;

    // データ連携クラス
    DataStore dataStore;

    #endregion


    #region 単体用置換処理メインメソッド
    /// <summary>
    /// 単体用置換処理メインメソッド
    /// </summary>
    /// <param name="tgtStr"></param>
    /// <returns>置換後文字列</returns>
    public string ExecRepMain(string tgtStr)
    {
      // データ連携クラス置換文字列設定
      dataStore.TgtStr = tgtStr;

      // 単体置換スレッドスタートメソッド使用
      Thread threadA = ExecRepStart();

      // スレッド終了待ち
      threadA.Join();

      // 置換後文字列返却
      return dataStore.ReplacedStr;
    }
    #endregion

    #region 単体置換スレッド処理メソッド
    /// <summary>
    /// 単体置換スレッド処理メソッド
    /// </summary>
    private void ExecRepThread()
    {
      // プログレスバー最大値設定
      fmPrgBar.PrgBarMax = 20;

      // 対象文字列取得
      string resultStr = dataStore.TgtStr;

      // 置換文字列ループ
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

    #region 単体置換スレッドスタートメソッド
    /// <summary>
    /// 単体置換スレッドスタートメソッド
    /// </summary>
    private Thread ExecRepStart()
    {
      // メインフォーム横幅
      int mainFormSizeW = dataStore.MainFormSize.Width;

      // プログレスバーフォーム
      fmPrgBar = new FrmPrgBar();
      // 事前にロードし、非表示としておく
      fmPrgBar.Show();
      fmPrgBar.Visible = false;
      // サイズ設定
      fmPrgBar.Size = new Size(mainFormSizeW * 3 / 4, 50);
      // プログレスバーフォーム開始位置
      fmPrgBar.StartPosition = FormStartPosition.Manual;
      /* 独自設定_複数置換からの呼び出し対策 */
      // 複数置換とかぶらないように下目に表示
      fmPrgBar.Location = new Point(dataStore.MainFormLoca.X + (mainFormSizeW * 1 / 4) / 2, dataStore.MainFormLoca.Y + (dataStore.MainFormSize.Height / 2) - 25);

      // 置換スレッド処理メソッドインスタンス生成
      Thread threadA = new Thread(new ThreadStart(ExecRepThread));
      // バックグラウンドフラグ
      threadA.IsBackground = true;
      // スレッドスタート
      threadA.Start();

      // スレッド内で最大値設定するためフォーム表示を一瞬遅らせる
      Thread.Sleep(500);
      // プログレスバーフォーム表示
      fmPrgBar.ShowDialog();

      return threadA;
    }
    #endregion


    #region 複数用置換処理メインメソッド
    /// <summary>
    /// 複数用置換処理メインメソッド
    /// </summary>
    /// <param name="tgtDirPath"></param>
    /// <param name="fileFltr"></param>
    /// <param name="enc"></param>
    public void ExecRepMain(string tgtDirPath, string fileFltr, Encoding enc)
    {
      // データ連携クラス設定
      dataStore.TgtDirPath = tgtDirPath;
      dataStore.FileFltr = fileFltr;
      dataStore.Enc = enc;

      // 複数置換スレッドスタートメソッド使用
      Thread threadB = ExecMltRepThStart();

      // スレッド終了待ち
      threadB.Join();
    }
    #endregion

    #region 複数置換スレッド処理メソッド
    /// <summary>
    /// 複数置換スレッド処理メソッド
    /// </summary>
    private void ExecMltRepThread()
    {
      // フォルダからXMLファイルのパスだけ取得
      string[] tgtFiles = Directory.GetFiles(dataStore.TgtDirPath, "*", SearchOption.TopDirectoryOnly);

      // プログレスバー最大値設定
      fmPrgBarMltRep.PrgBarMax = tgtFiles.Length;

      // 文字コード取得
      Encoding enc = dataStore.Enc;

      // 対象ファイルループ
      int i = 0;
      foreach (string x in tgtFiles)
      {
        string str = string.Empty;

        // ファイル名取得
        string tgtName = Path.GetFileName(x);

        // ファイル読み込み
        using (StreamReader sr = new StreamReader(x, enc))
        {
          // ファイル内容取得
          str = sr.ReadToEnd();
        }

        // 置換処理メインメソッド使用
        string repedStr = ExecRepMain(str);

        // ファイルを開く
        using (StreamWriter writer = new StreamWriter(tgtName, false, enc))
        {
          // テキストを書き込む
          writer.WriteLine(repedStr);
        }

        i++;
        fmPrgBarMltRep.UpdPrgBarOprt(i);
      }
    }
    #endregion

    #region 複数置換スレッドスタートメソッド
    /// <summary>
    /// 複数置換スレッドスタートメソッド
    /// </summary>
    private Thread ExecMltRepThStart()
    {
      // メインフォーム横幅
      int mainFormSizeW = dataStore.MainFormSize.Width;

      // 複数置換用プログレスバーフォーム
      fmPrgBarMltRep = new FrmPrgBar();
      fmPrgBarMltRep.Show();
      fmPrgBarMltRep.Visible = false;
      // サイズ設定
      fmPrgBarMltRep.Size = new Size(mainFormSizeW * 3 / 4, 50);
      // プログレスバーフォーム開始位置モード
      fmPrgBarMltRep.StartPosition = FormStartPosition.Manual;
      /* 独自設定 */
      // 中心に表示
      fmPrgBarMltRep.Location = new Point(dataStore.MainFormLoca.X + (mainFormSizeW * 1 / 4) / 2, dataStore.MainFormLoca.Y + (dataStore.MainFormSize.Height / 2) - 75);
      // 親フォームのスレッドから作成のため、表示は裏にいかないのでタスクバー非表示
      fmPrgBarMltRep.ShowInTaskbar = false;

      // 置換スレッド処理メソッドインスタンス生成
      Thread threadB = new Thread(new ThreadStart(ExecMltRepThread));
      // バックグラウンドフラグ
      threadB.IsBackground = true;
      // スレッドスタート
      threadB.Start();

      // スレッド内で最大値設定するためフォーム表示を一瞬遅らせる
      Thread.Sleep(500);
      // プログレスバーフォーム表示
      fmPrgBarMltRep.ShowDialog();

      return threadB;
    }
    #endregion
  }
}
