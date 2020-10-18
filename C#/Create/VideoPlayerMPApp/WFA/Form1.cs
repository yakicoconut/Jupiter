using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using Microsoft.VisualBasic;
using System.Diagnostics;

#region ヘッダ
/*
 * 概要
 *   Media Player
 * 事前準備
 *   コントロール追加
 *     ツールボックス右クリック-[アイテムの選択]-
 *     [COMコンポーネント]タブ-[Windows Media Player]チェック-
 *     [UIMessage Dialog]展開-[Windows Media Player]コントロール
 * サイト
 *   C#でWindows Media Playerを使う - 隊長GAN-STのブログ
 *   	http://www.gan.st/gan/blog/index.php?itemid=1406
 *   C# Fromで動画再生するには - 真実の楽譜（フルスコア）
 *   	http://truthfullscore.hatenablog.com/entry/2014/03/03/120602
 *   動画再生プレイヤーを作りたいメモ - ゲームエフェクトデザイナーのブログ (新)
 *   	https://effect.hatenablog.com/entry/2018/12/12/015904
 *   【C#】AxWindowsMediaPlayerにて，再生動画をコントロールサイズに合わせる方法 | 吟遊詩人の戯言
 *   	http://gurizuri0505.halfmoon.jp/20120216/40902
 */
#endregion
namespace WFA
{
  /// <summary>
  /// メインフォーム
  /// </summary>
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

      // 取得時刻フォームインスタンス生成
      fmGetTime = new FrmGetTime(this);
    }
    #endregion

    #region コンフィグ取得メソッド
    public void GetConfig()
    {
      string hoge01 = _comLogic.GetConfigValue("Key01", "DefaultValue");
    }
    #endregion


    #region 宣言

    // 共通ロジッククラスインスタンス
    MCSComLogic _comLogic = new MCSComLogic();

    // 取得時刻フォーム
    FrmGetTime fmGetTime;

    // 現在位置
    double crntPos;

    // 改行フラグ
    bool nLFlg;

    #endregion

    #region 定数

    const double MINUTE_TO_SECOND = 60;
    const double HOUR_TO_SECOND = 3600;
    const double SECOND_TO_MSECOND = 1;
    const char CONST_CHAR_EN_COLOGNE = ':';
    const char CONST_CHAR_EN_DOT = '.';

    #endregion


    #region フォームロードイベント
    private void Form1_Load(object sender, EventArgs e)
    {
      // true :コントロールサイズに合わせる
      // false:動画サイズに合わせる
      axWindowsMediaPlayer1.stretchToFit = true;

      // 常にメインフォームの手前に表示
      fmGetTime.Owner = this;
      // 取得時刻フォーム表示
      fmGetTime.Show();
    }
    #endregion


    #region Startボタン押下イベント
    private void btStart_Click(object sender, EventArgs e)
    {
      // 指定パスの動画再生
      axWindowsMediaPlayer1.URL = textBox1.Text;
    }
    #endregion

    #region Styleボタン押下イベント
    private void btStyle_Click(object sender, EventArgs e)
    {
      // 操作パネルプロパティ
      switch (axWindowsMediaPlayer1.uiMode)
      {
        case "full":
          // mini:一部ボタン省略
          axWindowsMediaPlayer1.uiMode = "mini";
          break;

        case "mini":
          // none:操作パネルなし
          axWindowsMediaPlayer1.uiMode = "none";
          break;

        case "none":
          // full:デフォルト
          axWindowsMediaPlayer1.uiMode = "full";
          break;

        default:
          break;
      }
    }
    #endregion

    #region GetTimeボタン押下イベント
    private void btGetTime_Click(object sender, EventArgs e)
    {
      // 現在位置秒数取得
      double pos = axWindowsMediaPlayer1.Ctlcontrols.currentPosition;

      // 時刻変換メソッド使用
      string strPos = ConvSecToStringTime(pos);
      // 時刻ラベル更新
      lbTime.Text = strPos;

      // 取得位置が前回位置と±1かどうか
      bool flg = pos - 1 <= crntPos && crntPos >= pos - 1;

      // 現在位置設定
      crntPos = pos;

      // ±1の場合
      if (flg)
      {
        // 改行フラグがある場合、改行、ない場合、スペース
        strPos = nLFlg ? strPos + Environment.NewLine : strPos + " ";
        // 取得位置確定入力
        fmGetTime.tbComment.AppendText(strPos);

        // 改行フラグ変更
        nLFlg = !nLFlg;

        return;
      }

      // 指定秒前に再生位置設定
      axWindowsMediaPlayer1.Ctlcontrols.currentPosition = crntPos - 3;
    }
    #endregion


    #region 時刻変換メソッド
    private static string ConvSecToStringTime(double sec)
    {
      // 時刻変換
      string hour = string.Format("{0:00}", (int)(sec / HOUR_TO_SECOND));
      string minute = string.Format("{0:00}", (int)((sec % HOUR_TO_SECOND) / MINUTE_TO_SECOND));
      string second = string.Format("{0:00}", (int)(sec % MINUTE_TO_SECOND));
      string mSec = "000";

      // 
      if (sec.ToString().IndexOf(CONST_CHAR_EN_DOT) != -1)
      {
        // 
        mSec = sec.ToString().Split(CONST_CHAR_EN_DOT)[1];
        if (mSec.Length > 3)
        {
          // 
          mSec = mSec.Substring(0, 3);
        }
      }

      //
      string ret = new StringBuilder().Append(hour).Append(CONST_CHAR_EN_COLOGNE)
                                .Append(minute).Append(CONST_CHAR_EN_COLOGNE)
                                .Append(second).Append(CONST_CHAR_EN_DOT)
                                .Append(mSec).ToString();

      return ret;
    } 
    #endregion


    #region 雛形メソッド
    public void template()
    {

    }
    #endregion
  }
}
