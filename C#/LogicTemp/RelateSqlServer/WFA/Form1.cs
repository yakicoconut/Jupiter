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
using System.Data.SqlClient;
using System.Xml;

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
      // ローカルサーバ名称
      localServer = _comLogic.GetConfigValue("LocalServer", "");
      // ローカルDB名称
      localDB = _comLogic.GetConfigValue("LocalDB", "");
      // 実行SQL
      execSqlScript = _comLogic.GetConfigValue("ExecSqlScript", "");
      //// 出力ファイル名称
      //outFileName = _comLogic.GetConfigValue("OutFileName", "");
    }
    #endregion


    #region 宣言

    // 共通ロジッククラスインスタンス
    MCSComLogic _comLogic = new MCSComLogic();

    //SQL Server接続値
    string sqlConnect_Left = @"Trusted_Connection = Yes;Data Source=";
    string sqlConnect_Center = @"Initial Catalog=";

    // ローカルサーバ名称
    string localServer;
    // ローカルDB名称
    string localDB;
    // 実行SQL
    string execSqlScript;
    // 出力ファイル名称
    string outFileName;

    #endregion


    #region フォームロードイベント
    private void Form1_Load(object sender, EventArgs e)
    {

    }
    #endregion

    #region ボタン1押下イベント
    private void button1_Click(object sender, EventArgs e)
    {
      // 出力ファイル名テキストボックスに値が無ければ現在時刻を指定
      outFileName = tbOutFileName.Text == string.Empty ? DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".txt" : tbOutFileName.Text + ".txt";
      //// 出力ファイルパスが「DateTime」なら現在時刻
      //outFileName = outFileName == "DateTime" ? DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".txt" : outFileName;

      // 同じファイル名が存在する場合
      if (File.Exists(outFileName))
      {
        DialogResult result = MessageBox.Show("同じ名称のファイルが存在します\r\n上書きしますか?", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        // ねずみ返し_「いいえ」選択
        if (result == DialogResult.No)
        {
          return;
        }
      }

      try
      {
        // SQL実行メソッド使用
        DataSet resultDataSet = SqlExecute(execSqlScript);

        // 一つ目のテーブル取得
        DataTable resultDataTable = resultDataSet.Tables[0];
        // 全セレクト
        DataRow[] resultDataRows = resultDataTable.Select();
        // 一つ目のセレクト
        DataRow resultDataRow = resultDataRows[0];
        // 一つ目の結果
        object resultRecord = resultDataRow.ItemArray[0];

        // 文字列XML変換メソッド使用
        string result = StrToXml(resultRecord.ToString());

        // 引数:対象ファイル、上書き可不可、文字コード
        using (StreamWriter sw = new StreamWriter(outFileName, false, Encoding.GetEncoding("shift_jis")))
        {
          sw.WriteLine(result);
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString());
      }
    }
    #endregion

    #region ボタン2押下イベント
    private void button2_Click(object sender, EventArgs e)
    {

    }
    #endregion


    #region SQL実行メソッド
    private DataSet SqlExecute(string sqlScript)
    {
      // SQLインスタンス
      SqlConnection conn = new SqlConnection();
      SqlCommand command = new SqlCommand();
      // データセットのインスタンス生成
      DataSet dbSet = new DataSet();

      // SQL接続設定
      conn.ConnectionString = sqlConnect_Left + localServer + ";" + sqlConnect_Center + localDB + ";";

      // アダプターの使用
      using (SqlDataAdapter adapter = new SqlDataAdapter())
      {
        // SQL接続
        command.Connection = conn;
        // SQｌ実行
        command.CommandText = sqlScript;
        adapter.SelectCommand = command;

        // SQL実行エラー処理
        try
        {
          // 結果の取得
          adapter.Fill(dbSet);
        }
        catch
        {
          // 例外を一つ上のメソッドに投げる
          throw;
        }
      }

      return dbSet;
    }
    #endregion

    #region SQLデータテーブル取得メソッド
    private DataTable SqlGetDbTable(string SQLScript, string TableName)
    {
      // SQLインスタンス
      SqlConnection conn = new SqlConnection();
      SqlCommand command = new SqlCommand();
      // データテーブルのインスタンスをテーブル名をつけて生成
      DataTable dbTable = new DataTable(TableName);

      // SQL接続設定
      conn.ConnectionString = sqlConnect_Left + localServer + ";" + sqlConnect_Center + localDB + ";";

      // アダプターの使用
      using (SqlDataAdapter adapter = new SqlDataAdapter())
      {
        // SQL接続
        command.Connection = conn;
        // SQｌ実行
        command.CommandText = SQLScript;
        adapter.SelectCommand = command;

        // SQL接続エラー処理
        try
        {
          // 結果の取得
          adapter.Fill(dbTable);
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.Message);
          throw ex;
        }
      }

      return dbTable;
    }
    #endregion


    #region 文字列XML変換メソッド
    /// <summary>
    /// 文字列XML変換メソッド
    /// </summary>
    private string StrToXml(string targetStr)
    {
      /* StringReader設定 */
      XmlReaderSettings setting = new XmlReaderSettings();
      // コメントを無視するかどうか
      // ※デフォルトもfalseだがサンプルのため明示的に設定
      setting.IgnoreComments = false;
      // 処理命令(スタイルシートの宣言等)を無視するかどうか
      // ※デフォルトもfalseだがサンプルのため明示的に設定
      setting.IgnoreProcessingInstructions = false;
      //意味のない空白を無視するかどうか
      setting.IgnoreWhitespace = true;

      // 文字列からXMLに変換
      XmlDocument doc = new XmlDocument();
      doc.LoadXml(targetStr);

      // XMLインデント整形メソッド使用
      string resultStr = FormatXmlDocument(doc);

      // 内容を返却
      return resultStr;
    }
    #endregion

    #region XMLインデント整形メソッド
    private string FormatXmlDocument(XmlDocument xmlDocument)
    {
      MemoryStream stream = new MemoryStream();
      XmlTextWriter writer = new XmlTextWriter(stream, Encoding.Unicode);

      // インデント設定
      writer.Formatting = Formatting.Indented;
      // インデント長
      writer.Indentation = 2;
      // インデント文字
      writer.IndentChar = ' ';

      // インデント変換
      xmlDocument.WriteContentTo(writer);
      writer.Flush();
      stream.Flush();
      stream.Position = 0;

      // 文字列変換
      StreamReader reader = new StreamReader(stream);
      string formattedXml = reader.ReadToEnd();

      return formattedXml;
    }
    #endregion


    #region 雛形メソッド
    private void template()
    {

    }
    #endregion
  }
}
