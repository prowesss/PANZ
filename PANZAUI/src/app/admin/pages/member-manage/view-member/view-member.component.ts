import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MemberService } from 'src/app/member/services/member.service';
import { Member } from 'src/app/models/member.model';

@Component({
  selector: 'app-view-member',
  templateUrl: './view-member.component.html',
  styleUrls: ['./view-member.component.scss']
})
export class ViewMemberComponent implements OnInit{

  public member: Member | undefined;
  public isLoading = false;

  constructor(
    private memberService: MemberService,
    private route: ActivatedRoute,
    private router: Router
  ) { }


  ngOnInit(): void {
    this.isLoading = true;
    this.route.params.subscribe(params => {
      const memberId = params['id'];
      this.getMember(memberId);
    });
  }


  getMember(memberId: any) {
    this.memberService.getMemberById(memberId).subscribe({
      next:(member: Member) => {
        this.member = member;
        this.isLoading = false;
      }
    });
  }

  onBackClick(){
    this.router.navigate(['admin/members'])
  }
}

