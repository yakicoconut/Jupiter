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
using System.Xml;
using System.Text.RegularExpressions;

namespace WFA
{
  public partial class FrmFileMng : Form
  {
    #region コンストラクタ
    public FrmFileMng(Form1 fm1)
    {
      InitializeComponent();

      // 親フォーム設定
      form1 = fm1;
    }
    #endregion


    #region 宣言

    // 親フォーム
    public Form1 form1 { get; set; }

    #endregion


    #region フォームロードイベント
    private void FrmFileMng_Load(object sender, EventArgs e)
    {
      this.Text = "ファイル管理";

      // 検索対象フォルダ設定
      tbSearchPath.Text = form1.XmlFolderName;
      // 検索対象が存在しない場合
      if (!Directory.Exists(tbSearchPath.Text))
      {
        // フォルダ作成
        Directory.CreateDirectory(tbSearchPath.Text);
      }

      // コミットパスに設定
      tbCommitPath.Text = tbSearchPath.Text;

      // ファイルリストフォーム初期化メソッド使用
      InitFileListForm(tbCommitPath.Text);
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
      // ねずみ返し_対象フォルダが存在しない場合
      if (!Directory.Exists(tbCommitPath.Text))
      {
        return;
      }

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


    #region リストビュー選択変更イベント
    private void lvFileList_SelectedIndexChanged(object sender, EventArgs e)
    {
      // ねずみ返し_選択行が0以下の場合
      if (lvFileList.SelectedItems.Count <= 0)
      {
        // 選択変更時に選択が外れてもイベントが発生するため
        return;
      }

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

      // コメントボックス更新用変数
      string cmment = string.Empty;

      // ファイルからXmlReaderでXMLを取得
      using (XmlReader xmlReader = XmlReader.Create(new StreamReader(tbCommitPath.Text + @"\" + lvFileList.SelectedItems[0].Text + ".xml"), setting))
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

          // キーの値がコメントの場合
          if (Regex.Match(keyName, @"Comment").Success)
          {
            // 二番目の属性「value」へ
            xmlReader.MoveToNextAttribute();

            // コメントボックスに設定
            cmment = xmlReader.Value;

            break;
          }

          continue;
        }
      }

      // コメントボックスに設定
      tbPtCommentPreview.Text = cmment;
    }
    #endregion

    #region リストビューダブルクリックイベント
    private void lvFileList_DoubleClick(object sender, EventArgs e)
    {
      // ねずみ返し_項目が選択されていない場合
      if (lvFileList.SelectedItems.Count == 0)
      {
        return;
      }

      // 選択項目からパス作成
      form1.InputXmlPath = tbCommitPath.Text + @"\" + lvFileList.SelectedItems[0].Text + ".xml";
      // フォーム閉じる
      this.Close();
    }
    #endregion


    #region 保存ボタン押下イベント
    private void btSaveXml_Click(object sender, EventArgs e)
    {
      // メインフォーム_XML保存メソッド使用
      form1.SaveXml(tbCommitPath.Text, "ImgList");

      // ファイルリストフォーム初期化メソッド使用
      InitFileListForm(tbCommitPath.Text);
    }
    #endregion

    #region 取込ボタン押下イベント
    private void btInputXml_Click(object sender, EventArgs e)
    {
      // ねずみ返し_項目が選択されていない場合
      if (lvFileList.SelectedItems.Count == 0)
      {
        return;
      }

      // 選択項目からパス作成
      form1.InputXmlPath = tbCommitPath.Text + @"\" + lvFileList.SelectedItems[0].Text + ".xml";
      // フォーム閉じる
      this.Close();
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
    private void FrmFileMng_FormClosing(object sender, FormClosingEventArgs e)
    {
      // リストボックス破棄
      lvFileList.Items.Clear();

      // XMLフォルダ名称をコミットパスに更新
      form1.XmlFolderName = tbCommitPath.Text;

      //// クローズキャンセル
      //if (e.CloseReason == CloseReason.UserClosing)
      //  e.Cancel = true;
    }
    #endregion
  }
}