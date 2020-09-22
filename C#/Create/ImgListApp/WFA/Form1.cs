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

      // コンフィグ取得メソッド使用
      GetConfig();
    }
    #endregion

    #region コンフィグ取得メソッド
    public void GetConfig()
    {
      // 対象拡張子
      tgtExt = _comLogic.GetConfigValue("TgtExt", ".jpg,.jepg,.png,.tiff,.gif,.bmp,.heic").Split(',');
      // サムネイル幅
      thumbW = int.Parse(_comLogic.GetConfigValue("ThumbW", "100"));
      // サムネイル高さ
      thumbH = int.Parse(_comLogic.GetConfigValue("ThumbH", "100"));
      // 起動アプリパス
      launchAppPath = _comLogic.GetConfigValue("LaunchAppPath", @"C:\WINDOWS\system32\mspaint.exe");
    }
    #endregion


    #region 宣言

    // 共通ロジッククラスインスタンス
    MCSComLogic _comLogic = new MCSComLogic();

    // 画像パスディクショナリ
    Dictionary<int, string> DicImgPath;

    // 対象拡張子
    string[] tgtExt;
    // サムネイル幅
    int thumbW;
    // サムネイル高さ
    int thumbH;
    // 起動アプリパス
    string launchAppPath;

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
      string dropItem = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];

      // 画像パスディクショナリ作成メソッド使用
      DicImgPath = CreateDic(dropItem);

      // 画像コントロール表示クリア
      imageList1.Images.Clear();
      listView1.Clear();

      // 
      imageList1.ImageSize = new Size(thumbW, thumbH);
      listView1.LargeImageList = imageList1;

      // サムネイル表示
      foreach (KeyValuePair<int, string> x in DicImgPath)
      {
        // 表示対象画像イメージマジック取り込み
        byte[] imgByte;
        using (MagickImage image = new MagickImage(x.Value))
        {
          // ビットマップに設定
          image.Format = MagickFormat.Bmp;
          // バイト変換
          imgByte = image.ToByteArray();
        }
        // 画像バイトストリーム取り込み
        using (MemoryStream ms = new MemoryStream(imgByte))
        {
          // ビットマップ変換
          using (Bitmap bm = new Bitmap(ms))
          {
            // サムネイル作成メソッド
            using (Image thumb = CreateThumb(bm))
            {
              // 
              imageList1.Images.Add(thumb);
              listView1.Items.Add(x.Value, x.Key);
            }
          }
        }
      }
    }
    #endregion

    #endregion


    #region 画像パスディクショナリ作成メソッド
    private Dictionary<int, string> CreateDic(string tgtPath)
    {
      // 返却用ディクショナリ
      Dictionary<int, string> dic = new Dictionary<int, string>();

      /* 対象ディレクトリパス取得 */
      // デフォルトとしてはディレクトリを想定
      string tgtDirPath = tgtPath;
      // ディレクトリでない判定
      if (!Directory.Exists(tgtPath))
      {
        try
        {
          // ファイルからフォルダパスを取得
          tgtDirPath = Path.GetDirectoryName(tgtPath);
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.ToString() + "\r\n\r\n" + tgtPath);
        }
      }

      // 対象ディレクトリ取得
      DirectoryInfo dir = new DirectoryInfo(tgtDirPath);

      // ファイル読み込み
      FileInfo[] files = dir.GetFiles("*", SearchOption.TopDirectoryOnly);

      // 画像パスディクショナリに変換
      int i = 0;
      foreach (FileInfo x in files)
      {
        // ねずみ返し_拡張子が設定したものではないときは次のループへ
        if (Array.IndexOf(tgtExt, Path.GetExtension(x.FullName).ToLower()) == -1)
        {
          continue;
        }

        // ディクショナリ追加
        dic.Add(i, x.FullName);
        i += 1;
      }

      return dic;
    }
    #endregion

    #region サムネイル作成メソッド
    private Image CreateThumb(Bitmap image)
    {
      // 表示用ビットマップ作成
      Bitmap canvas = new Bitmap(thumbW, thumbH);

      // 画像描写
      using (Graphics g = Graphics.FromImage(canvas))
      {
        // 拝啓作成
        g.FillRectangle(new SolidBrush(Color.White), 0, 0, thumbW, thumbH);

        float fw = (float)thumbW / (float)image.Width;
        float fh = (float)thumbH / (float)image.Height;

        float scale = Math.Min(fw, fh);
        fw = image.Width * scale;
        fh = image.Height * scale;

        // 画像描画
        g.DrawImage(image, (thumbW - fw) / 2, (thumbH - fh) / 2, fw, fh);
      }

      return canvas;
    }
    #endregion


    #region リストビュウダブルクリックイベント
    private void listView1_DoubleClick(object sender, EventArgs e)
    {
      // 選択ファイルパス取得
      string tgtPath = listView1.SelectedItems[0].Text;

      // 外部アプリ起動
      Process.Start(launchAppPath, tgtPath);
    }
    #endregion


    #region 雛形メソッド
    public void template()
    {

    }
    #endregion
  }
}
