using App.CommonHelper;
using App.Factories;
using App.Models;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace App.Controllers
{
	public class CrawlController : BaseController
	{
		private readonly IRatingFactory _ratingFactory;
		private readonly IProductFactory _productFactory;

		#region constructor

		public CrawlController(IRatingFactory ratingFactory, IProductFactory productFactory)
		{
			_ratingFactory = ratingFactory;
			_productFactory = productFactory;
		}

		#endregion constructor

		#region public methods

		#region Scraping one product

		public IActionResult CrawlOneProduct()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CrawledDataOneProductAsync(string shopeeUrl, int commentStar)
		{
			var list = new List<Rating>();
			if (!string.IsNullOrEmpty(shopeeUrl))
			{
				var searchModel = shopeeUrl.GetItemAndShopIdFromUrl();
				searchModel.type = commentStar;
				list = await _ratingFactory.PrepareRatingsForOneProductAsync(searchModel);
			}

			return ShowCrawledData(list);
		}

		[HttpPost]
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

		#endregion Scraping one product

		#region Scraping list product

		public IActionResult CrawlListProduct()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CrawledDataListProductAsync(string keySearch, int commentStar)
		{
			var list = new List<Rating>();
			if (!string.IsNullOrEmpty(keySearch))
			{
				var searchModel = new ProductSearchModel(keySearch, 0);
				var listProduct = await _productFactory.PrepareListProductAsync(searchModel);
			}
			return ShowCrawledData(list);
		}

		#endregion Scraping list product

		#region Scraping recommend product

		public IActionResult CrawlRecommendProduct()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CrawledDataRecommendProductAsync()
		{
			var list_product = await _productFactory.PrepareListRecommendProductAsync();
			var list_rating = new List<Rating>();
			if (list_product != null && list_product.Count>0)
			{
				foreach (var product in list_product)
				{
					var ratingSearchModel = new RatingSearchModel(product.itemid, product.shopid);
					var get_list_rating = await _ratingFactory.PrepareRatingsForOneProductAsync(ratingSearchModel);
					list_rating.AddRange(get_list_rating);
				}
			}
			return ShowCrawledData(list_rating);
		}

		[HttpPost]
		public async Task<IActionResult> ExportRecommendProduct(string shopeeUrl, int commentStar)
		{
			var list_product = await _productFactory.PrepareListRecommendProductAsync();
			var list_rating = new List<Rating>();
			if (list_product != null && list_product.Count > 0)
			{
				foreach (var product in list_product)
				{
					var ratingSearchModel = new RatingSearchModel(product.itemid, product.shopid);
					var get_list_rating = await _ratingFactory.PrepareRatingsForOneProductAsync(ratingSearchModel);
					list_rating.AddRange(get_list_rating);
				}
			}
			return GetRatingsFile(list_rating);
		}

		#endregion Scraping recommend product

		#endregion public methods

		#region private methods

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

		private void SetUpWorkBook(XLWorkbook workbook, List<Rating> ratings)
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

		#endregion private methods
	}
}