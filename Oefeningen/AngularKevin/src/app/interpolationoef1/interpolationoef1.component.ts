import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-interpolationoef1',
  templateUrl: './interpolationoef1.component.html',
  styleUrls: ['./interpolationoef1.component.css']
})
export class Interpolationoef1Component implements OnInit {

  public TimeNow:Date;
  constructor() {
   }

  ngOnInit() {
      this.utcTime();
  }
  utcTime(): void {
    setInterval(() => {
      this.TimeNow = new Date();
    }, 1000);
}

}
