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

    #region グループボックスドラッグドロップイベント
    private void groupBox_DragDrop(object sender, DragEventArgs e)
    {

    }
    #endregion

    #region グループボックスドラッグエンターイベント
    private void groupBox_DragEnter(object sender, DragEventArgs e)
    {

    }
    #endregion
  }
}
