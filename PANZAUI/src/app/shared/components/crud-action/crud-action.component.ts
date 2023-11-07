import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-crud-action',
  templateUrl: './crud-action.component.html',
  styleUrls: ['./crud-action.component.scss']
})
export class CrudActionComponent {

  @Output() viewClick = new EventEmitter<void>();
  @Output() editClick = new EventEmitter<void>();
  @Output() deleteClick = new EventEmitter<void>();

  onViewClick() {
    this.viewClick.emit();
  }

  onEditClick() {
    this.editClick.emit();

  }

  onDeleteClick() {
    this.deleteClick.emit();
  }
}
