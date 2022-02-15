import { IOrder } from './../shared/models/Order';
import { map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  baseUrl = environment.apiUrl;

  constructor(private htttp: HttpClient) { }

  loadOrdersForUser() {
    return this.htttp.get(this.baseUrl + 'orders').pipe(
      map((orders: IOrder[]) => { 
        return orders.sort((a, b) => b.id - a.id);
      })
    );
  }

  getOrderDetails(id: number) {
    return this.htttp.get(this.baseUrl + 'orders/' + id);
  }
}
