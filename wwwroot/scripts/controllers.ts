/// <reference path="./angular-loader.ts" />
/// <reference path="./services.ts" />

/// the sample controller
@controller("MenuController")
class MenuController extends Controller {

    /// the resource
    @wired
    $resource: ng.resource.IResourceService

    @wired
    loginService: string

    /// the menu items
    menuItems: string[] = ["Home", "Tutorial", "Test"]

    /// called when the controller is loaded
    public onLoad() {
        console.log(this.loginService)
    }

}

var controllers = new Module("controllers", ["services"])
controllers.register()
controllers.registerController(new MenuController())