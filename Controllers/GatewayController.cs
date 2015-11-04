using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json;

namespace SwiftViet.Controllers {
	
	public class InvokeData {
		
		/// Name of the controller
		public string Name {get; set;}
		
		/// the method name
		public string Method {get; set;}
		
		/// list of ObjectData
		public Dictionary<string, object> ObjectData {get; set;}
		
		/// dynamic object parameters
		public object[] Parameters {get; set;}
	}
	
	
	[Route("scripts/angular")]
	public class GatewayController: Controller {
	

        /// <summary>
        /// 
        /// </summary>
        private IServiceProvider ServiceProvider { get; set; }

        /// <summary>
        /// Gateway controller
        /// </summary>
        public GatewayController(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }
	
		/// Get the controller type
		private Type GetControllerType(string name) {
			var typeName = "SwiftViet.Angular." + name;
			return Type.GetType(typeName, false);
		}
		///
		/// Get controller script name
		///
		[Route("{name}.js")]
		public string GetControllerScript(string name) {
			var definition = new StringBuilder();
			
			try {
			
				var type = GetControllerType(name);
				
				var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
									.Where(propertyInfo => propertyInfo.CanWrite);
									
				var propertiesName = from propertyInfo in properties select propertyInfo.Name; 

				var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);
				var methodNames = from methodInfo in methods select methodInfo.Name;
				
				definition.AppendFormat("var {0} = (function (_super) {{\n", name);	
				definition.AppendFormat("  __extends({0}, _super);\n", name);
				definition.AppendFormat("  function {0}() {{\n", name);
				definition.AppendFormat("    _super.apply(this, arguments);\n");
				definition.AppendFormat("    this.properties = ['{0}']\n", string.Join("', '", propertiesName));
				
				foreach (var methodName in methodNames) {	
					definition.AppendFormat("    this.{0} = RemoteController.getRemoteMethod('{0}');\n", methodName);
				}
				
				definition.Append("  }\n");
				
				definition.AppendFormat("  {0} = __decorate([\n", name);
				definition.AppendFormat("    controller('{0}')\n", name);
				definition.AppendFormat("  ], {0});\n", name);
				definition.AppendFormat("  return {0};\n", name);
				definition.Append("})(RemoteController);\n");
				
				definition.AppendFormat("application.registerController(new {0}());\n", name);
				
			} catch (Exception e) {
				Console.WriteLine(e.Message);
				Console.WriteLine(e.StackTrace);
			}
			
			return definition.ToString();
		}
		
		
		///
		/// invoke a method
		[Route("invoke")]
		[HttpPost]
		public Dictionary<string, object> Invoke([FromBody] InvokeData data) {
			
			var type = GetControllerType(data.Name);
			
			Dictionary<string, object> result = null;
			
			try {	
				var requestedMethod = type.GetMethod(data.Method);
                var instance = CreateInstance(type);

                SetObjectData(instance, data.ObjectData);

				var parameters = GetParameters(data.Parameters, requestedMethod);
				
				requestedMethod.Invoke(instance, parameters);
				
				var afterData = Serialize(instance); 	
				
				result = new Dictionary<string, object>() {
					{"ok", true},
					{"data", afterData}
				};
				
			} catch (Exception exception){
				result = new Dictionary<string, object>() {
					{"ok", false},
					{"message", exception.Message},
					{"trace", exception.StackTrace},
				};
			}
			
			return result;
		}


        /// <summary>
        /// Create an Instance of Object
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private object CreateInstance(Type type)
        {
            var constructor = type.GetConstructors().FirstOrDefault();
            var constructorParameters = constructor.GetParameters();

            var injectedServices = new object[constructorParameters.Length];

            for (var i = 0; i < injectedServices.Length; i++)
            {
                var constructorParameter = constructorParameters[i];
                injectedServices[i] = ServiceProvider.GetService(constructorParameter.ParameterType);
            }

            return Activator.CreateInstance(type, injectedServices);
        }

        /// <summary>
        /// Get Parameter type
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="requestedMethod"></param>
        /// <returns></returns>
        private object[] GetParameters(object[] parameters, MethodInfo requestedMethod)
        {
            var result = new object[parameters.Length];
			var parameterInfos = requestedMethod.GetParameters();
			
			for (var i = 0; i < parameterInfos.Length; i++) {
				var parameterInfo = parameterInfos[i];
				var parameter = parameters[i];
				
				result[i] = ConvertType(parameter, parameterInfo.ParameterType);
			}
			
			return result;
        }

		/// convert an object to target type
        private object ConvertType(object parameter, Type parameterType)
        {
			var jsonData = JsonConvert.SerializeObject(parameter);
			return JsonConvert.DeserializeObject(jsonData, parameterType);

        }



        ///
        /// Set Object Data
		/// <parameter name="instance">The instance<parameter>
        private void SetObjectData(object instance, Dictionary<string, object> objectData) {
			
			var type = instance.GetType();
			
			foreach (var element in objectData) {
				var propertyName = element.Key;
				var propertyInfo = type.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
				
				if (propertyInfo != null && propertyInfo.CanWrite) {
					var value = ConvertType(element.Value, propertyInfo.PropertyType);
				
					propertyInfo.SetValue(instance, value);
				}
			}
		}
		
		/// Serialize the object into variables
		private Dictionary<string, object> Serialize(object instance) {
			var result = new Dictionary<string, object>();
			var type = instance.GetType();
			var properties = type.GetProperties(BindingFlags.Public 
								| BindingFlags.Instance);
			
			foreach (var objectProperty in properties) {
				result.Add(objectProperty.Name, objectProperty.GetValue(instance));
			}
			
			return result;
		}
	} 
}