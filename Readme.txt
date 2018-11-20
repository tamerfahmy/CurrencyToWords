========================================================================================================================================
																READ ME
========================================================================================================================================
This solution is implementing the functionality to convert from a currency number amount into English words. However it is 
also expendable to support multi human natural languages for the numbers and currencies. I used N-Tire architecture in this solutions
to have different layers each has its own task. The first layer is the Business Logic behind the actual number to words conversion.

Application Layers:
	Business Layer: 
		1- I've created here interface and classes which allowed me to create the conversion mechanism depends on a CultureInfo
		   Where it will contains many information about numbering and the currency formats. This also will define which NL to 
		   convert to.
		2- A factory design pattern is used to route between this classes and fetch the appropriate converter class based on the selected
		   culture. It also supports to add custom converters at runtime if needed.
		3- Extension methods is also used to easily access the conversion implementation from double or long data types.
	Service Layer:
		1- A simple WCF service is established to propose a service layer with a new convert method to used by service clients. This method has 
		   a complex return type which consider the error handling and client friendly.
	Presentation Layer:
		1- A simple WPF application is prepared to showcase the usage of the service layer with a friendly user interface, which handles the 
		   data input from the user and shows up the output results.