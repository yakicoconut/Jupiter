//#define TEST_ReceiveItemShow //【テスト】送るコマンド
//#define TEST_CtrlCreateMain //【テスト】コントロール自動生成実行
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
using System.Runtime.InteropServices;

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
      //対象拡張子
      targetExtension = ConfigurationManager.AppSettings["TargetExtension"].Split(',');
      //デフォルトエンコード
      defaultOpenEncode = ConfigurationManager.AppSettings["DefaultOpenEncode"];
      //デフォルトサイズ
      DefaultSizeWidth = int.Parse(ConfigurationManager.AppSettings["DefaultSizeWidth"]);
      DefaultSizeHeight = int.Parse(ConfigurationManager.AppSettings["DefaultSizeHeight"]);
    }
    #endregion


    #region 宣言

    //コントロール自動作成クラスインスタンス生成
    ACC_CtrlCreateClass ctrlCreateClass = new ACC_CtrlCreateClass();

    //コントロール括り番号(1~9999までを想定、それ以降は未検証)
    int incI_Lumping = 0;

    //対象拡張子
    string[] targetExtension;
    //デフォルトエンコード
    string defaultOpenEncode;
    //デフォルトサイズ
    int DefaultSizeWidth;
    int DefaultSizeHeight;


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

      //コントロール自動生成呼び出しメソッド使用
      CallACC(args);
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

      //コントロール自動生成呼び出しメソッド使用
      CallACC(args);
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
        //引数2:固定引数、自身のパス
        Panel panelA = TEST_ctrlCreateClass.CtrlCreateMain(String.Format("{0:0000}", i), Assembly.GetExecutingAssembly().Location);
        //フォームに追加
        Controls.Add(panelA);
      }
    }
    #endregion

    #region コントロール自動生成呼び出しメソッド
    public void CallACC(string[] args)
    {
      //全ての引数を処理
      foreach (string x in args)
      {
        //ねずみ返し_拡張子が設定したものではないとき次のループへ
        if (Array.IndexOf(targetExtension, Path.GetExtension(x).ToLower()) == -1)
        {
          continue;
        }

        //インクリメントしてコントロール括り番号を作成
        string LumpingNum = "_" + String.Format("{0:0000}", incI_Lumping++);

        //基底パネルの作成
        Panel panelA = ctrlCreateClass.CtrlCreateMain(LumpingNum, x);

        //作成したパネルをフォームに追加
        this.Controls.Add(panelA);
      }
    }
    #endregion

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
    public string ctrlNum { get; set; }
    //タイトル
    public string titleFullPath { get; set; }


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
    #region コントロール自動作成メインメソッド
    public Panel CtrlCreateMain(string argCtrlNum, string filePath)
    {
      //共通プロパティに値を設定
      ctrlNum = argCtrlNum;
      titleFullPath = filePath;

      //基底パネル作成メソッド使用
      Panel panelA = BasePanelCreate();

      return panelA;
    }
    #endregion

    #region 基底パネル作成メソッド
    public Panel BasePanelCreate()
    {
      /*共通設定プロパティ*/
      ctrlName = "BasePanel_" + ctrlNum;

      //作成コントロールインスタンス生成
      Panel ctrlA = new Panel();
      //基底コントロール設定メソッド使用
      ctrlA = (Panel)ACC_BasePanelSetting(ctrlA);

      /*個別設定*/
      //色
      ctrlA.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
      //アンカー
      //【注意】アンカーは設定を行うと(Noneでも)サイズ変更イベントが正常に動作しない

      /*子コントロールの作成*/
      TitlePanelCreate(ctrlA);
      RichTextBoxCreate(ctrlA);

      /*イベントの追加*/
      ctrlA.MouseMove += new System.Windows.Forms.MouseEventHandler(BasePanel_MouseMove);
      ctrlA.MouseDown += new System.Windows.Forms.MouseEventHandler(BasePanel_MouseDown);

      //作成したコントロールを返す
      return ctrlA;
    }
    #endregion


    #region タイトルパネル作成メソッド
    public void TitlePanelCreate(Control ctrlP)
    {
      /*共通設定プロパティ*/
      ctrlName = "TitlePanel_" + ctrlNum;
      commonAppeaX = 4;
      commonAppeaY = 3;
      commonSizeW = ctrlP.Size.Width - 2;
      commonSizeH = 25;

      //作成コントロールインスタンス生成
      Panel ctrlA = new Panel();
      //基底コントロール設定メソッド使用
      ctrlA = (Panel)ACC_CommonCtrlSetting(ctrlA);

      /*個別設定*/
      //アンカー
      ctrlA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
      //色
      ctrlA.BackColor = System.Drawing.SystemColors.GradientActiveCaption;

      /*子コントロールの作成*/
      ButtonPanelCreate(ctrlA);
      TitlePathLabelCreate(ctrlA);
      TitleFileNameLabelCreate(ctrlA);
      /*親コントロールに紐付ける*/
      ctrlP.Controls.Add(ctrlA);

      /*イベントの追加*/
      ctrlA.MouseDown += new System.Windows.Forms.MouseEventHandler(TitlePanel_MouseDown);
    }
    #endregion


    #region タイトルパスラベル作成メソッド
    public void TitlePathLabelCreate(Control ctrlP)
    {
      /*共通設定プロパティ*/
      ctrlName = "TitleLabel_" + ctrlNum;
      commonAppeaX = 0;
      commonAppeaY = 0;
      commonSizeW = ctrlP.Size.Width;
      commonSizeH = 10;

      //作成コントロールインスタンス生成
      Label ctrlA = new Label();
      //基底コントロール設定メソッド使用
      ctrlA = (Label)ACC_CommonCtrlSetting(ctrlA);

      /*個別設定*/
      //アンカー
      ctrlA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
      //タイトル
      ctrlA.Text = titleFullPath;

      /*親コントロールに紐付ける*/
      ctrlP.Controls.Add(ctrlA);

      /*イベントの追加*/
      ctrlA.MouseDown += new System.Windows.Forms.MouseEventHandler(TitlePanel_MouseDown);
    }
    #endregion

    #region タイトルファイル名ラベル作成メソッド
    public void TitleFileNameLabelCreate(Control ctrlP)
    {
      /*共通設定プロパティ*/
      ctrlName = "TitleFileNameLabel_" + ctrlNum;
      commonAppeaX = 0;
      commonAppeaY = 12;
      commonSizeW = ctrlP.Size.Width;
      commonSizeH = 10;

      //作成コントロールインスタンス生成
      Label ctrlA = new Label();
      //基底コントロール設定メソッド使用
      ctrlA = (Label)ACC_CommonCtrlSetting(ctrlA);

      /*個別設定*/
      //アンカー
      ctrlA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
      //タイトル
      ctrlA.Text = System.IO.Path.GetFileName(titleFullPath);

      /*親コントロールに紐付ける*/
      ctrlP.Controls.Add(ctrlA);
    }
    #endregion


    #region ボタンパネル作成メソッド
    public void ButtonPanelCreate(Control ctrlP)
    {
      /*共通設定プロパティ*/
      ctrlName = "ButtonPanel_" + ctrlNum;
      commonAppeaX = ctrlP.Size.Width - 82;
      commonAppeaY = 0;
      commonSizeW = 78;
      commonSizeH = 23;

      //作成コントロールインスタンス生成
      Panel ctrlA = new Panel();
      //基底コントロール設定メソッド使用
      ctrlA = (Panel)ACC_CommonCtrlSetting(ctrlA);

      /*個別設定*/
      //アンカー
      ctrlA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      //色
      ctrlA.BackColor = System.Drawing.Color.AliceBlue;

      /*子コントロールの作成*/
      MinButtonCreate(ctrlA);
      MaxButtonCreate(ctrlA);
      CloseButtonCreate(ctrlA);
      /*親コントロールに紐付ける*/
      ctrlP.Controls.Add(ctrlA);
    }
    #endregion

    #region 最小化ボタン作成メソッド
    public void MinButtonCreate(Control ctrlP)
    {
      /*共通設定プロパティ*/
      ctrlName = "MinButton_" + ctrlNum;
      commonAppeaX = 0;
      commonAppeaY = 0;
      commonSizeW = 26;
      commonSizeH = 23;

      //作成コントロールインスタンス生成
      Button ctrlA = new Button();
      //基底コントロール設定メソッド使用
      ctrlA = (Button)ACC_CommonCtrlSetting(ctrlA);

      /*個別設定*/
      //アンカー
      ctrlA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      //色
      ctrlA.BackColor = System.Drawing.SystemColors.Control;
      //フォント
      ctrlA.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      //文字表示位置
      ctrlA.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
      //表示文字
      ctrlA.Text = "_";

      /*親コントロールに紐付ける*/
      ctrlP.Controls.Add(ctrlA);
    }
    #endregion

    #region 最大化ボタン作成メソッド
    public void MaxButtonCreate(Control ctrlP)
    {
      /*共通設定プロパティ*/
      ctrlName = "MaxButton_" + ctrlNum;
      commonAppeaX = 26;
      commonAppeaY = 0;
      commonSizeW = 26;
      commonSizeH = 23;

      //作成コントロールインスタンス生成
      Button ctrlA = new Button();
      //基底コントロール設定メソッド使用
      ctrlA = (Button)ACC_CommonCtrlSetting(ctrlA);

      /*個別設定*/
      //アンカー
      ctrlA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      //色
      ctrlA.BackColor = System.Drawing.SystemColors.Control;
      //フォント
      ctrlA.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      //文字表示位置
      ctrlA.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
      //表示文字
      ctrlA.Text = "□";

      /*親コントロールに紐付ける*/
      ctrlP.Controls.Add(ctrlA);
    }
    #endregion

    #region 閉じるボタン作成メソッド
    public void CloseButtonCreate(Control ctrlP)
    {
      /*共通設定プロパティ*/
      ctrlName = "CloseButton" + ctrlNum;
      commonAppeaX = 52;
      commonAppeaY = 0;
      commonSizeW = 26;
      commonSizeH = 23;

      //作成コントロールインスタンス生成
      Button ctrlA = new Button();
      //基底コントロール設定メソッド使用
      ctrlA = (Button)ACC_CommonCtrlSetting(ctrlA);

      /*個別設定*/
      //アンカー
      ctrlA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      //色
      ctrlA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
      //フォント
      ctrlA.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      //文字表示位置
      ctrlA.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
      //表示文字
      ctrlA.Text = "×";

      /*親コントロールに紐付ける*/
      ctrlP.Controls.Add(ctrlA);
    }
    #endregion


    #region リッチテキストボックス作成メソッド
    public void RichTextBoxCreate(Control ctrlP)
    {
      /*共通設定プロパティ*/
      ctrlName = "RichTextBox_" + ctrlNum;
      commonAppeaX = 3;
      commonAppeaY = 28;
      commonSizeW = ctrlP.Size.Width - 7;
      commonSizeH = ctrlP.Size.Height - 32;

      //作成コントロールインスタンス生成
      RichTextBox ctrlA = new RichTextBox();
      //基底コントロール設定メソッド使用
      ctrlA = (RichTextBox)ACC_CommonCtrlSetting(ctrlA);

      /*個別設定*/
      //アンカー
      ctrlA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));

      /*親コントロールに紐付ける*/
      ctrlP.Controls.Add(ctrlA);
    }
    #endregion


    #region パネルサイズ変更・移動メソッド一覧

    #region 外部dll読み込み
    /*共通定数*/
    const int WM_SYSCOMMAND = 0x0112;
    const int SC_MOVE = 0xF010;
    const int SC_SIZE = 0xF000;

    /*dll読み込み*/
    [DllImport("User32.dll", EntryPoint = "SendMessage")]
    extern static int SendMessageGetTextLength(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
    [DllImport("User32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);
    [DllImport("User32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, int lParam);
    [DllImport("User32.dll")]
    public static extern bool SetCapture(IntPtr hWnd);
    [DllImport("user32.dll")]
    public static extern bool ReleaseCapture();
    #endregion

    #region 基底パネルマウスムーヴイベント(マウスカーソルを両矢印に変更する)
    private void BasePanel_MouseMove(object sender, MouseEventArgs e)
    {
      //パネルの枠にマウスカーソルがきたらサイズ変更カーソルにする

      //イベントを発生させたコントロールを取得
      Control iventControl = (Control)sender;

      //イベントのXYの値によってフラグを変更
      int flag = 0;
      if (e.X < 10)
      {
        flag += 0x0001;
      }
      if (iventControl.Width - 10 < e.X)
      {
        flag += 0x0002;
      }
      if (e.Y < 10)
      {
        flag += 0x0003;
      }
      if (iventControl.Height - 10 < e.Y)
      {
        flag += 0x0006;
      }

      //フラグによってカーソルを変更
      switch (flag)
      {
        case 0:
          iventControl.Cursor = Cursors.Default;
          break;
        case 1:
        case 2:
          iventControl.Cursor = Cursors.SizeWE;
          break;
        case 3:
        case 6:
          iventControl.Cursor = Cursors.SizeNS;
          break;
        case 4:
        case 8:
          iventControl.Cursor = Cursors.SizeNWSE;
          break;
        case 5:
        case 7:
          iventControl.Cursor = Cursors.SizeNESW;
          break;
      }
    }
    #endregion

    #region 基底パネルマウスダウンイベント(パネルサイズ変更)
    private void BasePanel_MouseDown(object sender, MouseEventArgs e)
    {
      //イベントを発生させたコントロールを取得
      Control iventControl = (Control)sender;

      //コントロールを最前面へ
      iventControl.BringToFront();

      SetCapture(iventControl.Handle);
      ReleaseCapture();

      int flag = 0;
      if (e.X < 10)
      {
        flag += 0x0001;
      }
      if (iventControl.Width - 10 < e.X)
      {
        flag += 0x0002;
      }
      if (e.Y < 10)
      {
        flag += 0x0003;
      }
      if (iventControl.Height - 10 < e.Y)
      {
        flag += 0x0006;
      }

      SendMessage(iventControl.Handle, WM_SYSCOMMAND, SC_SIZE | flag, 0);
    }
    #endregion

    #region タイトルパネルマウスダウンイベント(基底パネル移動)
    private void TitlePanel_MouseDown(object sender, MouseEventArgs e)
    {
      ////括り番号の取得メソッド使用
      //string iventControlLumpingNum = GetLumpingNumber(sender);

      //括り番号から対象基底パネルのコントロールを取得
      Control eventCtrl = (Control)sender;
      Control parentCtrl = eventCtrl.Parent;

      //コントロール最前面
      parentCtrl.BringToFront();

      //親のパネルを動かす
      SetCapture(parentCtrl.Handle);
      ReleaseCapture();
      SendMessage(parentCtrl.Handle, WM_SYSCOMMAND, SC_MOVE | 2, 0);
    }
    #endregion

    #region タイトルパネルマウスエンター(マウスカーソルをデフォルトに戻す)
    //private void TitlePanel_MouseEnter(object sender, EventArgs e)
    //{
    //  //イベントを発生させたコントロールを取得
    //  Control iventControl = (Control)sender;

    //  /*カーソルをデフォルトに戻す*/
    //  iventControl.Cursor = Cursors.Default;
    //}
    #endregion

    #region 括り番号の取得メソッド
    public string GetLumpingNumber(object sender)
    {
      //イベントを発生させたコントロールを取得
      Control iventControl = (Control)sender;
      //イベント発生コントロールから子フォーム括り番号を抜き出す
      string iventControlLumpingNum = iventControl.Name.Substring(iventControl.Name.Length - 5, 5);

      //「_」から括り番号を返す
      return iventControlLumpingNum;
    }
    #endregion

    #endregion
  }
}