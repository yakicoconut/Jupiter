# coding:utf-8

# # 画像サイズ変更　# #
#


# # インポート
import cv2


def img_resize(img, scale_high, scale_width):
    """画像リサイズ関数関数
    :概要  :画像リサイズ
    :引数01:画像
    :引数02:高さリサイズスケール
    :引数03:幅リサイズスケール
    :return:リサイズ後画像
    """

    # # 準備
    # 高さ、幅取得
    h, w = img.shape[:2]
    # 変更後の高さを計算
    scale_h = int(h * scale_high)
    # 変更後の幅を計算
    scale_w = int(w * scale_width)
    # # とりあえず表示
    # print(scale_h)
    # print(scale_w)
    # os.system('pause')

    # # リサイズ
    img = cv2.resize(img, (scale_w, scale_h))
    # # とりあえず表示
    # cv2.imshow("img_resize", img)
    # cv2.waitKey(0)

    return img
