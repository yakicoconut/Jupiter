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
using System.Drawing.Imaging;

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
      string hoge01 = ConfigurationManager.AppSettings["Hoge01"];
    }
    #endregion


    #region 宣言

    // 共通ロジッククラスインスタンス
    MCSComLogic _comLogic = new MCSComLogic();

    #endregion


    #region ロードイベント
    private void Form1_Load(object sender, EventArgs e)
    {
      // メインフォーム初期設定メソッド使用
      MainFormInitSeting();
    }
    #endregion

    #region メインフォーム初期設定メソッド
    private void MainFormInitSeting()
    {
      // 変更後拡張子コンボボックス設定
      cbSrcChcp.DataSource = new string[] { "UTF8", "SJIS", "UTF7", "BigEndianUnicode", "Unicode", "Default", "ASCII", "UTF32" };
      cbDestChcp.DataSource = new string[] { "UTF8", "SJIS", "UTF7", "BigEndianUnicode", "Unicode", "Default", "ASCII", "UTF32" };
    }
    #endregion


    #region ボタン1押下イベント
    private void button1_Click(object sender, EventArgs e)
    {
      // 対象パス取得
      string tgtPath = _comLogic.ExclIniEndWQuot(tbTgtPath.Text);
      // 出力パス取得
      string outPath = tbOutPath.Text;
      // 変換前文字コード
      Encoding srcEnc = Str2Enc(cbSrcChcp.Text);
      // 変換後文字コード
      Encoding destEnc = Str2Enc(cbDestChcp.Text);

      // ねずみ返し
      if (tgtPath == string.Empty)
      {
        MessageBox.Show("対象パスがありません");
        return;
      }

      // 出力パスが設定されている場合
      if (outPath != string.Empty)
      {
        // 最後一文字が「\」でない場合
        if (outPath.Substring(outPath.Length - 1, 1) != @"\")
          outPath += @"\";
      }

      // ファイルの場合
      if (File.Exists(tgtPath))
      {
        // 文字コード変換メソッド使用
        ChcpConversion(tgtPath, outPath, srcEnc, destEnc);
      }
      else if (Directory.Exists(tgtPath))
      {
        // フォルダからXMLファイルのパスだけ取得
        string[] targetFolder = Directory.GetFiles(tgtPath, "*", SearchOption.TopDirectoryOnly);

        // ループ
        foreach (string x in targetFolder)
        {
          // 文字コード変換メソッド使用
          ChcpConversion(x, outPath, srcEnc, destEnc);
        }
      }
      else
      {
        MessageBox.Show("対象が存在しません");
        return;
      }

      MessageBox.Show("完了しました");
    }
    #endregion


    #region 文字列文字コード変換メソッド
    private Encoding Str2Enc(string encStr)
    {
      // 拡張子コンボボックスからフォーマットを選判定する
      Encoding enc;
      switch (encStr)
      {
        default:
        case "UTF8":
          enc = Encoding.UTF8;
          break;

        case "SJIS":
          enc = Encoding.GetEncoding("Shift_JIS");
          break;

        case "UTF7":
          enc = Encoding.UTF7;
          break;

        case "BigEndianUnicode":
          enc = Encoding.BigEndianUnicode;
          break;

        case "Unicode":
          enc = Encoding.Unicode;
          break;

        case "Default":
          enc = Encoding.Default;
          break;

        case "ASCII":
          enc = Encoding.ASCII;
          break;

        case "UTF32":
          enc = Encoding.UTF32;
          break;
      }

      return enc;
    }
    #endregion

    #region 文字コード変換メソッド
    private void ChcpConversion(string tgtPath, string outPath, Encoding srcEnc, Encoding destEnc)
    {
      string str = string.Empty;

      // ファイル名取得
      string tgtName = Path.GetFileName(tgtPath);

      // ファイル読み込み
      using (StreamReader sr = new StreamReader(tgtPath))
      {
        str = sr.ReadToEnd();
      }

      // バイナリ変換
      byte[] binaryStr = srcEnc.GetBytes(str);
      // 文字コード変換
      byte[] convBinary = Encoding.Convert(srcEnc, destEnc, binaryStr);
      // 文字列変換
      string retStr = destEnc.GetString(convBinary);

      // ファイルを開く
      using (StreamWriter writer = new StreamWriter(tgtName, false, destEnc))
      {
        // テキストを書き込む
        writer.WriteLine(retStr);
      }
    }
    #endregion


    #region 雛形メソッド
    private void template()
    {

    }
    #endregion
  }
}
