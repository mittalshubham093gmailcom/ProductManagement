import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { ProductService } from './product.service';
import { error } from 'protractor';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { validateConfig } from '@angular/router/src/config';
import { CartService } from '../cart/cart.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  formProduct: FormGroup;
  public products: any[];
  public categories: any[];
  public user: number = 2;
  public selectedCards =[];
  public selectedCategory: any;

  @ViewChild('closeBtn') closeBtn: ElementRef;

  constructor(private _router: Router, private _ProductService: ProductService, private route: ActivatedRoute, private formBuilder: FormBuilder, private _cartService: CartService) {
    this.route.params.subscribe(params => {
      if (params && params['user'] && (params['user'] == "1" || params['user'] == '1')) {
        this.user = 1;
      }
      else {
        this.user = 2;
      }
    }
    );
  }
  public invalidPrice: boolean = false;
  public isCategoryUnselected: boolean = false;
  public submitted = false;
  ngOnInit() {
    this.getAllProducts();
    this.initializedFOrmGroup();
  }
  public initializedFOrmGroup() {
    this.invalidPrice = false;
    this.isCategoryUnselected = false;
    this.submitted = false;
    this.formProduct = this.formBuilder.group({
      name: ['', Validators.required],
      price: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(5)]],
      category: [0, [Validators.required]]
    });
  }
  get f() { return this.formProduct.controls; }

  public checkValue(isChecked, id) {
    {
      if (isChecked) {
        this.selectedCards.push(id);
      }
      else {
        if (!this.selectedCards || this.selectedCards.length <= 0)
          return;
        const index = this.selectedCards.findIndex(order => order==id);
        this.selectedCards.splice(index, 1);
      }
    }
    
    console.log(event);
    console.log(id);
  }
  public deleteProduct() {
    this._ProductService.DeleteProduct(1).subscribe((response) => {
      if (response && response == 1) {
        this.getAllProducts();
      }
    }, (error) => {
      alert("Error while deleteting products");
    }, () => {

    });
  }


  public addItemsIntoCart(productId) {
    this._cartService.AddProductsInCart(this.user, productId).subscribe((res) => {
      if (res) {
        if (res == 1) {
          this._router.navigate(['/cart', this.user]);
        }
        else if (res == 2) {
          alert('Item Already exists in Cart');
          this._router.navigate(['/cart', this.user]);
        }
      }
    }, (error) => {

    }, () => {

    });
  }

  public GoToCart() {
    this._router.navigate(['/cart', this.user]);
  }
  public AddSelectedItemToCards() {
    this._cartService.AddMultipleProductsToCart(this.user, this.selectedCards).subscribe((res) => {
      if (res) {
        if (res == 1) {
          this._router.navigate(['/cart', this.user]);
        }
      }
    }, (error) => {

    }, () => {

    });
  }
  public filterProductsBasedOnCategory(val) {
    if (val == 0 || !val || val == '' || val == "") {
      this.selectedCategory = undefined;
      this.getAllProducts();
    }
    else {
      this.selectedCategory = val;
      this._ProductService.GetProductsByCategory(val).subscribe((response) => {
        if (response) {
          this.products = response;
        } else
          alert("No products for selected category");
      }, (error) => {
        alert(error);
      }, () => {

      }); 
    }

  }
  private getAllProducts() {
    this._ProductService.GetAllProducts().subscribe((response) => {
      if (response) {
        this.products = response.products;
        this.categories = response.categories;
      }
    }, (error) => {
      alert(error);
    }, () => {

    });
  }
  public OnSelectDropDown(val) {
    this.formProduct.get('category').setValue(val, {
      onlySelf: true
    });
  }



  public AddProducts() {
    this.submitted = true;
    if (this.formProduct.get('price').value <= 0) {
      this.invalidPrice = true;
      return;
    }
    if (this.formProduct.get('category').value <= 0) {
      this.isCategoryUnselected = true;
      return;
    }
    // stop here if form is invalid
    if (this.formProduct.invalid) {
      return;
    }
    let prod = {
      name: this.formProduct.get('name').value,
      CategoryId: +this.formProduct.get('category').value,
      price: this.formProduct.get('price').value

    }
    this._ProductService.AddProducts(prod).subscribe((resp) => {
      if (resp) {
        if (this.selectedCategory && this.selectedCategory != 0) {
          this.filterProductsBasedOnCategory(this.selectedCategory);

        }
        else {
          this.getAllProducts();
        }
        this.closeBtn.nativeElement.click();

      }
    }, (error) => {

    },
      () => {

      });
  }
}
