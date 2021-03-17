import { RatingSearchModel } from './../_models/RatingSearchModel';
import { ProductSearchModel } from './../_models/productSearchModel';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, tap } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class ShopeeService {
  productSearchModel: ProductSearchModel;
  ratingSearchModel: RatingSearchModel;

  constructor(private http: HttpClient) {
    this.productSearchModel = {
      by : "relevancy",
      limit : 100,
      order : "desc",
      page_type : "search",
    }
    this.ratingSearchModel = {
      filter : 1, // có bình luận
      flag:1,
      limit:59, //max limit
      offset:0, //index bắt đầu lấy giá trị
      type:0 //số sao cần lấy
    }
    
  }

  getProducts(keyword: string, newest: number) {
    
    this.productSearchModel.keyword = keyword;
    this.productSearchModel.newest = newest;
    const url = `/api/v2/search_items/?by=${this.productSearchModel.by}&keyword=${this.productSearchModel.keyword}&limit=${this.productSearchModel.limit}&newest=${this.productSearchModel.newest}&order=${this.productSearchModel.order}&page_type=${this.productSearchModel.page_type}`;
    return this.http.get(url).pipe(map((response) => {
      return response['items'];
		}))
  }
  getComment(shopid:number, itemid:number)
  {
    this.ratingSearchModel.shopid = shopid;
    this.ratingSearchModel.itemid = itemid;
    // "https://shopee.vn/api/v2/item/get_ratings?filter=1&flag=1&itemid=3806297321&limit=59&offset=0&shopid=183469849&type=0"
    const url = `/api/v2/item/get_ratings?filter=${this.ratingSearchModel.filter}&flag=${this.ratingSearchModel.flag}&itemid=${this.ratingSearchModel.itemid}&limit=${this.ratingSearchModel.limit}&offset=${this.ratingSearchModel.offset}&shopid=${this.ratingSearchModel.shopid}&type=${this.ratingSearchModel.type}`;
    return this.http.get(url).pipe(
      map((response) => response['data']['ratings'],
      ))
  }
}
