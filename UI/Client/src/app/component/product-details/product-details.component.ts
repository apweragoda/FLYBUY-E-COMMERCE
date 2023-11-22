import { compileDeclareInjectorFromMetadata } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
//import { ICartItem } from 'src/app/models/cartItem';
import { IProduct } from 'src/app/models/product';
import { CartService } from 'src/app/services/cart.service';
import { NotificationService } from 'src/app/services/notification.service';
//import { CartService } from 'src/app/services/cart.service';
//import { NotificationService } from 'src/app/services/notification.service';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css'],
})
export class ProductDetailsComponent implements OnInit {
  product!: IProduct;
  products: IProduct[] = [];
  form!: FormGroup;
  formSubmitAttempt: boolean = false;
  errorMessage: string | undefined;
  id: number | undefined;
  selectedSize: string | undefined;
  category!: string;

  constructor(
    private productService: ProductService,
    private cartService: CartService,
    private route: ActivatedRoute,
    private formBuilder: FormBuilder,
    private notificationService: NotificationService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.id = Number(this.route.snapshot.paramMap.get('id'));
    this.productService.getSingleProduct(this.id).subscribe({
      next: (returnedProduct) => {
        this.product = returnedProduct;
        this.getAllProductsByCategory(returnedProduct.category);
        this.category = returnedProduct.category;
        console.log(returnedProduct);
        console.log(returnedProduct.category);
      },
      error: (err) => console.log(err.error),
      complete: () => console.log('completed'),
    });

    this.form = this.formBuilder.group({
      size: ['', Validators.required],
      quantity: 1,
    });
  }

  getAllProductsByCategory(category: string) {
    this.productService.getAllProductsByCategory(category).subscribe({
      next: (data) => {
        this.products = data;
        console.log(data);
      },
      error: (err) => console.log(err),
      complete: () => console.log('Getting products by category'),
    });
  }
  updateSize(size: string) {
    this.selectedSize = size;
    console.log(this.selectedSize);
  }

  addToCart() {
    // this.formSubmitAttempt = true;
    // if (this.form.valid) {
    //   const cartItem = {
    //     product: this.product,
    //     quantity: Number(this.form.value.quantity),
    //     size: "M",
    //   };
    const cartItem = {
        product: this.product,
        quantity: Number(this.form.value.quantity),
        size: "M",
      };
      this.cartService.addItemToCart(cartItem);
      this.notificationService.showNotification(
        'success',
        'Item added to cart successfully.'
      );
      this.router.navigate(['/cart']);

      console.log(cartItem);
    }
}
