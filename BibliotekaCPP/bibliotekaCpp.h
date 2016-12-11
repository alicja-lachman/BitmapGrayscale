#ifdef BIBLIOTEKACPP_EXPORTS
#define BIBLIOTEKACPP_API __declspec(dllexport) 
#else
#define BIBLIOTEKACPP_API __declspec(dllimport) 
#endif

namespace BibliotekaCPP
{
	// This class is exported from the MathLibrary.dll
	class Functions
	{
	public:
		// Returns a - b
		static BIBLIOTEKACPP_API unsigned char*  GreyScale(unsigned char* rgbValues, int size);
		static BIBLIOTEKACPP_API double Substract(double a, double b);

	};
}