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
using System.Drawing.Imaging;
using System.Collections;
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
      ArrayList alist = new ArrayList();
      string targetFolder = textBox1.Text;

      // 対象フォルダ内のファイル読み込み
      string[] fileNames = Directory.GetFiles(targetFolder, "*");
      // ファイルのソート
      Array.Sort(fileNames);

      // ファイルを一つ一つBitmapに変換
      for (int i = 0; i < fileNames.Length; i++)
      {
        try
        {
          // Bitmapを作成
          alist.Add((Bitmap)Bitmap.FromFile(fileNames[i]));
        }
        catch
        {
          // 対象ファイルが画像でない場合
        }
      }
      // 文末から最初の「\」+1の位置
      int LastYenIndex = targetFolder.LastIndexOf(@"\") + 1;
      // 一つ上の階層のパスを取得
      targetFolder = targetFolder.Substring(0, LastYenIndex - 1);

      // GIF作成メソッド使用
      SaveAnimatedGif(targetFolder + @"\新しいギフ画像.gif", alist, Convert.ToUInt16(textBox2.Text), Convert.ToUInt16(textBox3.Text));
    }
    #endregion

    #region ボタン2押下イベント
    private void button2_Click(object sender, EventArgs e)
    {

    }
    #endregion


    #region GIF作成メソッド
    public static void SaveAnimatedGif(string fileName, ArrayList alist, UInt16 delayTime, UInt16 loopCount)
    {
      // 書き込み先のファイルを開く
      FileStream writerFs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
      // BinaryWriterで書き込む
      BinaryWriter writer = new BinaryWriter(writerFs);


      MemoryStream ms = new MemoryStream();
      bool hasGlobalColorTable = false;
      int colorTableSize = 0;

      int imagesCount = alist.Count;
      for (int i = 0; i < imagesCount; i++)
      {
        // 画像をGIFに変換して、MemoryStreamに入れる
        Bitmap bmp = (Bitmap)alist[i];
        bmp.Save(ms, ImageFormat.Gif);
        ms.Position = 0;

        if (i == 0)
        {
          // ヘッダを書き込む
          // Header
          writer.Write(ReadBytes(ms, 6));

          // Logical Screen Descriptor
          byte[] screenDescriptor = ReadBytes(ms, 7);
          // Global Color Tableがあるか確認
          if ((screenDescriptor[4] & 0x80) != 0)
          {
            // Color Tableのサイズを取得
            colorTableSize = screenDescriptor[4] & 0x07;
            hasGlobalColorTable = true;
          }
          else
          {
            hasGlobalColorTable = false;
          }
          // Global Color Tableを使わない
          // 広域配色表フラグと広域配色表の寸法を消す
          screenDescriptor[4] = (byte)(screenDescriptor[4] & 0x78);
          writer.Write(screenDescriptor);

          /* ループ数設定 */
          // Application Extension
          writer.Write(GetApplicationExtension(loopCount));
        }
        else
        {
          // HeaderとLogical Screen Descriptorをスキップ
          ms.Position += 6 + 7;
        }

        byte[] colorTable = null;
        if (hasGlobalColorTable)
        {
          // Color Tableを取得
          colorTable = ReadBytes(ms, (int)Math.Pow(2, colorTableSize + 1) * 3);
        }

        /* 遅延時間の設定 */
        // Graphics Control Extension
        writer.Write(GetGraphicControlExtension(delayTime));
        // 基のGraphics Control Extensionをスキップ
        if (ms.GetBuffer()[ms.Position] == 0x21)
        {
          ms.Position += 8;
        }

        // Image Descriptor
        byte[] imageDescriptor = ReadBytes(ms, 10);
        if (!hasGlobalColorTable)
        {
          // Local Color Tableを持っているか確認
          if ((imageDescriptor[9] & 0x80) == 0)
            throw new Exception("Not found color table.");
          // Color Tableのサイズを取得
          colorTableSize = imageDescriptor[9] & 7;
          // Color Tableを取得
          colorTable = ReadBytes(ms, (int)Math.Pow(2, colorTableSize + 1) * 3);
        }
        // 狭域配色表フラグ (Local Color Table Flag) と狭域配色表の寸法を追加
        imageDescriptor[9] = (byte)(imageDescriptor[9] | 0x80 | colorTableSize);
        writer.Write(imageDescriptor);

        // Local Color Tableを書き込む
        writer.Write(colorTable);

        // Image Dataを書き込む (終了部は書き込まない)
        writer.Write(ReadBytes(ms, (int)(ms.Length - ms.Position - 1)));

        if (i == imagesCount - 1)
        {
          // 終了部 (Trailer)
          writer.Write((byte)0x3B);
        }

        // MemoryStreamをリセット
        ms.SetLength(0);
      }

      // 後始末
      ms.Close();
      writer.Close();
      writerFs.Close();
    }
    #endregion

    #region 指定サイズのバイト配列読み取りメソッド
    /// <summary>
    /// MemoryStreamの現在の位置から指定されたサイズのバイト配列を読み取る
    /// </summary>
    /// <param name="ms">読み取るMemoryStream</param>
    /// <param name="count">読み取るバイトのサイズ</param>
    /// <returns>読み取れたバイト配列</returns>
    private static byte[] ReadBytes(MemoryStream ms, int count)
    {
      byte[] bs = new byte[count];
      ms.Read(bs, 0, count);
      return bs;
    }
    #endregion

    #region NAEブロック取得メソッド
    /// <summary>
    /// Netscape Application Extensionブロックを返す。
    /// </summary>
    /// <param name="loopCount">繰り返す回数。0で無限。</param>
    /// <returns>Netscape Application Extensionブロックのbyte配列。</returns>
    private static byte[] GetApplicationExtension(UInt16 loopCount)
    {
      byte[] bs = new byte[19];

      // 拡張導入符 (Extension Introducer)
      bs[0] = 0x21;
      // アプリケーション拡張ラベル (Application Extension Label)
      bs[1] = 0xFF;
      // ブロック寸法 (Block Size)
      bs[2] = 0x0B;
      // アプリケーション識別名 (Application Identifier)
      bs[3] = (byte)'N';
      bs[4] = (byte)'E';
      bs[5] = (byte)'T';
      bs[6] = (byte)'S';
      bs[7] = (byte)'C';
      bs[8] = (byte)'A';
      bs[9] = (byte)'P';
      bs[10] = (byte)'E';
      // アプリケーション確証符号 (Application Authentication Code)
      bs[11] = (byte)'2';
      bs[12] = (byte)'.';
      bs[13] = (byte)'0';
      // データ副ブロック寸法 (Data Sub-block Size)
      bs[14] = 0x03;
      // 詰め込み欄 [ネットスケープ拡張コード (Netscape Extension Code)]
      bs[15] = 0x01;
      // 繰り返し回数 (Loop Count)
      byte[] loopCountBytes = BitConverter.GetBytes(loopCount);
      bs[16] = loopCountBytes[0];
      bs[17] = loopCountBytes[1];
      // ブロック終了符 (Block Terminator)
      bs[18] = 0x00;

      return bs;
    }
    #endregion

    #region GCEブロック取得メソッド
    /// <summary>
    /// Graphic Control Extensionブロックを返す。
    /// </summary>
    /// <param name="delayTime">遅延時間（100分の1秒単位）。</param>
    /// <returns>Graphic Control Extensionブロックのbyte配列。</returns>
    private static byte[] GetGraphicControlExtension(UInt16 delayTime)
    {
      byte[] bs = new byte[8];

      // 拡張導入符 (Extension Introducer)
      bs[0] = 0x21;
      // グラフィック制御ラベル (Graphic Control Label)
      bs[1] = 0xF9;
      // ブロック寸法 (Block Size, Byte Size)
      bs[2] = 0x04;
      // 詰め込み欄 (Packed Field)
      // 透過色指標を使う時は+1
      // 消去方法:そのまま残す+4、背景色でつぶす+8、直前の画像に戻す+12
      bs[3] = 0x00;
      // 遅延時間 (Delay Time)
      byte[] delayTimeBytes = BitConverter.GetBytes(delayTime);
      bs[4] = delayTimeBytes[0];
      bs[5] = delayTimeBytes[1];
      // 透過色指標 (Transparency Index, Transparent Color Index)
      bs[6] = 0x00;
      // ブロック終了符 (Block Terminator)
      bs[7] = 0x00;

      return bs;
    }
    #endregion


    #region 雛形メソッド
    public void template()
    {

    }
    #endregion
  }
}
