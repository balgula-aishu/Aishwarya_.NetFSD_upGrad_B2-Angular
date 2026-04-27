import { FormsModule } from '@angular/forms';
import { Component } from '@angular/core';
import { ContactComponent } from './contact/contact';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [ContactComponent,FormsModule,ReactiveFormsModule],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class AppComponent {}