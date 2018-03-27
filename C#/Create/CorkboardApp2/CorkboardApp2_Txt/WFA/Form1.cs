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

      //他クラスのプロパティに本クラスを設定
      ctrlCreateClass.form1 = this;
      form2.form1 = this;
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
    //フォーム2インスタンス生成
    Form2 form2 = new Form2();

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

    #region コントロール自動生成呼び出しメソッド
    public void CallACC(string[] args)
    {
      //デフォルト基底パネル出現位置のリセット
      ctrlCreateClass.basePanelAppeaX = 0;
      ctrlCreateClass.basePanelAppeaY = 0;

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

        //フォーム2のリストビューに作成したファイル名を追加
        form2.lvItem = form2.lvCtrl.Items.Add(System.IO.Path.GetFileName(x));
        //サブアイテムにパネル名を追加
        form2.lvItem.SubItems.Add(panelA.Name);

        //最前に表示
        panelA.BringToFront();
      }
    }
    #endregion


    #region フォームロードイベント
    private void Form1_Load(object sender, EventArgs e)
    {

    }
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

      //引数が渡されなくても本アプリ自身のパスを配列に格納するので対象は2以上
      if (args.Length > 1)
      {
        //コントロール自動生成呼び出しメソッド使用
        CallACC(args);
      }

      //常にメインフォームの手前に表示
      form2.Owner = this;
      //フォーム2呼び出し
      form2.Show();
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

    #region 機能ボタンイベント一覧

    #region 最小化ボタン押上イベント

    public void MinButton_MouseUp(object sender, MouseEventArgs e)
    {
      Control eventCtrl = (Control)sender;
      //括り番号の取得
      string lumpingNum = eventCtrl.Name.Substring(eventCtrl.Name.Length - 4, 4);
      //対象基底パネルのコントロールを取得
      Control targetBasePanel = this.Controls["BasePanel_" + lumpingNum];

      //非表示にする
      targetBasePanel.Visible = false;
    }
    #endregion

    #region 最大化ボタン押上イベント

    #region 宣言

    //退避用
    int beforeMaxW;
    int beforeMaxH;
    int beforeMaxX;
    int beforeMaxY;

    #endregion

    public void MaxButton_MouseUp(object sender, MouseEventArgs e)
    {
      Control eventCtrl = (Control)sender;
      //括り番号の取得
      string lumpingNum = eventCtrl.Name.Substring(eventCtrl.Name.Length - 4, 4);
      //対象基底パネルのコントロールを取得
      Control targetBasePanel = this.Controls["BasePanel_" + lumpingNum];

      //フォーム全体を指定
      Size sz = this.Size;

      //既に最大化している場合
      if (targetBasePanel.Location == new Point(0, 0) && targetBasePanel.Width == sz.Width - 16 && targetBasePanel.Height == sz.Height - 37)
      {
        //サイズと位置を元に戻す
        targetBasePanel.Width = beforeMaxW;
        targetBasePanel.Height = beforeMaxH;
        targetBasePanel.Location = new Point(beforeMaxX, beforeMaxY);

        return;
      }

      //現在の大きさと位置を退避
      beforeMaxW = targetBasePanel.Width;
      beforeMaxH = targetBasePanel.Height;
      beforeMaxX = targetBasePanel.Location.X;
      beforeMaxY = targetBasePanel.Location.Y;

      //位置を左上へ
      targetBasePanel.Location = new Point(0, 0);
      //サイズの変更
      targetBasePanel.Width = sz.Width - 16;
      targetBasePanel.Height = sz.Height - 37;

      //コントロールを最前面へ
      targetBasePanel.BringToFront();
    }
    #endregion

    #region 閉じるボタン押上イベント
    public void CloseButton_MouseUp(object sender, MouseEventArgs e)
    {
      Control eventCtrl = (Control)sender;

      //括り番号の取得
      string lumpingNum = eventCtrl.Name.Substring(eventCtrl.Name.Length - 4, 4);

      //対象基底パネルのコントロールを取得
      Control targetBasePanel = this.Controls["BasePanel_" + lumpingNum];

      //上書き確認メソッド使用
      if (!ConfirmationOverwrite(targetBasePanel, lumpingNum))
        //キャンセルの場合
        return;

      //基底パネル削除メソッド使用
      CloseBasePanel(targetBasePanel);
    }
    #endregion

    #endregion


    #region 基底パネルを閉じるメソッド
    public void CloseBasePanel(Control targetCtrl)
    {
      //イベントを発生させたコントロールを閉じる
      this.Controls.Remove(targetCtrl);

      //管理フォームの該当パネルを削除
      form2.lvCtrl.FindItemWithText(targetCtrl.Name, true, 0, true).Remove();
    }
    #endregion

    #region 親コントロール最前面化メソッド
    public void CtrlBringToFront(object sender, EventArgs e)
    {
      Control eventCtrl = (Control)sender;

      //括り番号から対象基底パネルのコントロールを取得
      Control parentCtrl = this.Controls["BasePanel_" + eventCtrl.Name.Substring(eventCtrl.Name.Length - 4, 4)];

      //コントロール最前面
      parentCtrl.BringToFront();
    }
    #endregion

    #region 基底パネルサイズ変更メソッド一覧

    #region マウスカーソル両矢印変更メソッド
    public void CursorChangeTwiceArrow(object sender, MouseEventArgs e)
    {
      Control eventCtrl = (Control)sender;

      //パネルの枠にマウスカーソルがきたらサイズ変更カーソルにする

      //イベントのXYの値によってフラグを変更
      int flag = 0;
      if (e.X < 10)
      {
        flag += 0x0001;
      }
      if (eventCtrl.Width - 10 < e.X)
      {
        flag += 0x0002;
      }
      if (e.Y < 10)
      {
        flag += 0x0003;
      }
      if (eventCtrl.Height - 10 < e.Y)
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
    public void BasePanelChangeSize(object sender, MouseEventArgs e)
    {
      Control eventCtrl = (Control)sender;

      //コントロールを最前面へ
      eventCtrl.BringToFront();

      SetCapture(eventCtrl.Handle);
      ReleaseCapture();

      int flag = 0;
      if (e.X < 10)
      {
        flag += 0x0001;
      }
      if (eventCtrl.Width - 10 < e.X)
      {
        flag += 0x0002;
      }
      if (e.Y < 10)
      {
        flag += 0x0003;
      }
      if (eventCtrl.Height - 10 < e.Y)
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
    public void CursorChangeDefault(object sender, EventArgs e)
    {
      //カーソルをデフォルトに戻す
      ((Control)sender).Cursor = Cursors.Default;
    }
    #endregion

    #region 基底パネル移動メソッド
    public void MoveBasePanel(object sender, MouseEventArgs e)
    {
      Control eventCtrl = (Control)sender;

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

    #endregion

    #region 上書き確認メソッド
    public bool ConfirmationOverwrite(Control targetBasePanel, string lumpingNum)
    {
      //対象テキストボックスを取得
      Control targetTextBox = targetBasePanel.Controls["RichTextBox_" + lumpingNum];
      //対象タイトルパネルを取得
      Control targetTitlePanel = targetBasePanel.Controls["TitlePanel_" + lumpingNum];

      //タイトルパネルから対象タイトルパスラベルを取得
      Control targetTitlePathLabel = targetTitlePanel.Controls["TitlePathLabel_" + lumpingNum];
      //タイトルパネルから対象タイトルファイル名ラベルを取得
      Control targetTitleFileNameLabel = targetTitlePanel.Controls["TitleFileNameLabel_" + lumpingNum];

      //対象テキストボックスからファイル内容を取得
      string targetFileText = targetTextBox.Text;
      //対象タイトルパスラベルからパスを取得
      string targetFilePath = targetTitlePathLabel.Text;
      //対象タイトルファイル名ラベルからファイル名を取得
      string targetFileName = targetTitlePathLabel.Text;

      //確認メッセージボックスを表示する
      DialogResult result = MessageBox.Show(targetFilePath + "\r\n" + targetFileName + "\r\nを上書きしてパネルを閉じますか?",
                      "上書き",
                      MessageBoxButtons.YesNoCancel,
                      MessageBoxIcon.Question,
                      MessageBoxDefaultButton.Button1);
      //[はい]押下
      if (result == DialogResult.Yes)
      {
        /*テキストファイルコミット*/
        //上書き
        System.IO.StreamWriter sw = new System.IO.StreamWriter(
            targetFileName,
            false,
            System.Text.Encoding.GetEncoding(ctrlCreateClass.defaultOpenEncode));
        //対象コントロールの内容を書き込む
        sw.Write(targetFileText);
        sw.Close();
      }
      //[いいえ]押下
      else if (result == DialogResult.No)
      {
        //[はい][いいえ]はどちらも最終的に下で基底パネルを削除する
      }
      //[キャンセル]押下
      else if (result == DialogResult.Cancel)
      {
        return false;
      }

      return true;
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
    public string ctrlNum { get; set; }
    //タイトル
    public string titleFullPath { get; set; }
    //テキスト内容
    public string textValue { get; set; }
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


      //デフォルト基底パネル出現位置
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
      textValue = File.ReadAllText(filePath, Encoding.GetEncoding(defaultOpenEncode));

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
      RichTextBoxCreate(ctrlA);

      /*イベントの追加*/
      ctrlA.MouseMove += new System.Windows.Forms.MouseEventHandler(form1.CursorChangeTwiceArrow);
      ctrlA.MouseDown += new System.Windows.Forms.MouseEventHandler(form1.BasePanelChangeSize);

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
      ctrlA.MouseDown += new System.Windows.Forms.MouseEventHandler(form1.MoveBasePanel);
      ctrlA.MouseEnter += new System.EventHandler(form1.CursorChangeDefault);
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
      ctrlA.MouseDown += new System.Windows.Forms.MouseEventHandler(form1.MoveBasePanel);
      ctrlA.MouseEnter += new System.EventHandler(form1.CursorChangeDefault);
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
      commonSizeH = 14;

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
      ctrlA.MouseDown += new System.Windows.Forms.MouseEventHandler(form1.MoveBasePanel);
      ctrlA.MouseEnter += new System.EventHandler(form1.CursorChangeDefault);
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

      /*イベントの追加*/
      ctrlA.MouseUp += new System.Windows.Forms.MouseEventHandler(form1.MinButton_MouseUp);
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

      /*イベントの追加*/
      ctrlA.MouseUp += new System.Windows.Forms.MouseEventHandler(form1.MaxButton_MouseUp);
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
      ctrlA.MouseUp += new System.Windows.Forms.MouseEventHandler(form1.CloseButton_MouseUp);
    }
    #endregion

    #region リッチテキストボックス作成メソッド
    public void RichTextBoxCreate(Control ctrlP)
    {
      /*共通設定プロパティ*/
      ctrlName = "RichTextBox_" + ctrlNum;
      commonAppeaX = 3;
      commonAppeaY = 32;
      commonSizeW = ctrlP.Size.Width - 7;
      commonSizeH = ctrlP.Size.Height - 35;

      //作成コントロールインスタンス生成
      RichTextBox ctrlA = new RichTextBox();
      //基底コントロール設定メソッド使用
      ctrlA = (RichTextBox)ACC_CommonCtrlSetting(ctrlA);

      /*個別設定*/
      //アンカー
      ctrlA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
      ctrlA.Text = textValue;

      /*親コントロールに紐付ける*/
      ctrlP.Controls.Add(ctrlA);

      /*イベントの追加*/
      ctrlA.MouseUp += new System.Windows.Forms.MouseEventHandler(form1.CtrlBringToFront);
    }
    #endregion

    #endregion


    #region イベント一覧

    #endregion
  }
}