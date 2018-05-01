﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WFA
{
  public partial class FrmFileList : Form
  {
    #region コンストラクタ
    public FrmFileList()
    {
      InitializeComponent();

      // タイトル設定
      this.Text = "FileList";
    }
    #endregion


    #region 宣言

    // 親フォーム
    public Form1 parentForm { get; set; }

    #endregion


    #region フォームロードイベント
    private void FrmFileList_Load(object sender, EventArgs e)
    {
      // タイトル設定
      this.Text = "FileList";

      // タスクバーにアイコンを表示しない
      this.ShowInTaskbar = false;
    }
    #endregion


    #region リストビューダブルクリックイベント
    private void lvFileList_MouseDoubleClick(object sender, MouseEventArgs e)
    {

    }
    #endregion

    #region リストビューマウスダウンイベント
    private void lvFileList_MouseDown(object sender, MouseEventArgs e)
    {

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

    #region コンテキスト_移動押下イベント
    private void ToolStripMenuItemMove_Click(object sender, EventArgs e)
    {

    }
    #endregion

    #region コンテキスト_コピー押下イベント
    private void ToolStripMenuItemCopy_Click(object sender, EventArgs e)
    {

    }
    #endregion

    #region コンテキスト_削除押下イベント
    private void ToolStripMenuItemDelete_Click(object sender, EventArgs e)
    {

    }
    #endregion

    #region コンテキスト_開く押下イベント
    private void ToolStripMenuItemOpen_Click(object sender, EventArgs e)
    {

    }
    #endregion


    #region フォームクロージングイベント
    private void FrmFileList_FormClosing(object sender, FormClosingEventArgs e)
    {
      // クローズキャンセル
      if (e.CloseReason == CloseReason.UserClosing)
      {
        e.Cancel = true;

        // 非表示
        this.Visible = false;
      }
    }
    #endregion
  }
}