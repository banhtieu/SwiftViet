/// <reference path="../Library/angularjs/angular.d.ts" />
/// <reference path="../Library/angularjs/angular-resource.d.ts" />
/// <reference path="../Library/angularjs/angular-animate.d.ts" />
/// <reference path="../Library/angularjs/angular-route.d.ts" />
/// <reference path="../Library/angularjs/angular-sanitize.d.ts" />


window["Controller"] = function () { };

var FactoryDefinition = (function () {
    /// initilize a Factory Definition object
    function FactoryDefinition(name, dependencies, method) {
        this.name = name;
        this.dependencies = dependencies;
        this.method = method;
    }
    return FactoryDefinition;
})();

/// base class for all application
var Module = (function () {
    /// name of the constructor
    function Module(name, dependencies) {
        if (name !== undefined) {
            this.moduleName = name;
        }
        if (dependencies !== undefined) {
            this.requiredModules = dependencies;
        }
    }
    /// register the application
    Module.prototype.register = function () {
        if (this.requiredModules === undefined) {
            this.requiredModules = [];
        }
        this.module = angular.module(this.moduleName, this.requiredModules);
        if (this.factories !== undefined) {
            /// register factory methods
            for (var i = 0; i < this.factories.length; i++) {
                var factory = this.factories[i];
                var definition = factory.dependencies;
                definition.push(factory.method);
                this.module.factory(factory.name, definition);
            }
        }
    };
    /// register the controller
    Module.prototype.registerController = function (controller) {
        var description = ["$scope"].concat(controller.injectModules);
        description.push(function () {
            var $scope = arguments[0];
            // copy properties
            for (var property in controller) {
                $scope[property] = controller[property];
            }
            // copy injected modules
            for (var i = 0; i < controller.injectModules.length; i++) {
                var moduleName = controller.injectModules[i];
                $scope[moduleName] = arguments[i + 1];
            }
            $scope.onLoad();
        });
        this.module.controller(controller.controllerName, description);
    };
    return Module;
})();
/// @controller
function controller(name) {
    /// the controller name
    return function (target) {
        target.prototype.controllerName = name;
    };
}
/// @application decorator
function module(name) {
    return function (target) {
        target.prototype.moduleName = name;
    };
}
/// @inject modules
function wired(target, propertyKey) {
    var controller = target;
    if (controller.injectModules === undefined) {
        controller.injectModules = [];
    }
    controller.injectModules.push(propertyKey);
}
/// @required decorator
function required(modules) {
    return function (target) {
        target.prototype.requiredModules = modules;
    };
}
/// @factory in an application
function factory(name, dependencies) {
    if (name === void 0) { name = undefined; }
    if (dependencies === void 0) { dependencies = []; }
    /// add a factory definition to the application class
    return function (target, propertyKey, descriptor) {
        if (Array.isArray(name) && dependencies === undefined) {
            dependencies = name;
            name = undefined;
        }
        if (name === undefined) {
            name = propertyKey.replace(/^get/, "");
            name = name.charAt(0).toLowerCase() + name.slice(1);
        }
        var definition = new FactoryDefinition(name, dependencies, descriptor.value);
        if (target.factories === undefined) {
            target.factories = [];
        }
        target.factories.push(definition);
    };
}
//# sourceMappingURL=angular-loader.js.map