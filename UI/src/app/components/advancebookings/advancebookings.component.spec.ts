import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdvancebookingsComponent } from './advancebookings.component';

describe('AdvancebookingsComponent', () => {
  let component: AdvancebookingsComponent;
  let fixture: ComponentFixture<AdvancebookingsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AdvancebookingsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AdvancebookingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
