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
  /// <summary>
  /// 
  /// </summary>
  public partial class FrmTgtFrame : Form
  {
    #region コンストラクタ
    public FrmTgtFrame()
    {
      InitializeComponent();
    }
    #endregion

    #region 宣言

    ////調整フォーム宣言
    //Form3 DrawRegulationFormClass;

    // 不透明度退避
    double evacuateOpacity;

    // 親フォーム
    public Form1 form1 { get; set; }

    // 開始/終了座標
    int leftTopX { get; set; }
    int leftTopY { get; set; }
    int rightBottomX { get; set; }
    int rightBottomY { get; set; }

    #endregion


    #region フォームロードイベント
    private void FrmTgtFrame_Load(object sender, EventArgs e)
    {
      // フォームの大きさを最大に固定
      this.WindowState = FormWindowState.Maximized;
      // フォーム不透明度設定
      this.Opacity = 0.6;
      // タイトルバー非表示
      this.FormBorderStyle = FormBorderStyle.None;

      leftTopX = 2;
      leftTopY = 2;

      rightBottomX = 10;
      rightBottomY = 10;
    }
    #endregion

    #region ロームショウイベント
    private void FrmTgtFrame_Shown(object sender, EventArgs e)
    {
      // 対象正方形描画メソッド使用
      DrawSquare();
    }
    #endregion

    #region マウスダブルクリックイベント
    private void FrmTgtFrame_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      // 座標取得メソッド使用
      GetPosition();
    }
    #endregion


    #region 座標取得メソッド
    private void GetPosition()
    {
      #region 【要調査】

      /*
       * 微妙に左上にズレる
       */
      //// クリック位置の座標取得
      //int x = Cursor.Position.X;
      //int y = Cursor.Position.Y;

      #endregion

      // フォーム上の座標でマウスポインタの位置を取得する
      Point sp = Cursor.Position;
      // 画面座標をクライアント座標に変換する
      Point cp = this.PointToClient(sp);

      //// クリック位置の座標取得
      int x = cp.X;
      int y = cp.Y;

      // 背景が黒の場合
      if (this.BackColor == Color.Black)
      {
        // ポイントテスト描画メソッド使用
        DrawPointTest(x, y);

        return;
      }

      // ラジオボタンで始点か終点を判断
      if (rbLeftTop.Checked)
      {
        // プロパティ設定
        leftTopX = x;
        leftTopY = y;

        // ラジオボタンに始点座標を表示
        rbLeftTop.Text = x.ToString() + "×" + y.ToString();

        // 右下ラジオボタンにチェック
        rbRightBottom.Checked = true;
      }
      else if (rbRightBottom.Checked)
      {
        rightBottomX = x;
        rightBottomY = y;

        rbRightBottom.Text = x.ToString() + "×" + y.ToString();

        rbLeftTop.Checked = true;

        // 対象正方形描画メソッド使用
        // 描画処理は終点のみで行う
        DrawSquare();
      }

      return;
    }
    #endregion

    #region ポイントテスト描画メソッド
    private void DrawPointTest(int x, int y)
    {
      // 対象点作成
      Point targetPoint = new Point(x, y);

      // Graphicsオブジェクトの作成
      using (Graphics g = this.CreateGraphics())
      {
        // 白点画像を作成
        Bitmap p = new Bitmap(1, 1);
        p.SetPixel(0, 0, Color.White);

        // 点描画
        g.DrawImageUnscaled(p, targetPoint);

        return;
      }
    }
    #endregion

    #region 対象正方形描画メソッド
    private void DrawSquare()
    {
      // Graphicsオブジェクトの作成
      using (Graphics g = this.CreateGraphics())
      {
        // 色を初期化
        g.Clear(SystemColors.Control);
        // 直線型のインスタンス生成
        Pen frontCoverPen = new Pen(Color.Green, 1);

        // 表紙lineの始点と終点を設定
        Point leftTop = new Point(leftTopX, leftTopY);
        Point rightButtom = new Point(rightBottomX, rightBottomY);
        // 右上と左下は始点と終点の値をそのまま使用できる
        Point rightTop = new Point(rightBottomX, leftTopY);
        Point leftButtom = new Point(leftTopX, rightBottomY);

        // 表紙lineを描画
        g.DrawLine(frontCoverPen, leftTop, rightTop);
        g.DrawLine(frontCoverPen, leftTop, leftButtom);
        g.DrawLine(frontCoverPen, rightButtom, rightTop);
        g.DrawLine(frontCoverPen, rightButtom, leftButtom);

        return;
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
      // 不透明度を上げる
      this.Opacity += 0.2;
    }
    #endregion

    #region コンテキスト_下げ押下イベント
    private void toolStripMenuItemOpacityDec_Click(object sender, EventArgs e)
    {
      // 不透明度を下げる
      this.Opacity -= 0.2;
    }
    #endregion

    #region コンテキスト_ポイントテスト押下イベント
    private void ToolStripMenuItemPointTest_Click(object sender, EventArgs e)
    {
      // 標準色の場合
      if (this.BackColor == SystemColors.Control)
      {
        // 色を黒にする
        this.BackColor = Color.Black;

        // 不透明度退避
        evacuateOpacity = this.Opacity;
        // 不透明度を最大に上げる
        this.Opacity = 0.8;
      }
      else if (this.BackColor == Color.Black)
      {
        // 色を元に戻す
        this.BackColor = SystemColors.Control;

        // 不透明度を戻す
        this.Opacity = evacuateOpacity;
      }
    }
    #endregion

    #region コンテキスト_閉じる押下イベント
    private void toolStripMenuItemClose_Click(object sender, EventArgs e)
    {
      // フォーム閉じる
      this.Close();
    }
    #endregion
  }
}