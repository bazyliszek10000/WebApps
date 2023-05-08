import { Component, Output } from '@angular/core';
import { IRemove } from '../right-panel/right-panel.component';

@Component({
    selector: 'app-calc',
    templateUrl: './calc.component.html',
    styleUrls: ['./calc.component.scss']
})

export class CalcComponent {

    tasks: string[] = []

    addTask = (val: string) => {
        debugger;
        if (!val) {
            return;
        }
        this.tasks.push(val);
    }

    removeTask = (val: IRemove) => {
        console.log(val.index);
        this.tasks = this.tasks.filter((item) => item !== val.name);
    }
}
