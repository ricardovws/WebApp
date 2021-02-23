import { Component, Input, Output, EventEmitter } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { debug } from 'console';
import { userLoggedData } from '../__models/userLoggedData';
import { userModel } from '../__models/userModel';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent {

  @Input() action;

  model: userModel = null;
  
  @Output() passEntry: EventEmitter<any> = new EventEmitter();

  constructor(public activeModal: NgbActiveModal) { }

  passBack(model) {
    this.passEntry.emit(model);
    this.activeModal.close();
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

