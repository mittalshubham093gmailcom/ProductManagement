import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {
  public editUserForm: FormGroup;
  public profileImage: any;
  public submitted: boolean;
  public ImageFile: any;
  constructor(private formBuilder: FormBuilder, private _productService: ProductService) { }
  get f() { return this.editUserForm.controls; }
  ngOnInit() {
    this.editUserForm = this.formBuilder.group({
      name: ['', [Validators.required]],
      price: ['', [Validators.required,]],
    });
  }
  public fileChangeEvent(event) {
    this.ImageFile = event.target.files[0];
  }
  public updateUser() {
    this.submitted = true;
    if (this.editUserForm.invalid )
      return;
    const formData = new FormData();
    formData.append('name', this.editUserForm.controls["name"].value);
    formData.append('price', this.editUserForm.controls["price"].value);
    if (this.ImageFile)
    formData.append('image', this.ImageFile);

    this._productService.AddProducts(formData).subscribe((response) => {
      console.log('response', response);
    },
      err => {
        console.log('error', err);
      }, () => {
       
      });
  }
}
