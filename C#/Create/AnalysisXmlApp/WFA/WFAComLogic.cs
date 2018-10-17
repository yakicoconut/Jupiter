using System.Reflection;
using System.IO;
using System.Configuration;

namespace WFA
{
  /// <summary>
  /// フォームアプリ共通ロジッククラス
  /// </summary>
  class WFAComLogic : MCSComLogic
  {
    #region コンストラクタ
    public WFAComLogic()
    {

    }
    #endregion


    #region 宣言

    #endregion


    #region アプリ名取得
    /// <summary>
    /// アプリ名取得
    /// </summary>
    /// <returns>アプリ名</returns>
    public string GetAppName()
    {
      // 自身のファイル名取得
      string exeName = Path.GetFileName(Assembly.GetExecutingAssembly().Location);

      // コンフィグからアプリ名を取得
      string appName = GetConfigValue("AppName", exeName);

      // RereaseかAuto指定の場合
      if (appName == "Rerease" || appName == "Auto")
      {
        // 自身のファイル名を返す
        return exeName;
      }
      // 更にDebugでない場合
      else if (appName != "Debug")
      {
        // コンフィグに設定されている値を返す
        return appName;
      }

      // 自身のフォルダパス取得
      string folderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

      // 変数初期化
      int lastYenIndex = folderPath.LastIndexOf(@"\") - 1;
      string debugFolder = folderPath;

      // 三つ上のフォルダパス取得ループ
      for (int i = 0; i < 3; i++)
      {
        // 最下層フォルダ名除去
        debugFolder = debugFolder.Substring(1, lastYenIndex);

        // 文末から最初の「\」-1の位置を取得
        lastYenIndex = debugFolder.LastIndexOf(@"\") - 1;
      }

      // デバッグフォルダ名取得
      debugFolder = debugFolder.Substring(lastYenIndex + 2, debugFolder.Length - lastYenIndex - 2);

      // フォルダ名を返す
      return debugFolder;
    }
    #endregion
  }
}
