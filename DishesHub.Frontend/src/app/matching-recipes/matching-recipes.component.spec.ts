import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MatchingRecipesComponent } from './matching-recipes.component';

describe('MatchingRecipesComponent', () => {
  let component: MatchingRecipesComponent;
  let fixture: ComponentFixture<MatchingRecipesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MatchingRecipesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MatchingRecipesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
