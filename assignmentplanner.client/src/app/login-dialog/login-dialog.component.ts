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
    Email: new FormControl(''),
    Password: new FormControl(''),
  });

  constructor(@Inject(MAT_DIALOG_DATA) public data: any) {
    console.log(data)
  }

  handleSubmit() {
    let user = {
      Email: this.loginForm.value.Email,
      Password: this.loginForm.value.Password,
    }

    this.http.post<{token: any, firstName: any}>(environment.apiUrl + '/user/login', user).pipe(take(1)).subscribe(loggedInUser => {
      localStorage.setItem('token', loggedInUser.token);
      localStorage.setItem('name', loggedInUser.firstName);
    })
  }

}
