import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IProduct } from 'src/app/models/product';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  products: IProduct[] = [];
  category!: string;
  constructor(private productService: ProductService) {}
  ngOnInit(): void {
    this.getAllProducts();
  }

  getAllProducts() {
    console.log('Showing all products');
    this.productService.getAllProducts().subscribe({
      next: (data) => {
        this.products = data;
        console.log(data);
      },
      error: (err) => console.log(err),
      complete: () => console.log('Getting all products'),
    });
  }

  getAllProductsByCategory(category: string) {
    this.productService
      .getAllProductsByCategory(category)
      .subscribe((prod) => (this.products = prod));
  }
  slideConfig = { slidesToShow: 1, slidesToScroll: 1 };
}
