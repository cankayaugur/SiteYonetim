using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenMuhendislerSitesi.Domain.DTOS
{
    public class SlimDto
    {
        //public object server { get; set; }
        //    public object meta { get; set; }
        public Input input { get; set; }
        public Output output { get; set; }
        //public Actions actions { get; set; }

        public class Input
        {
            public string name { get; set; }
            //public string type { get; set; }
            //public int? size { get; set; }
            //public int? width { get; set; }
            //public int? height { get; set; }
        }

        public class Output
        {
            public int? width { get; set; }
            public int? height { get; set; }
            public string image { get; set; }
        }

        //public class Crop
        //{
        //    public int? x { get; set; }
        //    public double? y { get; set; }
        //    public int? width { get; set; }
        //    public double? height { get; set; }
        //    public string type { get; set; }
        //}

        //public class Size
        //{
        //    public int? width { get; set; }
        //    public int? height { get; set; }
        //}

        //public class Actions
        //{
        //    public Crop crop { get; set; }
        //    public Size size { get; set; }
        //}

    }
}
