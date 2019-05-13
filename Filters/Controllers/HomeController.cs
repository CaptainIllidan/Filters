using Filters.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filters.Controllers
{
    [Message("This is the Controller-Scoped Filter", Order =10)]
    public class HomeController : Controller
    {
        [Message("This is the First Action-Scoped Filter", Order =1)]
        [Message("This is the Second Action-Scoped Filter", Order =-1)]
        public IActionResult Index() => View("Message",
                    "This is the Index action on the Home controller");

        public IActionResult SecondAction() => View("Message",
                    "This is the SecondAction action on the Home controller");

        public ViewResult GenerateException(int? id)
        {
            if (id == null)
            {
                throw new ArgumentException(nameof(id));
            }
            else if (id > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }
            else
            {
                return View("Message", "This value is {id}");
            }
        }
    }
}
