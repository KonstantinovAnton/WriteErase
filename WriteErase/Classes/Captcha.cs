using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;


using System.Drawing.Imaging;
using System.IO;

namespace WriteErase.Classes
{
    class Captcha
    {
        // заготовки для Captcha
        private const string letters = "QWERTYUIOPASDFGHJKLZXCVBNM";
        private const string numbers = "123456789";


        // генерация Captcha
        public static string generateCaptcha()
        {
            Random rnd = new Random();
            int maxRand = letters.Length - 1;

            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < 7; i++)
            {
                int index = rnd.Next(maxRand);
                stringBuilder.Append(letters[index]);
            }
            maxRand = numbers.Length - 1;
            for (int i = 0; i < 3; i++)
            {
                int index = rnd.Next(maxRand);
                stringBuilder.Append(numbers[index]);
            }

            Classes.GlobalValues.captchaText = stringBuilder.ToString();
            return stringBuilder.ToString();

        }

        // Генерация Captcha изображения
        public static CaptchaResult GetCaptchaImage(int width, int height, string capthcaCode)
        {
            Random rnd = new Random();
            using (Bitmap baseMap = new Bitmap(width, height))
            using (Graphics graphics = Graphics.FromImage(baseMap))
            {
                graphics.Clear(GetRandomLightColor());

                drawCaptchaCode();
                drawDisorderLine();
                AdjustRippleEffect();

                MemoryStream memoryStream = new MemoryStream();
                baseMap.Save(memoryStream, ImageFormat.Png);

                return new CaptchaResult
                {
                    captchaCode = capthcaCode,
                    captchaByteCode = memoryStream.ToArray(),
                    Timestamp = DateTime.Now
                };


                System.Drawing.Color GetRandomDeepColor()
                {
                    int redlow = 160, greenlow = 100, bluelow = 160;
                    return System.Drawing.Color.FromArgb(rnd.Next(redlow), rnd.Next(greenlow), rnd.Next(bluelow));
                }
                System.Drawing.Color GetRandomLightColor()
                {
                    int low = 180, high = 255;

                    int nRed = rnd.Next(high) % (high - low) + low;
                    int nGreen = rnd.Next(high) % (high - low) + low;
                    int nBlue = rnd.Next(high) % (high - low) + low;

                    return System.Drawing.Color.FromArgb(nRed, nGreen, nBlue);
                }

                // получить размер шрифта
                int GetFontSize(int imageWidth, int captchaCodeCount)
                {
                    var averageSize = imageWidth / captchaCodeCount;
                    return Convert.ToInt32(averageSize);
                }

                // нарисовать код Captcha
                void drawCaptchaCode()
                {

                    SolidBrush fontBrush = new SolidBrush(System.Drawing.Color.Black);
                    int fontSize = GetFontSize(100, 5);
                    Font fontBold = new Font(System.Drawing.FontFamily.GenericSansSerif, fontSize,
                    System.Drawing.FontStyle.Bold, GraphicsUnit.Pixel);

                    Font font = new Font(System.Drawing.FontFamily.GenericSansSerif, fontSize,
                    System.Drawing.FontStyle.Regular, GraphicsUnit.Pixel);


                    for (int i = 0; i < 10; i++)
                    {
                        fontBrush.Color = GetRandomDeepColor();
                        int shiftPx = fontSize / 6;

                        float x = i * fontSize + rnd.Next(-shiftPx, shiftPx) + rnd.Next(-shiftPx, shiftPx);
                        int maxY = height - fontSize;
                        if (maxY < 0) maxY = 0;
                        float y = rnd.Next(0, maxY);

                        if (rnd.Next(3) == 1)
                            graphics.DrawString(capthcaCode[i].ToString(), font, fontBrush, x, y);
                        else
                            graphics.DrawString(capthcaCode[i].ToString(), fontBold, fontBrush, x, y);
                    }
                }

                // нарисовать линии
                void drawDisorderLine()
                {
                    System.Drawing.Pen linePen = new System.Drawing.Pen(new SolidBrush(System.Drawing.Color.Black), 3);
                    for (int i = 0; i < 3; i++)
                    {
                        linePen.Color = GetRandomDeepColor();

                        System.Drawing.Point startPoint = new System.Drawing.Point(rnd.Next(0, width), rnd.Next(0, height));
                        System.Drawing.Point endPoint = new System.Drawing.Point(rnd.Next(0, width), rnd.Next(0, height));
                        graphics.DrawLine(linePen, startPoint, endPoint);

                    }
                }


                void AdjustRippleEffect()
                {
                    short nWave = 6;
                    int nWidht = baseMap.Width;
                    int nHeight = baseMap.Height;

                    System.Drawing.Point[,] pt = new System.Drawing.Point[nWidht, nHeight];

                    for (int x = 0; x < nWidht; x++)
                    {
                        for (int y = 0; y < nHeight; y++)
                        {
                            var xo = nWave * Math.Sin(2.0 * 3.1415 * y / 128.0);
                            var yo = nWave * Math.Cos(2.0 * 3.1415 * y / 128.0);

                            var newX = x + xo;
                            var newY = y + yo;

                            if (newX > 0 && newX < nWidht)
                                pt[x, y].X = (int)newX;
                            else
                                pt[x, y].X = 0;

                            if (newY > 0 && newY < nHeight)
                                pt[x, y].Y = (int)newY;
                            else
                                pt[x, y].Y = 0;
                        }
                    }
                }
            }
        }
    }
}
