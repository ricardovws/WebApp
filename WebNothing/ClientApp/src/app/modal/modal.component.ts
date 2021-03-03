import { Component, Input, Output, EventEmitter } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { userModel } from '../__models/userModel';
import { ErrorHandlerService } from '../_data-services/errorHandler';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent {

  @Input() action;

  model: userModel = null;
  
  @Output() passEntry: EventEmitter<any> = new EventEmitter();

  constructor(public activeModal: NgbActiveModal, public errorHandlerService: ErrorHandlerService) { }

  passBack(model) {
    this.passEntry.emit(model);
    if (this.action == 'Edit') {

    } else {
      this.activeModal.close();
    }    
  }

  isAddModal() {
    if (this.action == 'Add')
      return true;
  }

  isEditModal() {
    if (this.action == 'Edit')
      return true;
  }

  isDeleteModal() {
    if (this.action == 'Delete')
      return true;
  }

}

