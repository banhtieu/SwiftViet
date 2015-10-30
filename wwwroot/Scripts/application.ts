/// <reference path="./angular-loader.ts" />

/// the sample application
@module("SwiftVietApplication")
@required(["ngResource", "controllers"])
class SwiftVietApplication extends Module {

    /// the factory
    @factory()
    public facebookId($resource) {
        return "AAA"
    }
    
}

var application = new SwiftVietApplication()
application.register()