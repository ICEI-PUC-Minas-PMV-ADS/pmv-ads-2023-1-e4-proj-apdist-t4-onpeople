/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { MetaListComponent } from './metaList.component';

describe('MetaListComponent', () => {
  let component: MetaListComponent;
  let fixture: ComponentFixture<MetaListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MetaListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MetaListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
