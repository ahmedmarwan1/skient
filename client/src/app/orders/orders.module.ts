import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrdersComponent } from './orders/orders.component';
import { OrderDetailsComponent } from './order-Details/order-Details.component';
import { OrdertRoutingModule } from './order-routing.module';



@NgModule({
  declarations: [
    OrdersComponent,
    OrderDetailsComponent
  ],
  imports: [
    CommonModule,
    OrdertRoutingModule
  ]
})
export class OrdersModule { }
