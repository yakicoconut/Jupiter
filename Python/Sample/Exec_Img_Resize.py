# coding:utf-8

# # 画像サイズ変更共通関数使用例　# #
#


# # 共通関数フォルダの相対的指定
import sys
import os
import numpy as np
sys.path.append(__file__.rsplit("/", 3)[0] + r"/Python/OwnLib/Img")  # 上層の共通関数フォルダを指定
from Resize import *


# メイン実行
if __name__ == '__main__':
    # # 3×3で中心だけ白の画像配列作成
    # dtype:
    #       np.uint8:
    img_array = np.array([
        [[000, 000, 000, 255], [000, 000, 000, 255], [000, 000, 000, 255]],
        [[000, 000, 000, 255], [255, 255, 255, 000], [000, 000, 000, 255]],
        [[000, 000, 000, 255], [000, 000, 000, 255], [000, 000, 000, 255]]
    ], dtype=np.uint8)
    # とりあえず表示
    print(img_array)
    img_array = img_array.repeat(20, axis=0).repeat(20, axis=1)  # 拡大
    cv2.imshow("img_resize", img_array)
    cv2.waitKey(0)

    # 画像リサイズ関数使用
    resize_img = img_resize(img_array, 1.5, 2.0)
    # とりあえず表示
    print(resize_img)
    # resize_img = resize_img.repeat(20, axis=0).repeat(20, axis=1)  # 拡大
    cv2.imshow("img_resize", resize_img)
    cv2.waitKey(0)
