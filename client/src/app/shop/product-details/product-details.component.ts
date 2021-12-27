import { IProduct } from 'src/app/shared/models/product';
import { Component, OnInit } from '@angular/core';
import { ShopService } from '../shop.service';
import { ActivatedRoute } from '@angular/router';
import { BreadcrumbService } from 'xng-breadcrumb';
import { BasketService } from 'src/app/basket/basket.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  product: IProduct;
  quantity = 1;

  constructor(private shopService: ShopService, private activeRoute: ActivatedRoute,
    private bcservice: BreadcrumbService, private basketService: BasketService) {
      this.bcservice.set('@productDetails',' ')
     }

  ngOnInit(): void {
    this.loadProduct();
  }

  addItemToBasket() {
    this.basketService.addItemToBasket(this.product, this.quantity);
  }

  incrementQuantity() {
    this.quantity++;
  }

  decrementQuantity() {
    if (this.quantity > 1) {
      this.quantity--;
    }
  }

  loadProduct() {
    this.shopService.getProduct(+this.activeRoute.snapshot.paramMap.get('id')).subscribe(product => { 
      this.product = product;
      this.bcservice.set('@productDetails', product.name);
    },error => {
      console.log(error);
    });
  }
}
