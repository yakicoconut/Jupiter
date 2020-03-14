using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Collections;
using System.Runtime.InteropServices;
using System.Configuration;

namespace WFA
{
  class ImageCapture
  {
    #region コンストラクタ
    public ImageCapture()
    {
      //設定値をコンフィグから取得
      folderName = ConfigurationManager.AppSettings["OutputFolderName"];
      fileName = ConfigurationManager.AppSettings["OutputFileName"];
    }
    #endregion


    #region 宣言

    //設定値プロパティ
    public string folderName { get; set; }
    public string fileName { get; set; }

    #endregion


    #region XAML込みイメージキャプチャメソッド一覧

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

    #region XAMLキャプチャメソッド
    public void ImageCaptureForXAML(string folderName, string fileName)
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
      using (Bitmap bmp = Bitmap.FromHbitmap(hBmp))
      {
        //
        SelectObject(hDest, hOldBmp);

        //開放
        DeleteObject(hBmp);
        DeleteDC(hDest);
        ReleaseDC(hDesk, hSrce);

        //フォルダの設定値がない場合
        if (folderName.Length == 0)
        {
          //カレントディレクトリを指定して保存
          bmp.Save(Directory.GetCurrentDirectory() + "\\" + fileName + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        else
        {
          bmp.Save(folderName + "\\" + fileName + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }
      }
    }
    #endregion

    #endregion
  }
}
