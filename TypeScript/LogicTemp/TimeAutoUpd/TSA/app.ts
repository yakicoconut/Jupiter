// 時刻自動更新クラス
class AutoUpdTime {
    /*
     * グローバル変数
     */
    // HTML変数
    element: HTMLElement;

    /*
     * コンストラクタ
     */
    constructor(element: HTMLElement) {
        // 引数引継ぎ
        this.element = element;
    }

    /*
     * スタートメソッド
     */
    start() {
        // 時刻表示
        setInterval(() => {
            // 500ミリ秒間隔で現在時刻表示
            this.element.innerHTML = new Date().toUTCString();
        }, 500);
    }
}

/*
 * onload関数
 */
window.onload = () => {
    // HTML内の「DateTimeDisp」ID取得
    this.target = document.getElementById("DateTimeDisp");
    // 時刻自動更新クラスインスタンス生成
    var autoUpdTime = new AutoUpdTime(this.target);
    // スタートメソッド使用
    autoUpdTime.start();
}
