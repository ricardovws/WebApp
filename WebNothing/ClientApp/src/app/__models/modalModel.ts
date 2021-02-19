export class modalModel {
  action: string;
  description: string;
  target: string;
  buttonType: string;
  signal: string;
  deleteModal: boolean = true;

  constructor(action: string, description: string, target: string, signal: string, buttonType: string, deleteModal: boolean) {
    this.action = action;
    this.description = description;
    this.target = target;
    this.signal = signal;
    this.buttonType = buttonType;
    this.deleteModal = deleteModal;
  }

}


