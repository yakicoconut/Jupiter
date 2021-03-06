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
  public partial class Form2 : Form
  {
    #region コンストラクタ
    public Form2(string contents)
    {
      InitializeComponent();

      //Azukiエディタにコンテンツを設定
      azkAssist.Text = contents;
    }
    #endregion


    #region プロパティ


    #endregion


    #region フォームロードイベント
    private void Form2_Load(object sender, EventArgs e)
    {

    }
    #endregion


    #region コンテキストイベント一覧

    #region コンテキスト_不透明度押下イベント
    private void 不透明度ToolStripMenuItem_Click(object sender, EventArgs e)
    {
      //デフォルトに戻す
      this.Opacity = 0.8;
    }
    #endregion

    #region コンテキスト_上げ押下イベント
    private void 上げToolStripMenuItem_Click(object sender, EventArgs e)
    {
      //不透明度を上げる
      this.Opacity += 0.2;
    }
    #endregion

    #region コンテキスト_下げ押下イベント
    private void 下げToolStripMenuItem_Click(object sender, EventArgs e)
    {
      //不透明度を下げる
      this.Opacity -= 0.2;
    }
    #endregion

    #endregion


    #region フォームクロージングイベント
    private void Form2_FormClosing(object sender, FormClosingEventArgs e)
    {
      ////クローズキャンセル
      //if (e.CloseReason == CloseReason.UserClosing)
      //  e.Cancel = true;
    }
    #endregion
  }
}
