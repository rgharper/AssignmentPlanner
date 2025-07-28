import { Component, Inject, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl, FormGroup } from '@angular/forms';
import { environment } from '../environments/environment'
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { take } from 'rxjs';

@Component({
  selector: 'app-register-dialog',
  standalone: false,
  templateUrl: './register-dialog.component.html',
  styleUrl: './register-dialog.component.css'
})
export class RegisterDialogComponent {
  http = inject(HttpClient);
  registerForm = new FormGroup({
    FirstName: new FormControl(''),
    LastName: new FormControl(''),
    Email: new FormControl(''),
    Password: new FormControl(''),
  });

  constructor(@Inject(MAT_DIALOG_DATA) public data: any) {
    console.log(data)
  }

  handleSubmit() {
    let newUser = {
      FirstName: this.registerForm.value.FirstName,
      LastName: this.registerForm.value.LastName,
      Email: this.registerForm.value.Email,
      Password: this.registerForm.value.Password,
    }

    this.http.post(environment.apiUrl + '/user', newUser).pipe(take(1)).subscribe(createdUser => {
      //upon login
    })
  }

}
