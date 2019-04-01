import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { Ngifoef1Component } from './ngifoef1.component';

describe('Ngifoef1Component', () => {
  let component: Ngifoef1Component;
  let fixture: ComponentFixture<Ngifoef1Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Ngifoef1Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Ngifoef1Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
