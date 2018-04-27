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

      // コントロール初期設定メソッド使用
      ControlInitSeting();

      // 他クラスのプロパティに本クラスを設定
      fmOption.form1 = this;

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
    public void GetConfig()
    {
      // 初期フォーム位置
      currentZeroPoint = new Point(int.Parse(ConfigurationManager.AppSettings["DefaultLocationX"]), int.Parse(ConfigurationManager.AppSettings["DefaultLocationY"]));
      // 移動距離
      upMoveDistance = int.Parse(ConfigurationManager.AppSettings["UpMoveDistance"]);
      downMoveDistance = int.Parse(ConfigurationManager.AppSettings["DownMoveDistance"]);
      rightMoveDistance = int.Parse(ConfigurationManager.AppSettings["RightMoveDistance"]);
      leftMoveDistance = int.Parse(ConfigurationManager.AppSettings["LeftMoveDistance"]);
      // 倍率関連
      initZoomRatio = double.Parse(ConfigurationManager.AppSettings["InitZoomRatio"]);
      zoomInRatio = double.Parse(ConfigurationManager.AppSettings["ZoomInRatio"]);
      zoomOutRatio = double.Parse(ConfigurationManager.AppSettings["ZoomOutRatio"]);

      // 拡大/縮小モードキー
      modeZoomKey = ConfigurationManager.AppSettings["ModeZoomKey"].ToLower();
      // モードページ送りキー
      modePageEjectKey = ConfigurationManager.AppSettings["ModePageEjectKey"].ToLower();
      // モード0ポイントキー
      modeZeroPointKey = ConfigurationManager.AppSettings["ModeZeroPointKey"].ToLower();

      // 対象拡張子
      targetExtension = ConfigurationManager.AppSettings["TargetExtension"].Split(',');
    }
    #endregion


    #region 宣言

    // オプションフォームインスタンス生成
    FrmOption fmOption = new FrmOption();

    // 初期フォームサイズ
    int defaultFormWidth;
    int defaultFormHeight;

    // 表示対象画像
    private Bitmap currentImage;
    // 画像パスディクショナリ
    public Dictionary<int, string> dicImgPath = new Dictionary<int, string>();
    // 最大ページ数
    int maxImageKey = 0;
    // 現在表示ページ数
    int currentImageKey = 0;

    // 現在の開始位置(画像の左上)
    Point currentZeroPoint;
    // 倍率変更後の画像のサイズと位置
    Rectangle drawRectangle;

    // ズーム倍率初期値
    double initZoomRatio;
    // 現在のズーム倍率
    double currentZoomRatio = 1;
    //ズームイン倍率
    public double zoomInRatio { get; set; }
    //ズームアウト倍率
    public double zoomOutRatio { get; set; }

    // 各移動距離
    public int upMoveDistance { get; set; }
    public int downMoveDistance { get; set; }
    public int rightMoveDistance { get; set; }
    public int leftMoveDistance { get; set; }

    // 拡大/縮小モードキー
    string modeZoomKey;
    // モードページ送りキー
    string modePageEjectKey;
    // モード0ポイントキー
    string modeZeroPointKey;

    // 対象拡張子
    string[] targetExtension;

    #endregion


    #region コントロール初期設定メソッド
    public void ControlInitSeting()
    {
      // アプリの開始位置
      // 開始位置をロケーションプロパティ
      this.StartPosition = FormStartPosition.Manual;
      this.Location = new Point(int.Parse(ConfigurationManager.AppSettings["DefaultLocationX"]) - 10, int.Parse(ConfigurationManager.AppSettings["DefaultLocationY"]));

      // フォームサイズの変更
      if (!int.TryParse(ConfigurationManager.AppSettings["DefaultFormWidth"], out defaultFormWidth))
      {
        // 画面サイズを取得
        defaultFormWidth = Screen.PrimaryScreen.Bounds.Width + 16;
      }
      if (!int.TryParse(ConfigurationManager.AppSettings["DefaultFormHeight"], out defaultFormHeight))
      {
        defaultFormHeight = Screen.PrimaryScreen.Bounds.Height - 30;
      }
      this.Width = defaultFormWidth;
      this.Height = defaultFormHeight;

      // モードキーチェックボックステキスト設定
      fmOption.cbIsModeZoom.Text = string.Format("拡張/縮小({0})", modeZoomKey);
      fmOption.cbIsModePageEject.Text = string.Format("ページ送り({0})", modePageEjectKey);
      fmOption.cbIsModeZeroPoint.Text = string.Format("0Point({0})", modeZeroPointKey);

      // フォーム2の開始位置
      // 開始位置をロケーションプロパティ
      fmOption.StartPosition = FormStartPosition.Manual;
      fmOption.Location = new Point(int.Parse(ConfigurationManager.AppSettings["FormTwoDefaultLocationX"]) - 10, int.Parse(ConfigurationManager.AppSettings["FormTwoDefaultLocationY"]));
    }
    #endregion


    #region ロードイベント
    private void Form1_Load(object sender, EventArgs e)
    {
      //常にメインフォームの手前に表示
      fmOption.Owner = this;

      // テキストボックス設定
      fmOption.nudZoomInRatio.Text = zoomInRatio.ToString();
      fmOption.nudZoomOutRatio.Text = zoomOutRatio.ToString();
      fmOption.nudUpDist.Text = upMoveDistance.ToString();
      fmOption.nudDownDist.Text = downMoveDistance.ToString();
      fmOption.nudLeftDist.Text = leftMoveDistance.ToString();
      fmOption.nudRightDist.Text = rightMoveDistance.ToString();

      //フォーム2呼び出し
      fmOption.Show();

      #region TEST01_サンプル画像を使用したデバッグ
#if TEST01

      // ファイル読み込みメソッド使用
      ReadFile(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\MyResorce\TestImg\01.JPG");

#endif
      #endregion
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
    public void Form1_KeyDown(object sender, KeyEventArgs e)
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
    public bool IsModeZoomKey(KeyEventArgs e)
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
    public bool IsModePageEjectKey(KeyEventArgs e)
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
    public bool IsModeZeroPointKey(KeyEventArgs e)
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

        i = i + 1;
        dicImgPath.Add(i, x);
      }
      // 最終ページ数を設定
      maxImageKey = files.Length - 1;

      // ドロップされたのがフォルダの場合
      if (Directory.Exists(dropItem))
      {
        // 表示するファイルのページを1に設定
        currentImageKey = 1;
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


    #region 上操作メソッド
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
    public void RightOperation()
    {
      // ページ送りチェック
      if (fmOption.cbIsModePageEject.Checked)
      {
        // 現ページが最後の場合
        if (currentImageKey == maxImageKey)
        {
          // 最初のページへ
          currentImageKey = 1;
        }
        else
        {
          // 次のページへ
          currentImageKey += 1;
        }

        // 表示画像取得
        currentImage = new Bitmap(dicImgPath[currentImageKey]);

        // ページ送りに伴い画像を左上に設定
        currentZeroPoint = new Point(0, 0);

        // 画像初期化メソッド使用
        ImgInit();
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
    public void LeftOperation()
    {
      // コントロールチェックの場合
      if (fmOption.cbIsModePageEject.Checked)
      {
        // 現ページが最初の場合
        if (currentImageKey == 1)
        {
          currentImageKey = maxImageKey;
        }
        else
        {
          // 左のページへ
          currentImageKey -= 1;
        }

        // 表示画像取得
        currentImage = new Bitmap(dicImgPath[currentImageKey]);

        // ページ送りに伴い画像を左上に設定
        currentZeroPoint = new Point(0, 0);

        // 画像初期化メソッド使用
        ImgInit();
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


    #region 雛形メソッド
    public void template()
    {

    }
    #endregion
  }
}
