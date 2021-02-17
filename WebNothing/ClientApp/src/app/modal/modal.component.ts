import { Component, Input, Output, EventEmitter } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent {

  @Input() action;
  @Input() target;
  @Input() signal;
  @Input() objectDescription;
  @Input() buttonType;
  
  
  @Output() passEntry: EventEmitter<any> = new EventEmitter();

  constructor(public activeModal: NgbActiveModal) { }

  passBack() {
    this.passEntry.emit();
    this.activeModal.close();
  }

}

