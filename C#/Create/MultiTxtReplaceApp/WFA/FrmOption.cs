using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace WFA
{
  public partial class FrmOption : Form
  {
    #region コンストラクタ
    public FrmOption(Form1 fm1)
    {
      InitializeComponent();

      // 親フォーム設定
      form1 = fm1;

      // タイトル設定
      this.Text = "Option";
    }
    #endregion


    #region 宣言

    // 親フォーム
    public Form1 form1 { get; set; }

    #endregion


    #region フォームロードイベント
    private void Form2_Load(object sender, EventArgs e)
    {
      this.Text = "Option";
    }
    #endregion


    #region コンテキスト_不透明度押下イベント
    private void toolStripMenuItemOpacity_Click(object sender, EventArgs e)
    {
      //デフォルトに戻す
      this.Opacity = 0.8;
    }
    #endregion

    #region コンテキスト_上げ押下イベント
    private void toolStripMenuItemOpacityGain_Click(object sender, EventArgs e)
    {
      //不透明度を上げる
      this.Opacity += 0.2;
    }
    #endregion

    #region コンテキスト_下げ押下イベント
    private void toolStripMenuItemOpacityDec_Click(object sender, EventArgs e)
    {
      //不透明度を下げる
      this.Opacity -= 0.2;
    }
    #endregion


    #region 開くボタン押下イベント
    private void btOpen_Click(object sender, EventArgs e)
    {
      // 対象フォルダを開く
      Process.Start(tbCommitPath.Text);
    }
    #endregion

    #region 確定ボタン押下イベント
    private void btConfirm_Click(object sender, EventArgs e)
    {
      string searchPath = tbSearchPath.Text;

      // ねずみ返し_空の場合
      if (searchPath == string.Empty)
      {
        return;
      }
      // ねずみ返し_フォルダが存在しない場合
      if (!Directory.Exists(searchPath))
      {
        return;
      }

      // コミットパスに設定
      tbCommitPath.Text = searchPath;

      // ファイルリストフォーム初期化メソッド使用
      InitFileListForm(tbCommitPath.Text);
    }
    #endregion

    #region 保存ボタン押下イベント
    private void btSaveXml_Click(object sender, EventArgs e)
    {
      // メインフォーム_パターンXML保存メソッド使用
      form1.SavePatternXml();

      // ファイルリストフォーム初期化メソッド使用
      InitFileListForm(tbCommitPath.Text);
    }
    #endregion


    #region ファイルリストフォーム初期化メソッド
    /// <summary>
    /// ファイルリストフォーム初期化メソッド
    /// </summary>
    private void InitFileListForm(string searchPath)
    {
      // 対象フォルダパス内のXMLファイルを全て取得
      string[] files = Directory.GetFiles(searchPath, "*.xml", SearchOption.TopDirectoryOnly);

      // リストビュー初期化
      lvFileList.Items.Clear();

      // ファイルディクショナリをループ処理
      foreach (var x in files)
      {
        // リストビューにファイル名のみ追加
        lvFileList.Items.Add(Path.GetFileNameWithoutExtension(x));
      }
    }
    #endregion


    #region フォームクロージングイベント
    private void Form2_FormClosing(object sender, FormClosingEventArgs e)
    {
      // リストボックス破棄
      lvFileList.Items.Clear();
      
      //// クローズキャンセル
      //if (e.CloseReason == CloseReason.UserClosing)
      //  e.Cancel = true;
    }
    #endregion
  }
}