========================================================================================================================================
								READ ME
========================================================================================================================================
This solution is implementing the functionality to convert from a currency number amount into English words. However it is 
also expendable to support multi human natural languages for the numbers and currencies. I used N-Tire architecture in this solutions
to have different layers each has its own task. The first layer is the Business Logic behind the actual number to words conversion.

	1- Classes implements an interface which allows to create the conversion mechanism depends on a CultureInfo Where it will contains 	      many information about numbering and the currency formats. This also will define which NL to convert to.
	2- A factory design pattern is used to route between this classes and fetch the appropriate converter class based on the 		   selected culture. It also supports to add custom converters at runtime if needed.
	3- Extension methods is also used to easily access the conversion implementation from double or long data types.
