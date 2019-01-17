using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Reflection;

namespace WFA
{
  /// <summary>
  /// コントローラフォーム
  /// </summary>
  public partial class FrmOption : Form
  {
    #region コンストラクタ
    public FrmOption()
    {
      InitializeComponent();

      // タイトル設定
      this.Text = "Option";
    }
    #endregion


    #region 宣言

    // 値連携クラスインスタンス取得
    TgtFrameLogic tgtFrameLogic = TgtFrameLogic.GetInstance();

    // プレビュフォーム取得
    FrmPreview fmPreview = FrmPreview.GetInstance();

    #endregion

    #region プロパティ

    /// <summary>
    /// 親フォーム
    /// </summary>
    public FrmTgtFrame frmTgtFrame { get; set; }

    #endregion


    /* イベント */
    #region フォームロードイベント
    private void Form2_Load(object sender, EventArgs e)
    {
      // テストポイント座標を初期化
      lbTestPoint.Text = "";

      // タスクバーにアイコンを表示しない
      this.ShowInTaskbar = false;
      // 始点ラジオボックスにチェック
      rbLeftTop.Checked = true;
      // 共通プロパティ設定
      tgtFrameLogic.IsChkLeftTop = true;

      // 移動距離アップダウン初期値
      nudMoveDist.Text = tgtFrameLogic.MoveDist.ToString();

      // プレビュ枠線色ディクショナリ初期値設定
      tgtFrameLogic.AddDicPreViewFrameColor("Green", Color.Green);
      tgtFrameLogic.AddDicPreViewFrameColor("Black", Color.Black);
      tgtFrameLogic.AddDicPreViewFrameColor("White", Color.White);
      tgtFrameLogic.AddDicPreViewFrameColor("Blue", Color.Blue);
      // コンボボックスの値に変換
      string[] previewBackColorKeys = new string[tgtFrameLogic.DicPreViewFrameColor.Keys.Count];
      tgtFrameLogic.DicPreViewFrameColor.Keys.CopyTo(previewBackColorKeys, 0);
      cbPreviewBackColor.Items.AddRange(previewBackColorKeys);
      cbPreviewBackColor.SelectedIndex = 0;

      // キャプチャファイル種類
      string[] capFileExKeys = new string[tgtFrameLogic.DicImgEx.Keys.Count];
      tgtFrameLogic.DicImgEx.Keys.CopyTo(capFileExKeys, 0);
      cbCapFileEx.Items.AddRange(capFileExKeys);
      cbCapFileEx.SelectedIndex = 3;

      // ラジオボタン内容更新メソッド使用
      UpdRdioBtnTxt();
      // 距離ラベル更新メソッド使用
      UpdDistLblTxt();
    }
    #endregion


    #region 開始ラジオボタン変更イベント
    private void rbLeftTop_CheckedChanged(object sender, EventArgs e)
    {
      // 自身のチェックを共通クラスに設定
      tgtFrameLogic.IsChkLeftTop = rbLeftTop.Checked;
    }
    #endregion

    #region ↑ボタン押下イベント
    private void btUp_Click(object sender, EventArgs e)
    {
      // ねずみ返し_テストポイントモードの場合
      if (tgtFrameLogic.IsTestPointMode)
      {
        return;
      }

      // 移動にチェックの場合
      if (cbIsMove.Checked)
      {
        // 上へ移動
        tgtFrameLogic.LeftTopY -= (int)nudMoveDist.Value;
        tgtFrameLogic.RightBottomY -= (int)nudMoveDist.Value;
      }
      else
      {
        // 底辺を上へ縮小
        tgtFrameLogic.RightBottomY -= (int)nudMoveDist.Value;
      }

      // ラジオボタン内容更新メソッド使用
      UpdRdioBtnTxt();
      // 距離ラベル更新メソッド使用
      UpdDistLblTxt();

      // 対象正方形描画メソッド使用
      tgtFrameLogic.DrawSquare(frmTgtFrame);

      // プレビュフォームが表示されている場合
      if (fmPreview.Visible)
      {
        // ピクチャボックス画像更新メソッド使用
        fmPreview.UpdPicBoxImg();
      }
    }
    #endregion

