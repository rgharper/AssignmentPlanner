import { Component, OnInit, ViewChild, viewChild } from '@angular/core';
import { Class } from '../_interfaces/class.interface';
import { Assignment } from '../_interfaces/assignment.interface';
import { ClassService } from '../_services/class';
import { Observable, of, take } from 'rxjs';
import { MatSelectionListChange } from '@angular/material/list';

@Component({
  selector: 'app-class',
  standalone: false,
  templateUrl: './class.component.html',
  styleUrl: './class.component.css'
})
export class ClassComponent implements OnInit {
  classes$: Observable<Class[] | null> = of(null);
  selectedAssignment: Assignment | null | any = null;
  @ViewChild('assignmentCard') assignmentCard: any;

  constructor(private classService: ClassService) {
  }

  ngOnInit(): void {
    this.classes$ = this.classService.getall();
  }
  assignmentSelectionChanged($event: MatSelectionListChange) {
    //this.selectedAssignment = $event.source._value![0];
    //console.log(this.selectedAssignment);
  }

  assignmentClicked(assignment: Assignment) {
    this.selectedAssignment = assignment;
    console.log(this.selectedAssignment);
  }
  classPanelClosed() {
    this.selectedAssignment = null;
  }
}
