//#define DEBUG01 // ロードイベント参照
//#define DEBUG02 // クリック操作有効幅表示
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using System.Collections;
using System.Threading;
using System.Xml;
using System.Text.RegularExpressions;
using ImageMagick;

namespace WFA
{
  /// <summary>
  /// メインフォーム
  /// </summary>
  public partial class Form1 : Form
  {
    #region コンストラクタ
    /// <summary>
    /// コンストラクタ
    /// </summary>
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

      // メンバ初期化メソッド使用
      InitMember();

      // コマンドライン引数取得
      string[] cmdArgs = Environment.GetCommandLineArgs();
      // 引数がある場合(自身のexeパスが1つ目なので2以上のとき)
      if (cmdArgs.Length >= 2)
      {
        // ドラッグ&ドロップされたファイルの一つ目を取得
        string dropItem = Environment.GetCommandLineArgs()[1];
        // ファイル読み込みメソッド使用
        ReadFile(dropItem);
      }
    }
    #endregion

    #region コンフィグ取得メソッド
    /// <summary>
    /// コンフィグ取得メソッド
    /// </summary>
    private void GetConfig()
    {
      // 初期フォーム位置
      defLocationX = int.Parse(_comLogic.GetConfigValue("DefaultLocationX", "0"));
      defLocationY = int.Parse(_comLogic.GetConfigValue("DefaultLocationY", "0"));

      // フォームサイズ
      // コンフィグの値が数値以外の場合
      if (!int.TryParse(_comLogic.GetConfigValue("DefaultFormWidth", "1000"), out defFormWidth))
      {
        // タスクバーを抜いた画面サイズを設定
        defFormWidth = SystemInformation.WorkingArea.Width;
      }
      if (!int.TryParse(_comLogic.GetConfigValue("DefaultFormHeight", "500"), out defFormHeight))
      {
        defFormHeight = SystemInformation.WorkingArea.Height;
      }
      // 移動距離
      UpMoveDistance = int.Parse(_comLogic.GetConfigValue("UpMoveDistance", "1"));
      DownMoveDistance = int.Parse(_comLogic.GetConfigValue("DownMoveDistance", "1"));
      RightMoveDistance = int.Parse(_comLogic.GetConfigValue("RightMoveDistance", "1"));
      LeftMoveDistance = int.Parse(_comLogic.GetConfigValue("LeftMoveDistance", "1"));
      // 倍率関連
      initZoomRatio = double.Parse(_comLogic.GetConfigValue("InitZoomRatio", "1.0"));
      ZoomInRatio = double.Parse(_comLogic.GetConfigValue("ZoomInRatio", "2.0"));
      ZoomOutRatio = double.Parse(_comLogic.GetConfigValue("ZoomOutRatio", "2.0"));

      // 拡大/縮小モードキー
      modeZoomKey = _comLogic.GetConfigValue("ModeZoomKey", "Shift").ToLower();
      // モードページ送りキー
      modePageEjectKey = _comLogic.GetConfigValue("ModePageEjectKey", "Ctrl").ToLower();
      // モード0ポイントキー
      modeZeroPointKey = _comLogic.GetConfigValue("ModeZeroPointKey", "Alt").ToLower();
      // チェックキー
      chkImgKey = _comLogic.GetConfigValue("CheckImgKey", "Enter").ToLower();
      // ビュウアプリ起動キー
      launchViewKey = _comLogic.GetConfigValue("LaunchViewKey", "Enter").ToLower();

      // 対象拡張子
      tgtExtension = _comLogic.GetConfigValue("TargetExtension", ".jpg,.jepg,.png,.tiff,.gif,.bmp").Split(',');

      // ファイル読み込み対象範囲
      tgtRange = _comLogic.GetConfigValue("TargetRange", "OnlyCurrent");


      // オプションフォーム
      // コンフィグの値が数値以外の場合
      if (!int.TryParse(_comLogic.GetConfigValue("DefaultOptionFormLocationX", "0"), out defOptionFmLocationX))
      {
        // 画面右下に表示されるように設定
        defOptionFmLocationX = SystemInformation.WorkingArea.Width - fmOption.Size.Width;
      }
      if (!int.TryParse(_comLogic.GetConfigValue("DefaultOptionFormLocationY", "0"), out defOptionFmLocationY))
      {
        defOptionFmLocationY = SystemInformation.WorkingArea.Height - fmOption.Size.Height;
      }


      // ファイルリストフォーム
      // コンフィグの値が数値以外の場合
      if (!int.TryParse(_comLogic.GetConfigValue("DefaultFileListFormLocationX", "500"), out defFileListFmLocationX))
      {
        // 画面右下にオプションフォームと並ぶように表示
        defFileListFmLocationX = SystemInformation.WorkingArea.Width - (fmOption.Size.Width + fmFileList.Size.Width);
      }
      if (!int.TryParse(_comLogic.GetConfigValue("DefaultFileListFormLocationY", "0"), out defFileListFmLocationY))
      {
        defFileListFmLocationY = SystemInformation.WorkingArea.Height - fmFileList.Size.Height;
      }

      // ビュウアプリパス
      launchViewAppPath = _comLogic.GetConfigValue("LaunchViewAppPath", Assembly.GetExecutingAssembly().Location);

      // Xmlフォルダ名称
      XmlFolderName = _comLogic.GetConfigValue("XmlFolderName", "List");
    }
    #endregion

    #region メンバ初期化メソッド
    /// <summary>
    /// メンバ初期化メソッド
    /// </summary>
    private void InitMember()
    {
      // ファイル管理フォームインスタンス生成
      fmFileMng = new FrmFileMng(this);

      // 取り込みXMLパスプロパティ
      InputXmlPath = string.Empty;
      // 画像パスディクショナリプロパティ
      DicImgPath = new Dictionary<int, string>();
    }
    #endregion


    #region 宣言

    /// <summary>
    /// 共通ロジッククラスインスタンス
    /// </summary>
    MCSComLogic _comLogic = new MCSComLogic();

    // オプションフォームインスタンス生成
    FrmOption fmOption = new FrmOption();
    // ファイルリストフォームインスタンス生成
    FrmFileList fmFileList = new FrmFileList();
    // ファイル管理フォーム
    FrmFileMng fmFileMng;

    // 初期フォームサイズ
    int defFormWidth;
    int defFormHeight;
    // 初期フォーム位置
    int defLocationX;
    int defLocationY;

    // 表示対象画像
    Bitmap currentImage;
    // 最大ページ数
    int maxImageKey = 0;

    // 現在の開始位置(画像の左上)
    Point currentZeroPoint;
    // 倍率変更後の画像のサイズと位置
    Rectangle drawRectangle;

    // ズーム倍率初期値
    double initZoomRatio;
    // 現在のズーム倍率
    double currentZoomRatio = 1;

