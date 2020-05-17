/*
 * html内ロード順
 * 【JavaScript入門】onloadイベントの使い方とハマりやすい注意点とは | 侍エンジニア塾ブログ（Samurai Blog） - プログラミング入門者向けサイト
 * https://www.sejuku.net/blog/19754
 * ・タグ内容は上から順にロードされる
 * ・headはbodyの前にロードされる
 * ・scriptはソースファイルの指定と
 * 直接記述が可能
 */


/*
 * ボタンクリック関数
 */
function button1_click() {
    // ウィンドウ表示
    alert("HelloWorld3");
}