    #region ↓ボタン押下イベント
    private void btDown_Click(object sender, EventArgs e)
    {
      // ねずみ返し_テストポイントモードの場合
      if (tgtFrameLogic.IsTestPointMode)
      {
        return;
      }

      // 移動にチェックの場合
      if (cbIsMove.Checked)
      {
        // 下へ移動
        tgtFrameLogic.LeftTopY += (int)nudMoveDist.Value;
        tgtFrameLogic.RightBottomY += (int)nudMoveDist.Value;
      }
      else
      {
        // 底辺を下へ拡大
        tgtFrameLogic.RightBottomY += (int)nudMoveDist.Value;
      }

      // ラジオボタン内容更新メソッド使用
      UpdRdioBtnTxt();
      // 距離ラベル更新メソッド使用
      UpdDistLblTxt();

      // 対象正方形描画メソッド使用
      tgtFrameLogic.DrawSquare(frmTgtFrame);

      // プレビュフォームが表示されている場合
      if (fmPreview.Visible)
      {
        // ピクチャボックス画像更新メソッド使用
        fmPreview.UpdPicBoxImg();
      }
    }
    #endregion

    #region ←ボタン押下イベント
    private void btLeft_Click(object sender, EventArgs e)
    {
      // ねずみ返し_テストポイントモードの場合
      if (tgtFrameLogic.IsTestPointMode)
      {
        return;
      }

      // 移動にチェックの場合
      if (cbIsMove.Checked)
      {
        // 左へ移動
        tgtFrameLogic.LeftTopX -= (int)nudMoveDist.Value;
        tgtFrameLogic.RightBottomX -= (int)nudMoveDist.Value;
      }
      else
      {
        // 右辺を左へ縮小
        tgtFrameLogic.RightBottomX -= (int)nudMoveDist.Value;
      }

      // ラジオボタン内容更新メソッド使用
      UpdRdioBtnTxt();
      // 距離ラベル更新メソッド使用
      UpdDistLblTxt();

      // 対象正方形描画メソッド使用
      tgtFrameLogic.DrawSquare(frmTgtFrame);

      // プレビュフォームが表示されている場合
      if (fmPreview.Visible)
      {
        // ピクチャボックス画像更新メソッド使用
        fmPreview.UpdPicBoxImg();
      }
    }
    #endregion

    #region →ボタン押下イベント
    private void btRight_Click(object sender, EventArgs e)
    {
      // ねずみ返し_テストポイントモードの場合
      if (tgtFrameLogic.IsTestPointMode)
      {
        return;
      }

      // 移動にチェックの場合
      if (cbIsMove.Checked)
      {
        // 右へ移動
        tgtFrameLogic.LeftTopX += (int)nudMoveDist.Value;
        tgtFrameLogic.RightBottomX += (int)nudMoveDist.Value;
      }
      else
      {
        // 右辺を右へ拡大
        tgtFrameLogic.RightBottomX += (int)nudMoveDist.Value;
      }

      // ラジオボタン内容更新メソッド使用
      UpdRdioBtnTxt();
      // 距離ラベル更新メソッド使用
      UpdDistLblTxt();

      // 対象正方形描画メソッド使用
      tgtFrameLogic.DrawSquare(frmTgtFrame);

      // プレビュフォームが表示されている場合
      if (fmPreview.Visible)
      {
        // ピクチャボックス画像更新メソッド使用
        fmPreview.UpdPicBoxImg();
      }
    }
    #endregion

    #region プレビュバックカラーコンボボックス値変更イベント
    private void cbReviewBackColor_SelectedIndexChanged(object sender, EventArgs e)
    {
      // 選択した内容を境界色として設定
      tgtFrameLogic.BoundaryColor = tgtFrameLogic.DicPreViewFrameColor[cbPreviewBackColor.SelectedItem.ToString()];

      // プレビュフォームが表示されている場合
      if (fmPreview.Visible)
      {
        // ピクチャボックス画像更新メソッド使用
        fmPreview.UpdPicBoxImg();
      }
    }
    #endregion

    #region キャプチャ画像拡張子コンボボックス変更イベント
    private void cbCapFileEx_SelectedIndexChanged(object sender, EventArgs e)
    {
      // 選択した内容をキャプチャ画像拡張子として設定
      tgtFrameLogic.CapImgEx = tgtFrameLogic.DicImgEx[cbCapFileEx.SelectedItem.ToString()];
    }
    #endregion


