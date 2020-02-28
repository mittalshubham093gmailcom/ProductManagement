import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from '../../../environments/environment';

@Injectable()
export class ProductService {

  constructor(private _http: HttpClient) { }
  public GetAllProducts(): Observable<any> {
    return this._http.get( "api/Product");
  }
  public AddProducts(product: any): Observable<any> {
    return this._http.post("api/Product/AddProducts", product);
  }
  public DeleteProduct(id: number): Observable<any> {
    return this._http.get("api/Product/DeleteProduct?id=" + id)
  }
  public GetProductById(id: number): Observable<any> {
    return this._http.get("api/Product/GetProductById?id=" + id)
  }
  public GetProductsByCategory(id: number): Observable<any> {
    return this._http.get("api/Product/GetProductsByCategory?id=" + id)
  }
}
