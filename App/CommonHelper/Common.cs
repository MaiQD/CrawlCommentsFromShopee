using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.CommonHelper
{
	public static class Common
	{
		public static string _baseUrl = @"https://shopee.vn";
		public static string _urlGetRating = @"/api/v2/item/get_ratings";
		public static RatingSearchModel GetItemAndShopIdFromUrl(this string _url)
		{
			var itemAndShopId = _url.Split("-i.")[1].Split(".");
			var itemId = long.Parse(itemAndShopId[1]);
			var shopId = long.Parse(itemAndShopId[0]);
			return new RatingSearchModel(itemId, shopId);

		}
        #region  Object to json
        public static string toStringJson(this Object obj, bool isLowerCase = false)
        {
            if (obj == null)
                return "";
            try
            {
                if (!isLowerCase)
                    return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                else
                {
                    var serializerSettings = new Newtonsoft.Json.JsonSerializerSettings();
                    serializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
                    serializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
                    serializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(obj, serializerSettings);
                }
            }
            catch (Exception e)
            { }
            return "";
        }
        /// <summary>
        /// Chuyen doi chuoi json thanh dang entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strjson"></param>
        /// <returns></returns>
        public static T toEntity<T>(this string strjson)
        {
            if (string.IsNullOrEmpty(strjson))
                return default(T);
            try
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(strjson);
            }
            catch (Exception ex)
            {
                var err = ex;
            }
            return default(T);


        }
        
        /// <summary>
        /// Chuyen doi chuoi json thanh dang list(entity)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strjson"></param>
        /// <returns></returns>
        public static List<T> toEntities<T>(this string strjson)
        {
            if (string.IsNullOrEmpty(strjson))
                return default(List<T>);
            try
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(strjson);
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
            return default(List<T>);


        }
        
        #endregion
    }
}
