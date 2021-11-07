using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using ImageMagick;

namespace WFA
{
  /// <summary>
  /// 画像取り込み処理クラス
  /// </summary>
  class InportImg
  {
    #region コンストラクタ
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="frm1">メインフォームクラス</param>
    /// <param name="dataStore">データ格納クラス</param>
    public InportImg(Form1 frm1, DataStore dataStore)
    {
      // メインフォーム
      fm1 = frm1;

      // プログレスバーフォーム
      fmPrgBar = new FrmPrgBar();
      // 事前にロードし、非表示としておく
      fmPrgBar.Show();
      fmPrgBar.Visible = false;

      // データ格納クラス
      dsc = dataStore;
    }
    #endregion


    #region 宣言

    // メインフォーム
    Form1 fm1;
    // プログレスバーフォーム
    FrmPrgBar fmPrgBar;

    // データ格納クラス
    DataStore dsc;

    #endregion


    #region メイン処理メソッド
    /// <summary>
    /// メイン処理メソッド
    /// </summary>
    private void MainProcessThread()
    {
      // 画像リスト変数
      List<Image> lstImgLst = new List<Image>();
      // リストビュー変数
      List<ListViewItem> lstLstVwItm = new List<ListViewItem>();

      // 画像パスディクショナリ作成メソッド使用
      dsc.DicImgPath = CreateDic(dsc.DropItem);

      // 画像リストループ
      int i = 1;
      foreach (KeyValuePair<int, string> x in dsc.DicImgPath)
      {
        // 表示対象画像イメージマジック取り込み
        byte[] imgByte;
        using (MagickImage image = new MagickImage(x.Value))
        {
          // ビットマップに設定
          image.Format = MagickFormat.Bmp;
          // バイト変換
          imgByte = image.ToByteArray();
        }
        // 画像バイトストリーム取り込み
        using (MemoryStream ms = new MemoryStream(imgByte))
        {
          // ビットマップ変換
          using (Bitmap bm = new Bitmap(ms))
          {
            // サムネイル作成メソッド
            Bitmap thumb = CreateThumb(bm);

            // 画像リスト追加
            lstImgLst.Add(thumb);
            // リストビュー追加
            lstLstVwItm.Add(new ListViewItem(x.Value, x.Key));

            // プログレスバー更新メソッドメソッド使用
            fmPrgBar.UpdPrgBarOprt(i, dsc.DicImgPath.Count);
          }
        }

        i++;
      }

      // 画像リストソース設定
      dsc.SrcImgList = lstImgLst.ToArray();
      dsc.SrcListViewItem = lstLstVwItm.ToArray();
    }
    #endregion

    #region 画像パスディクショナリ作成メソッド
    /// <summary>
    /// 画像パスディクショナリ作成メソッド
    /// </summary>
    /// <param name="tgtPath">対象パス</param>
    /// <returns>画像パスディクショナリ(インデックス,ファイルパス)</returns>
    private Dictionary<int, string> CreateDic(string tgtPath)
    {
      // 返却用ディクショナリ
      Dictionary<int, string> dic = new Dictionary<int, string>();

      /* 対象ディレクトリパス取得 */
      // デフォルトとしてはディレクトリを想定
      string tgtDirPath = tgtPath;
      // ディレクトリでない判定
      if (!Directory.Exists(tgtPath))
      {
        try
        {
          // ファイルからフォルダパスを取得
          tgtDirPath = Path.GetDirectoryName(tgtPath);
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.ToString() + "\r\n\r\n" + tgtPath);
        }
      }

      // 対象ディレクトリ取得
      DirectoryInfo dir = new DirectoryInfo(tgtDirPath);

      // ファイル読み込み
      FileInfo[] files = dir.GetFiles("*", SearchOption.TopDirectoryOnly);

      // 画像パスディクショナリに変換
      int i = 0;
      foreach (FileInfo x in files)
      {
        // ねずみ返し_拡張子が設定したものではないときは次のループへ
        if (Array.IndexOf(dsc.TgtExt, Path.GetExtension(x.FullName).ToLower()) == -1)
        {
          continue;
        }

        // ディクショナリ追加
        dic.Add(i, x.FullName);
        i += 1;
      }

      return dic;
    }
    #endregion

    #region サムネイル作成メソッド
    /// <summary>
    /// サムネイル作成メソッド
    /// </summary>
    /// <param name="img">対象画像</param>
    /// <returns>作成サムネ画像</returns>
    private Bitmap CreateThumb(Bitmap img)
    {
      // 表示用ビットマップ作成
      Bitmap canvas = new Bitmap(dsc.ThumbW, dsc.ThumbH);

      // 画像描写
      using (Graphics g = Graphics.FromImage(canvas))
      {
        // 背景作成
        g.FillRectangle(new SolidBrush(Color.White), 0, 0, dsc.ThumbW, dsc.ThumbH);

        float fw = (float)dsc.ThumbW / (float)img.Width;
        float fh = (float)dsc.ThumbH / (float)img.Height;

        float scale = Math.Min(fw, fh);
        fw = img.Width * scale;
        fh = img.Height * scale;

        // 画像描画
        g.DrawImage(img, (dsc.ThumbW - fw) / 2, (dsc.ThumbH - fh) / 2, fw, fh);
      }

      return canvas;
    }
    #endregion


    #region スタートメソッド
    /// <summary>
    /// スタートメソッド
    /// </summary>
    public Thread Start()
    {
      // メイン処理メソッドスレッドインスタンス生成
      Thread threadA = new Thread(new ThreadStart(MainProcessThread));
      // バックグラウンドフラグ
      threadA.IsBackground = true;

      // プログレスバーフォーム開始位置
      fmPrgBar.StartPosition = FormStartPosition.CenterParent;
      // サイズ設定
      fmPrgBar.Size = new Size(fm1.Size.Width * 3 / 4, 50);
      
      // スレッドスタート
      threadA.Start();
      // プログレスバーフォーム表示
      fmPrgBar.ShowDialog(fm1);

      return threadA;
    }
    #endregion
  }
}
