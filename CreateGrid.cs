using System.Drawing;

static class CreateGrid
{
    static public int[,] CreateGridFromIMG(this Bitmap img, int RectX, int RectY)
    {
        int StepX = img.Width / RectX;
        int StepY = img.Height / RectY;
        img = img.ToGrayScale(StepX, StepY);

        int[,] result = new int[RectX, RectY];

        for (int i = 0; i < img.Width; i+= StepX)
        {
            for (int j = 0; j < img.Height; j+= StepY)
            {
                Color color = img.GetPixel(i, j);

                result[i / StepX, j / StepY] = color.R > 120 ? 0 : 1;
            }
        }

        return result;
    }

    private static Bitmap ToGrayScale(this Bitmap img, int StepX, int StepY)
    {
        for (int i = 0; i < img.Width; i += StepX)
        {
            for (int j = 0; j < img.Height; j += StepY)
            {
                var t = img.GetPixel(i, j);

                int TT = (t.G + t.B + t.R) / 3;

                img.SetPixel(i, j, Color.FromArgb(t.A, TT, TT, TT));
            }
        }
        return img;
    }
}

