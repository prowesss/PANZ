import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { UserRolesService } from 'src/app/admin/services/user-roles.service';
import { Role } from 'src/app/models/role.model';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page-roles.component.html',
  styleUrls: ['./main-page-roles.component.css']
})
export class MainPageRolesComponent implements OnInit {
  roles: Role[] = [];
  displayedColumns: string[] = [
    'position', 
    'name',
    'action'
    ];
  dataSource = new MatTableDataSource<Role>;

  constructor(
    private roleService: UserRolesService,
    public dialog: MatDialog,
    private router: Router
  ) { }

  ngOnInit() {
    this.getRoles();
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  getRoles() {
    this.roleService.getRoles().subscribe({
      next: (response) => {
        this.roles = response;
        this.dataSource = new MatTableDataSource(response);
      },
      error: () => {
        console.log('Error');
      }
    })
  }

  
  onDelete(role: Role) {
    console.log("role got deleted:", role);
  }

  // onDelete(role: Roles) {
  //   const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
  //     data: role,
  //   });

  //   dialogRef.afterClosed().subscribe((result) => {
  //     if (result) {
  //       this.deleteRole(result.id)
  //     }
  //   })
  // }

  // deleteMember(id: any) {
  //   this.memberService.deleteMember(id).subscribe(
  //     () => {
  //       this.members = this.members.filter(member => member.id !== id);
  //       this.dataSource = new MatTableDataSource(this.members);
  //     },
  //     (error) => {
  //       console.error('Error deleting member:', error);
  //     }
  //   );
  // }

  onEdit(role: Role) {
    console.log("role got edited:", role);
  }

  onView(role: Role) {
   this.router.navigate(['//', role])
  }
}

