/*
 * ForYouApplications.POS4U.Framework.Utility.SettingValueBase
 * \Framework\POS4U.Framework.Utility\Setting\SettingValueBase.cs
 */
/*
 * 抽象クラス
 * 参照先クラス
 *   なし
 */
/*
 * コンストラクタ
 *   渡されたキー名称をプロパティに引き継ぐ
 */
namespace WFA
{
  /// <summary>
  /// 設定値抽象クラス
  /// </summary>
  public abstract class SetValBase
  {
    #region コンストラクタ
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="key">キー</param>
    protected SetValBase(string key)
    {
      // プロパティに引継ぎ
      this.Key = key;
    }
    #endregion


    #region プロパティ

    /// <summary>
    /// キー
    /// </summary>
    protected internal string Key { get; private set; }

    #endregion


    #region 値文字列変換抽象メソッド
    /// <summary>
    /// 値を保存用Stringに変換する
    /// </summary>
    /// <param name="val">変換元値</param>
    /// <returns>変換後値</returns>
    protected internal abstract string ConvertBackToValue(object val);
    #endregion

    #region 新値設定抽象メソッド
    /// <summary>
    /// 新しい値を設定する
    /// </summary>
    /// <param name="newVal">新しい値</param>
    protected internal abstract void SetNewValue(object newVal);
    #endregion
  }
}