/// <reference path="./angular-loader.ts" />
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
/// the sample application
var SwiftVietApplication = (function (_super) {
    __extends(SwiftVietApplication, _super);
    function SwiftVietApplication() {
        _super.apply(this, arguments);
    }
    /// the factory
    SwiftVietApplication.prototype.facebookId = function ($resource) {
        return "AAA";
    };
    Object.defineProperty(SwiftVietApplication.prototype, "facebookId",
        __decorate([
            factory()
        ], SwiftVietApplication.prototype, "facebookId", Object.getOwnPropertyDescriptor(SwiftVietApplication.prototype, "facebookId")));
    SwiftVietApplication = __decorate([
        /// <reference path="./angular-loader.ts" />
        module("SwiftVietApplication"),
        required(["ngResource", "controllers"])
    ], SwiftVietApplication);
    return SwiftVietApplication;
})(Module);
var application = new SwiftVietApplication();
application.register();
//# sourceMappingURL=application.js.map