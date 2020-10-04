using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using Microsoft.VisualBasic;
using System.Diagnostics;
using ImageMagick;
using System.Threading;

namespace WFA
{
  /// <summary>
  /// メインフォーム
  /// </summary>
  public partial class Form1 : Form
  {
    #region コンストラクタ
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
    private void Form1_Load(object sender, EventArgs e)
    {
      // サムネサイズ
      imageList1.ImageSize = new Size(dsc.ThumbW, dsc.ThumbH);
      // 画像リストソース設定
      listView1.LargeImageList = imageList1;
    }
    #endregion


    #region マウスインされるファイルを開くイベント

    #region ドラッグエンターイベント
    private void CommDragEnter(object sender, DragEventArgs e)
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
    private void CommDragDrop(object sender, DragEventArgs e)
    {
      // ドラッグ&ドロップされたファイルの一つ目を取得
      dsc.DropItem = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];

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
    private void listView1_DoubleClick(object sender, EventArgs e)
    {
      // 選択ファイルパス取得
      string tgtPath = listView1.SelectedItems[0].Text;

      // 外部アプリ起動
      Process.Start(dsc.LaunchAppPath, tgtPath);
    }
    #endregion


    #region 雛形メソッド
    private void template()
    {

    }
    #endregion
  }
}
