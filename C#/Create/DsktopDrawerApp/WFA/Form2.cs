using System;
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

    // 画面更新判断座標
    int refreshX;
    int refreshY;

    #endregion


    #region フォームロードイベント
    private void Form2_Load(object sender, EventArgs e)
    {
      // ピクチャボックス生成
      PictureBox pbMain = new PictureBox();
      pbMain.Dock = System.Windows.Forms.DockStyle.Fill;
      pbMain.Location = new System.Drawing.Point(0, 0);
      pbMain.Name = "pictureBox1";
      pbMain.TabIndex = 0;
      pbMain.TabStop = false;
      pbMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
      pbMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
      pbMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);

      // フォーム設定
      this.Controls.Add(pbMain);
      ((System.ComponentModel.ISupportInitialize)(pbMain)).EndInit();
    }
    #endregion

    #region ピクチャボックスマウスダウンイベント
    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
      // 描画開始
      mouseDrug = true;
      prevX = e.Location.X;
      prevY = e.Location.Y;

      // 画面更新判断座標
      refreshX = e.Location.X;
      refreshY = e.Location.Y;
    }
    #endregion

    #region ピクチャボックスマウスアップイベント
    private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
      // 描画終了
      mouseDrug = false;
    }
    #endregion

    #region ピクチャボックスマウスムーブイベント
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
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
        using (Graphics objGrp = Graphics.FromImage(fmParent.mouseTraject))
        {
          // 線描画
          objGrp.DrawLine(objPen, prevX, prevY, e.Location.X, e.Location.Y);
        }
      }

      // 描画(マウスドラッグ)後の座標を開始座標に設定
      prevX = e.Location.X;
      prevY = e.Location.Y;

      // 親フォーム背景設定
      fmParent.BackgroundImage = fmParent.mouseTraject;

      // ドラッグ開始地点から一定の距離動かした場合
      if (Math.Abs(prevX - refreshX) > 10 || Math.Abs(prevY - refreshY) > 10)
      {
        // 画像を更新(更新しないと描画されないため)
        fmParent.Refresh();

        // 画面更新判断座標更新
        refreshX = prevX;
        refreshY = prevY;
      }
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
      /* 要調整 */
      //// タスクバー非表示の場合
      //if (this.Bounds.Height == SystemInformation.WorkingArea.Height)
      //{
      //  // タスクバー非表示
      //  this.Bounds = Screen.PrimaryScreen.Bounds;
      //}
      //else
      //{
      //  // タスクバー表示
      //  this.Bounds = new Rectangle(0, 0, SystemInformation.PrimaryMonitorSize.Width, SystemInformation.WorkingArea.Height);
      //}
    }
    #endregion

    #region コンテキスト_閉じる押下イベント
    private void toolStripMenuItemClose_Click(object sender, EventArgs e)
    {
      /* 要調整 */
      //// フォーム閉じる
      //this.Close();
    }
    #endregion
  }
}