    #region フォームクロージングイベント
    private void Form2_FormClosing(object sender, FormClosingEventArgs e)
    {
      // クローズキャンセル
      if (e.CloseReason == CloseReason.UserClosing)
        e.Cancel = true;
    }
    #endregion


    /* コンテキスト */
    #region コンテキスト_不透明度押下イベント
    private void toolStripMenuItemOpacity_Click(object sender, EventArgs e)
    {
      // デフォルトに戻す
      this.Opacity = 0.8;
    }
    #endregion

    #region コンテキスト_上げ押下イベント
    private void toolStripMenuItemOpacityGain_Click(object sender, EventArgs e)
    {
      // 不透明度が0.8以上なら
      if (this.Opacity >= 0.8)
      {
        // ※Graphicsで黒塗りつぶしをしていると
        //   不透明度を100%から下げたあとにとなぜか色が元に戻ってしまうため最大99%とする
        this.Opacity = 0.99;
        return;
      }

      // 不透明度を上げる
      this.Opacity += 0.2;
    }
    #endregion

    #region コンテキスト_下げ押下イベント
    private void toolStripMenuItemOpacityDec_Click(object sender, EventArgs e)
    {
      // 不透明度を下げる
      this.Opacity -= 0.2;

      // 不透明度が0.1以下なら
      if (this.Opacity <= 0.1)
      {
        // 不透明度を0%にするとフォームが非表示扱いとなってしまうため
        this.Opacity = 0.01;
      }
    }
    #endregion

    #region コンテキスト_透明押下イベント
    private void ToolStripMenuItemOpacityTransparent_Click(object sender, EventArgs e)
    {
      // 不透明度を0%にするとフォームが非表示扱いとなってしまうため
      this.Opacity = 0.01;
    }
    #endregion


    /* パブリックメソッド */
    #region ラジオボタン内容更新メソッド
    /// <summary>
    /// ラジオボタン内容更新メソッド
    /// </summary>
    public void UpdRdioBtnTxt()
    {
      // 始点終点座標更新
      rbLeftTop.Text = tgtFrameLogic.LeftTopX + "×" + tgtFrameLogic.LeftTopY;
      rbRightBottom.Text = tgtFrameLogic.RightBottomX + "×" + tgtFrameLogic.RightBottomY;
    }
    #endregion

    #region ラジオボタンチェック更新メソッド
    /// <summary>
    /// ラジオボタンチェック更新メソッド
    /// </summary>
    public void UpdRdioBtnChk()
    {
      // 始点がチェックされている場合
      if (rbLeftTop.Checked)
      {
        // 終点にチェック
        rbRightBottom.Checked = true;
      }
      else
      {
        rbLeftTop.Checked = true;
      }
    }
    #endregion

    #region 距離ラベル更新メソッド
    /// <summary>
    /// 距離ラベル更新メソッド
    /// </summary>
    public void UpdDistLblTxt()
    {
      // 水平距離
      lbHorizonDist.Text = Math.Abs(tgtFrameLogic.RightBottomX - tgtFrameLogic.LeftTopX).ToString();
      // 垂直距離
      lbVerticalDist.Text = Math.Abs(tgtFrameLogic.RightBottomY - tgtFrameLogic.LeftTopY).ToString();
    }
    #endregion

    #region テストポイントラベル更新メソッド
    /// <summary>
    /// テストポイントラベル更新メソッド
    /// </summary>
    public void UpdTestPointLblTxt()
    {
      // テストポイントモードでない場合
      if (!tgtFrameLogic.IsTestPointMode)
      {
        // テストポイントラベル初期化
        lbTestPoint.Text = "";

        return;
      }

      // テストポイントラベル更新
      lbTestPoint.Text = tgtFrameLogic.TestPoint.X.ToString() + "×" + tgtFrameLogic.TestPoint.Y.ToString();
    }
    #endregion


    /* プライベートメソッド */
    #region 全カラーリスト取得メソッド
    private ArrayList GetAllColorList()
    {
      ArrayList ColorList = new ArrayList();

      // カラーリストを全て取得
      Type colorType = typeof(Color);
      PropertyInfo[] propInfoList = colorType.GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public);
      foreach (PropertyInfo x in propInfoList)
      {
        ColorList.Add(x.Name);
      }

      return ColorList;
    }
    #endregion
  }
}