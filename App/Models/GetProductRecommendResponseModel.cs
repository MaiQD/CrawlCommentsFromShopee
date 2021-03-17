using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Index
    {
        public string data_type { get; set; }
        public string key { get; set; }
    }

    public class VideoInfoList
    {
        public string video_id { get; set; }
        public string thumb_url { get; set; }
        public int duration { get; set; }
        public int version { get; set; }
    }

    public class TierVariation
    {
        public string name { get; set; }
        public List<string> options { get; set; }
        public List<string> images { get; set; }
        public List<object> properties { get; set; }
        public int type { get; set; }
    }

    public class ItemRating
    {
        public double rating_star { get; set; }
        public List<int> rating_count { get; set; }
        public int rcount_with_image { get; set; }
        public int rcount_with_context { get; set; }
    }

    public class BundleDealInfo
    {
        public int bundle_deal_id { get; set; }
        public string bundle_deal_label { get; set; }
    }

    public class AddOnDealInfo
    {
        public int add_on_deal_id { get; set; }
        public string add_on_deal_label { get; set; }
        public int sub_type { get; set; }
        public int status { get; set; }
    }

    public class VoucherInfo
    {
        public int promotion_id { get; set; }
        public string voucher_code { get; set; }
        public string label { get; set; }
    }

    public class Item
    {
        public object itemid { get; set; }
        public int shopid { get; set; }
        public string name { get; set; }
        public List<int> label_ids { get; set; }
        public string image { get; set; }
        public List<string> images { get; set; }
        public string currency { get; set; }
        public int stock { get; set; }
        public int status { get; set; }
        public int ctime { get; set; }
        public int sold { get; set; }
        public int historical_sold { get; set; }
        public bool liked { get; set; }
        public int liked_count { get; set; }
        public int view_count { get; set; }
        public int catid { get; set; }
        public string brand { get; set; }
        public int cmt_count { get; set; }
        public int flag { get; set; }
        public int cb_option { get; set; }
        public string item_status { get; set; }
        public object price { get; set; }
        public object price_min { get; set; }
        public object price_max { get; set; }
        public object price_min_before_discount { get; set; }
        public object price_max_before_discount { get; set; }
        public object hidden_price_display { get; set; }
        public object price_before_discount { get; set; }
        public bool has_lowest_price_guarantee { get; set; }
        public int show_discount { get; set; }
        public int raw_discount { get; set; }
        public string discount { get; set; }
        public bool is_category_failed { get; set; }
        public string size_chart { get; set; }
        public List<VideoInfoList> video_info_list { get; set; }
        public List<TierVariation> tier_variations { get; set; }
        public ItemRating item_rating { get; set; }
        public int item_type { get; set; }
        public string reference_item_id { get; set; }
        public string transparent_background_image { get; set; }
        public bool is_adult { get; set; }
        public int badge_icon_type { get; set; }
        public bool shopee_verified { get; set; }
        public bool is_official_shop { get; set; }
        public bool show_official_shop_label { get; set; }
        public bool show_shopee_verified_label { get; set; }
        public bool show_official_shop_label_in_title { get; set; }
        public bool is_cc_installment_payment_eligible { get; set; }
        public bool is_non_cc_installment_payment_eligible { get; set; }
        public object coin_earn_label { get; set; }
        public bool show_free_shipping { get; set; }
        public object preview_info { get; set; }
        public object coin_info { get; set; }
        public object exclusive_price_info { get; set; }
        public int bundle_deal_id { get; set; }
        public bool can_use_bundle_deal { get; set; }
        public BundleDealInfo bundle_deal_info { get; set; }
        public object is_group_buy_item { get; set; }
        public object has_group_buy_stock { get; set; }
        public object group_buy_info { get; set; }
        public int welcome_package_type { get; set; }
        public object welcome_package_info { get; set; }
        public AddOnDealInfo add_on_deal_info { get; set; }
        public bool can_use_wholesale { get; set; }
        public bool is_preferred_plus_seller { get; set; }
        public string shop_location { get; set; }
        public bool has_model_with_available_shopee_stock { get; set; }
        public VoucherInfo voucher_info { get; set; }
        public string info { get; set; }
        public string data_type { get; set; }
        public string key { get; set; }
        public int count { get; set; }
        public int adsid { get; set; }
        public int campaignid { get; set; }
        public string deduction_info { get; set; }
        public int video_display_control { get; set; }
    }

    public class Ad
    {
        public object itemid { get; set; }
        public int shopid { get; set; }
        public string name { get; set; }
        public List<int> label_ids { get; set; }
        public string image { get; set; }
        public List<string> images { get; set; }
        public string currency { get; set; }
        public int stock { get; set; }
        public int status { get; set; }
        public int ctime { get; set; }
        public int sold { get; set; }
        public int historical_sold { get; set; }
        public bool liked { get; set; }
        public int liked_count { get; set; }
        public int view_count { get; set; }
        public int catid { get; set; }
        public string brand { get; set; }
        public int cmt_count { get; set; }
        public int flag { get; set; }
        public int cb_option { get; set; }
        public string item_status { get; set; }
        public object price { get; set; }
        public object price_min { get; set; }
        public object price_max { get; set; }
        public object price_min_before_discount { get; set; }
        public object price_max_before_discount { get; set; }
        public object hidden_price_display { get; set; }
        public object price_before_discount { get; set; }
        public bool has_lowest_price_guarantee { get; set; }
        public int show_discount { get; set; }
        public int raw_discount { get; set; }
        public string discount { get; set; }
        public bool is_category_failed { get; set; }
        public string size_chart { get; set; }
        public List<VideoInfoList> video_info_list { get; set; }
        public List<TierVariation> tier_variations { get; set; }
        public ItemRating item_rating { get; set; }
        public int item_type { get; set; }
        public string reference_item_id { get; set; }
        public string transparent_background_image { get; set; }
        public bool is_adult { get; set; }
        public int badge_icon_type { get; set; }
        public bool shopee_verified { get; set; }
        public bool is_official_shop { get; set; }
        public bool show_official_shop_label { get; set; }
        public bool show_shopee_verified_label { get; set; }
        public bool show_official_shop_label_in_title { get; set; }
        public bool is_cc_installment_payment_eligible { get; set; }
        public bool is_non_cc_installment_payment_eligible { get; set; }
        public object coin_earn_label { get; set; }
        public bool show_free_shipping { get; set; }
        public object preview_info { get; set; }
        public object coin_info { get; set; }
        public object exclusive_price_info { get; set; }
        public int bundle_deal_id { get; set; }
        public bool can_use_bundle_deal { get; set; }
        public BundleDealInfo bundle_deal_info { get; set; }
        public object is_group_buy_item { get; set; }
        public object has_group_buy_stock { get; set; }
        public object group_buy_info { get; set; }
        public int welcome_package_type { get; set; }
        public object welcome_package_info { get; set; }
        public AddOnDealInfo add_on_deal_info { get; set; }
        public bool can_use_wholesale { get; set; }
        public bool is_preferred_plus_seller { get; set; }
        public string shop_location { get; set; }
        public bool has_model_with_available_shopee_stock { get; set; }
        public VoucherInfo voucher_info { get; set; }
        public string info { get; set; }
        public string data_type { get; set; }
        public string key { get; set; }
        public int count { get; set; }
        public int adsid { get; set; }
        public int campaignid { get; set; }
        public string deduction_info { get; set; }
        public int video_display_control { get; set; }
    }

    public class ItemLite
    {
        public object itemid { get; set; }
        public int shopid { get; set; }
        public string data_type { get; set; }
        public string key { get; set; }
        public string info { get; set; }
        public int count { get; set; }
        public int feedid { get; set; }
        public int feed_author { get; set; }
        public int video_display_control { get; set; }
        public object list { get; set; }
    }

    public class Data
    {
        public List<Product> item { get; set; }
        public object keyword { get; set; }
        public object ads { get; set; }
        public object top_product { get; set; }
        public object collection { get; set; }
        public List<ItemLite> item_lite { get; set; }
        public object video { get; set; }
        public object voucher { get; set; }
        public object voucher_detail { get; set; }
        public object l1cat { get; set; }
        public object collection_lite { get; set; }
        public object l2cat { get; set; }
        public object shop { get; set; }
        public object shop_lite { get; set; }
        public object shopcat { get; set; }
        public object feed { get; set; }
        public object feed_tab { get; set; }
        public object stream { get; set; }
        public object promotion { get; set; }
        public object knode { get; set; }
        public int update_time { get; set; }
        public string version { get; set; }
        public List<Section> sections { get; set; }
        public int expire { get; set; }
    }

    public class List
    {
        public int total { get; set; }
        public string key { get; set; }
        public List<Index> index { get; set; }
        public Data data { get; set; }
    }

    public class TopProduct
    {
        public string info { get; set; }
        public int count { get; set; }
        public string data_type { get; set; }
        public string name { get; set; }
        public string label { get; set; }
        public string key { get; set; }
        public List<string> images { get; set; }
        public List list { get; set; }
    }

    public class Collection
    {
        public string info { get; set; }
        public string name { get; set; }
        public string data_type { get; set; }
        public int sold { get; set; }
        public object images { get; set; }
        public string key { get; set; }
        public string desc { get; set; }
        public string page_template_image { get; set; }
        public int collectionid { get; set; }
    }

    public class Section
    {
        public int total { get; set; }
        public string key { get; set; }
        public List<Index> index { get; set; }
        public Data data { get; set; }
    }

    public class GetProductRecommendResponseModel
    {
        public object bff_meta { get; set; }
        public object error { get; set; }
        public object error_msg { get; set; }
        public Data data { get; set; }
    }


}
