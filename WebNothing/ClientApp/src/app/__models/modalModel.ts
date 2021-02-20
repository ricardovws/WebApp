export class modalModel {
  action: string;
  description: string;
  target: string;
  buttonType: string;
  signal: string;

  constructor(action: string, description: string, target: string, signal: string, buttonType: string) {
    this.action = action;
    this.description = description;
    this.target = target;
    this.signal = signal;
    this.buttonType = buttonType;
  }

}


