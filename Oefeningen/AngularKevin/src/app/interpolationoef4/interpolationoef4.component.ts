import { Component, OnInit } from '@angular/core';
import * as Moment from 'moment'

@Component({
  selector: 'app-interpolationoef4',
  templateUrl: './interpolationoef4.component.html',
  styleUrls: ['./interpolationoef4.component.css']
})
export class Interpolationoef4Component implements OnInit {

  public TimeOfStarting:Date;
  public TimeAgo:string;
  
  pub
  constructor() { 
    this.TimeOfStarting = new Date();
    this.TimeAgo = Moment(this.TimeOfStarting).fromNow();
    setInterval(()=>{
      this.TimeAgo = Moment(this.TimeOfStarting).fromNow();
      console.log(this.TimeAgo);
    },5000);
  }

  ngOnInit() {
  }

}
