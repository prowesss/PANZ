import { Component, OnInit } from '@angular/core';
import { UserManageService } from 'src/app/admin/pages/user-manage/user-manage.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit{
loggedIn = false;
username: string = '';
currentUser= "";

constructor(private userService: UserManageService) { }

ngOnInit(): void {
}

logout(){
  this.loggedIn = false;
}
}
