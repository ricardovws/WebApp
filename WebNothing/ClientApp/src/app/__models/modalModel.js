"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.modalModel = void 0;
var modalModel = /** @class */ (function () {
    function modalModel(action, description, target, signal, buttonType, deleteModal) {
        this.deleteModal = true;
        this.action = action;
        this.description = description;
        this.target = target;
        this.signal = signal;
        this.buttonType = buttonType;
        this.deleteModal = deleteModal;
    }
    return modalModel;
}());
exports.modalModel = modalModel;
//# sourceMappingURL=modalModel.js.map