import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { KevinComponent } from './kevin/kevin.component';
import { Interpolationoef1Component } from './interpolationoef1/interpolationoef1.component';
import { Interpolationoef2Component } from './interpolationoef2/interpolationoef2.component';
import { Interpolationoef3Component } from './interpolationoef3/interpolationoef3.component';
import { Interpolationoef4Component } from './interpolationoef4/interpolationoef4.component';
import { Ngifoef1Component } from './ngifoef1/ngifoef1.component';

@NgModule({
  declarations: [
    AppComponent,
    KevinComponent,
    Interpolationoef1Component,
    Interpolationoef2Component,
    Interpolationoef3Component,
    Interpolationoef4Component,
    Ngifoef1Component
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
