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
///
var RemoteController = (function (_super) {
    __extends(RemoteController, _super);
    function RemoteController() {
        _super.apply(this, arguments);
    }
    /// call remote function
    RemoteController.prototype.callRemote = function (method, parameters) {
        var data = this.serialize();
        $(this.$element).addClass("loading");
        this.$http.post("scripts/angular/invoke", {
            'Name': this.controllerName,
            'Method': method,
            'ObjectData': data,
            'Parameters': parameters,
        }).then(this.callRemoteSuccess.bind(this));
    };
    /// handle remote call success
    RemoteController.prototype.callRemoteSuccess = function (response) {
        var data = response.data;
        if (data.ok) {
            var objectData = data.data;
            for (var key in objectData) {
                if (objectData.hasOwnProperty(key)) {
                    this[key] = objectData[key];
                }
            }
        }
        $(this.$element).removeClass("loading");
    };
    /// get remote method
    RemoteController.getRemoteMethod = function (name) {
        return function () {
            var args = [];
            for (var _i = 0; _i < arguments.length; _i++) {
                args[_i - 0] = arguments[_i];
            }
            this.callRemote(name, args);
        };
    };
    // serialize data
    RemoteController.prototype.serialize = function () {
        var data = {};
        for (var i = 0; i < this.properties.length; i++) {
            var property = this.properties[i];
            var value = this[property];
            if (value !== undefined) {
                data[property] = this[property];
            }
        }
        return data;
    };
    // onload
    RemoteController.prototype.onLoad = function () {
        if (this["OnLoad"] != undefined) {
            this["OnLoad"]();
        }
    };
    __decorate([
        wired
    ], RemoteController.prototype, "$http");
    __decorate([
        wired
    ], RemoteController.prototype, "$element");
    RemoteController = __decorate([
        /// <reference path="./angular-loader.ts" />
        controller("RemoteController")
    ], RemoteController);
    return RemoteController;
})(Controller);
var HelloWorldController = (function (_super) {
    __extends(HelloWorldController, _super);
    function HelloWorldController() {
        _super.apply(this, arguments);
        this.properties = ["Name"];
        this.Name = "Daniel";
        this.OnLoad = RemoteController.getRemoteMethod("OnLoad");
    }
    HelloWorldController = __decorate([
        controller("RemoteController")
    ], HelloWorldController);
    return HelloWorldController;
})(RemoteController);
application.registerController(new HelloWorldController());
//# sourceMappingURL=remote-controller.js.map