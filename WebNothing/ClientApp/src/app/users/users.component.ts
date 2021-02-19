import { Component, OnInit } from '@angular/core';
import { UserDataService } from '../_data-services/user.data-service';
import { AuthDataService } from '../_data-services/auth.data-service';
import { userLoggedData } from '../__models/userLoggedData';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { ModalComponent } from '../modal/modal.component';
import { modalModel } from '../__models/modalModel';

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

  model: userLoggedData;

  modalContent: modalModel;
  
  constructor(private userDataService: UserDataService, private authDataService: AuthDataService,
    private modalService: NgbModal) {

    this.model = new userLoggedData();
  }

  ngOnInit() {
    //Ao iniciar o componente, caso o usuário não
    //esteja com o token válido, ele será direcionado para a tela de login!
    //Caso estiver ok e conseguir fazer o get, terminar de pegar as infos para mandar para a view!
    this.get();
  }

  onEdit(user) {
    this.modalContent = new modalModel(
      'Edit',
      'Would you really like to edit ',
      user.name,
      '?',
      'info',
      false
    );
    this.buildModalContent(this.modalContent).componentInstance.passEntry.subscribe((receivedEntry) => {
      this.user.name = 'aiaiaia';
      this.user.email = 'ashuas@husahusahu.ciom';
      this.put();
    });
  }

  onDelete(user) {
    this.modalContent = new modalModel(
      'Delete',
      'Would you really like to delete ',
      user.name,
      '?',
      'danger',
      true
    );
    this.buildModalContent(this.modalContent).componentInstance.passEntry.subscribe((receivedEntry) => {
      this.delete(user);
    });
  }

  private buildModalContent(modalContent: modalModel) {
    const modalRef = this.modalService.open(ModalComponent, { centered: true });
    modalRef.componentInstance.action = modalContent.action;
    modalRef.componentInstance.buttonType = modalContent.buttonType;
    modalRef.componentInstance.objectDescription = modalContent.description;
    modalRef.componentInstance.signal = modalContent.signal;
    modalRef.componentInstance.target = modalContent.target;

    return modalRef;
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
      this.model = this.authDataService.getUserData();
    }, error => {
      console.log(error);
        //alert('internal error!');
        this.authDataService.logOut();
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
