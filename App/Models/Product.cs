using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
	public partial class Product
	{
		public long itemid { get; set; }
		public string name { get; set; }
	}
	public partial class ProductSearchModel
	{
		public ProductSearchModel(string keyword,long newest)
		{
			by = "relevancy";
			this.keyword = keyword;
			limit = 100;
			this.newest = newest;
			order = "desc";
			page_type = "search";
			version = 2;
		}
		public string by { get; set; }
		public string keyword { get; set; }
		public int limit { get; set; }
		public long newest { get; set; }
		public string order { get; set; }
		public string page_type { get; set; }
		public int version { get; set; }
	}
}
