using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;

/*
 * C#による辞書(Dictionary)型とその値のソート - Qiita
 * https://qiita.com/Jane35416555/items/11908638a789527891c8
 *     C# の Dictionary 同士を簡単にマージする方法 - Qiita
 * https://qiita.com/Nossa/items/802b0e0de927c0cfec05
 *     C# - ラムダ式っていうのが分かりません｜teratail
 * https://teratail.com/questions/149408
 *     C# 今更ですが、ラムダ式 - Qiita
 * https://qiita.com/rawr/items/11790e9ea08a29d028a4
 *     ラムダ式 - C# によるプログラミング入門 | ++C++; // 未確認飛行 C
 * https://ufcpp.net/study/csharp/sp3_lambda.html
 */
namespace WCA
{
  /// <summary>
  /// メインプログラム
  /// </summary>
  class Program
  {
    #region 宣言

    // 共通ロジッククラスインスタンス
    static MCSComLogic _comLogic = new MCSComLogic();

    // 出力対象ディレクトリパス書式
    static string FORMAT_DIR_NAME = Environment.NewLine + " {0} のディレクトリ" + Environment.NewLine;
    // 出力対象ファイル情報書式
    static string FORMAT_OBJ_INFO = "{0} {1} {2}";
    // 出力親フォルダファイル個数情報書式
    static string FORMAT_PARENT_FILECOUNT = "               {0} 個のファイル";
    // 出力親フォルダフォルダ個数情報書式
    static string FORMAT_PARENT_DIRCOUNT = "               {0} 個のディレクトリ";
    // ヘルプ内容
    static string HELP = "ヘルプ";

    #endregion


    #region メインメソッド
    static void Main(string[] args)
    {
      // ねずみ返し_引数がない場合
      if (args.Length <= 0)
      {
        Console.WriteLine("※本ファイルは単体で実行しないでください");
        Console.WriteLine("終了します");
        Console.ReadKey();
        return;
      }

      // 引数ループメソッド使用
      string targetArg = LoopArgs(args);

      // ヘルプオプションが存在する場合
      if (Option.IsHelpFlg)
      {
        // ヘルプを表示して終了
        Console.WriteLine(HELP);
        return;
      }

      // 対象がファイルの場合
      if (File.Exists(targetArg))
      {
        // ハッシュ取得メソッド使用
        string hash = GetHash.GetFileCheckSum(targetArg);
        Console.WriteLine(FORMAT_OBJ_INFO, hash, "     ", targetArg);
      }

      // 対象がフォルダの場合
      if (Directory.Exists(targetArg))
      {
        // フォルダ探索メソッド使用
        DigDir(targetArg);
      }

      Console.ReadKey();
    }
    #endregion


    #region 引数ループメソッド
    private static string LoopArgs(string[] args)
    {
      // オプション外引数
      StringBuilder sb = new StringBuilder();

      // 引数ループ
      foreach (string x in args)
      {
        // ねずみ返し_一文字目が「/」(オプション)でない場合
        if (x.Substring(0, 1) != "/")
        {
          // 空の場合
          if (sb.ToString() == string.Empty)
          {
            // オプション外引数に追加
            sb.Append(x);
          }
          else
          {
            // 半角スペースを頭につける
            sb.Append(" " + x);
          }

          continue;
        }

        // オプション解析
        OptionSwitch(x);
      }

      return sb.ToString();
    }
    #endregion

    #region オプション解析
    private static void OptionSwitch(string option)
    {
      // 二文字目スイッチ
      switch (option.Substring(1, 1).ToUpper())
      {
        // 属性指定
        case "A":
          // フラグオン
          Option.IsAttributeFlg = true;
          break;

        // ソート順
        case "O":
          Option.IsSortFlg = true;
          break;

        // サブディレクトリ対象
        case "S":
          Option.IsSubDirFlg = true;
          break;

        // ヘルプ
        case "?":
          Option.IsHelpFlg = true;
          break;

        default:
          break;
      }
    }
    #endregion


