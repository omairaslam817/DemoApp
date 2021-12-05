import { UserRole } from "../models/roles";
import { User } from "../models/user";
import { AuthService } from "../services/auth.service";

export class NavMenuComponent {    
  isExpanded = false;    
  userDataSubscription: any;    
  userData = new User();    
  userRole = UserRole;    
    
  constructor(private authService: AuthService) {    
    this.userDataSubscription = this.authService.userData.asObservable().subscribe(data => {    
      this.userData = data;    
    });    
  }    
    
  collapse() {    
    this.isExpanded = false;    
  }    
    
  toggle() {    
    this.isExpanded = !this.isExpanded;    
  }    
    
  logout() {    
    this.authService.logout();    
  }    
}     