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

    // エンコードフォーマット
    Encoding encFmt;

    #endregion


    #region メインフォーム初期設定メソッド
    private void MainFormInitSeting()
    {
      // 変更後拡張子コンボボックス設定
      cbChcp.DataSource = new string[] { "UTF7", "BigEndianUnicode", "Unicode", "Default", "ASCII", "UTF8", "UTF32" };
      // 変更後拡張子コンボボックス選択
      cbChcp.SelectedItem = 0;
      // エンコードフォーマット
      encFmt = Encoding.UTF8;
    }
    #endregion


    #region ロードイベント
    private void Form1_Load(object sender, EventArgs e)
    {
      // メインフォーム初期設定メソッド使用
      MainFormInitSeting();
    }
    #endregion

    #region コンボボックス値変更イベント
    private void cbChcp_Validated(object sender, EventArgs e)
    {
      // 拡張子コンボボックスからフォーマットを選判定する
      switch (cbChcp.Text)
      {
        case "UTF7":
          encFmt = Encoding.UTF7;
          break;

        case "BigEndianUnicode":
          encFmt = Encoding.BigEndianUnicode;
          break;

        case "Unicode":
          encFmt = Encoding.Unicode;
          break;

        case "Default":
          encFmt = Encoding.Default;
          break;

        case "ASCII":
          encFmt = Encoding.ASCII;
          break;

        case "UTF8":
          encFmt = Encoding.UTF8;
          break;

        case "UTF32":
          encFmt = Encoding.UTF32;
          break;
      }
    }
    #endregion

    #region ボタン1押下イベント
    private void button1_Click(object sender, EventArgs e)
    {
      // 対象パス取得
      string tgtPath = _comLogic.ExclIniEndWQuot(tbTgtPath.Text);
      // 出力パス取得
      string outPath = tbOutPath.Text;
      // 変換後文字コード取得
      string chcp = cbChcp.Text;

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
        ChcpConversion(tgtPath, outPath, chcp);
      }
      else if (Directory.Exists(tgtPath))
      {
        // フォルダからXMLファイルのパスだけ取得
        string[] targetFolder = Directory.GetFiles(tgtPath, "*", SearchOption.TopDirectoryOnly);

        // ループ
        foreach (string x in targetFolder)
        {
          // 文字コード変換メソッド使用
          ChcpConversion(x, outPath, chcp);
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

    #region ボタン2押下イベント
    private void button2_Click(object sender, EventArgs e)
    {

    }
    #endregion


    #region 文字コード変換メソッド
    private void ChcpConversion(string tgtPath, string outPath, string chcp)
    {
      // ファイル名取得
      string tgtName = Path.GetFileName(tgtPath);

      // ファイル読み込み
      StreamReader sr = new StreamReader(tgtPath);
      string str = sr.ReadToEnd();
      sr.Close();

      // エンコードセット
      Encoding srcEnc = Encoding.Unicode;
      Encoding destEnc = Encoding.UTF8;

      // バイナリ変換
      byte[] binaryStr = srcEnc.GetBytes(str);
      // 文字コード変換
      byte[] convBinary = Encoding.Convert(srcEnc, destEnc, binaryStr);
      // 文字列変換
      string retStr = destEnc.GetString(convBinary);

      // ファイルを開く
      StreamWriter writer = new StreamWriter(tgtName, false);
      // テキストを書き込む
      writer.WriteLine(retStr);
      // ファイルを閉じる
      writer.Close();
    }
    #endregion


    #region 雛形メソッド
    private void template()
    {

    }
    #endregion
  }
}
