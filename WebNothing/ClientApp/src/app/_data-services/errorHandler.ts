import { Injectable } from "@angular/core";
import { errorMessage } from "../__models/errorMessage";

@Injectable()
export class ErrorHandlerService {

  addErrors(modalRef: any, errorMessages: any) {
    for (var e in errorMessages) {
      if (e != undefined) {
        debugger;
        var error = new errorMessage(errorMessages[e].Name, errorMessages[e].Message)
        switch (errorMessages[e].Name) {
          case 'Name':
            modalRef.componentInstance.model.nameError = error;
            break;
          case 'Email':
            modalRef.componentInstance.model.emailError = error;
            break;
          case 'Password':
            modalRef.componentInstance.model.passwordError = error;
            break;
          case 'ConfirmPassword':
            modalRef.componentInstance.model.confirmPasswordError = error;
            break;
        }
      }
    }
    return modalRef;
  }
}
