using App.CommonHelper;
using App.Models;
using App.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Factories
{
	public interface IProductFactory
	{
		Task<List<Product>> PrepareListProductAsync(ProductSearchModel searchModel);
	}
	public class ProductFactory: IProductFactory
	{
		private readonly IApiServices _apiServices;

		public ProductFactory(IApiServices apiServices)
		{
			_apiServices = apiServices;
		}
		public virtual async Task<List<Product>> PrepareListProductAsync(ProductSearchModel searchModel)
		{
			var list = new List<Product>();
			//while (true)
			//{
			var res = await _apiServices.GetObjectApi<GetProductResposeModel>(Common._urlSearch, searchModel);

			//if (res?.data?.ratings == null || searchModel.offset > res.data.item_rating_summary.rcount_with_context)
			//	break;
			//	list.AddRange(res.data.ratings.Where(p => !string.IsNullOrEmpty(p.comment)));
			//	searchModel.offset += searchModel.limit;
			//}
			return list;
		}
	}
}
