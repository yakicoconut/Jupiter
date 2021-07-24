using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WFA
{
  public partial class Form2 : Form
  {
    #region コンストラクタ
    /// <summary>
    /// ProgressDialogクラスのコンストラクタ
    /// </summary>
    /// <param name="caption">タイトルバーに表示するテキスト</param>
    /// <param name="doWorkHandler">バックグラウンドで実行するメソッド</param>
    /// <param name="argument">doWorkで取得できるパラメータ</param>
    public Form2(string caption, DoWorkEventHandler doWork, object argument)
    {
      InitializeComponent();

      //初期設定
      this.workerArgument = argument;
      this.Text = caption;
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.ControlBox = false;
      this.CancelButton = this.btCancel;
      this.lbProgress.Text = "";
      this.progressBar1.Minimum = 0;
      this.progressBar1.Maximum = 100;
      this.progressBar1.Value = 0;
      this.btCancel.Text = "キャンセル";
      this.btCancel.Enabled = true;
      this.backgroundWorker1.WorkerReportsProgress = true;
      this.backgroundWorker1.WorkerSupportsCancellation = true;

      //イベント
      this.Shown += new EventHandler(Form2_Shown);
      this.btCancel.Click += new EventHandler(btCancel_Click);
      this.backgroundWorker1.DoWork += doWork;
      this.backgroundWorker1.ProgressChanged +=
          new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
      this.backgroundWorker1.RunWorkerCompleted +=
          new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
    }
    #endregion

    #region コンストラクタ
    /// <summary>
    /// ProgressDialogクラスのコンストラクタ
    /// </summary>
    public Form2(string formTitle, DoWorkEventHandler doWorkHandler) : this(formTitle, doWorkHandler, null)
    {
    }
    #endregion


    #region 宣言

    //
    private object workerArgument = null;

    #endregion

    #region プロパティ

    /// <summary>
    /// バックグラウンド処理結果
    /// ※クラス内での設定は罰金具フィールドで行う
    /// </summary>
    public object Result
    {
      get
      {
        return this._result;
      }
    }
    private object _result = null;

    /// <summary>
    /// バックグラウンド処理エラー
    /// ※クラス内での設定は罰金具フィールドで行う
    /// </summary>
    public Exception Error
    {
      get
      {
        return this._error;
      }
    }
    private Exception _error = null;

    /// <summary>
    /// 進行状況ダイアログで使用しているBackgroundWorkerクラス
    /// </summary>
    public BackgroundWorker BackgroundWorker
    {
      get
      {
        return this.backgroundWorker1;
      }
    }

    #endregion


    #region フォーム表示イベント
    private void Form2_Shown(object sender, EventArgs e)
    {
      // フォームが表示されたときにバックグラウンド処理を開始
      this.backgroundWorker1.RunWorkerAsync(this.workerArgument);
    }
    #endregion

    #region キャンセルボタン押下イベント
    private void btCancel_Click(object sender, EventArgs e)
    {
      // キャンセルボタン非表示
      btCancel.Enabled = false;

      // バックグラウンド処理キャンセル
      backgroundWorker1.CancelAsync();
    }
    #endregion


    #region コントロール更新用イベント
    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      // プログレスバーの値を変更する
      if (e.ProgressPercentage < this.progressBar1.Minimum)
      {
        this.progressBar1.Value = this.progressBar1.Minimum;
      }
      else if (this.progressBar1.Maximum < e.ProgressPercentage)
      {
        this.progressBar1.Value = this.progressBar1.Maximum;
      }
      else
      {
        this.progressBar1.Value = e.ProgressPercentage;
      }
      // メッセージのテキストを変更する
      this.lbProgress.Text = (string)e.UserState;
    }
    #endregion

    #region バックグラウンド処理終了イベント
    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (e.Error != null)
      {
        MessageBox.Show(this,
            "エラー",
            "エラーが発生しました。\n\n" + e.Error.Message,
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
        this._error = e.Error;
        this.DialogResult = DialogResult.Abort;
      }
      else if (e.Cancelled)
      {
        this.DialogResult = DialogResult.Cancel;
      }
      else
      {
        this._result = e.Result;
        this.DialogResult = DialogResult.OK;
      }

      this.Close();
    }
    #endregion
  }
}
