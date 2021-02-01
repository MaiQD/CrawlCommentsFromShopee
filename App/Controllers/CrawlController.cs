using App.CommonHelper;
using App.Models;
using App.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
	public class CrawlController : BaseController
	{
		private readonly IApiServices _apiServices;

		public CrawlController(IApiServices apiServices)
		{
			_apiServices = apiServices;
		}
		public IActionResult CrawlOneProduct()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CrawledDataOneProductAsync(string shopeeUrl)
		{
			var list = new List<Rating>() ;
			if (!string.IsNullOrEmpty(shopeeUrl))
			{
				var searhModel = shopeeUrl.GetItemAndShopIdFromUrl();
				while (true)
				{
					var res = await _apiServices.GetObjectApi<GetRatingResponseModel>(Common._urlGetRating, searhModel);
					if (res?.data != null && res?.data?.ratings != null && res.data.ratings.Count > 0)
						list.AddRange(res.data.ratings.Where(p => !string.IsNullOrEmpty(p.comment)));
					else
						break;
					searhModel.offset += searhModel.limit;
				}
				
			}
			
			return ShowCrawledData(list);
		}

	}
}
