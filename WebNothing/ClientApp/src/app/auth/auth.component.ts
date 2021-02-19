import { Component, OnInit } from '@angular/core';
import { AuthDataService } from '../_data-services/auth.data-service';
import { userLoggedData } from '../__models/userLoggedData';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css'],
  providers: [userLoggedData]
})
export class AuthComponent implements OnInit {

  public model: userLoggedData;

  constructor(private authDataService: AuthDataService) {

    this.model = new userLoggedData();

  }
  authenticate() {
    if (this.justCheckLogin()) {
      this.authDataService.authenticate(this.model.userLogin).subscribe((data: any) => {
        if (data.user) {
          localStorage.setItem('user_logged', JSON.stringify(data));
          this.model = this.authDataService.getUserData();
          this.cleanUserLoginDataScreen();
          this.authDataService.thatsOk();
        } else {
          alert('Error! This user cannot be logged!');
        }
      }, error => {
        console.log(error);
        alert('User invalid!');
      })
    }
  }

  justCheckLogin() {
    if (this.model.userLogin.email == undefined || this.model.userLogin.password == undefined) {
      alert('ESCREVE ALGUMA COISA AI HOME!!!!!');
      return false;
    } else {
      return true;
    }    
  }

  cleanUserLoginDataScreen() {
    this.model.userLogin.email = '';
    this.model.userLogin.password = '';
  }

  ngOnInit() {
    //this.authDataService.isAuthenticated();
    this.model = this.authDataService.getUserData();
    this.authDataService.thatsOk();
  }
}
