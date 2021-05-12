using System.Collections.Generic;

namespace lights.Controllers
{
    public class trafficModel
    {
        public List<string> color { get; set; }
        public double? time { get; set; }
        public trafficModel(List<string> color, double time)
        {
            this.color = color;
            this.time = time;
        }
    }
}