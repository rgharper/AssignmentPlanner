import { Component } from '@angular/core';
import { Class } from '../_models/classes';

@Component({
  selector: 'app-home',
  standalone: false,
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  classes: Class[] = [];
  // generate random classes
  ngOnInit() {
    for (let i = 0; i < 5; i++) {
      let c = new Class(i.toString(), `Class ${i}`);
      c.generateAssignments();
      this.classes.push(c);
    }
  }
}
