import { inject, ChangeDetectionStrategy, Component, OnInit, ViewChild} from '@angular/core';
import { Class } from '../_interfaces/class.interface';
import { Assignment } from '../_interfaces/assignment.interface';
import { ClassService } from '../_services/class';
import { Observable, of, take } from 'rxjs';
import { MatSelectionListChange } from '@angular/material/list';
import {
  MatDialog,
  MatDialogRef,
  MatDialogContent,
} from '@angular/material/dialog';
import { AssignmentDialogComponent } from '../assignment-dialog/assignment-dialog.component';
import { ClassDialogComponent } from '../class-dialog/class-dialog.component';

@Component({
  selector: 'app-class',
  standalone: false,
  templateUrl: './class.component.html',
  styleUrl: './class.component.css'
})
export class ClassComponent implements OnInit {
  classes: Class[] = [];
  selectedAssignment: Assignment | null | any = null;
  @ViewChild('assignmentCard') assignmentCard: any;
  readonly dialog = inject(MatDialog);

  constructor(private classService: ClassService) {
  }

  ngOnInit(): void {
    this.classService.getall().pipe(take(1)).subscribe(classes => this.classes = classes);
  }

  assignmentClicked(assignment: Assignment) {
    this.selectedAssignment = assignment;
    console.log(this.selectedAssignment);
  }
  classPanelClosed() {
    this.selectedAssignment = null;
  }
  addAssignment(selectedClass: Class) {
    this.dialog.open(AssignmentDialogComponent, { data: { class: selectedClass } });
    //selectedClass.assignments.push()
  }
  addClass() {
    this.dialog.open(ClassDialogComponent, { data: { classes: this.classes } });
  }
}
