using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lunar.WinUI3Playground.Models.Shapes
{
    public class Circle : IShape
    {
        private float _radius;
        private Vector2 _centerPoint;

        public Circle(float radius, Vector2 centerPoint)
        {
            _radius = radius;
            _centerPoint = centerPoint;
        }

        public float Radius => _radius;

        public Vector2 CenterPoint => _centerPoint;
    }
}
