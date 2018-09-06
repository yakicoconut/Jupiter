//#define DEBUG01 // ロードイベント参照
//#define DEBUG02 // クリック操作有効幅表示
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
using System.Collections;
using System.Threading;

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
      upMoveDistance = int.Parse(_comLogic.GetConfigValue("UpMoveDistance", "1"));
      downMoveDistance = int.Parse(_comLogic.GetConfigValue("DownMoveDistance", "1"));
      rightMoveDistance = int.Parse(_comLogic.GetConfigValue("RightMoveDistance", "1"));
      leftMoveDistance = int.Parse(_comLogic.GetConfigValue("LeftMoveDistance", "1"));
      // 倍率関連
      initZoomRatio = double.Parse(_comLogic.GetConfigValue("InitZoomRatio", "1.0"));
      zoomInRatio = double.Parse(_comLogic.GetConfigValue("ZoomInRatio", "2.0"));
      zoomOutRatio = double.Parse(_comLogic.GetConfigValue("ZoomOutRatio", "2.0"));

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
      targetExtension = _comLogic.GetConfigValue("TargetExtension", ".jpg,.jepg,.png,.tiff,.gif,.bmp").Split(',');

      // ファイル読み込み対象範囲
      targetRange = _comLogic.GetConfigValue("TargetRange", "OnlyCurrent");


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
    }
    #endregion


    #region 宣言

    // 共通ロジッククラスインスタンス
    MCSComLogic _comLogic = new MCSComLogic();

    // オプションフォームインスタンス生成
    FrmOption fmOption = new FrmOption();
    // ファイルリストフォームインスタンス生成
    FrmFileList fmFileList = new FrmFileList();

    // 初期フォームサイズ
    int defFormWidth;
    int defFormHeight;
    // 初期フォーム位置
    int defLocationX;
    int defLocationY;

    // 表示対象画像
    private Bitmap currentImage;
    // 画像パスディクショナリ
    public Dictionary<int, string> dicImgPath = new Dictionary<int, string>();
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
    string[] targetExtension;

    // ファイル読み込み対象範囲
    string targetRange;

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
    public int currentImageKey { get; set; }

    /// <summary>
    /// ズームイン倍率
    /// </summary>
    public double zoomInRatio { get; set; }
    /// <summary>
    /// ズームアウト倍率
    /// </summary>
    public double zoomOutRatio { get; set; }

    /// <summary>
    /// 上移動距離
    /// </summary>
    public int upMoveDistance { get; set; }
    /// <summary>
    /// 下移動距離
    /// </summary>
    public int downMoveDistance { get; set; }
    /// <summary>
    /// 左移動距離
    /// </summary>
    public int leftMoveDistance { get; set; }
    /// <summary>
    /// 右移動距離
    /// </summary>
    public int rightMoveDistance { get; set; }

    /// <summary>
    /// コミット先パス
    /// </summary>
    public string commitPath { get; set; }

    #endregion


    #region メインフォーム初期設定メソッド
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
      fmOption.nudZoomInRatio.Text = zoomInRatio.ToString();
      fmOption.btView.Text = string.Format("View({0})", launchViewKey);
      fmOption.nudZoomOutRatio.Text = zoomOutRatio.ToString();
      fmOption.nudUpDist.Text = upMoveDistance.ToString();
      fmOption.nudDownDist.Text = downMoveDistance.ToString();
      fmOption.nudLeftDist.Text = leftMoveDistance.ToString();
      fmOption.nudRightDist.Text = rightMoveDistance.ToString();
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
    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
      // 共通キー押下処理メソッド
      ComKeyDown(e);
    }
    #endregion


    #region コンテキスト_チェック拡張縮小押下イベント
    private void ToolStripMenuItemIsModeZoom_Click(object sender, EventArgs e)
    {
      // 拡大/縮小チェック
      fmOption.cbIsModeZoom.Checked = !fmOption.cbIsModeZoom.Checked;
    }
    #endregion

    #region コンテキスト_チェックページ送り押下イベント
    private void ToolStripMenuItemIsModePageEject_Click(object sender, EventArgs e)
    {
      // ページ送りチェック
      fmOption.cbIsModePageEject.Checked = !fmOption.cbIsModePageEject.Checked;
    }
    #endregion

    #region コンテキスト_ファイルリスト押下イベント
    private void ToolStripMenuItemFileListForm_Click(object sender, EventArgs e)
    {
      // マウスの位置にファイルリストを表示する
      fmFileList.Left = Cursor.Position.X;
      fmFileList.Top = Cursor.Position.Y;
    }
    #endregion

    #region コンテキスト_操作パネル押下イベント
    private void ToolStripMenuItemOptionForm_Click(object sender, EventArgs e)
    {
      // マウスの位置にオプションフォームを表示する
      fmOption.Left = Cursor.Position.X;
      fmOption.Top = Cursor.Position.Y;
    }
    #endregion

    #region コンテキスト_Viewアプリ起動押下イベント
    private void ToolStripMenuItemLaunchViewApp_Click(object sender, EventArgs e)
    {
      // ビュウアプリ起動メソッド使用
      LaunchView();
    }
    #endregion

    #region コンテキスト_コンフィグ押下イベント
    private void ToolStripMenuItemConfig_Click(object sender, EventArgs e)
    {
      // 自身のコンフィグファイルパス取得
      string configPath = Assembly.GetExecutingAssembly().Location + ".config";

      // コンフィグファイルを関連付けられたアプリケーションで開く
      Process p = Process.Start(configPath);
    }
    #endregion


    #region ピクチャボックスWクリックイベント
    private void pictureBox1_DoubleClick(object sender, EventArgs e)
    {
      // ピクチャボックスサイズを取得
      Size ctrlSize = pictureBox1.Size;
      // ピクチャボックス上のクリック位置取得
      Point clickPosition = pictureBox1.PointToClient(MousePosition);

      // 有効範囲クリック判断用変数
      bool upSideClick = false;
      bool downSideClick = false;
      bool rightSideClick = false;
      bool leftSideClick = false;

      // 有効範囲算出横五縦十メソッド使用
      EffectiveRangeFullTen(ctrlSize, clickPosition, out upSideClick, out downSideClick, out rightSideClick, out leftSideClick);

      // 有効範囲クリック判断
      if (upSideClick)
      {
        // 上操作メソッド使用
        UpOperation();
      }
      else if (downSideClick)
      {
        // 下操作メソッド使用
        DownOperation();
      }
      else if (rightSideClick)
      {
        // 右操作メソッド使用
        RightOperation();
      }
      else if (leftSideClick)
      {
        // 左操作メソッド使用
        LeftOperation();
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
        fmFileList.lvFileList.Items[currentImageKey].Checked = !fmFileList.lvFileList.Items[currentImageKey].Checked;
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
      // すでに読み込まれているものがある場合
      if (dicImgPath.Count >= 1)
      {
        // 初期化
        dicImgPath = new Dictionary<int, string>();
      }

      string targetDirPath = string.Empty;

      // フォルダの場合
      if (Directory.Exists(dropItem))
      {
        // ドロップされたアイテムをそのまま使用
        targetDirPath = dropItem;
      }
      else
      {
        try
        {
          // ドロップされたアイテムからフォルダを取得
          targetDirPath = Path.GetDirectoryName(dropItem);
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.ToString() + "\r\n\r\n" + dropItem);
        }
      }

      // 対象ディレクトリ取得
      DirectoryInfo dir = new DirectoryInfo(targetDirPath);
      FileInfo[] files = null;

      // ファイル読み込み対象範囲が全ファイルの場合
      if (targetRange == "TopBottom")
      {
        // 対象フォルダ以下すべてのフォルダの中身を取得
        files = dir.GetFiles("*", SearchOption.AllDirectories);
      }
      else
      {
        // 対象フォルダの中身のみ取得
        files = dir.GetFiles("*", SearchOption.TopDirectoryOnly);
      }

      /* ソート無名関数
       *   【C#】ファイル一覧をファイル名でソートする : ubichupas.net
       *      http://ubichupas.blogspot.com/2011/04/cfilesort.html
       */
      Array.Sort<FileInfo>(files, delegate(FileInfo a, FileInfo b)
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

      // 画像パスディクショナリに変換
      int i = 0;
      foreach (var x in files)
      {
        // ねずみ返し_拡張子が設定したものではないときは次のループへ
        if (Array.IndexOf(targetExtension, Path.GetExtension(x.FullName).ToLower()) == -1)
        {
          continue;
        }

        dicImgPath.Add(i, x.FullName);
        i += 1;
      }
      // 最終ページ数を設定
      maxImageKey = i - 1;

      // ドロップされたのがフォルダの場合
      if (Directory.Exists(dropItem))
      {
        // 表示するファイルのページを最初のものに設定
        currentImageKey = 0;
      }
      // ファイルが存在しない場合(移動等ファイルがないパターンを想定)
      else if (!File.Exists(dropItem))
      {
        // 表示するファイルのページを最初のものに設定
        currentImageKey = 0;
      }
      else
      {
        // 表示するファイルにドロップしたファイルを設定
        currentImageKey = dicImgPath.First(x => x.Value == dropItem).Key;
      }

      // 現在倍率に初期倍率を設定する
      currentZoomRatio = initZoomRatio;

      // 画像初期化メソッド使用
      ImgInit();

      // ファイルリストフォーム初期化メソッド使用
      InitFileListForm();

      // ファイルリストの該当ファイルを選択
      fmFileList.lvFileList.SelectedItems.Clear();
      fmFileList.lvFileList.Items[currentImageKey].Selected = true;
    }
    #endregion

    #region 画像初期化メソッド
    private void ImgInit()
    {
      // 表示する画像を読み込む
      if (currentImage != null)
      {
        currentImage.Dispose();
      }

      try
      {
        // 表示対象画像取得
        currentImage = new Bitmap(dicImgPath[currentImageKey]);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString() + "\r\n\r\nキー:" + currentImageKey);
      }

      // 初期化用設定
      drawRectangle = new Rectangle(currentZeroPoint.X, currentZeroPoint.Y, (int)Math.Round(currentImage.Width * currentZoomRatio), (int)Math.Round(currentImage.Height * currentZoomRatio));

      // 画像を表示する
      pictureBox1.Invalidate();

      // ファイル名表示
      fmOption.tbFileName.Text = Path.GetFileName(dicImgPath[currentImageKey]);
      // ファイルサイズ
      fmOption.tbFileSize.Text = drawRectangle.Width + "×" + drawRectangle.Height;
    }
    #endregion

    #region 画像ズームメソッド
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
      foreach (var x in dicImgPath)
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
      // 表示中の画像を移動するときに一旦、参照をはずす必要がある
      // 現在表示中の画像を退避する
      Bitmap evacuationImg = (Bitmap)pictureBox1.Image;
      // 表示中の画像を破棄
      if (currentImage != null)
      {
        currentImage.Dispose();
      }
      // 画像ファイルを直接参照するのではなく退避した画像を使用
      currentImage = evacuationImg;

      // チェックされたファイルを処理
      foreach (int x in fileIndex)
      {
        // ディクショナリから画像パスを取得
        string targetImgPath = dicImgPath[x];

        try
        {
          // ファイル移動
          File.Move(targetImgPath, commitPath + @"\" + Path.GetFileName(targetImgPath));
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.ToString() + "\r\n\r\n" + targetImgPath);
        }
      }

      // 現在表示している画像のフォルダを改めて読み込み
      ReadFile(dicImgPath[currentImageKey]);
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
        string targetImgPath = dicImgPath[x];

        try
        {
          // ファイル移動
          File.Copy(targetImgPath, commitPath + @"\" + Path.GetFileName(targetImgPath));
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
      // 表示中の画像を削除するときに一旦、参照をはずす必要がある
      // 現在表示中の画像を退避する
      Bitmap evacuationImg = (Bitmap)pictureBox1.Image;
      // 表示中の画像を破棄
      if (currentImage != null)
      {
        currentImage.Dispose();
      }
      // 画像ファイルを直接参照するのではなく退避した画像を使用
      currentImage = evacuationImg;

      // チェックされたファイルを処理
      foreach (int x in fileIndex)
      {
        // ディクショナリから画像パスを取得
        string targetImgPath = dicImgPath[x];

        try
        {
          // ファイル削除
          File.Delete(targetImgPath);
        }
        catch (Exception e)
        {
          MessageBox.Show(e.ToString());
        }
      }

      // 現在表示している画像のフォルダを改めて読み込み
      ReadFile(dicImgPath[currentImageKey]);
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
        // 現在倍率を倍にする
        currentZoomRatio = currentZoomRatio * zoomInRatio;

        // 現在の(0, 0)の位置を拡大後も引き継ぐ
        currentZeroPoint = new Point((int)(currentZeroPoint.X * zoomInRatio), (int)(currentZeroPoint.Y * zoomInRatio));

        // 0ポイントチェック
        if (fmOption.cbIsModeZeroPoint.Checked)
        {
          // ページ送りに伴い画像を左上に設定
          currentZeroPoint = new Point(0, 0);
        }

        // 画像ズームメソッド使用
        ImgZoom();
      }
      else
      {
        // 上に移動
        currentZeroPoint = new Point(currentZeroPoint.X + 0, currentZeroPoint.Y + upMoveDistance);

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
        // 現在倍率にズームアウト倍率を割る
        currentZoomRatio = currentZoomRatio / zoomOutRatio;

        // 現在の(0, 0)の位置を縮小後も引き継ぐ
        currentZeroPoint = new Point((int)(currentZeroPoint.X / zoomOutRatio), (int)(currentZeroPoint.Y / zoomOutRatio));

        // 0ポイントチェック
        if (fmOption.cbIsModeZeroPoint.Checked)
        {
          // 縮小の場合は画像の位置を戻す(画像位置によっては画面からいなくなる事があるため)
          currentZeroPoint = new Point(0, 0);
        }

        // 画像ズームメソッド使用
        ImgZoom();
      }
      else
      {
        // 下に移動
        currentZeroPoint = new Point(currentZeroPoint.X + 0, currentZeroPoint.Y - downMoveDistance);

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
        // 現ページが最後の場合
        if (currentImageKey == maxImageKey)
        {
          // 最初のページへ
          currentImageKey = 0;
        }
        else
        {
          // 次のページへ
          currentImageKey += 1;
        }

        // ページ送りメソッド使用
        FeedImg();

        // ファイルリストの該当ファイルを選択
        fmFileList.lvFileList.SelectedItems.Clear();
        fmFileList.lvFileList.Items[currentImageKey].Selected = true;
        // 選択ファイルがリスト上で次ページになった場合、リストをスクロール
        fmFileList.lvFileList.EnsureVisible(currentImageKey);

        // オプションフォームのチェックを表示している画像に沿って設定
        fmOption.cbChkImg.Checked = fmFileList.lvFileList.Items[currentImageKey].Checked;
      }
      else
      {
        // 右に移動
        currentZeroPoint = new Point(currentZeroPoint.X - rightMoveDistance, currentZeroPoint.Y + 0);

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
        // 現ページが最初の場合
        if (currentImageKey == 0)
        {
          currentImageKey = maxImageKey;
        }
        else
        {
          // 左のページへ
          currentImageKey -= 1;
        }

        // ページ送りメソッド使用
        FeedImg();

        // ファイルリストの該当ファイルを選択
        fmFileList.lvFileList.SelectedItems.Clear();
        fmFileList.lvFileList.Items[currentImageKey].Selected = true;
        // 選択ファイルがリスト上で前ページになった場合、リストをスクロール
        fmFileList.lvFileList.EnsureVisible(currentImageKey);

        // オプションフォームのチェックを表示している画像に沿って設定
        fmOption.cbChkImg.Checked = fmFileList.lvFileList.Items[currentImageKey].Checked;
      }
      else
      {
        // 左に移動
        currentZeroPoint = new Point(currentZeroPoint.X + leftMoveDistance, currentZeroPoint.Y + 0);

        // 移動メソッド使用
        ImgMove();
      }
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
      if (dicImgPath.Count == 0)
      {
        return;
      }

      // インスタンス生成
      ProcessStartInfo psi = new ProcessStartInfo();

      // 起動するファイルパス設定
      psi.FileName = launchViewAppPath;
      // 現在の画像パスをコマンドライン引数に設定
      // スペースで引数が分かれるためダブルクォートをつける
      psi.Arguments = "\"" + dicImgPath[currentImageKey] + "\"";

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
    private void EffectiveRangeFullTen(Size ctrlSize, Point clickPosition, out bool upSideClick, out bool downSideClick, out bool rightSideClick, out bool leftSideClick)
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


    #region 雛形メソッド
    private void template()
    {

    }
    #endregion
  }
}
