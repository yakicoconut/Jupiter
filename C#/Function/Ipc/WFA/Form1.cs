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
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using System.Runtime.Remoting;

/*
 * プロセス間通信
 *   概要
 *     ・Inter-Process Communication
 *     ・複数のローカルアプリ間でプロセス(スレッド)通信を行う
 *     ・通信はスキームが「IPC」のURIで指定する
 *   仕様
 *     ・自身のURIはフォルダ名を使用する
 *       →ビルド時に別名フォルダとしてビルドされる
 *   サイト
 *     ・C#.Net間でプロセス間通信 - Neareal
 *       	http://neareal.net/index.php?Programming%2F.NetFramework%2FNetworkAndStream%2FInterProcessCommunication
 */
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
      Text = WFACL.GetAppName(0);
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

    // サーバ側プロセス間通信用クラス 
    CommData srvCommData;
    // クライアント側プロセス間通信用クラス 
    CommData cltCommData;
    
    #endregion


    #region フォームロードイベント
    private void Form1_Load(object sender, EventArgs e)
    {
      // チャンネル名称用変数に表示名称設定
      string channelName = this.Text;

      // サーバ_チャンネル生成メソッド使用
      Srv_CreateChannel();

      // サーバ_チャンネル登録メソッド使用
      Srv_AddChannel(channelName);
    }
    #endregion

    #region ボタン1押下イベント
    private void button1_Click(object sender, EventArgs e)
    {
      string TARGET_URL = "ipc://{0}/{1}";
      string targetUrl = string.Format(TARGET_URL, textBox2.Text, textBox2.Text);

      // クライアント_チャンネル作成メソッド使用
      Clt_CreateRemoteObj(targetUrl);
      MessageBox.Show(targetUrl);
    }
    #endregion

    #region ボタン2押下イベント
    private void button2_Click(object sender, EventArgs e)
    {
      try
      {
        // クライアント_更新メソッド使用
        Clt_UpdateData();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString());
      }
    }
    #endregion

    #region ボタン3押下イベント
    private void button3_Click(object sender, EventArgs e)
    {
      // 公開クラスの値を表示
      textBox1.AppendText(srvCommData.Count.ToString() + Environment.NewLine);
    }
    #endregion


    #region サーバ_チャンネル生成メソッド
    public void Srv_CreateChannel()
    {
      // クライアントサイドのチャンネルを生成
      IpcClientChannel channel = new IpcClientChannel();

      // チャンネルを登録
      ChannelServices.RegisterChannel(channel, true);
    }
    #endregion

    #region サーバ_チャンネル登録メソッド
    private void Srv_AddChannel(string channelName)
    {
      // プロセス間通信用公開クラスインスタンス生成
      srvCommData = new CommData();

      // サーバサイドのチャンネルを生成
      IpcServerChannel channel = new IpcServerChannel(channelName);

      // チャンネルを登録
      ChannelServices.RegisterChannel(channel, true);

      // プロセス間通信用公開クラスと名称の設定
      RemotingServices.Marshal(srvCommData, channelName);
    }
    #endregion

    #region クライアント_チャンネル作成メソッド
    public void Clt_CreateRemoteObj(string targetUrl)
    {
      // リモートオブジェクトを取得
      // URIは"ipc:/チャンネル名/公開名"になる.
      cltCommData = Activator.GetObject(typeof(CommData), targetUrl) as CommData;
    }
    #endregion

    #region クライアント_更新メソッド
    public void Clt_UpdateData()
    {
      // カウントを1増やす
      cltCommData.Count++;
    }
    #endregion
  }

    #region サーバ_プロセス間通信用公開クラス
    /// <summary>
    /// サーバ_プロセス間通信用クラス
    /// </summary>
    public class CommData : MarshalByRefObject
  {
    // カウント
    public int Count { get; set; }
  }
  #endregion
}
