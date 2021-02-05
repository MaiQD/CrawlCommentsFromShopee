using App.CommonHelper;
using App.Models;
using App.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Factories
{
	public interface IRatingFactory
	{
		Task<List<Rating>> PrepareRatingsForOneProductAsync(RatingSearchModel searchModel);
	}
	public class RatingFactory : IRatingFactory
	{
		private readonly IApiServices _apiServices;

		public RatingFactory(IApiServices apiServices)
		{
			_apiServices = apiServices;
		}
		public virtual async Task<List<Rating>> PrepareRatingsForOneProductAsync(RatingSearchModel searchModel)
		{
			var list = new List<Rating>();
			while (true)
			{
				var res = await _apiServices.GetObjectApi<GetRatingResponseModel>(Common._urlGetRating, searchModel);
				if (res?.data != null && res?.data?.ratings != null && res.data.ratings.Count > 0)
					list.AddRange(res.data.ratings.Where(p => !string.IsNullOrEmpty(p.comment)));
				else
					break;
				searchModel.offset += searchModel.limit;
			}
			return list;
		}
	}
}
