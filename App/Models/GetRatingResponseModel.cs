using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
	public class GetRatingResponseModel
	{
		public Guid version { get; set; }
		public GetRatingResponseData data { get; set; }
		public string error_msg { get; set; }
		public int error { get; set; }
	}
	public class GetRatingResponseData
	{
		public GetRatingResponseData()
		{
			List<Rating> ratings = new List<Rating>();
		}
		public List<Rating> ratings { get; set; }
		public GetRatingResponseSumary item_rating_summary { get; set; }
	}
	public class GetRatingResponseSumary
	{
		public long rcount_with_context { get; set; }
		public long rcount_with_media { get; set; }
		public long rating_total { get; set; }
		public long rcount_with_image { get; set; }
	}
}
