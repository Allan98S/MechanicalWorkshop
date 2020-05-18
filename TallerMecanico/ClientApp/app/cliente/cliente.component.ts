import { Component, OnInit, EventEmitter, Output } from '@angular/core';
@Component({
    selector: 'app-cliente',
    templateUrl: './cliente.component.html',
    styleUrls: ['./cliente.component.css']
})
export class ClienteComponent implements OnInit {
   
    //@Output permite escuchar al component padre
    @Output() featureSelected = new EventEmitter<String>();

    constructor() {

    }
    ngOnInit() {

    }
    onSelect(feature: string) {
        this.featureSelected.emit(feature);
    }
  


}