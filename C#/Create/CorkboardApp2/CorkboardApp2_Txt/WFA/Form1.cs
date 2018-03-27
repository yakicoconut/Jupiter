//#define TEST_ReceiveItemShow //【テスト】送るコマンド
#define TEST_CtrlCreateMain //【テスト】コントロール自動生成実行
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


    #region 宣言

    //コントロール自動作成クラスインスタンス生成
    ACC_CtrlCreateClass ctrlCreateClass = new ACC_CtrlCreateClass();

    #endregion


    #region ファイル読み込み関連イベント一覧

    #region フォームショウイベント(送るで渡されるファイルを開く)
    private void Form1_Shown(object sender, EventArgs e)
    {
      //送るで渡されるコマンドライン引数を配列で取得
      string[] args = Environment.GetCommandLineArgs();

#if TEST_ReceiveItemShow
      //【テスト】とりあえず表示
      TEST_ReceiveItemShow(args);
#endif
#if TEST_CtrlCreateMain
      //【テスト】コントロール自動生成実行
      TEST_CtrlCreateMain(3);
#endif

      //ねずみ返し
      //引数が渡されなくても本アプリ自身のパスを配列に格納するので総数が1つの場合は終了
      if (args.Length == 1)
      {
        return;
      }

      ////コントロール自動作成作成メソッド使用
      //ControlAutoCreate(args);
    }

    #endregion

    #region マウスインされるファイルを開くイベント

    #region フォームドラッグエンターイベント
    private void Form1_DragEnter(object sender, DragEventArgs e)
    {
      //AllowDropプロパティの許可が必要

      //ねずみ返し_マウスがファイルを持っていない場合、イベント・ハンドラを抜ける
      if (!e.Data.GetDataPresent(DataFormats.FileDrop))
      {
        return;
      }

      //ドラッグ中のファイルの取得
      string[] drags = (string[])e.Data.GetData(DataFormats.FileDrop);

      //ねずみ返し_ファイルのみを条件とする
      foreach (string d in drags)
      {
        //ファイル以外であればイベント・ハンドラを抜ける
        if (!System.IO.File.Exists(d))
        {
          return;
        }
      }

      //マウスの表示を「+」に変更する
      e.Effect = DragDropEffects.Copy;
    }
    #endregion

    #region フォームドラッグドロップイベント
    private void Form1_DragDrop(object sender, DragEventArgs e)
    {
      //ドラッグ&ドロップされたファイルの取得
      string[] args = (string[])e.Data.GetData(DataFormats.FileDrop);

#if TEST_ReceiveItemShow
      //【テスト】とりあえず表示
      TEST_ReceiveItemShow(args);
#endif

      ////コントロール自動作成作成メソッド使用
      //ControlAutoCreate(args);
    }
    #endregion

    #endregion

    #region 【テスト】送るで受け取ったファイルのとりあえず表示
    [Conditional("TEST_ReceiveItemShow")]
    private void TEST_ReceiveItemShow(string[] args)
    {
      int i = 0;
      foreach (string x in args)
      {
        i = ++i;
        MessageBox.Show(i.ToString() + "/" + args.Length.ToString() + "\r\n" + x, "TEST_ReceiveItemShow");
      }
    }
    #endregion

    #region 【テスト】コントロール自動生成実行
    [Conditional("TEST_CtrlCreateMain")]
    private void TEST_CtrlCreateMain(int num)
    {
      //コントロール自動作成クラスインスタンス生成
      ACC_CtrlCreateClass TEST_ctrlCreateClass = new ACC_CtrlCreateClass();

      for (int i = 0; i < num; i++)
      {
        //コントロール自動作成メインメソッド使用
        Panel panelA = TEST_ctrlCreateClass.CtrlCreateMain(String.Format("{0:0000}", i));
        //フォームに追加
        Controls.Add(panelA);
      }
    }
    #endregion

    #endregion

    #region ボタン1押下イベント
    private void button1_Click(object sender, EventArgs e)
    {
      //テキストボックス自動作成クラスインスタンス生成
      ACC_CtrlCreateClass ctrlCreateClass = new ACC_CtrlCreateClass();

      for (int i = 0; i < 5; i++)
      {
        //テキストボックス自動作成メソッド使用
        Panel panelA = ctrlCreateClass.CtrlCreateMain(i.ToString());
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
  class ACC_BaseCreateClass
  {
    #region コンストラクタ
    public ACC_BaseCreateClass()
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

    //名称
    public string ctrlName { get; set; }


    //共通出現位置
    public int commonAppeaX { get; set; }
    public int commonAppeaY { get; set; }
    //共通サイズ
    public int commonSizeW { get; set; }
    public int commonSizeH { get; set; }


    //基底パネル出現位置
    public int basePanelAppeaX { get; set; }
    public int basePanelAppeaY { get; set; }
    //基底パネル二個目以降の出現位置調整
    public int basePanelAddX { get; set; }
    public int basePanelAddY { get; set; }
    //基底パネルサイズ
    public int basePanelSizeW { get; set; }
    public int basePanelSizeH { get; set; }

    #endregion

    #region プロパティ初期値設定メソッド
    void PropDefault()
    {
      //共通出現位置
      commonAppeaX = 0;
      commonAppeaY = 0;
      //共通サイズ
      commonSizeW = 98;
      commonSizeH = 98;


      //基底パネル出現位置
      basePanelAppeaX = 0;
      basePanelAppeaY = 0;
      //基底パネルサイズ
      basePanelSizeW = 200;
      basePanelSizeH = 200;
      //基底パネル二個目以降の出現位置調整
      basePanelAddX = basePanelSizeW + 1;
      basePanelAddY = 0;
    }
    #endregion

    #endregion


    #region 基底パネル設定メソッド
    /// <summary>
    /// 基底パネル設定メソッド
    /// </summary>
    /// <param name="ctrlA"></param>
    /// <returns></returns>
    public virtual Control ACC_BasePanelSetting(Control ctrlA)
    {
      //名称設定
      ctrlA.Name = ctrlName;
      //サイズと位置を設定する(実際の基準出現位置+出現位置実態)
      ctrlA.Location = new Point(basePanelAppeaX, basePanelAppeaY);
      //位置調整
      basePanelAppeaX += basePanelAddX;
      basePanelAppeaY += basePanelAddY;

      ctrlA.Size = new Size(basePanelSizeW, basePanelSizeH);

      return ctrlA;
    }
    #endregion

    #region 汎用コントロール設定メソッド
    /// <summary>
    /// 汎用コントロール設定メソッド
    /// </summary>
    /// <param name="ctrlA"></param>
    /// <returns></returns>
    public virtual Control ACC_CommonCtrlSetting(Control ctrlA)
    {
      //名称設定
      ctrlA.Name = ctrlName;
      //サイズと位置を設定する(実際の基準出現位置+出現位置実態)
      ctrlA.Location = new Point(commonAppeaX, commonAppeaY);
      ctrlA.Size = new Size(commonSizeW, commonSizeH);

      return ctrlA;
    }
    #endregion
  }


  /// <summary>
  /// テキストボックス自動生成クラス
  /// </summary>
  class ACC_CtrlCreateClass : ACC_BaseCreateClass
  {
    #region プロパティ


    #endregion


    #region コントロール自動作成メインメソッド
    public Panel CtrlCreateMain(string ctrlNum)
    {
      //基底パネル作成メソッド使用
      Panel panelA = BasePanelCreate(ctrlNum);

      //各自動作成メソッド使用
      panelA.Controls.Add(TitlePanelCreate(ctrlNum));
      panelA.Controls.Add(RichTextBoxCreate(ctrlNum));

      return panelA;
    }
    #endregion

    #region 基底パネル作成メソッド
    public Panel BasePanelCreate(string ctrlNum)
    {
      //共通設定プロパティ
      ctrlName = "BasePanel_" + ctrlNum;

      //作成コントロールインスタンス生成
      Panel ctrlA = new Panel();

      //基底コントロール設定メソッド使用
      ctrlA = (Panel)ACC_BasePanelSetting(ctrlA);

      //色
      ctrlA.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
      //アンカー
      //【注意】アンカーは設定を行うと(Noneでも)サイズ変更イベントが正常に動作しない
      //basePanelA.Anchor = System.Windows.Forms.AnchorStyles.None;

      //作成したコントロールを返す
      return ctrlA;
    }
    #endregion

    #region タイトルパネル作成メソッド
    public Panel TitlePanelCreate(string ctrlNum)
    {
      //共通設定プロパティ
      ctrlName = "TitlePanel_" + ctrlNum;
      commonAppeaX = 4;
      commonAppeaY = 4;
      commonSizeW = basePanelSizeW - 7;
      commonSizeH = 27;

      //作成コントロールインスタンス生成
      Panel ctrlA = new Panel();

      //基底コントロール設定メソッド使用
      ctrlA = (Panel)ACC_CommonCtrlSetting(ctrlA);

      //アンカー
      ctrlA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
      //背景色
      ctrlA.BackColor = System.Drawing.Color.Transparent;

      //子コントロールを紐付ける
      ctrlA.Controls.Add(ButtonPanelCreate(ctrlNum));

      //作成したコントロールを返す
      return ctrlA;
    }
    #endregion

    #region ボタンパネル作成メソッド
    public Panel ButtonPanelCreate(string ctrlNum)
    {
      //共通設定プロパティ
      ctrlName = "ButtonPanel_" + ctrlNum;
      commonAppeaX = basePanelSizeW - 100;
      commonAppeaY = 4;
      commonSizeW = 100;
      commonSizeH = 27;

      //作成コントロールインスタンス生成
      Panel ctrlA = new Panel();

      //基底コントロール設定メソッド使用
      ctrlA = (Panel)ACC_CommonCtrlSetting(ctrlA);

      //アンカー
      ctrlA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
      //背景色
      ctrlA.BackColor = System.Drawing.Color.AliceBlue;

      //子コントロールを紐付ける
      //ctrlA.Controls.Add(MinButtonCreate(ctrlNum, ctrlA));
      //ctrlA.Controls.Add(MaxButtonCreate(ctrlNum, ctrlA));
      ctrlA.Controls.Add(CloseButtonCreate(ctrlNum, ctrlA));

      //作成したコントロールを返す
      return ctrlA;
    }
    #endregion

    #region 最小化ボタン作成メソッド
    public Button MinButtonCreate(string ctrlNum, Control ctrlP)
    {
      //共通設定プロパティ
      ctrlName = "MinButton_" + ctrlNum;
      commonAppeaX = basePanelSizeW - 85;
      commonAppeaY = 0;
      commonSizeW = 26;
      commonSizeH = 23;

      //作成コントロールインスタンス生成
      Button ctrlA = new Button();

      //基底コントロール設定メソッド使用
      ctrlA = (Button)ACC_CommonCtrlSetting(ctrlA);

      //表示文字
      ctrlA.Text = "_";
      //アンカー
      ctrlA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));

      //作成したコントロールを返す
      return ctrlA;
    }
    #endregion

    #region 最大化ボタン作成メソッド
    public Button MaxButtonCreate(string ctrlNum, Control ctrlP)
    {
      //共通設定プロパティ
      ctrlName = "MaxButton_" + ctrlNum;
      commonAppeaX = basePanelSizeW - 60;
      commonAppeaY = 0;
      commonSizeW = 26;
      commonSizeH = 23;

      //作成コントロールインスタンス生成
      Button ctrlA = new Button();

      //基底コントロール設定メソッド使用
      ctrlA = (Button)ACC_CommonCtrlSetting(ctrlA);

      //表示文字
      ctrlA.Text = "□";
      //アンカー
      ctrlA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));

      //作成したコントロールを返す
      return ctrlA;
    }
    #endregion

    #region 閉じるボタン作成メソッド
    public Button CloseButtonCreate(string ctrlNum, Control ctrlP)
    {
      //共通設定プロパティ
      ctrlName = "CloseButton" + ctrlNum;
      commonAppeaX = ctrlP.Size.Width - 35;
      commonAppeaY = 0;
      commonSizeW = 26;
      commonSizeH = 23;

      //作成コントロールインスタンス生成
      Button ctrlA = new Button();

      //基底コントロール設定メソッド使用
      ctrlA = (Button)ACC_CommonCtrlSetting(ctrlA);

      //表示文字
      ctrlA.Text = "×";
      //アンカー
      ctrlA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      //色
      ctrlA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));

      //作成したコントロールを返す
      return ctrlA;
    }
    #endregion

    #region リッチテキストボックス作成メソッド
    public RichTextBox RichTextBoxCreate(string ctrlNum)
    {
      //共通設定プロパティ
      ctrlName = "RichTextBox_" + ctrlNum;
      commonAppeaX = 3;
      commonAppeaY = 30;
      commonSizeW = basePanelSizeW - 6;
      commonSizeH = basePanelSizeH - 32;

      //作成コントロールインスタンス生成
      RichTextBox ctrlA = new RichTextBox();

      //基底コントロール設定メソッド使用
      ctrlA = (RichTextBox)ACC_CommonCtrlSetting(ctrlA);

      ////アンカー
      //ctrlA.Anchor = System.Windows.Forms.AnchorStyles.None;

      //作成したコントロールを返す
      return ctrlA;
    }
    #endregion
  }
}
