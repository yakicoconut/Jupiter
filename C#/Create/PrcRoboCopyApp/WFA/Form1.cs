using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WFA
{
    /// <summary>
    /// メインフォームクラス
    /// </summary>
    public partial class Form1 : Form
    {
        #region 変数定義

        // 共通ロジッククラス
        private MCSComLogic _comLgc;

        // メインロジッククラス
        private ExecRobocopy execRbcpy;

        #endregion


        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="log">共通ロジッククラスインスタンス</param>
        public Form1(MCSComLogic comLgc)
        {
            InitializeComponent();

            this._comLgc = comLgc;

            // メインロジッククラスインスタンス生成
            execRbcpy = new ExecRobocopy(this._comLgc);
        }
        #endregion


        #region フォームロードイベント
        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // ログ用メソッド名
            string strMethodName = "Form1_Load";

            try
            {
                this._comLgc.WriteLog(strMethodName + "開始");

                // テキストボックス値設定
                tbColSrcPathList.Text = string.Join(",", execRbcpy.ColSrcPathAry);
                tbColDstPathList.Text = string.Join(",", execRbcpy.ColDstPathAry);
                tbRobocopyOpt.Text = execRbcpy.RbcpyOpt;
                cbIsOutDetailLog.Checked = execRbcpy.IsOutDetailLog;
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

        #region 実行ボタン押下イベント
        /// <summary>
        /// 実行ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btExec_Click(object sender, EventArgs e)
        {
            // ログ用メソッド名
            string strMethodName = "btExec_Click";
            bool bRet = true;

            this._comLgc.WriteLog(strMethodName + "開始");

            lbStatus.Text = "処理中";

            try
            {
                // テキストボックス設定値取得
                execRbcpy.ColSrcPathAry = tbColSrcPathList.Text.Split(',');
                execRbcpy.ColDstPathAry = tbColDstPathList.Text.Split(',');
                execRbcpy.RbcpyOpt = tbRobocopyOpt.Text;
                execRbcpy.IsOutDetailLog = cbIsOutDetailLog.Checked;

                // 実行メインメソッド使用
                bRet = execRbcpy.ExecMain();
                if (!bRet)
                {
                    MessageBox.Show(string.Format("エラーが発生しました{0}ログを確認してください", Environment.NewLine));
                }
            }
            catch (Exception ex)
            {
                this._comLgc.WriteLog(ex.Message + ex.StackTrace);
                MessageBox.Show(string.Format("【エラー】{0}{1}", Environment.NewLine, ex.Message + ex.StackTrace));
            }
            finally
            {
                this._comLgc.WriteLog(strMethodName + "終了");
                lbStatus.Text = "処理終了";
            }
        }
        #endregion
    }
}
