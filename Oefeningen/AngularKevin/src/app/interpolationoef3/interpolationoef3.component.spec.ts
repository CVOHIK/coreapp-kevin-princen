import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { Interpolationoef3Component } from './interpolationoef3.component';

describe('Interpolationoef3Component', () => {
  let component: Interpolationoef3Component;
  let fixture: ComponentFixture<Interpolationoef3Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Interpolationoef3Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Interpolationoef3Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
