using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WFA
{
  /// <summary>
  /// アイテムドロップインフォーム
  /// </summary>
  public partial class FrmItemDropIn : Form
  {
    #region コンストラクタ
    public FrmItemDropIn()
    {
      InitializeComponent();
    }
    #endregion


    #region フォームロードイベント
    private void FrmItemDropIn_Load(object sender, EventArgs e)
    {
      groupBox.AllowDrop = true;
    }
    #endregion


    #region グループボックスドラッグエンターイベント
    private void groupBox_DragEnter(object sender, DragEventArgs e)
    {
      // ねずみ返し_マウスがファイルを持っていない場合、イベント・ハンドラを抜ける
      if (!e.Data.GetDataPresent(DataFormats.FileDrop))
      {
        return;
      }

      // ドラッグ中アイテムの取得
      string[] drags = (string[])e.Data.GetData(DataFormats.FileDrop);

      // ねずみ返し_最初の一つ目がフォルダでもファイルでもない場合
      if (!Directory.Exists(drags[0]) && !File.Exists(drags[0]))
      {
        return;
      }

      // マウスの表示を「+」に変更する
      e.Effect = DragDropEffects.Copy;
    }
    #endregion

    #region グループボックスドラッグドロップイベント
    private void groupBox_DragDrop(object sender, DragEventArgs e)
    {
      // ドラッグ&ドロップされたアイテムの取得
      string[] drags = (string[])e.Data.GetData(DataFormats.FileDrop);

      // アイテム表示
      string outStr = string.Empty;
      foreach (string x in drags)
      {
        outStr += x + Environment.NewLine;
      }
      MessageBox.Show(outStr); 
    }
    #endregion
  }
}
