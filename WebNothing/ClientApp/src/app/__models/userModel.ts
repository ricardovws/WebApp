import { errorMessage } from "./errorMessage";

export class userModel {
  id: number;
  name: string;
  email: string;
  password: string;

  //errors
  nameError: errorMessage;
  emailError: errorMessage;
  passwordError: errorMessage;


  constructor(id: number, name: string, email: string,
    password: string) {
    this.id = id;
    this.name = name;
    this.email = email
    this.password = password;
  }
}
