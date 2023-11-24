import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { MemberService } from 'src/app/member/services/member.service';
import { Member } from 'src/app/models/member.model';
import { ConfirmationDialogComponent } from 'src/app/shared/components/confirmation-dialog/confirmation-dialog.component';

@Component({
  selector: 'app-main-members',
  templateUrl: './main-members.component.html',
  styleUrls: ['./main-members.component.scss',]
})
export class MainMembersComponent implements OnInit {
  members: Member[] = [];
  displayedColumns: string[] = [
    'position', 
    'email',
    'fullName',
    'paymentMethod',
    'paymentReference',
    'membershipStatus',
    'membershipPaymentStatus',
    'membershipType',
    'startDate',
    'expireDate',
    'action'];
  dataSource = new MatTableDataSource<Member>;

  constructor(
    private memberService: MemberService,
    public dialog: MatDialog,
    private router: Router
  ) { }

  ngOnInit() {
    this.getMembers();
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  getMembers() {
    this.memberService.getMembers().subscribe({
      next: (response) => {
        this.members = response;
        this.dataSource = new MatTableDataSource(response);
      },
      error: () => {
        console.log('Error');
      }
    })
  }

  

  onDelete(member: Member) {
    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      data: member,
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.deleteMember(result.id)
      }
    })
  }

  deleteMember(id: any) {
    this.memberService.deleteMember(id).subscribe(
      () => {
        this.members = this.members.filter(member => member.id !== id);
        this.dataSource = new MatTableDataSource(this.members);
      },
      (error) => {
        console.error('Error deleting member:', error);
      }
    );
  }

  onEdit(member: Member) {
    console.log("user got edited:", member);
  }

  onView(member: Member) {
   this.router.navigate(['admin/member', member.id])
  }
}
