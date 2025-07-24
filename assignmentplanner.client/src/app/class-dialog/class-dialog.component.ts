import { Component, Inject, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl, FormGroup } from '@angular/forms';
import { environment } from '../environments/environment'
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { take } from 'rxjs';

@Component({
  selector: 'app-class-dialog',
  standalone: false,
  templateUrl: './class-dialog.component.html',
  styleUrl: './class-dialog.component.css'
})
export class ClassDialogComponent {
  http = inject(HttpClient);
  classForm = new FormGroup({
    Year: new FormControl(''),
    Name: new FormControl(''),
    Description: new FormControl(''),
  });

  constructor(@Inject(MAT_DIALOG_DATA) public data: any) {
    console.log(data)
  }

  handleSubmit() {
    let newClass = {
      Name: this.classForm.value.Name,
      Description: this.classForm.value.Description,
      Year: this.classForm.value.Year
    }

    this.http.post(environment.apiUrl + '/class', newClass).pipe(take(1)).subscribe(createdClass => {
      this.data.classes.push(createdClass);
    })
  }

}
