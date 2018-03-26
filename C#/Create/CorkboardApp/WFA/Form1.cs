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
using System.Runtime.InteropServices;
using System.Collections;
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

      //デフォルトエンコードの表示
      lbDefaultOpenEncode.Text = defaultOpenEncode;
    }
    #endregion

    #region コンフィグ取得メソッド
    public void GetConfig()
    {
      string hoge01 = ConfigurationManager.AppSettings["Hoge01"];
    }
    #endregion


    #region 共通変数

    /*コンフィグ*/
    //対象拡張子
    string[] targetExtension = ConfigurationManager.AppSettings["TargetExtension"].Split(',');
    //デフォルトエンコード
    string defaultOpenEncode = ConfigurationManager.AppSettings["DefaultOpenEncode"];

    #endregion


    #region ボタン1押下イベント
    private void button1_Click(object sender, EventArgs e)
    {

    }
    #endregion

    #region ボタン2押下イベント
    private void button2_Click(object sender, EventArgs e)
    {

    }
    #endregion

    #region ファイル読み込み関連イベント一覧

    #region フォームショウイベント(送るで渡されるファイルを開く)
    private void Form1_Shown(object sender, EventArgs e)
    {
      //送るで渡されるコマンドライン引数を配列で取得
      string[] args = Environment.GetCommandLineArgs();
      #region とりあえず表示
      //int i = 0;
      //foreach (string x in args)
      //{
      //  i = ++i;
      //  MessageBox.Show(i.ToString() + "/" + args.Length.ToString() + "\r\n" + x);
      //}
      #endregion

      //ねずみ返し
      //引数が渡されなくても本アプリ自身のパスを配列に格納するので総数が1つの場合は終了
      if (args.Length == 1)
      {
        return;
      }

      //コントロール自動作成作成メソッド使用
      ControlAutoCreate(args);
      #region テスト
      //int[] numbers = { 1, 2, 3 };
      //foreach (int j in numbers)
      //{
      //  /*コントロール自動作成*/
      //  //各種タイトルバーボタンは返値(文字列)を子の配列に格納
      //  autoControlTitlePanelName.Add(MinButtonCreate(j.ToString()));
      //  autoControlTitlePanelName.Add(MaxButtonCreate(j.ToString()));
      //  autoControlTitlePanelName.Add(CloseButtonCreate(j.ToString()));

      //  //親パネルの要素は返値(文字列)を親の配列に格納
      //  autoControlBasePanelName.Add(TitlePanelCreate(j.ToString()));
      //  //処理中のパスからテキストファイルの中身をテキストボックスに表示
      //  autoControlBasePanelName.Add(TextBoxCreate(j.ToString(), File.ReadAllText(x, Encoding.GetEncoding("shift_jis"))));

      //  //親パネルの作成
      //  BasePanelCreate(i.ToString());
      //}
      #endregion
    }
    #endregion

    #region マウスインされるファイルを開くイベント

    #region フォームドラッグエンターイベント
    private void Form1_DragEnter(object sender, DragEventArgs e)
    {
      //マウスがファイルを持っている場合
      if (e.Data.GetDataPresent(DataFormats.FileDrop))
      {
        //ドラッグ中のファイルの取得
        string[] drags = (string[])e.Data.GetData(DataFormats.FileDrop);

        foreach (string d in drags)
        {
          //ねずみ返し_ファイル以外であればイベント・ハンドラを抜ける
          if (!System.IO.File.Exists(d))
          {
            return;
          }
        }

        //マウスの表示を「+」に変更する
        e.Effect = DragDropEffects.Copy;
      }
    }
    #endregion

    #region フォームドラッグドロップイベント
    private void Form1_DragDrop(object sender, DragEventArgs e)
    {
      //ドラッグ&ドロップされたファイルの取得
      string[] args = (string[])e.Data.GetData(DataFormats.FileDrop);

      //コントロール自動作成作成メソッド使用
      ControlAutoCreate(args);
    }
    #endregion

    #endregion

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
      //括り番号の取得メソッド使用
      string iventControlLumpingNum = GetLumpingNumber(sender);

      //括り番号から対象基底パネルのコントロールを取得
      Control iventControl = Controls["basePanel" + iventControlLumpingNum];

      //コントロール最前面
      iventControl.BringToFront();

      //親のパネルを動かす
      SetCapture(iventControl.Handle);
      ReleaseCapture();
      SendMessage(iventControl.Handle, WM_SYSCOMMAND, SC_MOVE | 2, 0);
    }
    #endregion

    #region タイトルパネルマウスエンター(マウスカーソルをデフォルトに戻す)
    private void TitlePanel_MouseEnter(object sender, EventArgs e)
    {
      //イベントを発生させたコントロールを取得
      Control iventControl = (Control)sender;

      /*カーソルをデフォルトに戻す*/
      iventControl.Cursor = Cursors.Default;
    }
    #endregion

    #endregion


    #region 基底パネルボタンイベント一覧

    #region 閉じるボタン押下イベント
    private void CloseButton_MouseUp(object sender, MouseEventArgs e)
    {
      //括り番号の取得メソッド使用
      string iventControlLumpingNum = GetLumpingNumber(sender);

      //括り番号から対象基底パネルのコントロールを取得
      Control targetBasePanel = Controls["basePanel" + iventControlLumpingNum];
      //括り番号と対象基底パネルから対象テキストボックスを取得
      Control targetTextBox = targetBasePanel.Controls["textBox" + iventControlLumpingNum];
      //括り番号と対象基底パネルから対象タイトルパネルを取得
      Control targetTitlePanel = targetBasePanel.Controls["titlePanel" + iventControlLumpingNum];
      //括り番号と対象タイトルパネルから対象ファイル名ラベルを取得
      Control targetFileNameLabel = targetTitlePanel.Controls["fileNameLabel" + iventControlLumpingNum];

      #region テスト
      //基底パネル名の表示
      MessageBox.Show(targetBasePanel.Name);
      #endregion

      //対象テキストボックスからファイル内容を取得
      string targetFileText = targetTextBox.Text;
      //対象ファイル名ラベルからファイル名(パス)を取得
      string targetFileName = targetFileNameLabel.Text;

      //確認メッセージボックスを表示する
      DialogResult result = MessageBox.Show(targetFileName + "\r\nを上書きしてパネルを閉じますか?",
                      "上書き",
                      MessageBoxButtons.YesNoCancel,
                      MessageBoxIcon.Question,
                      MessageBoxDefaultButton.Button1);
      //[はい]押下
      if (result == DialogResult.Yes)
      {
        /*テキストファイルコミット*/
        //Shift JISで書き込む
        //上書き
        System.IO.StreamWriter sw = new System.IO.StreamWriter(
            targetFileName,
            false,
            System.Text.Encoding.GetEncoding(defaultOpenEncode));
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
        return;
      }

      //基底パネル削除メソッド使用
      CloseBasePanel(targetBasePanel);
    }
    #endregion

    #endregion

    #region 基底パネル内コントロール共通イベント
    private void BasePanelChildrenControl_MouseDown(object sender, EventArgs e)
    {
      //イベントを発生させたコントロールを取得
      Control iventControl = (Control)sender;

      //コントロールを最前面へ
      iventControl.Parent.BringToFront();
    }
    #endregion

    #region メインメソッド一覧

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

    #region 基底パネル閉じるメソッド
    public void CloseBasePanel(Control sender)
    {
      //イベントを発生させたコントロールを閉じる
      this.Controls.Remove(sender);

    }
    #endregion

    #endregion


    #region コントロール自動生成メソッド一覧

    #region **共通引数**


    //基底パネルのサイズ(各コントロールの元となる値)
    int basePanelBaseSizeX = 300;
    int basePanelBaseSizeY = 200;

    #endregion

    #region 共通変数

    //基底パネルに追加するコントロール名を格納する配列
    ArrayList autoControlBasePanelName = new ArrayList();
    //タイトルパネルに追加するコントロール名を格納する配列
    ArrayList autoControlTitlePanelName = new ArrayList();
    //コントロール括り番号(1~9999までを想定、それ以降は未検証)
    int IncrementI_Lumping = 0;

    #endregion

    #region コントロール自動作成メソッド
    public void ControlAutoCreate(string[] args)
    {
      //全ての引数を処理
      foreach (string x in args)
      {
        //拡張子が設定したもののときだけコントロールを作成
        if (Array.IndexOf(targetExtension, Path.GetExtension(x).ToLower()) > -1)
        {
          //コントロール括り番号のインクリメント
          IncrementI_Lumping = ++IncrementI_Lumping;
          //括り番号の作成
          string LumpingNum = "_" + String.Format("{0:0000}", IncrementI_Lumping);

          /*コントロール自動作成*/
          //子パネル(タイトルバー)の配列に格納
          //各種タイトルバーボタン
          autoControlTitlePanelName.Add(MinButtonCreate(LumpingNum));
          autoControlTitlePanelName.Add(MaxButtonCreate(LumpingNum));
          autoControlTitlePanelName.Add(CloseButtonCreate(LumpingNum));
          //ファイル名
          autoControlTitlePanelName.Add(FileNameLabel(LumpingNum, x));

          //親パネル(基底パネル)の配列に格納
          //タイトルバー
          autoControlBasePanelName.Add(TitlePanelCreate(LumpingNum));
          //テキストボックス
          autoControlBasePanelName.Add(TextBoxCreate(LumpingNum, File.ReadAllText(x, Encoding.GetEncoding(defaultOpenEncode))));

          //親パネルの作成
          BasePanelCreate(LumpingNum);
        }
      }
    }
    #endregion

    #region 作成コントロール一覧

    #region 基底パネル
    /*基底パネルクリエイトメソッド用フィールド宣言*/
    private int basePanelPointX = 0; //基底パネルクリエイト出現位置調整Xフィールド
    private int basePanelPointY = 0; //基底パネルクリエイト出現位置調整Yフィールド

    #region 基底パネルクリエイトメソッド
    public void BasePanelCreate(string nameNum)
    {
      //Panelクラスのインスタンスを作成する
      Panel basePanelA = new Panel();

      /*設定値*/
      //一個目の出現位置
      int basePanelFirstPointX = 0;
      int basePanelFirstPointY = 0;
      //二個目以降の出現位置
      int addPointX = basePanelBaseSizeX + 1; //基底パネルのサイズから算出
      int addPointY = 0;
      //サイズ
      int basePanelSizeWidth = basePanelBaseSizeX;
      int basePanelSizeHeight = basePanelBaseSizeY;

      /*プロパティ設定*/
      basePanelA.Name = "basePanel" + nameNum;
      //サイズと位置を設定する
      basePanelA.Location = new Point(basePanelFirstPointX + basePanelPointX, basePanelFirstPointY + basePanelPointY);
      basePanelA.Size = new Size(basePanelSizeWidth, basePanelSizeHeight);
      //アンカー
      //【注意】アンカーは設定を行うと(Noneでも)サイズ変更イベントが正常に動作しない
      //basePanelA.Anchor = System.Windows.Forms.AnchorStyles.None;
      //色
      basePanelA.BackColor = System.Drawing.SystemColors.GradientActiveCaption;

      /*各コントロール紐付け*/
      //フォームに追加する
      Controls.Add(basePanelA);
      //自動生成した子コントロールを追加する(これを行うため本メソッドは追加コントロール生成後に行う)
      foreach (string x in autoControlBasePanelName)
      {
        basePanelA.Controls.Add(Controls[x]);
      }

      /*イベントの追加*/
      basePanelA.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BasePanel_MouseMove);
      basePanelA.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BasePanel_MouseDown);

      /*位置調整*/
      basePanelPointX += addPointX;

      //次に出る基底パネルの横位置が現在のフォームサイズを越すようなら
      if (basePanelPointX >= this.Size.Width)
      {
        //Xの値を0に戻す
        basePanelPointX = 0;
        //Yの値を規定サイズ分下に下げる
        basePanelPointY += basePanelBaseSizeY;
      }


      //フォームのラベルを隠すため最前面にする
      basePanelA.BringToFront();
    }
    #endregion

    #endregion

    #region タイトルパネル
    public string TitlePanelCreate(string nameNum)
    {
      //Panelクラスのインスタンスを作成する
      Panel titlePanelA = new Panel();

      /*設定値*/
      //一個目の出現位置
      int titlePanelFirstPointX = 3;
      int titlePanelFirstPointY = 3;
      //サイズ
      int titlePanelSizeWidth = basePanelBaseSizeX + 16; //基底パネルのサイズにあわせる
      int titlePanelSizeHeight = 27;

      /*プロパティ設定*/
      //名称
      titlePanelA.Name = "titlePanel" + nameNum;
      //位置
      titlePanelA.Location = new Point(titlePanelFirstPointX, titlePanelFirstPointY);
      titlePanelA.Size = new Size(titlePanelSizeWidth, titlePanelSizeHeight);
      //アンカー
      titlePanelA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
      //背景色
      titlePanelA.BackColor = System.Drawing.Color.Transparent;

      /*各コントロール紐付け*/
      //フォームに追加する
      Controls.Add(titlePanelA);
      //自動生成した子コントロールを追加する
      foreach (string x in autoControlTitlePanelName)
      {
        titlePanelA.Controls.Add(Controls[x]);
      }

      /*イベントの追加*/
      titlePanelA.MouseEnter += new System.EventHandler(this.TitlePanel_MouseEnter);
      titlePanelA.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitlePanel_MouseDown);
      titlePanelA.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BasePanelChildrenControl_MouseDown);

      //作成したコントロール名を返す
      return titlePanelA.Name;
    }
    #endregion

    #region ファイル名ラベル
    public string FileNameLabel(string tbName, string textValue)
    {
      //Labelクラスのインスタンスを作成する
      Label labelA = new Label();

      /*設定値*/
      //一個目の出現位置
      int labelFirstPointX = 0; //基底パネルのサイズから算出
      int labelFirstPointY = 0;
      //サイズ
      int labelSizeWidth = basePanelBaseSizeX + 16; //タイトルパネルにあわせる
      int labelSizeHeight = 24;

      /*プロパティ設定*/
      //名称
      labelA.Name = "fileNameLabel" + tbName;
      //値
      labelA.Text = textValue;
      //位置
      labelA.Location = new Point(labelFirstPointX, labelFirstPointY);
      //サイズ
      labelA.Size = new Size(labelSizeWidth, labelSizeHeight);
      //アンカー
      labelA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
      //背景色をタイトルバーとあわせる
      labelA.BackColor = System.Drawing.SystemColors.InactiveCaption;
      //ボーダースタイルをなしに設定
      labelA.BorderStyle = System.Windows.Forms.BorderStyle.None;

      /*各コントロール紐付け*/
      //フォームに追加する
      Controls.Add(labelA);

      /*イベントの追加*/
      labelA.MouseEnter += new System.EventHandler(this.TitlePanel_MouseEnter);
      labelA.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitlePanel_MouseDown);
      labelA.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BasePanelChildrenControl_MouseDown);

      //作成したコントロール名を返す
      return labelA.Name;
    }
    #endregion

    #region 最小化ボタン
    public string MinButtonCreate(string tbName)
    {
      //Buttonクラスのインスタンスを作成する
      Button buttonA = new Button();

      /*設定値*/
      //一個目の出現位置
      int buttonFirstPointX = basePanelBaseSizeX - 80; //基底パネルのサイズから算出
      int buttonFirstPointY = 2;
      //サイズ
      int buttonSizeWidth = 26;
      int buttonSizeHeight = 23;

      /*プロパティ設定*/
      buttonA.Name = "minButton" + tbName;
      buttonA.Text = "_";
      //サイズと位置を設定する
      buttonA.Location = new Point(buttonFirstPointX, buttonFirstPointY);
      buttonA.Size = new Size(buttonSizeWidth, buttonSizeHeight);
      //アンカー
      buttonA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      buttonA.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BasePanelChildrenControl_MouseDown);

      /*各コントロール紐付け*/
      //フォームに追加する
      Controls.Add(buttonA);

      //作成したコントロール名を返す
      return buttonA.Name;
    }
    #endregion

    #region 最大化ボタン
    public string MaxButtonCreate(string tbName)
    {
      //Buttonクラスのインスタンスを作成する
      Button buttonA = new Button();

      /*設定値*/
      //一個目の出現位置
      int buttonFirstPointX = basePanelBaseSizeX - 55; //基底パネルのサイズから算出
      int buttonFirstPointY = 2;
      //サイズ
      int buttonSizeWidth = 26;
      int buttonSizeHeight = 23;

      /*プロパティ設定*/
      buttonA.Name = "maxButton" + tbName;
      buttonA.Text = "□";
      //表示文字位置
      buttonA.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      //サイズと位置を設定する
      buttonA.Location = new Point(buttonFirstPointX, buttonFirstPointY);
      buttonA.Size = new Size(buttonSizeWidth, buttonSizeHeight);
      //アンカー
      buttonA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      buttonA.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BasePanelChildrenControl_MouseDown);

      /*各コントロール紐付け*/
      //フォームに追加する
      Controls.Add(buttonA);

      //作成したコントロール名を返す
      return buttonA.Name;
    }
    #endregion

    #region 閉じるボタン
    public string CloseButtonCreate(string tbName)
    {
      //Buttonクラスのインスタンスを作成する
      Button buttonA = new Button();

      /*設定値*/
      //一個目の出現位置
      int buttonFirstPointX = basePanelBaseSizeX - 30; //基底パネルのサイズから算出
      int buttonFirstPointY = 2;
      //サイズ
      int buttonSizeWidth = 26;
      int buttonSizeHeight = 23;

      /*プロパティ設定*/
      buttonA.Name = "closeButton" + tbName;
      buttonA.Text = "×";
      //表示文字位置
      buttonA.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      //色
      buttonA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
      //サイズと位置を設定する
      buttonA.Location = new Point(buttonFirstPointX, buttonFirstPointY);
      buttonA.Size = new Size(buttonSizeWidth, buttonSizeHeight);
      //アンカー
      buttonA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      buttonA.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BasePanelChildrenControl_MouseDown);

      /*各コントロール紐付け*/
      //フォームに追加する
      Controls.Add(buttonA);

      /*イベントの追加*/
      buttonA.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CloseButton_MouseUp);

      //作成したコントロール名を返す
      return buttonA.Name;
    }
    #endregion

    #region テキストボックス
    public string TextBoxCreate(string nameNum, string textValue)
    {
      //TextBoxクラスのインスタンスを作成する
      TextBox textBoxA = new TextBox();

      /*設定値*/
      //一個目の出現位置
      int textBoxFirstPointX = 3;
      int textBoxFirstPointY = 30;
      //サイズ
      int textBoxSizeWidth = basePanelBaseSizeX - 6; //基底パネルのサイズから算出
      int textBoxSizeHeight = basePanelBaseSizeY - 32; //基底パネルのサイズから算出

      /*プロパティ設定*/
      textBoxA.Name = "textBox" + nameNum;
      textBoxA.Text = textValue;
      //サイズと位置を設定する
      textBoxA.Location = new Point(textBoxFirstPointX, textBoxFirstPointY);
      textBoxA.Size = new Size(textBoxSizeWidth, textBoxSizeHeight);
      //アンカー
      textBoxA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
      | System.Windows.Forms.AnchorStyles.Left)
      | System.Windows.Forms.AnchorStyles.Right)));
      //マルチライン
      textBoxA.Multiline = true;
      //スクロールバー
      textBoxA.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      textBoxA.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BasePanelChildrenControl_MouseDown);

      /*各コントロール紐付け*/
      //フォームに追加する
      Controls.Add(textBoxA);

      //作成したコントロール名を返す
      return textBoxA.Name;
    }
    #endregion

    #endregion

    #endregion

    #region 雛形メソッド
    public void template()
    {

    }
    #endregion
  }
}
