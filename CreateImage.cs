using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

static class CreateImage
{
    static public Bitmap CreateIMG(this int[,] Grid, int RectSize, Size size)
    {
        Bitmap bitmap = new Bitmap(size.Width, size.Height);

        Graphics g = Graphics.FromImage(bitmap);

        var temp = GreateNeigbor(Grid);

        for (int i = 0; i < temp.GetLength(0); i++)
        {
            for (int j = 0; j < temp.GetLength(1); j++)
            {
                g.DrawImage(img[temp[i,j]], i * RectSize, j * RectSize, RectSize, RectSize);
            }
        }

        return bitmap;
    }

    private static Image[] img = new Image[]
    {
        Image.FromFile(Directory.GetCurrentDirectory() + $@"\Picture\num0.png"),
        Image.FromFile(Directory.GetCurrentDirectory() + $@"\Picture\num1.png"),
        Image.FromFile(Directory.GetCurrentDirectory() + $@"\Picture\num2.png"),
        Image.FromFile(Directory.GetCurrentDirectory() + $@"\Picture\num3.png"),
        Image.FromFile(Directory.GetCurrentDirectory() + $@"\Picture\num4.png"),
        Image.FromFile(Directory.GetCurrentDirectory() + $@"\Picture\num5.png"),
        Image.FromFile(Directory.GetCurrentDirectory() + $@"\Picture\num6.png"),
        Image.FromFile(Directory.GetCurrentDirectory() + $@"\Picture\num7.png"),
        Image.FromFile(Directory.GetCurrentDirectory() + $@"\Picture\num8.png"),       
        Image.FromFile(Directory.GetCurrentDirectory() + $@"\Picture\num10.png")
    };

    private static readonly Point[] NextPos = new Point[]
    {
        new Point(1, 0),
        new Point(1, 1),
        new Point(0, 1),
        new Point(-1, 0),
        new Point(-1, -1),
        new Point(0, -1),
        new Point(-1, 1),
        new Point(1, -1),
    };
    private static bool ProvOutRangeArray(Point point, Point NowPosition, int Leght1, int Leght2) => point.X + NowPosition.X < 0 || point.X + NowPosition.X >= Leght1 || point.Y + NowPosition.Y < 0 || point.Y + NowPosition.Y >= Leght2;
    private static int[,] GreateNeigbor(int[,] grid)
    {
        int[,] result = new int[grid.GetLength(0), grid.GetLength(1)];

        for (int x = 0; x < result.GetLength(0); x++)
        {
            for (int y = 0; y < result.GetLength(1); y++)
            {
                if (grid[x, y] == 1)
                { 
                    result[x, y] = 9; 
                    continue; 
                }

                int Sum = 0;

                for (int i = 0; i < NextPos.Length; i++)
                {
                    if (ProvOutRangeArray(NextPos[i], new Point(x, y), grid.GetLength(0), grid.GetLength(1)))
                        continue;
                    if (grid[x + NextPos[i].X, y + NextPos[i].Y] == 1)
                        Sum++;
                }
                result[x, y] = Sum;
            }
        }

        return result;
    }
}

