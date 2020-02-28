import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from '../../../environments/environment';

@Injectable()
export class CartService {

  constructor(private _http: HttpClient) { }
  public GetItemFromCart(id: number): Observable<any> {
    return this._http.get("api/Cart/GetItemFromCart?id="+id);
  }
  public AddProductsInCart(cartId: number, productId: number): Observable<any> {
    let cart = {
      CartId: cartId,
      ProductId: productId
    };
    return this._http.post("api/Cart/AddItemToCart", cart);
  }
  public AddMultipleProductsToCart(cartId: number, productIds): Observable<any> {
    let cart = {
      CartId: cartId,
      ProductIds: productIds
    };
    return this._http.post("api/Cart/AddMultipleProductsToCart", cart);
  }
  public RemoveProductsFromCart(cartId: number, productId: number): Observable<any> {
    let cart = {
      CartId: cartId,
      ProductId: productId
    };
    return this._http.post("api/Cart/RemoveItemFromCart",cart);
  }
  public RemoveAllItemFromCart(id: number): Observable<any> {
    return this._http.get("api/Cart/RemoveAllItemFromCart?id="+id);
  }

}
