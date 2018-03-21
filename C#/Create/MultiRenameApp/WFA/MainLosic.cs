using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace WFA
{
  class MainLosic
  {
    #region コンストラクタ
    public MainLosic()
    {
      //ログフォルダの作成
      Directory.CreateDirectory(@"Log");
      //ログ名称にタイムスタンプを使用
      logName = DateTime.Now.ToString("yyyyMMdd");
    }
    #endregion

    #region プロパティ

    //Azukiエディタのドキュメント型
    public Sgry.Azuki.Document targetDoc { get; set; }
    public Sgry.Azuki.Document changedDoc { get; set; }
    //ログ名称
    public string logName { get; set; }

    #endregion


    #region フォルダ参照メソッド
    /// <summary>
    /// フォルダ参照メソッド
    /// </summary>
    /// <param name="fm">フォーム</param>
    /// <returns></returns>
    public string ReferenceFolder(Form fm)
    {
      //インスタンス作成
      FolderBrowserDialog fbd = new FolderBrowserDialog();

      //上部に表示する説明テキストを指定する
      fbd.Description = "対象のフォルダを指定してください";
      //ルートフォルダを指定する
      fbd.RootFolder = Environment.SpecialFolder.Desktop;

      //OKが押下された場合
      if (fbd.ShowDialog(fm) == DialogResult.OK)
      {
        //取得したフォルダパスを返す
        return fbd.SelectedPath;
      }
      else
      {
        return null;
      }
    }
    #endregion

    #region フォルダ内容取得メソッド
    /// <summary>
    /// フォルダ内容取得メソッド
    /// </summary>
    /// <param name="targetDir">対象フォルダ</param>
    /// <returns>フォルダファイル一覧</returns>
    public ArrayList GetDirectoryContents(string targetDir)
    {
      ArrayList targetList = new ArrayList();

      //対象の取得
      string[] tempTargetFolder = Directory.GetDirectories(targetDir, "*", SearchOption.TopDirectoryOnly);
      string[] tempTargetFile = Directory.GetFiles(targetDir, "*", SearchOption.TopDirectoryOnly);

      //ねずみ返し_対象がない場合、終了
      if (tempTargetFolder.Length == 0 && tempTargetFile.Length == 0)
      {
        MessageBox.Show("対象となるファイルがありません");
        return null;
      }

      //対象ディレクトリ内の一覧取得
      targetList.Add(tempTargetFolder);
      targetList.Add(tempTargetFile);

      return targetList;
    }
    #endregion

    #region フォルダファイル一覧表示メソッド
    /// <summary>
    /// フォルダファイル一覧表示メソッド
    /// </summary>
    /// <param name="targetPath">対象フォルダ</param>
    public void ForlderAndFileDisplay(string targetPath)
    {
      //フォルダ内容取得メソッド使用
      ArrayList targetList = GetDirectoryContents(targetPath);
      //ねずみ返し_対象リストがヌルの場合
      if (targetList == null)
      {
        return;
      }

      //Azukiエディタのクリア
      targetDoc.Replace("", 0, targetDoc.Length);
      changedDoc.Replace("", 0, changedDoc.Length);

      //対象リストループ
      foreach (string[] x in targetList)
      {
        for (int i = 0; i < x.Length; i++)
        {
          //フォルダかファイル名のみ取得
          string y = System.IO.Path.GetFileName(x[i]);

          //Azukiエディタに追記
          targetDoc.Replace(y, targetDoc.Length, targetDoc.Length);
          changedDoc.Replace(y, changedDoc.Length, changedDoc.Length);
          //Azukiエディタに改行を追記
          targetDoc.Replace(Environment.NewLine, targetDoc.Length, targetDoc.Length);
          changedDoc.Replace(Environment.NewLine, changedDoc.Length, changedDoc.Length);
        }
      }

      //Azukiエディタの最後の改行を削除
      targetDoc.Replace("", targetDoc.Length - 2, targetDoc.Length);
      changedDoc.Replace("", changedDoc.Length - 2, changedDoc.Length);
    }
    #endregion

    #region リネーム処理メソッド
    public bool RenameProcess(string targetPath)
    {
      //フォルダパスを取得
      string targetPathYen = targetPath + @"\";

      //ログ出力_対象フォルダ
      WriteLog("実行時刻:" + DateTime.Now.ToString("HH:mm:ss") + "\r\nフォルダ:" + targetPath);

      //実処理
      for (int i = 0; i < targetDoc.LineCount; i++)
      {
        //ねずみ返し_変更後名がない場合
        if (changedDoc.GetLineContent(i).Length == 0)
        {
          continue;
        }
        //ねずみ返し_置換え前と置換え後が同じ場合
        if (targetDoc.GetLineContent(i) == changedDoc.GetLineContent(i))
        {
          continue;
        }

        //置換え対象取得
        string target = targetPathYen + targetDoc.GetLineContent(i);
        string changed = targetPathYen + changedDoc.GetLineContent(i);

        try
        {
          //フォルダかファイルか判断
          if (Directory.Exists(target))
          {
            Directory.Move(target, changed);
          }
          else
          {
            File.Move(target, changed);
          }

          //ログ出力_実行済みフォルダ
          WriteLog(targetDoc.GetLineContent(i) + "\t→\t" + changedDoc.GetLineContent(i));
        }
        catch (Exception e)
        {
          DialogResult result = MessageBox.Show(
            e.Message + "\r\n" + (i + 1).ToString() + "段目\r\n" + target + "\r\n→\r\n" + changed + "\r\n\r\n[はい]   :処理継続\r\n[いいえ]:処理終了",
            "エラー",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Error);

          //ログ出力_エラー
          WriteLog("■■■Error:" + e.Message + "      " + target + "\t→\t" + changed);

          //いいえの場合、終了
          if (result == DialogResult.No)
          {
            return false;
          }
        }
      }

      return true;
    }
    #endregion


    #region ログ出力メソッド
    public void WriteLog(string message)
    {
      using (StreamWriter sw = new StreamWriter(
                             @"Log\" + logName + ".log",
                             true,
                             System.Text.Encoding.GetEncoding("shift_jis")))
      {
        sw.WriteLine(message);
      }
    }
    #endregion
  }
}
