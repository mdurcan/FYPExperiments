using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.Structure;

namespace BackgroundSubtraction
{
    class DetectedObject
    {
        //variables
        private CircleF Circle;
        private List<Point> Centre;

        public DetectedObject(CircleF circle)
        {
            Circle = circle;
        }

        public CircleF GetCircle()
        {
            return Circle;
        }
    }
}