    // 拡大/縮小モードキー
    string modeZoomKey;
    // モードページ送りキー
    string modePageEjectKey;
    // モード0ポイントキー
    string modeZeroPointKey;
    // チェックキー
    string chkImgKey;
    // ビュウアプリ起動キー
    string launchViewKey;

    // 対象拡張子
    string[] tgtExtension;

    // ファイル読み込み対象範囲
    string tgtRange;

    // オプションフォーム開始位置
    int defOptionFmLocationX;
    int defOptionFmLocationY;

    // ファイルリストフォーム開始位置
    int defFileListFmLocationX;
    int defFileListFmLocationY;

    // ビュウアプリパス
    string launchViewAppPath;

    #endregion

    #region プロパティ

    /// <summary>
    /// 現在表示ページ数
    /// </summary>
    public int CurrentImageKey { get; set; }

    /// <summary>
    /// ズームイン倍率
    /// </summary>
    public double ZoomInRatio { get; set; }
    /// <summary>
    /// ズームアウト倍率
    /// </summary>
    public double ZoomOutRatio { get; set; }

    /// <summary>
    /// 上移動距離
    /// </summary>
    public int UpMoveDistance { get; set; }
    /// <summary>
    /// 下移動距離
    /// </summary>
    public int DownMoveDistance { get; set; }
    /// <summary>
    /// 左移動距離
    /// </summary>
    public int LeftMoveDistance { get; set; }
    /// <summary>
    /// 右移動距離
    /// </summary>
    public int RightMoveDistance { get; set; }

    /// <summary>
    /// コミット先パス
    /// </summary>
    public string commitPath { get; set; }

    /// <summary>
    /// XMLフォルダ名称
    /// </summary>
    public string XmlFolderName { get; set; }

    /// <summary>
    /// 取り込みXMLパス
    /// </summary>
    public string InputXmlPath { get; set; }

    /// <summary>
    /// 画像パスディクショナリ
    /// </summary>
    public Dictionary<int, string> DicImgPath { get; set; }

    #endregion


    #region メインフォーム初期設定メソッド
    /// <summary>
    /// メインフォーム初期設定メソッド
    /// </summary>
    private void MainFormInitSeting()
    {
      // フォーム位置
      this.StartPosition = FormStartPosition.Manual;
      this.Location = new Point(defLocationX, defLocationY);

      // フォームサイズ
      this.Width = defFormWidth;
      this.Height = defFormHeight;


      #region DEBUG01_コマンドライン引数
#if DEBUG01

      // ファイル読み込みメソッド使用
      ReadFile(@"MyResorce\TestImg\01.JPG");

#endif
      #endregion
    }
    #endregion


    #region サブフォーム初期設定メソッド
    /// <summary>
    /// サブフォーム初期設定メソッド
    /// </summary>
    private void SubFormInitSeting()
    {
      // オプションフォームのプロパティに本クラスを設定
      fmOption.parentForm = this;
      // 常にメインフォームの手前に表示
      fmOption.Owner = this;
      // 開始位置
      fmOption.StartPosition = FormStartPosition.Manual;
      fmOption.Location = new Point(defOptionFmLocationX, defOptionFmLocationY);
      // コントロール値設定
      fmOption.cbIsModeZoom.Text = string.Format("拡張/縮小({0})", modeZoomKey);
      fmOption.cbIsModePageEject.Text = string.Format("ページ送り({0})", modePageEjectKey);
      fmOption.cbIsModeZeroPoint.Text = string.Format("0Point({0})", modeZeroPointKey);
      fmOption.cbChkImg.Text = string.Format("チェック({0})", chkImgKey);
      fmOption.nudZoomInRatio.Text = ZoomInRatio.ToString();
      fmOption.btView.Text = string.Format("View({0})", launchViewKey);
      fmOption.nudZoomOutRatio.Text = ZoomOutRatio.ToString();
      fmOption.nudUpDist.Text = UpMoveDistance.ToString();
      fmOption.nudDownDist.Text = DownMoveDistance.ToString();
      fmOption.nudLeftDist.Text = LeftMoveDistance.ToString();
      fmOption.nudRightDist.Text = RightMoveDistance.ToString();
      // フォーム2呼び出し
      fmOption.Show();

      // ファイルリストフォームのプロパティに本クラスを設定
      fmFileList.parentForm = this;
      // ソートリストボックス値設定
      string[] cbSortDataSource = { "ファイル名昇順", "ファイル名降順", "作成日昇順", "作成日降順", "最終アクセス", "ファイルサイズ" };
      fmFileList.cbSort.DataSource = cbSortDataSource;
      // 常にメインフォームの手前に表示
      fmFileList.Owner = this;
      // 開始位置
      fmFileList.StartPosition = FormStartPosition.Manual;
      fmFileList.Location = new Point(defFileListFmLocationX, defFileListFmLocationY);
      // ファイルリストフォーム呼び出し
      fmFileList.Show();
      // リストビュー設定
      fmFileList.lvFileList.HideSelection = false;
    }
    #endregion


    #region ロードイベント
    /// <summary>
    /// ロードイベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Form1_Load(object sender, EventArgs e)
    {
      // メインフォーム初期設定メソッド使用
      MainFormInitSeting();

      // サブフォーム初期設定メソッド使用
      SubFormInitSeting();
    }
    #endregion

    #region マウスインされるファイルを開くイベント

