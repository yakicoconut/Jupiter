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

namespace WFA
{
  public partial class Form1 : Form
  {
    #region コンストラクタ
    public Form1()
    {
      InitializeComponent();

      #region 【論理雛形】
      WFA_CommonLogic WFACL = new WFA_CommonLogic();
      //アプリ名設定
      Text = WFACL.GetAppName();
      #endregion

      //対象Azukiエディタのドキュメント型を取得
      targetDoc = azkTargetFileName.Document;
      //変更後Azukiエディタのドキュメント型を取得
      changedDoc = azkChangedFileName.Document;
    }
    #endregion

    #region プロパティ

    //Azukiエディタのドキュメント型
    Sgry.Azuki.Document targetDoc { get; set; }
    Sgry.Azuki.Document changedDoc { get; set; }

    #endregion


    #region 参照ボタン押下イベント
    private void btReference_Click(object sender, EventArgs e)
    {
      //選択されたフォルダをbinパスに表示する
      tbTargetPathText.Text = ReferenceFolder("対象のフォルダを指定してください");
    }
    #endregion

    #region 位置確定ボタン押下イベント
    private void btPathConfirm_Click(object sender, EventArgs e)
    {
      //ねずみ返し_対象フォルダがない場合
      if (Directory.Exists(lbTargetPath.Text))
      {
        MessageBox.Show("対象フォルダが存在しません");
        return;
      }

      //フォルダ内容取得メソッド使用
      GetDirectoryContents();
    }
    #endregion

    #region 開くボタン押下イベント
    private void btOpenExplorer_Click(object sender, EventArgs e)
    {
      //ねずみ返し_初期状態なら開かず終了
      if (lbTargetPath.Text == "-")
      {
        MessageBox.Show("フォルダを指定してください");
        return;
      }
      //ねずみ返し_対象フォルダがない場合
      if (Directory.Exists(lbTargetPath.Text))
      {
        MessageBox.Show("対象フォルダが存在しません");
        return;
      }

      //対象フォルダラベルのフォルダをエクスプローラーで開く
      Process.Start(lbTargetPath.Text);
    }
    #endregion

    #region コミットボタン押下イベント
    private void btCommit_Click(object sender, EventArgs e)
    {
      //ねずみ返し_対象フォルダがない場合
      if (Directory.Exists(lbTargetPath.Text))
      {
        MessageBox.Show("対象フォルダが存在しません");
        return;
      }

      //フォルダパスを取得
      string targetFolderPath = lbTargetPath.Text + @"\";

      //対象Azukiエディタのドキュメント型を取得
      Sgry.Azuki.Document targetDoc = azkTargetFileName.Document;
      //変更後Azukiエディタのドキュメント型を取得
      Sgry.Azuki.Document changedDoc = azkChangedFileName.Document;

      //ねずみ返し_対象がない場合、終了
      if (targetDoc.Length == 0)
      {
        MessageBox.Show("対象となるファイルがありません");
        return;
      }

      //実処理
      for (int i = 0; i < targetDoc.LineCount; i++)
      {
        //置換え対象取得
        string target = targetFolderPath + targetDoc.GetLineContent(i);
        string changed = targetFolderPath + changedDoc.GetLineContent(i);

        //フォルダかファイルか判断
        if (Directory.Exists(target))
        {
          Directory.Move(target, changed);
        }
        else
        {
          File.Move(target, changed);
        }
      }
    }
    #endregion


    #region フォルダ参照メソッド
    private string ReferenceFolder(string fbd_Desc)
    {
      //インスタンス作成
      FolderBrowserDialog fbd = new FolderBrowserDialog();

      //上部に表示する説明テキストを指定する
      fbd.Description = fbd_Desc;
      //ルートフォルダを指定する
      fbd.RootFolder = Environment.SpecialFolder.Desktop;

      //OKが押下された場合
      if (fbd.ShowDialog(this) == DialogResult.OK)
      {
        //取得したフォルダパスを返す
        return fbd.SelectedPath;
      }
      else
      {
        return null;
      }
    }
    #endregion

    #region フォルダ内容取得メソッド
    private void GetDirectoryContents()
    {
      //フォルダパスを取得
      string targetFolderPath = lbTargetPath.Text;

      //対象ディレクトリ内の一覧取得
      string[] targetFolderList = Directory.GetDirectories(targetFolderPath, "*", SearchOption.TopDirectoryOnly);
      string[] targetFileList = Directory.GetFiles(targetFolderPath, "*", SearchOption.TopDirectoryOnly);

      //ねずみ返し_対象がない場合、終了
      if (targetFolderList.Length == 0 && targetFileList.Length == 0)
      {
        MessageBox.Show("対象フォルダにファイルがありません");
        return;
      }

      //対象フォルダの表示
      foreach (string x in targetFolderList)
      {
        //ディレクトリ名に変換
        string y = System.IO.Path.GetFileName(x);
        //Azukiエディタに追記
        targetDoc.Replace(y + "\r\n", targetDoc.Length, targetDoc.Length);
        changedDoc.Replace(y + "\r\n", changedDoc.Length, changedDoc.Length);
      }
      //対象ファイルの表示
      foreach (string x in targetFileList)
      {
        //ファイル名に変換
        string y = System.IO.Path.GetFileName(x);
        //Azukiエディタに追記
        targetDoc.Replace(y + "\r\n", targetDoc.Length, targetDoc.Length);
        changedDoc.Replace(y + "\r\n", changedDoc.Length, changedDoc.Length);
      }

      //対象フォルダ表示
      lbTargetPath.Text = targetFolderPath;
    }
    #endregion


    #region 共通ドラッグエンターイベント
    private void CommonDropEnterEv(object sender, DragEventArgs e)
    {
      //AllowDropプロパティの許可が必要

      //ねずみ返し_マウスがファイルを持っていない場合、イベント・ハンドラを抜ける
      if (!e.Data.GetDataPresent(DataFormats.FileDrop))
      {
        return;
      }

      //ドラッグ中のファイルの取得
      string[] drags = (string[])e.Data.GetData(DataFormats.FileDrop);

      //ねずみ返し_ファイルのみを条件とする
      foreach (string d in drags)
      {
        //フォルダでもファイルでもない場合
        if (!System.IO.Directory.Exists(d) && !System.IO.File.Exists(d))
        {
          return;
        }
      }

      //マウスの表示を「+」に変更する
      e.Effect = DragDropEffects.Copy;
    }
    #endregion

    #region 共通ドラッグドロップイベント
    private void CommonDropDropEv(object sender, DragEventArgs e)
    {
      //ドラッグ&ドロップされたファイルの一つ目を取得
      string dropItem = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];

      //フォルダかファイルか判断
      if (Directory.Exists(dropItem))
      {
        tbTargetPathText.Text = dropItem;
      }
      else
      {
        //対象フォルダ入力欄に表示
        tbTargetPathText.Text = System.IO.Path.GetDirectoryName(dropItem);
      }
    }
    #endregion


    #region 雛形メソッド
    public void template()
    {

    }
    #endregion
  }
}
