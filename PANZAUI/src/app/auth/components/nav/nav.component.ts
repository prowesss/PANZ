import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit{
loggedIn = false;
currentUser= "avinash";

public NavComponent(){
}

ngOnInit(): void {
  
}

logout(){
  this.loggedIn = false;
}
}
