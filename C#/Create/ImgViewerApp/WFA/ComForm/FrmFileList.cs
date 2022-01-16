using System;
using System.Windows.Forms;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Collections;

namespace WFA
{
  /// <summary>
  /// ファイルリストフォーム
  /// </summary>
  public partial class FrmFileList : Form
  {
    #region コンストラクタ
    /// <summary>
    /// コンストラクタ
    /// </summary>
    public FrmFileList()
    {
      InitializeComponent();

      // タイトル設定
      this.Text = "FileList";
    }
    #endregion


    #region 宣言

    #endregion

    #region プロパティ

    /// <summary>
    /// 親フォーム
    /// </summary>
    public Form1 parentForm { get; set; }

    #endregion


    #region フォームロードイベント
    /// <summary>
    /// フォームロードイベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void FrmFileList_Load(object sender, EventArgs e)
    {
      // タイトル設定
      this.Text = "FileList";

      // タスクバーにアイコンを表示しない
      this.ShowInTaskbar = false;
    }
    #endregion


    #region リストビューダブルクリックイベント
    /// <summary>
    /// リストビューダブルクリックイベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void lvFileList_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      // ねずみ返し_項目が選択されていない場合
      if (lvFileList.SelectedItems.Count == 0)
      {
        return;
      }

      // 現在のページ数に選択したファイルの番号を設定
      parentForm.CurrentImageKey = lvFileList.SelectedItems[0].Index;

      // ページ送りメソッド使用
      parentForm.FeedImg();
    }
    #endregion

    #region リストビューマウスダウンイベント
    /// <summary>
    /// リストビューマウスダウンイベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void lvFileList_MouseDown(object sender, MouseEventArgs e)
    {

    }
    #endregion

    #region リストビューキー押下イベント
    /// <summary>
    /// リストビューキー押下イベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void lvFileList_KeyDown(object sender, KeyEventArgs e)
    {
      // リストビュー内の項目選択を無効化
      if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Space)
        e.Handled = true;

