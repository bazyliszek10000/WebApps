import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-left-panel',
  templateUrl: './left-panel.component.html',
  styleUrls: ['./left-panel.component.scss']
})
export class LeftPanelComponent {

    newTask: string = '';

    @Output()
    onAdd = new EventEmitter<string>();

    addTask = () => {
      debugger;
        this.onAdd.emit(this.newTask);
        this.newTask = '';
    }
}
