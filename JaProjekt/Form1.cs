using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Diagnostics;

namespace JaProjekt
{
    public partial class Form1 : Form
    {


        [DllImport("C:\\Users\\alachman\\Documents\\Visual Studio 2015\\Projects\\JaProjektBW\\x64\\Release\\CppDll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GreyScale(byte[] rgbValues, int startIndex, int endIndex);

        string inputFile;
        string outputFile;
        int threads;
        Bitmap bitmap;
        static int imageSize = -1;
        byte[] bmp;

        public Form1()
        {
            InitializeComponent();
            label_threads.Text = Environment.ProcessorCount.ToString();
        }

        private void button_wyzeruj_Click(object sender, EventArgs e)
        {
            button_path.Text = "";
            inputFile = null;
            button_output.Text = "";
            outputFile = null;
            radio_asm.Checked = true;
            radio_cpp.Checked = false;
            text_threads.Text = "0";
            label8.Text = "";
            pictureBox1.Image = null;
        }


        private void button_generuj_Click(object sender, EventArgs e)
        {

            //TODO delete later!!!
            //inputFile = "C:\\hantle2.jpg";
           // outputFile = "C:\\Users\\alachman\\Pictures\\heheh.jpg";
            if (inputFile != null && outputFile != null)
            {
                try
                {
                    if (Int32.Parse(text_threads.Text) == 0)
                        threads = Int32.Parse(label_threads.Text);
                    else threads = Int32.Parse(text_threads.Text);

                    bitmap = (Bitmap)Image.FromFile(inputFile);
                    imageSize = bitmap.Width * bitmap.Height * 3;
                    processImage();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid file" + ex.Message);
                }
            }

            else
                MessageBox.Show("Uzupełnij wszystkie pola!!!!");
        }
        private unsafe void processImage()
        {
            try
            {
                Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                System.Drawing.Imaging.BitmapData bmpData =
                    bitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                    bitmap.PixelFormat);
                //pobranie adresu pierwszej linii
                IntPtr ptr = bmpData.Scan0;

                //zadeklarowanie tablicy do przechowywania bajtów bitmapy
                int bytes = Math.Abs(bmpData.Stride) * bitmap.Height;
                label1.Text = "wielkosc zdjecia: " + imageSize;
                label2.Text = "ilosc bytow: " + bytes;
                byte[] rgbValues = new byte[bytes];


                //skopiowanie danych RGB do tablicy
                Marshal.Copy(ptr, rgbValues, 0, bytes);


                ThreadData[] threadData = new ThreadData[threads];
                int indexPerThread = rgbValues.Length / (threads);
                int processedThreads = 0;
                for (int i = 0; i < threads; i++)
                {
                    threadData[i].start = processedThreads;
                    threadData[i].end = processedThreads + indexPerThread;
                    processedThreads += indexPerThread;
                }

                var sw = Stopwatch.StartNew();
                if (radio_cpp.Checked)
                {
                    Parallel.ForEach(threadData, new ParallelOptions() { MaxDegreeOfParallelism = threads },
                (data) =>
                 {
                     GreyScale(rgbValues, data.start, data.end);


                 });
                }
                else
                {
                    /*This time we convert the IntPtr to a ptr*/
                    byte* scan0 = (byte*)bmpData.Scan0.ToPointer();
                    //byte* bitmap = (byte*)bitmap;
                    FunkcjeAsemblera funkcje = new FunkcjeAsemblera();
                    //funkcje.wywolajFunkcjeLicz(scan0, rgbValues, 70, rgbValues.Length);
                    // BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                

                    // startTime = DateTime.Now;
                    FunkcjeAsemblera.invokeGreyscaleASM(scan0, rgbValues,120, imageSize);

                    //  b.UnlockBits(bmData);

                    //  stopTime = DateTime.Now;
                    //  roznica = stopTime - startTime;
                    // timeASM = roznica.Milliseconds;
                    // pictureBox2.Image = b;
                    // return true;
                }

                // skopiowanie wartości RGB z powrotem do bitmapy
                Marshal.Copy(rgbValues, 0, ptr, bytes);

                // odblokowanie bitów
                bitmap.UnlockBits(bmpData);

                label8.Text += "Czas wykonania: " + sw.Elapsed.TotalSeconds + "\r\n";
                label8.Text += "Liczba wątków: " + threads + "\r\n";
                pictureBox1.Image = bitmap;
                bitmap.Save(outputFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void text_input_TextChanged(object sender, EventArgs e)
        {



        }



        private void text_watki_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            Int32.TryParse(text_threads.Text, out x);
            threads = x;
        }

        private void button_sciezka_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "BMP files (*.bmp)|*.bmp|JPG files (*.jpg*)|*.jpg*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {

                            button_path.Text = openFileDialog1.FileName;
                            inputFile = openFileDialog1.FileName;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd: Nie można otworzyć pliku z dysku. Powód: " + ex.Message);
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button_output_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.InitialDirectory = "c:\\";
            fileDialog.RestoreDirectory = true;
            fileDialog.CheckFileExists = false;
            fileDialog.ShowDialog();
            button_output.Text = fileDialog.FileName;
            outputFile = fileDialog.FileName;
        }
    }

    struct ThreadData
    {
        public int start;
        public int end;

    }
}
