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
using System.Threading;

namespace WFA
{
  /// <summary>
  /// メインフォーム
  /// </summary>
  public partial class Form1 : Form
  {
    #region コンストラクタ
    public Form1()
    {
      InitializeComponent();

      #region 【論理雛形】
      WFAComLogic WFACL = new WFAComLogic();
      // アプリ名設定
      Text = WFACL.GetAppName();
      #endregion

      // コンフィグ取得メソッド使用
      GetConfig();
    }
    #endregion

    #region コンフィグ取得メソッド
    public void GetConfig()
    {
      targetGif = _comLogic.GetConfigValue("TargetGif", "Sample01.gif");
    }
    #endregion


    #region 宣言

    // 共通ロジッククラスインスタンス
    MCSComLogic _comLogic = new MCSComLogic();

    // 対象画像Bitmap
    Bitmap animatedImage;
    
    // 対象Gifファイル
    string targetGif;

    // スローモーション間隔
    int slowmotionTime;

    #endregion


    #region フォームロードイベント
    private void Form1_Load(object sender, EventArgs e)
    {
      // GIFアニメ画像の読み込み
      animatedImage = new Bitmap(@"Sample01.gif");
      // アニメ開始
      ImageAnimator.Animate(animatedImage, new EventHandler(this.Image_FrameChanged));
    }
    #endregion

    #region 開始ボタン押下イベント
    private void btStart_Click(object sender, EventArgs e)
    {
      // アニメ開始
      ImageAnimator.Animate(animatedImage, new EventHandler(this.Image_FrameChanged));
    }
    #endregion

    #region 停止ボタン押下イベント
    private void btStop_Click(object sender, EventArgs e)
    {
      // アニメ停止
      ImageAnimator.StopAnimate(animatedImage, new EventHandler(this.Image_FrameChanged));
    }
    #endregion

    #region スローモーション間隔数値ボックス変更イベント
    private void nupSlowInterval_ValueChanged(object sender, EventArgs e)
    {
      // スローモーション間隔設定
      slowmotionTime = (int)nupSlowInterval.Value;
    }
    #endregion


    #region 画像変更イベント
    private void Image_FrameChanged(object o, EventArgs e)
    {
      // スローモーション設定
      Thread.Sleep(slowmotionTime);
      // Paintイベントハンドラを呼び出す
      pictureBox1.Invalidate();
    }
    #endregion

    #region ピクチャボックス描画イベント
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
      // フレームを進める
      ImageAnimator.UpdateFrames(animatedImage);
      // 画像の表示
      e.Graphics.DrawImage(animatedImage, 0, 0);
    }
    #endregion


    #region 雛形メソッド
    public void template()
    {

    }
    #endregion
  }
}
