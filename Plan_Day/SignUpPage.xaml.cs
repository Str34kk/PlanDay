using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plan_Day
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        //Creating a background gradient
        private SKPaint backgroundBrush = new SKPaint()
        {
            Style = SKPaintStyle.Fill,
            Color = Color.Red.ToSKColor()
        };

        private void BackgroundGradien_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKImageInfo infoMain = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            SKColor gradientStart = ((Color)Application.Current.Resources["BackgroundGradientStartColor"]).ToSKColor();
            SKColor gradientEnd = ((Color)Application.Current.Resources["BackgroundGradientEndColor"]).ToSKColor();

            backgroundBrush.Shader = SKShader.CreateLinearGradient(
                new SKPoint(info.Width / 2, 0),
                new SKPoint(info.Width / 2, info.Height),
                new SKColor[]
                {
                    gradientStart, gradientEnd
                },
                new float[]
                {
                    0, 1
                },
                SKShaderTileMode.Clamp
                );
            SKRect backgroundBounds = new SKRect(0, 0, info.Width, info.Height);
            canvas.DrawRect(backgroundBounds, backgroundBrush);
        }

        //creating User SVG
        private void UserSVG_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            DrawSvgAtPoint(canvas, new SKPoint(info.Width / 2, info.Height / 2), (float)60, "Plan_Day.images.user.svg");
        }

        //creating Password SVG
        private void PasswordSVG_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            DrawSvgAtPoint(canvas, new SKPoint(info.Width / 2, info.Height / 2), (float)60, "Plan_Day.images.padlock.svg");
        }

        //creating Okey SVG
        private void OkeyIcon_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            DrawSvgAtPoint(canvas, new SKPoint(info.Width / 2, info.Height / 2), (float)400, "Plan_Day.images.okey.svg");
        }

        //Function to grnerate svg
        private void DrawSvgAtPoint(SKCanvas canvas, SKPoint location, float Size, string svgName)
        {
            using (Stream stream = GetType().Assembly.GetManifestResourceStream(svgName))
            {
                SkiaSharp.Extended.Svg.SKSvg svg = new SkiaSharp.Extended.Svg.SKSvg();
                svg.Load(stream);

                using (new SKAutoCanvasRestore(canvas))
                {
                    SKRect bounds = svg.ViewBox;

                    //Resizing
                    float xRatio = Size / bounds.Width;
                    float yRatio = Size / bounds.Height;
                    float ratio = Math.Min(xRatio, yRatio);

                    canvas.Translate(location.X - bounds.MidX * ratio, location.Y - bounds.MidY * ratio);
                    var matrix = SKMatrix.MakeScale(ratio, ratio);

                    //Redering
                    canvas.DrawPicture(svg.Picture, ref matrix);
                }
            }
        }

        //Creating lines under login and passswd SVG's
        private void LineUnderUserSVG_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            SKPaint linekBruch = new SKPaint()
            {
                Style = SKPaintStyle.Stroke,
                StrokeWidth = 4,
                Color = Color.White.ToSKColor()
            };

            canvas.DrawLine(0, info.Height, info.Width, info.Height, linekBruch);
        }

        //Back To Login Page
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            App.Current.MainPage = new MainPage();
        }
    }
}