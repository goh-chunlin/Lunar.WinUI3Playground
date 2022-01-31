using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lunar.WinUI3Playground.Models.Shapes
{
    public class Rectangle : IShape
    {
        private Vector2 _topLeft;

        private float _width;

        private float _height;

        public Rectangle(Vector2 topLeft, float width, float height)
        {
            _topLeft = topLeft;
            _width = width;
            _height = height;
        }

        public Vector2 TopLeft => _topLeft;

        public float Width => _width;

        public float Height => _height;
    }
}
