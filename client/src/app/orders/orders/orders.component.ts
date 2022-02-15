import { IOrder } from './../../shared/models/Order';
import { Component, OnInit } from '@angular/core';
import { OrderService } from '../order.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss']
})
export class OrdersComponent implements OnInit {
  Orders: IOrder[];

  constructor(private orderService: OrderService) { }

  ngOnInit(): void {
    this.orderService.loadOrdersForUser().subscribe(orders => {
      this.Orders = orders;
    }, error => {
      console.log(error);
    });
  }
  
}
