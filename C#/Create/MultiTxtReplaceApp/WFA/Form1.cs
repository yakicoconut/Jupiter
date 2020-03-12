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

#region メモ
/*
 * ※リッチテキストボックスは
 *   改行コードを自動的に\nに変換する
 * 
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
      outputPatternFile = ConfigurationManager.AppSettings["OutputPatternFile"];

      tbSearch01.Text = ConfigurationManager.AppSettings["Search01"];
      tbSearch02.Text = ConfigurationManager.AppSettings["Search02"];
      tbSearch03.Text = ConfigurationManager.AppSettings["Search03"];
      tbSearch04.Text = ConfigurationManager.AppSettings["Search04"];
      tbSearch05.Text = ConfigurationManager.AppSettings["Search05"];
      tbSearch06.Text = ConfigurationManager.AppSettings["Search06"];
      tbSearch07.Text = ConfigurationManager.AppSettings["Search07"];
      tbSearch08.Text = ConfigurationManager.AppSettings["Search08"];
      tbSearch09.Text = ConfigurationManager.AppSettings["Search09"];
      tbSearch10.Text = ConfigurationManager.AppSettings["Search10"];
      tbSearch11.Text = ConfigurationManager.AppSettings["Search11"];
      tbSearch12.Text = ConfigurationManager.AppSettings["Search12"];
      tbSearch13.Text = ConfigurationManager.AppSettings["Search13"];
      tbSearch14.Text = ConfigurationManager.AppSettings["Search14"];
      tbSearch15.Text = ConfigurationManager.AppSettings["Search15"];
      tbSearch16.Text = ConfigurationManager.AppSettings["Search16"];
      tbSearch17.Text = ConfigurationManager.AppSettings["Search17"];
      tbSearch18.Text = ConfigurationManager.AppSettings["Search18"];
      tbSearch19.Text = ConfigurationManager.AppSettings["Search19"];
      tbSearch20.Text = ConfigurationManager.AppSettings["Search20"];

      tbReplace01.Text = ConfigurationManager.AppSettings["Replace01"];
      tbReplace02.Text = ConfigurationManager.AppSettings["Replace02"];
      tbReplace03.Text = ConfigurationManager.AppSettings["Replace03"];
      tbReplace04.Text = ConfigurationManager.AppSettings["Replace04"];
      tbReplace05.Text = ConfigurationManager.AppSettings["Replace05"];
      tbReplace06.Text = ConfigurationManager.AppSettings["Replace06"];
      tbReplace07.Text = ConfigurationManager.AppSettings["Replace07"];
      tbReplace08.Text = ConfigurationManager.AppSettings["Replace08"];
      tbReplace09.Text = ConfigurationManager.AppSettings["Replace09"];
      tbReplace10.Text = ConfigurationManager.AppSettings["Replace10"];
      tbReplace11.Text = ConfigurationManager.AppSettings["Replace11"];
      tbReplace12.Text = ConfigurationManager.AppSettings["Replace12"];
      tbReplace13.Text = ConfigurationManager.AppSettings["Replace13"];
      tbReplace14.Text = ConfigurationManager.AppSettings["Replace14"];
      tbReplace15.Text = ConfigurationManager.AppSettings["Replace15"];
      tbReplace16.Text = ConfigurationManager.AppSettings["Replace16"];
      tbReplace17.Text = ConfigurationManager.AppSettings["Replace17"];
      tbReplace18.Text = ConfigurationManager.AppSettings["Replace18"];
      tbReplace19.Text = ConfigurationManager.AppSettings["Replace19"];
      tbReplace20.Text = ConfigurationManager.AppSettings["Replace20"];
    }
    #endregion


    #region 宣言

    // 共通ロジッククラスインスタンス
    MCSComLogic _comLogic = new MCSComLogic();

    //
    string outputPatternFile;


    #endregion


    #region フォームロードイベント
    private void Form1_Load(object sender, EventArgs e)
    {

    }
    #endregion

    #region 置換ボタン押下イベント
    private void btReplace_Click(object sender, EventArgs e)
    {
      rtbResult.ResetText();

      string result = rtbTarget.Text;

      result = cb01.Checked ? System.Text.RegularExpressions.Regex.Replace(result, tbSearch01.Text, tbReplace01.Text) : result;
      result = cb02.Checked ? System.Text.RegularExpressions.Regex.Replace(result, tbSearch02.Text, tbReplace02.Text) : result;
      result = cb03.Checked ? System.Text.RegularExpressions.Regex.Replace(result, tbSearch03.Text, tbReplace03.Text) : result;
      result = cb04.Checked ? System.Text.RegularExpressions.Regex.Replace(result, tbSearch04.Text, tbReplace04.Text) : result;
      result = cb05.Checked ? System.Text.RegularExpressions.Regex.Replace(result, tbSearch05.Text, tbReplace05.Text) : result;
      result = cb06.Checked ? System.Text.RegularExpressions.Regex.Replace(result, tbSearch06.Text, tbReplace06.Text) : result;
      result = cb07.Checked ? System.Text.RegularExpressions.Regex.Replace(result, tbSearch07.Text, tbReplace07.Text) : result;
      result = cb08.Checked ? System.Text.RegularExpressions.Regex.Replace(result, tbSearch08.Text, tbReplace08.Text) : result;
      result = cb09.Checked ? System.Text.RegularExpressions.Regex.Replace(result, tbSearch09.Text, tbReplace09.Text) : result;
      result = cb10.Checked ? System.Text.RegularExpressions.Regex.Replace(result, tbSearch10.Text, tbReplace10.Text) : result;
      result = cb11.Checked ? System.Text.RegularExpressions.Regex.Replace(result, tbSearch11.Text, tbReplace11.Text) : result;
      result = cb12.Checked ? System.Text.RegularExpressions.Regex.Replace(result, tbSearch12.Text, tbReplace12.Text) : result;
      result = cb13.Checked ? System.Text.RegularExpressions.Regex.Replace(result, tbSearch13.Text, tbReplace13.Text) : result;
      result = cb14.Checked ? System.Text.RegularExpressions.Regex.Replace(result, tbSearch14.Text, tbReplace14.Text) : result;
      result = cb15.Checked ? System.Text.RegularExpressions.Regex.Replace(result, tbSearch15.Text, tbReplace15.Text) : result;
      result = cb16.Checked ? System.Text.RegularExpressions.Regex.Replace(result, tbSearch16.Text, tbReplace16.Text) : result;
      result = cb17.Checked ? System.Text.RegularExpressions.Regex.Replace(result, tbSearch17.Text, tbReplace17.Text) : result;
      result = cb18.Checked ? System.Text.RegularExpressions.Regex.Replace(result, tbSearch18.Text, tbReplace18.Text) : result;
      result = cb19.Checked ? System.Text.RegularExpressions.Regex.Replace(result, tbSearch19.Text, tbReplace19.Text) : result;
      result = cb20.Checked ? System.Text.RegularExpressions.Regex.Replace(result, tbSearch20.Text, tbReplace20.Text) : result;

      rtbResult.Text = result;
    }
    #endregion

    #region 検索文字列全削除ボタン押下イベント
    private void btAllCrearSearch_Click(object sender, EventArgs e)
    {
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

    #region 検索文字列全削除ボタン押下イベント
    private void btAllCrearReplace_Click(object sender, EventArgs e)
    {
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
