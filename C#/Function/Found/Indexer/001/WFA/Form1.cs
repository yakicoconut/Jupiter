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

#region ヘッダ
/*
 * インデクサ
 *   組み込み型(int、string等)と同様にユーザー定義型も
 *   配列のように[]を使用したインデックスアクセスが定義可能
 *   一般
 *     T this [任意型 変数] { set { セット処理 } get { ゲット処理 } }
 * 
 * サイト
 *   C#-インデクサ について - Qiita
 *    http://qiita.com/ShirakawaYoshimaru/items/7ab011afe16a743bb053
 *   インデクサ（C#、VB.NET)
 *    http://www.geocities.jp/hatanero/indexer2.html
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

    #endregion


    #region フォームロードイベント
    private void Form1_Load(object sender, EventArgs e)
    {

    }
    #endregion

    #region ボタン1押下イベント
    private void button1_Click(object sender, EventArgs e)
    {
      // モンスターマネージャークラスインスタンス生成
      MonsterManager manager = new MonsterManager();

      // モンスタークラスリストに追加
      manager[0] = new Monster("くっぱ");
      manager[1] = new Monster("すらいむ");
      manager[2] = new Monster("とろーる");

      // モンスタークラス取り出し
      Monster monster = manager[1];

      // オーバーライドしたToStringメソッド使用
      MessageBox.Show(monster.ToString());
    }
    #endregion

    #region ボタン2押下イベント
    private void button2_Click(object sender, EventArgs e)
    {
      // 通常の配列
      Monster[] m = new Monster[3];
      m[0] = new Monster("くっぱ");
      m[1] = new Monster("すらいむ");
      m[2] = new Monster("とろーる");

      // オーバーライドしたToStringメソッド使用
      MessageBox.Show(m[1].ToString());
    }
    #endregion
  }


  #region モンスターマネージャークラス
  /// <summary>
  /// モンスターマネージャークラス
  /// </summary>
  public class MonsterManager
  {
    #region コンストラクタ
    public MonsterManager()
    {

    }
    #endregion


    #region 宣言

    // モンスタークラスリスト作成
    private List<Monster> monsterList = new List<Monster>();

    #endregion


    #region インデクサ
    /// <summary>
    /// インデクサ
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public Monster this[int index]
    {
      // 添え字での値取り出し
      get
      {
        return monsterList[index];
      }
      // 添え字での値設定
      set
      {
        monsterList.Add(value);
      }
    }
    #endregion
  }
  #endregion


  #region モンスタークラス
  /// <summary>
  /// モンスタークラス
  /// </summary>
  public class Monster
  {
    #region コンストラクタ
    public Monster(string name)
    {
      Name = name;
    }
    #endregion


    #region プロパティ

    public string Name { get; set; }

    #endregion


    #region オーバーライドToString
    public override string ToString()
    {
      return "Monster:" + Name;
    }
    #endregion
  }
  #endregion
}
