import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FotoDoDiaComponent } from './foto-do-dia.component';

describe('FotoDoDiaComponent', () => {
  let component: FotoDoDiaComponent;
  let fixture: ComponentFixture<FotoDoDiaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FotoDoDiaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FotoDoDiaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
