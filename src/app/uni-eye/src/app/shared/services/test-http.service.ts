import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable({providedIn: 'root'})
export class TestHttpService {
  constructor(private httpClient: HttpClient) {
  }

  sendTestRequest() {
    return this.httpClient.get('https://localhost:44384/students/Group');
  }
}
