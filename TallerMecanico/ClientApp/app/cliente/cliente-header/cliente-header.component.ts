import { Component, OnInit } from "@angular/core"
import { ClienteService } from "../../Service/cliente.service";
import { Cliente } from "../../Model/cliente";
import { Router } from "@angular/router";
@Component({
    selector: 'app-cliente-header',
    templateUrl: './cliente-header.component.html',
    styleUrls: ['./cliente-header.component.css']
})
export class ClienteHeaderComponent   {
    tittle = "app";
    loadedFeature = 'cliente';

  
    onNavigate(feature: string) {
        this.loadedFeature = feature;
    }


}