using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CGraphix
{
    abstract class Filters
    {
        protected abstract Color calculateNewPixelColor(Bitmap sourceImage, int x, int y);

        public Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker) {
            if (sourceImage == null) throw new ArgumentNullException("Выберите изображение");
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = 0; i < sourceImage.Width; i++){
                worker.ReportProgress((int)((float) i / resultImage.Width * 100));
                if (worker.CancellationPending) return null;
                for (int j = 0; j < sourceImage.Height; j++) {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }
            }
            return resultImage;
        }

        public int Clamp(int value, int min, int max)
        {
            if (value < min) 
                return min; 
            if (value > max) 
                return max;
            return value;
        }
    }

    class InvertFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            return Color.FromArgb(255 - sourceColor.R, 255 - sourceColor.G, 255 - sourceColor.B);
        }
    }

    class GrayScaleFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int intensity = (int)(0.299 * sourceColor.R + 0.587 * sourceColor.G + 0.114 * sourceColor.B);
            return Color.FromArgb(intensity, intensity, intensity);
        }
    }

    class SepiaFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            float k = 10;
            int intensity = (int)(0.36 * sourceColor.R + 0.53 * sourceColor.G + 0.11 * sourceColor.B);
            int R = Clamp((int)(intensity + 2 * k), 0, 255);
            int G = Clamp((int)(intensity + 0.5 * k), 0, 255);
            int B = Clamp((int)(intensity - 1 * k), 0, 255);
            return Color.FromArgb(R, G, B);
        }
    }

    class BrightnessFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int k = 10;
            return Color.FromArgb(Clamp(sourceColor.R + k, 0, 255), Clamp(sourceColor.G + k, 0, 255), Clamp(sourceColor.B + k, 0, 255)); ;
        }
    }

    class MatrixFilter : Filters 
    {
        protected float[,] kernel = null;
        protected MatrixFilter() { }
        public MatrixFilter(float[,] kernel)
        {
            this.kernel = kernel;
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;
            float resultR = 0;
            float resultG = 0;
            float resultB = 0;
            for(int l = -radiusY; l <= radiusY; l++) {
                for (int k = -radiusX; k <= radiusX; k++) {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    resultR += neighborColor.R * kernel[k + radiusX, l + radiusY];
                    resultG += neighborColor.G * kernel[k + radiusX, l + radiusY];
                    resultB += neighborColor.B * kernel[k + radiusX, l + radiusY];
                }
            }
            return Color.FromArgb(Clamp((int)resultR, 0, 255), Clamp((int)resultG, 0, 255), Clamp((int)resultB, 0, 255));
        }

        public Bitmap ApplyFilter(Bitmap image, int[,] structuringElement, Func<int[], int[,], int> operation, BackgroundWorker worker)
        {
            int maskWidth = structuringElement.GetLength(0);
            int maskHeight = structuringElement.GetLength(1);
            int maskCenterX = maskWidth / 2;
            int maskCenterY = maskHeight / 2;

            Bitmap result = new Bitmap(image.Width, image.Height);

            for (int x = 0; x < image.Width; x++)
            {
                worker.ReportProgress((int)((float)x / image.Width * 100));
                for (int y = 0; y < image.Height; y++)
                {
                    int[] pixelsUnderMaskR = new int[maskWidth * maskHeight];
                    int[] pixelsUnderMaskG = new int[maskWidth * maskHeight];
                    int[] pixelsUnderMaskB = new int[maskWidth * maskHeight];
                    for (int i = 0; i < maskWidth; i++)
                    {
                        for (int j = 0; j < maskHeight; j++)
                        {
                            int pixelX = x + i - maskCenterX;
                            int pixelY = y + j - maskCenterY;
                            if (pixelX >= 0 && pixelX < image.Width && pixelY >= 0 && pixelY < image.Height && structuringElement[i, j] == 1)
                            {
                                Color pixel = image.GetPixel(pixelX, pixelY);
                                pixelsUnderMaskR[maskWidth * i + j] = (pixel.R);
                                pixelsUnderMaskG[maskWidth * i + j] = (pixel.G);
                                pixelsUnderMaskB[maskWidth * i + j] = (pixel.B);
                            }
                        }
                    }
                    int newPixelValueR = operation(pixelsUnderMaskR.ToArray(), structuringElement);
                    int newPixelValueG = operation(pixelsUnderMaskG.ToArray(), structuringElement);
                    int newPixelValueB = operation(pixelsUnderMaskB.ToArray(), structuringElement);
                    result.SetPixel(x, y, Color.FromArgb(newPixelValueR, newPixelValueG, newPixelValueB));
                }
            }

            return result;
        }
    }

    class BlurFilter : MatrixFilter 
    { 
        public BlurFilter() 
        {
            int sizeX = 3;
            int sizeY = 3;
            kernel = new float[sizeX, sizeY];
            for (int i = 0; i < sizeX; i++)
                for (int j = 0; j < sizeY; j++)
                    kernel[i, j] = 1.0f / (float)(sizeX * sizeY);
        }
    }

    class GaussianFilter : MatrixFilter
    {
        public void createGaussianKernel(int radius, float sigma){
            int size = 2 * radius + 1;
            kernel = new float[size, size];
            float norm = 0;
            for (int i = -radius; i <= radius; i++)
                for (int j = -radius; j <= radius; j++){
                    kernel[i + radius, j + radius] = (float)(Math.Exp(-(i * i + j * j) / (sigma * sigma)));
                    norm += kernel[i + radius, j + radius];
                }
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    kernel[i, j] /= norm;
        }
        public GaussianFilter() { 
            createGaussianKernel(3, 2);
        }
    }

    class SobelFilter : MatrixFilter
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            float[,] xKernel = new float[3, 3]
            {
            { -1, 0, 1 },
            { -2, 0, 2 },
            { -1, 0, 1 }
            };
            float[,] yKernel = new float[3, 3]
            {
            { -1, -2, -1 },
            { 0, 0, 0 },
            { 1, 2, 1 }
            };
            float resultRx = 0;
            float resultGx = 0;
            float resultBx = 0;
            float resultRy = 0;
            float resultGy = 0;
            float resultBy = 0;
            float threshold = 128 * 128;
            for (int l = -1; l <= 1; l++)
                for (int k = -1; k <= 1; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    resultRx += neighborColor.R * xKernel[k + 1, l + 1];
                    resultGx += neighborColor.G * xKernel[k + 1, l + 1];
                    resultBx += neighborColor.B * xKernel[k + 1, l + 1];
                    resultRy += neighborColor.R * yKernel[k + 1, l + 1];
                    resultGy += neighborColor.G * yKernel[k + 1, l + 1];
                    resultBy += neighborColor.B * yKernel[k + 1, l + 1];
                }
            if (resultRx * resultRx + resultRy * resultRy > threshold || resultGx * resultGx + resultGy * resultGy > threshold || resultBx * resultBx + resultBy * resultBy > threshold)
                return Color.Black;
            //return Color.FromArgb(Clamp((int)resultRx, 0, 255), Clamp((int)resultGx, 0, 255), Clamp((int)resultBx, 0, 255));
            else return Color.White;
        }
    }

    class SharpnessFilter : MatrixFilter 
    { 
        public SharpnessFilter()
        {
            kernel = new float[3, 3]
            {
            { 0, -1, 0 },
            { -1, 5, -1 },
            { 0, -1, 0 }
            };
        } 
    }

    class EmbossingFilter : MatrixFilter 
    {
        public EmbossingFilter()
        {
            kernel = new float[3, 3]
            {
            { 0, 1, 0 },
            { 1, 0, -1 },
            { 0, -1, 0 }
            };
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;
            float resultR = 0;
            float resultG = 0;
            float resultB = 0;
            for (int l = -radiusY; l <= radiusY; l++)
            {
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    resultR += neighborColor.R * kernel[k + radiusX, l + radiusY];
                    resultG += neighborColor.G * kernel[k + radiusX, l + radiusY];
                    resultB += neighborColor.B * kernel[k + radiusX, l + radiusY];
                }
            }
            return Color.FromArgb(Clamp((int)((255 + resultR) / 2), 0, 255), Clamp((int)((255 + resultG) / 2), 0, 255), Clamp((int)((255 + resultB) / 2), 0, 255));
        }
    }

    class ShiftFilter : Filters 
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            if (x + 50 < sourceImage.Width) return sourceImage.GetPixel(x + 50, y);
            else return Color.FromArgb(0, 0, 0);
        }
    }

    class RotateFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            float mu = 1f;
            int centerX = sourceImage.Width / 2;
            int centerY = sourceImage.Height / 2;
            int pixelX = (int)((x - centerX) * Math.Cos(mu) - (y - centerY) * Math.Sin(mu) + centerX);
            int pixelY = (int)((x - centerX) * Math.Sin(mu) + (y - centerY) * Math.Cos(mu) + centerY);
            if (pixelX < sourceImage.Width && pixelY < sourceImage.Height && pixelX > 0 && pixelY > 0) return sourceImage.GetPixel(pixelX, pixelY);
            else return Color.FromArgb(0, 0, 0);
        }
    }

    class WaveFilter : Filters 
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int pixelX = (int)(x + 20 * Math.Sin(2 * Math.PI * y / 60));
            //int pixelX = (int)(x + 20 * Math.Sin(2 * Math.PI * x / 30));
            if (pixelX < sourceImage.Width && pixelX > 0) return sourceImage.GetPixel(pixelX, y);
            else return Color.FromArgb(0, 0, 0);
        }
    }

    class FrostedGlassFilter : Filters 
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Random rand = new Random();
            int pixelX = (int)(x + (rand.NextDouble() - 0.5) * 10);
            int pixelY = (int)(y + (rand.NextDouble() - 0.5) * 10);
            if (pixelX < sourceImage.Width && pixelY < sourceImage.Height && pixelX > 0 && pixelY > 0) return sourceImage.GetPixel(pixelX, pixelY);
            else return sourceImage.GetPixel(x,y);
        }
    }

    class MotionBlur : MatrixFilter 
    {
        public MotionBlur() 
        {
            int n = 7;
            kernel = new float[n, n];
            for (int i = 0; i < n; i++) kernel[i, i] = 1f / n;
        }
    }

    class RoughnessFilter : MatrixFilter
    {
        public RoughnessFilter()
        {
            kernel = new float[3, 3];
            for(int i = 0; i < 3; i++)
                for(int j = 0; j < 3; j++)
                    kernel[i, j] = -1f;
            kernel[1, 1] = 9;
        }
    }

    class BoundariesFilterSharr : MatrixFilter 
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            float[,] xKernel = new float[,]
            {
            { -3, 0, 3 },
            { -10, 0, 10 },
            { -3, 0, 3 }
            };
            float[,] yKernel = new float[,]
            {
            { -3, -10, -3 },
            { 0, 0, 0 },
            { 3, 10, 3 }
            };
            float resultRx = 0;
            float resultGx = 0;
            float resultBx = 0;
            float resultRy = 0;
            float resultGy = 0;
            float resultBy = 0;
            for (int l = -1; l <= 1; l++)
                for (int k = -1; k <= 1; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    resultRx += neighborColor.R * xKernel[k + 1, l + 1];
                    resultGx += neighborColor.G * xKernel[k + 1, l + 1];
                    resultBx += neighborColor.B * xKernel[k + 1, l + 1];
                    resultRy += neighborColor.R * yKernel[k + 1, l + 1];
                    resultGy += neighborColor.G * yKernel[k + 1, l + 1];
                    resultBy += neighborColor.B * yKernel[k + 1, l + 1];
                }
            Color newColor = Color.FromArgb(Clamp((int)Math.Sqrt(resultRx * resultRx + resultRy * resultRy), 0, 255), Clamp((int)Math.Sqrt(resultGx * resultGx + resultGy * resultGy), 0, 255), Clamp((int)Math.Sqrt(resultBx * resultBx + resultBy * resultBy), 0, 255));
            return newColor;
        }
    }

    class BoundariesFilterPruitt : MatrixFilter
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            float[,] xKernel = new float[,]
            {
            { -1, 0, 1 },
            { -1, 0, 1 },
            { -1, 0, 1 }
            };
            float[,] yKernel = new float[,]
            {
            { -1, -1, -1 },
            { 0, 0, 0 },
            { 1, 1, 1 }
            };
            float resultRx = 0;
            float resultGx = 0;
            float resultBx = 0;
            float resultRy = 0;
            float resultGy = 0;
            float resultBy = 0;
            float threshold = 128 * 128;
            for (int l = -1; l <= 1; l++)
                for (int k = -1; k <= 1; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    resultRx += neighborColor.R * xKernel[k + 1, l + 1];
                    resultGx += neighborColor.G * xKernel[k + 1, l + 1];
                    resultBx += neighborColor.B * xKernel[k + 1, l + 1];
                    resultRy += neighborColor.R * yKernel[k + 1, l + 1];
                    resultGy += neighborColor.G * yKernel[k + 1, l + 1];
                    resultBy += neighborColor.B * yKernel[k + 1, l + 1];
                }
            if (resultRx * resultRx + resultRy * resultRy > threshold || resultGx * resultGx + resultGy * resultGy > threshold || resultBx * resultBx + resultBy * resultBy > threshold)
                return Color.Black;
            else return Color.White;
        }
    }

    class GlowingEdgesFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            float[,] xKernel = new float[3, 3]
            {
            { -1, 0, 1 },
            { -2, 0, 2 },
            { -1, 0, 1 }
            };
            float[,] yKernel = new float[3, 3]
            {
            { -1, -2, -1 },
            { 0, 0, 0 },
            { 1, 2, 1 }
            };
            float resultRx = 0;
            float resultGx = 0;
            float resultBx = 0;
            float resultRy = 0;
            float resultGy = 0;
            float resultBy = 0;
            float threshold = 128 * 128;
            int maxR = 0;
            int maxG = 0;
            int maxB = 0;
            for (int l = -1; l <= 1; l++)
                for (int k = -1; k <= 1; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    resultRx += neighborColor.R * xKernel[k + 1, l + 1];
                    resultGx += neighborColor.G * xKernel[k + 1, l + 1];
                    resultBx += neighborColor.B * xKernel[k + 1, l + 1];
                    resultRy += neighborColor.R * yKernel[k + 1, l + 1];
                    resultGy += neighborColor.G * yKernel[k + 1, l + 1];
                    resultBy += neighborColor.B * yKernel[k + 1, l + 1];
                    maxR = maxR > neighborColor.R ? maxR : neighborColor.R;
                    maxG = maxG > neighborColor.G ? maxG : neighborColor.G;
                    maxB = maxB > neighborColor.B ? maxB : neighborColor.B;
                }
            if (resultRx * resultRx + resultRy * resultRy > threshold || resultGx * resultGx + resultGy * resultGy > threshold || resultBx * resultBx + resultBy * resultBy > threshold)
                return Color.FromArgb(maxR, maxG, maxB);
            //return Color.FromArgb(Clamp((int)resultRx, 0, 255), Clamp((int)resultGx, 0, 255), Clamp((int)resultBx, 0, 255));
            else return Color.Black;
        }
    }

    class LinearExpandFilter : Filters 
    {
        public int min = 255;
        public int max = 0;

        public void FindLevels(Bitmap image)
        {
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color sourceColor = image.GetPixel(i, j);
                    int intensity = (int)(0.36 * sourceColor.R + 0.53 * sourceColor.G + 0.11 * sourceColor.B);
                    min = intensity < min ? intensity : min;
                    max = intensity > max ? intensity : max;
                }
            }
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color oldPixel = sourceImage.GetPixel(x, y);
            return  Color.FromArgb((oldPixel.R - min) * 255 / (max - min), (oldPixel.G - min) * 255 / (max - min), (oldPixel.B - min) * 255 / (max - min));
        }
    }

    class AutolevelsFilter : Filters 
    {
        public int minR = 255;
        public int minG = 255;
        public int minB = 255;
        public int maxR = 0;
        public int maxG = 0;
        public int maxB = 0;

        public void FindColorLevels(Bitmap sourceImage)
        {
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color sourceColor = sourceImage.GetPixel(i, j);
                    minR = sourceColor.R < minR ? sourceColor.R : minR;
                    minG = sourceColor.G < minG ? sourceColor.G : minG;
                    minB = sourceColor.B < minB ? sourceColor.B : minB;
                    maxR = sourceColor.R > maxR ? sourceColor.R : maxR;
                    maxG = sourceColor.G > maxG ? sourceColor.G : maxG;
                    maxB = sourceColor.B > maxB ? sourceColor.B : maxB;
                }
            }
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color oldPixel = sourceImage.GetPixel(x, y);
            return Color.FromArgb((oldPixel.R - minR) * 255 / (maxR - minR), (oldPixel.G - minG) * 255 / (maxG - minG), (oldPixel.B - minB) * 255 / (maxB - minB));
        }
    }

    class GrayWorldFilter : Filters 
    {
        int avgR = 128;
        int avgG = 128;
        int avgB = 128;
        int avgA = 128;

        public void FindAvgColorLevels(Bitmap sourceImage)
        {
            int sumR = 0;
            int sumG = 0;
            int sumB = 0;
            int N = sourceImage.Width;
            int M = sourceImage.Height;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    Color sourceColor = sourceImage.GetPixel(i, j);
                    sumR += sourceColor.R;
                    sumG += sourceColor.G;
                    sumB += sourceColor.B;
                }
            }
            avgR = sumR / (N * M);
            avgG = sumG / (N * M);
            avgB = sumB / (N * M);
            avgA = (avgR + avgG + avgB) / 3;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color oldPixel = sourceImage.GetPixel(x, y);
            return Color.FromArgb(Clamp(oldPixel.R * avgA / avgR, 0, 255), Clamp(oldPixel.G * avgA / avgG, 0, 255), Clamp(oldPixel.B * avgA / avgB, 0, 255));
        }
    }

    class ColorFilter : Filters 
    {
        int R = 255;
        int G = 255;
        int B = 255;
        int srcR = 0;
        int srcG = 0;
        int srcB = 0;

        public void SetColors(Color color)
        {
            R = color.R; G = color.G; B = color.B;
        }

        public void SetSrcColors(Color color)
        { 
            srcR = color.R; srcG = color.G; srcB = color.B;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color oldPixel = sourceImage.GetPixel(x, y);
            return Color.FromArgb(Clamp(oldPixel.R * R / srcR, 0, 255), Clamp(oldPixel.G * G / srcG, 0, 255), Clamp(oldPixel.B * B / srcB, 0, 255));
        }
    }

    class PerfectReflectionFilter : Filters 
    {
        public int maxR = 0;
        public int maxG = 0;
        public int maxB = 0;

        public void FindLevels(Bitmap image)
        {
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color sourceColor = image.GetPixel(i, j);
                    maxR = sourceColor.R > maxR ? sourceColor.R : maxR;
                    maxG = sourceColor.G > maxG ? sourceColor.G : maxG;
                    maxB = sourceColor.B > maxB ? sourceColor.B : maxB;
                }
            }
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color oldPixel = sourceImage.GetPixel(x, y);
            return Color.FromArgb(Clamp(oldPixel.R * 255 / maxR, 0, 255), Clamp(oldPixel.G * 255 / maxG, 0, 255), Clamp(oldPixel.B * 255 / maxB, 0, 255));
        }
    }

    class MorphologicalOperations
    {
        private MatrixFilter _filter;
        private int[,] _structuringElement;

        public MorphologicalOperations()
        {
            _filter = new BlurFilter();
            _structuringElement = new int[,] { { 1, 1, 1, 1, 1}, { 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 } }; // Default structuring element
        }

        public void SetStructuringElement(int[,] structuringElement)
        {
            _structuringElement = structuringElement;
        }

        public Bitmap Dilation(Bitmap image, BackgroundWorker worker)
        {
            return _filter.ApplyFilter(image, _structuringElement, (pixels, mask) => pixels.Max(), worker);
        }

        public Bitmap Erosion(Bitmap image, BackgroundWorker worker)
        {
            return _filter.ApplyFilter(image, _structuringElement, (pixels, mask) => pixels.Min(), worker);
        }

        public Bitmap Opening(Bitmap image, BackgroundWorker worker)
        {
            return Dilation(_filter.ApplyFilter(image, _structuringElement, (pixels, mask) => pixels.Min(), worker), worker);
        }

        public Bitmap Closing(Bitmap image, BackgroundWorker worker)
        {
            return Erosion(_filter.ApplyFilter(image, _structuringElement, (pixels, mask) => pixels.Max(), worker), worker);
        }

        public Bitmap TopHat(Bitmap image, BackgroundWorker worker)
        {
            Bitmap openedImage = Opening(image, worker);
            Bitmap result = new Bitmap(image.Width, image.Height);
            for (int i = 0; i < image.Width; i++)
            {
                worker.ReportProgress((int)((float)i / image.Width * 100));
                for (int j = 0; j < image.Height; j++)
                {
                    int originalPixelR = image.GetPixel(i, j).R;
                    int openedPixelR = openedImage.GetPixel(i, j).R;
                    int resultPixelR = Math.Max(0, originalPixelR - openedPixelR);
                    int originalPixelG = image.GetPixel(i, j).G;
                    int openedPixelG = openedImage.GetPixel(i, j).G;
                    int resultPixelG = Math.Max(0, originalPixelG - openedPixelG);
                    int originalPixelB = image.GetPixel(i, j).B;
                    int openedPixelB = openedImage.GetPixel(i, j).B;
                    int resultPixelB = Math.Max(0, originalPixelB - openedPixelB);
                    result.SetPixel(i, j, Color.FromArgb(resultPixelR, resultPixelG, resultPixelB));
                }
            }
            return result;
        }

        public Bitmap BlackHat(Bitmap image, BackgroundWorker worker)
        {
            Bitmap closedImage = Closing(image, worker);
            Bitmap result = new Bitmap(image.Width, image.Height);
            for (int i = 0; i < image.Width; i++)
            {
                worker.ReportProgress((int)((float)i / image.Width * 100));
                for (int j = 0; j < image.Height; j++)
                {
                    int originalPixelR = image.GetPixel(i, j).R;
                    int closedPixelR = closedImage.GetPixel(i, j).R;
                    int resultPixelR = Math.Max(0, closedPixelR - originalPixelR);
                    int originalPixelG = image.GetPixel(i, j).G;
                    int closedPixelG = closedImage.GetPixel(i, j).G;
                    int resultPixelG = Math.Max(0, closedPixelG - originalPixelG);
                    int originalPixelB = image.GetPixel(i, j).B;
                    int closedPixelB = closedImage.GetPixel(i, j).B;
                    int resultPixelB = Math.Max(0, closedPixelB - originalPixelB);
                    result.SetPixel(i, j, Color.FromArgb(resultPixelR, resultPixelG, resultPixelB));
                }
            }
            return result;
        }

        public Bitmap Grad(Bitmap image, BackgroundWorker worker)
        {
            Bitmap ErodedImage = Erosion(image, worker);
            Bitmap DilatedImage = Dilation(image, worker);
            Bitmap result = new Bitmap(image.Width, image.Height);
            for (int i = 0; i < image.Width; i++)
            {
                worker.ReportProgress((int)((float)i / image.Width * 100));
                for (int j = 0; j < image.Height; j++)
                {
                    int originalPixelR = image.GetPixel(i, j).R;
                    int erodedPixelR = ErodedImage.GetPixel(i, j).R;
                    int dilatedPixelR = DilatedImage.GetPixel(i, j).R;
                    int resultPixelR = Math.Max(0, dilatedPixelR - erodedPixelR);
                    int originalPixelG = image.GetPixel(i, j).G;
                    int erodedPixelG = ErodedImage.GetPixel(i, j).G;
                    int dilatedPixelG = DilatedImage.GetPixel(i, j).G;
                    int resultPixelG = Math.Max(0, dilatedPixelG - erodedPixelG);
                    int originalPixelB = image.GetPixel(i, j).B;
                    int erodedPixelB = ErodedImage.GetPixel(i, j).B;
                    int dilatedPixelB = DilatedImage.GetPixel(i, j).B;
                    int resultPixelB = Math.Max(0, dilatedPixelB - erodedPixelB);
                    result.SetPixel(i, j, Color.FromArgb(resultPixelR, resultPixelG, resultPixelB));
                }
            }
            return result;
        }
    }

    class MedianFilter : Filters 
    {
        int radius = 1;

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int diam = (2 * radius + 1);
            int[] pixelsR = new int[diam * diam];
            int[] pixelsG = new int[diam * diam];
            int[] pixelsB = new int[diam * diam];
            for (int i = -radius; i <= radius; i++) {
                for(int j = -radius; j <= radius; j++)
                {
                    int idX = Clamp(x + i, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + j, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    pixelsR[diam * (i + radius) + (j + radius)] = (neighborColor.R);
                    pixelsG[diam * (i + radius) + (j + radius)] = (neighborColor.G);
                    pixelsB[diam * (i + radius) + (j + radius)] = (neighborColor.B);
                }
            }
            Array.Sort(pixelsR);
            Array.Sort(pixelsG);
            Array.Sort(pixelsB);
            return Color.FromArgb(pixelsR[diam * diam / 2], pixelsG[diam * diam / 2], pixelsB[diam * diam / 2]);
        }
    }

    class PinkFilter : Filters 
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            float k = 50;
            int intensity = (int)(0.36 * sourceColor.R + 0.53 * sourceColor.G + 0.11 * sourceColor.B);
            int R = Clamp((int)(intensity + 2 * k), 0, 255);
            int G = Clamp((int)(intensity - 1 * k), 0, 255);
            int B = Clamp((int)(intensity - 1 * k), 0, 255);
            return Color.FromArgb(R, G, B);
        }
    }
}
