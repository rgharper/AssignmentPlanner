import { HttpClient } from '@angular/common/http';
import { Component, Inject, inject } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { provideNativeDateAdapter } from '@angular/material/core';
import { environment } from '../environments/environment'
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { take } from 'rxjs';

@Component({
  selector: 'app-assignment-dialog',
  standalone: false,
  templateUrl: './assignment-dialog.component.html',
  styleUrl: './assignment-dialog.component.css',
  providers: [provideNativeDateAdapter()],
})
export class AssignmentDialogComponent {
  http = inject(HttpClient);
  assignmentForm = new FormGroup({
    Title: new FormControl(''),
    Description: new FormControl(''),
    Date: new FormControl(''),
  });

  constructor(@Inject(MAT_DIALOG_DATA) public data: any) {
    console.log(data)
  }

  handleSubmit() {
    let newAssignment = {
      Title: this.assignmentForm.value.Title,
      Description: this.assignmentForm.value.Description,
      Date: this.assignmentForm.value.Date,
      ClassId: this.data.class.id
    }

    this.http.post(environment.apiUrl + '/assignment', newAssignment).pipe(take(1)).subscribe(assignment => {
      this.data.class.assignments.push(assignment);
    })
  }
}
