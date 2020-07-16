import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { ProductService } from './product.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { CartService } from '../cart/cart.service';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  formProduct: FormGroup;
  public products: any[]=[];
  public categories: any[];
  public user: number = 2;
  public selectedCards =[];
  public selectedCategory: any;

  @ViewChild('closeBtn', { static: true }) closeBtn: ElementRef;

  constructor(private _router: Router, private _ProductService: ProductService, private route: ActivatedRoute, private formBuilder: FormBuilder, private _cartService: CartService, private sanitizer: DomSanitizer) {
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
  public profileImage: any;
  public submitted: boolean;
  public ImageFile: any;
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
      category: ['', [Validators.required]]
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
          for (let i = 0; i < response.products.length; i++) {
            let imgObj;
            if (response.products[i].image && response.products[i].image != null && response.products[i].image != undefined && response.products[i].image != 'null' && response.products[i].image != 'undefined') {
              imgObj = response.products[i].image;
              let objectURL = 'data:image/jpeg;base64,' + imgObj.image;
              imgObj = this.sanitizer.bypassSecurityTrustUrl(objectURL);
            }
            let item = {
              id: response.products[i].id,
              name: response.products[i].name,
              price: response.products[i].price,
              image: (imgObj != undefined && imgObj != null) ? imgObj : 'https://unsplash.it/500/300?image=0'
            }
            this.products.push(item);
          }
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
        //this.products = response.products;
        for (let i = 0; i < response.products.length; i++) {
          let imgObj;
          if (response.products[i].image && response.products[i].image != null && response.products[i].image != undefined && response.products[i].image != 'null' && response.products[i].image != 'undefined') {
            imgObj = response.products[i].image;
            let objectURL = 'data:image/jpeg;base64,' + imgObj;

            imgObj = this.sanitizer.bypassSecurityTrustUrl(objectURL);
          }
            let item = {
            id: response.products[i].id,
            name: response.products[i].name,
              price: response.products[i].price,
              image: (imgObj != undefined && imgObj != null) ? imgObj : 'https://unsplash.it/500/300?image=0'
          }
          this.products.push(item);
        }
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
  public fileChangeEvent(event) {
    this.ImageFile = event.target.files[0];
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
    const formData = new FormData();
    formData.append('name', this.formProduct.controls["name"].value);
    formData.append('price', this.formProduct.controls["price"].value);
    formData.append('CategoryId', this.formProduct.controls["category"].value);
   
    if (this.ImageFile)
      formData.append('image', this.ImageFile);
    
    this._ProductService.AddProducts(formData).subscribe((resp) => {
      if (resp) {
        if (this.selectedCategory && this.selectedCategory != 0) {
          this.filterProductsBasedOnCategory(this.selectedCategory);

        }
        else {
         
        }
        this.getAllProducts();
        this.closeBtn.nativeElement.click();

      }
    }, (error) => {

    },
      () => {

      });
  }
}
