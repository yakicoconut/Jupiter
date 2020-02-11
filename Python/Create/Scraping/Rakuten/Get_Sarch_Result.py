# # ウェブスクレイピング # #
# # 楽天市場検索結果一覧取得
# 出力したCSVファイルをShift_JISに変換する場合、テキストエディタによって手動で変換する
# (Ex:【楽天市場】surfaceの通販
#     	https://search.rakuten.co.jp/search/mall/surface/?f=1&grp=product


# # 宣言 # #
from bs4 import BeautifulSoup
import re
import csv
import sys
import os
sys.path.append(__file__.rsplit("/", 4)[0] + r"/OwnLib")  # 上層の共通関数フォルダを指定
from ConvEnc import *


# # 引数 # #
# *対象ファイル*
target_file = r'MyResorce\TestHtml\_x.html'
# *出力ファイル名*
outputFileName = "out.csv"


# # コメントクラス取得関数 # #
# # 引数1:
# # 戻値 :


def get_content_class(soup_tag):
    # # 宣言
    # 返却配列初期化
    result_list = []

    # ユーザUrlを含むタグ取得
    z = soup_tag.find('a')
    # # とりあえず表示
    # print("#######################################")
    # print(z)

    # ねずみ返し_要素がない場合
    if z is None:
        return

    # タイトル取得
    title = z.attrs['title']
    # ユーザUrl取得
    url = z.attrs['href']
    # # とりあえず表示
    # print("#######################################")
    # print(title)
    # print(url)

    # # 返却配列追加
    result_list.append(title)
    result_list.append(url)

    return result_list


# # エクストラコメントクラス取得関数 # #
# # 引数1:
# # 戻値 :


def get_extra_class(soup_tag):
    # # 宣言
    # 返却配列初期化
    result_list = []

    # 中古品質タグ取得
    z = soup_tag.find(class_="item used")
    # # とりあえず表示
    # print("#######################################")
    # print(z)

    # ねずみ返し_要素がない場合
    if z is None:
        return

    # 中古品質取得
    used_quality = z.text

    return used_quality


# # コメントディスクリプションプライスクラス取得関数 # #
# # 引数1:
# # 戻値 :


def get_description_class(soup_tag):
    # # 宣言
    # 返却配列初期化
    result_list = []

    # 中古品質タグ取得
    z = soup_tag.find(class_="important")
    # # とりあえず表示
    # print("#######################################")
    # print(z)

    # ねずみ返し_要素がない場合
    if z is None:
        return

    # 中古品質取得
    used_quality = z.text

    return used_quality


# # ファイルの読み込み # #
file = open(target_file, 'r', 1, 'utf-8')  # エンコードがutf-8の場合
# HTMLとして読み込む
soup = BeautifulSoup(file.read(), "lxml")
file.close()
# # とりあえず表示
# print(soup.prettify())


# # 置換パターン # #
p1 = re.compile(r"\n")


# # 表示名称タグ取得 # #
list_dui_item = soup.find_all(class_="dui-item searchresultitem")


# # メインの対象タグループ # #
# 出力値格納配列
outputArray = []
for x in list_dui_item:
    # # とりあえず表示
    # print("#######################################")
    # print(x.prettify())

    # 結果配列初期化
    res_list = []

    # コメント要素取得
    list_content = x.find_all(class_="content")
    for y in list_content:
        # # とりあえず表示
        # print("#######################################")
        # print(y.prettify())

        # クラス名連結
        class_name = ",".join(y['class'])

        # クラス名分岐
        if class_name == "content":
            # コメントクラス取得関数使用
            res_list.extend(get_content_class(y))

        elif class_name == "extra,content":
            # エクストラコメントクラス取得関数使用
            res_list.append(get_extra_class(y))

        elif class_name == "content,description,price":
            # コメントディスクリプションプライスクラス取得関数
            res_list.append(get_description_class(y))

        # 出力値格納配列追加
        outputArray.append(res_list)

# とりあえず表示
for a in outputArray:
    print("#######################################")
    for b in a:
        print(b)


# # # CSV出力 # #
# print("CSV出力処理開始")
# # CSVファイルオープン(無ければ作成)
# f = open(outputFileName, 'w', 1, 'utf_8')  # shift_jisは変換できない文字が多いので保留
# writer = csv.writer(f, lineterminator='\n')
#
# # CSV書き込み
# writer.writerows(outputArray)
#
# # CSVファイルクローズ
# f.close()
# print("CSV出力処理完了")
#
#
# # # 文字コード変換 # #
# # BOM付きUTF-8変換関数使用 #
# # 同一ファイルに上書き
# convert_utf8bom(outputFileName, outputFileName)
# print("文字コード変換完了")