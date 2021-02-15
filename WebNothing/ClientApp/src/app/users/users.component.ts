import { Component, OnInit } from '@angular/core';
import { UserDataService } from '../_data-services/user.data-service';
import { AuthDataService } from '../_data-services/auth.data-service';
import { userLoggedData } from '../__models/userLoggedData';
//import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css'],
  providers: [userLoggedData]
})
export class UsersComponent implements OnInit {

  users: any[] = [];
  user: any = {};
  showList: boolean = true;

  editModal: boolean = false;

  model: userLoggedData;

  constructor(private userDataService: UserDataService, private authDataService: AuthDataService) {
    this.model = new userLoggedData();
  }

  ngOnInit() {
    this.model = this.authDataService.getUserData();
    this.get();
  }



  openEditModal(user) {

  }



  save() {
    if (this.user.id) {
      this.put()
    } else {
      this.post()
    }
  }


  get() {
    this.userDataService.get().subscribe((data: any[]) => {
      this.users = data;
      this.showList = true;
    }, error => {
      console.log(error);
      alert('internal error!');
    })
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


  delete(user) {
    this.userDataService.delete(user.id).subscribe(data => {
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


}
