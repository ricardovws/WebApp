import { HttpClient } from "@angular/common/http";
import { Injectable, NgModule } from "@angular/core";
import { Router, Routes, RouterModule } from "@angular/router";
import { userLoggedData } from "../__models/userLoggedData";


const routes: Routes = [
  { path: '', redirectTo: '/index', pathMatch: 'full' }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

@Injectable()
export class AuthDataService {

  module: string = '/api/auth';

  public model: userLoggedData;

  constructor(private http: HttpClient, private router: Router) {
    this.model = new userLoggedData();
  }

  authenticate(data) {
    return this.http.post(this.module, data);
  }

  isAuthenticated() {

    this.http.get(this.module).subscribe(data => {
    }, error => {
      this.logOut();
    });

  }

  getUserData() {
    this.model.userLogged = JSON.parse(localStorage.getItem('user_logged'));
    this.model.isAuthenticated = this.model.userLogged != null;

    return this.model;
  }

  isLogged() {
    if (JSON.parse(localStorage.getItem('user_logged')) != null) {
      return true;
    } else {
      false;
    }
  }

  logOut() {
    localStorage.removeItem('user_logged');
    this.router.navigate(['/']);
  }

  //That's ok! Come in :)
  thatsOk() {
    if (this.model.userLogged != null)
      this.router.navigate(['/users']);
  }

}
