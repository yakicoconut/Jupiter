# # 文字コード変換 # #
# # 指定ファイルの文字コードをBOM付UTF-8に変換

import os
import codecs
import struct


# # BOM付きUTF-8変換関数 #
# 引数1:元ファイルパス、引数2:出力ファイル名(元ファイルと同じものを指定した場合、上書きとなる)
def convert_utf8bom(input_file, output_file):
    # リードファイルが存在しない場合は作成する
    if not os.path.exists(input_file):
        with open(input_file, "wb") as fout:
            pass

    # リストを初期化
    data = []
    # データをリストに格納
    for row in codecs.open(input_file, 'r', 'utf-8-sig'):
        data.append(row)

    # 書き込みファイルをバイナリーで開く
    with open(output_file, "wb") as fout:
        for x in [0xEF, 0xBB, 0xBF]:
            # BOM用データを書き込む
            fout.write(struct.pack("B", x))

    # 同じ書き込みファイルをutf-8アペンドモードで開く
    fout_utf = codecs.open(output_file, 'a', 'utf-8')
    # 格納したリストのデータを書き込む
    for r in data:
        fout_utf.write(r)

    # 書き込み用ファイルを閉じる
    fout_utf.close()
