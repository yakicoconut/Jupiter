using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Configuration;

namespace WFA
{
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
      string hoge01 = ConfigurationManager.AppSettings["Hoge01"];
    }
    #endregion


    #region ボタン1押下イベント
    private void button1_Click(object sender, EventArgs e)
    {
      // XAMLキャプチャメソッド使用
      ImageCaptureForXAML();

      // 画像表示メソッド使用
      ShowScreenImage();
    }
    #endregion

    
    #region XAML込みイメージキャプチャメソッド

    #region 宣言

    //dllのインポート
    //using System.Runtime.InteropServices;必須
    [DllImport("gdi32.dll")]
    static extern bool BitBlt(IntPtr hdcDest, int xDest, int yDest, int
    wDest, int hDest, IntPtr hdcSource, int xSrc, int ySrc, CopyPixelOperation rop);
    [DllImport("user32.dll")]
    static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDc);
    [DllImport("gdi32.dll")]
    static extern IntPtr DeleteDC(IntPtr hDc);
    [DllImport("gdi32.dll")]
    static extern IntPtr DeleteObject(IntPtr hDc);
    [DllImport("gdi32.dll")]
    static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);
    [DllImport("gdi32.dll")]
    static extern IntPtr CreateCompatibleDC(IntPtr hdc);
    [DllImport("gdi32.dll")]
    static extern IntPtr SelectObject(IntPtr hdc, IntPtr bmp);
    [DllImport("user32.dll")]
    public static extern IntPtr GetDesktopWindow();
    [DllImport("user32.dll")]
    public static extern IntPtr GetWindowDC(IntPtr ptr);

    #endregion

    Bitmap bmp;

    #region XAMLキャプチャメソッド
    public void ImageCaptureForXAML()
    {
      //画面全体を指定
      Size sz = Screen.PrimaryScreen.Bounds.Size;

      //
      IntPtr hDesk = GetDesktopWindow();
      IntPtr hSrce = GetWindowDC(hDesk);
      IntPtr hDest = CreateCompatibleDC(hSrce);
      IntPtr hBmp = CreateCompatibleBitmap(hSrce, sz.Width, sz.Height);
      IntPtr hOldBmp = SelectObject(hDest, hBmp);

      //BitBltメソッドの使用()
      bool b = BitBlt(hDest, 0, 0, sz.Width, sz.Height, hSrce, 0, 0, CopyPixelOperation.SourceCopy | CopyPixelOperation.CaptureBlt);
      //開始位置から終了位置サイズのBitmapを作成
      bmp = Bitmap.FromHbitmap(hBmp);
      //
      SelectObject(hDest, hOldBmp);

      //開放
      DeleteObject(hBmp);
      DeleteDC(hDest);
      ReleaseDC(hDesk, hSrce);

      //exeの階層に保存
      bmp.Save(System.IO.Directory.GetCurrentDirectory() + @"\ScreenImage.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
      bmp.Dispose();
    }
    #endregion

    #endregion
    
    #region 画像表示メソッド
    public void ShowScreenImage()
    {
      Form2 formTwo = new Form2();

      formTwo.ShowDialog();
    }
    #endregion


    #region 雛形メソッド
    public void template()
    {

    }
    #endregion
  }
}