      // 親フォームのキー押下イベント使用
      parentForm.ComKeyDown(e);
    }
    #endregion

    #region 参照ボタン押下イベント
    /// <summary>
    /// 参照ボタン押下イベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btReferenceDir_Click(object sender, EventArgs e)
    {
      // 選択されたフォルダをbinパスに表示する
      tbCommitDir.Text = ReferenceFolder("コミット先フォルダを指定してください");
    }
    #endregion

    #region ソートコンボボックス値変更イベント
    /// <summary>
    /// ソートコンボボックス値変更イベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void cbSort_SelectedIndexChanged(object sender, EventArgs e)
    {
      // ねずみ返し_画像パスディクショナリが空の場合
      if (parentForm.DicImgPath.Count <= 0)
      {
        return;
      }

      // ファイル読み込みメソッド使用
      parentForm.ReadFile(parentForm.DicImgPath[parentForm.CurrentImageKey]);
    }
    #endregion


    #region コンテキスト_不透明度押下イベント
    /// <summary>
    /// コンテキスト_不透明度押下イベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void toolStripMenuItemOpacity_Click(object sender, EventArgs e)
    {
      //デフォルトに戻す
      this.Opacity = 0.8;
    }
    #endregion

    #region コンテキスト_上げ押下イベント
    /// <summary>
    /// コンテキスト_上げ押下イベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void toolStripMenuItemOpacityGain_Click(object sender, EventArgs e)
    {
      //不透明度を上げる
      this.Opacity += 0.2;
    }
    #endregion

    #region コンテキスト_下げ押下イベント
    /// <summary>
    /// コンテキスト_下げ押下イベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void toolStripMenuItemOpacityDec_Click(object sender, EventArgs e)
    {
      //不透明度を下げる
      this.Opacity -= 0.2;
    }
    #endregion

    #region コンテキスト_透明押下イベント
    /// <summary>
    /// コンテキスト_透明押下イベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void toolStripMenuItemOpacityTransparent_Click(object sender, EventArgs e)
    {
      // 不透明度を0%にするとフォームが非表示扱いとなってしまうため
      this.Opacity = 0.01;
    }
    #endregion

    #region コンテキスト_移動押下イベント
    /// <summary>
    /// コンテキスト_移動押下イベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ToolStripMenuItemMove_Click(object sender, EventArgs e)
    {
      // コミット先パスを設定
      parentForm.commitPath = tbCommitDir.Text;

      // ねずみ返し_コミット先パスが空の場合
      if (parentForm.commitPath == string.Empty)
      {
        MessageBox.Show("コミット先パスを入力してください");
        return;
      }

      // ねずみ返し_ファイル操作判断メソッド使用
      ArrayList chk = new ArrayList();
      if (!FileOperateDecision(chk))
        return;

      // ファイル移動メソッド使用
      parentForm.MoveFiles(chk);
    }
    #endregion

    #region コンテキスト_コピー押下イベント
    /// <summary>
    /// コンテキスト_コピー押下イベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ToolStripMenuItemCopy_Click(object sender, EventArgs e)
    {
      // コミット先パスを設定
      parentForm.commitPath = tbCommitDir.Text;

      // ねずみ返し_コミット先パスが空の場合
      if (parentForm.commitPath == string.Empty)
      {
        MessageBox.Show("コミット先パスを入力してください");
        return;
      }

      // ねずみ返し_ファイル操作判断メソッド使用
      ArrayList chk = new ArrayList();
      if (!FileOperateDecision(chk))
        return;

      // ファイルコピーメソッド使用
      parentForm.CopyFiles(chk);
    }
    #endregion

    #region コンテキスト_削除押下イベント
    /// <summary>
    /// コンテキスト_削除押下イベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ToolStripMenuItemDelete_Click(object sender, EventArgs e)
    {
      // ねずみ返し_ファイル操作判断メソッド使用
      ArrayList chk = new ArrayList();
      if (!FileOperateDecision(chk))
        return;

      // 削除警告表示
      DialogResult result = MessageBox.Show("ファイルを削除します。\r\nよろしいですか?", "実施", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
      if (result == System.Windows.Forms.DialogResult.No)
        return;

      // ファイル削除メソッド使用
      parentForm.DeleteFiles(chk);
    }
    #endregion

    #region コンテキスト_開く押下イベント
    /// <summary>
    /// コンテキスト_開く押下イベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ToolStripMenuItemOpen_Click(object sender, EventArgs e)
    {
      // ねずみ返し_項目が選択されていない場合
      if (lvFileList.SelectedItems.Count == 0)
      {
        return;
      }

      // 選択したファイルにフォーカスを当ててフォルダを開く
      string selectFilePath = parentForm.DicImgPath[lvFileList.SelectedItems[0].Index];
      Process.Start("EXPLORER.EXE", @"/select," + selectFilePath);
    }
    #endregion


    #region フォルダ参照メソッド
    /// <summary>
    /// フォルダ参照メソッド
    /// </summary>
    /// <param name="description"></param>
    /// <returns></returns>
    private string ReferenceFolder(string description)
    {
      // インスタンス作成
      FolderBrowserDialog fbd = new FolderBrowserDialog();

      // 上部に表示する説明テキストを指定する
      fbd.Description = description;
      // ルートフォルダを指定する
      fbd.RootFolder = Environment.SpecialFolder.Desktop;
      // 最初に選択するフォルダを指定する
      fbd.SelectedPath = ConfigurationManager.AppSettings["DefaultReferenceDir"];

      // OKが押下された場合
      if (fbd.ShowDialog(this) == DialogResult.OK)
      {
        // 取得したフォルダパスを返す
        return fbd.SelectedPath;
      }
      else
      {
        return null;
      }
    }
    #endregion

    #region ファイル操作判断メソッド
    /// <summary>
    /// ファイル操作判断メソッド
    /// </summary>
    /// <param name="chk"></param>
    /// <returns></returns>
    private bool FileOperateDecision(ArrayList chk)
    {
      // ねずみ返し_項目がチェックされていない場合
      if (lvFileList.CheckedItems.Count == 0)
      {
        MessageBox.Show("対象項目をチェックしてください");
        return false;
      }

      // チェック項目取得
      foreach (ListViewItem x in lvFileList.CheckedItems)
      {
        chk.Add(x.Index);
      }

      return true;
    }
    #endregion


    #region コミット先テキストボックスドラッグエンターイベント
    /// <summary>
    /// コミット先テキストボックスドラッグエンターイベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void tbCommitDir_DragEnter(object sender, DragEventArgs e)
    {
      // ねずみ返し_マウスがファイルを持っていない場合、イベント・ハンドラを抜ける
      if (!e.Data.GetDataPresent(DataFormats.FileDrop))
      {
        return;
      }

      // ドラッグ中のファイルの取得
      string[] drags = (string[])e.Data.GetData(DataFormats.FileDrop);

      // ねずみ返し_最初の一つ目がフォルダでもファイルでもない場合
      if (!Directory.Exists(drags[0]))
      {
        return;
      }

      // マウスの表示を「+」に変更する
      e.Effect = DragDropEffects.Copy;
    }
    #endregion

    #region コミット先テキストボックスドラッグドロップイベント
    /// <summary>
    /// コミット先テキストボックスドラッグドロップイベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void tbCommitDir_DragDrop(object sender, DragEventArgs e)
    {
      // ドラッグ&ドロップされたアイテムの取得
      string[] drags = (string[])e.Data.GetData(DataFormats.FileDrop);

      // 一つ目のアイテムを設定
      tbCommitDir.Text = drags[0];
    }
    #endregion


    #region フォームクロージングイベント
    /// <summary>
    /// フォームクロージングイベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void FrmFileList_FormClosing(object sender, FormClosingEventArgs e)
    {
      // クローズキャンセル
      if (e.CloseReason == CloseReason.UserClosing)
      {
        e.Cancel = true;
      }
    }
    #endregion
  }
}