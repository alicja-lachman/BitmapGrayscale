
using System.Runtime.InteropServices;

namespace JaProjekt
{
    unsafe class FunkcjeAsemblera
    {
      
        [DllImport("C:\\Users\\alachman\\Documents\\Visual Studio 2015\\Projects\\JaProjektBW\\JaProjekt\\bin\\Debug\\bibliotekaASM.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern void grayscaleASM(byte[] bmpOriginal,  int imageSizeInBytes);  //import funkcji z biblioteki Asemblera
        public static void invokeGreyscaleASM(byte[] bmpOrig,  int size)
        {
            grayscaleASM(bmpOrig,  size);
        }
    }
}
