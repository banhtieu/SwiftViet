/// <reference path="./angular-loader.ts" />

///
@controller("RemoteController")
class RemoteController extends Controller {
	
	@wired 
	$http: ng.IHttpService
	
	@wired
	$element: HTMLElement
		
	properties: string[]
	
	Name: string
	
	/// call remote function
	public callRemote(method: string, parameters: any[]) {
		var data = this.serialize()
		
		$(this.$element).addClass("loading");
		
		this.$http.post("scripts/angular/invoke", {
			'Name': this.controllerName,
			'Method': method,
			'ObjectData': data,
			'Parameters': parameters,
		}).then(			
			this.callRemoteSuccess.bind(this)
		)
	}
	
	/// handle remote call success
	public callRemoteSuccess(response) {
		var data = response.data
		if (data.ok) {
			var objectData = data.data
			for (var key in objectData) {
				if (objectData.hasOwnProperty(key)){
					this[key] = objectData[key]
				}
			}
		}
		
		$(this.$element).removeClass("loading");
	}
	
	/// get remote method
	public static getRemoteMethod(name: string) {
		return function(...args: any[]){
			this.callRemote(name, args);
		}
	}
	
	// serialize data
	public serialize(): any {
		
		var data = {}
		
		for (var i = 0; i < this.properties.length; i++) {
			var property = this.properties[i]
			var value = this[property]
			
			if (value !== undefined) {
				data[property] = this[property]
			}
		}
		
		return data
	}
	
	// onload
	public onLoad() {
		if (this["OnLoad"] != undefined) {
			this["OnLoad"]()
		}
	}	
	
}

@controller("RemoteController")
class HelloWorldController extends RemoteController {
	properties: string[] = ["Name"]
	Name: string = "Daniel"
	OnLoad: Function = RemoteController.getRemoteMethod("OnLoad")
}

application.registerController(new HelloWorldController())