// クラス
class Greeter {
    /*
     * グローバル変数
     */
    // HTML変数
    element: HTMLElement;
    span: HTMLElement;
    // タイマ変数
    timerToken: number;

    /*
     * コンストラクタ
     */
    constructor(element: HTMLElement) {
        // 引数引継ぎ
        this.element = element;
        // 「inner」タグ設定
        this.element.innerHTML += "The time is: ";
        // 
        this.span = document.createElement('span');
        // 
        this.element.appendChild(this.span);
        // 
        this.span.innerText = new Date().toUTCString();
    }

    /*
     * スタートメソッド
     */
    start() {
        // 
        this.timerToken = setInterval(() => this.span.innerHTML = new Date().toUTCString(), 500);
    }

    /*
     * ストップメソッド
     */
    stop() {
        // 
        clearTimeout(this.timerToken);
    }

}

/*
 * 
 */
window.onload = () => {
    // 
    var el = document.getElementById('content');
    // 
    var greeter = new Greeter(el);
    // 
    greeter.start();
};