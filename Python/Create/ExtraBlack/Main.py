# # 画像から黒の部分だけ抽出する # #
# # 黒色はRGBで(0, 0, 0)で全てに+30程までは黒っぽく見える
# # 閾値を設定しそれ以下の値は黒に、それより上の値は白に変換する
# # (Ex:閾値が20で(20, 0, 3)の色が対象のときは黒(0, 0, 0)に変換
# # (Ex:閾値が20で(100, 0, 3)の色が対象のときは白(255, 255, 255)に変換


# # 共通関数フォルダの相対的指定
import sys
import os
import numpy as np
from PIL import Image
sys.path.append(__file__.rsplit("/", 2)[0] + r"/OwnLib")  # 二階層上の共通関数フォルダを指定


# 対象閾値(指定以下の要素を全て0に変更する)
targetThreshold = 20

# 対象イメージ読み込み
im_list = np.array(Image.open(r'./MyResorce/TestImg/Test02.png'))
# # とりあえず表示
# print("データ\r\n" + str(im_list))
# print("次元数\r\n" + str(im_list.ndim))
# print("サイズ\r\n:" + str(im_list.shape))
# print("型\r\n:" + str(im_list.dtype))

# 各色の要素を定義
waterDIm = np.array([0, 255, 255, 255])
purpleDim = np.array([255, 0, 255, 255])
yellowDim = np.array([255, 255, 0, 255])
blueDim = np.array([0, 0, 255, 255])
redDim = np.array([255, 0, 0, 255])
greenDim = np.array([0, 255, 0, 255])
blackDim = np.array([0, 0, 0, 255])
whiteDim = np.array([255, 255, 255, 255])
# # とりあえず表示_単色確認
# # 1ピクセルのみ置き換え
# im_list[0][0] = greenDim
# # PIL型に変換して表示
# img = Image.fromarray(im_list)
# img.show()


# 配列1次元目
oneDim = []
for x in im_list:
    # 配列2次元目
    twoDim = []
    for y in x:
        # # とりあえず表示
        # print("-------------")
        # print(y)

        # 対象要素数以下の要素は全て黒(0)、それ以外の値は全て白(255)に変更
        y = np.where(y <= targetThreshold , 0, 255)
        # # とりあえず表示
        # print(y)

        # 変換後の値が白か黒以外の場合
        if np.allclose(y, waterDIm) or np.allclose(y, purpleDim) or np.allclose(y, yellowDim)\
                or np.allclose(y, blueDim) or np.allclose(y, redDim) or np.allclose(y, greenDim):
            # 白に変更
            y = whiteDim

        # 2次元目に配列を追加
        twoDim.append(y)

    # 1次元目に配列を追加
    oneDim.append(twoDim)

# 画像配列のためuint8でnumpy配列に変換
im_list_changed = np.array(oneDim, dtype='uint8')
# # とりあえず表示
# print(im_list_changed)
# print("型\r\n:" + str(im_list_changed.dtype))

# PIL型に変換して表示
img = Image.fromarray(im_list_changed)
img.show()
