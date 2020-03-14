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
using System.Configuration;
using ZXing;
using System.Drawing.Imaging;

namespace WFA
{
  /*
   * バーコード関連パッケージZXing.Net(0.16.2)使用
   * 以下からダウンロード
   *   https://github.com/micjahn/ZXing.Net
   */
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


    #region フォームロードイベント
    private void Form1_Load(object sender, EventArgs e)
    {
      // 初期表示時に、先頭の項目を選択
      this.cbCodeType.SelectedIndex = 0;
    }
    #endregion

    #region ボタン1押下イベント
    private void button1_Click(object sender, EventArgs e)
    {
      // バーコード作成メソッド使用
      CreateBarcode();
    }
    #endregion

    #region ボタン2押下イベント
    private void button2_Click(object sender, EventArgs e)
    {
      /* テキストを一行ずつ取得しタブ区切りに配列に入れる(バーコード値\tディスクリプション) */

      //// 分割文字列(改行)の指定
      //string[] separatorNewLine = new string[] { "\r\n" };
      //// 文字列を分割
      //string[] lineList = textBox1.Text.Split(separatorNewLine, StringSplitOptions.None);

      //string[,] imputList;
      //foreach (string x in lineList)
      //{
      //  // 分割文字列の指定
      //  string[] separatorTab = new string[] { "\t" };
      //  // 文字列を分割
      //  string[] tempList = textBox1.Text.Split(separatorTab, StringSplitOptions.None);

        
      //  imputList = new string[,] { {"", "" } };
      //}
    }
    #endregion


    #region バーコード作成メソッド
    public void CreateBarcode()
    {
      var bacodeWriter = new BarcodeWriter();

      // コードタイプ変換メソッド使用
      bacodeWriter.Format = SwitchCodeType();

      // サイズ
      bacodeWriter.Options.Height = 40;
      bacodeWriter.Options.Width = 200;

      // バーコード左右の余白
      bacodeWriter.Options.Margin = 30;

      // バーコードのみ表示するか
      // falseにするとテキストも表示する
      bacodeWriter.Options.PureBarcode = false;


      // バーコードBitmapを作成
      using (var bitmap = bacodeWriter.Write("0000000000000000"))
      {
        // 画像として保存
        var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Barcode.png");
        bitmap.Save(filePath, ImageFormat.Png);
      }
    }
    #endregion

    #region コードタイプ変換メソッド
    public BarcodeFormat SwitchCodeType()
    {
      // 初期値設定
      BarcodeFormat codeType = BarcodeFormat.AZTEC;

      switch (cbCodeType.Text)
      {
        case "AZTEC":
          codeType = BarcodeFormat.AZTEC;
          break;
        case "CODABAR":
          codeType = BarcodeFormat.CODABAR;
          break;
        case "CODE_39":
          codeType = BarcodeFormat.CODE_39;
          break;
        case "CODE_93":
          codeType = BarcodeFormat.CODE_93;
          break;
        case "CODE_128":
          codeType = BarcodeFormat.CODE_128;
          break;
        case "DATA_MATRIX":
          codeType = BarcodeFormat.DATA_MATRIX;
          break;
        case "EAN_8":
          codeType = BarcodeFormat.EAN_8;
          break;
        case "EAN_13":
          codeType = BarcodeFormat.EAN_13;
          break;
        case "ITF":
          codeType = BarcodeFormat.ITF;
          break;
        case "MAXICODE":
          codeType = BarcodeFormat.MAXICODE;
          break;
        case "PDF_417":
          codeType = BarcodeFormat.PDF_417;
          break;
        case "QR_CODE":
          codeType = BarcodeFormat.QR_CODE;
          break;
        case "RSS_14":
          codeType = BarcodeFormat.RSS_14;
          break;
        case "RSS_EXPANDED":
          codeType = BarcodeFormat.RSS_EXPANDED;
          break;
        case "UPC_A":
          codeType = BarcodeFormat.UPC_A;
          break;
        case "UPC_E":
          codeType = BarcodeFormat.UPC_E;
          break;
        case "All_1D":
          codeType = BarcodeFormat.All_1D;
          break;
        case "UPC_EAN_EXTENSION":
          codeType = BarcodeFormat.UPC_EAN_EXTENSION;
          break;
        case "MSI":
          codeType = BarcodeFormat.MSI;
          break;
        case "PLESSEY":
          codeType = BarcodeFormat.PLESSEY;
          break;
        case "IMB":
          codeType = BarcodeFormat.IMB;
          break;
        default:
          break;
      }

      return codeType;
    }
    #endregion


    #region 雛形メソッド
    public void template()
    {

    }
    #endregion
  }
}
