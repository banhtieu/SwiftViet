/// <reference path="./angular-loader.ts" />
/// <reference path="./services.ts" />
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") return Reflect.decorate(decorators, target, key, desc);
    switch (arguments.length) {
        case 2: return decorators.reduceRight(function(o, d) { return (d && d(o)) || o; }, target);
        case 3: return decorators.reduceRight(function(o, d) { return (d && d(target, key)), void 0; }, void 0);
        case 4: return decorators.reduceRight(function(o, d) { return (d && d(target, key, o)) || o; }, desc);
    }
};
/// the sample controller
var MenuController = (function (_super) {
    __extends(MenuController, _super);
    function MenuController() {
        _super.apply(this, arguments);
        /// the menu items
        this.menuItems = ["Home", "Tutorial", "Test"];
    }
    /// called when the controller is loaded
    MenuController.prototype.onLoad = function () {
        console.log(this.loginService);
    };
    __decorate([
        wired
    ], MenuController.prototype, "$resource");
    __decorate([
        wired
    ], MenuController.prototype, "loginService");
    MenuController = __decorate([
        /// <reference path="./angular-loader.ts" />
        controller("MenuController")
    ], MenuController);
    return MenuController;
})(Controller);
var controllers = new Module("controllers", ["services"]);
controllers.register();
controllers.registerController(new MenuController());
//# sourceMappingURL=controllers.js.map