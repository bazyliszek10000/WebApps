import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
    selector: 'app-right-panel',
    templateUrl: './right-panel.component.html',
    styleUrls: ['./right-panel.component.scss']
})

export class RightPanelComponent {

    @Input()
    tasks: string[] = [];

    @Output()
    onRemove = new EventEmitter<IRemove>();

    removeTask = (name: string) => {
        this.onRemove.emit({ name, index: 1 });
    }
}

export interface  IRemove {
    name: string;
    index: number;
}
