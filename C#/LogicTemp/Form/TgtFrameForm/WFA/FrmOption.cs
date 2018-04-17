using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WFA
{
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

    // 親フォーム
    public FrmTgtFrame frmTgtFrame { get; set; }

    #endregion


    #region フォームロードイベント
    private void Form2_Load(object sender, EventArgs e)
    {
      // テストポイント座標を初期化
      lbTestPoint.Text = "";
    }
    #endregion

    #region ↑ボタン押下イベント
    private void btUp_Click(object sender, EventArgs e)
    {
      // ねずみ返し_テストポイントモードの場合
      if (frmTgtFrame.isTestPointMode)
      {
        return;
      }

      // 移動にチェックの場合
      if (cbIsMove.Checked)
      {
        // 上へ移動
        frmTgtFrame.LeftTopY -= (int)nudMoveDist.Value;
        frmTgtFrame.RightBottomY -= (int)nudMoveDist.Value;
      }
      else
      {
        // 底辺を上へ縮小
        frmTgtFrame.RightBottomY -= (int)nudMoveDist.Value;
      }

      // 対象正方形描画メソッド使用
      frmTgtFrame.DrawSquare();
    }
    #endregion

    #region ↓ボタン押下イベント
    private void btDown_Click(object sender, EventArgs e)
    {
      // ねずみ返し_テストポイントモードの場合
      if (frmTgtFrame.isTestPointMode)
      {
        return;
      }

      // 移動にチェックの場合
      if (cbIsMove.Checked)
      {
        // 下へ移動
        frmTgtFrame.LeftTopY += (int)nudMoveDist.Value;
        frmTgtFrame.RightBottomY += (int)nudMoveDist.Value;
      }
      else
      {
        // 底辺を下へ拡大
        frmTgtFrame.RightBottomY += (int)nudMoveDist.Value;
      }

      // 対象正方形描画メソッド使用
      frmTgtFrame.DrawSquare();
    }
    #endregion

    #region ←ボタン押下イベント
    private void btLeft_Click(object sender, EventArgs e)
    {
      // ねずみ返し_テストポイントモードの場合
      if (frmTgtFrame.isTestPointMode)
      {
        return;
      }

      // 移動にチェックの場合
      if (cbIsMove.Checked)
      {
        // 左へ移動
        frmTgtFrame.LeftTopX -= (int)nudMoveDist.Value;
        frmTgtFrame.RightBottomX -= (int)nudMoveDist.Value;
      }
      else
      {
        // 右辺を左へ縮小
        frmTgtFrame.RightBottomX -= (int)nudMoveDist.Value;
      }

      // 対象正方形描画メソッド使用
      frmTgtFrame.DrawSquare();
    }
    #endregion

    #region →ボタン押下イベント
    private void btRight_Click(object sender, EventArgs e)
    {
      // ねずみ返し_テストポイントモードの場合
      if (frmTgtFrame.isTestPointMode)
      {
        return;
      }

      // 移動にチェックの場合
      if (cbIsMove.Checked)
      {
        // 右へ移動
        frmTgtFrame.LeftTopX += (int)nudMoveDist.Value;
        frmTgtFrame.RightBottomX += (int)nudMoveDist.Value;
      }
      else
      {
        // 右辺を右へ拡大
        frmTgtFrame.RightBottomX += (int)nudMoveDist.Value;
      }

      // 対象正方形描画メソッド使用
      frmTgtFrame.DrawSquare();
    }
    #endregion


    #region コンテキスト_不透明度押下イベント
    private void 不透明度ToolStripMenuItem_Click(object sender, EventArgs e)
    {
      //デフォルトに戻す
      this.Opacity = 0.8;
    }
    #endregion

    #region コンテキスト_上げ押下イベント
    private void 上げToolStripMenuItem_Click(object sender, EventArgs e)
    {
      //不透明度を上げる
      this.Opacity += 0.2;
    }
    #endregion

    #region コンテキスト_下げ押下イベント
    private void 下げToolStripMenuItem_Click(object sender, EventArgs e)
    {
      //不透明度を下げる
      this.Opacity -= 0.2;
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
  }
}