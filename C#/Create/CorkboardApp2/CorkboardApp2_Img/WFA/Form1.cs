using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Reflection;
using System.Configuration;
using System.Collections;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
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
      //基底パネル自動作成クラスインスタンス生成
      ACC_BasePanel basePanel = new ACC_BasePanel();

      //プロパティの設定(設定しない場合デフォルト値となる)
      basePanel.sizeHeight = 30;
      basePanel.sizeWidth = 30;
      basePanel.pointAddX = 50;

      for (int i = 0; i < 5; i++)
      {
        //テキストボックス自動作成メソッド使用
        Panel basePanelA = basePanel.Create("BasePanel_" + i.ToString());
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
    public virtual void ACC_Setting(Control ctrl, string ctrlName)
    {
      //名称
      ctrl.Name = ctrlName;
      //サイズと位置を設定する(実際の基準出現位置+出現位置実態)
      ctrl.Location = new Point(pointLocationX, pointLocationY);
      //位置調整
      pointLocationX += pointAddX;
      pointLocationY += pointAddY;

      ctrl.Size = new Size(sizeWidth, sizeHeight);
    }
    #endregion
  }

  /// <summary>
  /// 基底パネル自動作成クラス
  /// </summary>
  class ACC_BasePanel : ACC_BaseClass
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

    ////出現位置
    //public int pointLocationX { get; set; }
    //public int pointLocationY { get; set; }

    ////二個目以降の出現位置調整
    //public int pointAddX { get; set; }
    //public int pointAddY { get; set; }

    ////サイズ
    //public int sizeWidth { get; set; }
    //public int sizeHeight { get; set; }

    #endregion


    #region 自動作成メソッド
    /// <summary>
    /// 基底パネル自動作成メソッド
    /// </summary>
    /// <param name="ctrlName">コントロール名</param>
    /// <param name="ctrlValue">コントロール値</param>
    /// <returns></returns>
    public Panel Create(string ctrlName)
    {
      //インスタンス生成
      Panel panelA = new Panel();

      //基底コントロール設定メソッド使用
      ACC_Setting(panelA, ctrlName);

      //設定メソッド使用
      Setting(panelA);

      //作成したコントロールを返す
      return panelA;
    }
    #endregion

    #region 設定メソッド
    /// <summary>
    /// 設定メソッド
    /// </summary>
    /// <param name="ctrlName"></param>
    /// <returns></returns>
    public void Setting(Panel panelA)
    {
      //アンカー
      //【注意】アンカーは設定を行うと(Noneでも)サイズ変更イベントが正常に動作しない
      //panelA.Anchor = System.Windows.Forms.AnchorStyles.None;
      //色
      panelA.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
      //フォームのラベルを隠すため最前面にする
      panelA.BringToFront();

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
      //panelA.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BasePanel_MouseMove);
      //panelA.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BasePanel_MouseDown);
    }
    #endregion
  }
}
