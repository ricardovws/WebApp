import { Component, OnInit } from '@angular/core';
import { UserDataService } from '../_data-services/user.data-service';
import { AuthDataService } from '../_data-services/auth.data-service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  users: any[] = [];
  user: any = {};
  showList: boolean = true;

  userLogin: any = {};
  isAuthenticated: boolean = false;
  userLogged: any = {};

  constructor(private userDataService: UserDataService, private authDataService: AuthDataService) { }

  get() {
    this.userDataService.get().subscribe((data:any[]) => {
      this.users = data;
      this.showList = true;
    }, error => {
        console.log(error);
        alert('internal error!');
    })
  }

  save() {
    if (this.user.id) {
      this.put()
    } else {
      this.post()
    }
  }

  post() {
    this.userDataService.post(this.user).subscribe(data => {
      if (data) {
        alert('The user has been registered!');
        this.get();
        this.user = {};
      } else {
        alert('Error! This user cannot be registered!');
      }
    }, error => {
        console.log(error);
        alert('internal error!');
    })
  }

  put() {
    this.userDataService.put(this.user).subscribe(data => {
      if (data) {
        alert('The user has been updated!');
        this.get();
        this.user = {};
      } else {
        alert('Error! This user cannot be updated!');
      }
    }, error => {
      console.log(error);
      alert('internal error!');
    })
  }

  openDetails(user) {
    this.showList = false;
    this.user = user;
  }

  delete(user) {
    this.userDataService.delete().subscribe(data => {
      if (data) {
        alert('The user has been deleted!');
        this.get();
        this.user = {};
      } else {
        alert('Error! This user cannot be deleted!');
      }
    }, error => {
      console.log(error);
      alert('internal error!');
    })
  }

  ngOnInit() {
    
  }
}
