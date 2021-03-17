export interface Rating {
  itemid: number;
  rating: number;
  liked?: any;
  videos: Video[];
  has_template_tag: boolean;
  shopid: number;
  show_reply?: any;
  rating_star: number;
  like_count?: number;
  mtime: number;
  mentioned: any[];
  ItemRatingReply: ItemRatingReply;
  is_hidden: boolean;
  template_tags: any[];
  author_portrait: string;
  detailed_rating?: Detailedrating;
  orderid: number;
  cmtid: number;
  exclude_scoring_due_low_logistic: boolean;
  editable_date?: number;
  sync_to_social_toggle?: any;
  opt: number;
  status: number;
  author_username: string;
  tags?: Tag[];
  images?: string[];
  delete_operator?: any;
  editable: number;
  anonymous: boolean;
  loyalty_info?: any;
  ctime: number;
  product_items: Productitem[];
  author_shopid: number;
  userid: number;
  comment: string;
  filter: number;
  sync_to_social: boolean;
  delete_reason?: any;
}

export interface Productitem {
  itemid: number;
  welcome_package_info?: any;
  liked?: any;
  recommendation_info?: any;
  bundle_deal_info?: any;
  price_max_before_discount: number;
  image: string;
  recommendation_algorithm?: any;
  is_cc_installment_payment_eligible: boolean;
  shopid: number;
  can_use_wholesale: boolean;
  group_buy_info?: any;
  reference_item_id: string;
  currency: string;
  raw_discount: number;
  show_free_shipping?: any;
  video_info_list?: any;
  images: string[];
  is_preferred_plus_seller?: any;
  price_before_discount: number;
  is_category_failed: boolean;
  show_discount: number;
  cmt_count: number;
  view_count?: any;
  catid: number;
  voucher_info?: any;
  upcoming_flash_sale?: any;
  is_official_shop: boolean;
  brand: string;
  price_min: number;
  liked_count: number;
  can_use_bundle_deal: boolean;
  show_official_shop_label: boolean;
  coin_earn_label?: any;
  is_snapshot: number;
  price_min_before_discount: number;
  cb_option: number;
  sold?: any;
  stock: number;
  status: number;
  price_max: number;
  add_on_deal_info?: any;
  is_group_buy_item?: any;
  flash_sale?: any;
  modelid: number;
  price: number;
  shop_location?: any;
  item_rating?: any;
  show_official_shop_label_in_title: boolean;
  tier_variations: Tiervariation[];
  is_adult?: any;
  discount: string;
  flag: number;
  is_non_cc_installment_payment_eligible: boolean;
  has_lowest_price_guarantee: boolean;
  snapshotid: number;
  has_group_buy_stock?: any;
  preview_info?: any;
  welcome_package_type: number;
  exclusive_price_info?: any;
  name: string;
  ctime: number;
  wholesale_tier_list: any[];
  show_shopee_verified_label: boolean;
  show_official_shop_label_in_normal_position?: any;
  item_status: string;
  shopee_verified?: any;
  hidden_price_display?: any;
  size_chart?: string;
  item_type: number;
  shipping_icon_type?: any;
  label_ids: number[];
  service_by_shopee_flag?: any;
  model_name: string;
  badge_icon_type?: any;
  historical_sold?: any;
  transparent_background_image: string;
}

export interface Tiervariation {
  images?: any;
  properties?: any;
  type: number;
  name: string;
  options: string[];
}

export interface Tag {
  tag_description: string;
  tag_id: number;
}

export interface Detailedrating {
  delivery_service: number;
  seller_service: number;
  product_quality: number;
}

export interface ItemRatingReply {
  orderid?: number;
  itemid?: any;
  cmtid?: number;
  ctime?: number;
  mentioned?: any;
  rating?: any;
  editable?: any;
  userid?: number;
  shopid?: any;
  comment?: string;
  filter?: any;
  rating_star?: any;
  status?: any;
  mtime?: number;
  opt?: any;
  is_hidden?: boolean;
}

export interface Video {
  url: string;
  duration: number;
  upload_time?: any;
  cover: string;
  id: string;
}