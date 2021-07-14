using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;

#region メモ
/*
 * ※リッチテキストボックスは
 *   改行コードを自動的に\nに変換する
 */
#endregion
namespace WFA
{
  /// <summary>
  /// メインフォーム
  /// </summary>
  public partial class FrmMain : Form
  {
    #region コンストラクタ
    public FrmMain()
    {
      InitializeComponent();

      // クラス変数インスタンス生成メソッド
      _comLgc = new CSPComLogic();
      // 各コントロール初期値ディクショナリインスタンス生成
      dicIniVal = new Dictionary<string, string>();

      // コンフィグ取得メソッド使用
      GetConfig();

      // データ連携クラスインスタンス生成
      dataStore = new DataStore();

      // サブフォームインスタンス生成
      frmPtMng = new FrmPtMng(this);
      frmPtCmt = new FrmPtCmt(this);
      frmCtrl = new FrmCtrl(this, dataStore);

      // 置換実行処理クラスインスタンス生成
      execRepPrc = new ExecRepPrc(dataStore);
    }
    #endregion


    #region コンフィグ取得メソッド
    private void GetConfig()
    {
      // パターンXMLフォルダ名称初期値
      PtDirName = _comLgc.GetConfigValue("DefPtFileDirName", "PatternList");

      // 検索対象初期値
      dicIniVal.Add("Comment", _comLgc.GetConfigValue("Comment", ""));
      dicIniVal.Add("IsCaseSens", _comLgc.GetConfigValue("IsCaseSens", "True"));
      dicIniVal.Add("IsNewLine", _comLgc.GetConfigValue("IsNewLine", "True"));
      dicIniVal.Add("IsTab", _comLgc.GetConfigValue("IsTab", "True"));
      dicIniVal.Add("IsMultRep", _comLgc.GetConfigValue("IsMultRep", "True"));
      dicIniVal.Add("TgtDirPath", _comLgc.GetConfigValue("TgtDirPath", ""));
      dicIniVal.Add("FileFilter", _comLgc.GetConfigValue("FileFilter", ""));
      dicIniVal.Add("EncStr", _comLgc.GetConfigValue("EncStr", "UTF8"));
      dicIniVal.Add("DestDirPath", _comLgc.GetConfigValue("DestDirPath", ""));
      for (int i = 1; i <= 20; i++)
      {
        // 1~20を二桁で作成
        string padTwo = i.ToString().PadLeft(2, '0');
        dicIniVal.Add("Search" + padTwo, _comLgc.GetConfigValue("Search" + padTwo, ""));
        dicIniVal.Add("Replace" + padTwo, _comLgc.GetConfigValue("Replace" + padTwo, ""));
        dicIniVal.Add("Check" + padTwo, _comLgc.GetConfigValue("Check" + padTwo, "false"));
      }
    }
    #endregion


    #region 宣言

    // 共通ロジッククラス
    private CSPComLogic _comLgc;

    // パターン管理フォーム
    private FrmPtMng frmPtMng;
    // コメントフォーム
    private FrmPtCmt frmPtCmt;
    // コントロールフォーム
    private FrmCtrl frmCtrl;

    // データ連携クラス
    private DataStore dataStore;
    // 置換実行処理クラス
    private ExecRepPrc execRepPrc;

    // 各コントロール初期値ディクショナリ
    private Dictionary<string, string> dicIniVal;

    #endregion


    #region プロパティ

    // パターンXMLフォルダ名称
    public string PtDirName { get; set; }
    // 入力パターンXMLファイルパス
    public string InpPtFilePath { get; set; }

    #endregion


    #region フォームロードイベント
    private void FrmMain_Load(object sender, EventArgs e)
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
      rtbTarget.Size = new Size(315, 225);
      rtbResult.Size = new Size(360, 225);
      splcTargetResult.Size = new Size(705, 335);

      // 対象・結果ボックスでタブ記号が入力されるようにする
      rtbTarget.AcceptsTab = true;
      rtbResult.AcceptsTab = true;

      // コントロール値初期化メソッド使用
      InitCtrlVal();

