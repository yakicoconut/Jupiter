//#define PATTERN01
//#define PATTERN02
#define PATTERN03
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#region ヘッダ
/*
 * オーバーフローチェック
 *   ・キーワード「checked」と「unchecked」
 */
#endregion
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

    #endregion


    static void Main(string[] args)
    {
      sbyte a;
      sbyte b;
      sbyte c = 0;

      #region パターン01_チェックなし
#if PATTERN01
      try
      {
        // 129を入れるとエラーにはならずに一周して-126となる
        //  127 + 1 = -128
        // -128 + 1 = -127
        // -127 + 1 = -126
        a = 65;
        b = 65;
        c = (sbyte)(a + b);
      }
      catch (OverflowException ex)
      {
        Console.Write(ex.Message);
      }
#endif
      #endregion

      #region パターン02_オーバーフローチェック
#if PATTERN02
      try
      {
        // オーバーフローチェック
        checked
        {
          // sbyte型は-128~127が範囲のため
          // オーバーフローチェック時に128を入れるとエラーとなる
          a = 64;
          b = 65;
          c = (sbyte)(a + b);
        }
      }
      catch (OverflowException ex)
      {
        Console.Write(ex.Message + "\r\n");
      }
#endif
      #endregion

      #region パターン03_アンオーバーフローチェック
#if PATTERN03
      try
      {
        // アンオーバーフローチェック
        unchecked
        {
          // sbyte型は-128~127が範囲だが
          // アンチェック時は128を入れてもエラーとならない
          a = 64;
          b = 65;
          c = (sbyte)(a + b);
        }
      }
      catch (OverflowException ex)
      {
        Console.Write(ex.Message + "\r\n");
      }
#endif
      #endregion

      Console.Write(c.ToString());
      Console.ReadLine();
    }
  }
}
