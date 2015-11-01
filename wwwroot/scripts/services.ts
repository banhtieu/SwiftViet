/// <reference path="./angular-loader.ts" />


@module("services")
class Services extends Module {


    /// the login service
    @factory()
    public getLoginService() {
        return "Hello"
    }

}


/// register new services
new Services().register()