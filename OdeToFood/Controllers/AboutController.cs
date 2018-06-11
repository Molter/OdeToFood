using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Controllers
{
    [Route("about")]
    public class AboutController: Controller
    {
        [Route("")]
        public string Phone()
        {
            return "+55 (51) 996440301";
        }
        [Route("address")]
        public string about()
        {
            return "Brazil";
        }
    }
}
