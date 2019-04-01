import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { Interpolationoef1Component } from './interpolationoef1.component';

describe('Interpolationoef1Component', () => {
  let component: Interpolationoef1Component;
  let fixture: ComponentFixture<Interpolationoef1Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Interpolationoef1Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Interpolationoef1Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
