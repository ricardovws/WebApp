import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";

@Injectable()
export class AuthDataService {

  module: string = '/api/auth';

  constructor(private http: HttpClient) { }

  authenticate(data) {
    return this.http.post(this.module, data);
  }

  isAuthenticated() {
    return this.http.get(this.module);
  }

}
