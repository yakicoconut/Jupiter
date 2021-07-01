using System;
using System.Windows.Forms;

namespace WFA
{
    ///// <summary>
    ///// メインクラス
    ///// </summary>
    public class PrcRoboCopy
    {
        #region 変数定義

        // 共通ロジッククラス
        private MCSComLogic _comLgc;

        #endregion


        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="log">共通ロジッククラスインスタンス</param>
        public PrcRoboCopy(MCSComLogic comLg)
        {
            this._comLgc = comLg;
        }
        #endregion

        #region エントリーポイント
        /// <summary>
        /// エントリーポイント
        /// </summary>
        /// <param name="args">コマンドライン引数配列</param>
        //******************************************************************************
        public void Start(string[] args)
        {
            // ログ用メソッド名
            string strMethodName = "Start";
            bool bRet = true;

            try
            {
                // 処理開始ログ出力
                this._comLgc.WriteLog(strMethodName + "開始");

                // パラメータが無い場合
                if (args.Length == 0)
                {
                    // 画面起動
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1(this._comLgc));
                    return;
                }

                // ロボコピー実行クラス
                ExecRobocopy execRobocopy = new ExecRobocopy(this._comLgc, args);
                bRet = execRobocopy.ExecMain();
                if (!bRet)
                {
                    // 処理なし
                }
            }
            catch (Exception ex)
            {
                this._comLgc.WriteLog(ex.Message + ex.StackTrace);
            }
            finally
            {
                this._comLgc.WriteLog(strMethodName + "終了");
            }
        }
        #endregion
    }
}
