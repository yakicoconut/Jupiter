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
    }
    #endregion

    #region インスタンス

    //処理クラス
    MainLosic mLogic = new MainLosic();

    #endregion

    #region プロパティ

    //変更後値のバックアップ用
    public string changedBk { get; set; }

    #endregion


    #region 参照ボタン押下イベント
    private void btReference_Click(object sender, EventArgs e)
    {
      //退避
      string evacuation = tbTargetPathText.Text;
      //フォルダ参照メソッド使用
      string reference = mLogic.ReferenceFolder(this);

      //ねずみ返し_参照指定していない場合
      if (reference == null)
      {
        //退避値を戻して終了
        tbTargetPathText.Text = evacuation;
        return;
      }

      //参照値を設定
      tbTargetPathText.Text = reference;
    }
    #endregion

    #region 開くボタン押下イベント
    private void btOpenExplorer_Click(object sender, EventArgs e)
    {
      //ねずみ返し_対象フォルダがない場合
      if (!Directory.Exists(lbTargetPath.Text))
      {
        MessageBox.Show("対象フォルダが存在しません");
        return;
      }

      //対象フォルダラベルのフォルダをエクスプローラで開く
      Process.Start(lbTargetPath.Text);
    }
    #endregion

    #region 位置確定ボタン押下イベント
    private void btPathConfirm_Click(object sender, EventArgs e)
    {
      //ねずみ返し_対象フォルダテキストの値が有効でない場合
      if (!Directory.Exists(tbTargetPathText.Text))
      {
        MessageBox.Show("対象フォルダが存在しません");
        return;
      }

      //対象Azukiエディタのドキュメント型を設定
      mLogic.targetDoc = azkTargetFileName.Document;
      //変更後Azukiエディタのドキュメント型を設定
      mLogic.changedDoc = azkChangedFileName.Document;
      //フォルダファイル一覧表示メソッド使用
      mLogic.ForlderAndFileDisplay(tbTargetPathText.Text);

      //対象フォルダを表示
      lbTargetPath.Text = tbTargetPathText.Text;
    }
    #endregion

    #region 実行ボタン押下イベント
    private void btExec_Click(object sender, EventArgs e)
    {
      //ねずみ返し_対象フォルダがない場合
      if (!Directory.Exists(lbTargetPath.Text))
      {
        MessageBox.Show("対象フォルダが存在しません");
        return;
      }
      //ねずみ返し_対象がない場合、終了
      if (azkTargetFileName.Document.Length == 0)
      {
        MessageBox.Show("対象となるファイルがありません");
        return;
      }

      //確認メッセージ
      DialogResult result = MessageBox.Show("リネーム処理を行います", "実施", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
      if (result == DialogResult.Yes)
      {
        //変更後値バックアップを設定
        changedBk = azkChangedFileName.Text;
        //対象Azukiエディタのドキュメント型を設定
        mLogic.targetDoc = azkTargetFileName.Document;
        //変更後Azukiエディタのドキュメント型を設定
        mLogic.changedDoc = azkChangedFileName.Document;
        //リネーム処理メソッド使用
        if (!mLogic.RenameProcess(lbTargetPath.Text))
        {
          //エラーからの中断の場合
          MessageBox.Show("処理が終了しました");
          //フォルダファイル一覧表示メソッド使用
          mLogic.ForlderAndFileDisplay(lbTargetPath.Text);

          return;
        }

        MessageBox.Show("処理を完了しました");
        //フォルダファイル一覧表示メソッド使用
        mLogic.ForlderAndFileDisplay(lbTargetPath.Text);
      }
      else if (result == DialogResult.No)
      {

      }
    }
    #endregion

    #region 前回呼出ボタン押下イベント
    private void btCallBackup_Click(object sender, EventArgs e)
    {
      //フォーム2インスタンス
      Form2 fm2 = new Form2(changedBk);
      //フォーム表示
      fm2.Show();
    }
    #endregion

    #region アシストボタン押下イベント
    private void btAssist_Click(object sender, EventArgs e)
    {
      //フォーム2インスタンス
      Form2 fm2 = new Form2(ConfigurationManager.AppSettings["AssistContents"]);
      //フォーム表示
      fm2.Show();
    }
    #endregion

    #region ログフォルダボタン押下イベント
    private void btOpenLogDir_Click(object sender, EventArgs e)
    {
      //対象フォルダラベルのフォルダをエクスプローラで開く
      Process.Start("Log");
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

      //ねずみ返し_フォルダかファイルを条件とする
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
        //対象フォルダ欄に表示
        lbTargetPath.Text = dropItem;
      }
      else
      {
        lbTargetPath.Text = System.IO.Path.GetDirectoryName(dropItem);
      }

      //対象Azukiエディタのドキュメント型を設定
      mLogic.targetDoc = azkTargetFileName.Document;
      //変更後Azukiエディタのドキュメント型を設定
      mLogic.changedDoc = azkChangedFileName.Document;
      //フォルダファイル一覧表示メソッド使用
      //対象フォルダ欄を使用
      mLogic.ForlderAndFileDisplay(lbTargetPath.Text);
    }
    #endregion

    #region スクロールイベント
    private void azkChangedFileName_VScroll(object sender, EventArgs e)
    {
      azkTargetFileName.ScrollPos = azkChangedFileName.ScrollPos;
    }
    #endregion


    #region 雛形メソッド
    public void template()
    {

    }
    #endregion
  }
}
