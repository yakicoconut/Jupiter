//#define TEST01 // ロードイベント参照
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
      currentZeroPoint = new Point(defLocationX, defLocationY);

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
      zoomOutRatio = double.Parse(_comLogic.GetConfigValue("ZoomOutRatio", "0.5"));

      // 拡大/縮小モードキー
      modeZoomKey = _comLogic.GetConfigValue("ModeZoomKey", "Shift").ToLower();
      // モードページ送りキー
      modePageEjectKey = _comLogic.GetConfigValue("ModePageEjectKey", "Ctrl").ToLower();
      // モード0ポイントキー
      modeZeroPointKey = _comLogic.GetConfigValue("ModeZeroPointKey", "Alt").ToLower();
      // チェックキー
      chkImgKey = _comLogic.GetConfigValue("CheckImgKey", "Enter").ToLower();

      // 対象拡張子
      targetExtension = _comLogic.GetConfigValue("TargetExtension", ".jpg,.jepg,.png,.tiff,.gif,.bmp").Split(',');

          
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

    // 対象拡張子
    string[] targetExtension;

    // オプションフォーム開始位置
    int defOptionFmLocationX;
    int defOptionFmLocationY;

    // ファイルリストフォーム開始位置
    int defFileListFmLocationX;
    int defFileListFmLocationY;

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
      this.Location = currentZeroPoint;

      // フォームサイズ
      this.Width = defFormWidth;
      this.Height = defFormHeight;
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
      fmOption.nudZoomOutRatio.Text = zoomOutRatio.ToString();
      fmOption.nudUpDist.Text = upMoveDistance.ToString();
      fmOption.nudDownDist.Text = downMoveDistance.ToString();
      fmOption.nudLeftDist.Text = leftMoveDistance.ToString();
      fmOption.nudRightDist.Text = rightMoveDistance.ToString();
      // フォーム2呼び出し
      fmOption.Show();

      // ファイルリストフォームのプロパティに本クラスを設定
      fmFileList.parentForm = this;
      // 常にメインフォームの手前に表示
      fmFileList.Owner = this;
      // 開始位置
      fmFileList.StartPosition = FormStartPosition.Manual;
      fmFileList.Location = new Point(defFileListFmLocationX, defFileListFmLocationY);
      // ファイルリストフォーム呼び出し
      fmFileList.Show();
      // リストビュー設定
      fmFileList.lvFileList.HideSelection = false;

      #region TEST01_サンプル画像を使用したデバッグ
#if TEST01

      // ファイル読み込みメソッド使用
      ReadFile(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\MyResorce\TestImg\01.JPG");

#endif
      #endregion
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


    #region ファイル読み込みメソッド
    private void ReadFile(string dropItem)
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
        // ドロップされたアイテムからフォルダを取得
        targetDirPath = Path.GetDirectoryName(dropItem);
      }

      // 対象フォルダの中身をすべて取得
      string[] files = Directory.GetFiles(targetDirPath, "*", SearchOption.TopDirectoryOnly);
      // 大文字小文字を区別しない序数比較で並び替える
      StringComparer cmp = StringComparer.OrdinalIgnoreCase;
      Array.Sort(files, cmp);

      // 画像パスディクショナリに変換
      int i = 0;
      foreach (string x in files)
      {
        // ねずみ返し_拡張子が設定したものではないときは次のループへ
        if (Array.IndexOf(targetExtension, Path.GetExtension(x).ToLower()) == -1)
        {
          continue;
        }

        dicImgPath.Add(i, x);
        i = i + 1;
      }
      // 最終ページ数を設定
      maxImageKey = files.Length - 2;

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
      // 表示対象画像取得
      currentImage = new Bitmap(dicImgPath[currentImageKey]);

      fmOption.tbFileName.Text = Path.GetFileName(dicImgPath[currentImageKey]);

      // 初期化用設定
      drawRectangle = new Rectangle(currentZeroPoint.X, currentZeroPoint.Y, (int)Math.Round(currentImage.Width * currentZoomRatio), (int)Math.Round(currentImage.Height * currentZoomRatio));

      // 画像を表示する
      pictureBox1.Invalidate();
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
        // 現在倍率にズームアウト倍率を掛ける
        currentZoomRatio = currentZoomRatio * zoomOutRatio;

        // チェックの場合
        if (fmOption.cbIsModeZeroPoint.Checked)
        {
          // 縮小の場合は画像の位置を戻す(画像位置によっては画面からいなくなる事があるため)
          currentZeroPoint = new Point(0, 0);
        }
        else
        {
          // 現在の(0, 0)の位置を縮小後も引き継ぐ
          currentZeroPoint = new Point((int)(currentZeroPoint.X * zoomOutRatio), (int)(currentZeroPoint.Y * zoomOutRatio));
        }

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


    #region 雛形メソッド
    private void template()
    {

    }
    #endregion
  }
}
