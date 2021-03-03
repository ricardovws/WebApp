import { Component, OnInit } from '@angular/core';
import { UserDataService } from '../_data-services/user.data-service';
import { AuthDataService } from '../_data-services/auth.data-service';
import { userLoggedData } from '../__models/userLoggedData';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { ModalComponent } from '../modal/modal.component';
import { modalModel } from '../__models/modalModel';
import { userModel } from '../__models/userModel';
import { ToastService } from '../_data-services/toast.data-service';
import { ErrorHandlerService } from '../_data-services/errorHandler';
import { errorMessage } from '../__models/errorMessage';

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

  modalRef: NgbModalRef;

  showToast: boolean;
  
  constructor(private userDataService: UserDataService, private authDataService: AuthDataService,
    private modalService: NgbModal,
    private toastService: ToastService,
    private errorHandlerService: ErrorHandlerService) {

    this.model = new userLoggedData();
  }

  ngOnInit() {
    //Ao iniciar o componente, caso o usuário não
    //esteja com o token válido, ele será direcionado para a tela de login!
    //Caso estiver ok e conseguir fazer o get, terminar de pegar as infos para mandar para a view!
    this.get();
  }

  addUser() {
    this.modalContent = new modalModel(
      'Add'
    );

    var user = new userModel(0, null, null, null);

    this.buildModalContent(this.modalContent, user).componentInstance.passEntry.subscribe((receivedEntry) => {
      this.user = new userModel(0, receivedEntry.name, receivedEntry.email,
        receivedEntry.password);
      this.post();
    })
  }

  onEdit(user) {
    this.modalContent = new modalModel(
      'Edit'
    );

    user = new userModel(user.id, user.name, user.email, user.password);

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

  private buildModalContent(modalContent: modalModel, user: userModel, errorMessages?: any) {
    const modalRef = this.modalService.open(ModalComponent, { centered: true });
    modalRef.componentInstance.action = modalContent.action;
    modalRef.componentInstance.model = user;
    this.modalRef = modalRef;

    //Add message errors
    if (errorMessages != null) {
      this.modalRef = this.errorHandlerService.addErrors(modalRef, errorMessages);
    }
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
        this.toastService.show("", this.user.name + " has been updated!", "bg-success text-light");
        this.get();
        this.user = null;

        setTimeout(() => {
          this.modalService.dismissAll();
        }, 500)

        //this.user = {};
      } else {
        debugger;
        alert('Error! This user cannot be updated!');
      }
    }, error => {
        
        var errorMessages = error.error.errors;
        this.toastService.show("Error!", errorMessages.Password, "bg-danger text-light");

        this.modalService.dismissAll();

        setTimeout(() => {

          this.buildModalContent(this.modalContent, this.user, errorMessages).componentInstance.passEntry.subscribe((receivedEntry) => {
            this.user = new userModel(receivedEntry.id, receivedEntry.name, receivedEntry.email,
              receivedEntry.password);
            this.put();
          });

        }, 50)

    })
  }


  delete(user) {
    this.userDataService.delete(user.id).subscribe((data: userModel) => {
      if (data) {
        this.toastService.show("", user.name + " has been deleted!", "bg-success text-light");
        this.get();
        this.user = null;
        //this.user = {};
      } else {
        this.toastService.show("", "Error! This user cannot be deleted!", "bg-warning text-light");
      }
    }, error => {
      console.log(error);
      this.toastService.show("Error!", "Something went wrong! Check your console!", "bg-warning text-light");
    })
  }


}
