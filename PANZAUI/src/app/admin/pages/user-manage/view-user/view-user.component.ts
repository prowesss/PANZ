import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/auth/auth.service';

@Component({
  templateUrl: './view-user.component.html',
  styleUrls: ['./view-user.component.scss']
})
export class ViewUserComponent implements OnInit {
  users: any;

  constructor(private http: HttpClient) {}
   
  ngOnInit() {
   this.getUsers();
}

getUsers(){
  this.http.get('https://localhost:7106/api/user/list').subscribe(response => {
    this.users= response;
  }, error => {
    console.log(error);
  })
}}