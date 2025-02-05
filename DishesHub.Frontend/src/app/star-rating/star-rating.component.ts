import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-star-rating',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './star-rating.component.html',
  styleUrl: './star-rating.component.css'
})
export class StarRatingComponent {
  @Input() rating: number = 0;
  @Input() editable: boolean = false;
  @Output() ratingChange = new EventEmitter<number>();

  setRating(star: number) {
    if (this.editable) {
      this.rating = star;
      this.ratingChange.emit(this.rating);
    }
  }
}
