import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MembershipTypeService } from 'src/app/admin/services/membership-type/membership-type.service';
import { MembershipType } from 'src/app/models/membership-type.model';

@Component({
  selector: 'app-view-membership-type',
  templateUrl: './view-membership-type.component.html',
  styleUrls: ['./view-membership-type.component.scss']
})
export class ViewMembershipTypeComponent {
  public membershipType: MembershipType | undefined ;
  public isLoading = false;

  constructor(
    private membershipTypeManageService: MembershipTypeService,
    private route: ActivatedRoute,
    private router: Router
  ) { }


  ngOnInit(): void {
    this.isLoading = true;
    this.route.params.subscribe(params => {
      const membershipTypeId = params['id'];
      this.getMembershipType(membershipTypeId);
    });
  }


  getMembershipType(membershipTypeId: any) {
    this.membershipTypeManageService.getMembershipTypeById(membershipTypeId).subscribe({
      next:(membershipType: MembershipType) => {
        this.membershipType = membershipType;
        this.isLoading = true;
      }
    });
  }

  onBackClick(){
    this.router.navigate(['membership-types'])
  }
}
