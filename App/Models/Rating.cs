using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
	public class Rating
	{
		public long itemid { get; set; }
		public decimal rating { get; set; }
		public decimal rating_star { get; set; }
		public long cmtid  { get; set; }
		public string comment { get; set; }
		public string author_username { get; set; }

	}
	public class RatingSearchModel
	{
		public RatingSearchModel(int filter, int flag, long itemid, long shopid, int limit, long offset, int type)
		{
			this.filter = filter;
			this.flag = flag;
			this.itemid = itemid;
			this.shopid = shopid;
			this.limit = limit;
			this.offset = offset;
			this.type = type;
		}
		public RatingSearchModel(long itemid, long shopid)
		{
			this.filter = 0;
			this.flag = 1;
			this.itemid = itemid;
			this.shopid = shopid;
			this.limit = 59;
			this.offset = 0;
			this.type = 0;
		}
		public int filter { get; set; }
		public int flag { get; set; }
		public long itemid { get; set; }
		public int limit { get; set; }
		public long offset { get; set; }
		public long shopid { get; set; }
		public int type { get; set; }
	}
}
