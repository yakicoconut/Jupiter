using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Xml;

/*
 * ForYouApplications.POS4U.Framework.Utility.SettingsManager
 * \Framework\POS4U.Framework.Utility\SettingsManager.cs
 */
/*
 * 基底クラス
 * 参照先クラス
 *   SetHlpr.cs
 *   SetValTypeBase.cs
 *   SetValBase.cs
 *   SettingsInfo内部クラス
 */
/*
 * 設定Xml内容取得
 *   コンストラクタからvoid Init()メソッドを
 *   呼び出し、設定Xmlの値を取得する
 * 設定値呼び出し
 *   SetHlpr.T GetValue<T>(SetValTypeBase<T> key)メソッド使用
 */
namespace WFA
{
  /// <summary>
  /// 設定マネジャークラス
  /// </summary>
  public static class SetMngr
  {
    #region コンストラクタ
    /// <summary>
    /// コンストラクタ
    /// </summary>
    static SetMngr()
    {
      // 初期化メソッド使用
      Init();
    }
    #endregion


    #region 宣言

    /// <summary>
    /// コンフィグから取得する
    /// 対象設定ファイル名一覧のキー名称
    /// </summary>
    private const string SETTING_FILES = "SettingFiles";

    /// <summary>
    /// 排他制御用オブジェクト
    /// </summary>
    private static object _lockObj = new object();

    /// <summary>
    /// 設定ヘルパークラス
    /// </summary>
    private static SetHlpr _helper = new SetHlpr();

    #endregion

    #region プロパティ

    /// <summary>
    /// キー別情報ディクショナリ
    /// [キー名称, SettingsInfoクラス[キー名称, 設定値, Xmlファイル名]]
    /// </summary>
    private static Dictionary<string, SettingsInfo> KeySettingInfoDic { get; set; }
    
    #endregion


    #region 初期化メソッド
    /// <summary>
    /// 初期化処理
    /// </summary>
    private static void Init()
    {
      // コンフィグから読み込み対象設定ファイル名一覧取得
      string[] settingFileNames = ConfigurationManager.AppSettings[SETTING_FILES].Split(',');

      // キー別情報ディクショナリローカル変数
      Dictionary<string, SettingsInfo> keySettingInfoDic = new Dictionary<string, SettingsInfo>();
      // キー別値ディクショナリローカル変数
      // [キー名称, 設定値]
      Dictionary<string, string> keyValueDic = new Dictionary<string, string>();

      // 取得した設定ファイル一覧ループ
      foreach (string settingFileName in settingFileNames)
      {
        // ねずみ返し_対象設定がない場合
        if (string.IsNullOrEmpty(settingFileName))
        {
          continue;
        }

        // Xmlオープン
        /*
         * 対象Xml例
         *   <settings xmlns="http://www.4uapplications.com/POS4U/settings.xsd">
         *     <setting key="abc" value="def"/>
         *   </settings>  
         */
        using (XmlTextReader reader = new XmlTextReader(settingFileName))
        {
          SettingsInfo settings = null;
          while (reader.Read())
          {
            // ノードタイプで分岐
            switch (reader.NodeType)
            {
              // 要素の場合
              case XmlNodeType.Element:
                // 要素名で分岐
                switch (reader.Name)
                {
                  case "setting":
                    // 次属性へ
                    while (reader.MoveToNextAttribute())
                    {
                      // 属性名で分岐
                      switch (reader.Name)
                      {
                        case "key":
                          // SettingsInfo内部クラスインスタンス生成
                          settings = new SettingsInfo();
                          // キー変数に属性名称設定
                          settings.Key = reader.Value;
                          // ファイル名変数にオープンしているXmlファイル名設定
                          settings.FileName = settingFileName;
                          break;

                        case "value":
                          // 「value」属性は必ず、「key」属性に対応するため
                          // 改めてインスタンス生成はしない

                          // 値変数に属性値設定
                          settings.Value = reader.Value;

                          // キー別情報ディクショナリ追加
                          keySettingInfoDic.Add(settings.Key, settings);
                          // キー別値ディクショナリ追加
                          keyValueDic.Add(settings.Key, settings.Value);

                          settings = null;
                          break;

                        default:
                          break;
                      }
                    }
                    break;

                  default:
                    break;
                }
                break;

              // 終了要素の場合
              case XmlNodeType.EndElement:
                settings = null;
                break;
            }
          }
        }
      }

      // キー別情報ディクショナリプロパティへ引継ぎ
      KeySettingInfoDic = keySettingInfoDic;
      // 設定ヘルパークラスのディクショナリへ引継ぎ      
      _helper.KeyValueDic = keyValueDic;
    }
    #endregion


