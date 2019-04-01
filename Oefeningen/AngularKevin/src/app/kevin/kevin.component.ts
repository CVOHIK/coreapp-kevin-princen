import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-kevin',
  templateUrl: './kevin.component.html',
  styleUrls: ['./kevin.component.css']
})
export class KevinComponent implements OnInit {

  public isVisible:boolean = true;
  public getallen:number[];
  



  constructor() {
    this.getallen = [];
    this.getallen.push(6);
    this.getallen.push(8);
    this.getallen.push(1990);
    this.getallen.push(28);
    this.getallen.push(49941649);

    
   }

  ngOnInit() {
  }

}
