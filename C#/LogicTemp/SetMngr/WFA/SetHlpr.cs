using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

/*
 * ForYouApplications.POS4U.Framework.Utility.SettingsHelper
 * \Framework\POS4U.Framework.Utility\SettingsHelper.cs
 */
/*
 * 基底クラス
 * 参照先クラス
 *   SetValBase.cs
 *   SetValTypeBase.cs
 */
namespace WFA
{
  /// <summary>
  /// 設定ヘルパークラス
  /// </summary>
  public class SetHlpr
  {
    #region プロパティ

    /// <summary>
    /// キーと設定値の保持Dictionary
    /// </summary>
    public Dictionary<string, string> KeyValueDic { get; set; }
    
    #endregion


    #region キー返却メソッド
    /// <summary>
    /// 設定キーを返す
    /// </summary>
    /// <param name="setValBaseCls">キー情報クラス</param>
    /// <returns>キー</returns>
    public string GetKey(SetValBase setValBaseCls)
    {
      return setValBaseCls.Key;
    } 
    #endregion

    #region 値返却メソッド
    /// <summary>
    /// 値を返す
    /// </summary>
    /// <param name="setValTypeBaseCls">設定値クラス</param>
    /// <returns>
    /// 変換された設定値
    /// </returns>
    public T GetValue<T>(SetValTypeBase<T> setValTypeBaseCls)
    {
      return setValTypeBaseCls.GetValue(this.KeyValueDic);
    } 
    #endregion

    #region 値変換メソッド
    /// <summary>
    /// 値変換
    /// </summary>
    /// <param name="key">キー</param>
    /// <param name="val">変換元値</param>
    /// <returns>変換後値</returns>
    public T ConvertToValue<T>(SetValTypeBase<T> key, string val)
    {
      return key.ConvertToValue(val);
    } 
    #endregion

    #region 値保存メソッド
    /// <summary>
    /// 値を保存用Stringに変換する
    /// </summary>
    /// <param name="key">設定キー</param>
    /// <param name="val">変換元値</param>
    /// <returns>変換後値</returns>
    public string ConvertBackToValue(SetValBase key, object val)
    {
      return key.ConvertBackToValue(val);
    } 
    #endregion

    #region 値設定メソッド
    /// <summary>
    /// 新しい値を設定する
    /// </summary>
    /// <param name="key">設定キー</param>
    /// <param name="newVal">新しい値</param>
    public void SetNewValue(SetValBase key, object newVal)
    {
      key.SetNewValue(newVal);
    } 
    #endregion
  }
}
