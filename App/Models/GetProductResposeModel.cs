using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
	public class GetProductResposeModel
	{
		public GetProductResposeModel()
		{
			items = new List<Product>();
		}
		public string version { get; set; }
		public string json_data { get; set; }
		public long total_count { get; set; }
		public List<Product> items { get; set; }
		public string name { get; set; }
	}
}
