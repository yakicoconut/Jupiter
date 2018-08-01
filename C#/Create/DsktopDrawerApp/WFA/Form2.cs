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
    public Form2(Form1 fm)
    {
      InitializeComponent();

      // 親フォーム設定
      fmParent = fm;
    }
    #endregion


    #region 宣言

    // 親フォーム
    Form1 fmParent;

    // 線描画フラグ
    bool mouseDrug = false;

    // 描画開始座標
    int prevX;
    int prevY;

    #endregion


    #region フォームロードイベント
    private void Form2_Load(object sender, EventArgs e)
    {
      // 本フォームにイベントを追加
      this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.form2_MouseDown);
      this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.form2_MouseUp);
      this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.form2_MouseMove);
    }
    #endregion

    #region フォーム2マウスダウンイベント
    private void form2_MouseDown(object sender, MouseEventArgs e)
    {
      // 描画開始
      mouseDrug = true;
      prevX = e.Location.X;
      prevY = e.Location.Y;
    }
    #endregion

    #region フォーム2マウスアップイベント
    private void form2_MouseUp(object sender, MouseEventArgs e)
    {
      // 描画終了
      mouseDrug = false;
    }
    #endregion

    #region フォーム2マウスムーブイベント
    private void form2_MouseMove(object sender, MouseEventArgs e)
    {
      // ねずみ返し_描画フラグが立っていない場合
      if (!mouseDrug)
      {
        return;
      }

      // ペンオブジェクト生成
      using (Pen objPen = new Pen(Color.Black, 1))
      {
        // グラフィックスオブジェクト生成
        // 親フォームのグラフィックに直接アクセス
        using (Graphics objGrp = fmParent.CreateGraphics())
        {
          // 線描画
          objGrp.DrawLine(objPen, prevX, prevY, e.Location.X, e.Location.Y);
        }
      }

      // 描画(マウスドラッグ)後の座標を開始座標に設定
      prevX = e.Location.X;
      prevY = e.Location.Y;
    }
    #endregion


    #region コンテキスト_不透明度押下イベント
    private void toolStripMenuItemOpacity_Click(object sender, EventArgs e)
    {
      // デフォルトに戻す
      this.Opacity = 0.8;
    }
    #endregion

    #region コンテキスト_上げ押下イベント
    private void toolStripMenuItemOpacityGain_Click(object sender, EventArgs e)
    {
      // 不透明度が0.8以上なら
      if (this.Opacity >= 0.8)
      {
        // ※Graphicsで黒塗りつぶしをしていると
        //   不透明度を100%から下げたあとにとなぜか色が元に戻ってしまうため最大99%とする
        this.Opacity = 0.99;
        return;
      }

      // 不透明度を上げる
      this.Opacity += 0.2;
    }
    #endregion

    #region コンテキスト_下げ押下イベント
    private void toolStripMenuItemOpacityDec_Click(object sender, EventArgs e)
    {
      // 不透明度を下げる
      this.Opacity -= 0.2;

      // 不透明度が0.1以下なら
      if (this.Opacity <= 0.1)
      {
        // 不透明度を0%にするとフォームが非表示扱いとなってしまうため
        this.Opacity = 0.01;
      }
    }
    #endregion

    #region コンテキスト_透明押下イベント
    private void ToolStripMenuItemOpacityTransparent_Click(object sender, EventArgs e)
    {
      // 不透明度を0%にするとフォームが非表示扱いとなってしまうため
      this.Opacity = 0.01;
    }
    #endregion

    #region コンテキスト_タスクバー押下イベント
    private void ToolStripMenuItemTaskBar_Click(object sender, EventArgs e)
    {
      // タスクバー非表示の場合
      if (fmParent.Bounds.Height == SystemInformation.WorkingArea.Height)
      {
        // タスクバー非表示
        fmParent.Bounds = Screen.PrimaryScreen.Bounds;
      }
      else
      {
        // タスクバー表示
        fmParent.Bounds = new Rectangle(0, 0, SystemInformation.PrimaryMonitorSize.Width, SystemInformation.WorkingArea.Height);
      }
    }
    #endregion

    #region コンテキスト_閉じる押下イベント
    private void toolStripMenuItemClose_Click(object sender, EventArgs e)
    {
      // フォーム閉じる
      fmParent.Close();
    }
    #endregion
  }
}
