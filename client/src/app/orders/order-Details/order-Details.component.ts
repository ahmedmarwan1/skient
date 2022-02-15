import { BreadcrumbModule, BreadcrumbService } from 'xng-breadcrumb';
import { Component, OnInit } from '@angular/core';
import { OrderService } from '../order.service';
import { ActivatedRoute } from '@angular/router';
import { IOrder } from 'src/app/shared/models/Order';

@Component({
  selector: 'app-order-Details',
  templateUrl: './order-Details.component.html',
  styleUrls: ['./order-Details.component.scss']
})
export class OrderDetailsComponent implements OnInit {
  order: IOrder;

  constructor(private orderservice: OrderService, private bcservice: BreadcrumbService,
    private route: ActivatedRoute)
  { 
    this.bcservice.set('@orderDetails', '');
  }
    

  ngOnInit(): void {
    this.orderservice.getOrderDetails(+this.route.snapshot.paramMap.get('id'))
      .subscribe((order: IOrder) => {
        this.order = order;
        this.bcservice.set('@orderDetails', `Order# ${order.id} - ${order.status}`);
      }, error => { 
        console.log(error);
      });
  }


}
