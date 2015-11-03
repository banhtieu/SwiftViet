using Microsoft.AspNet.Mvc;

namespace SwiftViet.Controllers {
	
	
	
	///
	/// The about controller - simply give information
	/// about the controller
	[Route("api/about")]
	public class AboutController: Controller {
	
	
		///
		/// Return the info
		///
		[HttpGet]
		public string GetInfo() {
			return "Swift Talk";
		}	
	}
	
}