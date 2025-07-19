import { inject } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private http = inject(HttpClient);
  private apiUrl = environment.apiUrl;
  register(formData: any): [boolean, string] {
    let status: [boolean, string] = [false, "Error"];
    const payload = {
      email: formData.email,
      password: formData.password,
    }

    this.http.post(`${this.apiUrl}/register`, payload).subscribe(data => { console.log(data) });

    return status;
  }
}
