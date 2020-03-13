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
using System.Text.RegularExpressions;
using FastTxtDiff;
using System.Xml;

#region メモ
/*
 * ※リッチテキストボックスは
 *   改行コードを自動的に\nに変換する
 *   
 * ※差分比較は以下のパターンで正常にならない
 *   「abc」→「acb」
 * 
 * ・SplitContainerのスクロールバーを表示すると
 *   内部のコントロールのデザイナー上のサイズと実行時の表示が変わる
 *   →一旦、スクロールバーを非表示にした状態で内部コントロールのサイズを変更し
 *     .Designer.csファイルでスクロールバーを表示設定にすることでなぜか回避可能
 */
#endregion
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

      // サブフォームインスタンス生成
      fmPtMng = new FrmPtMng(this);
      fmComment = new FrmPtComment(this);
    }
    #endregion

    #region コンフィグ取得メソッド
    private void GetConfig()
    {
      // パターンXMLフォルダ名称初期値
      PtDirName = _comLogic.GetConfigValue("DefPtFileDirName", "Pattern");

      // 検索対象初期値
      dicInitValue.Add("Comment", _comLogic.GetConfigValue("Comment", ""));
      for (int i = 1; i <= 20; i++)
      {
        // 1~20を二桁で作成
        string padTwo = i.ToString().PadLeft(2, '0');
        dicInitValue.Add("Search" + padTwo, _comLogic.GetConfigValue("Search" + padTwo, ""));
        dicInitValue.Add("Replace" + padTwo, _comLogic.GetConfigValue("Replace" + padTwo, ""));
        dicInitValue.Add("Check" + padTwo, _comLogic.GetConfigValue("Check" + padTwo, "false"));
      }
    }
    #endregion


    #region 宣言

    // 共通ロジッククラスインスタンス
    MCSComLogic _comLogic = new MCSComLogic();
    // パターン管理フォーム
    FrmPtMng fmPtMng;
    // コメントフォーム
    FrmPtComment fmComment;

    // 各コントロール初期値ディクショナリ
    Dictionary<string, string> dicInitValue = new Dictionary<string, string>();

    // チェックボックスリスト
    List<CheckBox> listChkBox = new List<CheckBox>();
    // 検索対象テキストボックスリスト
    List<TextBox> listTbSearch = new List<TextBox>();
    // 置換文字列テキストボックスリスト
    List<TextBox> listTbReplace = new List<TextBox>();

    #endregion


    #region プロパティ

    // パターンXMLフォルダ名称
    public string PtDirName { get; set; }
    // 入力パターンXMLファイルパス
    public string InpPtFilePath { get; set; }

    #endregion


    #region フォームロードイベント
    private void Form1_Load(object sender, EventArgs e)
    {
      #region リストにコントロール格納

      listChkBox.Add(cb01);
      listChkBox.Add(cb02);
      listChkBox.Add(cb03);
      listChkBox.Add(cb04);
      listChkBox.Add(cb05);
      listChkBox.Add(cb06);
      listChkBox.Add(cb07);
      listChkBox.Add(cb08);
      listChkBox.Add(cb09);
      listChkBox.Add(cb10);
      listChkBox.Add(cb11);
      listChkBox.Add(cb12);
      listChkBox.Add(cb13);
      listChkBox.Add(cb14);
      listChkBox.Add(cb15);
      listChkBox.Add(cb16);
      listChkBox.Add(cb17);
      listChkBox.Add(cb18);
      listChkBox.Add(cb19);
      listChkBox.Add(cb20);
      listTbSearch.Add(tbSearch01);
      listTbSearch.Add(tbSearch02);
      listTbSearch.Add(tbSearch03);
      listTbSearch.Add(tbSearch04);
      listTbSearch.Add(tbSearch05);
      listTbSearch.Add(tbSearch06);
      listTbSearch.Add(tbSearch07);
      listTbSearch.Add(tbSearch08);
      listTbSearch.Add(tbSearch09);
      listTbSearch.Add(tbSearch10);
      listTbSearch.Add(tbSearch11);
      listTbSearch.Add(tbSearch12);
      listTbSearch.Add(tbSearch13);
      listTbSearch.Add(tbSearch14);
      listTbSearch.Add(tbSearch15);
      listTbSearch.Add(tbSearch16);
      listTbSearch.Add(tbSearch17);
      listTbSearch.Add(tbSearch18);
      listTbSearch.Add(tbSearch19);
      listTbSearch.Add(tbSearch20);
      listTbReplace.Add(tbReplace01);
      listTbReplace.Add(tbReplace02);
      listTbReplace.Add(tbReplace03);
      listTbReplace.Add(tbReplace04);
      listTbReplace.Add(tbReplace05);
      listTbReplace.Add(tbReplace06);
      listTbReplace.Add(tbReplace07);
      listTbReplace.Add(tbReplace08);
      listTbReplace.Add(tbReplace09);
      listTbReplace.Add(tbReplace10);
      listTbReplace.Add(tbReplace11);
      listTbReplace.Add(tbReplace12);
      listTbReplace.Add(tbReplace13);
      listTbReplace.Add(tbReplace14);
      listTbReplace.Add(tbReplace15);
      listTbReplace.Add(tbReplace16);
      listTbReplace.Add(tbReplace17);
      listTbReplace.Add(tbReplace18);
      listTbReplace.Add(tbReplace19);
      listTbReplace.Add(tbReplace20);

      #endregion


      // 置換文字列テキストボックス設定
      foreach (TextBox x in listTbReplace)
      {
        // SplitContainer内のコントロールのサイズ位置を無理やり変更
        x.Size = new Size(402, 19);
      }

      // SplitContainer内のコントロールのサイズ位置を無理やり変更
      rtbTarget.Size = new Size(315, 242);
      rtbResult.Size = new Size(360, 242);
      splcTargetResult.Size = new Size(705, 335);

      // 対象・結果ボックスでタブ記号が入力されるようにする
      rtbTarget.AcceptsTab = true;
      rtbResult.AcceptsTab = true;

      // コントロール値初期化メソッド使用
      InitCtrlValue();

      // コメントフォームのプロパティに本クラスを設定
      fmComment.form1 = this;
      // 常にメインフォームの手前に表示
      fmComment.Owner = this;
      // コメントフォーム表示
      fmComment.Show();
    }
    #endregion


    #region 置換ボタン押下イベント
    private void btReplace_Click(object sender, EventArgs e)
    {
      // コントロール変数化
      RichTextBox target = rtbTarget;
      RichTextBox result = rtbResult;
      string resultStr = target.Text;

      // 対象・結果の色を黒で初期化
      rtbTarget.SelectAll();
      rtbTarget.SelectionColor = Color.Black;
      rtbResult.SelectAll();
      rtbResult.SelectionColor = Color.Black;

      int i = 0;
      foreach (CheckBox x in listChkBox)
      {
        // ねずみ返し_チェックが付いていない場合
        if (!x.Checked)
        {
          i += 1;
          continue;
        }
        // ねずみ返し_検索対象が空の場合
        if (listTbSearch[i].Text == string.Empty)
        {
          i += 1;
          continue;
        }

        // Regexオプション
        RegexOptions regOption;
        regOption = RegexOptions.None;
        // 大小文字判別チェック
        if (cbIgnoreCase.Checked)
        {
          // 大小文字判別しない
          regOption = RegexOptions.IgnoreCase;
        }

        /* 色変更 */
        // Regexオブジェクト作成
        Regex regex = new Regex(listTbSearch[i].Text, regOption);

        // 正規表現と一致する対象をすべて検索
        MatchCollection matchCollect = regex.Matches(target.Text);
        foreach (Match y in matchCollect)
        {
          // 対象選択
          target.Select(y.Index, y.Length);
          // カラーリング
          target.SelectionColor = Color.Red;
          // 反映
          rtbTarget = target;
        }

        /* 置換え */
        // 複数行モード(「^」と「$」の有効化)
        resultStr = Regex.Replace(resultStr, listTbSearch[i].Text, listTbReplace[i].Text, RegexOptions.Multiline);
        // 改行チェック
        if (cbNewLine.Checked)
        {
          // 「\n」を改行とする
          resultStr = Regex.Replace(resultStr, @"\\n", Environment.NewLine);
        }

        i += 1;
      }

      // 置換えた文字列をリッチテキストに設定
      result.Text = resultStr;

      // 対象と結果の比較から差分を取得
      DiffResult[] diffResult = FastDiff.DiffChar(target.Text, result.Text);
      foreach (DiffResult x in diffResult)
      {
        // 差異が存在する場合
        if (x.Modified)
        {
          // 対象選択
          result.Select(x.ModifiedStart, x.ModifiedLength);
          // カラーリング
          result.SelectionColor = Color.Red;
        }
      }

      // コミット
      rtbTarget = target;
      rtbResult = result;
    }
    #endregion

    #region パターンボタン押下イベント
    private void btPattern_Click(object sender, EventArgs e)
    {
      // 入力パターンXMLファイルパス初期化
      InpPtFilePath = string.Empty;

      // パターン管理フォームのプロパティに本クラスを設定
      fmPtMng.form1 = this;
      // パターン管理フォーム呼び出し
      fmPtMng.ShowDialog();

      // ねずみ返し_オプションフォームでファイル選択されなかった場合
      if (InpPtFilePath == string.Empty)
      {
        return;
      }

      // パターンXML読み込みメソッド使用
      ReadPatternFile(InpPtFilePath);
      // コントロール値初期化メソッド
      InitCtrlValue();
      // ファイル名テキストボックス更新
      tbPatternFileName.Text = Path.GetFileNameWithoutExtension(InpPtFilePath);
    }
    #endregion


    #region 全選択チェックボックス押下イベント
    private void cbAllCheck_CheckedChanged(object sender, EventArgs e)
    {
      bool chk = false;

      // 全選択チェックボックスがチェックの場合
      if (cbAllCheck.Checked)
      {
        // 全チェック設定
        chk = true;
      }

      // 全チェックボックスループ
      foreach (CheckBox x in listChkBox)
      {
        x.Checked = chk;
      }
    }
    #endregion

    #region 検索対象全削除ボタン押下イベント
    private void btAllCrearSearch_Click(object sender, EventArgs e)
    {
      // 検索対象ボックス全削除
      foreach (TextBox x in listTbSearch)
      {
        x.ResetText();
      }
    }
    #endregion

    #region 置換文字列全削除ボタン押下イベント
    private void btAllCrearReplace_Click(object sender, EventArgs e)
    {
      // 置換文字列ボックス全削除
      foreach (TextBox x in listTbReplace)
      {
        x.ResetText();
      }
    }
    #endregion


    #region 検索対象ボックスキー押下イベント
    private void rtbTarget_KeyDown(object sender, KeyEventArgs e)
    {
      // キーボードペースト
      if (e.Control == true && e.KeyCode == Keys.V)
      {
        // 置換え時の色変更を引き継いでしまうときがあるため
        // ペースト時に黒を設定
        rtbTarget.SelectionColor = Color.Black;
      }
    }
    #endregion


    #region パターンパネルスクロールイベント
    private void splcSearchReplace_Scroll(object sender, ScrollEventArgs e)
    {
      // 最上位へのスクロール時
      if (splcSearchReplace.Panel2.VerticalScroll.Value == 0)
      {
        // パネル1のスクロールを完全に0にするためスクロールバーを一時的に表示
        splcSearchReplace.Panel1.VerticalScroll.Visible = true;
      }

      // 置換文字列パネルのスクロール値を検索文字列パネルのスクロール値に合わせる
      splcSearchReplace.Panel1.VerticalScroll.Value = splcSearchReplace.Panel2.VerticalScroll.Value;

      if (splcSearchReplace.Panel2.VerticalScroll.Value == 0)
      {
        // スクロールバー表示を戻す
        splcSearchReplace.Panel1.VerticalScroll.Visible = false;
        splcSearchReplace.Panel1.AutoScroll = false;
      }
    }
    #endregion

    #region スプリットパネル上下変更イベント
    private void splcPatternResult_SplitterMoved(object sender, SplitterEventArgs e)
    {
      // 置換文字列パネルのスクロール値を検索文字列パネルのスクロール値に合わせる
      splcSearchReplace.Panel1.VerticalScroll.Visible = true;
      splcSearchReplace.Panel1.VerticalScroll.Value = splcSearchReplace.Panel2.VerticalScroll.Value;
      splcSearchReplace.Panel1.VerticalScroll.Visible = false;
      splcSearchReplace.Panel1.AutoScroll = false;
    }
    #endregion


    #region コントロール値初期化メソッド
    private void InitCtrlValue()
    {
      // コメント
      // デフォルト値
      fmComment.tbComment.Text = string.Empty;
      if (dicInitValue.ContainsKey("Comment"))
      {
        // 設定値から取得
        fmComment.tbComment.Text = dicInitValue["Comment"];
      }

      // 各コントロール値初期化
      for (int i = 0; i < 20; i++)
      {
        // ディクショナリの添え字は1始まり
        string padTwo = (i + 1).ToString().PadLeft(2, '0');

        // デフォルト値
        listChkBox[i].Checked = true;
        listTbSearch[i].Text = string.Empty;
        listTbReplace[i].Text = string.Empty;

        // ディクショナリ存在確認
        if (dicInitValue.ContainsKey("Check" + padTwo))
          listChkBox[i].Checked = dicInitValue["Check" + padTwo].ToLower() == "true";
        if (dicInitValue.ContainsKey("Search" + padTwo))
          listTbSearch[i].Text = dicInitValue["Search" + padTwo];
        if (dicInitValue.ContainsKey("Replace" + padTwo))
          listTbReplace[i].Text = dicInitValue["Replace" + padTwo];
      }
    }
    #endregion


    #region パターンXML読み込みメソッド
    private void ReadPatternFile(string targetPath)
    {
      // 各コントロール初期値ディクショナリクリア
      dicInitValue.Clear();

      /* StringReader設定 */
      XmlReaderSettings setting = new XmlReaderSettings();
      // コメントを無視するかどうか
      // ※デフォルトもfalseだがサンプルのため明示的に設定
      setting.IgnoreComments = false;
      // 処理命令(スタイルシートの宣言等)を無視するかどうか
      // ※デフォルトもfalseだがサンプルのため明示的に設定
      setting.IgnoreProcessingInstructions = false;
      // 意味のない空白を無視するかどうか
      setting.IgnoreWhitespace = true;

      // ファイルからXmlReaderでXMLを取得
      using (XmlReader xmlReader = XmlReader.Create(new StreamReader(targetPath), setting))
      {
        // ルートタグへ移動
        bool root = xmlReader.ReadToFollowing("Root");
        // ねずみ返し_対象タグが存在しない場合
        if (!root)
        {
          return;
        }

        // 「add」タグを巡回
        while (xmlReader.Read())
        {
          // 最初の属性「Key」へ
          xmlReader.MoveToFirstAttribute();
          string keyName = xmlReader.Value;
          // ねずみ返し_キーの値が違う場合
          if (!Regex.Match(keyName, @"Comment|Check\d\d|Search\d\d|Replace\d\d").Success)
          {
            continue;
          }

          // 二番目の属性「value」へ
          xmlReader.MoveToNextAttribute();
          string keyValue = xmlReader.Value;

          // 各コントロール初期値ディクショナリ追加        
          dicInitValue.Add(keyName, keyValue);
        }
      }
    }
    #endregion

    #region パターンXML保存メソッド
    public void SavePatternXml(string outPtDirPath, string outPtFileName)
    {
      // 現在時刻取得
      DateTime now = DateTime.Now;
      string outputDate = now.ToString("yyyyMMddHHmmssfff");
      string outputFileName = outPtDirPath + @"\" + outPtFileName + "_" + outputDate + ".xml";

      // 出力用変数
      string outStrComment = string.Empty;
      string outStrChk = string.Empty;
      string outStrSearch = string.Empty;
      string outStrReplace = string.Empty;
      string commentFormat = "  <add key=\"Comment\" value=\"{0}\"/>";
      string chkFormat = "  <add key=\"Check{0}\" value=\"{1}\"/>";
      string searchFormat = "  <add key=\"Search{0}\" value=\"{1}\"/>";
      string replaceFormat = "  <add key=\"Replace{0}\" value=\"{1}\"/>";
      // XML用
      string xmlDec = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
      string xmlRootStart = "<Root>";
      string xmlRootEnd = "</Root>";

      // コメントフォームのコメントテキストボックスから文字列取得
      outStrComment = fmComment.tbComment.Text;
      // XML用文字に変換
      outStrComment = Regex.Replace(outStrComment, "&", "&amp;");
      outStrComment = Regex.Replace(outStrComment, "\"", "&quot;");
      outStrComment = Regex.Replace(outStrComment, "'", "&apos;");
      outStrComment = Regex.Replace(outStrComment, "<", "&lt;");
      outStrComment = Regex.Replace(outStrComment, ">", "&gt;");
      outStrComment = Regex.Replace(outStrComment, "\r\n", "&#xD;&#xA;");
      outStrComment = string.Format(commentFormat, outStrComment);

      // 全チェックボックスループ
      int i = 0;
      foreach (CheckBox x in listChkBox)
      {
        string chkStr = listChkBox[i].Checked.ToString();
        string searchStr = listTbSearch[i].Text;
        string replaceStr = listTbReplace[i].Text;

        // XML用文字に変換
        searchStr = Regex.Replace(searchStr, "&", "&amp;");
        searchStr = Regex.Replace(searchStr, "\"", "&quot;");
        searchStr = Regex.Replace(searchStr, "'", "&apos;");
        searchStr = Regex.Replace(searchStr, "<", "&lt;");
        searchStr = Regex.Replace(searchStr, ">", "&gt;");
        replaceStr = Regex.Replace(replaceStr, "&", "&amp;");
        replaceStr = Regex.Replace(replaceStr, "\"", "&quot;");
        replaceStr = Regex.Replace(replaceStr, "'", "&apos;");
        replaceStr = Regex.Replace(replaceStr, "<", "&lt;");
        replaceStr = Regex.Replace(replaceStr, ">", "&gt;");

        // コンフィグの番号は1始まりのためここでインクリメント
        i += 1;

        // 変数格納
        outStrChk += string.Format(chkFormat, i.ToString().PadLeft(2, '0'), chkStr) + Environment.NewLine;
        outStrSearch += string.Format(searchFormat, i.ToString().PadLeft(2, '0'), searchStr) + Environment.NewLine;
        outStrReplace += string.Format(replaceFormat, i.ToString().PadLeft(2, '0'), replaceStr) + Environment.NewLine;
      }

      // 出力ファイルの作成
      // 引数:対象ファイル、上書き可不可、文字コード
      using (StreamWriter sw = new StreamWriter(outputFileName, true, Encoding.GetEncoding("UTF-8")))
      {
        sw.WriteLine(
          xmlDec + Environment.NewLine +
          xmlRootStart + Environment.NewLine +
          outStrComment + Environment.NewLine +
          outStrChk +
          outStrSearch +
          outStrReplace +
          xmlRootEnd
          );
      }
    }
    #endregion


    #region Exe位置を開くメソッド
    private void OpenExe()
    {
      // 自身のフォルダを開く
      string myLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
      Process.Start(myLocation);
    }
    #endregion


    #region 雛形メソッド
    private void template()
    {

    }
    #endregion
  }
}
