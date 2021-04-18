using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace grafikaLab5
{


    public partial class Form1 : Form
    {
        
        Image tukan;
        Image aurora; 
        Bitmap bitmapTukan;
        Bitmap bitmapAurora;
        
        int tukanWidth, tukanHeight, auroraWidth, auroraHeight;
     
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
        public Form1()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tukan = pictureBox1.Image;
            aurora = pictureBox3.Image;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            aurora = resizeImage(aurora, new Size(pictureBox3.Size.Width, pictureBox3.Size.Height));
            tukan = resizeImage(tukan, new Size(pictureBox1.Size.Width, pictureBox1.Size.Height));
            bitmapTukan = new Bitmap(tukan);
            bitmapAurora = new Bitmap(aurora);
            tukanWidth = bitmapTukan.Width;
            tukanHeight = bitmapTukan.Height;
            auroraWidth = bitmapAurora.Width;
            auroraHeight = bitmapAurora.Height;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < tukanHeight; y++)
            {
                for (int x = 0; x < tukanWidth; x++)
                {
                    Color p = bitmapTukan.GetPixel(x, y);
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    r = 255 - r;
                    g = 255 - g;
                    b = 255 - b;

                    bitmapTukan.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }
            }
            pictureBox2.Image = bitmapTukan;
        }
        
        public int checkIfInRGB(int value)
        {
            if (value >= 255) return 254;
            if (value <= 0) return 1;
            else return value;
        }

        private void blend1_Click(object sender, EventArgs e)
        {
           
            for(int y=0; y < tukanHeight; y++)
            {
                for(int x=0; x < tukanWidth; x++)
                {
                    Color tukanPixel = bitmapTukan.GetPixel(x, y);
                    Color auroraPixel = bitmapAurora.GetPixel(x, y);
                    int a = checkIfInRGB(tukanPixel.A + auroraPixel.A) ;
                    int r = checkIfInRGB(tukanPixel.R + auroraPixel.R);
                    int g = checkIfInRGB(tukanPixel.G + auroraPixel.G);
                    int b = checkIfInRGB(tukanPixel.B + auroraPixel.B);
                   

                    bitmapTukan.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                    
                }
            }
            pictureBox2.Image = bitmapTukan;
        }
      

        private void blend2_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < tukanHeight; y++)
            {
                for (int x = 0; x < tukanWidth; x++)
                {
                    Color tukanPixel = bitmapTukan.GetPixel(x, y);
                    Color auroraPixel = bitmapAurora.GetPixel(x, y);
                    int a = checkIfInRGB(tukanPixel.A + auroraPixel.A - 255);
                    int r = checkIfInRGB(tukanPixel.R + auroraPixel.R - 255);
                    int g = checkIfInRGB(tukanPixel.G + auroraPixel.G - 255);
                    int b = checkIfInRGB(tukanPixel.B + auroraPixel.B - 255);

                    bitmapTukan.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox2.Image = bitmapTukan;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            pictureBox2.Image = dostosujJasnosc(bitmapTukan, trackBar1.Value);
        }

        private void blend3_Click(object sender, EventArgs e)
        {
           for (int y = 0; y < tukanHeight; y++)
            {
                for (int x = 0; x < tukanWidth; x++)
                {
                    Color tukanPixel = bitmapTukan.GetPixel(x, y);
                    Color auroraPixel = bitmapAurora.GetPixel(x, y);
                    int a = tukanPixel.A;
                    int r = checkIfInRGB(Math.Abs(tukanPixel.R - auroraPixel.R));
                    int g = checkIfInRGB(Math.Abs(tukanPixel.G - auroraPixel.G)) ;
                    int b = checkIfInRGB(Math.Abs(tukanPixel.B - auroraPixel.B));

                    bitmapTukan.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox2.Image = bitmapTukan;
            
        }

        private void blend4_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < tukanHeight; y++)
            {
                for (int x = 0; x < tukanWidth; x++)
                {
                    Color tukanPixel = bitmapTukan.GetPixel(x, y);
                    Color auroraPixel = bitmapAurora.GetPixel(x, y);
                    int a = 255;
                    int r = checkIfInRGB(tukanPixel.R * auroraPixel.R);
                    int g = checkIfInRGB(tukanPixel.G * auroraPixel.G);
                    int b = checkIfInRGB(tukanPixel.B * auroraPixel.B);

                    bitmapTukan.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox2.Image = bitmapTukan;
        }

        private void blend5_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < tukanHeight; y++)
            {
                for (int x = 0; x < tukanWidth; x++)
                {
                    Color tukanPixel = bitmapTukan.GetPixel(x, y);
                    Color auroraPixel = bitmapAurora.GetPixel(x, y);
                    double a = checkIfInRGB(255- checkIfInRGB((255-tukanPixel.A))* checkIfInRGB(255-auroraPixel.B));
                    double r = checkIfInRGB(255- checkIfInRGB((255 - tukanPixel.R)) * checkIfInRGB(255 - auroraPixel.R));
                    double g = checkIfInRGB(255 - checkIfInRGB((255 - tukanPixel.G)) * checkIfInRGB(255 - auroraPixel.G));
                    double b = checkIfInRGB(255 - checkIfInRGB((255 - tukanPixel.B) )* checkIfInRGB(255 - auroraPixel.B));
                    bitmapTukan.SetPixel(x, y, Color.FromArgb((int)a, (int)r, (int)g, (int)b));

                }
            }
            pictureBox2.Image = bitmapTukan;
        }

        private void blend6_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < tukanHeight; y++)
            {
                for (int x = 0; x < tukanWidth; x++)
                {
                    Color tukanPixel = bitmapTukan.GetPixel(x, y);
                    Color auroraPixel = bitmapAurora.GetPixel(x, y);
                    int a = 255;
                    int r =  checkIfInRGB(255 - checkIfInRGB(Math.Abs(255 - tukanPixel.R - auroraPixel.R)));
                    int g =  checkIfInRGB(255 - checkIfInRGB(Math.Abs(255 - tukanPixel.G - auroraPixel.G)));
                    int b =  checkIfInRGB(255 - checkIfInRGB(Math.Abs(255 - tukanPixel.B - auroraPixel.B)));

                    bitmapTukan.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox2.Image = bitmapTukan;
        }

        private void blend7_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < tukanHeight; y++)
            {
                for (int x = 0; x < tukanWidth; x++)
                {
                    Color tukanPixel = bitmapTukan.GetPixel(x, y);
                    Color auroraPixel = bitmapAurora.GetPixel(x, y);
                    int a=255, r, g, b;                 

                    if (tukanPixel.R < auroraPixel.R)
                        r = auroraPixel.R;
                    else
                        r = auroraPixel.R;

                    if (tukanPixel.G < auroraPixel.G)
                        g = tukanPixel.G;
                    else
                        g = auroraPixel.G;

                    if (tukanPixel.B < auroraPixel.B)
                        b = tukanPixel.B;
                    else
                        b = auroraPixel.B;


                    bitmapTukan.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox2.Image = bitmapTukan;
        }

        private void blend8_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < tukanHeight; y++)
            {
                for (int x = 0; x < tukanWidth; x++)
                {
                    Color tukanPixel = bitmapTukan.GetPixel(x, y);
                    Color auroraPixel = bitmapAurora.GetPixel(x, y);
                    int a, r, g, b;
                    if (tukanPixel.A > auroraPixel.A)
                        a = tukanPixel.A;
                    else
                        a = auroraPixel.A;

                    if (tukanPixel.R > auroraPixel.R)
                        r = auroraPixel.R;
                    else
                        r = auroraPixel.R;

                    if (tukanPixel.G > auroraPixel.G)
                        g = tukanPixel.G;
                    else
                        g = auroraPixel.G;

                    if (tukanPixel.B > auroraPixel.B)
                        b = tukanPixel.B;
                    else
                        b = auroraPixel.B;


                    bitmapTukan.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox2.Image = bitmapTukan;
        }

        private void blend9_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < tukanHeight; y++)
            {
                for (int x = 0; x < tukanWidth; x++)
                {
                    Color tukanPixel = bitmapTukan.GetPixel(x, y);
                    Color auroraPixel = bitmapAurora.GetPixel(x, y);
                    int a = 255;
                    int r = checkIfInRGB(tukanPixel.R + auroraPixel.R - checkIfInRGB(510 * tukanPixel.R * auroraPixel.R));
                    int g = checkIfInRGB(tukanPixel.G + auroraPixel.G - checkIfInRGB(510 * tukanPixel.G * auroraPixel.G));
                    int b = checkIfInRGB(tukanPixel.B + auroraPixel.B - checkIfInRGB(510 * tukanPixel.B * auroraPixel.B));

                    bitmapTukan.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            pictureBox2.Image = bitmapTukan;
            }
        }

        private void blend10_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < tukanHeight; y++)
            {
                for (int x = 0; x < tukanWidth; x++)
                {
                    Color tukanPixel = bitmapTukan.GetPixel(x, y);
                    Color auroraPixel = bitmapAurora.GetPixel(x, y);
                    int a=255, r, g, b;
                   
                    if (tukanPixel.R < 255 * 0.5)
                        r = checkIfInRGB(2 * tukanPixel.R * auroraPixel.R);
                    else
                        r = checkIfInRGB(1 - 2 * (1 - tukanPixel.R) * (1 - auroraPixel.R));

                    if (tukanPixel.G < 255 * 0.5)
                        g = checkIfInRGB(2 * tukanPixel.G * auroraPixel.G);
                    else
                        g = checkIfInRGB(1 - 2 * (1 - tukanPixel.G) * (1 - auroraPixel.G));

                    if (tukanPixel.B < 255 * 0.5)
                        b = checkIfInRGB(2 * tukanPixel.B * auroraPixel.B);
                    else
                        b = checkIfInRGB(1 - 2 * (1 - tukanPixel.B) * (1 - auroraPixel.B));


                    bitmapTukan.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox2.Image = bitmapTukan;
        }

        private void blend11_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < tukanHeight; y++)
            {
                for (int x = 0; x < tukanWidth; x++)
                {
                    Color tukanPixel = bitmapTukan.GetPixel(x, y);
                    Color auroraPixel = bitmapAurora.GetPixel(x, y);
                    int a=255, r, g, b;
                   
                    if (auroraPixel.R < 255 * 0.5)
                        r = checkIfInRGB(510 * tukanPixel.R * auroraPixel.R);
                    else
                        r = checkIfInRGB(255 - 510 * (255 - tukanPixel.R) * (255- auroraPixel.R));

                    if (auroraPixel.G < 255 * 0.5)
                        g = checkIfInRGB(510 * tukanPixel.G * auroraPixel.G);
                    else
                        g = checkIfInRGB(255 - 510 * (255 - tukanPixel.G) * (255- auroraPixel.G));

                    if (auroraPixel.B < 255 * 0.5)
                        b = checkIfInRGB(510 * tukanPixel.B * auroraPixel.B);
                    else
                        b = checkIfInRGB(255 - 510 * (255 - tukanPixel.B) * (510 - auroraPixel.B));


                    bitmapTukan.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox2.Image = bitmapTukan;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bitmapTukan = new Bitmap(tukan);
            pictureBox2.Image = bitmapTukan;

        }

        private void blend12_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < tukanHeight; y++)
            {
                for (int x = 0; x < tukanWidth; x++)
                {
                    Color tukanPixel = bitmapTukan.GetPixel(x, y);
                    Color auroraPixel = bitmapAurora.GetPixel(x, y);
                    double a=255, r, g, b;
                 
                    if (auroraPixel.R /255 <  0.5)
                        r = checkIfInRGB(((int)(2 * tukanPixel.R/255 * auroraPixel.R/255 + Math.Pow(tukanPixel.R/255, 2) * (1 - 2 * auroraPixel.R/255))) * 255);
                    else
                        r = checkIfInRGB(((int)(Math.Sqrt(tukanPixel.R/255) * (2 * auroraPixel.R/255 - 1) + (2 * tukanPixel.R/255) * (1 - auroraPixel.R/255))) * 255);

                    if (auroraPixel.G /255< 0.5)
                        g = checkIfInRGB(((int)(2 * tukanPixel.G/255 * auroraPixel.G/255 + Math.Pow(tukanPixel.G/255, 2) * (1 - 2 * auroraPixel.G/255))) * 255);
                    else
                        g = checkIfInRGB(((int)(Math.Sqrt(tukanPixel.G/255) * (2 * auroraPixel.G/255 - 1) + (2 * tukanPixel.G/255) * (1 - auroraPixel.G/255))) * 255);

                    if (auroraPixel.B/255 <  0.5)
                        b = checkIfInRGB(((int)(2 * tukanPixel.B/255 * auroraPixel.B/255 + Math.Pow(tukanPixel.B/255, 2) * (1 - 2 * auroraPixel.B/255))) * 255);
                    else
                        b = checkIfInRGB(((int)(Math.Sqrt(tukanPixel.B/255) * (2 * auroraPixel.B/255 - 1) + (2 * tukanPixel.B/255) * (1 - auroraPixel.B/255))) * 255);


                    bitmapTukan.SetPixel(x, y, Color.FromArgb((int)a, (int)r, (int)g, (int)b));

                }
            }
            pictureBox2.Image = bitmapTukan;
        }

        private void blend13_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < tukanHeight; y++)
            {
                for (int x = 0; x < tukanWidth; x++)
                {
                    Color tukanPixel = bitmapTukan.GetPixel(x, y);
                    Color auroraPixel = bitmapAurora.GetPixel(x, y);
                  
                    int a = checkIfInRGB(tukanPixel.A / checkIfInRGB((255-auroraPixel.A)));
                    int r = checkIfInRGB(tukanPixel.R / checkIfInRGB((255 - auroraPixel.R)));
                    int g = checkIfInRGB(tukanPixel.G / checkIfInRGB((255 - auroraPixel.G)));
                    int b = checkIfInRGB(tukanPixel.B / checkIfInRGB((255 - auroraPixel.B)));

                    bitmapTukan.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox2.Image = bitmapTukan;
        }

        private void blend15_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < tukanHeight; y++)
            {
                for (int x = 0; x < tukanWidth; x++)
                {
                    Color tukanPixel = bitmapTukan.GetPixel(x, y);
                    Color auroraPixel = bitmapAurora.GetPixel(x, y);

                    int a = checkIfInRGB((int)(Math.Pow(tukanPixel.A, 2) / checkIfInRGB(255 - auroraPixel.A)));
                    int r = checkIfInRGB((int)(Math.Pow(tukanPixel.R, 2) / checkIfInRGB(255 - auroraPixel.R)));
                    int g = checkIfInRGB((int)(Math.Pow(tukanPixel.G, 2) / checkIfInRGB(255 - auroraPixel.G)));
                    int b = checkIfInRGB((int)(Math.Pow(tukanPixel.B, 2) / checkIfInRGB(255 - auroraPixel.B)));

                    bitmapTukan.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox2.Image = bitmapTukan;
        }

        private void bledn16_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < tukanHeight; y++)
            {
                for (int x = 0; x < tukanWidth; x++)
                {
                    Color tukanPixel = bitmapTukan.GetPixel(x, y);
                    Color auroraPixel = bitmapAurora.GetPixel(x, y);
                    int a = checkIfInRGB((trackBar2.Value * ((auroraPixel.A + 64) - tukanPixel.A)) / 256 + tukanPixel.A - (trackBar2.Value / 4));
                    int r = checkIfInRGB((trackBar2.Value * ((auroraPixel.R + 64) - tukanPixel.R)) / 256 + tukanPixel.R - (trackBar2.Value / 4));
                    int g = checkIfInRGB((trackBar2.Value * ((auroraPixel.G + 64) - tukanPixel.G)) / 256 + tukanPixel.G - (trackBar2.Value / 4));
                    int b = checkIfInRGB((trackBar2.Value * ((auroraPixel.B + 64) - tukanPixel.B)) / 256 + tukanPixel.B - (trackBar2.Value / 4));


                    bitmapTukan.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox2.Image = bitmapTukan;
        }

        private void blend14_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < tukanHeight; y++)
            {
                for (int x = 0; x < tukanWidth; x++)
                {
                    Color tukanPixel = bitmapTukan.GetPixel(x, y);
                    Color auroraPixel = bitmapAurora.GetPixel(x, y);
                    int a = checkIfInRGB(255 - (255 - tukanPixel.A) / checkIfInRGB(auroraPixel.A));
                    int r = checkIfInRGB(255 - (255 - tukanPixel.R) / checkIfInRGB(auroraPixel.R));
                    int g = checkIfInRGB(255 - (255 - tukanPixel.G) / checkIfInRGB(auroraPixel.G));
                    int b = checkIfInRGB(255 - (255 - tukanPixel.B) / checkIfInRGB(auroraPixel.B));

                    bitmapTukan.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox2.Image = bitmapTukan;
        }

        public static Bitmap dostosujJasnosc(Bitmap Image, int Value)
        {
            Bitmap tempBitmap = Image;
            float finalValue = (float)Value / 255.0f;
            Bitmap newBitmap = new Bitmap(tempBitmap.Width, tempBitmap.Height);
            Graphics newGraphics = Graphics.FromImage(newBitmap);
            float[][] floatColorMatrix =
            {
                new float[] {1,0,0,0,0},
                new float[] {0,1,0,0,0},
                new float[] {0,0,1,0,0},
                new float[] {0,0,0,1,0},
                new float[] {finalValue,finalValue,finalValue,1,1}
            };
            ColorMatrix newcolorMatrix = new ColorMatrix(floatColorMatrix);
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(newcolorMatrix);
            newGraphics.DrawImage(tempBitmap, new Rectangle(0, 0, tempBitmap.Width, tempBitmap.Height), 0, 0,
                tempBitmap.Width, tempBitmap.Height, GraphicsUnit.Pixel, attributes);
            attributes.Dispose();
            newGraphics.Dispose();

            return newBitmap;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            pictureBox2.Image = dostosujJasnosc(bitmapTukan, trackBar1.Value);
        }

     
    }
}
