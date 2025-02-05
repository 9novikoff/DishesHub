import { Component, Input } from '@angular/core';
import { RateComponent } from "../rate/rate.component";
import { RateAddComponent } from "../rate-add/rate-add.component";
import { RateGetDto } from '../../models/rate-get-dto';

@Component({
  selector: 'app-rate-section',
  standalone: true,
  imports: [RateComponent, RateAddComponent],
  templateUrl: './rate-section.component.html',
  styleUrl: './rate-section.component.css'
})
export class RateSectionComponent {
  @Input() rates: RateGetDto[] = [];
  @Input() recipeId: number | undefined;
}
