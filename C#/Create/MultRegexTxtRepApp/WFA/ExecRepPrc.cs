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
    FrmPrgBar frmPrgBar;
    // 複数置換用プログレスバーフォーム
    FrmPrgBar frmPrgBarMultRep;

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

    #region 単体置換スレッドスタートメソッド
    /// <summary>
    /// 単体置換スレッドスタートメソッド
    /// </summary>
    private Thread ExecRepStart()
    {
      // メインフォーム横幅
      int mainFormSizeW = dataStore.MainFormSize.Width;

      // プログレスバーフォーム
      frmPrgBar = new FrmPrgBar();
      // 事前にロードし、非表示としておく
      frmPrgBar.Show();
      frmPrgBar.Visible = false;
      // サイズ設定
      frmPrgBar.Size = new Size(mainFormSizeW * 3 / 4, 50);
      // プログレスバーフォーム開始位置
      frmPrgBar.StartPosition = FormStartPosition.Manual;
      /* 独自設定_複数置換からの呼び出し対策 */
      // 複数置換とかぶらないように下目に表示
      frmPrgBar.Location = new Point(dataStore.MainFormLoca.X + (mainFormSizeW * 1 / 4) / 2, dataStore.MainFormLoca.Y + (dataStore.MainFormSize.Height / 2) - 25);

      // 置換スレッド処理メソッドインスタンス生成
      Thread threadA = new Thread(new ThreadStart(ExecRepThread));
      // バックグラウンドフラグ
      threadA.IsBackground = true;
      // スレッドスタート
      threadA.Start();

      // スレッド内で最大値設定するためフォーム表示を一瞬遅らせる
      Thread.Sleep(500);
      // プログレスバーフォーム表示
      frmPrgBar.ShowDialog();

      return threadA;
    }
    #endregion

    #region 単体置換スレッド処理メソッド
    /// <summary>
    /// 単体置換スレッド処理メソッド
    /// </summary>
    private void ExecRepThread()
    {
      // プログレスバー最大値設定
      frmPrgBar.PrgBarMax = 20;

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
          frmPrgBar.UpdPrgBarOprt(i);
          continue;
        }
        // ねずみ返し_検索対象が空の場合
        if (dataStore.ListTbSearch[i].Text == string.Empty)
        {
          i++;
          frmPrgBar.UpdPrgBarOprt(i);
          continue;
        }

        // Regexオプション
        RegexOptions regOpt;
        // 「^」、「$」有効化
        regOpt = RegexOptions.Multiline;
        // 大小文字区別しない場合
        if (!dataStore.IsCaseSens)
        {
          // 大小文字判別しないを追加
          regOpt |= RegexOptions.IgnoreCase;
        }

        /* 置換え */
        // 複数行モード
        resultStr = Regex.Replace(resultStr, dataStore.ListTbSearch[i].Text, dataStore.ListTbReplace[i].Text, regOpt);
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
        frmPrgBar.UpdPrgBarOprt(i);
      }

      // 置換後文字列設定
      dataStore.ReplacedStr = resultStr;
    }
    #endregion


    #region 複数用置換処理メインメソッド
    /// <summary>
    /// 複数用置換処理メインメソッド
    /// </summary>
    public void ExecDirRepMain()
    {
      // 複数置換スレッドスタートメソッド使用
      Thread threadB = ExecDirRepThStart();

      // スレッド終了待ち
      threadB.Join();
    }
    #endregion

    #region 複数置換スレッドスタートメソッド
    /// <summary>
    /// 複数置換スレッドスタートメソッド
    /// </summary>
    private Thread ExecDirRepThStart()
    {
      // メインフォーム横幅
      int mainFormSizeW = dataStore.MainFormSize.Width;

      // 複数置換用プログレスバーフォーム
      frmPrgBarMultRep = new FrmPrgBar();
      frmPrgBarMultRep.Show();
      frmPrgBarMultRep.Visible = false;
      // サイズ設定
      frmPrgBarMultRep.Size = new Size(mainFormSizeW * 3 / 4, 50);
      // プログレスバーフォーム開始位置モード
      frmPrgBarMultRep.StartPosition = FormStartPosition.Manual;
      /* 独自設定 */
      // 中心に表示
      frmPrgBarMultRep.Location = new Point(dataStore.MainFormLoca.X + (mainFormSizeW * 1 / 4) / 2, dataStore.MainFormLoca.Y + (dataStore.MainFormSize.Height / 2) - 75);
      // 親フォームのスレッドから作成のため、表示は裏にいかないのでタスクバー非表示
      frmPrgBarMultRep.ShowInTaskbar = false;

      // 置換スレッド処理メソッドインスタンス生成
      Thread threadB = new Thread(new ThreadStart(ExecDirRepThread));
      // バックグラウンドフラグ
      threadB.IsBackground = true;
      // スレッドスタート
      threadB.Start();

      // スレッド内で最大値設定するためフォーム表示を一瞬遅らせる
      Thread.Sleep(500);
      // プログレスバーフォーム表示
      frmPrgBarMultRep.ShowDialog();

      return threadB;
    }
    #endregion

    #region 複数置換スレッド処理メソッド
    /// <summary>
    /// 複数置換スレッド処理メソッド
    /// </summary>
    private void ExecDirRepThread()
    {
      // フォルダからXMLファイルのパスだけ取得
      string[] tgtFiles = Directory.GetFiles(dataStore.TgtDirPath, dataStore.FileFilter, SearchOption.TopDirectoryOnly);

      // 対象ファイル数
      int tgtFileLen = tgtFiles.Length;

      // プログレスバー最大値設定
      frmPrgBarMultRep.PrgBarMax = tgtFileLen;
      if (tgtFileLen == 0)
      {
        // プログレスバーフォームを閉じるため更新
        frmPrgBarMultRep.UpdPrgBarOprt(0);
        return;
      }

      // 文字コード取得
      Encoding enc = dataStore.Enc;

      // 出力フォルダ作成
      string outDirName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
      string outDir = string.Format(@"{0}\{1}", dataStore.DestDirPath, outDirName);
      Directory.CreateDirectory(outDir);

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
        using (StreamWriter writer = new StreamWriter(string.Format(@"{0}\{1}", outDir, tgtName), false, enc))
        {
          // テキストを書き込む
          writer.WriteLine(repedStr);
        }

        i++;
        frmPrgBarMultRep.UpdPrgBarOprt(i);
      }
    }
    #endregion
  }
}
