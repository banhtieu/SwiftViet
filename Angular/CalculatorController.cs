namespace SwiftTalkAPI.Angular {
	
	
	///
	/// a sample angular controller
	class CalculatorController {
		
		/// Name 
		public int A { get; set; }
		
		public int B { get; set; }
		
		public int Result { get; set; }
		
		
		/// add the two integer
		public void Add() {
			Result = A + B;
		}
		
	}
	
}