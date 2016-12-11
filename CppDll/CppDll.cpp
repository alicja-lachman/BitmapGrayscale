#include "stdafx.h"
#include "CppDll.h"

namespace BitmapFuncs {
	void GreyScale(unsigned char* rgbValues, int startIndex, int endIndex) {
		for (int i = startIndex; i < endIndex; i += 3) {
			int b = rgbValues[i];
			int g = rgbValues[i + 1];
			int r = rgbValues[i + 2];
			int average = (r + g + b) / 3;

			rgbValues[i] = average;
			rgbValues[i + 1] = average;
			rgbValues[i + 2] = average;
		}
	}
}