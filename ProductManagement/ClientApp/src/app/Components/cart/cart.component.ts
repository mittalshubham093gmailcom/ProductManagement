import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CartService } from './cart.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  public products: any[];
  public user: number = 2;
  constructor(private _router: Router, private _route: ActivatedRoute, private _cartService: CartService) { }

  ngOnInit() {
    this._route.params.subscribe(params => {
      if (params && params['user'] && (params['user'] == "1" || params['user'] == '1')) {
        this.user = 1;
      }
      else {
        this.user = 2;
      }
      this.getProductsFromCart();
    }
    );
  }
  public getProductsFromCart() {
    this._cartService.GetItemFromCart(this.user).subscribe((response) => {
      if (response) {
        this.products = response;
      }
    }, (error) => {
      alert(error);
    }, () => {

    });
  }
  public GoToCart() {
    this._router.navigate(['/products', this.user]);
  }
  public checkValue(event, id) {
    console.log(event);
    console.log(id);
  }
  public RemoveItemFromCart(productId) {
    this._cartService.RemoveProductsFromCart(this.user, productId).subscribe((res) => {
      if (res && res == 1) {
        this.getProductsFromCart();
      }
    }, (error) => {

      }, () => {

      })
  }

  public RemoveAllItemFromCart() {
    this._cartService.RemoveAllItemFromCart(this.user).subscribe((res) => {
      if (res && res == 1) {
        this.products = undefined;
      }
    }, (error) => {

    }, () => {

    })
  }

}
