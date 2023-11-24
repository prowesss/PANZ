import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MembershipType } from 'src/app/models/membership-type.model';

@Component({
  selector: 'app-membership-type-card',
  templateUrl: './membership-type-card.component.html',
  styleUrls: ['./membership-type-card.component.scss']
})
export class MembershipTypeCardComponent {
  @Input() membershipTypes: MembershipType[] = [];
  @Output() onMembershipTypeSelect = new EventEmitter<MembershipType>();

  selectMembershipType(type: MembershipType) {
    this.onMembershipTypeSelect.emit(type);
  }
}
