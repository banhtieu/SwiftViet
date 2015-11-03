namespace SwiftViet.Angular {
	
	
	///
	/// a sample angular controller
	public class CalculatorController {
		
		/// Name 
		public int A { get; set; }
		
		public int B { get; set; }
		
		public int Result { get; set; }
		
		
		/// add the two integer
		public void Add()
        {
			Result = A + B;
		}

        public void Sub()
        {
            Result = A - B;
        }
		
	}
	
}