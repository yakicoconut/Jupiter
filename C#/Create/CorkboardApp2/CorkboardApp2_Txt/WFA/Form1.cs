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
      string hoge01 = ConfigurationManager.AppSettings["Hoge01"];
    }
    #endregion


    #region ボタン1押下イベント
    private void button1_Click(object sender, EventArgs e)
    {
      //テキストボックス自動作成クラスインスタンス生成
      ACC_CtrlCreateClass ctrlCreateClass = new ACC_CtrlCreateClass();

      for (int i = 0; i < 5; i++)
      {
        //テキストボックス自動作成メソッド使用
        Panel panelA = ctrlCreateClass.MainCtrlCreate(i.ToString());
        //フォームに追加
        Controls.Add(panelA);
      }
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

  /// <summary>
  /// 基底クラス_コントロール自動作成
  /// </summary>
  class ACC_BaseClass
  {
    #region コンストラクタ
    public ACC_BaseClass()
    {
      //プロパティ初期値設定メソッド使用
      PropDefault();
    }
    #endregion


    #region プロパティ

    #region プロパティ初期値(C#6.0から)
    /* ※C#6.0からの機能
      //出現位置
      public int pointLocationX { get; set; } = 0;
      public int pointLocationY { get; set; } = 0;
      //二個目以降の出現位置調整
      public int pointAddX { get; set; } = 100 + 1;
      public int pointAddY { get; set; } = 0;
      //サイズ
      public int sizeWidth { get; set; } = 100;
      public int sizeHeight { get; set; } = 100;
      */
    #endregion

    #region 宣言

    //出現位置
    public int pointLocationX { get; set; }
    public int pointLocationY { get; set; }

    //二個目以降の出現位置調整
    public int pointAddX { get; set; }
    public int pointAddY { get; set; }

    //サイズ
    public int sizeWidth { get; set; }
    public int sizeHeight { get; set; }

    #endregion

    #region プロパティ初期値設定メソッド
    void PropDefault()
    {
      //出現位置
      pointLocationX = 0;
      pointLocationY = 0;
      //二個目以降の出現位置調整
      pointAddX = 100 + 1;
      pointAddY = 0;
      //サイズ
      sizeWidth = 100;
      sizeHeight = 100;
    }
    #endregion

    #endregion


    #region 基底コントロール設定メソッド
    /// <summary>
    /// コントロール設定
    /// </summary>
    /// <param name="ctrl"></param>
    /// <param name="ctrlName">名称</param>
    public virtual Control ACC_Setting(Control ctrl)
    {
      //サイズと位置を設定する(実際の基準出現位置+出現位置実態)
      ctrl.Location = new Point(pointLocationX, pointLocationY);
      //位置調整
      pointLocationX += pointAddX;
      pointLocationY += pointAddY;

      ctrl.Size = new Size(sizeWidth, sizeHeight);

      return ctrl;
    }
    #endregion
  }


  /// <summary>
  /// テキストボックス自動生成クラス
  /// </summary>
  class ACC_CtrlCreateClass : ACC_BaseClass
  {
    #region プロパティ


    #endregion


    #region コントロール自動作成メインメソッド
    public Panel MainCtrlCreate(string ctrlNum)
    {
      //基底パネル作成メソッド使用
      Panel panelA = BasePanelCreate(ctrlNum);

      //リッチテキストボックス作成メソッド使用
      panelA.Controls.Add(RichTextBoxCreate(ctrlNum));

      return panelA;
    }
    #endregion

    #region 基底パネル作成メソッド
    public Panel BasePanelCreate(string ctrlNum)
    {
      //事前準備
      ctrlNum = "BasePanel_" + ctrlNum;

      //作成コントロールインスタンス生成
      Panel ctrlA = new Panel();

      //基底コントロール設定メソッド使用
      ctrlA = (Panel)ACC_Setting(ctrlA);

      //名称
      ctrlA.Name = ctrlNum;
      //色
      ctrlA.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
      //アンカー
      //【注意】アンカーは設定を行うと(Noneでも)サイズ変更イベントが正常に動作しない
      //basePanelA.Anchor = System.Windows.Forms.AnchorStyles.None;

      //作成したコントロールを返す
      return ctrlA;
    }
    #endregion

    #region リッチテキストボックス作成メソッド
    public RichTextBox RichTextBoxCreate(string ctrlNum)
    {
      //事前準備
      ctrlNum = "RichTextBox_" + ctrlNum;

      //作成コントロールインスタンス生成
      RichTextBox ctrlA = new RichTextBox();

      //名称
      ctrlA.Name = ctrlNum;
      //サイズと位置を設定する(実際の基準出現位置+出現位置実態)
      ctrlA.Location = new Point(2, 2);
      //サイズ
      ctrlA.Size = new Size(sizeWidth - 6, sizeHeight - 32);
      //アンカー
      ctrlA.Anchor = System.Windows.Forms.AnchorStyles.None;

      //作成したコントロールを返す
      return ctrlA;
    }
    #endregion
  }
}
