import { BusyService } from './../../_services/busy.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { Product } from './../../_models/product';
import { ShopeeService } from './../../_services/shopee.service';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Rating } from 'src/app/_models/rating';

@Component({
  selector: 'app-scraping-list-product',
  templateUrl: './scraping-list-product.component.html',
  styleUrls: ['./scraping-list-product.component.css']
})
export class ScrapingListProductComponent implements OnInit {
  model: any = {};
  products: Product[] = [];
  ratings: Rating[] = [];
  constructor(private shopeeService: ShopeeService, private busyService: BusyService) { }

  ngOnInit(): void {
  }
  getProducts() {
    console.log(this.model.keyword)
    this.shopeeService.getProducts(this.model.keyword, 0).subscribe((res) => {
      this.products = res;
      for (let product of this.products) {
        this.shopeeService.getComment(product.shopid, product.itemid).subscribe((res) => {
          this.ratings.push.apply(this.ratings, res);
        })
      }

    });
  }

}
