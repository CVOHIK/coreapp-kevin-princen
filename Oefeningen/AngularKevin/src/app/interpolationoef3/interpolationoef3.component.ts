import { Component, OnInit } from '@angular/core';
import * as Lodash from "Lodash"; //import lodash

@Component({
  selector: 'app-interpolationoef3',
  templateUrl: './interpolationoef3.component.html',
  styleUrls: ['./interpolationoef3.component.css']
})
export class Interpolationoef3Component implements OnInit {

  public Random:number;//property aangemaakt om waarde te tonen in html
  constructor() { 
        setInterval(()=>{
      this.Random = Lodash.random(0,100,0); //via lodash een random aanmaken tss 0 en 100
    },2000); //refreshen elke 2sec
  }

  ngOnInit() {
  }

}
