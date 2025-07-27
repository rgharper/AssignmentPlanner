import { Component, Inject, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl, FormGroup } from '@angular/forms';
import { environment } from '../environments/environment'
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { take } from 'rxjs';

@Component({
  selector: 'app-login-dialog',
  standalone: false,
  templateUrl: './login-dialog.component.html',
  styleUrl: './login-dialog.component.css'
})
export class LoginDialogComponent {
  http = inject(HttpClient);
  loginForm = new FormGroup({
    FirstName: new FormControl(''),
    LastName: new FormControl(''),
    Email: new FormControl(''),
    Password: new FormControl(''),
    Role: new FormControl(''),
  });

  constructor(@Inject(MAT_DIALOG_DATA) public data: any) {
    console.log(data)
  }

  handleSubmit() {
    let newUser = {
      FirstName: this.loginForm.value.FirstName,
      LastName: this.loginForm.value.LastName,
      Email: this.loginForm.value.Email,
      Password: this.loginForm.value.Password,
      Role: this.loginForm.value.Role,
    }

    this.http.post(environment.apiUrl + '/user', newUser).pipe(take(1)).subscribe(createdUser => {
      //upon login
    })
  }

}
