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

      // 検索対象変数
      search01 = _comLogic.GetConfigValue("Search01", "");
      search02 = _comLogic.GetConfigValue("Search02", "");
      search03 = _comLogic.GetConfigValue("Search03", "");
      search04 = _comLogic.GetConfigValue("Search04", "");
      search05 = _comLogic.GetConfigValue("Search05", "");
      search06 = _comLogic.GetConfigValue("Search06", "");
      search07 = _comLogic.GetConfigValue("Search07", "");
      search08 = _comLogic.GetConfigValue("Search08", "");
      search09 = _comLogic.GetConfigValue("Search09", "");
      search10 = _comLogic.GetConfigValue("Search10", "");
      search11 = _comLogic.GetConfigValue("Search11", "");
      search12 = _comLogic.GetConfigValue("Search12", "");
      search13 = _comLogic.GetConfigValue("Search13", "");
      search14 = _comLogic.GetConfigValue("Search14", "");
      search15 = _comLogic.GetConfigValue("Search15", "");
      search16 = _comLogic.GetConfigValue("Search16", "");
      search17 = _comLogic.GetConfigValue("Search17", "");
      search18 = _comLogic.GetConfigValue("Search18", "");
      search19 = _comLogic.GetConfigValue("Search19", "");
      search20 = _comLogic.GetConfigValue("Search20", "");
      // 置換文字列変数
      replace01 = _comLogic.GetConfigValue("Replace01", "");
      replace02 = _comLogic.GetConfigValue("Replace02", "");
      replace03 = _comLogic.GetConfigValue("Replace03", "");
      replace04 = _comLogic.GetConfigValue("Replace04", "");
      replace05 = _comLogic.GetConfigValue("Replace05", "");
      replace06 = _comLogic.GetConfigValue("Replace06", "");
      replace07 = _comLogic.GetConfigValue("Replace07", "");
      replace08 = _comLogic.GetConfigValue("Replace08", "");
      replace09 = _comLogic.GetConfigValue("Replace09", "");
      replace10 = _comLogic.GetConfigValue("Replace10", "");
      replace11 = _comLogic.GetConfigValue("Replace11", "");
      replace12 = _comLogic.GetConfigValue("Replace12", "");
      replace13 = _comLogic.GetConfigValue("Replace13", "");
      replace14 = _comLogic.GetConfigValue("Replace14", "");
      replace15 = _comLogic.GetConfigValue("Replace15", "");
      replace16 = _comLogic.GetConfigValue("Replace16", "");
      replace17 = _comLogic.GetConfigValue("Replace17", "");
      replace18 = _comLogic.GetConfigValue("Replace18", "");
      replace19 = _comLogic.GetConfigValue("Replace19", "");
      replace20 = _comLogic.GetConfigValue("Replace20", "");
    }
    #endregion


    #region 宣言

    // 共通ロジッククラスインスタンス
    MCSComLogic _comLogic = new MCSComLogic();

    // 出力パターンファイルパス
    string outputPatternFile;

    // 検索対象変数
    string search01 = string.Empty;
    string search02 = string.Empty;
    string search03 = string.Empty;
    string search04 = string.Empty;
    string search05 = string.Empty;
    string search06 = string.Empty;
    string search07 = string.Empty;
    string search08 = string.Empty;
    string search09 = string.Empty;
    string search10 = string.Empty;
    string search11 = string.Empty;
    string search12 = string.Empty;
    string search13 = string.Empty;
    string search14 = string.Empty;
    string search15 = string.Empty;
    string search16 = string.Empty;
    string search17 = string.Empty;
    string search18 = string.Empty;
    string search19 = string.Empty;
    string search20 = string.Empty;
    // 検索対象変数
    string replace01 = string.Empty;
    string replace02 = string.Empty;
    string replace03 = string.Empty;
    string replace04 = string.Empty;
    string replace05 = string.Empty;
    string replace06 = string.Empty;
    string replace07 = string.Empty;
    string replace08 = string.Empty;
    string replace09 = string.Empty;
    string replace10 = string.Empty;
    string replace11 = string.Empty;
    string replace12 = string.Empty;
    string replace13 = string.Empty;
    string replace14 = string.Empty;
    string replace15 = string.Empty;
    string replace16 = string.Empty;
    string replace17 = string.Empty;
    string replace18 = string.Empty;
    string replace19 = string.Empty;
    string replace20 = string.Empty;























    #endregion


    #region フォームロードイベント
    private void Form1_Load(object sender, EventArgs e)
    {
      // 検索対象ボックス初期化
      tbSearch01.Text = search01;
      tbSearch02.Text = search02;
      tbSearch03.Text = search03;
      tbSearch04.Text = search04;
      tbSearch05.Text = search05;
      tbSearch06.Text = search06;
      tbSearch07.Text = search07;
      tbSearch08.Text = search08;
      tbSearch09.Text = search09;
      tbSearch10.Text = search10;
      tbSearch11.Text = search11;
      tbSearch12.Text = search12;
      tbSearch13.Text = search13;
      tbSearch14.Text = search14;
      tbSearch15.Text = search15;
      tbSearch16.Text = search16;
      tbSearch17.Text = search17;
      tbSearch18.Text = search18;
      tbSearch19.Text = search19;
      tbSearch20.Text = search20;
      // 置換文字列ボックス初期化
      tbReplace01.Text = replace01;
      tbReplace02.Text = replace02;
      tbReplace03.Text = replace03;
      tbReplace04.Text = replace04;
      tbReplace05.Text = replace05;
      tbReplace06.Text = replace06;
      tbReplace07.Text = replace07;
      tbReplace08.Text = replace08;
      tbReplace09.Text = replace09;
      tbReplace10.Text = replace10;
      tbReplace11.Text = replace11;
      tbReplace12.Text = replace12;
      tbReplace13.Text = replace13;
      tbReplace14.Text = replace14;
      tbReplace15.Text = replace15;
      tbReplace16.Text = replace16;
      tbReplace17.Text = replace17;
      tbReplace18.Text = replace18;
      tbReplace19.Text = replace19;
      tbReplace20.Text = replace20;
    }
    #endregion

    #region 置換ボタン押下イベント
    private void btReplace_Click(object sender, EventArgs e)
    {
      // 結果ボックス初期化
      rtbResult.ResetText();

      // 置き換え実行
      string result = rtbTarget.Text;
      result = cb01.Checked ? Regex.Replace(result, search01, replace01) : result;
      result = cb02.Checked ? Regex.Replace(result, search02, replace02) : result;
      result = cb03.Checked ? Regex.Replace(result, search03, replace03) : result;
      result = cb04.Checked ? Regex.Replace(result, search04, replace04) : result;
      result = cb05.Checked ? Regex.Replace(result, search05, replace05) : result;
      result = cb06.Checked ? Regex.Replace(result, search06, replace06) : result;
      result = cb07.Checked ? Regex.Replace(result, search07, replace07) : result;
      result = cb08.Checked ? Regex.Replace(result, search08, replace08) : result;
      result = cb09.Checked ? Regex.Replace(result, search09, replace09) : result;
      result = cb10.Checked ? Regex.Replace(result, search10, replace10) : result;
      result = cb11.Checked ? Regex.Replace(result, search11, replace11) : result;
      result = cb12.Checked ? Regex.Replace(result, search12, replace12) : result;
      result = cb13.Checked ? Regex.Replace(result, search13, replace13) : result;
      result = cb14.Checked ? Regex.Replace(result, search14, replace14) : result;
      result = cb15.Checked ? Regex.Replace(result, search15, replace15) : result;
      result = cb16.Checked ? Regex.Replace(result, search16, replace16) : result;
      result = cb17.Checked ? Regex.Replace(result, search17, replace17) : result;
      result = cb18.Checked ? Regex.Replace(result, search18, replace18) : result;
      result = cb19.Checked ? Regex.Replace(result, search19, replace19) : result;
      result = cb20.Checked ? Regex.Replace(result, search20, replace20) : result;

      // 結果表示
      rtbResult.Text = result;
    }
    #endregion

    #region 検索対象全削除ボタン押下イベント
    private void btAllCrearSearch_Click(object sender, EventArgs e)
    {
      // 検索対象ボックス全削除
      tbSearch01.ResetText();
      tbSearch02.ResetText();
      tbSearch03.ResetText();
      tbSearch04.ResetText();
      tbSearch05.ResetText();
      tbSearch06.ResetText();
      tbSearch07.ResetText();
      tbSearch08.ResetText();
      tbSearch09.ResetText();
      tbSearch10.ResetText();
      tbSearch11.ResetText();
      tbSearch12.ResetText();
      tbSearch13.ResetText();
      tbSearch14.ResetText();
      tbSearch15.ResetText();
      tbSearch16.ResetText();
      tbSearch17.ResetText();
      tbSearch18.ResetText();
      tbSearch19.ResetText();
      tbSearch20.ResetText();
    }
    #endregion

    #region 置換文字列全削除ボタン押下イベント
    private void btAllCrearReplace_Click(object sender, EventArgs e)
    {
      // 置換文字列ボックス全削除
      tbReplace01.ResetText();
      tbReplace02.ResetText();
      tbReplace03.ResetText();
      tbReplace04.ResetText();
      tbReplace05.ResetText();
      tbReplace06.ResetText();
      tbReplace07.ResetText();
      tbReplace08.ResetText();
      tbReplace09.ResetText();
      tbReplace10.ResetText();
      tbReplace11.ResetText();
      tbReplace12.ResetText();
      tbReplace13.ResetText();
      tbReplace14.ResetText();
      tbReplace15.ResetText();
      tbReplace16.ResetText();
      tbReplace17.ResetText();
      tbReplace18.ResetText();
      tbReplace19.ResetText();
      tbReplace20.ResetText();
    }
    #endregion

    #region パターンパネルスクロールイベント
    private void splcSearchReplace_Scroll(object sender, ScrollEventArgs e)
    {
      // 置き換え文字列パネルのスクロール最大値を検索文字列パネルのスクロール最大値に設定する
      splcSearchReplace.Panel1.VerticalScroll.Maximum = splcSearchReplace.Panel2.VerticalScroll.Maximum;
      // 置き換え文字列パネルのスクロール値を検索文字列パネルのスクロール値に設定する
      splcSearchReplace.Panel1.VerticalScroll.Value = splcSearchReplace.Panel2.VerticalScroll.Value;
    }
    #endregion

    #region テキストボックスキーダウンイベント
    private void tb_KeyDown(object sender, KeyEventArgs e)
    {
      // Ctrl+Aキーの場合
      if (e.Control && e.KeyCode == Keys.A)
      {
        // イベント発生元のテキストボックスの内容を全選択する
        TextBox ctrl = (TextBox)sender;
        ctrl.SelectAll();
      }
    }
    #endregion

    #region 全選択チェックボックス押下イベント
    private void cbAllCheck_CheckedChanged(object sender, EventArgs e)
    {
      // 全選択チェックボックスをチェックした場合
      if (cbAllCheck.Checked)
      {
        //for (int i = 1; i <= 20; i++)
        //{
        //  CheckBox ctrl = (CheckBox)this.Controls[string.Format("{0:00}", i)];
        //  ctrl.Checked = true;
        //}
        cb01.Checked = true;
        cb02.Checked = true;
        cb03.Checked = true;
        cb04.Checked = true;
        cb05.Checked = true;
        cb06.Checked = true;
        cb07.Checked = true;
        cb08.Checked = true;
        cb09.Checked = true;
        cb10.Checked = true;
        cb11.Checked = true;
        cb12.Checked = true;
        cb13.Checked = true;
        cb14.Checked = true;
        cb15.Checked = true;
        cb16.Checked = true;
        cb17.Checked = true;
        cb18.Checked = true;
        cb19.Checked = true;
        cb20.Checked = true;
      }
      else
      {
        //for (int i = 1; i <= 20; i++)
        //{
        //  CheckBox ctrl = (CheckBox)this.Controls[string.Format("{0:00}", i)];
        //  ctrl.Checked = false;
        //}
        cb01.Checked = false;
        cb02.Checked = false;
        cb03.Checked = false;
        cb04.Checked = false;
        cb05.Checked = false;
        cb06.Checked = false;
        cb07.Checked = false;
        cb08.Checked = false;
        cb09.Checked = false;
        cb10.Checked = false;
        cb11.Checked = false;
        cb12.Checked = false;
        cb13.Checked = false;
        cb14.Checked = false;
        cb15.Checked = false;
        cb16.Checked = false;
        cb17.Checked = false;
        cb18.Checked = false;
        cb19.Checked = false;
        cb20.Checked = false;
      }
    }
    #endregion

    #region パターン保存ボタン押下イベント
    private void btPatternSave_Click(object sender, EventArgs e)
    {
      string outStrSearch = string.Empty;
      string outStrReplace = string.Empty;

      // パターン
      if (cb01.Checked)
      {
        outStrSearch = outStrSearch + "\r\n" + tbSearch01.Text;
        outStrReplace = outStrReplace + "\r\n" + tbReplace01.Text;
      }
      if (cb02.Checked)
      {
        outStrSearch = outStrSearch + "\r\n" + tbSearch02.Text;
        outStrReplace = outStrReplace + "\r\n" + tbReplace02.Text;
      }
      if (cb03.Checked)
      {
        outStrSearch = outStrSearch + "\r\n" + tbSearch03.Text;
        outStrReplace = outStrReplace + "\r\n" + tbReplace03.Text;
      }
      if (cb04.Checked)
      {
        outStrSearch = outStrSearch + "\r\n" + tbSearch04.Text;
        outStrReplace = outStrReplace + "\r\n" + tbReplace04.Text;
      }
      if (cb05.Checked)
      {
        outStrSearch = outStrSearch + "\r\n" + tbSearch05.Text;
        outStrReplace = outStrReplace + "\r\n" + tbReplace05.Text;
      }
      if (cb06.Checked)
      {
        outStrSearch = outStrSearch + "\r\n" + tbSearch06.Text;
        outStrReplace = outStrReplace + "\r\n" + tbReplace06.Text;
      }
      if (cb07.Checked)
      {
        outStrSearch = outStrSearch + "\r\n" + tbSearch07.Text;
        outStrReplace = outStrReplace + "\r\n" + tbReplace07.Text;
      }
      if (cb08.Checked)
      {
        outStrSearch = outStrSearch + "\r\n" + tbSearch08.Text;
        outStrReplace = outStrReplace + "\r\n" + tbReplace08.Text;
      }
      if (cb09.Checked)
      {
        outStrSearch = outStrSearch + "\r\n" + tbSearch09.Text;
        outStrReplace = outStrReplace + "\r\n" + tbReplace09.Text;
      }
      if (cb10.Checked)
      {
        outStrSearch = outStrSearch + "\r\n" + tbSearch10.Text;
        outStrReplace = outStrReplace + "\r\n" + tbReplace10.Text;
      }
      if (cb11.Checked)
      {
        outStrSearch = outStrSearch + "\r\n" + tbSearch11.Text;
        outStrReplace = outStrReplace + "\r\n" + tbReplace11.Text;
      }
      if (cb12.Checked)
      {
        outStrSearch = outStrSearch + "\r\n" + tbSearch12.Text;
        outStrReplace = outStrReplace + "\r\n" + tbReplace12.Text;
      }
      if (cb13.Checked)
      {
        outStrSearch = outStrSearch + "\r\n" + tbSearch13.Text;
        outStrReplace = outStrReplace + "\r\n" + tbReplace13.Text;
      }
      if (cb14.Checked)
      {
        outStrSearch = outStrSearch + "\r\n" + tbSearch14.Text;
        outStrReplace = outStrReplace + "\r\n" + tbReplace14.Text;
      }
      if (cb15.Checked)
      {
        outStrSearch = outStrSearch + "\r\n" + tbSearch15.Text;
        outStrReplace = outStrReplace + "\r\n" + tbReplace15.Text;
      }
      if (cb16.Checked)
      {
        outStrSearch = outStrSearch + "\r\n" + tbSearch16.Text;
        outStrReplace = outStrReplace + "\r\n" + tbReplace16.Text;
      }
      if (cb17.Checked)
      {
        outStrSearch = outStrSearch + "\r\n" + tbSearch17.Text;
        outStrReplace = outStrReplace + "\r\n" + tbReplace17.Text;
      }
      if (cb18.Checked)
      {
        outStrSearch = outStrSearch + "\r\n" + tbSearch18.Text;
        outStrReplace = outStrReplace + "\r\n" + tbReplace18.Text;
      }
      if (cb19.Checked)
      {
        outStrSearch = outStrSearch + "\r\n" + tbSearch19.Text;
        outStrReplace = outStrReplace + "\r\n" + tbReplace19.Text;
      }
      if (cb20.Checked)
      {
        outStrSearch = outStrSearch + "\r\n" + tbSearch20.Text;
        outStrReplace = outStrReplace + "\r\n" + tbReplace20.Text;
      }

      // XML用文字に変換
      outStrSearch = System.Text.RegularExpressions.Regex.Replace(outStrSearch, "&", "&amp;");
      outStrSearch = System.Text.RegularExpressions.Regex.Replace(outStrSearch, "\"", "&quot;");
      outStrSearch = System.Text.RegularExpressions.Regex.Replace(outStrSearch, "'", "&apos;");
      outStrSearch = System.Text.RegularExpressions.Regex.Replace(outStrSearch, "<", "&lt;");
      outStrSearch = System.Text.RegularExpressions.Regex.Replace(outStrSearch, ">", "&gt;");

      outStrReplace = System.Text.RegularExpressions.Regex.Replace(outStrReplace, "&", "&amp;");
      outStrReplace = System.Text.RegularExpressions.Regex.Replace(outStrReplace, "\"", "&quot;");
      outStrReplace = System.Text.RegularExpressions.Regex.Replace(outStrReplace, "'", "&apos;");
      outStrReplace = System.Text.RegularExpressions.Regex.Replace(outStrReplace, "<", "&lt;");
      outStrReplace = System.Text.RegularExpressions.Regex.Replace(outStrReplace, ">", "&gt;");

      // 出力ファイルの作成
      // 引数:対象ファイル、上書き可不可、文字コード
      using (StreamWriter sw = new System.IO.StreamWriter(
                             outputPatternFile,
                             true,
                             System.Text.Encoding.GetEncoding("shift_jis")))
      {
        sw.WriteLine("-----Search-----" + outStrSearch + "\r\n-----Replace-----" + outStrReplace);
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
