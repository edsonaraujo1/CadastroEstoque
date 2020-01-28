using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace iSysmp01
{
    public partial class Captcha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Para gerar números randômicos.
            Random random = new Random();

            string s = "";
            for (int i = 0; i < 6; i++)
                s = String.Concat(s, random.Next(10).ToString());

            // Cria uma imagem bitmap de 32-bit.
            Bitmap bitmap = new Bitmap(173, 50, PixelFormat.Format32bppArgb);

            // Crie um objeto gráfico para o desenho.
            Graphics g = Graphics.FromImage(bitmap);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, 173, 50);

            // Preencha o fundo.
            HatchBrush hatchBrush = new HatchBrush(HatchStyle.SmallConfetti,
                                                   Color.LightGray, Color.White);
            g.FillRectangle(hatchBrush, rect);

            // Configura a fonte do texto.
            SizeF size;
            float fontSize = rect.Height + 1;
            Font font;

            // Ajuste o tamanho da fonte até que o texto 
            // se encaixe dentro da imagem.
            do
            {
                fontSize--;
                font = new Font(System.Drawing.FontFamily.GenericSerif.Name,
                                fontSize, FontStyle.Bold);
                size = g.MeasureString(s, font);
            }
            while (size.Width > rect.Width);

            // Configure o formato de texto.
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            // Cria uma deformação no formato dos números.
            GraphicsPath path = new GraphicsPath();
            path.AddString(s, font.FontFamily, (int)font.Style, font.Size,
                           rect, format);
            float v = 4F;
            PointF[] points =
    {
         new PointF(
           random.Next(rect.Width) / v,
           random.Next(rect.Height) / v),
         new PointF(
           rect.Width - random.Next(rect.Width) / v,
           random.Next(rect.Height) / v),
         new PointF(
           random.Next(rect.Width) / v,
           rect.Height - random.Next(rect.Height) / v),
         new PointF(
           rect.Width - random.Next(rect.Width) / v,
           rect.Height - random.Next(rect.Height) / v)
     };
            Matrix matrix = new Matrix();
            matrix.Translate(0F, 0F);
            path.Warp(points, rect, matrix, WarpMode.Perspective, 0F);

            // Desenha o texto.
            hatchBrush = new HatchBrush(HatchStyle.LargeConfetti,
                                        Color.LightGray, Color.DarkGray);
            g.FillPath(hatchBrush, path);

            // Coloca um pouco de partículas no fundo.
            int m = Math.Max(rect.Width, rect.Height);
            for (int i = 0; i < (int)(rect.Width * rect.Height / 30F); i++)
            {
                int x = random.Next(rect.Width);
                int y = random.Next(rect.Height);
                int w = random.Next(m / 50);
                int h = random.Next(m / 50);
                g.FillEllipse(hatchBrush, x, y, w, h);
            }

            //Cria uma session com o valor da imagem
            Session["CaptchaImageText"] = s;

            // Define a imagem.
            font.Dispose();
            hatchBrush.Dispose();
            g.Dispose();
            Response.ContentType = "image/GIF";
            bitmap.Save(Response.OutputStream, ImageFormat.Gif);
            bitmap.Dispose();


        }
    }
}