export class errorMessage {
  errorName: string;
  errorDescription: string;
  errorTarget: string;

constructor(errorName: string, errorDescription: string) {
  this.errorName = errorName;
  this.errorDescription = errorDescription;
  this.errorTarget = 'is-invalid';
  }
}
