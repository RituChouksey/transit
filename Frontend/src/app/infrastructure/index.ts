
import { HTTP_INTERCEPTORS } from '@angular/common/http';

import { ApiHttpInterceptor } from './api-http-interceptor';

export const HttpInterceptorProviders = [
  { provide: HTTP_INTERCEPTORS, useClass: ApiHttpInterceptor, multi: true },
];
