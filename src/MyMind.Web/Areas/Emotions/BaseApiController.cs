using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyMind.Web.Areas.Emotions
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public abstract class BaseApiController : Controller
    {

    }
}
