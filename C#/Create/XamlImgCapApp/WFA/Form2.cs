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
    public Form2()
    {
      InitializeComponent();

      //ウィンド最大化・前面表示
      this.WindowState = FormWindowState.Maximized;
      TopMost = true;

      //画像取得メソッド使用
      GetScreenImage();
    }
    #endregion


    #region 宣言

    Image img;

    #endregion

    #region 画像取得メソッド
    public void GetScreenImage()
    {
      //イメージを取得し表示
      img = Image.FromFile(@"ScreenImage.jpg");
      pictureBox1.Image = img;
    }
    #endregion

    #region フォームクロージング
    private void Form2_FormClosing(object sender, FormClosingEventArgs e)
    {
      //イメージ解放
      img.Dispose();
    }
    #endregion




    //表示する画像
    private Bitmap currentImage;
    //倍率
    private double zoomRatio = 1d;
    //倍率変更後の画像のサイズと位置
    private Rectangle drawRectangle;

    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
      int getX = e.X;
      int getY = e.Y;


    }


  }
}
