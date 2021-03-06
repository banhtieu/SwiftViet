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
var Services = (function (_super) {
    __extends(Services, _super);
    function Services() {
        _super.apply(this, arguments);
    }
    /// the login service
    Services.prototype.getLoginService = function () {
        return "Hello";
    };
    Object.defineProperty(Services.prototype, "getLoginService",
        __decorate([
            factory()
        ], Services.prototype, "getLoginService", Object.getOwnPropertyDescriptor(Services.prototype, "getLoginService")));
    Services = __decorate([
        /// <reference path="./angular-loader.ts" />
        module("services")
    ], Services);
    return Services;
})(Module);
/// register new services
new Services().register();
//# sourceMappingURL=services.js.map