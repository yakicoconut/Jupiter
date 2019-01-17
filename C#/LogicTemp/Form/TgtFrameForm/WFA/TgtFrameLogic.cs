using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/*
 * ・複数のクラスから呼び出すためインスタンスの生成は
 *   シングルトンデザインパターンを使用する
 */
namespace WFA
{
  class TgtFrameLogic
  {
    #region シングルトンパターン

    // シングルトン用インスタンス生成
    private static TgtFrameLogic instance = new TgtFrameLogic();

    /// <summary>
    /// シングルトンインスタンス引継メソッド
    /// </summary>
    /// <returns></returns>
    public static TgtFrameLogic GetInstance()
    {
      return instance;
    }

    #endregion

    #region コンストラクタ
    private TgtFrameLogic()
    {
      // プレビュ枠線色ディクショナリ
      DicPreViewFrameColor = new Dictionary<string, Color>();

      // 画像拡張子ディクショナリ
      DicImgEx = new Dictionary<string, ImageFormat>();
      // 値は基本的に固定(増えない)のためここで設定
      DicImgEx.Add("bmp", ImageFormat.Bmp);
      DicImgEx.Add("gif", ImageFormat.Gif);
      DicImgEx.Add("jpg", ImageFormat.Jpeg);
      DicImgEx.Add("png", ImageFormat.Png);
      DicImgEx.Add("tiff", ImageFormat.Tiff);
    }
    #endregion


    #region プロパティ

    /// <summary>
    /// 始点X座標
    /// </summary>
    public int LeftTopX { get; set; }

    /// <summary>
    /// 始点Y座標
    /// </summary>
    public int LeftTopY { get; set; }

    /// <summary>
    /// 終点X座標
    /// </summary>
    public int RightBottomX { get; set; }

    /// <summary>
    /// 終点Y座標
    /// </summary>
    public int RightBottomY { get; set; }

    /// <summary>
    /// 対象正方形色
    /// </summary>
    public Color SquareColor { get; set; }

    /// <summary>
    /// 境界色
    /// </summary>
    public Color BoundaryColor { get; set; }

    /// <summary>
    /// テストポイントモードフラグ
    /// </summary>
    public bool IsTestPointMode { get; set; }

    /// <summary>
    /// テスト座標
    /// </summary>
    public Point TestPoint { get; set; }

    /// <summary>
    /// ズーム倍率
    /// </summary> 
    public double ZoomRatio { get; set; }

    /// <summary>
    /// 始点判断フラグ
    /// </summary> 
    public bool IsChkLeftTop { get; set; }

    /// <summary>
    /// プレビュ枠線色ディクショナリ
    /// 外部からの値設定は専用メソッドを使用する
    /// </summary>
    public Dictionary<string, Color> DicPreViewFrameColor { get; private set; }

    /// <summary>
    /// 移動距離
    /// </summary> 
    public int MoveDist { get; set; }

    /// <summary>
    /// 対象画面範囲取得フォーム不透明度
    /// </summary> 
    public double TgtFrameOpacity { get; set; }

    /// <summary>
    /// キャプチャ保存フォルダ名称
    /// </summary> 
    public string CaptureDirName { get; set; }

    /// <summary>
    /// キャプチャ画像拡張子ディクショナリ
    /// </summary>
    public Dictionary<string, ImageFormat> DicImgEx { get; private set; }

    /// <summary>
    /// キャプチャ画像拡張子
    /// </summary>
    public ImageFormat CapImgEx { get; set; }

    /// <summary>
    /// キャプチャファイル名
    /// </summary>
    public string CaptureFileName { get; set; }

    #endregion


    #region 対象正方形描画メソッド
    /// <summary>
    /// 対象正方形描画メソッド
    /// </summary>
    /// <param name="targetFrm">描画対象フォーム</param>
    public void DrawSquare(Form targetFrm)
    {
      // Graphicsオブジェクトの作成
      using (Graphics g = targetFrm.CreateGraphics())
      {
        // 色を初期化
        g.Clear(SystemColors.Control);

        // 直線型のインスタンス生成
        Pen frontCoverPen = new Pen(SquareColor, 1);

        // 表紙lineの始点と終点を設定
        Point leftTop = new Point(LeftTopX, LeftTopY);
        Point rightButtom = new Point(RightBottomX, RightBottomY);
        // 右上と左下は始点と終点の値をそのまま使用できる
        Point rightTop = new Point(RightBottomX, LeftTopY);
        Point leftButtom = new Point(LeftTopX, RightBottomY);

        // 正方形描画
        g.DrawLine(frontCoverPen, leftTop, rightTop);
        g.DrawLine(frontCoverPen, leftTop, leftButtom);
        g.DrawLine(frontCoverPen, rightButtom, rightTop);
        g.DrawLine(frontCoverPen, rightButtom, leftButtom);
      }
    }
    #endregion

    #region スクリーンコピーメソッド
    /// <summary>
    /// スクリーンコピーメソッド
    /// </summary>
    public Bitmap CopyScreen()
    {
      // 対象ポイントからサイズを取得
      int width = Math.Abs(RightBottomX - LeftTopX);
      int height = Math.Abs(RightBottomY - LeftTopY);

      // ビットマップ作成(境界線分確保)
      Bitmap bmp = new Bitmap(width + 10, height + 10);
      // Graphicsオブジェクトの作成
      using (Graphics g = Graphics.FromImage(bmp))
      {
        // 境界色設定
        g.Clear(BoundaryColor);

        // 画像表示
        g.CopyFromScreen(new Point(LeftTopX, LeftTopY), new Point(5, 5), new Size(width, height));
      }

      return bmp;
    }
    #endregion

    #region テストポイント描画メソッド
    /// <summary>
    /// テストポイント描画メソッド
    /// </summary>
    /// <param name="targetFrm">描画対象フォーム</param>
    public void DrawTestPoint(Form targetFrm)
    {
      // Graphicsオブジェクトの作成
      using (Graphics g = targetFrm.CreateGraphics())
      {
        // 白点画像を作成
        Bitmap p = new Bitmap(1, 1);
        p.SetPixel(0, 0, Color.White);

        // 点描画
        g.DrawImageUnscaled(p, TestPoint);
      }
    }
    #endregion

    #region プレビュ枠線色ディクショナリ値追加メソッド
    public void AddDicPreViewFrameColor(string key, Color color)
    {
      // ねずみ返し_追加キーが既に存在する場合
      if (DicPreViewFrameColor.ContainsKey(key))
      {
        return;
      }

      // 値追加
      DicPreViewFrameColor.Add(key, color);
    }
    #endregion
  }
}