    #region 設定値呼出しメソッド
    /// <summary>
    /// 値を返す
    /// </summary>
    /// <param name="key">キー</param>
    /// <returns>
    /// 変換された設定値
    /// </returns>
    public static T GetValue<T>(SetValTypeBase<T> key)
    {
      return _helper.GetValue(key);
    }
    #endregion

    #region 値保存メソッド
    /// <summary>
    /// 設定値保存
    /// </summary>
    /// <param name="saveValues">保存設定値</param>
    public static void Save(SetSaveVal saveValues)
    {
      lock (_lockObj)
      {
        Dictionary<string, Dictionary<string, string>> dicFile =
            new Dictionary<string, Dictionary<string, string>>();

        Dictionary<SetValBase, object> settingValues = saveValues.GetSaveValues();

        foreach (KeyValuePair<SetValBase, object> pair in settingValues)
        {
          SettingsInfo info;
          if (KeySettingInfoDic.TryGetValue(_helper.GetKey(pair.Key), out info))
          {
            if (!dicFile.ContainsKey(info.FileName))
            {
              Dictionary<string, string> l = new Dictionary<string, string>();
              dicFile.Add(info.FileName, l);
            }

            dicFile[info.FileName].Add(
                _helper.GetKey(pair.Key),
                _helper.ConvertBackToValue(pair.Key, pair.Value));
          }
          else
          {
            throw new ArgumentException(string.Format("key = {0}, newValue = {1}", _helper.GetKey(pair.Key), pair.Value));
          }
        }

        Dictionary<string, XmlDocument> saveFiles = new Dictionary<string, XmlDocument>();

        foreach (KeyValuePair<string, Dictionary<string, string>> fileValues in dicFile)
        {
          XmlDocument xDoc = new XmlDocument();
          xDoc.Load(fileValues.Key);

          Dictionary<string, string> vals = fileValues.Value;

          foreach (XmlNode node1 in xDoc.ChildNodes)
          {
            if (node1.Name == "settings")
            {
              foreach (XmlNode node2 in node1.ChildNodes)
              {
                if (node2.Name == "setting")
                {
                  string xmlKey = node2.Attributes["key"].Value;
                  string newVal;
                  if (vals.TryGetValue(xmlKey, out newVal))
                  {
                    node2.Attributes["value"].Value = newVal;
                    vals.Remove(xmlKey);
                  }
                }
              }
            }
          }

          if (vals.Count != 0)
          {
            StringBuilder stb = new StringBuilder();
            foreach (KeyValuePair<string, string> pair in vals)
            {
              stb.Append(string.Format("(key = {0}, val = {1})", pair.Key, pair.Value));
            }

            throw new ArgumentException(stb.ToString());
          }

          saveFiles.Add(fileValues.Key, xDoc);
        }

        foreach (KeyValuePair<string, XmlDocument> saveFile in saveFiles)
        {
          saveFile.Value.Save(saveFile.Key);
        }

        foreach (KeyValuePair<SetValBase, object> newSetting in settingValues)
        {
          _helper.SetNewValue(newSetting.Key, newSetting.Value);
        }
      }
    }
    #endregion


    #region デバッグ用メソッド
    /// <summary>
    /// デバッグ用メソッド
    /// 設定漏れがないかの確認を行う。
    /// </summary>
    /// <param name="type">
    /// 検査クラス
    /// </param>
    [System.Diagnostics.Conditional("DEBUG")]
    public static void DebugVerify(Type type)
    {
      System.Reflection.FieldInfo[] fields = type.GetFields(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);

      foreach (System.Reflection.FieldInfo field in fields)
      {
        if (field.GetValue(null) == null)
        {
          throw new NotImplementedException(field.Name);
        }
      }
    }
    #endregion


    #region 設定キーと値情報クラス
    /// <summary>
    /// 設定キーと値情報
    /// </summary>
    private class SettingsInfo
    {
      /// <summary>
      /// キー名称
      /// </summary>
      public string Key { get; set; }

      /// <summary>
      /// 設定値
      /// </summary>
      public string Value { get; set; }

      /// <summary>
      /// ファイル名
      /// </summary>
      public string FileName { get; set; }
    }
    #endregion
  }
}
