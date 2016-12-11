
using System.Runtime.InteropServices;

namespace JaProjekt
{
    unsafe class FunkcjeAsemblera
    {
       // [DllImport("C:\\Users\\alachman\\Documents\\Visual Studio 2015\\Projects\\JaProjektBW\\JaProjekt\\bin\\Release\\bibliotekaASM.dll", CallingConvention = CallingConvention.StdCall)]
       // private static extern void rozjasnijA(byte[] rgbValues, int start, int end); //import funkcji z biblioteki asemblera
        [DllImport("C:\\Users\\alachman\\Documents\\Visual Studio 2015\\Projects\\JaProjektBW\\JaProjekt\\bin\\Debug\\bibliotekaASM.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern void grayscaleASM(byte* bmpDataScan0, byte[] bmpOriginal, short value, int imageSizeInBytes);  //import funkcji z biblioteki Asemblera
        public static void invokeGreyscaleASM(byte *bmpDataScan, byte[] bmpOrig, short val, int size)
        {
       
            grayscaleASM(bmpDataScan, bmpOrig, val, size);

        
        }

        //  private static extern void grayscaleASM(byte[] b, int Height, int Width, int Offset);  //import funkcji z biblioteki Asemblera
        //  public void wywolajFunkcjeLicz(byte[] values,int height, int width, int offset)
        //  {
        //      grayscaleASM(values, height, width, offset);
        //  }
        // {
        ///     rozjasnijA(values, start, end);
        //}
    }
}
