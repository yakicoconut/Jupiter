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
      // 座標
      tgtFrameLogic.LeftTopX = int.Parse(_comLogic.GetConfigValue("LeftTopX", "1"));
      tgtFrameLogic.LeftTopY = int.Parse(_comLogic.GetConfigValue("LeftTopY", "2"));
      tgtFrameLogic.RightBottomX = int.Parse(_comLogic.GetConfigValue("RightBottomX", "3"));
      tgtFrameLogic.RightBottomY = int.Parse(_comLogic.GetConfigValue("RightBottomY", "4"));
      // 拡大倍率
      tgtFrameLogic.ZoomRatio = double.Parse(_comLogic.GetConfigValue("ZoomRatio", "1.00"));
      // 対象画面範囲取得フォーム不透明度設定
      tgtFrameLogic.TgtFrameOpacity = double.Parse(_comLogic.GetConfigValue("TgtFrameOpacity", "0.25"));
      // キャプチャ保存フォルダ名称
      tgtFrameLogic.CaptureDirName = _comLogic.GetConfigValue("CaptureDirName", "CaptureImg");
      // キャプチャファイル名
      tgtFrameLogic.CaptureFileName = _comLogic.GetConfigValue("CaptureFileName", "CaptureImg_");
      // 移動距離
      tgtFrameLogic.MoveDist = int.Parse(_comLogic.GetConfigValue("MoveDist", "1"));
    }
    #endregion


    #region 宣言

    // 共通ロジッククラスインスタンス
    MCSComLogic _comLogic = new MCSComLogic();

    // 値連携クラスインスタンス取得
    TgtFrameLogic tgtFrameLogic = TgtFrameLogic.GetInstance();

    #endregion


    #region フォームロードイベント
    private void Form1_Load(object sender, EventArgs e)
    {

    }
    #endregion

    #region ボタン1押下イベント
    private void button1_Click(object sender, EventArgs e)
    {
      // 枠調整フォームインスタンス生成
      FrmTgtFrame frmTgtFrame = new FrmTgtFrame();

      // フォーム2呼び出し
      frmTgtFrame.ShowDialog();

      // 結果表示
      textBox1.AppendText("LeftTopX    :" + tgtFrameLogic.LeftTopX.ToString() + Environment.NewLine);
      textBox1.AppendText("LeftTopY    :" + tgtFrameLogic.LeftTopY.ToString() + Environment.NewLine);
      textBox1.AppendText("RightBottomX:" + tgtFrameLogic.RightBottomX.ToString() + Environment.NewLine);
      textBox1.AppendText("RightBottomY:" + tgtFrameLogic.RightBottomY.ToString() + Environment.NewLine);
    }
    #endregion

    #region ボタン2押下イベント
    private void button2_Click(object sender, EventArgs e)
    {

    }
    #endregion


    #region 雛形メソッド
    public void template()
    {

    }
    #endregion
  }
}
