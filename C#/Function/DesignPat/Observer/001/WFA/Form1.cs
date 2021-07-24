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

#region ヘッダ
/*
 * オブザーバーパターン
 * 
 * サイト
 *   全ては時の中に… : 【C#】デザインパターンのObserverパターンを利用する
 *    http://blog.livedoor.jp/akf0/archives/51530106.html
 *   全ては時の中に… : 【C#】デザインパターンのObserverパターンをイベントを使って実装する
 *    http://blog.livedoor.jp/akf0/archives/51534822.html
 */
#endregion
namespace WFA
{
  public partial class Form1 : Form
  {
    #region メンバ

    // コントロールマネージャ
    private ControlManager manager;

    // オブザーバ
    private StudentObserver student;
    private TeacherObserver teacher;

    #endregion


    #region コンストラクタ
    public Form1()
    {
      InitializeComponent();
    }
    #endregion


    #region ロードメソッド
    /// <summary>
    /// 各オブジェクトを生成
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Form1_Load(object sender, EventArgs e)
    {
      // 初期化
      manager = new ControlManager();
      student = new StudentObserver(this);
      teacher = new TeacherObserver(this);
    }
    #endregion


    #region SEventボタン押下イベント
    /// <summary>
    /// イベント送信
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SEventButton_Click(object sender, EventArgs e)
    {
      textBox1.AppendText("Studentから送信\r\n");

      // 
      manager.SetChanged(10, 20, "Student → Teacher\r\n");
    }
    #endregion

    #region TEventボタン押下イベント
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TEventButton_Click(object sender, EventArgs e)
    {
      textBox1.AppendText("Teacherから送信\r\n");

      manager.SetChanged(20, 10, "Teacher → Student");
    }
    #endregion

    #region AllEventボタン押下イベント
    private void AllEventButton_Click(object sender, EventArgs e)
    {
      manager.SetChanged(10, 20, "Student → Teacher");
      manager.SetChanged(20, 10, "Teacher → Student");
    }
    #endregion


    #region SAttachボタン押下イベント
    /// <summary>
    /// Senderに登録
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SAttachButton_Click(object sender, EventArgs e)
    {
      manager.Attach(student);
    }
    #endregion

    #region TAttachボタン押下イベント
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TAttachButton_Click(object sender, EventArgs e)
    {
      manager.Attach(teacher);
    }
    #endregion

    #region SDetachボタン押下イベント
    /// <summary>
    /// Senderから削除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SDetachButton_Click(object sender, EventArgs e)
    {
      manager.Detach(student);
    }
    #endregion

    #region TDetachボタン押下イベント
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TDetachButton_Click(object sender, EventArgs e)
    {
      manager.Detach(teacher);
    }
    #endregion
  }
}
