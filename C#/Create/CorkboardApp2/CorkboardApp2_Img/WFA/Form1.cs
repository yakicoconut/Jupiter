﻿//#define TEST_ReceiveItemShow //【テスト】送るコマンド
//#define TEST_CtrlCreateMain //【テスト】コントロール自動生成実行
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
    }
    #endregion


    #region 宣言

    //コントロール自動作成クラスインスタンス生成
    ACC_CtrlCreateClass ctrlCreateClass = new ACC_CtrlCreateClass();

    //コントロール括り番号(1~9999までを想定、それ以降は未検証)
    int incI_Lumping = 0;

    // 対象拡張子
    string[] targetExtension;

    #endregion


    #region 外部dll読み込み

    #region コントロールサイズ変更・コントロール移動

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
        string LumpingNum = String.Format("{0:0000}", incI_Lumping++);

        //基底パネルの作成
        Panel panelA = ctrlCreateClass.CtrlCreateMain(LumpingNum, x);

        //作成したパネルをフォームに追加
        this.Controls.Add(panelA);
      }
    }
    #endregion


    #region 閉じるボタン機能メソッド
    public void CloseButtonFunc(Control eventCtrl)
    {
      //括り番号の取得
      string lumpingNum = eventCtrl.Name.Substring(eventCtrl.Name.Length - 4, 4);

      //対象基底パネルのコントロールを取得
      Control targetBasePanel = this.Controls["BasePanel_" + lumpingNum];
      //対象テキストボックスを取得
      Control targetTextBox = targetBasePanel.Controls["RichTextBox_" + lumpingNum];
      //対象タイトルパネルを取得
      Control targetTitlePanel = targetBasePanel.Controls["TitlePanel_" + lumpingNum];

      //タイトルパネルから対象タイトルパスラベルを取得
      Control targetTitlePathLabel = targetTitlePanel.Controls["TitlePathLabel_" + lumpingNum];
      //タイトルパネルから対象タイトルファイル名ラベルを取得
      Control targetTitleFileNameLabel = targetTitlePanel.Controls["TitleFileNameLabel_" + lumpingNum];

      //対象タイトルパスラベルからパスを取得
      string targetFilePath = targetTitlePathLabel.Text;
      //対象タイトルファイル名ラベルからファイル名を取得
      string targetFileName = targetTitlePathLabel.Text;

      //基底パネル削除メソッド使用
      CloseBasePanel(targetBasePanel);
    }
    #endregion

    #region 基底パネルを閉じるメソッド
    public void CloseBasePanel(Control targetCtrl)
    {
      //イベントを発生させたコントロールを閉じる
      this.Controls.Remove(targetCtrl);
    }
    #endregion


    #region 親コントロール最前面化メソッド
    public void CtrlBringToFront(Control eventCtrl)
    {
      //括り番号から対象基底パネルのコントロールを取得
      Control parentCtrl = this.Controls["basePanel_" + eventCtrl.Name.Substring(eventCtrl.Name.Length - 4, 4)];

      //コントロール最前面
      parentCtrl.BringToFront();
    }
    #endregion

    #region 基底パネルサイズ変更メソッド一覧

    #region マウスカーソル両矢印変更メソッド
    public void CursorChangeTwiceArrow(Control eventCtrl, int mouseX, int mouseY)
    {
      //パネルの枠にマウスカーソルがきたらサイズ変更カーソルにする

      //イベントのXYの値によってフラグを変更
      int flag = 0;
      if (mouseX < 10)
      {
        flag += 0x0001;
      }
      if (eventCtrl.Width - 10 < mouseX)
      {
        flag += 0x0002;
      }
      if (mouseY < 10)
      {
        flag += 0x0003;
      }
      if (eventCtrl.Height - 10 < mouseY)
      {
        flag += 0x0006;
      }

      //フラグによってカーソルを変更
      switch (flag)
      {
        case 0:
          eventCtrl.Cursor = Cursors.Default;
          break;
        case 1:
        case 2:
          eventCtrl.Cursor = Cursors.SizeWE;
          break;
        case 3:
        case 6:
          eventCtrl.Cursor = Cursors.SizeNS;
          break;
        case 4:
        case 8:
          eventCtrl.Cursor = Cursors.SizeNWSE;
          break;
        case 5:
        case 7:
          eventCtrl.Cursor = Cursors.SizeNESW;
          break;
      }
    }
    #endregion

    #region 基底パネルサイズ変更メソッド
    public void BasePanelChangeSize(Control eventCtrl, int mouseX, int mouseY)
    {
      //コントロールを最前面へ
      eventCtrl.BringToFront();

      SetCapture(eventCtrl.Handle);
      ReleaseCapture();

      int flag = 0;
      if (mouseX < 10)
      {
        flag += 0x0001;
      }
      if (eventCtrl.Width - 10 < mouseX)
      {
        flag += 0x0002;
      }
      if (mouseY < 10)
      {
        flag += 0x0003;
      }
      if (eventCtrl.Height - 10 < mouseY)
      {
        flag += 0x0006;
      }

      //引数1:対象コントロールのハンドル番号
      //引数2:
      //引数3:
      //引数4:
      SendMessage(eventCtrl.Handle, WM_SYSCOMMAND, SC_SIZE | flag, 0);
    }
    #endregion

    #endregion

    #region 基底パネル移動メソッド一覧

    #region マウスカーソルデフォルト変更メソッド
    public void CursorChangeDefault(Control eventCtrl)
    {
      //カーソルをデフォルトに戻す
      eventCtrl.Cursor = Cursors.Default;
    }
    #endregion

    #region 基底パネル移動メソッド
    public void MoveBasePanel(Control eventCtrl)
    {
      //括り番号から対象基底パネルのコントロールを取得
      Control parentCtrl = this.Controls["basePanel_" + eventCtrl.Name.Substring(eventCtrl.Name.Length - 4, 4)];

      //コントロールを最前面へ
      parentCtrl.BringToFront();

      //親のパネルを動かす
      SetCapture(parentCtrl.Handle);
      ReleaseCapture();
      SendMessage(parentCtrl.Handle, WM_SYSCOMMAND, SC_MOVE | 2, 0);
    }
    #endregion

    #endregion

    #region 画像拡大・移動メソッド一覧

    #region 宣言

    //表示するBitmap  
    private Bitmap bmp = null;
    //描画用Graphicsオブジェクト  
    private Graphics g = null;
    //マウスダウンフラグ  
    public bool mouseDownFlg { get; set; }
    //マウスをクリックした位置の保持用  
    private PointF oldPoint;
    //アフィン変換行列  
    private System.Drawing.Drawing2D.Matrix mat;

    #endregion

    #region ピクチャボックスマウスダウンメソッド
    public void MouseDownPictureBox(Control eventCtrl, int mouseX, int mouseY)
    {
      //フォーカスの設定  
      //（クリックしただけではMouseWheelイベントが有効にならない）  
      eventCtrl.Focus();
      //マウスをクリックした位置の記録  
      oldPoint.X = mouseX;
      oldPoint.Y = mouseY;
      //マウスダウンフラグ  
      mouseDownFlg = true;
    }
    #endregion

    #region ピクチャボックスマウスムーブメソッド
    public void MouseMovePictureBox(Control eventCtrl, int mouseX, int mouseY)
    {
      //マウスをクリックしながら移動中のとき  
      if (mouseDownFlg == true)
      {
        //画像の移動  
        mat.Translate(mouseX - oldPoint.X, mouseY - oldPoint.Y,
            System.Drawing.Drawing2D.MatrixOrder.Append);
        //画像の描画  
        DrawImage((PictureBox)eventCtrl);

        //ポインタ位置の保持  
        oldPoint.X = mouseX;
        oldPoint.Y = mouseY;
      }
    }
    #endregion

    #region マウスホイール動作メソッド
    public void MouseWheelPictureBox(Control eventCtrl, MouseEventArgs e)
    {
      //ポインタの位置→原点へ移動  
      mat.Translate(-e.X, -e.Y,
          System.Drawing.Drawing2D.MatrixOrder.Append);
      if (e.Delta > 0)
      {
        //拡大  
        if (mat.Elements[0] < 100)  //X方向の倍率を代表してチェック  
        {
          mat.Scale(1.5f, 1.5f,
              System.Drawing.Drawing2D.MatrixOrder.Append);
        }
      }
      else
      {
        //縮小  
        if (mat.Elements[0] > 0.01)  //X方向の倍率を代表してチェック  
        {
          mat.Scale(1.0f / 1.5f, 1.0f / 1.5f,
              System.Drawing.Drawing2D.MatrixOrder.Append);
        }
      }
      //原点→ポインタの位置へ移動(元の位置へ戻す)  
      mat.Translate(e.X, e.Y,
          System.Drawing.Drawing2D.MatrixOrder.Append);
      //画像の描画  
      DrawImage((PictureBox)eventCtrl);
    }
    #endregion

    #region ビットマップの描画メソッド
    private void DrawImage(PictureBox eventCtrl)
    {
      if (bmp == null) return;

      //アフィン変換行列の設定  
      if ((mat != null))
      {
        g.Transform = mat;
      }
      //ピクチャボックスのクリア  
      g.Clear(eventCtrl.BackColor);
      //描画  
      g.DrawImage(bmp, 0, 0);
      //再描画  
      eventCtrl.Refresh();
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
    //対象イメージ
    public Image targetImage { get; set; }
    //デフォルトエンコード
    public string defaultOpenEncode { get; set; }


    //基底パネル出現位置
    public int basePanelAppeaX { get; set; }
    public int basePanelAppeaY { get; set; }
    //基底パネル二個目以降の出現位置調整
    public int basePanelAddX { get; set; }
    public int basePanelAddY { get; set; }
    //基底パネルサイズ
    public int basePanelSizeW { get; set; }
    public int basePanelSizeH { get; set; }


    //共通出現位置
    public int commonAppeaX { get; set; }
    public int commonAppeaY { get; set; }
    //共通サイズ
    public int commonSizeW { get; set; }
    public int commonSizeH { get; set; }

    #endregion

    #region プロパティ初期値設定メソッド
    void PropDefault()
    {
      //デフォルトエンコード
      defaultOpenEncode = ConfigurationManager.AppSettings["DefaultOpenEncode"];


      //基底パネル出現位置
      basePanelAppeaX = 0;
      basePanelAppeaY = 0;
      //基底パネルサイズ
      basePanelSizeW = int.Parse(ConfigurationManager.AppSettings["DefaultSizeWidth"]);
      basePanelSizeH = int.Parse(ConfigurationManager.AppSettings["DefaultSizeHeight"]);
      //基底パネル二個目以降の出現位置調整
      //basePanelAddX = basePanelSizeW + 1;
      basePanelAddX = 10;
      basePanelAddY = 0;


      //共通出現位置
      commonAppeaX = 0;
      commonAppeaY = 0;
      //共通サイズ
      commonSizeW = 98;
      commonSizeH = 98;
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
  /// コントロール自動生成クラス
  /// </summary>
  class ACC_CtrlCreateClass : ACC_BaseCreateClass
  {
    #region 宣言

    //フォーム1のプロパティ
    public Form1 form1;

    #endregion


    #region コントロール自動作成メインメソッド
    public Panel CtrlCreateMain(string argCtrlNum, string filePath)
    {
      //共通プロパティに値を設定
      ctrlNum = argCtrlNum;
      titleFullPath = filePath;
      //テキスト内容を取得
      targetImage = System.Drawing.Image.FromFile(filePath);

      //基底パネル作成メソッド使用
      Panel basePanelA = BasePanelCreate();

      return basePanelA;
    }
    #endregion


    #region 各コントロール作成メソッド一覧

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
      PictureBoxCreate(ctrlA);

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
      commonSizeW = ctrlP.Size.Width - 6;
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
      ctrlA.MouseEnter += new System.EventHandler(Ctrl_MouseEnter);
    }
    #endregion

    #region タイトルパスラベル作成メソッド
    public void TitlePathLabelCreate(Control ctrlP)
    {
      /*共通設定プロパティ*/
      ctrlName = "TitlePathLabel_" + ctrlNum;
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
      ctrlA.MouseEnter += new System.EventHandler(Ctrl_MouseEnter);
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

      /*イベントの追加*/
      ctrlA.MouseDown += new System.Windows.Forms.MouseEventHandler(TitlePanel_MouseDown);
      ctrlA.MouseEnter += new System.EventHandler(Ctrl_MouseEnter);
    }
    #endregion

    #region ボタンパネル作成メソッド
    public void ButtonPanelCreate(Control ctrlP)
    {
      /*共通設定プロパティ*/
      ctrlName = "ButtonPanel_" + ctrlNum;
      commonAppeaX = ctrlP.Size.Width - 80;
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

      /*イベントの追加*/
      ctrlA.MouseUp += new System.Windows.Forms.MouseEventHandler(CloseButton_MouseUp);
    }
    #endregion

    #region ピクチャボックス作成メソッド
    public void PictureBoxCreate(Control ctrlP)
    {
      /*共通設定プロパティ*/
      ctrlName = "PictureBox_" + ctrlNum;
      commonAppeaX = 3;
      commonAppeaY = 28;
      commonSizeW = ctrlP.Size.Width - 7;
      commonSizeH = ctrlP.Size.Height - 32;

      //作成コントロールインスタンス生成
      PictureBox ctrlA = new PictureBox();
      //基底コントロール設定メソッド使用
      ctrlA = (PictureBox)ACC_CommonCtrlSetting(ctrlA);

      /*個別設定*/
      //アンカー
      ctrlA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
      ctrlA.Image = targetImage;

      /*親コントロールに紐付ける*/
      ctrlP.Controls.Add(ctrlA);

      /*イベントの追加*/
      ctrlA.MouseDown += new System.Windows.Forms.MouseEventHandler(PictureBox_MouseDown);
      ctrlA.MouseMove += new System.Windows.Forms.MouseEventHandler(PictureBox_MouseMove);
      ctrlA.MouseUp += new System.Windows.Forms.MouseEventHandler(PictureBox_MouseUp);
      ctrlA.MouseWheel += new System.Windows.Forms.MouseEventHandler(PictureBox_MouseWheel);
      ctrlA.MouseEnter += new System.EventHandler(Ctrl_MouseEnter);
    }
    #endregion

    #endregion


    #region イベント一覧

    #region コントロールクリックイベント
    private void Ctrl_MouseUp(object sender, MouseEventArgs e)
    {
      //フォーム1クラス閉じるボタン機能メソッド使用
      form1.CtrlBringToFront(((Control)sender));
    }
    #endregion

    #region コントロールマウスエンター(マウスカーソルをデフォルトに戻す)
    private void Ctrl_MouseEnter(object sender, EventArgs e)
    {
      //フォーム1クラスマウスカーソルデフォルト変更メソッド使用
      form1.CursorChangeDefault((Control)sender);
    }
    #endregion

    #region ボタンイベント一覧

    #region 閉じるボタン押上イベント
    private void CloseButton_MouseUp(object sender, MouseEventArgs e)
    {
      //フォーム1クラス閉じるボタン機能メソッド使用
      form1.CloseButtonFunc(((Control)sender));
    }
    #endregion

    #endregion

    #region パネルサイズ変更イベント一覧

    #region 基底パネルマウスムーヴイベント(マウスカーソルを両矢印に変更する)
    private void BasePanel_MouseMove(object sender, MouseEventArgs e)
    {
      //フォーム1クラスマウスカーソル両矢印変更メソッド使用
      form1.CursorChangeTwiceArrow((Control)sender, e.X, e.Y);
    }
    #endregion

    #region 基底パネルマウスダウンイベント(パネルサイズ変更)
    private void BasePanel_MouseDown(object sender, MouseEventArgs e)
    {
      //フォーム1クラス基底パネルサイズ変更メソッド使用
      form1.BasePanelChangeSize((Control)sender, e.X, e.Y);
    }
    #endregion

    #endregion


    #region タイトルパネルマウスダウンイベント(基底パネル移動)
    private void TitlePanel_MouseDown(object sender, MouseEventArgs e)
    {
      //フォーム1クラス基底パネル移動メソッド使用
      form1.MoveBasePanel((Control)sender);
    }
    #endregion


    #region 画像拡大・移動イベント

    #region ピクチャボックスマウスダウンイベント
    private void PictureBox_MouseDown(object sender, MouseEventArgs e)
    {
      //フォーム1クラスピクチャボックスマウスダウンメソッド使用
      form1.MouseDownPictureBox((Control)sender, e.X, e.Y);
    }
    #endregion

    #region ピクチャボックスマウスムーブイベント
    private void PictureBox_MouseMove(object sender, MouseEventArgs e)
    {
      //フォーム1クラスピクチャボックスマウスムーブメソッド使用
      form1.MouseMovePictureBox((Control)sender, e.X, e.Y);
    }
    #endregion

    #region ピクチャボックスマウスアップイベント
    private void PictureBox_MouseUp(object sender, MouseEventArgs e)
    {
      //フォーム1クラスマウスダウンフラグを設定
      form1.mouseDownFlg = false;
    }
    #endregion

    #region マウスホイールイベント
    private void PictureBox_MouseWheel(object sender, MouseEventArgs e)
    {
      //フォーム1クラスマウスホイール動作メソッド使用
      form1.MouseWheelPictureBox((Control)sender, e);
    }
    #endregion

    #endregion

    #endregion
  }
}