# # HTMLタブ整形 #
# # HTMLをタグの階層ごとにタブ整形する(階層ごとのインデント(半角スペース)を
# # 階層を保ったままタブ文字に置き換える)

# # 共通インポート
import re
from bs4 import BeautifulSoup


# # ファイルから #
# # 引数1:HTMLファイルパス
# # 引数2:エンコード
# # 戻値 :置換後文字列


def fn_html_tab_prettify_from_file(target_file, encode):
    # # 宣言
    # 階層ごとのインデント(半角スペース)を階層を保ったままタブ文字に置き換える
    p25 = re.compile(r"\n {25}")
    p24 = re.compile(r"\n {24}")
    p23 = re.compile(r"\n {23}")
    p22 = re.compile(r"\n {22}")
    p21 = re.compile(r"\n {21}")
    p20 = re.compile(r"\n {20}")
    p19 = re.compile(r"\n {19}")
    p18 = re.compile(r"\n {18}")
    p17 = re.compile(r"\n {17}")
    p16 = re.compile(r"\n {16}")
    p15 = re.compile(r"\n {15}")
    p14 = re.compile(r"\n {14}")
    p13 = re.compile(r"\n {13}")
    p12 = re.compile(r"\n {12}")
    p11 = re.compile(r"\n {11}")
    p10 = re.compile(r"\n {10}")
    p09 = re.compile(r"\n {9}")
    p08 = re.compile(r"\n {8}")
    p07 = re.compile(r"\n {7}")
    p06 = re.compile(r"\n {6}")
    p05 = re.compile(r"\n {5}")
    p04 = re.compile(r"\n {4}")
    p03 = re.compile(r"\n {3}")
    p02 = re.compile(r"\n {2}")
    p01 = re.compile(r"\n ")

    # ファイルの読み込み
    file = open(target_file, 'r', 1, encode)
    # # とりあえず表示
    # for x in file:
    #   print(x)

    # HTMLとして読み込む
    soup = BeautifulSoup(file.read(), "lxml")
    file.close()

    # 整形
    soup = soup.prettify()

    # タブ文字置換
    soup = p25.sub("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t", soup)
    soup = p24.sub("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t", soup)
    soup = p23.sub("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t", soup)
    soup = p22.sub("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t", soup)
    soup = p21.sub("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t", soup)
    soup = p20.sub("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t", soup)
    soup = p19.sub("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t", soup)
    soup = p18.sub("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t", soup)
    soup = p17.sub("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t", soup)
    soup = p16.sub("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t", soup)
    soup = p15.sub("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t", soup)
    soup = p14.sub("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t", soup)
    soup = p13.sub("\n\t\t\t\t\t\t\t\t\t\t\t\t\t", soup)
    soup = p12.sub("\n\t\t\t\t\t\t\t\t\t\t\t\t", soup)
    soup = p11.sub("\n\t\t\t\t\t\t\t\t\t\t\t", soup)
    soup = p10.sub("\n\t\t\t\t\t\t\t\t\t\t", soup)
    soup = p09.sub("\n\t\t\t\t\t\t\t\t\t", soup)
    soup = p08.sub("\n\t\t\t\t\t\t\t\t", soup)
    soup = p07.sub("\n\t\t\t\t\t\t\t", soup)
    soup = p06.sub("\n\t\t\t\t\t\t", soup)
    soup = p05.sub("\n\t\t\t\t\t", soup)
    soup = p04.sub("\n\t\t\t\t", soup)
    soup = p03.sub("\n\t\t\t", soup)
    soup = p02.sub("\n\t\t", soup)
    soup = p01.sub("\n\t", soup)

    # # アンダーバー(_)置換
    # soup = p25.sub("\n_________________________", soup)
    # soup = p24.sub("\n________________________", soup)
    # soup = p23.sub("\n_______________________", soup)
    # soup = p22.sub("\n______________________", soup)
    # soup = p21.sub("\n_____________________", soup)
    # soup = p20.sub("\n____________________", soup)
    # soup = p19.sub("\n___________________", soup)
    # soup = p18.sub("\n__________________", soup)
    # soup = p17.sub("\n_________________", soup)
    # soup = p16.sub("\n________________", soup)
    # soup = p15.sub("\n_______________", soup)
    # soup = p14.sub("\n______________", soup)
    # soup = p13.sub("\n_____________", soup)
    # soup = p12.sub("\n____________", soup)
    # soup = p11.sub("\n___________", soup)
    # soup = p10.sub("\n__________", soup)
    # soup = p09 .sub("\n_________", soup)
    # soup = p08 .sub("\n________", soup)
    # soup = p07 .sub("\n_______", soup)
    # soup = p06 .sub("\n______", soup)
    # soup = p05 .sub("\n_____", soup)
    # soup = p04 .sub("\n____", soup)
    # soup = p03 .sub("\n___", soup)
    # soup = p02 .sub("\n__", soup)
    # soup = p01 .sub("\n_", soup)

    return soup


