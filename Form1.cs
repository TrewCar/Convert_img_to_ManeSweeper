
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System;


public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        timer1.Start();     
    }
    int RectSZ = 10; // cell size

    int i = 0; // the initial frame
    private void timer1_Tick(object sender, EventArgs e)
    {
        Image image;
        try
        {
            image = Image.FromFile(Directory.GetCurrentDirectory() + $@"\BadApple\BadApple_{Tototott(i)}.png");           
        }
        catch (Exception)
        {

            timer1.Stop();
            return;
        }

        Bitmap ttt = (Bitmap)image;
        ttt= new Bitmap(ttt, 480 *2,360*2);

        i++;
     
        pictureBox1.Image = ttt.CreateGridFromIMG(ttt.Width / RectSZ, ttt.Height / RectSZ).CreateIMG(RectSZ, ttt.Size);
        pictureBox1.Invalidate();

        //pictureBox1.Image.Save($@"D:\Bad Apple 2\BadApple{i}.png"); //To save frames
    }
    private string Tototott(int i )
    {
        var t = i.ToString();

        while (t.Length < 5)
        {
            t = "0" + t;
        }
        return t;
    }
}

