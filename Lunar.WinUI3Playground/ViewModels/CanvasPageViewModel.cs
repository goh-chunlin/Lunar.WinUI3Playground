using Lunar.WinUI3Playground.Models.Shapes;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lunar.WinUI3Playground.ViewModels
{
    public class CanvasPageViewModel : ObservableObject
    {
        private ObservableCollection<IShape> _drawingObjects = new();
        private string _operation = string.Empty;

        public CanvasPageViewModel()
        {
            CreateShapeCommand = new RelayCommand<string>(CreateShape);
        }

        public IList<IShape> DrawingObjects => _drawingObjects;

        public string Operation
        {
            get => _operation;
            private set => SetProperty(ref _operation, value);
        }

        public ICommand CreateShapeCommand { get; }

        public Action<string> HeaderMenuClicked { get; set; }

        private void RegisterCreateDrawingObject(IShape drawingObject) 
        {
            _drawingObjects.Add(drawingObject);
            HeaderMenuClicked?.Invoke("RefreshCanvas");
        }

        private void ClearAllDrawingObjects()
        {
            _drawingObjects.Clear();
            HeaderMenuClicked?.Invoke("RefreshCanvas");
        }

        private void CreateShape(string shapeName) 
        {
            var rand = new Random();
            IShape newShape = null;

            switch (shapeName) 
            {
                case "Circle":
                    float radius = rand.NextSingle() * 200;
                    float centerX = rand.NextSingle() * 300;
                    float centerY = rand.NextSingle() * 300;

                    newShape = new Circle(radius, new Vector2(centerX, centerY));
                    Operation = $"Added a circle of radius {radius:0.00} at ({centerX:0.00},{centerY:0.00}).";

                    break;

                case "Rectangle":
                    float width = rand.NextSingle() * 1000;
                    float height = rand.NextSingle() * 400;
                    float topLeftX = rand.NextSingle() * 800;
                    float topLeftY = rand.NextSingle() * 800;

                    newShape = new Rectangle(new Vector2(topLeftX, topLeftY), width, height);
                    Operation = $"Added a rectangle of width {width:0.00} and height {height:0.00} at ({topLeftX:0.00},{topLeftY:0.00}).";

                    break;

                case "Reset":
                    ClearAllDrawingObjects();
                    Operation = $"Created a new canvas.";

                    break;
            }

            RegisterCreateDrawingObject(newShape);
        }
    }
}
