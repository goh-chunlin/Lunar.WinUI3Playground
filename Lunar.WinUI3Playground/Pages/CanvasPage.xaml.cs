using Lunar.WinUI3Playground.Models.Shapes;
using Lunar.WinUI3Playground.ViewModels;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.UI.Xaml;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Lunar.WinUI3Playground.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CanvasPage : Page
    {
        private CanvasPageViewModel _viewModel = new CanvasPageViewModel();

        public CanvasPage()
        {
            this.InitializeComponent();

            _viewModel.HeaderMenuClicked = cmd =>
            {
                switch (cmd)
                {
                    case "RefreshCanvas": RefreshCanvas(); break;
                }

            };
        }

        public CanvasPageViewModel ViewModel => _viewModel;

        void CanvasControl_Draw(CanvasControl sender, CanvasDrawEventArgs args)
        {
            Windows.UI.Color penColor = Colors.Black;

            CanvasCommandList cl = new CanvasCommandList(sender);
            using (CanvasDrawingSession clds = cl.CreateDrawingSession())
            {
                foreach (IShape shape in _viewModel.DrawingObjects)
                {
                    if (shape is Circle circle) 
                    {
                        clds.DrawCircle(
                            circle.CenterPoint, circle.Radius, 
                            penColor);
                    } 
                    else if (shape is Rectangle rectangle)
                    {
                        clds.DrawRectangle(
                            new Rect(rectangle.TopLeft.X, rectangle.TopLeft.Y, rectangle.Width, rectangle.Height), 
                            penColor);
                    }
                }
            }

            args.DrawingSession.DrawImage(cl);
        }

        void RefreshCanvas()
        {
            MainCanvas.Invalidate();
        }
    }
}
