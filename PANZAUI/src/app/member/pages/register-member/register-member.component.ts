import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MemberService } from '../../services/member.service';
import { CreateMember, Member } from 'src/app/models/member.model';
import { forkJoin } from 'rxjs';
import { PaymentMethodService } from 'src/app/admin/services/payment-method/payment-method.service';
import { MembershipStatusService } from 'src/app/admin/services/membership-status/membership-status.service';
import { PaymentMethod } from 'src/app/models/payment-method.model';
import { MembershipStatus } from 'src/app/models/membership-status.model';
import { MembershipTypeService } from 'src/app/admin/services/membership-type/membership-type.service';
import { MembershipType } from 'src/app/models/membership-type.model';
import { AuthService } from 'src/app/auth/auth.service';
import { MatDialog } from '@angular/material/dialog';
import { MemberCheckoutComponent } from 'src/app/shared/components/member-checkout/member-checkout.component';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-register-member',
  templateUrl: './register-member.component.html',
  styleUrls: ['./register-member.component.scss']
})
export class RegisterMemberComponent implements OnInit {
  personalInfoFormGroup: FormGroup = new FormGroup([]);
  workFormGroup: FormGroup = new FormGroup([]);
  membershipFormGroup: FormGroup = new FormGroup([]);
  userInfo: any
  isLoading = false;

  public paymentMethods: PaymentMethod[] = [];
  public membershipStatus: MembershipStatus[] = [];
  public membershipTypes: MembershipType[] = [];

  public selectedMembershipType: MembershipType | undefined;
  currentMember: Member  | undefined;;

  constructor(private fb: FormBuilder,
    private memberservice: MemberService,
    private dialog: MatDialog,
    private paymentMethodService: PaymentMethodService,
    private membershipStatusService: MembershipStatusService,
    private membershipTypesService: MembershipTypeService,
    private authService: AuthService,
    private snackBar: MatSnackBar) {
  }


  ngOnInit(): void {
    this.authService.user$.subscribe((user) => {
      this.userInfo = user;
    });

    this.isLoading = true;
    this.createFormGroups();
    this.getAllOptions();
  }


  getAllOptions() {
    forkJoin([
      this.paymentMethodService.getPaymentMethods(),
      this.membershipStatusService.getAllMembershipStatus(),
      this.membershipTypesService.getMembershipTypes(),
    ]).subscribe(([paymentMethods, membershipStatus, membershipTypes]) => {
      this.paymentMethods = paymentMethods;
      this.membershipStatus = membershipStatus;
      this.membershipTypes = membershipTypes;
    });
  }

  selectMembershipType(event: any) {
    if(!this.userInfo?.isLoggedIn){
      this.snackBar.open("Please Login or register before proceeding with the member registration", "Close");
      return;
    }
    this.selectedMembershipType = event;
    this.membershipFormGroup.get('membershipTypeId')?.setValue(event.id)
  }

  removeSelectedMembershipType() {
    this.selectedMembershipType = undefined;
    this.membershipFormGroup.get('membershipTypeId')?.reset();
  }

  stripePaymentSucessful(strapiObject: any) {
    this.membershipFormGroup.get('paymentSessionId')?.setValue(strapiObject.sessionId)
  }


  createFormGroups() {
    this.personalInfoFormGroup = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      imageUrl: [''],
      gender: ['', Validators.required],
      phone: ['', Validators.pattern('^[0-9]*$')],
      residencyStatus: ['', Validators.required],
      address: [''],
      suburb: [''],
      city: [''],
    });

    this.workFormGroup = this.fb.group({
      companyName: [''],
      jobTitle: [''],
    });

    this.membershipFormGroup = this.fb.group({
      willingToVolunteer: [false],// Ui
      paymentMethodId: [''],// Ui
      paymentReference: [''],// if bank then show the input field else stripe will create a refernce
      paymentSessionId: [''],// only used by stripe
      membershipStatusId: [''],// if strapi once payment is sucessful then membership status change to running
      membershipPaymentStatusId: [''],// if strapi once payment is sucessful then membership status change to paid
      membershipTypeId: ['', Validators.required],// Ui
      startDate: [''],// stripe: once payment is sucessful then put today's date as start date, Bank: Admin needs to update it.
      expireDate: [''],//Based on the membership type
    });
  }

  register() {
    if (!this.personalInfoFormGroup.valid || !this.workFormGroup.valid || !this.membershipFormGroup.valid) {
      this.personalInfoFormGroup.markAllAsTouched();
      this.workFormGroup.markAllAsTouched();
      this.membershipFormGroup.markAllAsTouched();
      return;
    }
    
    const createMember: CreateMember = {
      userId: this.userInfo.userId,
      email: this.personalInfoFormGroup.get('email')!.value || '',
      firstName: this.personalInfoFormGroup.get('firstName')!.value || '',
      lastName: this.personalInfoFormGroup.get('lastName')!.value || '',
      imageUrl: this.personalInfoFormGroup.get('imageUrl')!.value || '',
      gender: this.personalInfoFormGroup.get('gender')!.value || '',
      residencyStatus: this.personalInfoFormGroup.get('residencyStatus')!.value || '',
      phone: this.personalInfoFormGroup.get('phone')!.value || '',
      willingToVolunteer: this.membershipFormGroup.get('willingToVolunteer')!.value || false,
      address: this.personalInfoFormGroup.get('address')!.value || '',
      suburb: this.personalInfoFormGroup.get('suburb')!.value || '',
      city: this.personalInfoFormGroup.get('city')!.value || '',
      companyName: this.workFormGroup.get('companyName')!.value || '',
      jobTitle: this.workFormGroup.get('jobTitle')!.value || '',
      paymentMethodId: this.membershipFormGroup.get('paymentMethodId')!.value,
      paymentReference: this.membershipFormGroup.get('paymentReference')!.value,
      paymentSessionId: this.membershipFormGroup.get('paymentSessionId')!.value,
      membershipStatusId: this.membershipFormGroup.get('membershipStatusId')!.value,
      membershipPaymentStatusId: this.membershipFormGroup.get('membershipPaymentStatusId')!.value,
      membershipTypeId: this.membershipFormGroup.get('membershipTypeId')!.value,
      startDate: this.membershipFormGroup.get('startDate')!.value || new Date(),
      expireDate: this.membershipFormGroup.get('expireDate')!.value || new Date(),
    };
    console.log('Creating member with the following data:', createMember);
    this.memberservice.addMember(createMember).subscribe(
      (response) => {
        this.currentMember = response;
        console.log('Member registered successfully', response);
      },
      (error) => {
        console.error('Error registering member', error);
      }
    );
  }

  openCheckoutPopup(): void {
    const dialogRef = this.dialog.open(MemberCheckoutComponent, {
      width: '1000px',
      height: '500px',
      data: {
        paymentMethods: this.paymentMethods,
        selectedMembershipType: this.selectedMembershipType,
        member: this.currentMember
      },
    });
  
    // You can subscribe to the afterClosed event if you need to perform any action after the pop-up is closed
    dialogRef.afterClosed().subscribe(result => {
      // Handle the result if needed
    });
  }
  

}
