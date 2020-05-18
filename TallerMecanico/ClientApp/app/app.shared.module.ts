import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { ModelModule } from './Service/model.module';
import { HeaderComponent } from './header/header.component';
import { ReporteComponent } from './Reporte/reporte.component';
import { VehiculoListaComponent } from './vehiculo/vehiculo-lista/vehiculo-lista.component';
import { VehiculoModificarComponent } from './vehiculo/vehiculo-modificar/vehiculo-modificar.component';
import { VehiculoRegistrarComponent } from './vehiculo/vehiculo-registrar/vehiculo-registrar.component';
import { VehiculoComponent } from './vehiculo/vehiculo.component';
import { ClienteListaComponent } from './cliente/cliente-buscar/cliente-buscar.component';
import { ClienteEditarComponent } from './cliente/cliente-editar/cliente-editar.component';
import { ClienteRegistroComponent } from './cliente/cliente-registro/cliente-registro.component';
import { ClienteBorrarComponent} from './cliente/cliente-borrar/cliente-borrar.component';
import { ClienteComponent } from './cliente/cliente.component';
import { ClienteHeaderComponent } from './cliente/cliente-header/cliente-header.component';
import { OrdenTrabajoComponent } from './OrdenTrabajo/ordenTrabajo.component';
import { DetalleOrdenComponent } from './DetalleOrden/detalleOrden.component';
import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';


@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        ClienteComponent, ClienteHeaderComponent, ClienteListaComponent, ClienteEditarComponent, ClienteRegistroComponent, ClienteBorrarComponent,
        VehiculoComponent, VehiculoListaComponent, VehiculoModificarComponent, VehiculoRegistrarComponent,
        DetalleOrdenComponent,
        HeaderComponent,
        OrdenTrabajoComponent,
        ReporteComponent,
    ],
    imports: [
        CommonModule,
        ModelModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', component: HomeComponent, pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'cliente', component: ClienteComponent },
            { path: 'clienteHeader', component: ClienteHeaderComponent },
            { path: 'listaClientes', component: ClienteListaComponent },
            { path: 'editarCliente', component: ClienteEditarComponent },
            { path: 'registroCliente', component: ClienteRegistroComponent },
            { path: 'registoVehiculo', component: VehiculoRegistrarComponent },
            { path: 'listaVehiculo', component: VehiculoListaComponent },
            { path: 'modificarVehiculo', component: VehiculoModificarComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}
