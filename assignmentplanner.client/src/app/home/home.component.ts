import { Component, OnInit } from '@angular/core';
import { Class } from '../_models/classes';
import { ClassService } from '../_services/class';
import { Observable, of, take } from 'rxjs';

@Component({
  selector: 'app-home',
  standalone: false,
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  classes$: Observable<any> = of(null);

  constructor(private classService: ClassService) {
    console.log('hello world');
    //let classService = new ClassService();
    //this.classes$ = classService.getall();
  }

  ngOnInit(): void {
    this.classes$ = this.classService.getall();
  }
}
