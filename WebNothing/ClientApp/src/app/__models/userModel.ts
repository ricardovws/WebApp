import { errorMessage } from "./errorMessage";

export class userModel {
  id: number;
  name: string;
  email: string;
  password: string;
  confirmPassword: string;

  //errors
  nameError: errorMessage;
  emailError: errorMessage;
  passwordError: errorMessage;
  confirmPasswordError: errorMessage;
  
  constructor(id: number, name: string, email: string,
    password: string,
    confirmPassword: string) {
    this.id = id;
    this.name = name;
    this.email = email
    this.password = password;
    this.confirmPassword = confirmPassword;
  }
}