      // 常にメインフォームの手前に表示
      frmPtCmt.Owner = this;
      // コメントフォーム表示
      frmPtCmt.Show();

      // 常にメインフォームの手前に表示
      frmCtrl.Owner = this;
      // コメントフォーム表示
      frmCtrl.Show();

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
      // メインフォーム情報設定
      dataStore.MainFormSize = this.Size;
      dataStore.MainFormLoca = this.Location;

      // 単体用置換処理メインメソッド使用
      rtbResult.Text = execRepPrc.ExecRepMain(rtbTarget.Text);
    }
    #endregion

    #region 複数用置換実行メソッド
    /// <summary>
    /// 複数用置換実行メソッド
    /// </summary>
    /// <param name="tgtDirPath">対象フォルダパス</param>
    /// <param name="fileFilter">ファイルフィルタ</param>
    /// <param name="destDirPath">出力先フォルダパス</param>
    /// <param name="encStr">文字コード文字列</param>
    public void ExecDirRep()
    {
      // メインフォーム情報設定
      dataStore.MainFormSize = this.Size;
      dataStore.MainFormLoca = this.Location;

      // 複数用置換処理メインメソッド使用
      execRepPrc.ExecDirRepMain();
    }
    #endregion


    #region パターン管理フォーム起動メソッド
    public void ShowPtMngFrm()
    {
      // パターン管理フォーム呼び出し
      DialogResult res = frmPtMng.ShowDialog();

      // ねずみ返し_取込実行していないもしくはファイル選択されていない場合
      if (res != DialogResult.OK || InpPtFilePath == null)
      {
        return;
      }

      // パターンXML読み込みメソッド使用
      ReadPatternFile(InpPtFilePath);
      // コントロール値初期化メソッド
      InitCtrlVal();
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
    private void Com_BtAllClr_Click(object sender, EventArgs e)
    {
      switch (sender)
      {
        // 型がボタンかつ対象コントロールと一致する場合
        case Button ctrl when sender.Equals(btAllClrSearch):
          // 検索対象ボックス全削除
          foreach (TextBox x in dataStore.ListTbSearch)
          {
            x.ResetText();
          }
          break;

        case Button ctrl when sender.Equals(btAllClrReplace):
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
    private void InitCtrlVal()
    {
      // コメント
      frmPtCmt.tbComment.Text = string.Empty;
      if (dicIniVal.ContainsKey("Comment"))
        frmPtCmt.tbComment.Text = dicIniVal["Comment"];

      // コントロールフォーム
      if (dicIniVal.ContainsKey("IsCaseSens"))
        dataStore.IsCaseSens = bool.Parse(dicIniVal["IsCaseSens"]);
      if (dicIniVal.ContainsKey("IsNewLine"))
        dataStore.IsNewLine = bool.Parse(dicIniVal["IsNewLine"]);
      if (dicIniVal.ContainsKey("IsTab"))
        dataStore.IsTab = bool.Parse(dicIniVal["IsTab"]);
      if (dicIniVal.ContainsKey("IsMultRep"))
        dataStore.IsMultRep = bool.Parse(dicIniVal["IsMultRep"]);
      if (dicIniVal.ContainsKey("TgtDirPath"))
        dataStore.TgtDirPath = dicIniVal["TgtDirPath"];
      if (dicIniVal.ContainsKey("FileFilter"))
        dataStore.FileFilter = dicIniVal["FileFilter"];
      if (dicIniVal.ContainsKey("EncStr"))
        // 文字列文字コード変換メソッド使用
        dataStore.Enc = Str2Enc(dicIniVal["EncStr"]);

      // コントロールフォーム更新
      frmCtrl.InitCtrlValue();

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
        if (dicIniVal.ContainsKey("Check" + padTwo))
          dataStore.ListChkBox[i].Checked = dicIniVal["Check" + padTwo].ToLower() == "true";
        if (dicIniVal.ContainsKey("Search" + padTwo))
          dataStore.ListTbSearch[i].Text = dicIniVal["Search" + padTwo];
        if (dicIniVal.ContainsKey("Replace" + padTwo))
          dataStore.ListTbReplace[i].Text = dicIniVal["Replace" + padTwo];
      }
    }
    #endregion

    #region 文字列文字コード変換メソッド
    /// <summary>
    /// 文字列文字コード変換メソッド
    /// </summary>
    /// <param name="encStr">文字コード文字列</param>
    /// <returns>文字コード</returns>
    public Encoding Str2Enc(string encStr)
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


    #region パターンXML読み込みメソッド
    private void ReadPatternFile(string targetPath)
    {
      // 対象キー名称定数
      const string TGT_KEY_NAME = @"Comment|IsCaseSens|IsNewLine|IsTab|IsMultRep|TgtDirPath|FileFilter|EncStr|DestDirPath|Check\d\d|Search\d\d|Replace\d\d";

      // 各コントロール初期値ディクショナリクリア
      dicIniVal.Clear();

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
          if (!Regex.Match(keyName, TGT_KEY_NAME).Success)
          {
            continue;
          }

          // 二番目の属性「value」へ
          xmlReader.MoveToNextAttribute();
          string keyValue = xmlReader.Value;

          // 各コントロール初期値ディクショナリ追加        
          dicIniVal.Add(keyName, keyValue);
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
      string outStrIsCaseSens = string.Empty;
      string outStrIsNewLine = string.Empty;
      string outStrIsTab = string.Empty;
      string outStrChk = string.Empty;
      string outStrSearch = string.Empty;
      string outStrReplace = string.Empty;
      string outIsMultRep = string.Empty;
      string outTgtDirPath = string.Empty;
      string outFileFilter = string.Empty;
      string outEncStr = string.Empty;
      string outDestDirPath = string.Empty;
      string XML_FMT = "  <add key=\"{0}\" value=\"{1}\"/>" + Environment.NewLine;
      // XML用
      string XML_DEC = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + Environment.NewLine;
      string XML_ROOT_START = "<Root>" + Environment.NewLine;
      string XML_ROOT_END = "</Root>";

      // コメントフォームのコメントテキストボックスから文字列取得
      outStrCmt = frmPtCmt.tbComment.Text;
      // XML用文字に変換
      outStrCmt = Regex.Replace(outStrCmt, "&", "&amp;");
      outStrCmt = Regex.Replace(outStrCmt, "\"", "&quot;");
      outStrCmt = Regex.Replace(outStrCmt, "'", "&apos;");
      outStrCmt = Regex.Replace(outStrCmt, "<", "&lt;");
      outStrCmt = Regex.Replace(outStrCmt, ">", "&gt;");
      outStrCmt = Regex.Replace(outStrCmt, "\r\n", "&#xD;&#xA;");
      outStrCmt = string.Format(XML_FMT, "Comment", outStrCmt);

      // 大小文字判別、改行、タブモード判断
      outStrIsCaseSens = string.Format(XML_FMT, "IsCaseSens", dataStore.IsCaseSens.ToString());
      outStrIsNewLine = string.Format(XML_FMT, "IsNewLine", dataStore.IsNewLine.ToString());
      outStrIsTab = string.Format(XML_FMT, "IsTab", dataStore.IsTab.ToString());
      // 一括置換
      outIsMultRep = string.Format(XML_FMT, "IsMultRep", dataStore.IsMultRep.ToString());
      outTgtDirPath = string.Format(XML_FMT, "TgtDirPath", dataStore.TgtDirPath);
      outFileFilter = string.Format(XML_FMT, "FileFilter", dataStore.FileFilter);
      outEncStr = string.Format(XML_FMT, "EncStr", dataStore.Enc.ToString());
      outDestDirPath = string.Format(XML_FMT, "DestDirPath", dataStore.DestDirPath);

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
          outStrIsCaseSens +
          outStrIsNewLine +
          outStrIsTab +
          outIsMultRep +
          outTgtDirPath +
          outFileFilter +
          outEncStr +
          outStrChk +
          outStrSearch +
          outStrReplace +
          XML_ROOT_END
          );
      }
    }
    #endregion
  }
}
