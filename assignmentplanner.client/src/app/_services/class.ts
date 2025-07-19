import { inject } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ClassService {
  private http = inject(HttpClient);
  private apiUrl = environment.apiUrl;

  getall(): Observable<any> {
    //let response: any;

    //this.http.get(`${this.apiUrl}/class/getall`).subscribe(data => { response = data });
    //console.log(response);
    //return response;
    return this.http.get(`${this.apiUrl}/class/getall`);
  }
}
