import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpHandlerFn,
} from '@angular/common/http';
import { Observable } from 'rxjs';
export function JwtInterceptor(req: HttpRequest<unknown>, next: HttpHandlerFn): Observable<HttpEvent<unknown>> {
  const reqWithHeader = req.clone({ headers: req.headers.set('Authorization', `Bearer ${localStorage.getItem('token')}`), });
  return next(reqWithHeader);
}
