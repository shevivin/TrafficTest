using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace lights.Controllers
{
    public class TrafficLightsController : Controller
    {     
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult lights(LightsRequest request)
        {
           
            if (!string.IsNullOrEmpty(request.color))
            {
                var s = trafficLine[request.color]; 
                return Json(s, JsonRequestBehavior.AllowGet);
            }
            var isGetValue = trafficLine.TryGetValue("yellow", out trafficModel value);
            return Json(value, JsonRequestBehavior.AllowGet);

        }

        private readonly Dictionary<string, trafficModel> trafficLine = new Dictionary<string, trafficModel>()
        {
             {"red",new trafficModel(new List<string>{"red","yellow"},1.5 ) } ,
             {"red,yellow",new trafficModel(new List<string>{"green" },3 ) } ,
             {"green",new trafficModel(new List<string>{"yellow" },1.5 ) } ,
             {"yellow",new trafficModel(new List<string>{"red" },3) }
           
            };

        public class LightsRequest
        {
            public string color { get; set; }
        }
       
    }
}