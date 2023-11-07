import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { User } from 'src/app/models/user.model';
import { ConfirmationDialogComponent } from 'src/app/shared/components/confirmation-dialog/confirmation-dialog.component';
import { UserManageService } from '../user-manage.service';
import { Router } from '@angular/router';

@Component({
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.scss']
})
export class MainPageComponent  implements OnInit {
  users: User[] = [];
  displayedColumns: string[] = ['position', 'email', 'action'];
  dataSource = new MatTableDataSource<User>;

  constructor(
    private userManageService: UserManageService,
    public dialog: MatDialog,
    private router: Router
  ) { }

  ngOnInit() {
    this.getUsers();
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  getUsers() {
    this.userManageService.getUsers().subscribe({
      next: (response) => {
        this.users = response;
        this.dataSource = new MatTableDataSource(response);
      },
      error: () => {
        console.log('Error');
      }
    })
  }

  onDelete(user: User) {
    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      data: user,
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.deleteUser(result.id)
      }
    })
  }

  deleteUser(id: any) {
   this.userManageService.deleteUser(id);
  }

  onEdit(user: User) {
    console.log("user got edited:", user);
  }

  onView(user: User) {
   this.router.navigate(['admin/user', user.id])
  }
}