/*
 * 無限ループ
 *   概要
 *     setIntervalメソッドは明示的に停止するか
 *     画面更新、画面終了するまで無限ループする
 *   サイト
 *     タイマー処理を行うsetTimeout()と一定時間の繰り返しを行うsetInterval() | JavaScript中級編 - ウェブプログラミングポータル
 *      https://wp-p.info/tpl_rep.php?cat=js-intermediate&fl=r6
 */


/*
 * 変数
 */
// ボタン2終了フラグ
var button2IsEndFlg: boolean = false;
// 
var button2SetIv

/*
 * ボタンクリック1関数
 */
function button1_click() {
    // HTML内のID取得
    var target = document.getElementById("Disp1");

    // カウンタ
    var i = 0;
    // setIntervalループ
    setInterval(() => {
        // 表示更新
        target.innerHTML = String(i);
        // カウンタインクリメント
        i++;
    }, 1000);
}

/*
 * ボタンクリック2関数
 */
function button2_click() {
    // ねずみ返し_ボタン2終了フラグが立っている場合
    if (this.button2IsEndFlg) {
        // ボタン2終了フラグを折る
        this.button2IsEndFlg = false;
        // ループ終了
        clearInterval(this.button2SetIv);
        return;
    }

    // HTML内のID取得
    var target = document.getElementById("Disp2");

    // カウンタ
    var i = 0;
    // setIntervalループ
    button2SetIv = setInterval(() => {
        // 表示更新
        target.innerHTML = String(i);
        // カウンタインクリメント
        i++;
    }, 1000);

    // ボタン2終了フラグを立てる
    this.button2IsEndFlg = true;
}
