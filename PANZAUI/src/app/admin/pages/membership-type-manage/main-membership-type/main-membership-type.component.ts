import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { ConfirmationDialogComponent } from 'src/app/shared/components/confirmation-dialog/confirmation-dialog.component';
import { MembershipTypeService } from 'src/app/admin/services/membership-type/membership-type.service';
import { MembershipType } from 'src/app/models/membership-type.model';

@Component({
  selector: 'app-main-membership-type',
  templateUrl: './main-membership-type.component.html',
  styleUrls: ['./main-membership-type.component.scss']
})
export class MainMembershipTypeComponent {
  membershipTypes: MembershipType[] = [];
  displayedColumns: string[] = ['position', 'name', 'cost', 'duration', 'action'];
  dataSource = new MatTableDataSource<MembershipType>;

  constructor(
    private membershipTypeService: MembershipTypeService,
    public dialog: MatDialog,
    private router: Router
  ) { }

  ngOnInit() {
    this.getMembershipTypes();
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  getMembershipTypes() {
    this.membershipTypeService.getMembershipTypes().subscribe({
      next: (response) => {
        this.membershipTypes = response;
        this.dataSource = new MatTableDataSource(response);
      },
      error: () => {
        console.log('Error');
      }
    })
  }

  onDelete(membershipTypes: MembershipType) {
    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      data: membershipTypes,
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        // this.deleteUser(result.id)
      }
    })
  }

  // deleteUser(id: any) {
  //  this.membershipTypeService.deleteUser(id);
  // }

  onEdit(membershipTypes: MembershipType) {
    console.log("user got edited:", membershipTypes);
  }

  onView(membershipTypes: MembershipType) {
   this.router.navigate(['membership-type', membershipTypes.id])
  }
}
