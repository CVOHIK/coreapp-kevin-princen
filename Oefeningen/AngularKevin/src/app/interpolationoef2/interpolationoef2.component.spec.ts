import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { Interpolationoef2Component } from './interpolationoef2.component';

describe('Interpolationoef2Component', () => {
  let component: Interpolationoef2Component;
  let fixture: ComponentFixture<Interpolationoef2Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Interpolationoef2Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Interpolationoef2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
