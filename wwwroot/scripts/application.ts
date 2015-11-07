/// <reference path="./angular-loader.ts" />

/// the sample application
@module("SwiftVietApplication")
@required(["ngResource", "controllers", "ngMaterial"])
class SwiftVietApplication extends Module {
    
}

var application = new SwiftVietApplication()
application.register()