var _this = this;
// 時刻自動更新クラス
var AutoUpdTime = /** @class */ (function () {
    /*
     * コンストラクタ
     */
    function AutoUpdTime(element) {
        // 引数引継ぎ
        this.element = element;
    }
    /*
     * スタートメソッド
     */
    AutoUpdTime.prototype.start = function () {
        var _this = this;
        // 時刻表示
        setInterval(function () {
            // 500ミリ秒間隔で現在時刻表示
            _this.element.innerHTML = new Date().toUTCString();
        }, 500);
    };
    return AutoUpdTime;
}());
/*
 * onload関数
 */
window.onload = function () {
    // HTML内の「DateTimeDisp」ID取得
    _this.target = document.getElementById("DateTimeDisp");
    // 時刻自動更新クラスインスタンス生成
    var autoUpdTime = new AutoUpdTime(_this.target);
    // スタートメソッド使用
    autoUpdTime.start();
};
//# sourceMappingURL=app.js.map