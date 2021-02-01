using App.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
	public class BaseController : Controller
	{
		protected IActionResult ShowCrawledData(List<Rating> model)
		{
			return View("CrawledData", model);
		}
	}
}
