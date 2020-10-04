using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA
{
  /// <summary>
  /// バックグラウンド処理クラス
  /// </summary>
  class BackGroundClass1
  {
    #region コンストラクタ
    public BackGroundClass1(Form1 frm1)
    {
      // メインフォーム
      fm1 = frm1;

      // プログレスバーフォーム初期設定メソッド使用
      FrmPrgBarInit();
    }
    #endregion


    #region 宣言

    // メインフォーム
    Form1 fm1;

    // プログレスバーフォーム
    FrmPrgBar fmPrgBar;

    #endregion


    #region プログレスバーフォーム初期設定メソッド
    private void FrmPrgBarInit()
    {
      // プログレスバーフォームインスタンス生成
      fmPrgBar = new FrmPrgBar();

      // 事前にロードし、非表示としておく
      fmPrgBar.Show();
      fmPrgBar.Visible = false;

      // プログレスバーフォーム開始位置
      fmPrgBar.StartPosition = FormStartPosition.CenterParent;
    }
    #endregion


    #region メイン処理メソッド
    /// <summary>
    /// メイン処理メソッド
    /// </summary>
    private void MainProcessThread()
    {
      // 最大値
      int max = 5;

      // 処理サンプル
      for (int i = 0; i <= max; i++)
      {
        // プログレスバー更新メソッドメソッド使用
        fmPrgBar.UpdPrgBarOprt(i, max);

        // 待機
        Thread.Sleep(1000);
      }

      /* ループ処理後の処理 */
      // メインフォームプロパティ設定
      fm1.str = "abc";
    }
    #endregion

    #region スタートメソッド
    /// <summary>
    /// スタートメソッド
    /// </summary>
    /// <returns>実行スレッド</returns>
    public Thread Start()
    {
      // メイン処理メソッドスレッドインスタンス生成
      Thread threadA = new Thread(new ThreadStart(MainProcessThread));
      // バックグラウンドフラグ
      threadA.IsBackground = true;

      // サイズ設定
      fmPrgBar.Size = new Size(fm1.Size.Width * 3 / 4, 50);

      // スレッドスタート
      threadA.Start();
      // プログレスバーフォーム表示
      fmPrgBar.ShowDialog(fm1);

      return threadA;
    }
    #endregion
  }
}
