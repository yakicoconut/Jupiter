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
using System.Threading;

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

      // データ連携クラスインスタンス生成
      dataStore = new DataStore();

      // サブフォームインスタンス生成
      fmPtMng = new FrmPtMng(this);
      fmComment = new FrmPtComment(this);
      fmCtrl = new FrmPtCtrl(this, dataStore);

      // 置換実行処理クラスインスタンス生成
      execRepPrc = new ExecRepPrc(dataStore);
    }
    #endregion

    #region コンフィグ取得メソッド
    private void GetConfig()
    {
      // パターンXMLフォルダ名称初期値
      PtDirName = _comLogic.GetConfigValue("DefPtFileDirName", "PatternList");

      // 検索対象初期値
      dicInitValue.Add("Comment", _comLogic.GetConfigValue("Comment", ""));
      dicInitValue.Add("IsIgnoreCase", _comLogic.GetConfigValue("IsIgnoreCase", "True"));
      dicInitValue.Add("IsNewLine", _comLogic.GetConfigValue("IsNewLine", "True"));
      dicInitValue.Add("IsTab", _comLogic.GetConfigValue("IsTab", "True"));
      dicInitValue.Add("IsMltRep", _comLogic.GetConfigValue("IsMltRep", "True"));
      dicInitValue.Add("TgtDirPath", _comLogic.GetConfigValue("TgtDirPath", ""));
      dicInitValue.Add("FileFltr", _comLogic.GetConfigValue("FileFltr", ""));
      dicInitValue.Add("EncStr", _comLogic.GetConfigValue("EncStr", "UTF8"));
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
    private MCSComLogic _comLogic = new MCSComLogic();

    // パターン管理フォーム
    private FrmPtMng fmPtMng;
    // コメントフォーム
    private FrmPtComment fmComment;
    // コントロールフォーム
    private FrmPtCtrl fmCtrl;

    // データ連携クラス
    private DataStore dataStore;
    // 置換実行処理クラス
    private ExecRepPrc execRepPrc;

    // 各コントロール初期値ディクショナリ
    private Dictionary<string, string> dicInitValue = new Dictionary<string, string>();

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

      dataStore.ListChkBox.Add(cb01);
      dataStore.ListChkBox.Add(cb02);
      dataStore.ListChkBox.Add(cb03);
      dataStore.ListChkBox.Add(cb04);
      dataStore.ListChkBox.Add(cb05);
      dataStore.ListChkBox.Add(cb06);
      dataStore.ListChkBox.Add(cb07);
      dataStore.ListChkBox.Add(cb08);
      dataStore.ListChkBox.Add(cb09);
      dataStore.ListChkBox.Add(cb10);
      dataStore.ListChkBox.Add(cb11);
      dataStore.ListChkBox.Add(cb12);
      dataStore.ListChkBox.Add(cb13);
      dataStore.ListChkBox.Add(cb14);
      dataStore.ListChkBox.Add(cb15);
      dataStore.ListChkBox.Add(cb16);
      dataStore.ListChkBox.Add(cb17);
      dataStore.ListChkBox.Add(cb18);
      dataStore.ListChkBox.Add(cb19);
      dataStore.ListChkBox.Add(cb20);
      dataStore.ListTbSearch.Add(tbSearch01);
      dataStore.ListTbSearch.Add(tbSearch02);
      dataStore.ListTbSearch.Add(tbSearch03);
      dataStore.ListTbSearch.Add(tbSearch04);
      dataStore.ListTbSearch.Add(tbSearch05);
      dataStore.ListTbSearch.Add(tbSearch06);
      dataStore.ListTbSearch.Add(tbSearch07);
      dataStore.ListTbSearch.Add(tbSearch08);
      dataStore.ListTbSearch.Add(tbSearch09);
      dataStore.ListTbSearch.Add(tbSearch10);
      dataStore.ListTbSearch.Add(tbSearch11);
      dataStore.ListTbSearch.Add(tbSearch12);
      dataStore.ListTbSearch.Add(tbSearch13);
      dataStore.ListTbSearch.Add(tbSearch14);
      dataStore.ListTbSearch.Add(tbSearch15);
      dataStore.ListTbSearch.Add(tbSearch16);
      dataStore.ListTbSearch.Add(tbSearch17);
      dataStore.ListTbSearch.Add(tbSearch18);
      dataStore.ListTbSearch.Add(tbSearch19);
      dataStore.ListTbSearch.Add(tbSearch20);
      dataStore.ListTbReplace.Add(tbReplace01);
      dataStore.ListTbReplace.Add(tbReplace02);
      dataStore.ListTbReplace.Add(tbReplace03);
      dataStore.ListTbReplace.Add(tbReplace04);
      dataStore.ListTbReplace.Add(tbReplace05);
      dataStore.ListTbReplace.Add(tbReplace06);
      dataStore.ListTbReplace.Add(tbReplace07);
      dataStore.ListTbReplace.Add(tbReplace08);
      dataStore.ListTbReplace.Add(tbReplace09);
      dataStore.ListTbReplace.Add(tbReplace10);
      dataStore.ListTbReplace.Add(tbReplace11);
      dataStore.ListTbReplace.Add(tbReplace12);
      dataStore.ListTbReplace.Add(tbReplace13);
      dataStore.ListTbReplace.Add(tbReplace14);
      dataStore.ListTbReplace.Add(tbReplace15);
      dataStore.ListTbReplace.Add(tbReplace16);
      dataStore.ListTbReplace.Add(tbReplace17);
      dataStore.ListTbReplace.Add(tbReplace18);
      dataStore.ListTbReplace.Add(tbReplace19);
      dataStore.ListTbReplace.Add(tbReplace20);

      #endregion


      // 置換文字列テキストボックス設定
      foreach (TextBox x in dataStore.ListTbReplace)
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

      // 常にメインフォームの手前に表示
      fmComment.Owner = this;
      // コメントフォーム表示
      fmComment.Show();

      // 常にメインフォームの手前に表示
      fmCtrl.Owner = this;
      // コメントフォーム表示
      fmCtrl.Show();

      // パターンXMLフォルダが存在しない場合、作成
      if (!Directory.Exists(PtDirName))
        Directory.CreateDirectory(PtDirName);
    }
    #endregion


    #region 単体用置換実行メソッド
    /// <summary>
    /// 単体用置換実行メソッド
    /// </summary>
    public void ExecRep()
    {
      // 対象リッチテキスト色初期化
      rtbTarget.SelectAll();
      rtbTarget.SelectionColor = Color.Black;

      // メインフォーム情報設定
      dataStore.MainFormSize = this.Size;
      dataStore.MainFormLoca = this.Location;

      // 画像取り込み処理クラス置換処理メインメソッド使用
      rtbResult.Text = execRepPrc.ExecRepMain(rtbTarget.Text);

      // 対象と結果の比較から差分を取得
      DiffResult[] diffResult = FastDiff.DiffChar(rtbResult.Text, rtbTarget.Text);
      foreach (DiffResult x in diffResult)
      {
        // 差異が存在する場合
        if (x.Modified)
        {
          // 対象選択
          rtbTarget.Select(x.ModifiedStart, x.ModifiedLength);
          // カラーリング
          rtbTarget.SelectionColor = Color.Red;
        }
      }
    }
    #endregion

    #region 複数用置換実行メソッド
    /// <summary>
    /// 複数用置換実行メソッド
    /// </summary>
    /// <param name="tgtDirPath">対象フォルダパス</param>
    /// <param name="fileFltr">ファイルフィルタ</param>
    /// <param name="encStr">文字コード文字列</param>
    public void ExecRep(string tgtDirPath, string fileFltr, string encStr)
    {
      // メインフォーム情報設定
      dataStore.MainFormSize = this.Size;
      dataStore.MainFormLoca = this.Location;

      // 複数用置換処理メインメソッド使用
      execRepPrc.ExecRepMain(tgtDirPath, fileFltr, encStr);
    }
    #endregion


    #region パターン管理フォーム起動メソッド
    public void ShowPtMngFrm()
    {
      // パターン管理フォーム呼び出し
      fmPtMng.ShowDialog();

      // ねずみ返し_オプションフォームでファイル選択されなかった場合
      if (InpPtFilePath == null)
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
      foreach (CheckBox x in dataStore.ListChkBox)
      {
        x.Checked = chk;
      }
    }
    #endregion


    #region 共通_全削除ボタン押下イベント
    private void Com_AllCrearButton_Click(object sender, EventArgs e)
    {
      switch (sender)
      {
        // 型がボタンかつ対象コントロールと一致する場合
        case Button ctrl when sender.Equals(btAllCrearSearch):
          // 検索対象ボックス全削除
          foreach (TextBox x in dataStore.ListTbSearch)
          {
            x.ResetText();
          }
          break;

        case Button ctrl when sender.Equals(btAllCrearReplace):
          // 置換文字列ボックス全削除
          foreach (TextBox x in dataStore.ListTbReplace)
          {
            x.ResetText();
          }
          break;

        default:
          break;
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

        // テキストフォーマットで貼り付け
        rtbTarget.Paste(DataFormats.GetFormat(DataFormats.Text));
        e.Handled = true;
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
      fmComment.tbComment.Text = string.Empty;
      if (dicInitValue.ContainsKey("Comment"))
        fmComment.tbComment.Text = dicInitValue["Comment"];

      // コントロールフォーム
      if (dicInitValue.ContainsKey("IsIgnoreCase"))
        dataStore.IsIgnoreCase = bool.Parse(dicInitValue["IsIgnoreCase"]);
      if (dicInitValue.ContainsKey("IsNewLine"))
        dataStore.IsNewLine = bool.Parse(dicInitValue["IsNewLine"]);
      if (dicInitValue.ContainsKey("IsTab"))
        dataStore.IsTab = bool.Parse(dicInitValue["IsTab"]);
      if (dicInitValue.ContainsKey("IsMltRep"))
        dataStore.IsMltRep = bool.Parse(dicInitValue["IsMltRep"]);
      if (dicInitValue.ContainsKey("TgtDirPath"))
        dataStore.TgtDirPath = dicInitValue["TgtDirPath"];
      if (dicInitValue.ContainsKey("FileFltr"))
        dataStore.FileFltr = dicInitValue["FileFltr"];
      if (dicInitValue.ContainsKey("EncStr"))
        dataStore.EncStr = dicInitValue["EncStr"];

      // コントロールフォーム更新
      fmCtrl.InitCtrlValue();

      // 各コントロール値初期化
      for (int i = 0; i < 20; i++)
      {
        // ディクショナリの添え字は1始まり
        string padTwo = (i + 1).ToString().PadLeft(2, '0');

        // デフォルト値
        dataStore.ListChkBox[i].Checked = true;
        dataStore.ListTbSearch[i].Text = string.Empty;
        dataStore.ListTbReplace[i].Text = string.Empty;

        // ディクショナリ存在確認
        if (dicInitValue.ContainsKey("Check" + padTwo))
          dataStore.ListChkBox[i].Checked = dicInitValue["Check" + padTwo].ToLower() == "true";
        if (dicInitValue.ContainsKey("Search" + padTwo))
          dataStore.ListTbSearch[i].Text = dicInitValue["Search" + padTwo];
        if (dicInitValue.ContainsKey("Replace" + padTwo))
          dataStore.ListTbReplace[i].Text = dicInitValue["Replace" + padTwo];
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
      using (StreamReader sr = new StreamReader(targetPath))
      using (XmlReader xmlReader = XmlReader.Create(sr, setting))
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
          if (!Regex.Match(keyName, @"Comment|IsIgnoreCase|IsNewLine|IsTab|IsMltRep|TgtDirPath|FileFltr|EncStr|Check\d\d|Search\d\d|Replace\d\d").Success)
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
      // ファイル名指定がない場合
      if (outPtFileName == string.Empty)
      {
        // 現在時刻取得
        DateTime now = DateTime.Now;
        string outputDate = now.ToString("yyyyMMddHHmmssfff");
        outPtFileName = "Pattern" + "_" + outputDate;
      }

      // 出力ファイル設定
      string outputFileName = outPtDirPath + @"\" + outPtFileName + ".xml";
      // 保存咲ファイル存在確認
      if (File.Exists(outputFileName))
      {
        // 存在する場合、上書き選択肢表示
        DialogResult result = MessageBox.Show(this, "上書きしますか?", "保存先のファイルが存在しています", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result == DialogResult.No)
        {
          return;
        }
      }

      // 出力用変数
      string outStrCmt = string.Empty;
      string outStrIsIgnoreCase = string.Empty;
      string outStrIsNewLine = string.Empty;
      string outStrIsTab = string.Empty;
      string outStrChk = string.Empty;
      string outStrSearch = string.Empty;
      string outStrReplace = string.Empty;
      string outIsMltRep = string.Empty;
      string outTgtDirPath = string.Empty;
      string outFileFltr = string.Empty;
      string outChcp = string.Empty;
      string XML_FMT = "  <add key=\"{0}\" value=\"{1}\"/>" + Environment.NewLine;
      // XML用
      string XML_DEC = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + Environment.NewLine;
      string XML_ROOT_START = "<Root>" + Environment.NewLine;
      string XML_ROOT_END = "</Root>";

      // コメントフォームのコメントテキストボックスから文字列取得
      outStrCmt = fmComment.tbComment.Text;
      // XML用文字に変換
      outStrCmt = Regex.Replace(outStrCmt, "&", "&amp;");
      outStrCmt = Regex.Replace(outStrCmt, "\"", "&quot;");
      outStrCmt = Regex.Replace(outStrCmt, "'", "&apos;");
      outStrCmt = Regex.Replace(outStrCmt, "<", "&lt;");
      outStrCmt = Regex.Replace(outStrCmt, ">", "&gt;");
      outStrCmt = Regex.Replace(outStrCmt, "\r\n", "&#xD;&#xA;");
      outStrCmt = string.Format(XML_FMT, "Comment", outStrCmt);

      // 大小文字判別、改行、タブモード判断
      outStrIsIgnoreCase = string.Format(XML_FMT, "IsIgnoreCase", dataStore.IsIgnoreCase.ToString());
      outStrIsNewLine = string.Format(XML_FMT, "IsNewLine", dataStore.IsNewLine.ToString());
      outStrIsTab = string.Format(XML_FMT, "IsTab", dataStore.IsTab.ToString());
      // 一括置換
      outIsMltRep = string.Format(XML_FMT, "IsMltRep", dataStore.IsMltRep.ToString());
      outTgtDirPath = string.Format(XML_FMT, "TgtDirPath", dataStore.TgtDirPath);
      outFileFltr = string.Format(XML_FMT, "FileFltr", dataStore.FileFltr);
      outChcp = string.Format(XML_FMT, "EncStr", dataStore.EncStr);

      // 全チェックボックスループ
      int i = 0;
      foreach (CheckBox x in dataStore.ListChkBox)
      {
        string chkStr = dataStore.ListChkBox[i].Checked.ToString();
        string searchStr = dataStore.ListTbSearch[i].Text;
        string replaceStr = dataStore.ListTbReplace[i].Text;

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
        outStrChk += string.Format(XML_FMT, "Check" + i.ToString().PadLeft(2, '0'), chkStr);
        outStrSearch += string.Format(XML_FMT, "Search" + i.ToString().PadLeft(2, '0'), searchStr);
        outStrReplace += string.Format(XML_FMT, "Replace" + i.ToString().PadLeft(2, '0'), replaceStr);
      }

      // 出力ファイルの作成
      // 引数:対象ファイル、上書き可不可、文字コード
      using (StreamWriter sw = new StreamWriter(outputFileName, false, Encoding.GetEncoding("UTF-8")))
      {
        sw.WriteLine(
          XML_DEC +
          XML_ROOT_START +
          outStrCmt +
          outStrIsIgnoreCase +
          outStrIsNewLine +
          outStrIsTab +
          outIsMltRep +
          outTgtDirPath +
          outFileFltr +
          outChcp +
          outStrChk +
          outStrSearch +
          outStrReplace +
          XML_ROOT_END
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
