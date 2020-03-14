#define TEST01 // ロードイベント参照
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

      // 他クラスのプロパティに本クラスを設定
      form2.form1 = this;

      // コマンドライン引数取得
      string[] cmdArgs = Environment.GetCommandLineArgs();
      // 引数がある場合(自身のexeパスが1つ目なので2以上のとき)
      if (cmdArgs.Length >= 2)
      {
        // ドラッグ&ドロップされたファイルの一つ目を取得
        string dropItem = Environment.GetCommandLineArgs()[1];
        //// ファイル読み込みメソッド使用
        //ReadFile(dropItem);
      }

      // コンフィグ取得メソッド使用
      GetConfig();

      // コントロール初期設定メソッド使用
      ControlInitSeting();
    }
    #endregion

    #region コンフィグ取得メソッド
    public void GetConfig()
    {
      // 初期フォーム位置
      currentZeroPoint = new Point(int.Parse(ConfigurationManager.AppSettings["DefaultLocationX"]), int.Parse(ConfigurationManager.AppSettings["DefaultLocationY"]));
      // 初期フォームサイズ
      defaultFormWidth = int.Parse(ConfigurationManager.AppSettings["DefaultFormWidth"]);
      defaultFormHeight = int.Parse(ConfigurationManager.AppSettings["DefaultFormHeight"]);
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
      modeZoomKey = ConfigurationManager.AppSettings["ModeZoomKey"];
      // モードページ送りキー
      modePageEjectKey = ConfigurationManager.AppSettings["ModePageEjectKey"];
      // モード0ポイントキー
      modeZeroPointKey = ConfigurationManager.AppSettings["ModeZeroPointKey"];
    }
    #endregion

    #region 宣言

    //フォーム2インスタンス生成
    Form2 form2 = new Form2();

    // 初期フォームサイズ
    int defaultFormWidth;
    int defaultFormHeight;

    // 表示対象画像
    private Bitmap currentImage;
    // 画像パスディクショナリ
    Dictionary<int, string> dicImgPath = new Dictionary<int, string>();
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
    double zoomInRatio;
    //ズームアウト倍率
    double zoomOutRatio;

    // 各移動距離
    int upMoveDistance;
    int downMoveDistance;
    int rightMoveDistance;
    int leftMoveDistance;

    // 拡大/縮小モードキー
    string modeZoomKey;
    // モードページ送りキー
    string modePageEjectKey;
    // モード0ポイントキー
    string modeZeroPointKey;

    #endregion

    #region コントロール初期設定メソッド
    public void ControlInitSeting()
    {
      // フォームサイズの変更
      this.Width = defaultFormWidth;
      this.Height = defaultFormHeight;
      // モードキーチェックボックステキスト設定
      form2.cbIsModeZoom.Text = string.Format("拡張/縮小({0})", modeZoomKey);
      form2.cbIsModePageEject.Text = string.Format("ページ送り({0})", modePageEjectKey);
      form2.cbIsModeZeroPoint.Text = string.Format("0Point({0})", modeZeroPointKey);
    }
    #endregion


    #region ロードイベント
    private void Form1_Load(object sender, EventArgs e)
    {
      //常にメインフォームの手前に表示
      form2.Owner = this;
      //フォーム2呼び出し
      form2.Show();

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
      // コントロールの場合
      if (e.Control)
      {
        // チェック
        form2.cbIsModePageEject.Checked = !form2.cbIsModePageEject.Checked;
        return;
      }

      // シフトの場合
      if (e.Shift)
      {
        form2.cbIsModeZoom.Checked = !form2.cbIsModeZoom.Checked;
        return;
      }

      // 押下キー振り分け
      switch (e.KeyCode)
      {
        #region ↑
        case Keys.Up:
          // シフトチェックの場合
          if (form2.cbIsModeZoom.Checked)
          {
            // 現在倍率を倍にする
            currentZoomRatio = currentZoomRatio * zoomInRatio;

            // 現在の(0, 0)の位置を拡大後も引き継ぐ
            currentZeroPoint = new Point((int)(currentZeroPoint.X * zoomInRatio), (int)(currentZeroPoint.Y * zoomInRatio));

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
          break;
        #endregion

        #region ↓
        case Keys.Down:
          // シフトチェックの場合
          if (form2.cbIsModeZoom.Checked)
          {
            // 現在倍率にズームアウト倍率を掛ける
            currentZoomRatio = currentZoomRatio * zoomOutRatio;

            // チェックの場合
            if (form2.cbIsModeZeroPoint.Checked)
            {
              // 縮小の場合は画像の位置を戻す(画像位置によっては画面からいなくなる事があるため)
              currentZeroPoint = new Point(0, 0);
            }
            else
            {
              // 現在の(0, 0)の位置を縮小後も引き継ぐ
              currentZeroPoint = new Point((int)(currentZeroPoint.X * zoomOutRatio), (int)(currentZeroPoint.Y * zoomOutRatio));
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
          break;
        #endregion

        #region →
        case Keys.Right:
          // コントロールチェックの場合
          if (form2.cbIsModePageEject.Checked)
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
              currentImageKey = currentImageKey + 1;
            }

            // 表示画像取得
            currentImage = new Bitmap(dicImgPath[currentImageKey]);

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
          break;
        #endregion

        #region ←
        case Keys.Left:
          // コントロールチェックの場合
          if (form2.cbIsModePageEject.Checked)
          {
            // 現ページが最初の場合
            if (currentImageKey == 1)
            {
              currentImageKey = maxImageKey;
            }
            else
            {
              // 左のページへ
              currentImageKey = currentImageKey - 1;
            }

            // 表示画像取得
            currentImage = new Bitmap(dicImgPath[currentImageKey]);

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
          break;
        #endregion

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


    #region ファイル読み込みメソッド
    private void ReadFile(string dropItem)
    {
      // すでに読み込まれているものがある場合
      if (dicImgPath.Count >= 1)
      {
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
        i = i + 1;
        dicImgPath.Add(i, x);
      }
      // 最終ページ数を設定
      maxImageKey = files.Length;

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

      // 初期化用設定
      drawRectangle = new Rectangle(currentZeroPoint.X, currentZeroPoint.Y, (int)Math.Round(currentImage.Width * initZoomRatio), (int)Math.Round(currentImage.Height * initZoomRatio));

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


    #region 雛形メソッド
    public void template()
    {

    }
    #endregion
  }
}
