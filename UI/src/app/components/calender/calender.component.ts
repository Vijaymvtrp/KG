import { ChangeDetectionStrategy, Component } from '@angular/core';
import {provideNativeDateAdapter} from '@angular/material/core';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatIconModule} from '@angular/material/icon';
import {MatInputModule} from '@angular/material/input'

@Component({
  selector: 'app-calender',
  standalone: true,
  imports: [MatFormFieldModule, MatInputModule, MatDatepickerModule, MatIconModule],
  providers: [provideNativeDateAdapter()],
  changeDetection: ChangeDetectionStrategy.OnPush,

  templateUrl: './calender.component.html',
  styleUrl: './calender.component.scss'
})
export class CalenderComponent {

}
