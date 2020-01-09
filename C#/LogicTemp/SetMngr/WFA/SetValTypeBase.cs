using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * ForYouApplications.POS4U.Framework.Utility.SettingValueTypeBase
 * \Framework\POS4U.Framework.Utility\Setting\SettingValueTypeBase.cs
 */
/*
 * 抽象クラス
 * 継承元クラス
 *   SetValBase
 * 参照先クラス
 *   なし
 */
namespace WFA
{
  /// <summary>
  /// 設定値クラス
  /// </summary>
  /// <typeparam name="T">型</typeparam>
  public abstract class SetValTypeBase<T> : SetValBase
  {
    #region コンストラクタ
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="key">キー</param>
    /// <param name="defaultValue">ディフォルト値</param>
    protected SetValTypeBase(string key, T defaultValue) : base(key)
    {
      this.HasValue = false;
      this.DefaultValue = defaultValue;
    } 
    #endregion


    #region プロパティ

    /// <summary>
    /// 値
    /// </summary>
    protected T Value { get; private set; }

    /// <summary>
    /// デフォルト値
    /// </summary>
    protected T DefaultValue { get; private set; }

    /// <summary>
    /// デフォルト値
    /// </summary>
    protected bool HasValue { get; private set; }
        
    #endregion


    #region 値変換メソッド
    /// <summary>
    /// 値変換
    /// </summary>
    /// <param name="val">変換元値</param>
    /// <returns>変換後値</returns>
    protected internal abstract T ConvertToValue(string val); 
    #endregion

    #region ファイル保存有効値変換メソッド
    /// <summary>
    /// ファイル保存用の値に戻す
    /// </summary>
    /// <param name="val">変換元値</param>
    /// <returns>変換後値</returns>
    protected internal override string ConvertBackToValue(object val)
    {
      return this.ConvertBackToValue((T)val);
    } 
    #endregion

    #region 新値設定メソッド
    /// <summary>
    /// 新しい値を設定する
    /// </summary>
    /// <param name="newVal">新しい値</param>
    protected internal override void SetNewValue(object newVal)
    {
      this.Value = (T)newVal;

      this.HasValue = true;
    } 
    #endregion

    #region 値取得メソッド
    /// <summary>
    /// String値を返す
    /// </summary>
    /// <param name="keyValueDic">キーバリューDic</param>
    /// <returns>
    /// 変換された設定値
    /// </returns>
    protected internal T GetValue(Dictionary<string, string> keyValueDic)
    {
      if (!this.HasValue)
      {
        string value;
        if (keyValueDic.TryGetValue(this.Key, out value))
        {
          this.Value = this.ConvertToValue(value);
        }
        else
        {
          this.Value = this.DefaultValue;
        }

        this.HasValue = true;
      }

      return this.Value;
    } 
    #endregion

    #region ファイル保存有効値変換メソッド
    /// <summary>
    /// ファイル保存用の値に戻す
    /// </summary>
    /// <param name="val">変換元値</param>
    /// <returns>変換後値</returns>
    protected virtual string ConvertBackToValue(T val)
    {
      return Convert.ToString(val);
    } 
    #endregion
   }
}
