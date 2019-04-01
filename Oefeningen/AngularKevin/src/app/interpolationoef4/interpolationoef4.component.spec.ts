import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { Interpolationoef4Component } from './interpolationoef4.component';

describe('Interpolationoef4Component', () => {
  let component: Interpolationoef4Component;
  let fixture: ComponentFixture<Interpolationoef4Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Interpolationoef4Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Interpolationoef4Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
