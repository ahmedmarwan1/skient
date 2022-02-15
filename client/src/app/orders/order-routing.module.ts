import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OrderDetailsComponent } from './order-Details/order-Details.component';
import { OrdersComponent } from './orders/orders.component';

const routes: Routes = [
  { path: '', component: OrdersComponent },
  {path:':id', component:OrderDetailsComponent, data: { breadcrumb: {alias:'orderDetails'}}  }
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class OrdertRoutingModule { }