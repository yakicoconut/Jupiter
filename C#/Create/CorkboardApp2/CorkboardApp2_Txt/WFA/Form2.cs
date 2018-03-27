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
  public partial class Form2 : Form
  {
    #region コンストラクタ
    public Form2()
    {
      InitializeComponent();

      //リストビューをプロパティに格納
      lvCtrl = listView1;
    }
    #endregion


    #region プロパティ

    public Form1 form1 { get; set; }
    public ListViewItem lvItem { get; set; }
    public ListView lvCtrl { get; set; }

    #endregion


    #region フォームロードイベント
    private void Form2_Load(object sender, EventArgs e)
    {

    }
    #endregion

    #region リストビューダブルクリックイベント
    private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      try
      {
        //選択された基底パネル名を取得
        string targetCtrlName = listView1.SelectedItems[0].SubItems[1].Text;
        ////【テスト】選択された基底パネル名を表示
        //MessageBox.Show(targetCtrlName);

        //選択した基底パネルを表示し最前面化
        form1.Controls[targetCtrlName].Visible = true;
        form1.Controls[targetCtrlName].BringToFront();
      }
      catch
      {

      }
    }
    #endregion

    #region リストビューマウスダウンイベント
    private void listView1_MouseDown(object sender, MouseEventArgs e)
    {
      //ねずみ返し_ワンクリックの場合
      if (e.Clicks == 1)
      {
        return;
      }

      //選択アイテムのチェックを変更しない
      if (listView1.SelectedItems[0].Checked)
      {
        listView1.SelectedItems[0].Checked = false;
      }
      else
      {
        listView1.SelectedItems[0].Checked = true;
      }
    }
    #endregion


    #region コンテキストイベント一覧

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

    #region コンテキスト_閉じる押下イベント
    private void 閉じるToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        //チェックしたアイテム
        foreach (ListViewItem x in listView1.CheckedItems)
        {
          //対象コントロール情報取得
          Control targetCtrl = form1.Controls[x.SubItems[1].Text];
          string lumpingNum = targetCtrl.Name.Substring(targetCtrl.Name.Length - 4, 4);

          //上書き確認メソッド使用
          if (!form1.ConfirmationOverwrite(targetCtrl, lumpingNum))
            //キャンセルの場合
            continue;

          //基底パネル削除メソッド使用
          form1.CloseBasePanel(targetCtrl);
        }
      }
      catch
      {

      }
    }
    #endregion

    #endregion


    #region フォームクロージングイベント
    private void Form2_FormClosing(object sender, FormClosingEventArgs e)
    {
      //クローズキャンセル
      if (e.CloseReason == CloseReason.UserClosing)
        e.Cancel = true;
    }
    #endregion
  }
}
