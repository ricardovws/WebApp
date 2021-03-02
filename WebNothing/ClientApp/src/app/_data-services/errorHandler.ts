import { Injectable } from "@angular/core";
import { errorMessage } from "../__models/errorMessage";

@Injectable()
export class ErrorHandlerService {

  addErrors(modalRef: any, errorMessages: any) {
    for (var e in errorMessages) {
      if (e != undefined) {
        var error = new errorMessage(e, errorMessages[e])

        switch (e) {
          case 'Name':
            modalRef.componentInstance.model.nameError = error;
            break;
          case 'Email':
            modalRef.componentInstance.model.emailError = error;
            break;
          case 'Password':
            modalRef.componentInstance.model.passwordError = error;
            break;
        }
      }
    }

    return modalRef;

  }
}
