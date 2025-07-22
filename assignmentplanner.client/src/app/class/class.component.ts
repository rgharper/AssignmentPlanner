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
  readonly dialog = inject(MatDialog);

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
  addAssignment(selectedClass: Class) {
    this.dialog.open(AssignmentDialog, {
      width: '250px',
      enterAnimationDuration: 600,
      exitAnimationDuration: 600,
    });
    //selectedClass.assignments.push()
  }
}

// the new assignment dialog
@Component({
  selector: 'assignment-dialog',
  templateUrl: 'dialog-assignment-dialog.html',
})
export class AssignmentDialog {
  readonly dialogRef = inject(MatDialogRef<AssignmentDialog>);
}
