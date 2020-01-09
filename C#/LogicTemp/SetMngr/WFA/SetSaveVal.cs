using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * ForYouApplications.POS4U.Framework.Utility.SettingsSaveValues
 * \Framework\POS4U.Framework.Utility\SettingsSaveValues.cs
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
  /// 設定値保存処理引数クラス
  /// </summary>
  public class SetSaveVal
  {
    #region コンストラクタ
    /// <summary>
    /// コンストラクタ
    /// </summary>
    public SetSaveVal()
    {
    }
    #endregion


    #region プロパティ

    /// <summary>
    /// 設定キー-新値Dic
    /// 設定キーと新しい設定値
    /// </summary>
    private Dictionary<SetValBase, object> _dic = new Dictionary<SetValBase, object>();
    
    #endregion
    

    #region 値追加メソッド
    /// <summary>
    /// 値を追加する
    /// </summary>
    /// <param name="key">キー</param>
    /// <param name="newValue">
    /// 新しい値
    /// </param>
    public void AddValue<T>(SetValTypeBase<T> key, T newValue)
    {
      // 設定キー-新値Dicプロパティに追加
      this._dic.Add(key, newValue);
    }
    #endregion

    #region 設定キー-新値Dic返却メソッド
    /// <summary>
    /// 設定キーと新しい設定値のDictionaryを返す
    /// </summary>
    /// <returns>設定キーと新しい設定値のDictionary</returns>
    public Dictionary<SetValBase, object> GetSaveValues()
    {
      // 設定キー-新値Dic返却
      return this._dic;
    } 
    #endregion
  }
}
