# # URLからHTML取得 # #
# # csvファイルのURLからHTMLを取得


# # 共通関数フォルダの相対的指定
import sys
import os
from time import sleep
import csv
import pandas as pd
import requests
import shutil
sys.path.append(__file__.rsplit("/", 3)[0] + r"/OwnLib")  # 二階層上の共通関数フォルダを指定
from HtmlPrettify import *  # 共通関数ファイルの読み込み例


# print(fn_template)  # 関数使用例


# # 事前準備
# 対象CSVファイル
target_csv_file = 'TargetUrl.csv'
# 出力テンプレートファイル
out_temp_file = r".\MyResorce\Template\template.html"


# # 実行
# CSVファイル読み込み
target_csv = pd.read_csv(target_csv_file, encoding="shift-jis")

# 「完了フラグ」カラム取得
comp_flags = target_csv.完了フラグ

# ループ処理
i = 0
for x in comp_flags:
    # ねずみ返し_完了フラグが立っている場合
    if bool(x):
        # 行数インクリメント
        i += 1
        continue

    # 「URL」カラムから対象のURLを取得
    target_url = target_csv.iloc[i, 1]

    # URLの読み込み
    target_html = requests.get(target_url)
    # リクエストのエンコードを動的に設定
    target_html.encoding = target_html.apparent_encoding
    # 内容取得
    target_html_str = target_html.text

    # # タブでHTMLの階層をつける # #
    target_html_prettify = fn_html_tab_prettify_from_str(target_html_str)

    # 対象タイトル取得
    target_title = target_csv.iloc[i, 0]
    # ファイル名用に20文字だけ取得
    target_title = target_title[0:20]

    # ファイルコピー
    shutil.copyfile(out_temp_file, (target_title + '.html'))
    # ファイルオープン(無ければ作成、追記)
    with open(target_title + '.html', 'a', 1, 'utf-8') as f:
        # 取得したHtmlの書き込み
        f.write(str(target_html_prettify))

    # 完了フラグを立てる
    target_csv.iloc[i, 2] = True

    # 行数インクリメント
    i += 1
    # 完了表示
    print('完了:' + str(i))

    # 【必須】スリープ
    sleep(1)


# CSV出力(インデックスなし)
target_csv.to_csv(target_csv_file, index=False)
