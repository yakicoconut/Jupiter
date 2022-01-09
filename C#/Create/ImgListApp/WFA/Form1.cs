using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace WFA
{
  /// <summary>
  /// メインフォーム
  /// </summary>
  public partial class Form1 : Form
  {
    #region コンストラクタ
    /// <summary>
    /// コンストラクタ
    /// </summary>
    public Form1()
    {
      InitializeComponent();

      #region 【論理雛形】
      WFAComLogic WFACL = new WFAComLogic();
      // アプリ名設定
      Text = WFACL.GetAppName();
      #endregion

      // データ格納クラスインスタンス生成
      dsc = new DataStore();
      // 画像取り込み処理クラスインスタンス生成
      inportImg = new InportImg(this, dsc);

      // コンフィグ取得メソッド使用
      GetConfig();
    }
    #endregion

    #region コンフィグ取得メソッド
    /// <summary>
    /// コンフィグ取得メソッド
    /// </summary>
    private void GetConfig()
    {
      // 対象拡張子
      dsc.TgtExt = _comLogic.GetConfigValue("TgtExt", ".jpg,.jepg,.png,.tiff,.gif,.bmp,.heic").Split(',');
      // サムネイル幅
      dsc.ThumbW = int.Parse(_comLogic.GetConfigValue("ThumbW", "100"));
      // サムネイル高さ
      dsc.ThumbH = int.Parse(_comLogic.GetConfigValue("ThumbH", "100"));
      // 起動アプリパス
      dsc.LaunchAppPath = _comLogic.GetConfigValue("LaunchAppPath", @"C:\WINDOWS\system32\mspaint.exe");
    }
    #endregion


    #region 宣言

    // 共通ロジッククラスインスタンス
    MCSComLogic _comLogic = new MCSComLogic();

    // データ格納クラス
    DataStore dsc;
    // 画像取り込み処理クラス
    InportImg inportImg;

    #endregion


    #region フォームロードイベント
    /// <summary>
    /// フォームロードイベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Form1_Load(object sender, EventArgs e)
    {
      // サムネサイズ
      imageList1.ImageSize = new Size(dsc.ThumbW, dsc.ThumbH);
      // 画像リストソース設定
      listView1.LargeImageList = imageList1;
    }
    #endregion


    #region D&Dイベント関連

    #region ドラッグエンターイベント
    /// <summary>
    /// ドラッグエンターイベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Com_DragEnter(object sender, DragEventArgs e)
    {
      // AllowDropプロパティの許可が必要

      // ねずみ返し_マウスがファイルを持っていない場合、イベント・ハンドラを抜ける
      if (!e.Data.GetDataPresent(DataFormats.FileDrop))
      {
        return;
      }

      // ドラッグ中のファイルの取得
      string[] drags = (string[])e.Data.GetData(DataFormats.FileDrop);

      // ねずみ返し_ファイルのみを条件とする
      foreach (string d in drags)
      {
        //ファイルまたはフォルダ以外であればイベント・ハンドラを抜ける
        if (!(File.Exists(d) || Directory.Exists(d)))
        {
          return;
        }
      }

      // マウスの表示を「+」に変更する
      e.Effect = DragDropEffects.Copy;
    }
    #endregion

    #region フォームドラッグドロップイベント
    /// <summary>
    /// フォームドラッグドロップイベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Com_DragDrop(object sender, DragEventArgs e)
    {
      // ドラッグ&ドロップされたファイルの一つ目を取得
      dsc.DropItem = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];

      // 移動先フォルダテキストボックスの場合
      if ((sender is TextBox tgtCtrl) && tgtCtrl.Name == "tbCommitPath")
      {
        // ドラッグ&ドロップされたアイテムの先頭取得
        string drag = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
        // ファイルの場合
        if(File.Exists(drag))
        {
          // フォルダパス取得
          drag = Path.GetDirectoryName(drag);
        }
        // パス設定
        tbCommitPath.Text = drag;
        return;
      }

      // 画像コントロール表示クリア
      imageList1.Images.Clear();
      listView1.Items.Clear();

      // 画像取り込み処理クラススタートメソッド使用
      Thread threadA = inportImg.Start();

      // スレッド終了待ち
      threadA.Join();

      // 画像表示
      imageList1.Images.AddRange(dsc.SrcImgList);
      listView1.Items.AddRange(dsc.SrcListViewItem);
    }
    #endregion

    #endregion


    #region リストビュウダブルクリックイベント
    /// <summary>
    /// リストビュウダブルクリックイベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void listView1_DoubleClick(object sender, EventArgs e)
    {
      // 選択ファイルパス取得
      string tgtPath = listView1.SelectedItems[0].Text;

      // 外部アプリ起動
      Process.Start(dsc.LaunchAppPath, tgtPath);
    }
    #endregion


    #region コンテキスト_移動
    /// <summary>
    /// コンテキスト_移動押下イベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ToolStripMenuItem_Move_Click(object sender, EventArgs e)
    {
      // 移動先パス取得
      string commitPath = tbCommitPath.Text;
      if(!Directory.Exists(commitPath))
      {
        MessageBox.Show("移動先フォルダが存在しません");
        return;
      }

      // ねずみ返し_選択ファイルが存在しない場合
      ListView.SelectedIndexCollection chk = listView1.SelectedIndices;
      if (chk.Count == 0)
        return;

      // 削除警告表示
      DialogResult result = MessageBox.Show("ファイルを移動します。\r\nよろしいですか?", "実施", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
      if (result == DialogResult.No)
        return;

      // ファイル移動メソッド使用
      MoveFiles(chk);
    }
    #endregion

    #region コンテキスト_削除押下イベント
    /// <summary>
    /// コンテキスト_削除押下イベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ToolStripMenuItem_Delete_Click(object sender, EventArgs e)
    {
      // ねずみ返し_選択ファイルが存在しない場合
      ListView.SelectedIndexCollection chk = listView1.SelectedIndices;
      if (chk.Count == 0)
        return;

      // 削除警告表示
      DialogResult result = MessageBox.Show("ファイルを削除します。\r\nよろしいですか?", "実施", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
      if (result == DialogResult.No)
        return;

      // ファイル削除メソッド使用
      DeleteFiles(chk);
    }
    #endregion


    #region ファイル移動メソッド
    /// <summary>
    /// ファイル移動メソッド
    /// </summary>
    /// <param name="fileIndex"></param>
    public void MoveFiles(ListView.SelectedIndexCollection fileIndex)
    {
      // チェックされたファイルを処理
      foreach (int x in fileIndex)
      {
        // ディクショナリから画像パスを取得
        string targetImgPath = dsc.DicImgPath[x];

        try
        {
          // ファイル移動
          File.Move(targetImgPath, @"E:\_work\Surface→PC2" + @"\" + Path.GetFileName(targetImgPath));
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.ToString() + "\r\n\r\n" + targetImgPath);
        }
      }

      // 画像コントロール表示クリア
      imageList1.Images.Clear();
      listView1.Items.Clear();

      // 画像取り込み処理クラススタートメソッド使用
      Thread threadA = inportImg.Start();

      // スレッド終了待ち
      threadA.Join();

      // 画像表示
      imageList1.Images.AddRange(dsc.SrcImgList);
      listView1.Items.AddRange(dsc.SrcListViewItem);
    }
    #endregion

    #region ファイル削除メソッド
    /// <summary>
    /// ファイル削除メソッド
    /// </summary>
    /// <param name="fileIndex"></param>
    private void DeleteFiles(ListView.SelectedIndexCollection fileIndex)
    {
      // チェックされたファイルを処理
      foreach (int x in fileIndex)
      {
        // ディクショナリから画像パスを取得
        string targetImgPath = dsc.DicImgPath[x];

        try
        {
          // ファイル削除
          File.Delete(targetImgPath);
        }
        catch (Exception e)
        {
          MessageBox.Show(e.ToString());
        }
      }

      // 画像コントロール表示クリア
      imageList1.Images.Clear();
      listView1.Items.Clear();

      // 画像取り込み処理クラススタートメソッド使用
      Thread threadA = inportImg.Start();

      // スレッド終了待ち
      threadA.Join();

      // 画像表示
      imageList1.Images.AddRange(dsc.SrcImgList);
      listView1.Items.AddRange(dsc.SrcListViewItem);
    }
    #endregion
  }
}
