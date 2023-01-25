using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work.entity
{
    public class BodyDimensions
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public int FootSize { get; set; }
        public string BodyDimensionUp { get; set; }
        public string BodyDimensionDown { get; set; }
        public string HeadDimension { get; set; }
        public double PercentBD { get; set; }
    }
}
