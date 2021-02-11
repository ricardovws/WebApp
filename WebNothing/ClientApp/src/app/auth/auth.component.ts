import { Component, OnInit } from '@angular/core';
import { AuthDataService } from '../_data-services/auth.data-service';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css']
})
export class AuthComponent implements OnInit {

  constructor(private authDataService: AuthDataService) { }

  userLogin: any = {};
  isAuthenticated: boolean = false;
  userLogged: any = {};

  authenticate() {
    this.authDataService.authenticate(this.userLogin).subscribe((data: any) => {
      if (data.user) {
        localStorage.setItem('user_logged', JSON.stringify(data));
        this.getUserData();
      } else {
        alert('Error! This user cannot be logged!');
      }
    }, error => {
      console.log(error);
      alert('User invalid!');
    })
  }

  getUserData() {
    this.userLogged = JSON.parse(localStorage.getItem('user_logged'));
    this.isAuthenticated = this.userLogged != null;
  }

  clickMe() {
    alert('fui clicado!')
  }

  ngOnInit() {
  }

}
