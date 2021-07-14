using System;

namespace WFA
{
    /// <summary>
    /// ジョブ開始クラス
    /// </summary>
    public class StartJob
    {
        #region デフォルトコンストラクタ
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public StartJob()
        {
            //特になし
        }
        #endregion

        #region エントリーポイント
        /// <summary>
        /// エントリーポイント
        /// </summary>
        /// <param name="args">コマンドライン引数配列</param>
        [STAThread]
        public static void Main(string[] args)
        {
            // 共通ロジッククラスインスタンス生成
            MCSComLogic _comLgc = new MCSComLogic();

            try
            {
                // メイン処理起動
                PrcRoboCopy job = new PrcRoboCopy(_comLgc);
                job.Start(args);
            }
            catch (Exception ex)
            {
                // ログ出力
                _comLgc.WriteLog(ex.Message + ex.StackTrace);

                Environment.Exit(-1);
            }

            Environment.Exit(0);
        }
        #endregion
    }
}
