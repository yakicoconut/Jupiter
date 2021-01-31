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
      // オプションフォームインスタンス生成
      fmOption = new FrmOption();
    }
    #endregion

    #region コンフィグ取得メソッド
    public void GetConfig()
    {
      // 再生位置巻き戻し秒デフォルト値
      defBackPosSec = int.Parse(_comLgc.GetConfigValue("DefBackPosSec", "-5"));
      // 再生位置移動秒デフォルト値
      defGoPosSec = int.Parse(_comLgc.GetConfigValue("DefGoPosSec", "3"));
      // 取得再生位置確定範囲秒デフォルト値
      defCmtPosRange = int.Parse(_comLgc.GetConfigValue("DefCmtPosRange", "1"));
      // 再生位置取得後巻き戻し秒デフォルト値
      defGetAftBackPos = int.Parse(_comLgc.GetConfigValue("DefGetAftBackPos", "3"));
    }
    #endregion


    #region 宣言

    // 共通ロジッククラスインスタンス
    MCSComLogic _comLgc = new MCSComLogic();

    // 取得時刻フォーム
    FrmGetTime fmGetTime;
    // オプションフォーム
    FrmOption fmOption;

    // 現在位置
    double playPos;

    // 再生位置巻き戻し秒デフォルト値
    int defBackPosSec;
    // 再生位置移動秒デフォルト値
    int defGoPosSec;
    // 取得再生位置確定範囲秒デフォルト値
    int defCmtPosRange;
    // 再生位置取得後巻き戻し秒デフォルト値
    int defGetAftBackPos;

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

      // 常にメインフォームの手前に表示
      fmOption.Owner = this;

      /* プロパティ設定 */
      // オプションフォームのプロパティに本クラスを設定
      fmOption.ParentForm = this;
      // 再生位置巻き戻し秒デフォルト値
      fmOption.DefBackPosSec = defBackPosSec;
      // 再生位置移動秒デフォルト値
      fmOption.DefGoPosSec = defGoPosSec;
      // 取得再生位置確定範囲秒デフォルト値
      fmOption.DefCmtPosRange = defCmtPosRange;
      // 再生位置取得後巻き戻し秒デフォルト値
      fmOption.DefGetAftBackPos = defGetAftBackPos;

      // オプションフォーム表示
      fmOption.Show();
    }
    #endregion


    #region ReadVideoメソッド
    /// <summary>
    /// ReadVideoメソッド
    /// </summary>
    /// <param name="filePath">再生対象ファイル</param>
    public void ReadVideo(string filePath)
    {
      // 再生中の場合
      if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
      {
        // メッセージボックス表示
        DialogResult dlgRes = MessageBox.Show("再生中です\r\nファイル読み込みを行いますか", "再生中", MessageBoxButtons.YesNo);
        // 「いいえ」押下の場合、終了
        if(dlgRes == DialogResult.No)
          return;
      }

      // 指定パスの動画再生
      axWindowsMediaPlayer1.URL = filePath;
    }
    #endregion

    #region プレイヤーモード変更メソッド
    /// <summary>
    /// プレイヤーモード変更メソッド
    /// </summary>
    public void CngMode()
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

    #region 現在再生位置取得メソッド
    /// <summary>
    /// 現在再生位置取得メソッド
    /// </summary>
    /// <param name="posRange">位置確定範囲</param>
    /// <param name="goBack">再生位置巻き戻し</param>
    /// <param name="isNewLine">改行フラグ</param>
    /// <returns>現在再生位置文字列</returns>
    public string GetPlayPos(int posRange, int cmtBack, ref bool isNewLine)
    {
      // 返却用変数
      string strPos = string.Empty;

      // 現在再生位置取得
      double pos = axWindowsMediaPlayer1.Ctlcontrols.currentPosition;

      // 再生位置が前回位置と指定±秒以内かどうか
      bool rangeFlg = pos - posRange <= playPos && playPos >= pos - posRange;

      // 現在再生位置設定
      playPos = pos;

      // ±秒が範囲内の場合
      if (rangeFlg)
      {
        // 時刻変換メソッド使用
        strPos = ConvSecToStringTime(pos);

        // 改行フラグがある場合、改行、ない場合、スペース
        strPos = isNewLine ? strPos + Environment.NewLine : strPos + " ";
        // 取得位置確定入力
        fmGetTime.tbComment.AppendText(strPos);

        // 改行フラグ変更
        isNewLine = !isNewLine;

        return strPos;
      }

      // 指定秒前に再生位置設定
      axWindowsMediaPlayer1.Ctlcontrols.currentPosition = playPos - cmtBack;

      return strPos;
    }
    #endregion

    #region Goメソッド
    /// <summary>
    /// Goメソッド
    /// </summary>
    /// <param name="pos">巻き戻し秒</param>
    public void Go(int goPos)
    {
      // 再生位置変更
      axWindowsMediaPlayer1.Ctlcontrols.currentPosition += goPos;
    }
    #endregion

    #region 再生速度変更メソッド
    /// <summary>
    /// 再生速度変更メソッド
    /// </summary>
    /// <param name="playSpd">再生速度</param>
    public void CngPlaySpd(double playSpd)
    {
      // 再生速度変更
      axWindowsMediaPlayer1.settings.rate = playSpd;
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
