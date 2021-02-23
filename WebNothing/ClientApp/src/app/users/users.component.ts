import { Component, OnInit } from '@angular/core';
import { UserDataService } from '../_data-services/user.data-service';
import { AuthDataService } from '../_data-services/auth.data-service';
import { userLoggedData } from '../__models/userLoggedData';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ModalComponent } from '../modal/modal.component';
import { modalModel } from '../__models/modalModel';
import { userModel } from '../__models/userModel';
import { ToastService } from '../_data-services/toast.data-service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css'],
  providers: [userLoggedData]
})
export class UsersComponent implements OnInit {

  users: userModel[];
  
  user: userModel;
  
  showList: boolean = true;

  model: userLoggedData;

  modalContent: modalModel;
  
  constructor(private userDataService: UserDataService, private authDataService: AuthDataService,
    private modalService: NgbModal,
    private toastService: ToastService){

    this.model = new userLoggedData();
  }

  ngOnInit() {
    //Ao iniciar o componente, caso o usuário não
    //esteja com o token válido, ele será direcionado para a tela de login!
    //Caso estiver ok e conseguir fazer o get, terminar de pegar as infos para mandar para a view!
    this.get();
  }

  showStandard() {
    //alert('olha o pai!')
    //this.toastService.show('I am a standard toast');

    this.toastService.show('I am a standard toast');


  }


  onEdit(user) {
    this.modalContent = new modalModel(
      'Edit'
    );

    this.buildModalContent(this.modalContent, user).componentInstance.passEntry.subscribe((receivedEntry) => {
      this.user = new userModel(receivedEntry.id, receivedEntry.name, receivedEntry.email,
        receivedEntry.password);
      this.put();
    });
  }

  onDelete(user) {
    this.modalContent = new modalModel(
      'Delete'
    );
    this.buildModalContent(this.modalContent, user).componentInstance.passEntry.subscribe((receivedEntry) => {
      this.delete(user);
    });
  }

  private buildModalContent(modalContent: modalModel, user: userModel) {
    const modalRef = this.modalService.open(ModalComponent, { centered: true });
    modalRef.componentInstance.action = modalContent.action;
    modalRef.componentInstance.model = user;
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
    this.userDataService.get().subscribe((data: userModel[]) => {
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
    this.userDataService.post(this.user).subscribe((data: userModel) => {
      if (data) {
        alert('The user has been registered!');
        this.get();
        this.user = null;
        //this.user = {};
      } else {
        alert('Error! This user cannot be registered!');
      }
    }, error => {
      console.log(error);
      alert('internal error!');
    })
  }

  put() {
    this.userDataService.put(this.user).subscribe((data: userModel) => {
      if (data) {
        alert('The user has been updated!');
        this.get();
        this.user = null;
        //this.user = {};
      } else {
        alert('Error! This user cannot be updated!');
      }
    }, error => {
      console.log(error);
      alert('internal error!');
    })
  }


  delete(user) {
    this.userDataService.delete(user.id).subscribe((data: userModel) => {
      if (data) {
        alert('The user has been deleted!');
        this.get();
        this.user = null;
        //this.user = {};
      } else {
        alert('Error! This user cannot be deleted!');
      }
    }, error => {
      console.log(error);
      alert('internal error!');
    })
  }


}
