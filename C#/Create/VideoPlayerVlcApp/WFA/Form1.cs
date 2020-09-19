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
using Vlc.DotNet.Core;
using System.Threading;

#region ヘッダ
/*
 * 概要
 *   VLC
 * 事前準備
 *   NuGet
 *     [ツール]展開-[NuGetパッケージマネージャ]展開-[ソリューションのNuGetパッケージの管理]
 *   Vlcライブラリフォルダ
 *     下記サイトからzipダウンロード-以下ファイル任意位置へコピー-
 *       ・libvlc.dll
 *       ・libvlccore.dll
 *       ・pluginsフォルダ
 *     VSから全dllを出力ディレクトコピー設定
 *       VS2019の場合
 *         追加対象ルートフォルダを「ソリューションエクスプローラ」にD&D-「ソリューションエクスプローラ」-
 *         フィルタ(検索)-[dll]入力-dllのみ選択右クリック-[プロパティ]-「出力ディレクトリにコピー」-
 *         [新しい場合はコピーする]選択
 *     サイト
 *       Downloads - VideoLAN
 *       	http://get.videolan.org/vlc/2.2.1/win32/vlc-2.2.1-win32.zip
 *   コントロール
 *     デザイナ-「ツールボックス」-[Vlc.DotNet]展開-[VlcControl]
 * サイト
 *   マジカルプレイヤーの開発の記録 – soy-software
 *   	https://soysoftware.sakura.ne.jp/archives/809
 *   街角のリブロガー: C#でVLCを操作する
 *   	http://ivis-mynikki.blogspot.com/2015/03/cvlc.html
 *   [C#.NET]VLCMediaPlayerでのファイル再生が... - Yahoo!知恵袋
 *   	https://detail.chiebukuro.yahoo.co.jp/qa/question_detail/q11148633691
 *   [VLC]MemoryStreamから動画を再生する - Qiita
 *   	https://qiita.com/MARCHXXX/items/44a8e35ad894baf201e2
 *   c# - Play DVD in VideoLan DotNet - Stack Overflow
 *   	https://stackoverflow.com/questions/24466980/play-dvd-in-videolan-dotnet
 *   MediaPlayer クラス (System.Windows.Media) | Microsoft Docs
 *   	https://docs.microsoft.com/ja-jp/dotnet/api/system.windows.media.mediaplayer?view=netcore-3.1
 *   【C#.net】PictureBox、AxWindowsMediaPlayerのメモリ解放について - 中堅プログラマーの備忘録
 *   	https://www.chuken-engineer.com/entry/2020/02/27/194835
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

    // オプションフォームインスタンス生成
    FrmOption fmOption = new FrmOption();

    // マウスのクリック位置を記憶
    private Point ctrlMousePoint;

    // サイズ変更境界線パネル
    private Panel borderPanelRightBottom;

    #endregion

    #region プロパティ

    /// <summary>
    /// Vlc音量
    /// </summary>
    public int VlcVol {
      get
      {
        // Vlcの音量を返す
        return vlcControl1.Audio.Volume;
      }
    }

    #endregion

       
    #region フォームロードイベント
    private void Form1_Load(object sender, EventArgs e)
    {
      /* オプションフォーム */
      // オプションフォームのプロパティに本クラスを設定
      fmOption.parentForm = this;
      // 常にメインフォームの手前に表示
      fmOption.Owner = this;
      // 開始位置
      fmOption.StartPosition = FormStartPosition.Manual;
      fmOption.Location = new Point(Location.X, Location.Y);
      // オプションフォーム呼び出し
      fmOption.Show();

      /* サイズ変更境界線パネル */
      // 隅の境界コントロール
      borderPanelRightBottom = new Panel();
      vlcControl1.Controls.Add(borderPanelRightBottom);
      borderPanelRightBottom.BackColor = Color.Transparent;
      borderPanelRightBottom.Cursor = Cursors.SizeNWSE;
      borderPanelRightBottom.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      borderPanelRightBottom.Location = new Point(vlcControl1.Size.Width - 9, vlcControl1.Size.Height - 10);
      borderPanelRightBottom.Size = new Size(5, 6);
      borderPanelRightBottom.MouseDown += new MouseEventHandler(window_Comm_MouseDown);
      borderPanelRightBottom.MouseMove += new MouseEventHandler(borderPanelRightBottom_MouseMove);
    }
    #endregion

    #region Vlcライブラリフォルダ指定イベント
    private void vlcControl1_VlcLibDirectoryNeeded(object sender, Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs e)
    {
      // !!!必須設定!!!
      // 「事前準備.Vlcライブラリフォルダ」で
      // 出力設定したVlcライブラリフォルダ指定
      e.VlcLibDirectory = new DirectoryInfo(@".\MyResource\Lib\vlc-2.2.1");
    }
    #endregion
    

    #region サイズ変更境界線パネル共通マウスダウンイベント
    private void window_Comm_MouseDown(object sender, MouseEventArgs e)
    {
      // 左クリックの場合
      if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
      {
        // 開始位置取得
        ctrlMousePoint = new Point(e.X, e.Y);
      }
    }
    #endregion

    #region Vlcマウスムーブイベント
    private void vlcControl1_MouseMove(object sender, MouseEventArgs e)
    {
      // 左クリックの場合
      if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
      {
        // フォームの位置を動かした先にする
        this.Left += e.X - ctrlMousePoint.X;
        this.Top += e.Y - ctrlMousePoint.Y;

        // 位置・サイズ設定コントロール更新メソッド使用
        fmOption.UpdNudCngLocaSizeOperation(this.Location.X, this.Location.Y, this.Size.Width, this.Size.Height);
      }
    }
    #endregion

    #region サイズ変更境界線パネル右下部マウスムーブイベント
    private void borderPanelRightBottom_MouseMove(object sender, MouseEventArgs e)
    {
      // 左クリックの場合
      if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
      {
        // フォームのサイズを動かした分調整する
        Height += e.Y - ctrlMousePoint.Y;
        Width += e.X - ctrlMousePoint.X;

        // 位置・サイズ設定コントロール更新メソッド使用
        fmOption.UpdNudCngLocaSizeOperation(this.Location.X, this.Location.Y, this.Size.Width, this.Size.Height);
      }
    }
    #endregion


    #region Vlc状態変化イベント
    private void vlcControl1_VideoOutChanged(object sender, VlcMediaPlayerVideoOutChangedEventArgs e)
    {
      // 現行メディア取得
      VlcMedia tgtMedia = vlcControl1.GetCurrentMedia();

      // コントロール操作メソッド使用
      fmOption.UpdDurationTextBoxOperation(tgtMedia.Duration.ToString());
    }
    #endregion

    #region Vlcメディア初期化メソッド
    public void VlcMediaInit(string tgtPath)
    {
      // DVDトップ画面表示
      vlcControl1.SetMedia("dvd:///" + tgtPath);
      //// DVD直接再生
      //vlcControl1.SetMedia("dvdsimple:///D:");
      //// 対象ファイル
      //vlcControl1.SetMedia(new FileInfo(tgtPath));

      // 再生
      vlcControl1.Play();
    }
    #endregion

    #region Vlc停止/再生メソッド
    public void VlcPauseStart()
    {
      //// 停止/再生
      //vlcControl1.Pause();
      // コントロール操作メソッド使用
      fmOption.UpdDurationTextBoxOperation(vlcControl1.Time.ToString());
    }
    #endregion

    #region VlcTimeメソッド
    public void VlcTime(long mSec, int delayedTime)
    {
      // 一旦、停止してから再生位置設定を行う
      vlcControl1.Pause();
      // 再生位置設定
      vlcControl1.Time = mSec;

      // 遅延再生設定分スリープ
      Thread.Sleep(delayedTime * 1000);
      // 再生
      vlcControl1.Pause();
    }
    #endregion

    #region Vlc音量調整メソッド
    public void VlcVolume(int vol)
    {
      // 音量変更
      vlcControl1.Audio.Volume = vol;
    }
    #endregion

    #region VLCウィンドウ位置変更メソッド
    public void CngVlcWindLocation(int x, int y)
    {
      // サイズ変更
      this.Location = new Point(x, y);
    }
    #endregion

    #region VLCウィンドウサイズ変更メソッド
    public void CngVlcWindSize(int w, int h)
    {
      // サイズ変更
      this.Size = new Size(w, h);
    }
    #endregion


    #region 雛形メソッド
    private void template()
    {

    }
    #endregion
  }
}
