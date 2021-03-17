export interface Product {
    itemid: number;
    welcome_package_info?: any;
    liked?: any;
    recommendation_info?: any;
    bundle_deal_info?: Bundledealinfo;
    price_max_before_discount: number;
    tracking_info?: Trackinginfo;
    image: string;
    recommendation_algorithm?: any;
    is_cc_installment_payment_eligible: boolean;
    shopid: number;
    can_use_wholesale: boolean;
    group_buy_info?: any;
    reference_item_id: string;
    currency: string;
    raw_discount: number;
    show_free_shipping: boolean;
    video_info_list: (Videoinfolist | Videoinfolist2)[];
    ads_keyword?: string;
    collection_id?: any;
    images: string[];
    is_preferred_plus_seller: boolean;
    price_before_discount: number;
    is_category_failed: boolean;
    show_discount: number;
    cmt_count: number;
    view_count: number;
    display_name?: any;
    catid: number;
    voucher_info?: Voucherinfo;
    upcoming_flash_sale?: any;
    is_official_shop: boolean;
    brand?: string;
    price_min: number;
    liked_count: number;
    can_use_bundle_deal: boolean;
    show_official_shop_label: boolean;
    coin_earn_label?: any;
    price_min_before_discount: number;
    cb_option: number;
    sold: number;
    deduction_info?: string;
    stock: number;
    status: number;
    price_max: number;
    add_on_deal_info?: Addondealinfo;
    is_group_buy_item?: any;
    flash_sale?: any;
    algo_image?: any;
    price: number;
    shop_location: string;
    item_rating: Itemrating;
    show_official_shop_label_in_title: boolean;
    tier_variations: Tiervariation[];
    is_adult: boolean;
    discount?: string;
    flag: number;
    is_non_cc_installment_payment_eligible: boolean;
    has_lowest_price_guarantee: boolean;
    json_data: string;
    has_group_buy_stock?: any;
    match_type?: number;
    preview_info?: any;
    welcome_package_type: number;
    exclusive_price_info?: any;
    name: string;
    distance?: any;
    adsid?: number;
    ctime: number;
    wholesale_tier_list: (Wholesaletierlist | Wholesaletierlist2)[];
    show_shopee_verified_label: boolean;
    campaignid?: number;
    show_official_shop_label_in_normal_position?: any;
    item_status: string;
    shopee_verified: boolean;
    hidden_price_display?: any;
    size_chart?: any;
    item_type: number;
    shipping_icon_type?: any;
    campaign_stock?: any;
    label_ids: number[];
    service_by_shopee_flag?: any;
    badge_icon_type: number;
    historical_sold: number;
    transparent_background_image: string;
  }
  
  export interface Wholesaletierlist2 {
    min_count: number;
    price: number;
    max_count?: any;
  }
  
  export interface Wholesaletierlist {
    min_count: number;
    price: number;
    max_count?: number;
  }
  
  export interface Tiervariation {
    images: (string | string)[];
    properties: any[];
    type: number;
    name: string;
    options: string[];
  }
  
  export interface Itemrating {
    rating_star: number;
    rating_count: number[];
    rcount_with_image: number;
    rcount_with_context: number;
  }
  
  export interface Addondealinfo {
    add_on_deal_id: number;
    add_on_deal_label: string;
    sub_type: number;
  }
  
  export interface Voucherinfo {
    promotion_id: number;
    voucher_code: string;
    label: string;
  }
  
  export interface Videoinfolist2 {
    duration: number;
    video_id: string;
    version?: any;
    thumb_url: string;
  }
  
  export interface Videoinfolist {
    duration: number;
    video_id: string;
    version: number;
    thumb_url: string;
  }
  
  export interface Trackinginfo {
    multi_search_tracking: number[];
    viral_spu_tracking?: any;
    business_tracking?: any;
  }
  
  export interface Bundledealinfo {
    bundle_deal_id: number;
    bundle_deal_label: string;
  }