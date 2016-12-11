#include <stdexcept>
using namespace std;

namespace BitmapFuncs {
	extern "C"  __declspec(dllexport)void GreyScale(unsigned char* rgbValues, int startIndex, int endIndex);
}