    #region フォルダ探索メソッド
    private static void DigDir(string targetDir)
    {
      // 対象フォルダ内ファイル探索
      string[] files = Directory.GetFiles(targetDir, "*", SearchOption.TopDirectoryOnly);
      // ディクショナリ変換(ファイル当否はすべて真)
      Dictionary<string, bool> topDirFiles = files.ToDictionary(n => n, n => true);

      // 対象フォルダ内フォルダ探索
      string[] dirs = Directory.GetDirectories(targetDir, "*", SearchOption.TopDirectoryOnly);
      // ディクショナリ変換(ファイル当否はすべて偽)
      Dictionary<string, bool> topDirDirs = dirs.ToDictionary(n => n, n => false);
      
      // ディレクトリとファイルの混合表示とするためディクショナリ結合
      IEnumerable<KeyValuePair<string, bool>> topDirObj = topDirFiles.Concat(topDirDirs);
      // キー昇順にソート
      topDirObj = topDirObj.OrderBy(x => x.Key);

      // ディレクトリ名表示
      Console.WriteLine(string.Format(FORMAT_DIR_NAME, Path.GetDirectoryName(targetDir)));
      // 対象オブジェクトループ
      foreach (KeyValuePair<string, bool> x in topDirObj)
      {
        // ファイル/フォルダ名称取得
        string objName = Path.GetFileName(x.Key);

        // ファイルでない場合
        if (!x.Value)
        {
          Console.WriteLine(FORMAT_OBJ_INFO, "        ", "<DIR>", objName);
          continue;
        }

        // ハッシュ取得メソッド使用
        string hash = GetHash.GetFileCheckSum(x.Key);
        Console.WriteLine(FORMAT_OBJ_INFO, hash, "     ", objName);
      }

      // ファイル個数表示
      Console.WriteLine(string.Format(FORMAT_PARENT_FILECOUNT, topDirFiles.Count));
      // フォルダ個数表示
      Console.WriteLine(string.Format(FORMAT_PARENT_DIRCOUNT, topDirDirs.Count));

      // サブディレクトリフラグがオンの場合
      if (Option.IsSubDirFlg)
      {
        // フォルダループ
        foreach (string x in dirs)
        {
          // 自身を回帰呼び出し
          DigDir(x);
        }
      }
    }
    #endregion


    #region ハッシュ取得クラス
    /// <summary>
    /// ハッシュ取得クラス
    /// </summary>
    public static class GetHash
    {
      #region ハッシュ取得メソッド
      /// <summary>
      /// 物理ファイルチェックサム(ハッシュ)取得メソッド
      /// </summary>
      /// <param name="fileName">ファイル名</param>
      /// <returns>8桁チェックサム(CRC32)</returns>
      public static string GetFileCheckSum(string fileName)
      {
        try
        {
          // ファイルオープン
          using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
          {
            // ストリングビルダーインスタンス
            StringBuilder sb = new StringBuilder();

            // ねずみ返しファイルがnullの場合
            if (fs == null)
            {
              return sb.ToString();
            }

            // ハッシュ計算クラスインスタンス
            using (HashAlgorithm hashAlgorithm = new CRC32())
            {
              // ハッシュ計算
              byte[] hash = hashAlgorithm.ComputeHash(fs);
              foreach (byte b in hash)
              {
                sb.Append(b.ToString("X2"));
              }
            }
            return sb.ToString();
          }
        }
        catch (Exception e)
        {
          return e.ToString();
        }
      }
      #endregion
    }
    #endregion


    #region オプションクラス
    public static class Option
    {
      #region プロパティ

      // 属性指定フラグ
      public static bool IsAttributeFlg { get; set; }

      // ソート順フラグ
      public static bool IsSortFlg { get; set; }

      // サブディレクトリフラグ
      public static bool IsSubDirFlg { get; set; }

      // ヘルプフラグ
      public static bool IsHelpFlg { get; set; }

      #endregion
    }
    #endregion


    #region テンプレートメソッド
    private static void template()
    {

    }
    #endregion
  }
}
