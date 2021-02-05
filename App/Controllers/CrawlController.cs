using App.CommonHelper;
using App.Factories;
using App.Models;
using App.Services;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
	public class CrawlController : BaseController
	{
		private readonly IApiServices _apiServices;
		private readonly IRatingFactory _ratingFactory;

		public CrawlController(IApiServices apiServices,IRatingFactory ratingFactory)
		{
			_apiServices = apiServices;
			_ratingFactory = ratingFactory;
		}
		public IActionResult CrawlOneProduct()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CrawledDataOneProductAsync(string shopeeUrl,int commentStar)
		{
			var list = new List<Rating>() ;
			if (!string.IsNullOrEmpty(shopeeUrl))
			{
				var searchModel = shopeeUrl.GetItemAndShopIdFromUrl();
				searchModel.type = commentStar;
				list = await _ratingFactory.PrepareRatingsForOneProductAsync(searchModel);
			}
			
			return ShowCrawledData(list);
		}
		public async Task<IActionResult> ExportOneProduct(string shopeeUrl, int commentStar)
		{
			var list = new List<Rating>();
			if (!string.IsNullOrEmpty(shopeeUrl))
			{
				var searchModel = shopeeUrl.GetItemAndShopIdFromUrl();
				searchModel.type = commentStar;
				list = await _ratingFactory.PrepareRatingsForOneProductAsync(searchModel);
			}
			return GetRatingsFile(list);
		}
		private IActionResult GetRatingsFile(List<Rating> list)
		{
			string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
			string fileName = DateTime.Now.ToString("yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss.fffffffK") + ".xlsx";
			try
			{
				using (var workbook = new XLWorkbook())
				{
					SetUpWorkBook(workbook, list);
					using (var stream = new MemoryStream())
					{
						workbook.SaveAs(stream);
						var content = stream.ToArray();
						return File(content, contentType, fileName);
					}
				}
			}
			catch (Exception ex)
			{
				return RedirectToAction("Error", "Home");
			}
		}
		private void SetUpWorkBook(XLWorkbook workbook,List<Rating> ratings)
		{
			IXLWorksheet worksheet =
					workbook.Worksheets.Add("Authors");
			worksheet.Cell(1, 1).Value = "Id";
			worksheet.Cell(1, 2).Value = "Rating Star";
			worksheet.Cell(1, 3).Value = "Username";
			worksheet.Cell(1, 4).Value = "Comment";
			int index = 1;
			foreach (var item in ratings)
			{
				worksheet.Cell(index + 1, 1).Value = index;
				worksheet.Cell(index + 1, 2).Value = item.rating_star;
				worksheet.Cell(index + 1, 3).Value = item.author_username;
				worksheet.Cell(index + 1, 4).Value = item.comment;
				index++;
			}
		}
	}
}
