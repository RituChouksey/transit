import { Injectable } from '@angular/core';
import {
  HttpEvent, HttpInterceptor, HttpHandler, HttpRequest
} from '@angular/common/http';

import { Observable } from 'rxjs';

@Injectable()
export class ApiHttpInterceptor implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // rerdirect the API calls to webApi
    if (req.url.indexOf('api') > -1) {
      const modifiedRequest = req.clone({
        //url: req.url.replace('http:4200//', 'http:62351//')
        url: 'http://localhost:62351/' + req.url
      });
      // send the cloned, request to the next handler.
      return next.handle(modifiedRequest);
    }
    return next.handle(req);
  }
}
