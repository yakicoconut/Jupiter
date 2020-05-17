/*
 * ボタンクリック関数
 */
function button1_click() {
    // 現在時刻取得
    var now = new Date();
    // 時分秒変数設定
    var hour = now.getHours();
    var min = now.getMinutes();
    var sec = now.getSeconds();

    // ウィンドウ表示
    alert(hour + ":" + min + ":" + sec);
}
