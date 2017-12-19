import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ServidorFichaComponent } from './servidor-ficha.component';

describe('ServidorFichaComponent', () => {
  let component: ServidorFichaComponent;
  let fixture: ComponentFixture<ServidorFichaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ServidorFichaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ServidorFichaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
