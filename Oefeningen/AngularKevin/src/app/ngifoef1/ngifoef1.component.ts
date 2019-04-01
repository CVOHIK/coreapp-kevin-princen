import { Component, OnInit } from '@angular/core';
import * as Lodash from 'lodash';

@Component({
  selector: 'app-ngifoef1',
  templateUrl: './ngifoef1.component.html',
  styleUrls: ['./ngifoef1.component.css']
})
export class Ngifoef1Component implements OnInit {

  public RandomGetal:number;
  public LageScore:string;
  public HogeScore:string;
  

  constructor() {
    this.LageScore = "Dit resultaat is ondermaats!";
    this.HogeScore = "Mooie score!";
    setInterval(()=>{
      this.RandomGetal = Lodash.random(0,10,0);
    },2000);
   }

  ngOnInit() {
  }

}
