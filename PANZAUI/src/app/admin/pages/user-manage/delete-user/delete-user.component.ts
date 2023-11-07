import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { HttpClient } from '@angular/common/http';

@Component({
  templateUrl: './delete-user.component.html',
  styleUrls: ['./delete-user.component.scss']
})
export class DeleteUserComponent {
  constructor(
    public dialogRef: MatDialogRef<DeleteUserComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private http: HttpClient
  ) {}

  cancel(): void {
    this.dialogRef.close(false); 
  }

  deleteUser(): void {
    const userId = this.data.userId;

    this.http.delete(`/api/users/${userId}`).subscribe(
      () => {
        this.dialogRef.close(true);
      },
      (error) => {
        console.error('Error deleting user:', error);
      }
    );
  }
}
