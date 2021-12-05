import { OnInit } from "@angular/core";
import { UserService } from "../services/user.service";

export class UserHomeComponent implements OnInit {    
    
  userData: string;    
    
  constructor(private userService: UserService) { }    
    
  ngOnInit() {    
  }    
    
  fetchUserData() {    
    this.userService.getUserData().subscribe(    
      (result: string) => {    
        this.userData = result;    
      }    
    );    
  }    
}    