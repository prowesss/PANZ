import { Component, OnInit } from '@angular/core';
import { UserManageService } from '../user-manage.service';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/models/user.model';


@Component({
  templateUrl: './view-user.component.html',
  styleUrls: ['./view-user.component.scss']
})
export class ViewUserComponent implements OnInit{

  public user: User | undefined ;
  public isLoading = false;

  constructor(
    private userManageService: UserManageService,
    private route: ActivatedRoute,
    private router: Router
  ) { }


  ngOnInit(): void {
    this.isLoading = true;
    this.route.params.subscribe(params => {
      const userId = params['id'];
      this.getUser(userId);
    });
  }


  getUser(userId: any) {
    this.userManageService.getUserById(userId).subscribe({
      next:(user: User) => {
        this.user = user;
        this.isLoading = true;
      }
    });
  }

  onBackClick(){
    this.router.navigate(['admin/users'])
  }
}