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
      ACC_BasePanel basePanelCreate = new ACC_BasePanel();

      ////プロパティの設定(設定しない場合デフォルト値となる)
      //basePanelCreate.sizeHeight = 30;
      //basePanelCreate.sizeWidth = 30;
      //basePanelCreate.pointAddX = 50;

      for (int i = 0; i < 5; i++)
      {
        //テキストボックス自動作成メソッド使用
        Panel basePanelA = basePanelCreate.Create("BasePanel_" + i.ToString());
        //フォームに追加
        Controls.Add(basePanelA);
        ////子コントロールを基底パネルに追加
        //foreach (string x in belongToBP)
        //{
        //    basePanelA.Controls.Add(Controls[x]);
        //}
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
  /// テキストボックス自動作成クラス
  /// </summary>
  class ACC_BasePanel
  {
    #region コンストラクタ
    public ACC_BasePanel()
    {
      #region プロパティの初期値設定

      //出現位置
      pointLocationX = 0;
      pointLocationY = 0;
      //二個目以降の出現位置調整
      pointAddX = 100 + 1;
      pointAddY = 0;
      //サイズ
      sizeWidth = 100;
      sizeHeight = 100;

      #endregion
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


    //出現位置
    private int _pointLocationX;
    public int pointLocationX
    {
      set { _pointLocationX = value; }
      get { return _pointLocationX; }
    }
    private int _pointLocationY;
    public int pointLocationY
    {
      set { _pointLocationY = value; }
      get { return _pointLocationY; }
    }

    //二個目以降の出現位置調整
    private int _pointAddX;
    public int pointAddX
    {
      set { _pointAddX = value; }
      get { return _pointAddX; }
    }
    private int _pointAddY;
    public int pointAddY
    {
      set { _pointAddY = value; }
      get { return _pointAddY; }
    }

    //サイズ
    private int _sizeWidth;
    public int sizeWidth
    {
      set { _sizeWidth = value; }
      get { return _sizeWidth; }
    }
    private int _sizeHeight;
    public int sizeHeight
    {
      set { _sizeHeight = value; }
      get { return _sizeHeight; }
    }

    #endregion


    #region テキストボックス自動作成メソッド
    /// <summary>
    /// テキストボックス自動作成メソッド
    /// </summary>
    /// <param name="ctrlName">コントロール名</param>
    /// <param name="ctrlValue">コントロール値</param>
    /// <returns></returns>
    public Panel Create(string ctrlName)
    {
      //TextBoxクラスのインスタンスを作成する
      Panel basePanelA = new Panel();

      /*コントロール設定*/
      basePanelA.Name = ctrlName;
      //サイズと位置を設定する(実際の基準出現位置+出現位置実態)
      basePanelA.Location = new Point(pointLocationX, pointLocationY);
      basePanelA.Size = new Size(sizeWidth, sizeHeight);
      //アンカー
      //【注意】アンカーは設定を行うと(Noneでも)サイズ変更イベントが正常に動作しない
      //basePanelA.Anchor = System.Windows.Forms.AnchorStyles.None;
      //色
      basePanelA.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
      //フォームのラベルを隠すため最前面にする
      basePanelA.BringToFront();

      //位置調整
      pointLocationX += pointAddX;
      pointLocationY += pointAddY;

      ////次に出る基底パネルの横位置が現在のフォームサイズを越すようなら
      //if (basePanelPointX >= this.Size.Width)
      //{
      //    //Xの値を0に戻す
      //    basePanelPointX = 0;
      //    //Yの値を規定サイズ分下に下げる
      //    basePanelPointY += DefaultSizeHeight;
      //}

      ///*イベントの追加*/
      //basePanelA.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BasePanel_MouseMove);
      //basePanelA.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BasePanel_MouseDown);

      //作成したコントロールを返す
      return basePanelA;
    }
    #endregion
  }

  #region テキストボックス自動作成クラス
  ///// <summary>
  ///// テキストボックス自動作成クラス
  ///// </summary>
  //class ACC_TextBox
  //{
  //    #region プロパティ

  //    //出現位置
  //    public int pointLocationX { get; set; } = 100;
  //    public int pointLocationY { get; set; } = 0;
  //    //二個目以降の出現位置調整
  //    public int pointAddX { get; set; } = 20;
  //    public int pointAddY { get; set; } = 0;
  //    //サイズ
  //    public int sizeWidth { get; set; } = 10;
  //    public int sizeHeight { get; set; } = 10;

  //    #endregion


  //    #region テキストボックス自動作成メソッド
  //    /// <summary>
  //    /// テキストボックス自動作成メソッド
  //    /// </summary>
  //    /// <param name="ctrlName">コントロール名</param>
  //    /// <param name="ctrlValue">コントロール値</param>
  //    /// <returns></returns>
  //    public TextBox Create(string ctrlName, string ctrlValue)
  //    {
  //        //TextBoxクラスのインスタンスを作成する
  //        TextBox textBoxA = new TextBox();

  //        /*コントロール設定*/
  //        textBoxA.Name = ctrlName;
  //        textBoxA.Text = ctrlValue;
  //        //サイズと位置を設定する(実際の基準出現位置+出現位置実態)
  //        textBoxA.Location = new Point(pointLocationX, pointLocationY);
  //        textBoxA.Size = new Size(sizeWidth, sizeHeight);

  //        //位置調整
  //        pointLocationX += pointAddX;
  //        pointLocationY += pointAddY;

  //        //作成したコントロールを返す
  //        return textBoxA;
  //    }
  //    #endregion
  //}
  #endregion
}
