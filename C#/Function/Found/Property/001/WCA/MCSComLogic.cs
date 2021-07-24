﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace WCA
{
  /// <summary>
  /// 共通ロジッククラス
  /// </summary>
  class MCSComLogic
  {
    #region コンストラクタ
    public MCSComLogic()
    {

    }
    #endregion


    #region 宣言

    #endregion


    #region ログ出力メソッド
    /// <summary>
    /// ログ出力メソッド
    /// </summary>
    /// <param name="logText">ログ出力文字列</param>
    public void WriteLog(string logText)
    {
      try
      {
        DateTime now = DateTime.Now;
        string fileName = now.ToString("yyyyMMdd") + Path.GetFileName(Assembly.GetExecutingAssembly().Location) + ".log";
        File.AppendAllText(fileName, now.ToString("yyyy/MM/dd HH:mm:ss.fff ") + logText + Environment.NewLine, Encoding.UTF8);
      }
      catch (Exception e)
      {

      }
    }
    #endregion

    #region 詳細ログ出力メソッド
    /// <summary>
    /// 詳細ログ出力メソッド
    /// </summary>
    /// <param name="dirPath">出力フォルダパス</param>
    /// <param name="fileName">出力ファイル名</param>
    /// <param name="logText">ログ出力文字列</param>
    public void WriteDetailLog(string dirPath, string fileName, string logText)
    {
      try
      {
        // フォルダ存在確認
        if (!Directory.Exists(dirPath))
        {
          Directory.CreateDirectory(dirPath);
        }

        DateTime now = DateTime.Now;
        fileName = now.ToString("yyyyMMddHHmmss") + fileName + ".log";
        File.AppendAllText(Path.Combine(dirPath, fileName), logText + Environment.NewLine, Encoding.UTF8);
      }
      catch (Exception e)
      {

      }
    }
    #endregion

    #region コンフィグ設定取得メソッド
    /// <summary>
    /// コンフィグ設定取得メソッド
    /// </summary>
    /// <param name="key">対象キー</param>
    /// <param name="defaultValue">デフォルト値</param>
    /// <returns>コンフィグ値</returns>
    public string GetConfigValue(string key, string defaultValue)
    {
      // コンフィグから値を取得
      string value = ConfigurationManager.AppSettings[key];

      // コンフィグに値がある場合
      if (value != null)
      {
        return value;
      }
      else
      {
        WriteLog(string.Format("GetValueString : Key {0} has not found", key));
        return defaultValue;
      }
    }
    #endregion
  }
}
