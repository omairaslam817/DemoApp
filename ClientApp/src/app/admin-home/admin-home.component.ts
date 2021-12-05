import { OnInit } from "@angular/core";
import { UserService } from "../services/user.service";

export class AdminHomeComponent implements OnInit {    
    
  adminData: string;    
    
  constructor(private userService: UserService) { }    
    
  ngOnInit() {    
  }    
    
  fetchAdminData() {    
    this.userService.getAdminData().subscribe(    
      (result: string) => {    
        this.adminData = result;    
      }    
    );    
  }    
}