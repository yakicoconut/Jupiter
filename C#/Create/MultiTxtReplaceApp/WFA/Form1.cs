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

#region メモ
/*
 * ※リッチテキストボックスは
 *   改行コードを自動的に\nに変換する
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
    }
    #endregion

    #region コンフィグ取得メソッド
    private void GetConfig()
    {
      // 出力パターンファイルパス
      outputPatternFile = _comLogic.GetConfigValue("OutputPatternFile", "Pattern.txt");

      // 検索対象初期値
      for (int i = 1; i <= 20; i++)
      {
        // 1~20を二桁で作成
        string padTwo = i.ToString().PadLeft(2, '0');
        dicConfigSearch.Add("Search" + padTwo, _comLogic.GetConfigValue("Search" + padTwo, ""));
        dicConfigReplace.Add("Replace" + padTwo, _comLogic.GetConfigValue("Replace" + padTwo, ""));
      }
    }
    #endregion


    #region 宣言

    // 共通ロジッククラスインスタンス
    MCSComLogic _comLogic = new MCSComLogic();

    // 出力パターンファイルパス
    string outputPatternFile;
    
    // 検索対象テキストボックスリスト
    List<TextBox> listTbSearch = new List<TextBox>();
    // 置換文字列テキストボックスリスト
    List<TextBox> listTbReplace = new List<TextBox>();
    // チェックボックスリスト
    List<CheckBox> listchkBox = new List<CheckBox>();

    // 検索対象テキストボックス初期値ディクショナリ
    Dictionary<string, string> dicConfigSearch = new Dictionary<string, string>();
    // 置換文字列テキストボックス初期値ディクショナリ
    Dictionary<string, string> dicConfigReplace = new Dictionary<string, string>();
    
    #endregion


    #region フォームロードイベント
    private void Form1_Load(object sender, EventArgs e)
    {
      #region リストにコントロール格納

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
      listchkBox.Add(cb01);
      listchkBox.Add(cb02);
      listchkBox.Add(cb03);
      listchkBox.Add(cb04);
      listchkBox.Add(cb05);
      listchkBox.Add(cb06);
      listchkBox.Add(cb07);
      listchkBox.Add(cb08);
      listchkBox.Add(cb09);
      listchkBox.Add(cb10);
      listchkBox.Add(cb11);
      listchkBox.Add(cb12);
      listchkBox.Add(cb13);
      listchkBox.Add(cb14);
      listchkBox.Add(cb15);
      listchkBox.Add(cb16);
      listchkBox.Add(cb17);
      listchkBox.Add(cb18);
      listchkBox.Add(cb19);
      listchkBox.Add(cb20);

      #endregion


      // 検索対象テキストボックス設定
      foreach (TextBox x in listTbSearch)
      {
        // 検索対象テキストボックス初期値リスト
        x.Text = dicConfigSearch["Search" + x.Name.Substring(x.Name.Length - 2, 2)];
      }
      // 置換文字列テキストボックス設定
      foreach (TextBox x in listTbReplace)
      {
        x.Text = dicConfigReplace["Replace" + x.Name.Substring(x.Name.Length - 2, 2)];

        // SplitContainer内のコントロールのサイズ位置を無理やり変更
        x.Size = new Size(402, 19);
      }

      // SplitContainer内のコントロールのサイズ位置を無理やり変更
      rtbTarget.Size = new Size(315, 210);
      rtbResult.Size = new Size(360, 210);
      splcTargetResult.Size = new Size(705, 345);

      // 対象・結果ボックスでタブ記号が入力されるようにする
      rtbTarget.AcceptsTab = true;
      rtbResult.AcceptsTab = true;
    }
    #endregion


    #region 置換ボタン押下イベント
    private void btReplace_Click(object sender, EventArgs e)
    {
      // 結果ボックス初期化
      rtbResult.ResetText();

      // 置換え実行
      RichTextBox target = rtbTarget;
      string result = rtbTarget.Text;

      int i = 0;
      foreach (CheckBox x in listchkBox)
      {
        // ねずみ返し_チェックが付いていない場合
        if (!x.Checked)
        {
          i += 1;
          continue;
        }

        /* 色変更 */
        // Regexオブジェクト作成
        Regex regex = new Regex(listTbSearch[i].Text, RegexOptions.IgnoreCase);

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
        result = Regex.Replace(result, listTbSearch[i].Text, listTbReplace[i].Text);
        
        i += 1;
      }

      // 結果表示
      rtbResult.Text = result;
    }
    #endregion

    #region パターン保存ボタン押下イベント
    private void btPatternSave_Click(object sender, EventArgs e)
    {
      // 現在時刻取得
      DateTime now = DateTime.Now;
      string outputDate = now.ToString("yyyy/MM/dd HH:mm:ss.fff");

      // 出力用変数
      string outStrSearch = string.Empty;
      string outStrReplace = string.Empty;
      string searchFormat = "<add key=\"Search{0}\" value=\"{1}\"/>";
      string replaceFormat = "<add key=\"Replace{0}\" value=\"{1}\"/>";

      // 全チェックボックスループ
      int i = 0;
      foreach (CheckBox x in listchkBox)
      {
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
        outStrSearch += string.Format(searchFormat, i.ToString().PadLeft(2, '0'), searchStr) + Environment.NewLine;
        outStrReplace += string.Format(replaceFormat, i.ToString().PadLeft(2, '0'), replaceStr) + Environment.NewLine;
      }

      // 出力ファイルの作成
      // 引数:対象ファイル、上書き可不可、文字コード
      using (StreamWriter sw = new StreamWriter(outputPatternFile, true, Encoding.GetEncoding("shift_jis")))
      {
        sw.WriteLine("-----" + outputDate + "-----" + Environment.NewLine + outStrSearch + outStrReplace);
      }
    }
    #endregion

    #region 開くボタン押下イベント
    private void btOpen_Click(object sender, EventArgs e)
    {
      // 自身のフォルダを開く
      string myLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
      Process.Start(myLocation);      
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
      foreach (CheckBox x in listchkBox)
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


    #region 雛形メソッド
    private void template()
    {

    }
    #endregion
  }
}
