/*
 * 【JavaScript入門】onloadイベントの使い方とハマりやすい注意点とは | 侍エンジニア塾ブログ（Samurai Blog） - プログラミング入門者向けサイト
 *  https://www.sejuku.net/blog/19754
 * 読み込み時の処理！JavaScriptでonloadを使う方法 | TechAcademyマガジン
 *  https://techacademy.jp/magazine/15558
-->


/*
 * onload関数
 */
window.onload = function () {
    // HTML内の「DateTimeDisp」ID取得
    var target = document.getElementById("Disp");
    // 文字列表示
    target.innerHTML = "テスト";
};
//# sourceMappingURL=app.js.map