import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { IProduct } from 'src/app/models/product';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-product-page',
  templateUrl: './product-page.component.html',
  styleUrls: ['./product-page.component.css'],
})
export class ProductPageComponent implements OnInit {
  paramSub!: Subscription;
  productSub!: Subscription;
  selectedCategory: any;
  category!: string;
  id!: number;
  products: IProduct[] = [];
  product!: IProduct;
  error: string | undefined;
  isLoading: boolean = false;

  constructor(
    private productService: ProductService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.paramSub = this.route.paramMap.subscribe((param) => {
      this.getSingleProduct(Number(param.get('id')));
      this.getAllProductsByCategory(String(param.get('category')));
    });
  }

  getSingleProduct(id: number) {
    this.isLoading = true;
    console.log('Id : ' + id);
    if (this.id == id) {
      return;
    }
    this.productSub = this.productService.getSingleProduct(id).subscribe({
      next: (data) => {
        this.product = data;
        this.id = this.product.id;
        console.log(data);
        console.log(this.id);
      },
      error: (err) => console.log(err),
      complete: () => console.log('Getting product by id'),
    });
  }

  getAllProductsByCategory(category: string) {
    this.isLoading = true;
    console.log('Category : ' + category);
    if (this.category == category) {
      return;
    }
    this.category = category;
    this.productSub = this.productService
      .getAllProductsByCategory(category)
      .subscribe({
        next: (data) => {
          this.products = data;
          console.log(data);
        },
        error: (err) => console.log(err),
        complete: () => console.log('Getting products by category'),
      });
  }

  ngOnDestroy(): void {
    console.log('Product page has been closed');

    this.productSub.unsubscribe();
    this.paramSub.unsubscribe();
  }
}