# # 文字列から #
# # 引数1:対象文字列
# # 戻値 :置換後文字列


def fn_html_tab_prettify_from_str(target_str):
    # # 宣言
    # 階層ごとのインデント(半角スペース)を階層を保ったままタブ文字に置き換える
    p25 = re.compile(r"\n {25}")
    p24 = re.compile(r"\n {24}")
    p23 = re.compile(r"\n {23}")
    p22 = re.compile(r"\n {22}")
    p21 = re.compile(r"\n {21}")
    p20 = re.compile(r"\n {20}")
    p19 = re.compile(r"\n {19}")
    p18 = re.compile(r"\n {18}")
    p17 = re.compile(r"\n {17}")
    p16 = re.compile(r"\n {16}")
    p15 = re.compile(r"\n {15}")
    p14 = re.compile(r"\n {14}")
    p13 = re.compile(r"\n {13}")
    p12 = re.compile(r"\n {12}")
    p11 = re.compile(r"\n {11}")
    p10 = re.compile(r"\n {10}")
    p09 = re.compile(r"\n {9}")
    p08 = re.compile(r"\n {8}")
    p07 = re.compile(r"\n {7}")
    p06 = re.compile(r"\n {6}")
    p05 = re.compile(r"\n {5}")
    p04 = re.compile(r"\n {4}")
    p03 = re.compile(r"\n {3}")
    p02 = re.compile(r"\n {2}")
    p01 = re.compile(r"\n ")

    # HTMLとして読み込む
    soup = BeautifulSoup(target_str, "lxml")

    # 整形
    soup = soup.prettify()

    # タブ文字置換
    soup = p25.sub("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t", soup)
    soup = p24.sub("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t", soup)
    soup = p23.sub("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t", soup)
    soup = p22.sub("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t", soup)
    soup = p21.sub("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t", soup)
    soup = p20.sub("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t", soup)
    soup = p19.sub("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t", soup)
    soup = p18.sub("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t", soup)
    soup = p17.sub("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t", soup)
    soup = p16.sub("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t", soup)
    soup = p15.sub("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t", soup)
    soup = p14.sub("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t", soup)
    soup = p13.sub("\n\t\t\t\t\t\t\t\t\t\t\t\t\t", soup)
    soup = p12.sub("\n\t\t\t\t\t\t\t\t\t\t\t\t", soup)
    soup = p11.sub("\n\t\t\t\t\t\t\t\t\t\t\t", soup)
    soup = p10.sub("\n\t\t\t\t\t\t\t\t\t\t", soup)
    soup = p09.sub("\n\t\t\t\t\t\t\t\t\t", soup)
    soup = p08.sub("\n\t\t\t\t\t\t\t\t", soup)
    soup = p07.sub("\n\t\t\t\t\t\t\t", soup)
    soup = p06.sub("\n\t\t\t\t\t\t", soup)
    soup = p05.sub("\n\t\t\t\t\t", soup)
    soup = p04.sub("\n\t\t\t\t", soup)
    soup = p03.sub("\n\t\t\t", soup)
    soup = p02.sub("\n\t\t", soup)
    soup = p01.sub("\n\t", soup)

    return soup
