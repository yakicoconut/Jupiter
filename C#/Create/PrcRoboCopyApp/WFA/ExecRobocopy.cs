using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace WFA
{
    /// <summary>
    /// ロボコピー実行クラス
    /// </summary>
    class ExecRobocopy
    {
        #region 定数定義

        // 実行ロボコピーファイル名称
        private const string CMD_FILE_NAME_RBCPY = "ROBOCOPY.EXE";

        #endregion

        #region 変数定義

        // 共通ロジッククラス
        private MCSComLogic _comLgc;

        // 詳細ログ出力フラグ
        private bool isOutDetailLogCopy;
        private bool isOutDetailLogMove;

        // コピー用収集対象パスリスト
        private string[] colSrcPathAryCopy;
        // コピー用収集先パスリスト
        private string[] colDstPathAryCopy;
        // 移動用収集対象パスリスト
        private string[] colSrcPathAryMove;
        // 移動用収集先パスリスト
        private string[] colDstPathAryMove;

        // コピー用robocopyオプション
        private string rbcpyOptCopy;
        // 移動用robocopyオプション
        private string rbcpyOptMove;

        // 実行日付
        private string todayYyyymmdd;

        #endregion

        #region プロパティ

        /// <summary>
        /// 詳細ログ出力フラグ(True:出力する、False:出力しない) 
        /// </summary>
        public bool IsOutDetailLog { get; set; }

        /// <summary>
        /// 詳細ログファイル出力フォルダパス
        /// </summary>
        public string DetailLogOutPath { get; set; }

        /// <summary>
        /// 収集対象パスリスト
        /// </summary>
        public string[] ColSrcPathAry { get; set; }
        /// <summary>
        /// 収集先パスリスト
        /// </summary>
        public string[] ColDstPathAry { get; set; }

        /// <summary>
        /// robocopyオプション
        /// </summary>
        public string RbcpyOpt { get; set; }

        #endregion


        #region コンストラクタ

        #region コンストラクタ
        /// <summary>
        /// フォーム用コンストラクタ
        /// </summary>
        /// <param name="log">共通ロジッククラスインスタンス</param>
        public ExecRobocopy(MCSComLogic comLgc) : this(comLgc, new string[0])
        {
            /*
             * 第2引数に初期状態の配列インスタンスを指定し、
             * コマンドライン引数用コンストラクタ呼出し
             */
        }
        #endregion

        #region コマンドライン引数用コンストラクタ
        /// <summary>
        /// コマンドライン引数用コンストラクタ
        /// </summary>
        /// <param name="comLgc">共通ロジッククラスインスタンス</param>
        /// <param name="cmdArgs">コマンドライン引数</param>
        public ExecRobocopy(MCSComLogic comLgc, string[] cmdArgs)
        {
            // ログ用メソッド名
            string strMethodName = "ExecRobocopy";

            this._comLgc = comLgc;
            this._comLgc.WriteLog(strMethodName + "開始");

            // コンフィグ取得メソッド使用
            GetConfig();

            try
            {
                // 実行日付取得
                todayYyyymmdd = DateTime.Now.ToString("yyyyMMdd");

                // 「[YYYYMMDD]」を本日日付に置き換え
                colSrcPathAryCopy = colSrcPathAryCopy.Select((string x) => { return x.Replace("[YYYYMMDD]", todayYyyymmdd); }).ToArray();
                rbcpyOptCopy= rbcpyOptCopy.Replace("[YYYYMMDD]", todayYyyymmdd);

                // コピー用設定デフォルト値設定
                IsOutDetailLog = isOutDetailLogCopy;
                ColSrcPathAry = colSrcPathAryCopy;
                ColDstPathAry = colDstPathAryCopy;
                RbcpyOpt = rbcpyOptCopy;
                // 引数に「/MOV」がある場合
                int idx = Array.FindIndex(cmdArgs, x => x.IndexOf("/MOVE", StringComparison.InvariantCultureIgnoreCase) >= 0);
                if (idx >= 0)
                {
                    // 「[YYYYMMDD]」置換え
                    colSrcPathAryMove = colSrcPathAryMove.Select((string x) => { return x.Replace("[YYYYMMDD]", todayYyyymmdd); }).ToArray();
                    rbcpyOptMove = rbcpyOptMove.Replace("[YYYYMMDD]", todayYyyymmdd);

                    // 移動用設定
                    IsOutDetailLog = isOutDetailLogMove;
                    ColSrcPathAry = colSrcPathAryMove;
                    ColDstPathAry = colDstPathAryMove;
                    RbcpyOpt = rbcpyOptMove;
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

        #endregion

        #region コンフィグ取得メソッド
        /// <summary>
        /// コンフィグ取得メソッド
        /// </summary>
        private void GetConfig()
        {
            // ログ用メソッド名
            string strMethodName = "GetConfig";

            this._comLgc.WriteLog(strMethodName + "開始");

            try
            {
                // 詳細ログ出力フラグ
                isOutDetailLogCopy = bool.Parse(this._comLgc.GetConfigValue("IsOutDetailLogCopy", "False"));
                isOutDetailLogMove = bool.Parse(this._comLgc.GetConfigValue("IsOutDetailLogMove", "True"));

                // 詳細ログファイル出力フォルダパス
                DetailLogOutPath = this._comLgc.GetConfigValue("DetailLogOutPath", @"D:\FFS\Log\SMS");

                // 移動用収集対象パスリスト
                colSrcPathAryMove = this._comLgc.GetConfigValue("ColSrcPathAryMove", "").Replace("\r", "").Replace("\n", "").Split(',');
                // 移動用収集先パスリスト
                colDstPathAryMove = this._comLgc.GetConfigValue("ColDstPathAryMove", "").Replace("\r", "").Replace("\n", "").Split(',');
                // コピー用収集対象パスリスト
                colSrcPathAryCopy = this._comLgc.GetConfigValue("ColSrcPathAryCopy", "").Replace("\r", "").Replace("\n", "").Split(',');
                // コピー用収集先パスリスト
                colDstPathAryCopy = this._comLgc.GetConfigValue("ColDstPathAryCopy", "").Replace("\r", "").Replace("\n", "").Split(',');

                // 移動用robocopyオプション
                rbcpyOptMove = this._comLgc.GetConfigValue("RobocopyOptMove", "/MOV /E /R:2 /W:10");
                // コピー用robocopyオプション
                rbcpyOptCopy = this._comLgc.GetConfigValue("RobocopyOptCopy", "/E /R:2 /W:10");
            }
            catch (Exception ex)
            {
                this._comLgc.WriteLog(ex.Message + ex.StackTrace);
            }

            this._comLgc.WriteLog(strMethodName + "終了");
        }
        #endregion


        #region 実行メインメソッド
        /// <summary>
        /// 実行メインメソッド
        /// </summary>
        /// <returns>処理成否(True:成功、False:失敗)</returns>
        public bool ExecMain()
        {
            // ログ用メソッド名
            string strMethodName = "ExecMain";

            this._comLgc.WriteLog(strMethodName + "開始");

            bool ret = true;
            int exitCode = 0;
            string errMsg = string.Empty;
            bool bRet = true;

            try
            {
                // パスリスト要素数取得
                int srcListLen = ColSrcPathAry.Length;
                int dstListLen = ColDstPathAry.Length;

                // パスリスト設定要素数検証メソッド使用
                bRet = ChkPathListLen(srcListLen, dstListLen, out errMsg);
                if (!bRet)
                {

                    // エラー内容ログ出力後、終了
                    this._comLgc.WriteLog(errMsg);
                    ret = false;
                    return ret;
                }

                // 詳細ログ出力フラグがオンの場合
                if (IsOutDetailLog)
                {
                    // 実行日付接尾文字列取得
                    string detailLogSfx = todayYyyymmdd;
                    // 現在日付を指定した詳細ログオプション追加
                    RbcpyOpt += string.Format(" /LOG+:{0}\\SMSDTL{1}{2}.log /NP", DetailLogOutPath, detailLogSfx , "001");
                }

                // 収集対象パスリストループ
                for (int i = 0; i < srcListLen; i++)
                {
                    #region #if_DEBUG
//#if DEBUG

//                    this._comLgc.WriteLog("#if_DEBUG_開始");

//                    // 1/5でエラーとする
//                    Random rdm = new Random();
//                    if (rdm.Next(0, 4) == 0)
//                    {
//                        this._comLgc.WriteLog("#if_DEBUG_エラーログテスト");
//                        continue;
//                    }

//#endif 
                    #endregion

                    // パスリスト取得
                    string srcPath = ColSrcPathAry[i];
                    string dstPath = ColDstPathAry[i];

                    this._comLgc.WriteLog(string.Format("ループ:{0}/{1}", (i + 1).ToString(), (srcListLen).ToString()));

                    // ROBOCOPY実行コマンド引数作成
                    string cmdArg = string.Format("{0} {1} {2}", srcPath, dstPath, RbcpyOpt);

                    this._comLgc.WriteLog(string.Format("実行コマンド:{0} {1}", CMD_FILE_NAME_RBCPY, cmdArg));

                    // ロボコピー起動メソッド使用
                    bRet = LnchRbcpy(cmdArg, out exitCode, out errMsg);
                    if (!bRet)
                    {
                        this._comLgc.WriteLog(errMsg);
                        ret = false;
                        return ret;
                    }

                    // 終了コード判定メソッド使用
                    string codeMean = SwitchExitCode(exitCode);
                    this._comLgc.WriteLog(codeMean);
                }
            }
            catch (Exception ex)
            {
                this._comLgc.WriteLog(ex.Message + ex.StackTrace);
                ret = false;
            }
            finally
            {

                this._comLgc.WriteLog(strMethodName + "終了");
            }

            return ret;
        }
        #endregion

        #region パスリスト設定要素数検証メソッド
        /// <summary>
        /// パスリスト設定要素数検証メソッド
        /// </summary>
        /// <param name="srcListLen">収集対象パスリスト要素数</param>
        /// <param name="dstListLen">格納先パスリスト要素数</param>
        /// <param name="errMsg">エラーメッセージ参照引数</param>
        /// <returns>処理成否(True:成功、False:失敗)</returns>
        private bool ChkPathListLen(int srcListLen, int dstListLen, out string errMsg)
        {
            errMsg = string.Empty;
            bool ret = true;

            // パスリスト要素数いずれかでも0の場合
            if (srcListLen * dstListLen <= 0)
            {
                errMsg = string.Format("パス設定の要素数が無効です(収集対象パス数:{0}、格納先パス数:{1})", srcListLen, dstListLen);
                ret = false;
            }
            // パスリストの設定値数が一致しない場合
            else if (srcListLen != dstListLen)
            {
                errMsg = string.Format("収集対象パスと格納先パスの要素数が一致しません(収集対象パス数:{0}、格納先パス数:{1})", srcListLen, dstListLen);
                ret = false;
            }

            return ret;
        }
        #endregion

        #region ロボコピー起動メソッド
        /// <summary>
        /// ロボコピー起動メソッド
        /// </summary>
        /// <param name="cmdArg">ロボコピーオプション文字列</param>
        /// <param name="exitCode">終了コード数値参照引数</param>
        /// <param name="errMsg">エラーメッセージ参照引数</param>
        /// <returns>処理成否(True:成功、False:失敗)</returns>
        private bool LnchRbcpy(string cmdArg, out int exitCode, out string errMsg)
        {
            exitCode = 0;
            errMsg = string.Empty;
            bool ret = true;

            try
            {
                // プロセス作成
                using (Process rbcpyPrc = new Process())
                {
                    // コマンドファイル指定
                    rbcpyPrc.StartInfo.FileName = CMD_FILE_NAME_RBCPY;
                    // コマンド引数設定
                    rbcpyPrc.StartInfo.Arguments = cmdArg;

                    // コマンドプロンプト非表示
                    rbcpyPrc.StartInfo.CreateNoWindow = true;
                    // 新規ウィンドウ起動無効化
                    rbcpyPrc.StartInfo.UseShellExecute = false;
                    // 標準入力無効化
                    rbcpyPrc.StartInfo.RedirectStandardInput = false;

                    // 実行
                    rbcpyPrc.Start();

                    // 実行完了まで待機
                    rbcpyPrc.WaitForExit();

                    // 終了コード取得
                    exitCode = rbcpyPrc.ExitCode;
                }
            }
            catch (Exception ex) when (ex is Win32Exception || ex is FileNotFoundException)
            {
                errMsg = "【エラー】" + Environment.NewLine;
                errMsg += ex.Message + Environment.NewLine;
                ret = false;
            }

            return ret;
        }
        #endregion

        #region 終了コード判定メソッド
        /// <summary>
        /// 終了コード判定メソッド
        /// </summary>
        /// <param name="exitCode">ロボコピー終了コード数値</param>
        /// <param name="logSort">ログソート列挙型</param>
        /// <returns>終了コード判定結果文字列</returns>
        private string SwitchExitCode(int exitCode)
        {
            #region 終了コード解説
            /*
             * 一覧
             *   スキップ
             *     0:スキップ
             *   成功系
             *     1:コピー済み
             *     2:Extras
             *     4:不一致
             *     3 :一部コピー成功、一部Extras(1 + 2)
             *     5 :一部コピー成功、一部不一致(1 + 4)
             *     7 :一部コピー成功、一部Extrasまたは不一致(1 + 2 + 4)
             *     6 :Extrasまたは不一致(2 + 4)
             *   失敗系
             *     8 :失敗
             *     10:失敗またはExtras(2 + 8)
             *     12:失敗または不一致(8 + 4)
             *     14:失敗、不一致またはExtras(8 + 4 + 2)
             *     9 :一部失敗、一部コピー成功(8 + 1)
             *     11:一部失敗、一部コピー成功、一部Extras(8 + 1 + 2)
             *     13:一部失敗、一部コピー成功、一部不一致(8 + 1 + 4)
             *     15:一部失敗、一部コピー成功、一部不一致またはExtras、(8 + 1 + 4 + 2)
             *   ヘルプ・引数不正
             *     16: ヘルプ表示、または存在しないフォルダー指定等、引数不正
             * サイト
             *   Robocopy のエラー (戻り値) について
             *       https://social.technet.microsoft.com/Forums/windows/ja-JP/2b8fbdd8-c268-4261-9fba-47533f67a5b7/robocopy-12398124561252112540-251471242620516?forum=Wcsupportja
             *   Robocopyの戻り値 | nastrodonのメモ帳
             *       https://ameblo.jp/nastrodon/entry-12189427087.html
             */
            #endregion

            // 返却用引数初期値
            string Fmt_codeMean = "終了コード:{0} {1}";
            string codeMean = codeMean = string.Format(Fmt_codeMean, exitCode, "未定義の終了コードが返却されました");

            // 終了コード分岐
            switch (exitCode)
            {
                // 問題なし
                case 0:
                    codeMean = string.Format(Fmt_codeMean, exitCode, "差分が存在しないため、処理はスキップされました");
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                    codeMean = string.Format(Fmt_codeMean, exitCode, "処理は成功しました");
                    break;

                // エラー系
                case 8:
                    codeMean = string.Format(Fmt_codeMean, exitCode, "処理が失敗しました※詳細ログを確認してください");
                    break;
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                    codeMean = string.Format(Fmt_codeMean, exitCode, "一部処理が失敗しました※詳細ログを確認してください");
                    break;

                case 16:
                    codeMean = string.Format(Fmt_codeMean, exitCode, "ヘルプまたは引数不正の可能性があります※詳細ログを確認してください");
                    break;

                default:
                    break;
            }

            return codeMean;
        }
        #endregion
    }
}
