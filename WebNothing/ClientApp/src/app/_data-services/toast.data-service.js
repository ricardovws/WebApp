"use strict";
var __assign = (this && this.__assign) || function () {
    __assign = Object.assign || function(t) {
        for (var s, i = 1, n = arguments.length; i < n; i++) {
            s = arguments[i];
            for (var p in s) if (Object.prototype.hasOwnProperty.call(s, p))
                t[p] = s[p];
        }
        return t;
    };
    return __assign.apply(this, arguments);
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.ToastService = void 0;
var ToastService = /** @class */ (function () {
    function ToastService() {
        this.toasts = [];
    }
    ToastService.prototype.show = function (textOrTpl, options) {
        if (options === void 0) { options = {}; }
        this.toasts.push(__assign({ textOrTpl: textOrTpl }, options));
    };
    ToastService.prototype.remove = function (toast) {
        this.toasts = this.toasts.filter(function (t) { return t !== toast; });
    };
    return ToastService;
}());
exports.ToastService = ToastService;
//# sourceMappingURL=toast.data-service.js.map