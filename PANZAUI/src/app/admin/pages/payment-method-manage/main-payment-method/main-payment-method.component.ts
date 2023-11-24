import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { PaymentMethodService } from 'src/app/admin/services/payment-method/payment-method.service';
import { PaymentMethod } from 'src/app/models/payment-method.model';
import { ConfirmationDialogComponent } from 'src/app/shared/components/confirmation-dialog/confirmation-dialog.component';

@Component({
  selector: 'app-main-payment-method',
  templateUrl: './main-payment-method.component.html',
  styleUrls: ['./main-payment-method.component.scss']
})
export class MainPaymentMethodComponent {
  paymentMethods: PaymentMethod[] = [];
  displayedColumns: string[] = ['position', 'name', 'description', 'isActive', 'action'];
  dataSource = new MatTableDataSource<PaymentMethod>;

  constructor(
    private paymentMethodService: PaymentMethodService,
    public dialog: MatDialog,
    private router: Router
  ) { }

  ngOnInit() {
    this.getPaymentMethods();
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  getPaymentMethods() {
    this.paymentMethodService.getPaymentMethods().subscribe({
      next: (response) => {
        this.paymentMethods = response;
        this.dataSource = new MatTableDataSource(response);
      },
      error: () => {
        console.log('Error');
      }
    })
  }

  onDelete(paymentMethods: PaymentMethod) {
    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      data: paymentMethods,
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

  onEdit(paymentMethods: PaymentMethod) {
    console.log("user got edited:", paymentMethods);
  }

  onView(paymentMethods: PaymentMethod) {
   this.router.navigate(['membership-type', paymentMethods.id])
  }
}
