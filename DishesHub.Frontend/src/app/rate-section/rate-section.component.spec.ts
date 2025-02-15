import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RateSectionComponent } from './rate-section.component';

describe('RateSectionComponent', () => {
  let component: RateSectionComponent;
  let fixture: ComponentFixture<RateSectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RateSectionComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(RateSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
