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
    public Form2(Form1 fm)
    {
      InitializeComponent();

      fm1 = fm;
    }
    #endregion

    #region 宣言

    // ラベル更新メソッド用デリゲート
    delegate void UpdLabelCallback(string str);

    Form1 fm1;

    #endregion


    #region ラベル更新メソッド
    private void UpdLabel(string str)
    {
      // 表示更新
      label1.Text = str;

      if (str == "5")
      {
        fm1.str = "abc";
        this.Close();
      }
    }
    #endregion
    
    #region ラベル更新操作メソッド
    /// <summary>
    /// ラベル更新操作メソッド
    /// </summary>
    /// <param name="i">更新値</param>
    public void UpdLabelOprt(string i)
    {
      // ラベル更新メソッド用デリゲートインスタンス生成
      UpdLabelCallback dlgUpdLabel = new UpdLabelCallback(UpdLabel);

      // ラベル更新メソッド起動
      label1.Invoke(dlgUpdLabel, i.ToString());
    }
    #endregion

  }
}
