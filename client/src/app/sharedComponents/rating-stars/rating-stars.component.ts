import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-rating-stars',
  templateUrl: './rating-stars.component.html',
  styleUrls: ['./rating-stars.component.css']
})
export class RatingStarsComponent implements OnInit {
  @Input() numberStars :number;
  numbers=[];
  constructor() { }

  ngOnInit(): void {
    this.numbers = Array(5).fill(0).map((x,i)=>i); // [0,1,2,3,4]
  }

}
