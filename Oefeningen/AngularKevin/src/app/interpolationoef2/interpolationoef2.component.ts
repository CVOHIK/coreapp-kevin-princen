import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-interpolationoef2',
  templateUrl: './interpolationoef2.component.html',
  styleUrls: ['./interpolationoef2.component.css']
})
export class Interpolationoef2Component implements OnInit {

  public Teller:number = 0;
  constructor() { }

  ngOnInit() {
    this.RaiseTeller();
  }
  RaiseTeller(): void{
      setInterval(() => {
        this.Teller= this.Teller + 1;
      }, 200); //waarde in ms
  }

}
