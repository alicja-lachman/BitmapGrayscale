// BibliotekaCPP.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "bibliotekaCpp.h"

namespace BibliotekaCPP
{
	unsigned char* Functions::GreyScale(unsigned char* rgbValues, int size)
	{
		for (int counter = 2; counter <size; counter += 3)
			rgbValues[counter] = 255;

		return rgbValues;
	}

}
