import { Component, Input } from '@angular/core';
import { RateGetDto } from '../../models/rate-get-dto';
import { StarRatingComponent } from "../star-rating/star-rating.component";

@Component({
  selector: 'app-rate',
  standalone: true,
  imports: [StarRatingComponent],
  templateUrl: './rate.component.html',
  styleUrl: './rate.component.css'
})
export class RateComponent {
  @Input() rate!: RateGetDto;
}