    #region フォームドラッグエンターイベント
    /// <summary>
    /// フォームドラッグエンターイベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
        //ファイルまたはフォルダ以外であればイベント・ハンドラを抜ける
        if (!(File.Exists(d) || Directory.Exists(d)))
        {
          return;
        }
      }

      //マウスの表示を「+」に変更する
      e.Effect = DragDropEffects.Copy;
    }
    #endregion

    #region フォームドラッグドロップイベント
    /// <summary>
    /// フォームドラッグドロップイベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Form1_DragDrop(object sender, DragEventArgs e)
    {
      // ドラッグ&ドロップされたファイルの一つ目を取得
      string dropItem = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];

      // ファイル読み込みメソッド使用
      ReadFile(dropItem);
    }
    #endregion

    #endregion

    #region Paintイベント
    /// <summary>
    /// Paintイベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
      if (currentImage != null)
      {
        //画像を指定された位置、サイズで描画する
        e.Graphics.DrawImage(currentImage, drawRectangle);
      }
    }
    #endregion

    #region キー押下イベント
    /// <summary>
    /// キー押下イベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
      // 共通キー押下処理メソッド
      ComKeyDown(e);
    }
    #endregion


    #region コンテキスト_チェック拡張縮小押下イベント
    /// <summary>
    /// コンテキスト_チェック拡張縮小押下イベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ToolStripMenuItemIsModeZoom_Click(object sender, EventArgs e)
    {
      // 拡大/縮小チェック
      fmOption.cbIsModeZoom.Checked = !fmOption.cbIsModeZoom.Checked;
    }
    #endregion

    #region コンテキスト_チェックページ送り押下イベント
    /// <summary>
    /// コンテキスト_チェックページ送り押下イベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ToolStripMenuItemIsModePageEject_Click(object sender, EventArgs e)
    {
      // ページ送りチェック
      fmOption.cbIsModePageEject.Checked = !fmOption.cbIsModePageEject.Checked;
    }
    #endregion

    #region コンテキスト_ファイルリスト押下イベント
    /// <summary>
    /// コンテキスト_ファイルリスト押下イベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ToolStripMenuItemFileListForm_Click(object sender, EventArgs e)
    {
      // マウスの位置にファイルリストを表示する
      fmFileList.Left = Cursor.Position.X;
      fmFileList.Top = Cursor.Position.Y;
    }
    #endregion

    #region コンテキスト_操作パネル押下イベント
    /// <summary>
    /// コンテキスト_操作パネル押下イベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ToolStripMenuItemOptionForm_Click(object sender, EventArgs e)
    {
      // マウスの位置にオプションフォームを表示する
      fmOption.Left = Cursor.Position.X;
      fmOption.Top = Cursor.Position.Y;
    }
    #endregion

    #region コンテキスト_Viewアプリ起動押下イベント
    /// <summary>
    /// コンテキスト_Viewアプリ起動押下イベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ToolStripMenuItemLaunchViewApp_Click(object sender, EventArgs e)
    {
      // ビュウアプリ起動メソッド使用
      LaunchView();
    }
    #endregion

    #region コンテキスト_コンフィグ押下イベント
    /// <summary>
    /// コンテキスト_コンフィグ押下イベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ToolStripMenuItemConfig_Click(object sender, EventArgs e)
    {
      // 自身のコンフィグファイルパス取得
      string configPath = Assembly.GetExecutingAssembly().Location + ".config";

      // コンフィグファイルを関連付けられたアプリケーションで開く
      Process p = Process.Start(configPath);
    }
    #endregion

    #region コンテキスト_リスト押下イベント
    /// <summary>
    /// コンテキスト_リスト押下イベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ToolStripMenuItemList_Click(object sender, EventArgs e)
    {
      // ファイル管理フォームのプロパティに本クラスを設定
      fmFileMng.form1 = this;
      // ファイル管理フォーム呼び出し
      fmFileMng.ShowDialog();

      // ねずみ返し_オプションフォームでファイル選択されなかった場合
      if (InputXmlPath == string.Empty)
      {
        return;
      }

      // XML読み込みメソッド使用
      ReadXml(InputXmlPath);

      /* 画像表示処理 */
      // 表示するファイルにドロップしたファイルを設定
      CurrentImageKey = 0;
      // 最終ページ数を設定
      maxImageKey = DicImgPath.Count - 1;

      // 現在倍率に初期倍率を設定する
      currentZoomRatio = initZoomRatio;

      // 画像初期化メソッド使用
      ImgInit();

      // ファイルリストフォーム初期化メソッド使用
      InitFileListForm();

      // ファイルリストの該当ファイルを選択
      fmFileList.lvFileList.SelectedItems.Clear();
      fmFileList.lvFileList.Items[CurrentImageKey].Selected = true;
    }
    #endregion


    #region ピクチャボックスWクリックイベント
    /// <summary>
    /// ピクチャボックスWクリックイベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void pictureBox1_DoubleClick(object sender, EventArgs e)
    {
      // ピクチャボックスサイズを取得
      Size ctrlSize = pictureBox1.Size;
      // ピクチャボックス上のクリック位置取得
      Point clickPosition = pictureBox1.PointToClient(MousePosition);

      // 有効範囲クリック判断用変数
      bool leftUpClick = false;
      bool rightUpClick = false;
      bool leftDownClick = false;
      bool rightDownClick = false;
      bool upSideClick = false;
      bool downSideClick = false;
      bool rightSideClick = false;
      bool leftSideClick = false;

      // 有効範囲算出横五縦十メソッド使用
      EffectiveRangeFullTen(ctrlSize, clickPosition, out leftUpClick, out rightUpClick, out leftDownClick, out rightDownClick, out upSideClick, out downSideClick, out rightSideClick, out leftSideClick);

      // クリック位置分岐
      if (leftUpClick) // 左上
      {
        // ズームイン操作メソッド使用
        ZoomInOperation();
      }
      else if (rightUpClick)
      {
        // 次ページ送り操作メソッド使用
        ImgFeedPostOperation();
      }
      else if (leftDownClick)
      {
        // 前ページ送り操作メソッド使用
        ImgFeedPreOperation();
      }
      else if (rightDownClick)
      {
        // ズームアウト操作メソッド使用
        ZoomOutOperation();
      }
      else if (upSideClick) // 有効範囲クリック判断
      {
        // 上に移動
        currentZeroPoint = new Point(currentZeroPoint.X + 0, currentZeroPoint.Y + UpMoveDistance);
        // 移動メソッド使用
        ImgMove();
      }
      else if (downSideClick)
      {
        // 下に移動
        currentZeroPoint = new Point(currentZeroPoint.X + 0, currentZeroPoint.Y - DownMoveDistance);
        ImgMove();
      }
      else if (rightSideClick)
      {
        // 右に移動
        currentZeroPoint = new Point(currentZeroPoint.X - RightMoveDistance, currentZeroPoint.Y + 0);
        ImgMove();
      }
      else if (leftSideClick)
      {
        // 左に移動
        currentZeroPoint = new Point(currentZeroPoint.X + LeftMoveDistance, currentZeroPoint.Y + 0);
        ImgMove();
      }
    }
    #endregion


    #region 共通キー押下処理メソッド
    /// <summary>
    /// 共通キー押下処理メソッド
    /// </summary>
    /// <param name="e"></param>
    public void ComKeyDown(KeyEventArgs e)
    {
      // 拡大/縮小キー押下判断メソッド使用
      if (IsModeZoomKey(e))
      {
        // チェック
        fmOption.cbIsModeZoom.Checked = !fmOption.cbIsModeZoom.Checked;
        return;
      }

      // ページ送りキー押下判断メソッド使用
      if (IsModePageEjectKey(e))
      {
        fmOption.cbIsModePageEject.Checked = !fmOption.cbIsModePageEject.Checked;
        return;
      }

      // 0ポイントキー押下判断メソッド使用
      if (IsModeZeroPointKey(e))
      {
        fmOption.cbIsModeZeroPoint.Checked = !fmOption.cbIsModeZeroPoint.Checked;
        return;
      }

      // チェックキー押下判断メソッド使用
      if (IsChkImgKey(e))
      {
        fmOption.cbChkImg.Checked = !fmOption.cbChkImg.Checked;
        // ファイルリスト該当ファイルのチェックを変更する
        fmFileList.lvFileList.Items[CurrentImageKey].Checked = !fmFileList.lvFileList.Items[CurrentImageKey].Checked;
        return;
      }

      // チェックキー押下判断メソッド使用
      if (IsLaunchViewKey(e))
      {
        // ビュウアプリ起動メソッド使用
        LaunchView();
        return;
      }

      // 押下キー振り分け
      switch (e.KeyCode)
      {
        case Keys.Up:
          // 上操作メソッド使用
          UpOperation();
          break;

        case Keys.Down:
          // 下操作メソッド使用
          DownOperation();
          break;

        case Keys.Right:
          // 右操作メソッド使用
          RightOperation();
          break;

        case Keys.Left:
          // 左操作メソッド使用
          LeftOperation();
          break;

        default:
          break;
      }

      //switch (e.KeyData)
      //{
      //  case Keys.Up:
      //    // コントロールと同時押しの場合
      //    if (e.KeyData == Keys.Up && e.Control)
      //      break;
      //}
    }
    #endregion


    #region 拡大/縮小キー押下判断メソッド
    /// <summary>
    /// 拡大/縮小キー押下判断メソッド
    /// </summary>
    /// <param name="e"></param>
    /// <returns></returns>
    private bool IsModeZoomKey(KeyEventArgs e)
    {
      bool isFunctionOn = false;
      switch (modeZoomKey)
      {
        case "ctrl":
          isFunctionOn = e.Control;
          break;
        case "shift":
          isFunctionOn = e.Shift;
          break;
        case "alt":
          isFunctionOn = e.Alt;
          break;

        default:
          break;
      }

      return isFunctionOn;
    }
    #endregion

    #region ページ送りキー押下判断メソッド
    /// <summary>
    /// ページ送りキー押下判断メソッド
    /// </summary>
    /// <param name="e"></param>
    /// <returns></returns>
    private bool IsModePageEjectKey(KeyEventArgs e)
    {
      bool isFunctionOn = false;
      switch (modePageEjectKey)
      {
        case "ctrl":
          isFunctionOn = e.Control;
          break;
        case "shift":
          isFunctionOn = e.Shift;
          break;
        case "alt":
          isFunctionOn = e.Alt;
          break;

        default:
          break;
      }

      return isFunctionOn;
    }
    #endregion

    #region 0ポイントキー押下判断メソッド
    /// <summary>
    /// 0ポイントキー押下判断メソッド
    /// </summary>
    /// <param name="e"></param>
    /// <returns></returns>
    private bool IsModeZeroPointKey(KeyEventArgs e)
    {
      bool isFunctionOn = false;
      switch (modeZeroPointKey)
      {
        case "ctrl":
          isFunctionOn = e.Control;
          break;
        case "shift":
          isFunctionOn = e.Shift;
          break;
        case "alt":
          isFunctionOn = e.Alt;
          break;

        default:
          break;
      }

      return isFunctionOn;
    }
    #endregion

    #region チェックキー押下判断メソッド
    /// <summary>
    /// チェックキー押下判断メソッド
    /// </summary>
    /// <param name="e"></param>
    /// <returns></returns>
    private bool IsChkImgKey(KeyEventArgs e)
    {
      bool isChkOn = false;
      switch (chkImgKey)
      {
        case "enter":
          isChkOn = e.KeyCode == Keys.Enter ? true : false;
          break;
        case "space":
          isChkOn = e.KeyCode == Keys.Space ? true : false;
          break;

        default:
          break;
      }

      return isChkOn;
    }
    #endregion

    #region ビュウアプリ起動キー押下判断メソッド
    /// <summary>
    /// ビュウアプリ起動キー押下判断メソッド
    /// </summary>
    /// <param name="e"></param>
    /// <returns></returns>
    private bool IsLaunchViewKey(KeyEventArgs e)
    {
      bool isLaunchView = false;
      switch (launchViewKey)
      {
        case "enter":
          isLaunchView = e.KeyCode == Keys.Enter ? true : false;
          break;
        case "space":
          isLaunchView = e.KeyCode == Keys.Space ? true : false;
          break;

        default:
          break;
      }

      return isLaunchView;
    }
    #endregion


    #region ファイル読み込みメソッド
    /// <summary>
    /// ファイル読み込みメソッド
    /// </summary>
    /// <param name="dropItem">対象ファイルパス</param>
    public void ReadFile(string dropItem)
    {
      // 画像パスディクショナリ作成メソッド使用
      CreateDic(dropItem);

      // ドロップされたのがフォルダの場合
      if (Directory.Exists(dropItem))
      {
        // 表示するファイルのページを最初のものに設定
        CurrentImageKey = 0;
      }
      // ファイルが存在しない場合(移動等ファイルがないパターンを想定)
      else if (!File.Exists(dropItem))
      {
        // 表示するファイルのページを最初のものに設定
        CurrentImageKey = 0;
      }
      else
      {
        // 表示するファイルにドロップしたファイルを設定
        CurrentImageKey = DicImgPath.First(x => x.Value == dropItem).Key;
      }

      // 現在倍率に初期倍率を設定する
      currentZoomRatio = initZoomRatio;

      // 画像初期化メソッド使用
      ImgInit();

      // ファイルリストフォーム初期化メソッド使用
      InitFileListForm();

      // ファイルリストの該当ファイルを選択
      fmFileList.lvFileList.SelectedItems.Clear();
      fmFileList.lvFileList.Items[CurrentImageKey].Selected = true;
    }
    #endregion

    #region 画像パスディクショナリ作成メソッド
    /// <summary>
    /// 画像パスディクショナリ作成メソッド
    /// </summary>
    /// <param name="tgtPath"></param>
    private void CreateDic(string tgtPath)
    {
      // すでに読み込まれているものがある場合
      if (DicImgPath.Count >= 1)
      {
        // 初期化
        DicImgPath = new Dictionary<int, string>();
      }

      /* 対象ディレクトリパス取得 */
      // デフォルトとしてはディレクトリを想定
      string tgtDirPath = tgtPath;
      // ファイルの移動・削除直後を想定してディレクトリでない判定
      if (!Directory.Exists(tgtPath))
      {
        try
        {
          // ファイルからフォルダパスを取得
          tgtDirPath = Path.GetDirectoryName(tgtPath);
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.ToString() + "\r\n\r\n" + tgtPath);
        }
      }

      // 対象ディレクトリ取得
      DirectoryInfo dir = new DirectoryInfo(tgtDirPath);

      // ファイル読み込み対象範囲分岐
      FileInfo[] files = null;
      if (tgtRange == "TopBottom")
      {
        // 対象フォルダ以下すべてのフォルダの中身を取得
        files = dir.GetFiles("*", SearchOption.AllDirectories);
      }
      else
      {
        // 対象フォルダの中身のみ取得
        files = dir.GetFiles("*", SearchOption.TopDirectoryOnly);
      }


      #region ソート無名関数
      /*
       *   【C#】ファイル一覧をファイル名でソートする : ubichupas.net
       *      http://ubichupas.blogspot.com/2011/04/cfilesort.html
       */
      Array.Sort<FileInfo>(files, delegate (FileInfo a, FileInfo b)
      {
        // ソートコンボボックスからソート方法を分岐
        int returnVar = 0;
        switch (fmFileList.cbSort.Text)
        {
          case "ファイル名昇順":
            returnVar = a.Name.CompareTo(b.Name);
            break;

          case "ファイル名降順":
            returnVar = b.Name.CompareTo(a.Name);
            break;

          case "作成日昇順":
            returnVar = a.CreationTime.CompareTo(b.CreationTime);
            break;

          case "作成日降順":
            returnVar = b.CreationTime.CompareTo(a.CreationTime);
            break;

          case "最終アクセス":
            returnVar = a.LastAccessTime.CompareTo(b.LastAccessTime);
            break;

          case "最終書き込み":
            returnVar = a.LastWriteTime.CompareTo(b.LastWriteTime);
            break;

          case "ファイルサイズ":
            returnVar = (int)(a.Length - b.Length);
            break;

          default:
            // デフォルト:ファイル名昇順
            returnVar = a.Name.CompareTo(b.Name);
            break;
        }
        return returnVar;
      });
      #endregion


      // 画像パスディクショナリに変換
      int i = 0;
      foreach (FileInfo x in files)
      {
        // ねずみ返し_拡張子が設定したものではないときは次のループへ
        if (Array.IndexOf(tgtExtension, Path.GetExtension(x.FullName).ToLower()) == -1)
        {
          continue;
        }

        DicImgPath.Add(i, x.FullName);
        i += 1;
      }
      // 最終ページインデックスを設定
      maxImageKey = DicImgPath.Count - 1;
    }
    #endregion

    #region 画像初期化メソッド
    /// <summary>
    /// 画像初期化メソッド
    /// </summary>
    private void ImgInit()
    {
      // 読み込み済みの場合
      if (currentImage != null)
      {
        currentImage.Dispose();
      }

      try
      {
        // 表示対象画像イメージマジック取り込み
        byte[] imgByte;
        using (MagickImage image = new MagickImage(DicImgPath[CurrentImageKey]))
        {
          // ビットマップに設定
          image.Format = MagickFormat.Bmp;
          // バイト変換
          imgByte = image.ToByteArray();
        }
        // 画像バイトストリーム取り込み
        using (MemoryStream ms = new MemoryStream(imgByte))
        {
          // ビットマップ変換
          currentImage = new Bitmap(ms);
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString() + "\r\n\r\nキー:" + CurrentImageKey);
      }

      // 初期化用設定
      drawRectangle = new Rectangle(currentZeroPoint.X, currentZeroPoint.Y, (int)Math.Round(currentImage.Width * currentZoomRatio), (int)Math.Round(currentImage.Height * currentZoomRatio));

      // 画像を表示する
      pictureBox1.Invalidate();

      // ファイル名表示
      fmOption.tbFileName.Text = Path.GetFileName(DicImgPath[CurrentImageKey]);
      // ファイルサイズ
      fmOption.tbFileSize.Text = drawRectangle.Width + "×" + drawRectangle.Height;
    }
    #endregion

    #region 画像ズームメソッド
    /// <summary>
    /// 画像ズームメソッド
    /// </summary>
    private void ImgZoom()
    {
      // 倍率変更後の画像のサイズと位置を計算する
      drawRectangle.Width = (int)Math.Round(currentImage.Width * currentZoomRatio);
      drawRectangle.Height = (int)Math.Round(currentImage.Height * currentZoomRatio);
      // 現在位置を位置として設定
      drawRectangle.X = currentZeroPoint.X;
      drawRectangle.Y = currentZeroPoint.Y;

      //画像を表示する
      pictureBox1.Invalidate();

      // ファイルサイズ
      fmOption.tbFileSize.Text = drawRectangle.Width + "×" + drawRectangle.Height;
    }
    #endregion

    #region 画像移動メソッド
    /// <summary>
    /// 画像移動メソッド
    /// </summary>
    private void ImgMove()
    {
      // 移動後ポイントを設定
      drawRectangle.X = currentZeroPoint.X;
      drawRectangle.Y = currentZeroPoint.Y;
      //画像を表示する
      pictureBox1.Invalidate();
    }
    #endregion


    #region ファイルリストフォーム初期化メソッド
    /// <summary>
    /// ファイルリストフォーム初期化メソッド
    /// </summary>
    public void InitFileListForm()
    {
      // リストビュー初期化
      fmFileList.lvFileList.Items.Clear();

      // ファイルディクショナリをループ処理
      foreach (var x in DicImgPath)
      {
        // リストビューにファイル名のみ追加
        fmFileList.lvFileList.Items.Add(Path.GetFileName(x.Value));
      }
    }
    #endregion

    #region ファイル移動メソッド
    /// <summary>
    /// ファイル移動メソッド
    /// </summary>
    /// <param name="fileIndex"></param>
    public void MoveFiles(ArrayList fileIndex)
    {
      // 表示中の画像を破棄
      if (currentImage != null)
      {
        currentImage.Dispose();
      }

      // チェックされたファイルを処理
      foreach (int x in fileIndex)
      {
        // ディクショナリから画像パスを取得
        string tgtImgPath = DicImgPath[x];

        try
        {
          // ファイル移動
          File.Move(tgtImgPath, commitPath + @"\" + Path.GetFileName(tgtImgPath));
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.ToString() + "\r\n\r\n" + tgtImgPath);
        }
      }

      // 現在表示している画像のフォルダを改めて読み込み
      ReadFile(DicImgPath[CurrentImageKey]);
    }
    #endregion

    #region ファイルコピーメソッド
    /// <summary>
    /// ファイルコピーメソッド
    /// </summary>
    /// <param name="fileIndex"></param>
    public void CopyFiles(ArrayList fileIndex)
    {
      // チェックされたファイルを処理
      foreach (int x in fileIndex)
      {
        // ディクショナリから画像パスを取得
        string tgtImgPath = DicImgPath[x];

        try
        {
          // ファイル移動
          File.Copy(tgtImgPath, commitPath + @"\" + Path.GetFileName(tgtImgPath));
        }
        catch (Exception e)
        {
          MessageBox.Show(e.ToString());
        }
      }
    }
    #endregion

    #region ファイル削除メソッド
    /// <summary>
    /// ファイル削除メソッド
    /// </summary>
    /// <param name="fileIndex"></param>
    public void DeleteFiles(ArrayList fileIndex)
    {
      // 表示中の画像を破棄
      if (currentImage != null)
      {
        currentImage.Dispose();
      }

      // チェックされたファイルを処理
      foreach (int x in fileIndex)
      {
        // ディクショナリから画像パスを取得
        string tgtImgPath = DicImgPath[x];

        try
        {
          // ファイル削除
          File.Delete(tgtImgPath);
        }
        catch (Exception e)
        {
          MessageBox.Show(e.ToString());
        }
      }

      // 現在表示している画像のフォルダを改めて読み込み
      ReadFile(DicImgPath[CurrentImageKey]);
    }
    #endregion


    #region 上操作メソッド
    /// <summary>
    /// 上操作メソッド
    /// </summary>
    public void UpOperation()
    {
      // 拡大/縮小チェック
      if (fmOption.cbIsModeZoom.Checked)
      {
        // ズームイン操作メソッド使用
        ZoomInOperation();
      }
      else
      {
        // 上に移動
        currentZeroPoint = new Point(currentZeroPoint.X + 0, currentZeroPoint.Y + UpMoveDistance);

        // 移動メソッド使用
        ImgMove();
      }
    }
    #endregion

    #region 下操作メソッド
    /// <summary>
    /// 下操作メソッド
    /// </summary>
    public void DownOperation()
    {
      // 拡大/縮小チェック
      if (fmOption.cbIsModeZoom.Checked)
      {
        // ズームアウト操作メソッド使用
        ZoomOutOperation();
      }
      else
      {
        // 下に移動
        currentZeroPoint = new Point(currentZeroPoint.X + 0, currentZeroPoint.Y - DownMoveDistance);

        // 移動メソッド使用
        ImgMove();
      }
    }
    #endregion

    #region 右操作メソッド
    /// <summary>
    /// 右操作メソッド
    /// </summary>
    public void RightOperation()
    {
      // ページ送りチェック
      if (fmOption.cbIsModePageEject.Checked)
      {
        // 次ページ送り操作メソッド使用
        ImgFeedPostOperation();
      }
      else
      {
        // 右に移動
        currentZeroPoint = new Point(currentZeroPoint.X - RightMoveDistance, currentZeroPoint.Y + 0);

        // 移動メソッド使用
        ImgMove();
      }
    }
    #endregion

    #region 左操作メソッド
    /// <summary>
    /// 左操作メソッド
    /// </summary>
    public void LeftOperation()
    {
      // コントロールチェックの場合
      if (fmOption.cbIsModePageEject.Checked)
      {
        // 前ページ送り操作メソッド使用
        ImgFeedPreOperation();
      }
      else
      {
        // 左に移動
        currentZeroPoint = new Point(currentZeroPoint.X + LeftMoveDistance, currentZeroPoint.Y + 0);

        // 移動メソッド使用
        ImgMove();
      }
    }
    #endregion


    #region ズームイン操作メソッド
    /// <summary>
    /// ズームイン操作メソッド
    /// </summary>
    private void ZoomInOperation()
    {
      // 現在倍率を倍にする
      currentZoomRatio = currentZoomRatio * ZoomInRatio;

      // 現在の(0, 0)の位置を拡大後も引き継ぐ
      currentZeroPoint = new Point((int)(currentZeroPoint.X * ZoomInRatio), (int)(currentZeroPoint.Y * ZoomInRatio));

      // 0ポイントチェック
      if (fmOption.cbIsModeZeroPoint.Checked)
      {
        // ページ送りに伴い画像を左上に設定
        currentZeroPoint = new Point(0, 0);
      }

      // 画像ズームメソッド使用
      ImgZoom();
    }
    #endregion

    #region ズームアウト操作メソッド
    /// <summary>
    /// ズームアウト操作メソッド
    /// </summary>
    private void ZoomOutOperation()
    {
      // 現在倍率にズームアウト倍率を割る
      currentZoomRatio = currentZoomRatio / ZoomOutRatio;

      // 現在の(0, 0)の位置を縮小後も引き継ぐ
      currentZeroPoint = new Point((int)(currentZeroPoint.X / ZoomOutRatio), (int)(currentZeroPoint.Y / ZoomOutRatio));

      // 0ポイントチェック
      if (fmOption.cbIsModeZeroPoint.Checked)
      {
        // 縮小の場合は画像の位置を戻す(画像位置によっては画面からいなくなる事があるため)
        currentZeroPoint = new Point(0, 0);
      }

      // 画像ズームメソッド使用
      ImgZoom();
    }
    #endregion

    #region 次ページ送り操作メソッド
    /// <summary>
    /// 次ページ送り操作メソッド
    /// </summary>
    private void ImgFeedPostOperation()
    {
      // 現ページが最後の場合
      if (CurrentImageKey == maxImageKey)
      {
        // 最初のページへ
        CurrentImageKey = 0;
      }
      else
      {
        // 次のページへ
        CurrentImageKey += 1;
      }

      // ページ送りメソッド使用
      FeedImg();

      // ファイルリストの該当ファイルを選択
      fmFileList.lvFileList.SelectedItems.Clear();
      fmFileList.lvFileList.Items[CurrentImageKey].Selected = true;
      // 選択ファイルがリスト上で次ページになった場合、リストをスクロール
      fmFileList.lvFileList.EnsureVisible(CurrentImageKey);

      // オプションフォームのチェックを表示している画像に沿って設定
      fmOption.cbChkImg.Checked = fmFileList.lvFileList.Items[CurrentImageKey].Checked;
    }
    #endregion

    #region 前ページ送り操作メソッド
    /// <summary>
    /// 前ページ送り操作メソッド
    /// </summary>
    private void ImgFeedPreOperation()
    {
      // 現ページが最初の場合
      if (CurrentImageKey == 0)
      {
        CurrentImageKey = maxImageKey;
      }
      else
      {
        // 左のページへ
        CurrentImageKey -= 1;
      }

      // ページ送りメソッド使用
      FeedImg();

      // ファイルリストの該当ファイルを選択
      fmFileList.lvFileList.SelectedItems.Clear();
      fmFileList.lvFileList.Items[CurrentImageKey].Selected = true;
      // 選択ファイルがリスト上で前ページになった場合、リストをスクロール
      fmFileList.lvFileList.EnsureVisible(CurrentImageKey);

      // オプションフォームのチェックを表示している画像に沿って設定
      fmOption.cbChkImg.Checked = fmFileList.lvFileList.Items[CurrentImageKey].Checked;
    }
    #endregion


    #region ページ送りメソッド
    /// <summary>
    /// ページ送りメソッド
    /// </summary>
    public void FeedImg()
    {
      // ページ送りに伴い画像を左上に設定
      currentZeroPoint = new Point(0, 0);

      // 画像初期化メソッド使用
      ImgInit();
    }
    #endregion

    #region ビュウアプリ起動メソッド
    /// <summary>
    /// ビュウアプリ起動メソッド
    /// </summary>
    public void LaunchView()
    {
      // ねずみ返し_画像がない場合
      if (DicImgPath.Count == 0)
      {
        return;
      }

      // インスタンス生成
      ProcessStartInfo psi = new ProcessStartInfo();

      // 起動するファイルパス設定
      psi.FileName = launchViewAppPath;
      // 現在の画像パスをコマンドライン引数に設定
      // スペースで引数が分かれるためダブルクォートをつける
      psi.Arguments = "\"" + DicImgPath[CurrentImageKey] + "\"";

      // 起動
      Process p = Process.Start(psi);

      // 自身をアクティブ化するために起動を待つ
      bool isAlive = true;
      while (isAlive)
      {
        // IDが振られるまでループ
        if (Process.GetProcessById(p.Id) != null)
        {
          isAlive = false;
        }
        Thread.Sleep(500);
      }

      // ビューアプリ起動後、自身のアクティブ化チェックがついている場合
      if (fmOption.cbThisAct.Checked)
      {
        // 自身をアクティブ化
        this.Activate();
      }
    }
    #endregion


    #region 有効範囲算出横五縦十メソッド
    /// <summary>
    /// 有効範囲算出横五縦十メソッド
    /// </summary>
    /// <param name="ctrlSize"></param>
    /// <param name="clickPosition"></param>
    /// <param name="upSideClick"></param>
    /// <param name="downSideClick"></param>
    /// <param name="rightSideClick"></param>
    /// <param name="leftSideClick"></param>
    private void EffectiveRangeFiveTen(Size ctrlSize, Point clickPosition, out bool upSideClick, out bool downSideClick, out bool rightSideClick, out bool leftSideClick)
    {
      #region メモ
      /*
       *     1 2 3 4 5
       *  1 ┌┬┬┬┬┐
       *  2 ├┼┼┼┼┤
       *  3 ├┼┼┼┼┤
       *  4 ├┼┼┼┼┤←//ここから//
       *  5 ├┼┼┼┼┤    有効縦幅
       *  6 ├┼┼┼┼┤←//ここまで//
       *  7 ├┼┼┼┼┤
       *  8 ├┼┼┼┼┤
       *  9 ├┼┼┼┼┤
       * 10 └┴┴┴┴┘
       *         ↑
       *         有効横幅
       */
      #endregion

      // 横幅の有効横幅作成(四捨五入)
      int widthBeltSize = Convert.ToInt32(Math.Round((double)ctrlSize.Width / 5));
      // 実際の有効横幅を作成
      int beginWidthBelt = 2 * widthBeltSize;
      int endWidthBelt = 3 * widthBeltSize;

      // 縦の有効縦幅作成(四捨五入)
      int heightBeltSize = Convert.ToInt32(Math.Round((double)ctrlSize.Height / 10));
      // 実際の有効縦幅を作成
      int beginHeightBelt = 4 * heightBeltSize;
      int endHeightBelt = 6 * heightBeltSize;

      #region デバッグ02_クリック操作有効幅表示
#if DEBUG02
      // 描画先するImageオブジェクト作成
      Bitmap canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
      // ImageオブジェクトのGraphicsオブジェクト作成
      using (Graphics g = Graphics.FromImage(canvas))
      {
        // 横幅の描写
        for (int i = 1; i < 5 + 1; i++)
        {
          g.DrawLine(Pens.Black, i * widthBeltSize, 0, i * widthBeltSize, ctrlSize.Height);
        }

        // 縦の描写
        for (int i = 1; i < 10 + 1; i++)
        {
          g.DrawLine(Pens.Black, 0, i * heightBeltSize, ctrlSize.Width, i * heightBeltSize);
        }

        // 中心線
        g.DrawLine(Pens.Green, 0, ctrlSize.Height / 2, ctrlSize.Width, ctrlSize.Height / 2);
        g.DrawLine(Pens.Green, ctrlSize.Width / 2, 0, ctrlSize.Width / 2, ctrlSize.Height);

        // 有効線横
        g.DrawLine(Pens.Blue, 0, 4 * heightBeltSize, ctrlSize.Width, 4 * heightBeltSize);
        g.DrawLine(Pens.Blue, 0, 6 * heightBeltSize, ctrlSize.Width, 6 * heightBeltSize);
        // 有効線縦
        g.DrawLine(Pens.Blue, 2 * widthBeltSize, 0, 2 * widthBeltSize, ctrlSize.Height);
        g.DrawLine(Pens.Blue, 3 * widthBeltSize, 0, 3 * widthBeltSize, ctrlSize.Height);
      }
      // 描画
      pictureBox1.Image = canvas;
#endif
      #endregion

      // 上側の有効縦幅判定
      upSideClick = clickPosition.X >= beginWidthBelt && clickPosition.X <= endWidthBelt && clickPosition.Y <= beginHeightBelt;
      // 下側の有効縦幅判定
      downSideClick = clickPosition.X >= beginWidthBelt && clickPosition.X <= endWidthBelt && clickPosition.Y >= endHeightBelt;
      // 右側の有効縦幅判定
      rightSideClick = clickPosition.Y >= beginHeightBelt && clickPosition.Y <= endHeightBelt && clickPosition.X >= endWidthBelt;
      // 左側の有効縦幅判定
      leftSideClick = clickPosition.Y >= beginHeightBelt && clickPosition.Y <= endHeightBelt && clickPosition.X <= beginWidthBelt;
    }
    #endregion

    #region 有効範囲算出横全縦十メソッド
    /// <summary>
    /// 有効範囲算出横全縦十メソッド
    /// </summary>
    /// <param name="ctrlSize"></param>
    /// <param name="clickPosition"></param>
    /// <param name="leftUpClick"></param>
    /// <param name="rightUpClick"></param>
    /// <param name="leftDownClick"></param>
    /// <param name="rightDownClick"></param>
    /// <param name="upSideClick"></param>
    /// <param name="downSideClick"></param>
    /// <param name="rightSideClick"></param>
    /// <param name="leftSideClick"></param>
    private void EffectiveRangeFullTen(Size ctrlSize, Point clickPosition, out bool leftUpClick, out bool rightUpClick, out bool leftDownClick, out bool rightDownClick, out bool upSideClick, out bool downSideClick, out bool rightSideClick, out bool leftSideClick)
    {
      #region メモ
      /*
       *  1 ┌────┐←//ここから//
       *  2 ├────┤    有効横幅
       *  3 ├────┤←//ここまで//
       *  4 ├────┤←//ここから//
       *  5 ├────┤    有効縦幅
       *  6 ├────┤←//ここまで//
       *  7 ├────┤←//ここから//
       *  8 ├────┤    有効横幅
       *  9 ├────┤    有効横幅
       * 10 └────┘←//ここまで//
       */
      #endregion

      //// 横幅の有効横幅作成(四捨五入)
      //int widthBeltSize = Convert.ToInt32(Math.Round((double)ctrlSize.Width / 5));
      // 実際の有効横幅を作成
      int beginWidthBelt = 0;
      int endWidthBelt = ctrlSize.Width;

      // 縦の有効縦幅作成(四捨五入)
      int heightBeltSize = Convert.ToInt32(Math.Round((double)ctrlSize.Height / 10));
      // 実際の有効縦幅を作成
      int beginHeightBelt = 4 * heightBeltSize;
      int endHeightBelt = 6 * heightBeltSize;

      #region デバッグ02_クリック操作有効幅表示
#if DEBUG02
      // 描画先するImageオブジェクト作成
      Bitmap canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
      // ImageオブジェクトのGraphicsオブジェクト作成
      using (Graphics g = Graphics.FromImage(canvas))
      {
        // 縦の描写
        for (int i = 1; i < 10 + 1; i++)
        {
          g.DrawLine(Pens.Black, 0, i * heightBeltSize, ctrlSize.Width, i * heightBeltSize);
        }

        // 四つ角
        g.DrawRectangle(Pens.Red, 0, 0, ctrlSize.Width / 4, ctrlSize.Height / 5);
        g.DrawRectangle(Pens.Red, ctrlSize.Width - ctrlSize.Width / 4, 0, ctrlSize.Width, ctrlSize.Height / 5);
        g.DrawRectangle(Pens.Red, 0, ctrlSize.Height - ctrlSize.Height / 5, ctrlSize.Width / 4, ctrlSize.Height / 5);
        g.DrawRectangle(Pens.Red, ctrlSize.Width - ctrlSize.Width / 4, ctrlSize.Height - ctrlSize.Height / 5, ctrlSize.Width, ctrlSize.Height);

        // 中心線
        g.DrawLine(Pens.Green, 0, ctrlSize.Height / 2, ctrlSize.Width, ctrlSize.Height / 2);
        g.DrawLine(Pens.Green, ctrlSize.Width / 2, 0, ctrlSize.Width / 2, ctrlSize.Height);

        // 有効線横
        g.DrawLine(Pens.Blue, 0, 4 * heightBeltSize, ctrlSize.Width, 4 * heightBeltSize);
        g.DrawLine(Pens.Blue, 0, 6 * heightBeltSize, ctrlSize.Width, 6 * heightBeltSize);
        // 有効線縦は有効線横と同じになる
      }
      // 描画
      pictureBox1.Image = canvas;
#endif
      #endregion

      // 四つ角
      leftUpClick = clickPosition.X <= ctrlSize.Width / 4 && clickPosition.Y <= ctrlSize.Height / 5;
      rightUpClick = clickPosition.X >= ctrlSize.Width - ctrlSize.Width / 4 && clickPosition.Y <= ctrlSize.Height / 5;
      leftDownClick = clickPosition.X <= ctrlSize.Width / 4 && clickPosition.Y >= ctrlSize.Height - ctrlSize.Height / 5;
      rightDownClick = clickPosition.X >= ctrlSize.Width - ctrlSize.Width / 4 && clickPosition.Y >= ctrlSize.Height - ctrlSize.Height / 5;

      // 上側の有効縦幅判定
      upSideClick = clickPosition.X >= beginWidthBelt && clickPosition.X <= endWidthBelt && clickPosition.Y <= beginHeightBelt;
      // 下側の有効縦幅判定
      downSideClick = clickPosition.X >= beginWidthBelt && clickPosition.X <= endWidthBelt && clickPosition.Y >= endHeightBelt;
      // 右側の有効縦幅判定
      rightSideClick = clickPosition.Y >= beginHeightBelt && clickPosition.Y <= endHeightBelt && clickPosition.X >= ctrlSize.Width / 2;
      // 左側の有効縦幅判定
      leftSideClick = clickPosition.Y >= beginHeightBelt && clickPosition.Y <= endHeightBelt && clickPosition.X <= ctrlSize.Width / 2;
    }
    #endregion


    #region XML読み込みメソッド
    /// <summary>
    /// XML読み込みメソッド
    /// </summary>
    /// <param name="tgtPath">対象パス</param>
    private void ReadXml(string tgtPath)
    {
      // ディクショナリクリア
      DicImgPath.Clear();

      /* StringReader設定 */
      XmlReaderSettings setting = new XmlReaderSettings();
      // コメントを無視するかどうか
      // ※デフォルトもfalseだがサンプルのため明示的に設定
      setting.IgnoreComments = false;
      // 処理命令(スタイルシートの宣言等)を無視するかどうか
      // ※デフォルトもfalseだがサンプルのため明示的に設定
      setting.IgnoreProcessingInstructions = false;
      // 意味のない空白を無視するかどうか
      setting.IgnoreWhitespace = true;

      // ファイルからXmlReaderでXMLを取得
      using (XmlReader xmlReader = XmlReader.Create(new StreamReader(tgtPath), setting))
      {
        // ルートタグへ移動
        bool root = xmlReader.ReadToFollowing("Root");
        // ねずみ返し_対象タグが存在しない場合
        if (!root)
        {
          return;
        }

        // 「add」タグを巡回
        int i = 0;
        while (xmlReader.Read())
        {
          // 最初の属性「Key」へ
          xmlReader.MoveToFirstAttribute();
          string keyName = xmlReader.Value;
          // ねずみ返し_キーの値が違う場合
          if (!Regex.Match(keyName, @"ImgFilePath").Success)
          {
            continue;
          }

          // 二番目の属性「value」へ
          xmlReader.MoveToNextAttribute();
          string keyValue = xmlReader.Value;

          // ディクショナリ追加        
          DicImgPath.Add(i, keyValue);
          ++i;
        }
      }
    }
    #endregion

    #region XML保存メソッド
    /// <summary>
    /// XML保存メソッド
    /// </summary>
    /// <param name="outDirPath">出力フォルダパス</param>
    /// <param name="outFileName">出力ファイル名</param>
    public void SaveXml(string outDirPath, string outFileName)
    {
      // 現在時刻取得
      DateTime now = DateTime.Now;
      string outputDate = now.ToString("yyyyMMddHHmmssfff");
      string outputFileName = outDirPath + @"\" + outFileName + "_" + outputDate + ".xml";

      // 出力用変数
      string outStr = string.Empty;
      string imgFileFormat = "  <add key=\"ImgFilePath\" value=\"{0}\"/>";
      // XML用
      string xmlDec = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
      string xmlRootStart = "<Root>";
      string xmlRootEnd = "</Root>";

      // チェックファイルループ
      foreach (int x in fmFileList.lvFileList.CheckedIndices)
      {
        // チェックのあるイメージファイルパス
        outStr += string.Format(imgFileFormat, DicImgPath[x]) + Environment.NewLine;
      }

      // 出力ファイルの作成
      // 引数:対象ファイル、上書き可不可、文字コード
      using (StreamWriter sw = new StreamWriter(outputFileName, true, Encoding.GetEncoding("UTF-8")))
      {
        sw.WriteLine(
          xmlDec + Environment.NewLine +
          xmlRootStart + Environment.NewLine +
          outStr +
          xmlRootEnd
          );
      }
    }
    #endregion
  }
}
