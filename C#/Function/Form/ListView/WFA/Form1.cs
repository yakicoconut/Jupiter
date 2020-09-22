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
      string hoge01 = _comLogic.GetConfigValue("Key01", "DefaultValue");
    }
    #endregion


    #region 宣言

    // 共通ロジッククラスインスタンス
    MCSComLogic _comLogic = new MCSComLogic();

    // 画像パスディクショナリ
    Dictionary<int, string> DicImgPath;

    // 対象拡張子
    string[] tgtExt;

    #endregion


    #region フォームロードイベント
    private void Form1_Load(object sender, EventArgs e)
    {
      // 対象拡張子
      tgtExt = ".jpg,.jepg,.png,.tiff,.gif,.bmp, .heic".Split(',');
    }
    #endregion

    #region ボタン1押下イベント
    private void button1_Click(object sender, EventArgs e)
    {
      // 画像パスディクショナリ作成メソッド使用
      DicImgPath = CreateDic(textBox1.Text);

      int width = 100;
      int height = 100;

      // 
      imageList1.ImageSize = new Size(width, height);
      listView1.LargeImageList = imageList1;

      foreach (KeyValuePair<int, string> x in DicImgPath)
      {
        // ビットマップ変換
        using (Image bm= Bitmap.FromFile(x.Value))
        {
          // サムネイル作成メソッド
          using (Image thumb = CreateThumb(bm, width, height))
          {
            // 
            imageList1.Images.Add(thumb);
            listView1.Items.Add(x.Value, x.Key);
          }
        }
      }
    }
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
    private Image CreateThumb(Image image, int w, int h)
    {
      // 表示用ビットマップ作成
      Bitmap canvas = new Bitmap(w, h);

      // 画像描写
      using (Graphics g = Graphics.FromImage(canvas))
      {
        // 拝啓作成
        g.FillRectangle(new SolidBrush(Color.White), 0, 0, w, h);

        float fw = (float)w / (float)image.Width;
        float fh = (float)h / (float)image.Height;

        float scale = Math.Min(fw, fh);
        fw = image.Width * scale;
        fh = image.Height * scale;

        // 画像描画
        g.DrawImage(image, (w - fw) / 2, (h - fh) / 2, fw, fh);
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
      Process.Start(@"C:\WINDOWS\system32\mspaint.exe", tgtPath);
    }
    #endregion


    #region 雛形メソッド
    public void template()
    {

    }
    #endregion
  }
}
